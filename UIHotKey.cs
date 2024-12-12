using P_Keys.conf;
using System;
using System.Windows.Forms;

namespace P_Keys
{
    public partial class UIHotKey : UserControl
    {
        public UIHotKey()
        {
            InitializeComponent();
        }

        public UIPKeys Root { get; set; }

        public string HotKey
        {
            get => ui_tex_hotkey.Text;
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

        public bool CheckNest
        {
            get => ui_che_nest.Checked;
            set
            {
                if (value == ui_che_nest.Checked)
                {
                    return;
                }
                ui_che_nest.Checked = value;
            }
        }

        private void ui_che_hotkey_CheckedChanged(object sender, EventArgs e)
        {
            this.Root.UpdateStatusLabel();
        }

        private void ui_con_menu_edit_Click(object sender, EventArgs e)
        {
            using (var ctx = new HookContext(Root))
            {
                var hotKey = HotKey;
                var dialogParam = new UIInputFormParam();
                dialogParam.TitleText = "Edit Hotkey";
                dialogParam.LabelText = "Input new hotkey(keep empty to disable)";
                dialogParam.InputText = hotKey;
                var dialog = new UIInputForm(dialogParam);
                if (dialog.ShowDialog() != DialogResult.OK) { return; }

                string userInput = dialog.UserInput;
                var k = KeysConfig.Key(userInput);
                while ((k == null) && (userInput != ""))
                {
                    var r = MessageBox.Show($"Invalid input: {userInput}\nPlease check your input.", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                    if (r == DialogResult.Cancel) { return; }

                    dialogParam.InputText = userInput;
                    dialog = new UIInputForm(dialogParam);
                    if (dialog.ShowDialog() != DialogResult.OK) { return; }
                    userInput = dialog.UserInput;
                    k = KeysConfig.Key(userInput);
                }

                Config.HotKey = k;
                Config.Save();
                Root.Reload();

                if (userInput == "")
                {
                    Config.InfoBox($"Disable hotkey, origin hotkey is `{hotKey}`.");
                }
                else
                {
                    Config.InfoBox($"Change hotkey from `{hotKey}` to `{userInput}`.");
                }
            }
        }

        private void ui_che_nest_CheckedChanged(object sender, EventArgs e)
        {
            if (Config.Nest == CheckNest) { return; }
            Config.Nest = CheckNest;
            Config.Save();
        }
    }
}
