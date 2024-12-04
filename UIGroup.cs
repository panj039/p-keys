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
    public partial class UIGroup : UserControl
    {
        public UIGroup()
        {
            InitializeComponent();
        }

        public ComboBox Group { get => ui_com_group; }
    }
}
