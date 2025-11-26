using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace C3_Form_testing
{
    public partial class Form4 : Form
    {
        private Form1 _Form1;
        private Form5 _Form5;
        public Form4(Form1 form1, Form5 form5)
        {
            InitializeComponent();
            _Form1 = form1;
            _Form5 = form5;
        }

        FontFamily ff;
        public void FontFamilySet(FontFamily fontf) 
        {
            ff = fontf;
        }

        private void GameLevel_Setting_button(object sender, EventArgs e)
        {
            Form2 _Form2 = new Form2(_Form1, false,_Form5);
            _Form2.ShowDialog();
        }
        private void Tutorial_Setting_button(object sender, EventArgs e)
        {
            Form3 _Form3 = new Form3(); _Form3.Show();
        }
        private void FontChange_Setting_button(object sender, EventArgs e)
        {
            /*
            Form4_1 _Form4_1 = new Form4_1(this);
            _Form4_1.ShowDialog();
            _Form1.ChangeFont(ff);
            */
            MessageBox.Show("글꼴 변경은 글꼴 모양만 바꿀수 있습니다.");
            if(fontDialog1.ShowDialog() == DialogResult.OK)
            {
                ff = fontDialog1.Font.FontFamily;
                try{ _Form1.ChangeFont(ff);}
                catch (Exception ex){ MessageBox.Show("올바르지 않은 동작입니다.");}
            }
            
        }

        private void SettingClose_button(object sender, EventArgs e)
        {
            Close();
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                if (!bigWindow)
                {
                    _Form5.setSize(false);
                }
                if (radioButton2.Checked)
                {
                    bigWindow = false;
                    _Form1.setSize(bigWindow);
                    _Form5.setSize(bigWindow);
                }
                _Form1.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
                _Form1.WindowState = FormWindowState.Normal;
                _Form5.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
                _Form5.WindowState = FormWindowState.Normal;
            }
            
            else
            {
                _Form1.setSize(true);
                _Form5.setSize(true);
                _Form1.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                _Form1.WindowState = FormWindowState.Maximized;
                _Form5.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                _Form5.WindowState = FormWindowState.Maximized;
                Program.chk = true;
            }
                
        }

        private void Battle_Delay_Delete(object sender, MouseEventArgs e)
        {// 11 - 23 전투 딜레이 제거 및 생성을 만듦
            if(_Form1.Delay_Delete == 0 && e.Button == MouseButtons.Left)
            { _Form1.Delay_Delete = 1; MessageBox.Show("전투 딜레이를 제거했습니다! "); }
       else if(_Form1.Delay_Delete == 1 && e.Button == MouseButtons.Left)
            { _Form1.Delay_Delete = 0; MessageBox.Show("전투 딜레이를 생성했습니다! "); }
        }

        public Boolean bigWindow;
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked && radioButton1.Checked)
            {
                bigWindow = true;
                _Form1.setSize(bigWindow);
                _Form5.setSize(bigWindow);
                _Form1.Left = (Screen.PrimaryScreen.Bounds.Width - _Form1.Width);
                _Form1.Top = (Screen.PrimaryScreen.Bounds.Height - _Form1.Height);
                _Form5.Left = (Screen.PrimaryScreen.Bounds.Width - _Form5.Width);
                _Form5.Top = (Screen.PrimaryScreen.Bounds.Height - _Form5.Height);
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked && radioButton2.Checked)
            {// 1920 * 1080 기준으로 맞추어 세부적인 값을 조정해야함
                _Form1.Left = (Screen.PrimaryScreen.Bounds.Width - _Form1.Width + 250);
                _Form1.Top = (Screen.PrimaryScreen.Bounds.Height - _Form1.Height + 100);
                _Form5.Left = (Screen.PrimaryScreen.Bounds.Width - _Form5.Width + 250);
                _Form5.Top = (Screen.PrimaryScreen.Bounds.Height - _Form5.Height + 100);
                bigWindow = false;
                _Form1.setSize(bigWindow);
                _Form5.setSize(bigWindow);
            }

        }

        private void Form4_Load(object sender, EventArgs e)
        {
            if (Program.chk) checkBox1.Checked = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("정말 종료하시겠습니까?", "게임 종료", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                _Form5.Close();
                _Form1.Close();
                this.Close();
            }
        }
           
    }
}
