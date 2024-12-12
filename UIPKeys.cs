using P_Keys.conf;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Windows.Forms;
using WindowsInput;
using static P_Keys.UIPKeys;

namespace P_Keys
{
    public partial class UIPKeys : Form
    {
        private const int WH_KEYBOARD_LL = 13; // 低级键盘钩子
        private const int WM_KEYDOWN = 0x0100; // 键盘按下事件
        private IntPtr m_hookId = IntPtr.Zero;
        private InputSimulator m_simulator = new InputSimulator();
        private KeysGroup m_curKeysGroup;
        private List<Control> m_curUIKeysData = new List<Control>();
        private HookProc m_hookProc;

        public UIPKeys()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.AppIcon;
            UpdateStatusLabel();
            this.Size = new System.Drawing.Size(250, 300);
            this.FormClosing += (s, e) => UnhookWindowsHookEx(m_hookId);
            m_hookProc = new HookProc(HookCallback);
            m_hookId = SetHook(m_hookProc);
            ui_hotkey.Root = this;
            ui_group.Root = this;

            Config.Load();

            InitComponent();
        }

        public bool IsFunctionEnabled {
            get => ui_hotkey.Check;
            set => ui_hotkey.Check = value;
        }

        // 更新状态标签
        public void UpdateStatusLabel()
        {
            var info = IsFunctionEnabled ? "On " : "Off";
            this.Text = info;
            ui_hotkey.CheHotKey = info;
        }

        // Windows API
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr SetWindowsHookEx(int hookType, HookProc hookProc, IntPtr hInstance, uint threadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern bool UnhookWindowsHookEx(IntPtr hookId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr CallNextHookEx(IntPtr hookId, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll")]
        public static extern IntPtr GetModuleHandle(string moduleName);

        public delegate IntPtr HookProc(int nCode, IntPtr wParam, IntPtr lParam);

        // 设置键盘钩子
        private IntPtr SetHook(HookProc hookProc)
        {
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule)
            {
                return SetWindowsHookEx(WH_KEYBOARD_LL, hookProc, GetModuleHandle(curModule.ModuleName), 0);
            }
        }

        // 按键回调函数
        private IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0 && wParam == (IntPtr)WM_KEYDOWN)
            {
                Keys key = (Keys)Marshal.ReadInt32(lParam);

                // update message
                ui_message.Message = $"Key `{key}` Pressed";
                //Debug.WriteLine($"Key `{key}` Pressed");

                // 按下热键(默认`)键开启/关闭功能
                if (key == (Config.HotKey?.KKey ?? Keys.None)) // 反引号键 Keys.Oemtilde
                {
                    IsFunctionEnabled = !ui_hotkey.Check;
                    return (IntPtr)1;  // 返回1，表示此事件已被处理
                }

                // 如果按键映射启用，按下指定键时模拟后续按键组合
                if (IsFunctionEnabled)
                {
                    var keysData = m_curKeysGroup?.GetKeysData(key);
                    if (keysData != null)
                    {
                        //Debug.WriteLine("in");
                        if ((NestDepth == 0) || (Config.Nest && (NestDepth < Config.NestMax)))
                        {
                            NestDepth++;
                            foreach (var link in keysData.Links)
                            {
                                link.Key.VKey.Press(m_simulator, true);
                            }
                            m_simulator.Keyboard.Sleep(Config.PressDownTime);
                            for (int i = keysData.Links.Count - 1; i >= 0; i--)
                            {
                                var link = keysData.Links[i];
                                link.Key.VKey.Press(m_simulator, false);
                            }
                            NestDepth--;
                            //Debug.WriteLine("out");
                            return (IntPtr)1; // 阻止继续传递此事件
                        }
                    }
                }
            }

            return CallNextHookEx(m_hookId, nCode, wParam, lParam);
        }

        public void HookRestore()
        {
            m_hookId = SetHook(m_hookProc);
        }

        public void Reload()
        {
            Config.Load();

            ui_hotkey.HotKey = Config.HotKey?.SKey ?? "";
            ui_hotkey.CheckNest = Config.Nest;

            ui_group.Group.DataSource = null;
            ui_group.Group.DataSource = Config.Groups;
            ui_group.Group.DisplayMember = "Name";
            ui_group.Group.ValueMember = "Name";
        }

        public void SelectLastGroup()
        {
            ui_group.Group.SelectedIndex = Config.Groups.Count - 1;
        }

        // 窗口加载时，初始化状态
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            UpdateStatusLabel();
            this.ActiveControl = ui_group;
        }

        private void InitComponent()
        {
            // ui_hotkey
            ui_hotkey.HotKey = Config.HotKey?.SKey ?? "";
            ui_hotkey.CheckNest = Config.Nest;

            // ui_group
            ui_group.Group.DropDownStyle = ComboBoxStyle.DropDown;
            ui_group.Group.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            ui_group.Group.AutoCompleteSource = AutoCompleteSource.ListItems;

            ui_group.Group.DataSource = Config.Groups;
            ui_group.Group.DisplayMember = "Name";
            ui_group.Group.ValueMember = "Name";
            ui_group.Group.SelectedIndexChanged += OnUIComGroup;

            if (Config.Groups.Count > 0)
            {
                ui_group.Group.SelectedIndex = 0;
                OnUIComGroup(ui_group.Group, EventArgs.Empty);
            }
        }

        public IntPtr HookID { get => m_hookId; }

        private int NestDepth { get; set; }

        private void OnUIComGroup(object sender, EventArgs e)
        {
            foreach (Control control in m_curUIKeysData)
            {
                control.Dispose();
                ui_flow_layout_panel.Controls.Remove(control);
            }
            m_curUIKeysData.Clear();

            m_curKeysGroup = ui_group.Group.SelectedItem as KeysGroup;
            if (m_curKeysGroup == null)
            {
                return;
            }

            var groupName = m_curKeysGroup.Name;
            foreach (var key in m_curKeysGroup.Keys.Values)
            {
                var ui = new UIKeysData();
                ui.SetUITexKeysData(groupName, key, this);
                ui_flow_layout_panel.Controls.Add(ui);
                m_curUIKeysData.Add(ui);
            }
        }

        private void ui_menu_config_open_Click(object sender, EventArgs e)
        {
            using (var ctx = new HookContext(this))
            {
                Config.Open();
            }
        }

        private void ui_menu_config_reload_Click(object sender, EventArgs e)
        {
            using (var ctx = new HookContext(this))
            {
                Reload();
            }
        }

        private void ui_menu_help_all_support_keys_Click(object sender, EventArgs e)
        {
            using (var ctx = new HookContext(this))
            {
                string info = "All Support Keys:\n\n";
                int count = 0;
                int limit = 5;
                foreach (var strKey in KeysConfig.LisStrKeys)
                {
                    ++count;
                    info += strKey + ",";
                    if (count == limit)
                    {
                        info += "\n";
                    }
                    else
                    {
                        info += "\t";
                    }
                }
                info = info.Substring(0, info.Length - 2);
                MessageBox.Show(info, Config.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ui_menu_help_help_Click(object sender, EventArgs e)
        {
            using (var ctx = new HookContext(this))
            {
                MessageBox.Show(Config.HelpHelpInfo, Config.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ui_menu_help_about_Click(object sender, EventArgs e)
        {
            using (var ctx = new HookContext(this))
            {
                MessageBox.Show(Config.HelpAbortInfo, Config.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ui_menu_add_group_Click(object sender, EventArgs e)
        {
            using (var ctx = new HookContext(this))
            {
                var dialogParam = new UIInputFormParam();
                dialogParam.TitleText = "Add Group";
                dialogParam.LabelText = "Please input group name:";
                var dialog = new UIInputForm(dialogParam);
                if (dialog.ShowDialog() != DialogResult.OK) { return; }

                var groupName = dialog.UserInput;
                while (Config.Group(groupName) != null)
                {
                    var r = MessageBox.Show($"Group: {groupName} already exist.", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                    if (r == DialogResult.Cancel) { return; }

                    dialogParam.InputText = groupName;
                    dialog = new UIInputForm(dialogParam);
                    if (dialog.ShowDialog() != DialogResult.OK) { return; }
                    groupName = dialog.UserInput;
                }

                Config.AddGroup(groupName);
                Config.Save();
                Reload();
                SelectLastGroup();

                Config.InfoBox($"Group `{groupName}` added.");
            }
        }

        private void ui_menu_add_key_Click(object sender, EventArgs e)
        {
            using (var ctx = new HookContext(this))
            {
                var dialogParam = new UIInputFormParam();
                dialogParam.TitleText = "Add Key";
                dialogParam.LabelText = "Please input new key macro:";
                var kdN = UIKeysData.GetInputKeysData(this, dialogParam);
                if (kdN == null) { return; }

                var group = Config.Group(m_curKeysGroup.Name);
                if (group == null)
                {
                    MessageBox.Show($"Invalid Group: {m_curKeysGroup.Name}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                group.AddKeysData(kdN);
                Config.Save();
                Reload();

                Config.InfoBox($"Key `{kdN.ToStringDescribe()}` added to group `{group.Name}`.");
            }
        }
    }

    // use this to escape from "CallbackOnCollectedDelegate"
    public class HookContext : IDisposable
    {
        private bool disposed = false;
        private UIPKeys Root { get; set; }
        private bool IsFunctionEnabled { get; set; }

        public HookContext(UIPKeys root)
        {
            Root = root;
            UIPKeys.UnhookWindowsHookEx(Root.HookID); // unhook keboard
            IsFunctionEnabled = Root.IsFunctionEnabled; // backup enable status
            Root.IsFunctionEnabled = false; // disable function
            //Debug.WriteLine("禁用hook");
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this); // 防止终结器被调用
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            Root.HookRestore();
            Root.IsFunctionEnabled = IsFunctionEnabled;
            //Debug.WriteLine("恢复hook");

            disposed = true;
        }

        ~HookContext()
        {
            Dispose(false);
        }
    }
}
