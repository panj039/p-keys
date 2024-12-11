namespace P_Keys
{
    partial class UIHotKey
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
            this.ui_lab_hotkey = new System.Windows.Forms.Label();
            this.ui_tex_hotkey = new System.Windows.Forms.TextBox();
            this.ui_che_hotkey = new System.Windows.Forms.CheckBox();
            this.ui_flo_layout.SuspendLayout();
            this.SuspendLayout();
            // 
            // ui_flo_layout
            // 
            this.ui_flo_layout.AutoSize = true;
            this.ui_flo_layout.Controls.Add(this.ui_lab_hotkey);
            this.ui_flo_layout.Controls.Add(this.ui_tex_hotkey);
            this.ui_flo_layout.Controls.Add(this.ui_che_hotkey);
            this.ui_flo_layout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ui_flo_layout.Location = new System.Drawing.Point(0, 0);
            this.ui_flo_layout.Name = "ui_flo_layout";
            this.ui_flo_layout.Size = new System.Drawing.Size(200, 21);
            this.ui_flo_layout.TabIndex = 0;
            // 
            // ui_lab_hotkey
            // 
            this.ui_lab_hotkey.Location = new System.Drawing.Point(3, 3);
            this.ui_lab_hotkey.Margin = new System.Windows.Forms.Padding(3);
            this.ui_lab_hotkey.Name = "ui_lab_hotkey";
            this.ui_lab_hotkey.Size = new System.Drawing.Size(50, 12);
            this.ui_lab_hotkey.TabIndex = 0;
            this.ui_lab_hotkey.Text = "HotKey";
            // 
            // ui_tex_hotkey
            // 
            this.ui_tex_hotkey.CausesValidation = false;
            this.ui_tex_hotkey.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ui_tex_hotkey.Location = new System.Drawing.Point(56, 0);
            this.ui_tex_hotkey.Margin = new System.Windows.Forms.Padding(0);
            this.ui_tex_hotkey.Name = "ui_tex_hotkey";
            this.ui_tex_hotkey.ReadOnly = true;
            this.ui_tex_hotkey.Size = new System.Drawing.Size(88, 21);
            this.ui_tex_hotkey.TabIndex = 1;
            this.ui_tex_hotkey.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ui_che_hotkey
            // 
            this.ui_che_hotkey.Location = new System.Drawing.Point(147, 3);
            this.ui_che_hotkey.Name = "ui_che_hotkey";
            this.ui_che_hotkey.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ui_che_hotkey.Size = new System.Drawing.Size(50, 16);
            this.ui_che_hotkey.TabIndex = 3;
            this.ui_che_hotkey.Text = "Off";
            this.ui_che_hotkey.UseVisualStyleBackColor = true;
            this.ui_che_hotkey.CheckedChanged += new System.EventHandler(this.ui_che_hotkey_CheckedChanged);
            // 
            // UIHotKey
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ui_flo_layout);
            this.Name = "UIHotKey";
            this.Size = new System.Drawing.Size(200, 21);
            this.ui_flo_layout.ResumeLayout(false);
            this.ui_flo_layout.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel ui_flo_layout;
        private System.Windows.Forms.Label ui_lab_hotkey;
        private System.Windows.Forms.TextBox ui_tex_hotkey;
        private System.Windows.Forms.CheckBox ui_che_hotkey;
    }
}
