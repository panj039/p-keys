namespace P_Keys
{
    partial class UIGroup
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
            this.ui_flo_layout = new System.Windows.Forms.FlowLayoutPanel();
            this.ui_lab_group = new System.Windows.Forms.Label();
            this.ui_com_group = new System.Windows.Forms.ComboBox();
            this.ui_flo_layout.SuspendLayout();
            this.SuspendLayout();
            // 
            // ui_flo_layout
            // 
            this.ui_flo_layout.Controls.Add(this.ui_lab_group);
            this.ui_flo_layout.Controls.Add(this.ui_com_group);
            this.ui_flo_layout.Location = new System.Drawing.Point(0, 0);
            this.ui_flo_layout.Name = "ui_flo_layout";
            this.ui_flo_layout.Size = new System.Drawing.Size(200, 21);
            this.ui_flo_layout.TabIndex = 1;
            // 
            // ui_lab_group
            // 
            this.ui_lab_group.Location = new System.Drawing.Point(3, 3);
            this.ui_lab_group.Margin = new System.Windows.Forms.Padding(3);
            this.ui_lab_group.Name = "ui_lab_group";
            this.ui_lab_group.Size = new System.Drawing.Size(50, 15);
            this.ui_lab_group.TabIndex = 1;
            this.ui_lab_group.Text = "Group";
            // 
            // ui_com_group
            // 
            this.ui_com_group.FormattingEnabled = true;
            this.ui_com_group.Location = new System.Drawing.Point(56, 0);
            this.ui_com_group.Margin = new System.Windows.Forms.Padding(0);
            this.ui_com_group.Name = "ui_com_group";
            this.ui_com_group.Size = new System.Drawing.Size(144, 20);
            this.ui_com_group.TabIndex = 2;
            // 
            // UIGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ui_flo_layout);
            this.Name = "UIGroup";
            this.Size = new System.Drawing.Size(200, 21);
            this.ui_flo_layout.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel ui_flo_layout;
        private System.Windows.Forms.Label ui_lab_group;
        private System.Windows.Forms.ComboBox ui_com_group;
    }
}
