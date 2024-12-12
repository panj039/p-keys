using System;
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
