using System;
using System.Windows.Forms;

namespace P_Keys
{
    public partial class UIInputForm : Form
    {
        public UIInputForm(UIInputFormParam param)
        {
            InitializeComponent();
            SetParam(param);
        }

        public void SetParam(UIInputFormParam param)
        {
            this.Icon = Properties.Resources.AppIcon;
            this.Text = param.TitleText;
            this.ui_label.Text = param.LabelText;
            this.ui_text.Text = param.InputText;
            this.ui_but_ok.Text = param.ButtonOKText;
            this.ui_but_cancel.Text = param.ButtonCancelText;
        }

        private void ui_but_ok_Click(object sender, EventArgs e)
        {
            this.UserInput = ui_text.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void ui_but_cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult= DialogResult.Cancel;
            this.Close();
        }

        public string UserInput {  get; set; }
    }

    public class UIInputFormParam
    {
        public UIInputFormParam()
        {
            TitleText = "unknown title";
            LabelText = "unknown label";
            InputText = "";
            ButtonOKText = "OK";
            ButtonCancelText = "Cancel";
        }

        public string TitleText { get; set; }
        public string LabelText { get; set; }
        public string InputText { get; set; }
        public string ButtonOKText { get; set; }
        public string ButtonCancelText { get; set; }
    }
}
