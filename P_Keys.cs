﻿using P_Keys.conf;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using WindowsInput;
using WindowsInput.Native;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace P_Keys
{
    public partial class P_Keys : Form
    {
        private const int WH_KEYBOARD_LL = 13; // 低级键盘钩子
        private const int WM_KEYDOWN = 0x0100; // 键盘按下事件
        private IntPtr hookId = IntPtr.Zero;
        private InputSimulator simulator = new InputSimulator();
        private bool isFunctionEnabled = false;
        private KeysGroup m_curKeysGroup;
        private List<Control> m_curUIKeysData = new List<Control>();

        public P_Keys()
        {
            InitializeComponent();
            this.Text = "按键模拟器";
            this.Size = new System.Drawing.Size(300, 300);
            this.FormClosing += (s, e) => UnhookWindowsHookEx(hookId);
            hookId = SetHook(HookCallback);

            Config.Load();

            initComponent();
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

                // 按下反引号(`)键开启/关闭功能
                if (key == Keys.Oemtilde) // 反引号键
                {
                    isFunctionEnabled = !isFunctionEnabled;
                    UpdateStatusLabel();
                    return (IntPtr)1;  // 返回1，表示此事件已被处理
                }

                // 如果按键映射启用，按下 Z 键时模拟 X 和 C 键
                if (isFunctionEnabled)
                {
                    var keysData = m_curKeysGroup.GetKeysData(key);
                    if (keysData != null)
                    {
                        foreach (var link in keysData.Links)
                        {
                            VirtualKeyCode vkc = VirtualKeyCode.LBUTTON;
                            if (link.GetVirtualKeyCode(ref vkc))
                            {
                                simulator.Keyboard.KeyPress(vkc);
                            }
                        }
                        return (IntPtr)1; // 阻止继续传递此事件
                    }
                }
            }

            return CallNextHookEx(hookId, nCode, wParam, lParam);
        }

        // 更新状态标签
        private void UpdateStatusLabel()
        {
            this.Text = isFunctionEnabled ? "按键映射已启用" : "按键映射已禁用";
        }

        // 窗口加载时，初始化状态
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            UpdateStatusLabel();
        }

        private void initComponent()
        {
            // ui_com_group
            ui_com_group.DropDownStyle = ComboBoxStyle.DropDown;
            ui_com_group.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            ui_com_group.AutoCompleteSource = AutoCompleteSource.ListItems;

            ui_com_group.DataSource = Config.Groups;
            ui_com_group.DisplayMember = "Group";
            ui_com_group.ValueMember = "Group";
            ui_com_group.SelectedIndexChanged += on_ui_com_group;

            if (Config.Groups.Count > 0)
            {
                ui_com_group.SelectedIndex = 0;
                on_ui_com_group(ui_com_group, EventArgs.Empty);
            }

            // position and size
            this.Resize += new EventHandler(on_p_keys_resize);
        }

        private void on_ui_com_group(object sender, EventArgs e)
        {
            foreach (Control control in m_curUIKeysData)
            {
                control.Dispose();
                ui_flow_layout_panel.Controls.Remove(control);
            }
            m_curUIKeysData.Clear();

            m_curKeysGroup = ui_com_group.SelectedItem as KeysGroup;
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

        private void on_p_keys_resize(object sender, EventArgs e)
        {
            int formWidth = this.ClientSize.Width;
            int formHeight = this.ClientSize.Height;
        }
    }
}