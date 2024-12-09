using Newtonsoft.Json;
using System.Collections.Generic;
using System.Windows.Forms;

namespace P_Keys.conf
{
    internal class KeysGroup
    {
        public string Name { get; set; }
        public List<KeysData> Keys { get; set; }
        [JsonIgnore]
        public Dictionary<string, KeysData> DKeys = new Dictionary<string, KeysData>();

        public void Tidy()
        {
            DKeys.Clear();
            foreach (var key in Keys)
            {
                DKeys[key.Key.ToLower()] = key;
            }
        }

        public KeysData GetKeysData(Keys key)
        {
            string cKey = Config.SKey(key);
            if (DKeys.TryGetValue(cKey.ToLower(), out KeysData valueL))
            {
                return valueL;
            }

            return null;
        }
    }
}
