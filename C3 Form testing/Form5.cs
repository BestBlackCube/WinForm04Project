using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C3_Form_testing
{
    public partial class Form5 : Form
    {
        private Form1 _Form1;
        public Form5()
        {
            InitializeComponent();
        }

        /*
         설정 창모드 체크 박스 실행시

         폼 사이즈 조절  Form1 2가지 
        1920, 1080 전체 화면 및 위툴바 존재
        1440, 900 줄인 화면 및 위툴바 존재

        폼 사이즈 조절 Form3
        1600, 900 기본 사이즈
        1280, 800 줄인 사이즈

        Form5은 Form1과 동일 하게 2가지
        1920, 1080 - 기본 사이즈
        1440, 900 - 줄인 사이즈
         */

        public void setSize(Boolean sizeInfo)
        {
            if(sizeInfo)
            {
                BackgroundImage = Properties.Resources.main_Start_1920;
                this.Size = new Size(1920, 1080);
                GameStart_btn.Location = new Point(797, 628);
                GameStart_tutorial.Location = new Point(797, 704);
                GameStart_Setting_btn.Location = new Point(797, 784);
                GameEnd_btn.Location = new Point(797, 865);
            }
            else 
            {
                BackgroundImage = Properties.Resources.main_Start_1440;
                this.Size = new Size(1440, 900);
                GameStart_btn.Location = new Point(558, 500);
                GameStart_tutorial.Location = new Point(558, 576);
                GameStart_Setting_btn.Location = new Point(558, 656);
                GameEnd_btn.Location = new Point(558, 737);
            }
        }

        private void GameStart_btn_Click(object sender, EventArgs e)
        {
            Form2 _Form2 = new Form2(_Form1, true, this);
            _Form2.Show();
            // Form 1
            // Form1 실행전에 Form2 난이도 설정창이 먼저 뜨고 버튼 선택후 Form1 실행
            // Form1 = Form1_Load 구간에 Form2 실행문장 존재 없애줘
        }

        private void GameStart_tutorial_Click(object sender, EventArgs e)
        {
            Form3 _Form3 = new Form3();
            _Form3.ShowDialog();
        }

        private void GameStart_Setting_btn_Click(object sender, EventArgs e)
        {
            Form4 _Form4 = new Form4(_Form1,this);
            _Form4.ShowDialog();
            // 설정의 폰트 설정, 난이도 제외
        }

        private void GameEnd_btn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            _Form1 = new Form1(this);
        }
    }
}
