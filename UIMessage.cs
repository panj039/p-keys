using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P_Keys
{
    internal class UIMessage : UIHotKey
    {
        public UIMessage()
        {
            this.HotKeyLabel = "Message";
        }

        public String Message
        {
            set => this.HotKey = value;
        }
    }
}
