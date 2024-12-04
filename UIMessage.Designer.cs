namespace P_Keys
{
    partial class UIMessage
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
            this.ui_lab_message = new System.Windows.Forms.Label();
            this.ui_tex_message = new System.Windows.Forms.TextBox();
            this.ui_flo_layout = new System.Windows.Forms.FlowLayoutPanel();
            this.ui_flo_layout.SuspendLayout();
            this.SuspendLayout();
            // 
            // ui_lab_message
            // 
            this.ui_lab_message.Location = new System.Drawing.Point(3, 3);
            this.ui_lab_message.Margin = new System.Windows.Forms.Padding(3);
            this.ui_lab_message.Name = "ui_lab_message";
            this.ui_lab_message.Size = new System.Drawing.Size(50, 12);
            this.ui_lab_message.TabIndex = 0;
            this.ui_lab_message.Text = "Message";
            // 
            // ui_tex_message
            // 
            this.ui_tex_message.CausesValidation = false;
            this.ui_tex_message.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ui_tex_message.Location = new System.Drawing.Point(56, 0);
            this.ui_tex_message.Margin = new System.Windows.Forms.Padding(0);
            this.ui_tex_message.Name = "ui_tex_message";
            this.ui_tex_message.ReadOnly = true;
            this.ui_tex_message.Size = new System.Drawing.Size(144, 21);
            this.ui_tex_message.TabIndex = 1;
            // 
            // ui_flo_layout
            // 
            this.ui_flo_layout.AutoSize = true;
            this.ui_flo_layout.Controls.Add(this.ui_lab_message);
            this.ui_flo_layout.Controls.Add(this.ui_tex_message);
            this.ui_flo_layout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ui_flo_layout.Location = new System.Drawing.Point(0, 0);
            this.ui_flo_layout.Name = "ui_flo_layout";
            this.ui_flo_layout.Size = new System.Drawing.Size(200, 21);
            this.ui_flo_layout.TabIndex = 1;
            // 
            // UIMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ui_flo_layout);
            this.Name = "UIMessage";
            this.Size = new System.Drawing.Size(200, 21);
            this.ui_flo_layout.ResumeLayout(false);
            this.ui_flo_layout.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ui_lab_message;
        private System.Windows.Forms.TextBox ui_tex_message;
        private System.Windows.Forms.FlowLayoutPanel ui_flo_layout;
    }
}
