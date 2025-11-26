using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C3_Form_testing
{
    public partial class Form4 : Form
    {
        private Form1 _Form1;
        public Form4(Form1 form1)
        {
            InitializeComponent();
            _Form1 = form1;
        }

        FontFamily ff;
        public void FontFamilySet(FontFamily fontf) 
        {
            ff = fontf;
        }

        private void GameLevel_Setting_button(object sender, EventArgs e)
        {
            Form2 _Form2 = new Form2(_Form1, false);
            _Form2.ShowDialog();
        }
        private void Tutorial_Setting_button(object sender, EventArgs e)
        {
            Form3 _Form3 = new Form3(_Form1); _Form3.Show();
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
                _Form1.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
                _Form1.WindowState = FormWindowState.Normal;
            }
            else
            {
                _Form1.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                _Form1.WindowState = FormWindowState.Maximized;
            }
                
        }
    }
}
