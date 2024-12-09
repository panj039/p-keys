using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsInput.Native;

namespace P_Keys.conf
{
    internal class KeysConfig
    {
        public KeysConfig() { }
        public KeysConfig(string sKey, Keys kKey, VirtualKeyCode vKey) {
            Key = sKey.ToLower();
            KeyCode = kKey;
            VirtualKey = vKey;
        }
        public string Key { get; private set; }
        public Keys KeyCode { get; private set; }
        public VirtualKeyCode VirtualKey { get; private set; }

        public static readonly Dictionary<string, KeysConfig> SKeys;
        public static readonly Dictionary<Keys, KeysConfig> KKeys;
        public static readonly Dictionary<VirtualKeyCode, KeysConfig> VKeys;

        static KeysConfig()
        {
            SKeys = new Dictionary<string, KeysConfig>();
            KKeys = new Dictionary<Keys, KeysConfig>();
            VKeys = new Dictionary<VirtualKeyCode, KeysConfig>();

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
            RegKey("`", Keys.Oemtilde, VirtualKeyCode.OEM_3);
            RegKey("CTRL", Keys.ControlKey, VirtualKeyCode.CONTROL);
            RegKey("ALT", Keys.Alt, VirtualKeyCode.MENU);
            RegKey("SHIFT", Keys.ShiftKey, VirtualKeyCode.SHIFT);
            RegKey("TAB", Keys.Tab, VirtualKeyCode.TAB);
            RegKey("ENTER", Keys.Enter, VirtualKeyCode.RETURN);

            // mouse
            RegKey("LBUTTON", Keys.LButton, VirtualKeyCode.LBUTTON);
            RegKey("RBUTTON", Keys.RButton, VirtualKeyCode.RBUTTON);
            RegKey("MBUTTON", Keys.MButton, VirtualKeyCode.MBUTTON);
            RegKey("XBUTTON1", Keys.XButton1, VirtualKeyCode.XBUTTON1);
            RegKey("XBUTTON2", Keys.XButton2, VirtualKeyCode.XBUTTON2);
        }

        private static void RegKey(string sKey, Keys kKey, VirtualKeyCode vKey)
        {
            sKey = sKey.ToLower();

            KeysConfig c = new KeysConfig(sKey, kKey, vKey);
            SKeys[c.Key] = c;
            KKeys[c.KeyCode] = c;
            VKeys[c.VirtualKey] = c;
        }
    };
}
