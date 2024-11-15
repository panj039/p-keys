using WindowsInput.Native;

namespace P_Keys.conf
{
    public class KeysCell
    {
        public string Key { get; set; }

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
