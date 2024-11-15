using Newtonsoft.Json;
using System.Collections.Generic;
using System.Windows.Forms;

namespace P_Keys.conf
{
    internal class KeysGroup
    {
        public string Group { get; set; }
        public List<KeysData> Keys { get; set; }
        [JsonIgnore]
        public Dictionary<string, KeysData> DKeys = new Dictionary<string, KeysData>();

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
                string cKey = Config.GetCharFromKey(key);
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
