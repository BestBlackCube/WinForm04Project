namespace C3_Form_testing
{
    partial class Form5
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form5));
            this.GameStart_btn = new System.Windows.Forms.Button();
            this.GameStart_tutorial = new System.Windows.Forms.Button();
            this.GameStart_Setting_btn = new System.Windows.Forms.Button();
            this.GameEnd_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // GameStart_btn
            // 
            this.GameStart_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.GameStart_btn.BackgroundImage = global::C3_Form_testing.Properties.Resources.button8;
            this.GameStart_btn.Font = new System.Drawing.Font("굴림", 30F, System.Drawing.FontStyle.Bold);
            this.GameStart_btn.Location = new System.Drawing.Point(797, 628);
            this.GameStart_btn.Name = "GameStart_btn";
            this.GameStart_btn.Size = new System.Drawing.Size(300, 60);
            this.GameStart_btn.TabIndex = 0;
            this.GameStart_btn.Text = "게임 시작";
            this.GameStart_btn.UseVisualStyleBackColor = true;
            this.GameStart_btn.Click += new System.EventHandler(this.GameStart_btn_Click);
            // 
            // GameStart_tutorial
            // 
            this.GameStart_tutorial.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.GameStart_tutorial.BackgroundImage = global::C3_Form_testing.Properties.Resources.button8;
            this.GameStart_tutorial.Font = new System.Drawing.Font("굴림", 30F, System.Drawing.FontStyle.Bold);
            this.GameStart_tutorial.Location = new System.Drawing.Point(797, 704);
            this.GameStart_tutorial.Name = "GameStart_tutorial";
            this.GameStart_tutorial.Size = new System.Drawing.Size(300, 60);
            this.GameStart_tutorial.TabIndex = 1;
            this.GameStart_tutorial.Text = "튜토리얼";
            this.GameStart_tutorial.UseVisualStyleBackColor = true;
            this.GameStart_tutorial.Click += new System.EventHandler(this.GameStart_tutorial_Click);
            // 
            // GameStart_Setting_btn
            // 
            this.GameStart_Setting_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.GameStart_Setting_btn.BackgroundImage = global::C3_Form_testing.Properties.Resources.button8;
            this.GameStart_Setting_btn.Font = new System.Drawing.Font("굴림", 30F, System.Drawing.FontStyle.Bold);
            this.GameStart_Setting_btn.Location = new System.Drawing.Point(797, 784);
            this.GameStart_Setting_btn.Name = "GameStart_Setting_btn";
            this.GameStart_Setting_btn.Size = new System.Drawing.Size(300, 60);
            this.GameStart_Setting_btn.TabIndex = 2;
            this.GameStart_Setting_btn.Text = "설정";
            this.GameStart_Setting_btn.UseVisualStyleBackColor = true;
            this.GameStart_Setting_btn.Click += new System.EventHandler(this.GameStart_Setting_btn_Click);
            // 
            // GameEnd_btn
            // 
            this.GameEnd_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.GameEnd_btn.BackgroundImage = global::C3_Form_testing.Properties.Resources.button8;
            this.GameEnd_btn.Font = new System.Drawing.Font("굴림", 30F, System.Drawing.FontStyle.Bold);
            this.GameEnd_btn.Location = new System.Drawing.Point(797, 865);
            this.GameEnd_btn.Name = "GameEnd_btn";
            this.GameEnd_btn.Size = new System.Drawing.Size(300, 60);
            this.GameEnd_btn.TabIndex = 3;
            this.GameEnd_btn.Text = "게임 종료";
            this.GameEnd_btn.UseVisualStyleBackColor = true;
            this.GameEnd_btn.Click += new System.EventHandler(this.GameEnd_btn_Click);
            // 
            // Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackgroundImage = global::C3_Form_testing.Properties.Resources.main_Start_1920;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.GameStart_btn);
            this.Controls.Add(this.GameEnd_btn);
            this.Controls.Add(this.GameStart_Setting_btn);
            this.Controls.Add(this.GameStart_tutorial);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form5";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Team 4";
            this.Load += new System.EventHandler(this.Form5_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button GameStart_tutorial;
        private System.Windows.Forms.Button GameStart_Setting_btn;
        private System.Windows.Forms.Button GameEnd_btn;
        private System.Windows.Forms.Button GameStart_btn;
    }
}