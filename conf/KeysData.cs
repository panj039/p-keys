using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P_Keys.conf
{
    public class KeysData
    {
        public char Key {  get; set; }
        public List<KeysCell> Links { get; set; }

        public string ToStringDescribe()
        {
            return $"{Key} = {string.Join(" + ", Links.Select(x => x.Key))}";
        }
    }
}
