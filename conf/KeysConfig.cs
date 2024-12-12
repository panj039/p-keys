using System.Collections.Generic;
using System.Windows.Forms;
using WindowsInput.Native;

namespace P_Keys.conf
{
    public class KeysConfig
    {
        static KeysConfig()
        {
            SKeys = new Dictionary<string, KeyConfig>();
            KKeys = new Dictionary<Keys, KeyConfig>();
            VKeys = new Dictionary<VirtualKeyCode, KeyConfig>();
            LisStrKeys = new List<string>(); // help for all support keys

            // mouse
            RegKey("LBUTTON", Keys.LButton, VirtualKeyCode.LBUTTON);
            RegKey("RBUTTON", Keys.RButton, VirtualKeyCode.RBUTTON);
            RegKey("MBUTTON", Keys.MButton, VirtualKeyCode.MBUTTON);
            RegKey("XBUTTON1", Keys.XButton1, VirtualKeyCode.XBUTTON1);
            RegKey("XBUTTON2", Keys.XButton2, VirtualKeyCode.XBUTTON2);

            // number
            RegKey("0", Keys.D0, VirtualKeyCode.VK_0);
            RegKey("1", Keys.D1, VirtualKeyCode.VK_1);
            RegKey("2", Keys.D2, VirtualKeyCode.VK_2);
            RegKey("3", Keys.D3, VirtualKeyCode.VK_3);
            RegKey("4", Keys.D4, VirtualKeyCode.VK_4);
            RegKey("5", Keys.D5, VirtualKeyCode.VK_5);
            RegKey("6", Keys.D6, VirtualKeyCode.VK_6);
            RegKey("7", Keys.D7, VirtualKeyCode.VK_7);
            RegKey("8", Keys.D8, VirtualKeyCode.VK_8);
            RegKey("9", Keys.D9, VirtualKeyCode.VK_9);

            // alphabet
            RegKey("A", Keys.A, VirtualKeyCode.VK_A);
            RegKey("B", Keys.B, VirtualKeyCode.VK_B);
            RegKey("C", Keys.C, VirtualKeyCode.VK_C);
            RegKey("D", Keys.D, VirtualKeyCode.VK_D);
            RegKey("E", Keys.E, VirtualKeyCode.VK_E);
            RegKey("F", Keys.F, VirtualKeyCode.VK_F);
            RegKey("G", Keys.G, VirtualKeyCode.VK_G);
            RegKey("H", Keys.H, VirtualKeyCode.VK_H);
            RegKey("I", Keys.I, VirtualKeyCode.VK_I);
            RegKey("J", Keys.J, VirtualKeyCode.VK_J);
            RegKey("K", Keys.K, VirtualKeyCode.VK_K);
            RegKey("L", Keys.L, VirtualKeyCode.VK_L);
            RegKey("M", Keys.M, VirtualKeyCode.VK_M);
            RegKey("N", Keys.N, VirtualKeyCode.VK_N);
            RegKey("O", Keys.O, VirtualKeyCode.VK_O);
            RegKey("P", Keys.P, VirtualKeyCode.VK_P);
            RegKey("Q", Keys.Q, VirtualKeyCode.VK_Q);
            RegKey("R", Keys.R, VirtualKeyCode.VK_R);
            RegKey("S", Keys.S, VirtualKeyCode.VK_S);
            RegKey("T", Keys.T, VirtualKeyCode.VK_T);
            RegKey("U", Keys.U, VirtualKeyCode.VK_U);
            RegKey("V", Keys.V, VirtualKeyCode.VK_V);
            RegKey("W", Keys.W, VirtualKeyCode.VK_W);
            RegKey("X", Keys.X, VirtualKeyCode.VK_X);
            RegKey("Y", Keys.Y, VirtualKeyCode.VK_Y);
            RegKey("Z", Keys.Z, VirtualKeyCode.VK_Z);

            // control
            RegKey("ESC", Keys.Escape, VirtualKeyCode.ESCAPE);
            RegKey("ALT", Keys.Alt, VirtualKeyCode.MENU);
            RegKey("LAlt", Keys.LMenu, VirtualKeyCode.LMENU);
            RegKey("RAlt", Keys.RMenu, VirtualKeyCode.RMENU);
            RegKey("Ctrl", Keys.ControlKey, VirtualKeyCode.CONTROL);
            RegKey("LCtrl", Keys.LControlKey, VirtualKeyCode.LCONTROL);
            RegKey("RCtrl", Keys.RControlKey, VirtualKeyCode.RCONTROL);
            RegKey("SHIFT", Keys.ShiftKey, VirtualKeyCode.SHIFT);
            RegKey("LShift", Keys.LShiftKey, VirtualKeyCode.LSHIFT);
            RegKey("RShift", Keys.RShiftKey, VirtualKeyCode.RSHIFT);
            RegKey("TAB", Keys.Tab, VirtualKeyCode.TAB);
            RegKey("ENTER", Keys.Enter, VirtualKeyCode.RETURN);
            RegKey("SPACE", Keys.Space, VirtualKeyCode.SPACE);
            RegKey("BACK", Keys.Back, VirtualKeyCode.BACK);
            RegKey("LWin", Keys.LWin, VirtualKeyCode.LWIN);
            RegKey("RWin", Keys.RWin, VirtualKeyCode.RWIN);

            // function 1
            RegKey("F1", Keys.F1, VirtualKeyCode.F1);
            RegKey("F2", Keys.F2, VirtualKeyCode.F2);
            RegKey("F3", Keys.F3, VirtualKeyCode.F3);
            RegKey("F4", Keys.F4, VirtualKeyCode.F4);
            RegKey("F5", Keys.F5, VirtualKeyCode.F5);
            RegKey("F6", Keys.F6, VirtualKeyCode.F6);
            RegKey("F7", Keys.F7, VirtualKeyCode.F7);
            RegKey("F8", Keys.F8, VirtualKeyCode.F8);
            RegKey("F9", Keys.F9, VirtualKeyCode.F9);
            RegKey("F10", Keys.F10, VirtualKeyCode.F10);
            RegKey("F11", Keys.F11, VirtualKeyCode.F11);
            RegKey("F12", Keys.F12, VirtualKeyCode.F12);

            // function 2
            RegKey("PrintScreen", Keys.PrintScreen, VirtualKeyCode.SNAPSHOT);
            RegKey("ScrollLock", Keys.Scroll, VirtualKeyCode.SCROLL);
            RegKey("Pause", Keys.Pause, VirtualKeyCode.PAUSE);

            // function 3
            RegKey("Insert", Keys.Insert, VirtualKeyCode.INSERT);
            RegKey("Home", Keys.Home, VirtualKeyCode.HOME);
            RegKey("Delete", Keys.Delete, VirtualKeyCode.DELETE);
            RegKey("End", Keys.End, VirtualKeyCode.END);
            RegKey("PageUp", Keys.PageUp, VirtualKeyCode.PRIOR);
            RegKey("PageDown", Keys.PageDown, VirtualKeyCode.NEXT);

            // direction
            RegKey("Up", Keys.Up, VirtualKeyCode.UP);
            RegKey("Down", Keys.Down, VirtualKeyCode.DOWN);
            RegKey("Left", Keys.Left, VirtualKeyCode.LEFT);
            RegKey("Right", Keys.Right, VirtualKeyCode.RIGHT);

            // keypad
            RegKey("Num+", Keys.Add, VirtualKeyCode.ADD);
            RegKey("Num-", Keys.Subtract, VirtualKeyCode.SUBTRACT);
            RegKey("Num*", Keys.Multiply, VirtualKeyCode.MULTIPLY);
            RegKey("Num/", Keys.Divide, VirtualKeyCode.DIVIDE);
            RegKey("Num.", Keys.Decimal, VirtualKeyCode.DECIMAL);
            RegKey("Num0", Keys.NumPad0, VirtualKeyCode.NUMPAD0);
            RegKey("Num1", Keys.NumPad1, VirtualKeyCode.NUMPAD1);
            RegKey("Num2", Keys.NumPad2, VirtualKeyCode.NUMPAD2);
            RegKey("Num3", Keys.NumPad3, VirtualKeyCode.NUMPAD3);
            RegKey("Num4", Keys.NumPad4, VirtualKeyCode.NUMPAD4);
            RegKey("Num5", Keys.NumPad5, VirtualKeyCode.NUMPAD5);
            RegKey("Num6", Keys.NumPad6, VirtualKeyCode.NUMPAD6);
            RegKey("Num7", Keys.NumPad7, VirtualKeyCode.NUMPAD7);
            RegKey("Num8", Keys.NumPad8, VirtualKeyCode.NUMPAD8);
            RegKey("Num9", Keys.NumPad9, VirtualKeyCode.NUMPAD9);

            // symbol
            RegKey("`", Keys.Oemtilde, VirtualKeyCode.OEM_3);
            RegKey("-", Keys.OemMinus, VirtualKeyCode.OEM_MINUS);
            RegKey("+", Keys.Oemplus, VirtualKeyCode.OEM_PLUS);
            RegKey(",", Keys.Oemcomma, VirtualKeyCode.OEM_COMMA);
            RegKey(".", Keys.OemPeriod, VirtualKeyCode.OEM_PERIOD);
            //RegKey("[", Keys.OemOpenBrackets, VirtualKeyCode.OEM_OPENBRACKET);
            //RegKey("]", Keys.OemCloseBrackets, VirtualKeyCode.OEM_CLOSEBRACKET);
            //RegKey("\\", Keys.OemBackslash, VirtualKeyCode.OEM_BACKSLASH);
            //RegKey(";", Keys.OemSemicolon, VirtualKeyCode.OEM_SEMICOLON);
            //RegKey("'", Keys.OemQuotes, VirtualKeyCode.OEM_QUOTE);
            //RegKey("/", Keys.OemQuestion, VirtualKeyCode.OEM_SLASH);
        }

        public static readonly Dictionary<string, KeyConfig> SKeys;
        public static readonly Dictionary<Keys, KeyConfig> KKeys;
        public static readonly Dictionary<VirtualKeyCode, KeyConfig> VKeys;
        public static readonly List<string> LisStrKeys;

        public static KeyConfig Key(string k) { if (SKeys.TryGetValue(k, out KeyConfig kc)) { return kc; } return null; }
        public static KeyConfig Key(Keys k) { if (KKeys.TryGetValue(k, out KeyConfig kc)) { return kc; } return null; }
        public static KeyConfig Key(VirtualKeyCode k) { if (VKeys.TryGetValue(k, out KeyConfig kc)) { return kc; } return null; }

        private static void RegKey(string sKey, Keys kKey, VirtualKeyCode vKey)
        {
            sKey = sKey.ToLower();

            KeyConfig c = new KeyConfig(sKey, kKey, vKey);
            SKeys[c.SKey] = c;
            KKeys[c.KKey] = c;
            VKeys[c.VKey] = c;

            LisStrKeys.Add(sKey);
        }
    }

    public class KeyConfig
    {

        public KeyConfig() { }
        public KeyConfig(string sKey, Keys kKey, VirtualKeyCode vKey) {
            SKey = sKey.ToLower();
            KKey = kKey;
            VKey = vKey;
        }
        public KeyConfig(string sKey)
        {
            // not suitable for KeysConfig
            SKey = sKey.ToLower();
            if (KeysConfig.SKeys.TryGetValue(SKey, out KeyConfig k))
            {
                KKey = k.KKey;
                VKey = k.VKey;
            }
            else
            {
                MessageBox.Show($"Unknown string key: {sKey}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public string SKey { get; private set; }
        public Keys KKey { get; private set; }
        public VirtualKeyCode VKey { get; private set; }
    };
}
