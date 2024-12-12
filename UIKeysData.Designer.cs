namespace P_Keys
{
    partial class UIKeysData
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ui_tex_keys_data = new System.Windows.Forms.TextBox();
            this.ui_con_menu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ui_com_menu_edit = new System.Windows.Forms.ToolStripMenuItem();
            this.ui_com_menu_delete = new System.Windows.Forms.ToolStripMenuItem();
            this.ui_layout = new System.Windows.Forms.FlowLayoutPanel();
            this.ui_con_menu.SuspendLayout();
            this.ui_layout.SuspendLayout();
            this.SuspendLayout();
            // 
            // ui_tex_keys_data
            // 
            this.ui_tex_keys_data.ContextMenuStrip = this.ui_con_menu;
            this.ui_tex_keys_data.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ui_tex_keys_data.Location = new System.Drawing.Point(0, 0);
            this.ui_tex_keys_data.Margin = new System.Windows.Forms.Padding(0);
            this.ui_tex_keys_data.Name = "ui_tex_keys_data";
            this.ui_tex_keys_data.ReadOnly = true;
            this.ui_tex_keys_data.Size = new System.Drawing.Size(200, 21);
            this.ui_tex_keys_data.TabIndex = 0;
            // 
            // ui_con_menu
            // 
            this.ui_con_menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ui_com_menu_edit,
            this.ui_com_menu_delete});
            this.ui_con_menu.Name = "ui_con_menu";
            this.ui_con_menu.Size = new System.Drawing.Size(113, 48);
            // 
            // ui_com_menu_edit
            // 
            this.ui_com_menu_edit.Name = "ui_com_menu_edit";
            this.ui_com_menu_edit.Size = new System.Drawing.Size(112, 22);
            this.ui_com_menu_edit.Text = "edit";
            this.ui_com_menu_edit.Click += new System.EventHandler(this.ui_com_menu_edit_Click);
            // 
            // ui_com_menu_delete
            // 
            this.ui_com_menu_delete.Name = "ui_com_menu_delete";
            this.ui_com_menu_delete.Size = new System.Drawing.Size(112, 22);
            this.ui_com_menu_delete.Text = "delete";
            this.ui_com_menu_delete.Click += new System.EventHandler(this.ui_com_menu_delete_Click);
            // 
            // ui_layout
            // 
            this.ui_layout.AutoSize = true;
            this.ui_layout.Controls.Add(this.ui_tex_keys_data);
            this.ui_layout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ui_layout.Location = new System.Drawing.Point(0, 0);
            this.ui_layout.Margin = new System.Windows.Forms.Padding(0);
            this.ui_layout.Name = "ui_layout";
            this.ui_layout.Size = new System.Drawing.Size(200, 21);
            this.ui_layout.TabIndex = 2;
            // 
            // UIKeysData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ui_layout);
            this.Name = "UIKeysData";
            this.Size = new System.Drawing.Size(200, 21);
            this.ui_con_menu.ResumeLayout(false);
            this.ui_layout.ResumeLayout(false);
            this.ui_layout.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ui_tex_keys_data;
        private System.Windows.Forms.FlowLayoutPanel ui_layout;
        private System.Windows.Forms.ContextMenuStrip ui_con_menu;
        private System.Windows.Forms.ToolStripMenuItem ui_com_menu_edit;
        private System.Windows.Forms.ToolStripMenuItem ui_com_menu_delete;
    }
}
