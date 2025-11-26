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
    public partial class Form2 : Form
    {// Form1 F1값을 만들어 Form1의 정보를 불러옴
        private Form1 F1;

        private Form5 _Form5;
        private Boolean chkFirst;
        public Form2(Form1 f1,Boolean chk,Form5 f5)
        {
            F1 = f1;
            _Form5 = f5;
            chkFirst = chk;
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            if(chkFirst == true) { 
                button5.Visible = false; 
            }
        }

        public int GameCount;
        private void EazyLevel_button(object sender, MouseEventArgs e)
        {// 11 - 17 GameCount의 값을 설정하여 난이도 변경 함 F1.GameLV의 값을 대입시킴
            GameCount = 1;
            F1.GameLV = GameCount;
            F1.Show();
            Close();
        }
        private void NomalLevel_button(object sender, MouseEventArgs e)
        {
            GameCount = 2;
            F1.GameLV = GameCount;
            F1.Show();
            Close();
        }
        private void HardLevel_button(object sender, MouseEventArgs e)
        {
            GameCount = 3;
            F1.GameLV = GameCount;
            F1.Show();
            Close();
        }

        private void GameLevelClose_button(object sender, EventArgs e)
        {
            Close();
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (chkFirst)
            {
                if(!Program.chkWindowSize)F1.Size = new Size(1440, 900); // 231202 불특정 예외처리
                F1.Show();
                _Form5.Visible = false;
            }

        }
    }
}
