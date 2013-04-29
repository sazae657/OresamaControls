namespace TestContainer
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナ変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナで生成されたコード

        /// <summary>
        /// デザイナ サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディタで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.xmCheckBox1 = new Oresama.Widget.Primitive.XmCheckBox();
            this.xmPushButton2 = new Oresama.Widget.Primitive.XmPushButton();
            this.xmPushButton1 = new Oresama.Widget.Primitive.XmPushButton();
            this.xmTextBox1 = new Oresama.Widget.Primitive.XmTextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(220, 209);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(80, 16);
            this.checkBox1.TabIndex = 3;
            this.checkBox1.Text = "checkBox1";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.xmTextBox1);
            this.panel1.Controls.Add(this.xmCheckBox1);
            this.panel1.Location = new System.Drawing.Point(25, 248);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(189, 84);
            this.panel1.TabIndex = 4;
            // 
            // xmCheckBox1
            // 
            this.xmCheckBox1.Checked = false;
            this.xmCheckBox1.CheckState = System.Windows.Forms.CheckState.Unchecked;
            this.xmCheckBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.xmCheckBox1.Location = new System.Drawing.Point(0, 0);
            this.xmCheckBox1.Name = "xmCheckBox1";
            this.xmCheckBox1.ShadowThickness = 3;
            this.xmCheckBox1.Size = new System.Drawing.Size(189, 32);
            this.xmCheckBox1.TabIndex = 1;
            this.xmCheckBox1.Text = "xmCheckBox1";
            this.xmCheckBox1.UseVisualStyleBackColor = true;
            this.xmCheckBox1.Click += new System.EventHandler(this.xmCheckBox1_Click);
            // 
            // xmPushButton2
            // 
            this.xmPushButton2.DialogResult = System.Windows.Forms.DialogResult.None;
            this.xmPushButton2.Location = new System.Drawing.Point(183, 36);
            this.xmPushButton2.Name = "xmPushButton2";
            this.xmPushButton2.ShadowThickness = 2;
            this.xmPushButton2.Size = new System.Drawing.Size(147, 68);
            this.xmPushButton2.TabIndex = 2;
            this.xmPushButton2.Text = "xmPushButton2";
            this.xmPushButton2.UseVisualStyleBackColor = true;
            this.xmPushButton2.Click += new System.EventHandler(this.xmPushButton2_Click);
            // 
            // xmPushButton1
            // 
            this.xmPushButton1.DialogResult = System.Windows.Forms.DialogResult.None;
            this.xmPushButton1.Location = new System.Drawing.Point(25, 33);
            this.xmPushButton1.Name = "xmPushButton1";
            this.xmPushButton1.ShadowThickness = 3;
            this.xmPushButton1.Size = new System.Drawing.Size(152, 71);
            this.xmPushButton1.TabIndex = 0;
            this.xmPushButton1.Text = "xmPushButton1";
            this.xmPushButton1.UseVisualStyleBackColor = true;
            // 
            // xmTextBox1
            // 
            this.xmTextBox1.FocusSelect = true;
            this.xmTextBox1.Location = new System.Drawing.Point(4, 39);
            this.xmTextBox1.Name = "xmTextBox1";
            this.xmTextBox1.PromptFont = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.xmTextBox1.PromptForeColor = System.Drawing.SystemColors.GrayText;
            this.xmTextBox1.PromptText = "";
            this.xmTextBox1.Size = new System.Drawing.Size(160, 19);
            this.xmTextBox1.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(448, 344);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.xmPushButton2);
            this.Controls.Add(this.xmPushButton1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Oresama.Widget.Primitive.XmPushButton xmPushButton1;
        private Oresama.Widget.Primitive.XmCheckBox xmCheckBox1;
        private Oresama.Widget.Primitive.XmPushButton xmPushButton2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Panel panel1;
        private Oresama.Widget.Primitive.XmTextBox xmTextBox1;




    }
}

