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
        public UIHotKey()
        {
            InitializeComponent();
        }

        public string HotKeyLabel
        {
            set => ui_lab_hotkey.Text = value;
        }

        public string HotKey
        {
            set => ui_tex_hotkey.Text = value;
        }
    }
}
