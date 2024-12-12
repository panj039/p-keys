using System;
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

        public Dictionary<object, object> Build()
        {
            var data = new Dictionary<object, object>();

            foreach (var item in Keys)
            {
                data[item.Key] = item.Value.Build();
            }

            return data;
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

        public void DelKeysData(string k)
        {
            Keys.Remove(k);
        }

        public void AddKeysData(KeysData kd)
        {
            Keys[kd.Key.SKey] = kd;
        }
    }

    public class KeysData
    {
        public KeyConfig Key { get; set; }
        public List<KeysCell> Links { get; set; }

        public KeysData() { }

        public KeysData(string k, List<object> links)
        {
            Key = new KeyConfig(k);
            Links = new List<KeysCell>();
            foreach (var link in links)
            {
                Links.Add(new KeysCell(link as Dictionary<object, object>));
            }
        }

        public List<object> Build()
        {
            var data = new List<object>();

            foreach (var link in Links)
            {
                data.Add(link.Build());
            }

            return data;
        }

        public bool InitByStringDescribe(string keysData)
        {
            string[] parts = keysData.Split(new[] { '=' }, 2);
            if (parts.Length != 2) { return false; }

            // 获取左边的变量
            string leftSide = parts[0].Trim();

            // 获取右边的部分
            string rightSide = parts[1].Trim();
            string[] variables = rightSide.Split(new[] { '+' }, StringSplitOptions.RemoveEmptyEntries)
                                           .Select(s => s.Trim())
                                           .ToArray();
            if (variables.Length == 0) {  return false; }

            // check
            if (KeysConfig.Key(leftSide) == null) { return false; }
            foreach (var variable in variables)
            {
                if (KeysConfig.Key(variable) == null) { return false; }
            }

            // set data
            Key = new KeyConfig(leftSide);
            Links = new List<KeysCell>();
            foreach (var variable in variables)
            {
                Links.Add(new KeysCell(variable));
            }

            return true;
        }

        public string ToStringDescribe()
        {
            return $"{Key.SKey} = {string.Join(" + ", Links.Select(x => x.Key.SKey))}";
        }
    }

    public class KeysCell
    {
        public KeyConfig Key { get; set; }
        public KeysCell(string sKey)
        {
            Key = new KeyConfig(sKey);
        }
        public KeysCell(Dictionary<object, object> d) : this(d[Config.YML_Key] as string) {}
        public Dictionary<object, object> Build()
        {
            var data = new Dictionary<object, object>();

            data[Config.YML_Key] = Key.SKey;

            return data;
        }
    }
}
