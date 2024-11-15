using System.Collections.Generic;
using System.Linq;

namespace P_Keys.conf
{
    public class KeysData
    {
        public string Key { get; set; }
        public List<KeysCell> Links { get; set; }

        public string ToStringDescribe()
        {
            return $"{Key} = {string.Join(" + ", Links.Select(x => x.Key))}";
        }
    }
}
