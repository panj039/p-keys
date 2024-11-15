namespace P_Keys
{
    partial class P_Keys
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
            this.ui_com_group = new System.Windows.Forms.ComboBox();
            this.ui_flow_layout_panel = new System.Windows.Forms.FlowLayoutPanel();
            this.ui_tex_hotkey = new System.Windows.Forms.TextBox();
            this.ui_flow_layout_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ui_com_group
            // 
            this.ui_com_group.FormattingEnabled = true;
            this.ui_com_group.Location = new System.Drawing.Point(3, 30);
            this.ui_com_group.Name = "ui_com_group";
            this.ui_com_group.Size = new System.Drawing.Size(121, 20);
            this.ui_com_group.TabIndex = 0;
            // 
            // ui_flow_layout_panel
            // 
            this.ui_flow_layout_panel.AutoScroll = true;
            this.ui_flow_layout_panel.AutoSize = true;
            this.ui_flow_layout_panel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ui_flow_layout_panel.Controls.Add(this.ui_tex_hotkey);
            this.ui_flow_layout_panel.Controls.Add(this.ui_com_group);
            this.ui_flow_layout_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ui_flow_layout_panel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.ui_flow_layout_panel.Location = new System.Drawing.Point(0, 0);
            this.ui_flow_layout_panel.Name = "ui_flow_layout_panel";
            this.ui_flow_layout_panel.Size = new System.Drawing.Size(800, 450);
            this.ui_flow_layout_panel.TabIndex = 1;
            this.ui_flow_layout_panel.WrapContents = false;
            // 
            // ui_tex_hotkey
            // 
            this.ui_tex_hotkey.Location = new System.Drawing.Point(3, 3);
            this.ui_tex_hotkey.Name = "ui_tex_hotkey";
            this.ui_tex_hotkey.ReadOnly = true;
            this.ui_tex_hotkey.Size = new System.Drawing.Size(100, 21);
            this.ui_tex_hotkey.TabIndex = 1;
            // 
            // P_Keys
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ui_flow_layout_panel);
            this.Name = "P_Keys";
            this.Text = "P-Keys";
            this.ui_flow_layout_panel.ResumeLayout(false);
            this.ui_flow_layout_panel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox ui_com_group;
        private System.Windows.Forms.FlowLayoutPanel ui_flow_layout_panel;
        private System.Windows.Forms.TextBox ui_tex_hotkey;
    }
}

