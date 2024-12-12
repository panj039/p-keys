using P_Keys.conf;
using System;
using System.Windows.Forms;

namespace P_Keys
{
    public partial class UIKeysData : UserControl
    {
        public UIKeysData()
        {
            InitializeComponent();
        }

        public static KeysData GetInputKeysData(UIPKeys root, UIInputFormParam dialogParam)
        {
            var dialog = new UIInputForm(dialogParam);
            if (dialog.ShowDialog() != DialogResult.OK) { return null; }

            string userInput = dialog.UserInput;
            var kdN = new KeysData();
            while (!kdN.InitByStringDescribe(userInput))
            {
                var r = MessageBox.Show($"Invalid input: {userInput}\nPlease check your input.", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                if (r == DialogResult.Cancel) { return null; }

                dialogParam.InputText = userInput;
                dialog = new UIInputForm(dialogParam);
                if (dialog.ShowDialog() != DialogResult.OK) { return null; }
                userInput = dialog.UserInput;
            }

            return kdN;
        }

        public void SetUITexKeysData(string groupName, KeysData data, UIPKeys r)
        {
            GroupName = groupName;
            ui_tex_keys_data.Text = data.ToStringDescribe();
            Root = r;
        }

        private void ui_com_menu_edit_Click(object sender, EventArgs e)
        {
            using (var ctx = new HookContext(Root))
            {
                var keysData = ui_tex_keys_data.Text;
                var kdO = new KeysData();
                if (!kdO.InitByStringDescribe(keysData))
                {
                    MessageBox.Show($"KeysData: {keysData} Invalid");
                    return;
                }

                var dialogParam = new UIInputFormParam();
                dialogParam.TitleText = "Edit Key";
                dialogParam.LabelText = "Please input replace key macro:";
                dialogParam.InputText = keysData;
                var kdN = GetInputKeysData(Root, dialogParam);
                if (kdN == null) { return; }

                var group = Config.Group(GroupName);
                if (group == null)
                {
                    MessageBox.Show($"Invalid Group: {GroupName}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                group.DelKeysData(kdO.Key.SKey);
                group.AddKeysData(kdN);
                Config.Save();
                Root.Reload();

                Config.InfoBox($"Change Key from `{keysData}` to `{kdN.ToStringDescribe()}`.");
            }
        }

        private void ui_com_menu_delete_Click(object sender, EventArgs e)
        {
            using (var ctx = new HookContext(Root))
            {
                var keysData = ui_tex_keys_data.Text;
                var r = MessageBox.Show($"Delete: '{keysData}' ?", "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (r == DialogResult.No) { return; }

                var kdO = new KeysData();
                if (!kdO.InitByStringDescribe(keysData))
                {
                    MessageBox.Show($"KeysData: {keysData} Invalid");
                    return;
                }

                var group = Config.Group(GroupName);
                if (group == null)
                {
                    MessageBox.Show($"Invalid Group: {GroupName}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                group.DelKeysData(kdO.Key.SKey);
                Config.Save();
                Root.Reload();

                Config.InfoBox($"Key `{keysData}` macro deleted.");
            }
        }

        private string GroupName { get; set; }
        private UIPKeys Root {  get; set; }
    }
}
