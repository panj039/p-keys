using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P_Keys.conf
{
    internal class KeysGroup
    {
        public string Group {  get; set; }
        public List<KeysData> Keys { get; set; }
        [JsonIgnore]
        public Dictionary<char, KeysData> DKeys = new Dictionary<char, KeysData>();

        public void Tidy()
        {
            DKeys.Clear();
            foreach (var key in Keys)
            {
                DKeys[key.Key] = key;
            }
        }

        public KeysData GetKeysData(Keys key)
        {
            try
            {
                char cKey = Config.GetCharFromKey(key);
                if (DKeys.TryGetValue(cKey, out KeysData value))
                {
                    return value;
                }
            }
            catch
            {
            }
            return null;
        }
    }
}
