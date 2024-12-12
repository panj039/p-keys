namespace P_Keys
{
    partial class UIInputForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.ui_label = new System.Windows.Forms.Label();
            this.ui_text = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.ui_but_ok = new System.Windows.Forms.Button();
            this.ui_but_cancel = new System.Windows.Forms.Button();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Controls.Add(this.ui_label);
            this.flowLayoutPanel1.Controls.Add(this.ui_text);
            this.flowLayoutPanel1.Controls.Add(this.flowLayoutPanel2);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(266, 96);
            this.flowLayoutPanel1.TabIndex = 4;
            // 
            // ui_label
            // 
            this.ui_label.AutoSize = true;
            this.ui_label.Location = new System.Drawing.Point(3, 0);
            this.ui_label.Name = "ui_label";
            this.ui_label.Padding = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.ui_label.Size = new System.Drawing.Size(47, 25);
            this.ui_label.TabIndex = 5;
            this.ui_label.Text = "label1";
            // 
            // ui_text
            // 
            this.ui_text.Location = new System.Drawing.Point(3, 28);
            this.ui_text.Name = "ui_text";
            this.ui_text.Size = new System.Drawing.Size(250, 21);
            this.ui_text.TabIndex = 4;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.AutoScroll = true;
            this.flowLayoutPanel2.AutoSize = true;
            this.flowLayoutPanel2.Controls.Add(this.ui_but_ok);
            this.flowLayoutPanel2.Controls.Add(this.ui_but_cancel);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 55);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(248, 29);
            this.flowLayoutPanel2.TabIndex = 8;
            // 
            // ui_but_ok
            // 
            this.ui_but_ok.AutoSize = true;
            this.ui_but_ok.Location = new System.Drawing.Point(3, 3);
            this.ui_but_ok.Name = "ui_but_ok";
            this.ui_but_ok.Size = new System.Drawing.Size(118, 23);
            this.ui_but_ok.TabIndex = 8;
            this.ui_but_ok.Text = "button1";
            this.ui_but_ok.UseVisualStyleBackColor = true;
            this.ui_but_ok.Click += new System.EventHandler(this.ui_but_ok_Click);
            // 
            // ui_but_cancel
            // 
            this.ui_but_cancel.AutoSize = true;
            this.ui_but_cancel.Location = new System.Drawing.Point(127, 3);
            this.ui_but_cancel.Name = "ui_but_cancel";
            this.ui_but_cancel.Size = new System.Drawing.Size(118, 23);
            this.ui_but_cancel.TabIndex = 9;
            this.ui_but_cancel.Text = "button2";
            this.ui_but_cancel.UseVisualStyleBackColor = true;
            this.ui_but_cancel.Click += new System.EventHandler(this.ui_but_cancel_Click);
            // 
            // UIInputForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(266, 96);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "UIInputForm";
            this.Text = "UIInputForm";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label ui_label;
        private System.Windows.Forms.TextBox ui_text;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Button ui_but_ok;
        private System.Windows.Forms.Button ui_but_cancel;
    }
}