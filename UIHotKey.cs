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
    public partial class UIHotKey : UserControl
    {
        UIPKeys root = null;

        public UIHotKey()
        {
            InitializeComponent();
        }

        public UIPKeys Root { set => root = value; }

        public string HotKey
        {
            set => ui_tex_hotkey.Text = value;
        }

        public string CheHotKey
        {
            set => ui_che_hotkey.Text = value;
        }

        public bool Check
        {
            get => ui_che_hotkey.Checked;
            set
            {
                if (value == ui_che_hotkey.Checked)
                {
                    return;
                }
                ui_che_hotkey.Checked = value;
            }
        }

        private void ui_che_hotkey_CheckedChanged(object sender, EventArgs e)
        {
            this.root.UpdateStatusLabel();
        }
    }
}
