using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsInput.Native;

namespace P_Keys.conf
{
    public class KeysCell
    {
        public char Key {  get; set; }

        public bool GetVirtualKeyCode(ref VirtualKeyCode vkc)
        {
            try
            {
                vkc = Config.GetVirtualKeyCodeFromChar(Key);
                return true;
            }
            catch { }

            return false;
        }
    }
}
