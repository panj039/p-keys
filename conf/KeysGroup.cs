using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace P_Keys.conf
{
    internal class KeysGroup
    {
        public string Name { get; set; }
        public Dictionary<string, KeysData> Keys = new Dictionary<string, KeysData>();

        public KeysGroup(string name, Dictionary<object, object> keys)
        {
            Name = name;
            Keys.Clear();
            foreach (var key in keys)
            {
                var kd = new KeysData(key.Key as string, key.Value as List<object>);
                Keys[kd.Key.SKey] = kd;
            }
        }

        public KeysData GetKeysData(Keys key)
        {
            var k = KeysConfig.Key(key);
            if (k == null) return null;
            if (Keys.TryGetValue(k.SKey, out KeysData value))
            {
                return value;
            }

            return null;
        }
    }

    public class KeysData
    {
        public KeyConfig Key { get; set; }
        public List<KeysCell> Links { get; set; }

        public KeysData(string k, List<object> links)
        {
            Key = new KeyConfig(k);
            Links = new List<KeysCell>();
            foreach (var link in links)
            {
                Links.Add(new KeysCell(link as Dictionary<object, object>));
            }
        }

        public string ToStringDescribe()
        {
            return $"{Key.SKey} = {string.Join(" + ", Links.Select(x => x.Key.SKey))}";
        }
    }

    public class KeysCell
    {
        public KeyConfig Key { get; set; }
        public KeysCell(Dictionary<object, object> d)
        {
            Key = new KeyConfig(d["key"] as string);
        }
    }
}
