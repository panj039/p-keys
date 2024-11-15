using P_Keys.conf;
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
    public partial class UIKeysData : UserControl
    {
        public UIKeysData()
        {
            InitializeComponent();
        }

        public void SetUITexKeysData(KeysData data)
        {
            ui_tex_keys_data.Text = data.ToStringDescribe();
        }
    }
}
