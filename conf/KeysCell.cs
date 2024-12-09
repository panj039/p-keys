using System.Windows.Forms;
using WindowsInput.Native;

namespace P_Keys.conf
{
    public class KeysCell
    {
        public string Key { get; set; }

        public bool VKey(ref VirtualKeyCode vkc)
        {
            if (KeysConfig.SKeys.TryGetValue(Key.ToLower(), out KeysConfig k))
            {
                vkc = k.VirtualKey;
                return true;
            }

            return false;
        }
    }
}
