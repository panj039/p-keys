using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P_Keys
{
    public partial class UIMessage : UserControl
    {
        public UIMessage()
        {
            InitializeComponent();
        }

        public String Message
        {
            set => this.ui_tex_message.Text = value;
        }
    }
}
