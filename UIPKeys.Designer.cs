namespace P_Keys
{
    partial class UIPKeys
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.ui_menu = new System.Windows.Forms.MenuStrip();
            this.ui_menu_add = new System.Windows.Forms.ToolStripMenuItem();
            this.ui_menu_add_group = new System.Windows.Forms.ToolStripMenuItem();
            this.ui_menu_add_key = new System.Windows.Forms.ToolStripMenuItem();
            this.ui_menu_settings = new System.Windows.Forms.ToolStripMenuItem();
            this.ui_menu_settings_open = new System.Windows.Forms.ToolStripMenuItem();
            this.ui_menu_settings_reload = new System.Windows.Forms.ToolStripMenuItem();
            this.ui_menu_settings_separator = new System.Windows.Forms.ToolStripSeparator();
            this.ui_menu_settings_notification = new System.Windows.Forms.ToolStripMenuItem();
            this.ui_menu_help = new System.Windows.Forms.ToolStripMenuItem();
            this.ui_menu_help_all_support_keys = new System.Windows.Forms.ToolStripMenuItem();
            this.ui_menu_help_help = new System.Windows.Forms.ToolStripMenuItem();
            this.ui_menu_help_about = new System.Windows.Forms.ToolStripMenuItem();
            this.ui_flow_layout_panel = new System.Windows.Forms.FlowLayoutPanel();
            this.ui_hotkey = new P_Keys.UIHotKey();
            this.ui_group = new P_Keys.UIGroup();
            this.ui_message = new P_Keys.UIMessage();
            this.ui_spl_keys = new System.Windows.Forms.Splitter();
            this.ui_menu.SuspendLayout();
            this.ui_flow_layout_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ui_menu
            // 
            this.ui_menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ui_menu_add,
            this.ui_menu_settings,
            this.ui_menu_help});
            this.ui_menu.Location = new System.Drawing.Point(0, 0);
            this.ui_menu.Name = "ui_menu";
            this.ui_menu.Size = new System.Drawing.Size(800, 25);
            this.ui_menu.TabIndex = 0;
            this.ui_menu.Text = "menu";
            // 
            // ui_menu_add
            // 
            this.ui_menu_add.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ui_menu_add_group,
            this.ui_menu_add_key});
            this.ui_menu_add.Name = "ui_menu_add";
            this.ui_menu_add.Size = new System.Drawing.Size(44, 21);
            this.ui_menu_add.Text = "Add";
            // 
            // ui_menu_add_group
            // 
            this.ui_menu_add_group.Name = "ui_menu_add_group";
            this.ui_menu_add_group.Size = new System.Drawing.Size(113, 22);
            this.ui_menu_add_group.Text = "Group";
            this.ui_menu_add_group.Click += new System.EventHandler(this.ui_menu_add_group_Click);
            // 
            // ui_menu_add_key
            // 
            this.ui_menu_add_key.Name = "ui_menu_add_key";
            this.ui_menu_add_key.Size = new System.Drawing.Size(113, 22);
            this.ui_menu_add_key.Text = "Key";
            this.ui_menu_add_key.Click += new System.EventHandler(this.ui_menu_add_key_Click);
            // 
            // ui_menu_settings
            // 
            this.ui_menu_settings.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ui_menu_settings_open,
            this.ui_menu_settings_reload,
            this.ui_menu_settings_separator,
            this.ui_menu_settings_notification});
            this.ui_menu_settings.Name = "ui_menu_settings";
            this.ui_menu_settings.Size = new System.Drawing.Size(66, 21);
            this.ui_menu_settings.Text = "Settings";
            // 
            // ui_menu_settings_open
            // 
            this.ui_menu_settings_open.Name = "ui_menu_settings_open";
            this.ui_menu_settings_open.ShowShortcutKeys = false;
            this.ui_menu_settings_open.Size = new System.Drawing.Size(180, 22);
            this.ui_menu_settings_open.Text = "Open";
            this.ui_menu_settings_open.Click += new System.EventHandler(this.ui_menu_settings_open_Click);
            // 
            // ui_menu_settings_reload
            // 
            this.ui_menu_settings_reload.Name = "ui_menu_settings_reload";
            this.ui_menu_settings_reload.Size = new System.Drawing.Size(180, 22);
            this.ui_menu_settings_reload.Text = "Reload";
            this.ui_menu_settings_reload.Click += new System.EventHandler(this.ui_menu_settings_reload_Click);
            // 
            // ui_menu_settings_separator
            // 
            this.ui_menu_settings_separator.Name = "ui_menu_settings_separator";
            this.ui_menu_settings_separator.Size = new System.Drawing.Size(177, 6);
            // 
            // ui_menu_settings_notification
            // 
            this.ui_menu_settings_notification.Name = "ui_menu_settings_notification";
            this.ui_menu_settings_notification.Size = new System.Drawing.Size(180, 22);
            this.ui_menu_settings_notification.Text = "Notification";
            this.ui_menu_settings_notification.Click += new System.EventHandler(this.ui_menu_settings_notification_Click);
            // 
            // ui_menu_help
            // 
            this.ui_menu_help.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ui_menu_help_all_support_keys,
            this.ui_menu_help_help,
            this.ui_menu_help_about});
            this.ui_menu_help.Name = "ui_menu_help";
            this.ui_menu_help.Size = new System.Drawing.Size(47, 21);
            this.ui_menu_help.Text = "Help";
            // 
            // ui_menu_help_all_support_keys
            // 
            this.ui_menu_help_all_support_keys.Name = "ui_menu_help_all_support_keys";
            this.ui_menu_help_all_support_keys.Size = new System.Drawing.Size(172, 22);
            this.ui_menu_help_all_support_keys.Text = "All Support Keys";
            this.ui_menu_help_all_support_keys.Click += new System.EventHandler(this.ui_menu_help_all_support_keys_Click);
            // 
            // ui_menu_help_help
            // 
            this.ui_menu_help_help.Name = "ui_menu_help_help";
            this.ui_menu_help_help.Size = new System.Drawing.Size(172, 22);
            this.ui_menu_help_help.Text = "Help";
            this.ui_menu_help_help.Click += new System.EventHandler(this.ui_menu_help_help_Click);
            // 
            // ui_menu_help_about
            // 
            this.ui_menu_help_about.Name = "ui_menu_help_about";
            this.ui_menu_help_about.Size = new System.Drawing.Size(172, 22);
            this.ui_menu_help_about.Text = "About";
            this.ui_menu_help_about.Click += new System.EventHandler(this.ui_menu_help_about_Click);
            // 
            // ui_flow_layout_panel
            // 
            this.ui_flow_layout_panel.AutoScroll = true;
            this.ui_flow_layout_panel.AutoSize = true;
            this.ui_flow_layout_panel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ui_flow_layout_panel.Controls.Add(this.ui_hotkey);
            this.ui_flow_layout_panel.Controls.Add(this.ui_group);
            this.ui_flow_layout_panel.Controls.Add(this.ui_message);
            this.ui_flow_layout_panel.Controls.Add(this.ui_spl_keys);
            this.ui_flow_layout_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ui_flow_layout_panel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.ui_flow_layout_panel.Location = new System.Drawing.Point(0, 25);
            this.ui_flow_layout_panel.Name = "ui_flow_layout_panel";
            this.ui_flow_layout_panel.Size = new System.Drawing.Size(800, 425);
            this.ui_flow_layout_panel.TabIndex = 2;
            this.ui_flow_layout_panel.WrapContents = false;
            // 
            // ui_hotkey
            // 
            this.ui_hotkey.Check = false;
            this.ui_hotkey.CheckNest = false;
            this.ui_hotkey.HotKey = "";
            this.ui_hotkey.Location = new System.Drawing.Point(3, 3);
            this.ui_hotkey.Name = "ui_hotkey";
            this.ui_hotkey.Root = null;
            this.ui_hotkey.Size = new System.Drawing.Size(200, 21);
            this.ui_hotkey.TabIndex = 2;
            // 
            // ui_group
            // 
            this.ui_group.AutoSize = true;
            this.ui_group.Location = new System.Drawing.Point(3, 30);
            this.ui_group.Name = "ui_group";
            this.ui_group.Root = null;
            this.ui_group.Size = new System.Drawing.Size(203, 24);
            this.ui_group.TabIndex = 3;
            // 
            // ui_message
            // 
            this.ui_message.Location = new System.Drawing.Point(3, 60);
            this.ui_message.Name = "ui_message";
            this.ui_message.Size = new System.Drawing.Size(200, 21);
            this.ui_message.TabIndex = 5;
            // 
            // ui_spl_keys
            // 
            this.ui_spl_keys.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ui_spl_keys.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ui_spl_keys.Location = new System.Drawing.Point(3, 87);
            this.ui_spl_keys.Name = "ui_spl_keys";
            this.ui_spl_keys.Size = new System.Drawing.Size(203, 3);
            this.ui_spl_keys.TabIndex = 4;
            this.ui_spl_keys.TabStop = false;
            // 
            // UIPKeys
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ui_flow_layout_panel);
            this.Controls.Add(this.ui_menu);
            this.MainMenuStrip = this.ui_menu;
            this.Name = "UIPKeys";
            this.Text = "P-Keys";
            this.ui_menu.ResumeLayout(false);
            this.ui_menu.PerformLayout();
            this.ui_flow_layout_panel.ResumeLayout(false);
            this.ui_flow_layout_panel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip ui_menu;
        private System.Windows.Forms.ToolStripMenuItem ui_menu_settings;
        private System.Windows.Forms.ToolStripMenuItem ui_menu_settings_open;
        private System.Windows.Forms.FlowLayoutPanel ui_flow_layout_panel;
        private UIHotKey ui_hotkey;
        private UIGroup ui_group;
        private System.Windows.Forms.Splitter ui_spl_keys;
        private System.Windows.Forms.ToolStripMenuItem ui_menu_settings_reload;
        private UIMessage ui_message;
        private System.Windows.Forms.ToolStripMenuItem ui_menu_help;
        private System.Windows.Forms.ToolStripMenuItem ui_menu_help_about;
        private System.Windows.Forms.ToolStripMenuItem ui_menu_help_all_support_keys;
        private System.Windows.Forms.ToolStripMenuItem ui_menu_add;
        private System.Windows.Forms.ToolStripMenuItem ui_menu_add_group;
        private System.Windows.Forms.ToolStripMenuItem ui_menu_add_key;
        private System.Windows.Forms.ToolStripMenuItem ui_menu_help_help;
        private System.Windows.Forms.ToolStripSeparator ui_menu_settings_separator;
        private System.Windows.Forms.ToolStripMenuItem ui_menu_settings_notification;
    }
}

