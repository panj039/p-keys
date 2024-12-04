using P_Keys.conf;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Threading;
using System.Windows.Forms;
using WindowsInput;
using WindowsInput.Native;

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

        public UIPKeys()
        {
            InitializeComponent();
            this.Text = "Disable";
            this.Size = new System.Drawing.Size(230, 300);
            this.FormClosing += (s, e) => UnhookWindowsHookEx(m_hookId);
            m_hookId = SetHook(HookCallback);
            ui_hotkey.Root = this;

            Config.Load();

            InitComponent();
        }

        public bool IsFunctionEnabled {
            get => ui_hotkey.Check;
        }

        // 更新状态标签
        public void UpdateStatusLabel()
        {
            this.Text = IsFunctionEnabled ? "Enable" : "Disable";
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

                // 按下热键(默认`)键开启/关闭功能
                if (key == Config.HotKey) // 反引号键 Keys.Oemtilde
                {
                    ui_hotkey.Check = !ui_hotkey.Check;
                    return (IntPtr)1;  // 返回1，表示此事件已被处理
                }

                // 如果按键映射启用，按下指定键时模拟后续按键组合
                if (IsFunctionEnabled)
                {
                    var keysData = m_curKeysGroup.GetKeysData(key);
                    if (keysData != null)
                    {
                        foreach (var link in keysData.Links)
                        {
                            VirtualKeyCode vkc = VirtualKeyCode.LBUTTON;
                            if (link.GetVirtualKeyCode(ref vkc))
                            {
                                m_simulator.Keyboard.KeyDown(vkc);
                                //m_simulator.Keyboard.KeyPress(vkc);
                            }
                        }
                        m_simulator.Keyboard.Sleep(50);
                        for (int i = keysData.Links.Count - 1; i >= 0; i--)
                        {
                            var link = keysData.Links[i];
                            VirtualKeyCode vkc = VirtualKeyCode.LBUTTON;
                            if (link.GetVirtualKeyCode(ref vkc))
                            {
                                m_simulator.Keyboard.KeyUp(vkc);
                            }
                        }
                        return (IntPtr)1; // 阻止继续传递此事件
                    }
                }
            }

            return CallNextHookEx(m_hookId, nCode, wParam, lParam);
        }

        // 窗口加载时，初始化状态
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            UpdateStatusLabel();
        }

        private void InitComponent()
        {
            // ui_hotkey
            ui_hotkey.HotKey = Config.GetCharFromKey(Config.HotKey);

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

            foreach (var key in m_curKeysGroup.Keys)
            {
                var ui = new UIKeysData();
                ui.SetUITexKeysData(key);
                ui_flow_layout_panel.Controls.Add(ui);
                m_curUIKeysData.Add(ui);
            }
        }

        private void ui_menu_config_open_Click(object sender, EventArgs e)
        {
            Config.Open();
        }

        private void ui_menu_config_reload_Click(object sender, EventArgs e)
        {
            Config.Load();
            ui_hotkey.HotKey = Config.GetCharFromKey(Config.HotKey);
            ui_group.Group.DataSource = Config.Groups;
            ui_group.Group.Refresh();
        }

        private void ui_menu_help_about_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Config.HelpAbortInfo, Config.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
