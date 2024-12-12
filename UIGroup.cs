using P_Keys.conf;
using System;
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
        public UIPKeys Root { get; set; }

        private void ui_con_menu_rename_Click(object sender, EventArgs e)
        {
            using (var ctx = new HookContext(Root))
            {
                var groupName = Group.Text;
                var dialogParam = new UIInputFormParam();
                dialogParam.TitleText = "Rename Group";
                dialogParam.LabelText = "Input new group name:";
                dialogParam.InputText = groupName;
                var dialog = new UIInputForm(dialogParam);
                if (dialog.ShowDialog() != DialogResult.OK) { return; }

                string userInput = dialog.UserInput;
                
                while ((userInput == "") || (Config.Group(userInput) != null))
                {
                    var r = MessageBox.Show($"Invalid input: {userInput}.\nMaybe duplicate groupname.\nPlease check your input.", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                    if (r == DialogResult.Cancel) { return; }

                    dialogParam.InputText = userInput;
                    dialog = new UIInputForm(dialogParam);
                    if (dialog.ShowDialog() != DialogResult.OK) { return; }
                    userInput = dialog.UserInput;
                }

                var group = Config.Group(groupName);
                group.Name = userInput;
                Config.Save();
                Root.Reload();

                Config.InfoBox($"Group `{groupName}` renamed to `{userInput}`.");
            }
        }

        private void ui_com_menu_duplicate_Click(object sender, EventArgs e)
        {
            using (var ctx = new HookContext(Root))
            {
                var groupName = Group.Text;
                var group = Config.Group(groupName);
                if (group == null)
                {
                    MessageBox.Show($"Invalid group name: {groupName}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var groupNameNPre = $"{group.Name}_duplicate";
                var groupNameNSuf = "";
                var index = 0;
                while (Config.Group(groupNameNPre + groupNameNSuf) != null)
                {
                    groupNameNSuf = $"({index++})";
                }
                var groupNameN = groupNameNPre + groupNameNSuf;

                var groupData = group.Build();
                var groupN = new KeysGroup(groupNameN, groupData);
                Config.AddGroup(groupN);
                Config.Save();
                Root.Reload();
                Root.SelectLastGroup();

                Config.InfoBox($"Duplicate `{groupName}` to `{groupN.Name}` done.");
            }
        }

        private void ui_con_menu_delete_Click(object sender, EventArgs e)
        {
            using (var ctx = new HookContext(Root))
            {
                var groupName = Group.Text;
                var r = MessageBox.Show($"Delete group: {groupName}.", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (r == DialogResult.No) { return; }

                Config.DelGroup(groupName);
                Config.Save();
                Root.Reload();

                Config.InfoBox($"Group `{groupName}` deleted.");
            }
        }
    }
}
