namespace C3_Form_testing
{
    partial class Form4
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form4));
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.button5 = new System.Windows.Forms.Button();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.button6 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(35)))), ((int)(((byte)(45)))));
            this.label1.Font = new System.Drawing.Font("굴림", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(99, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "설정";
            // 
            // button1
            // 
            this.button1.Image = global::C3_Form_testing.Properties.Resources.button6;
            this.button1.Location = new System.Drawing.Point(29, 66);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(97, 34);
            this.button1.TabIndex = 1;
            this.button1.Text = "난이도 설정";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.GameLevel_Setting_button);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(40)))), ((int)(((byte)(55)))));
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.checkBox1.Location = new System.Drawing.Point(98, 186);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(60, 16);
            this.checkBox1.TabIndex = 2;
            this.checkBox1.Text = "창모드";
            this.checkBox1.UseVisualStyleBackColor = false;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // button2
            // 
            this.button2.Image = global::C3_Form_testing.Properties.Resources.button6;
            this.button2.Location = new System.Drawing.Point(132, 66);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(97, 34);
            this.button2.TabIndex = 3;
            this.button2.Text = "튜토리얼";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Tutorial_Setting_button);
            // 
            // button3
            // 
            this.button3.Image = global::C3_Form_testing.Properties.Resources.button6;
            this.button3.Location = new System.Drawing.Point(29, 146);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(200, 34);
            this.button3.TabIndex = 4;
            this.button3.Text = "폰트설정";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.FontChange_Setting_button);
            // 
            // button4
            // 
            this.button4.Image = global::C3_Form_testing.Properties.Resources.button6;
            this.button4.Location = new System.Drawing.Point(132, 245);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(97, 34);
            this.button4.TabIndex = 5;
            this.button4.Text = "닫기";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.SettingClose_button);
            // 
            // button5
            // 
            this.button5.Image = global::C3_Form_testing.Properties.Resources.button6;
            this.button5.Location = new System.Drawing.Point(29, 106);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(200, 34);
            this.button5.TabIndex = 6;
            this.button5.Text = "전투 딜레이 제거";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Battle_Delay_Delete);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(35)))), ((int)(((byte)(45)))));
            this.radioButton1.ForeColor = System.Drawing.Color.White;
            this.radioButton1.Location = new System.Drawing.Point(29, 208);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(79, 16);
            this.radioButton1.TabIndex = 8;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "1920, 1080";
            this.radioButton1.UseVisualStyleBackColor = false;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(35)))), ((int)(((byte)(45)))));
            this.radioButton2.ForeColor = System.Drawing.Color.White;
            this.radioButton2.Location = new System.Drawing.Point(156, 208);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(73, 16);
            this.radioButton2.TabIndex = 9;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "1440, 900";
            this.radioButton2.UseVisualStyleBackColor = false;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // button6
            // 
            this.button6.Image = global::C3_Form_testing.Properties.Resources.button6;
            this.button6.Location = new System.Drawing.Point(29, 245);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(97, 34);
            this.button6.TabIndex = 10;
            this.button6.Text = "게임종료";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::C3_Form_testing.Properties.Resources.OPTION1;
            this.ClientSize = new System.Drawing.Size(254, 291);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form4";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "설정";
            this.Load += new System.EventHandler(this.Form4_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.Button button6;
    }
}