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
    public partial class Form3 : Form
    {
        public int Page_count = 1;
        struct Tutorial_ImageDB
        {
            public Image Tutorial_Image;
        }
        Tutorial_ImageDB[] ImageDB = new Tutorial_ImageDB[11]; // 이미지 수대로 임의수정

        public void Tuto_Iamge()
        {
            ImageDB[0].Tutorial_Image = Properties.Resources.TTI1;
            ImageDB[1].Tutorial_Image = Properties.Resources.TTI2;
            ImageDB[2].Tutorial_Image = Properties.Resources.TTI3;
            ImageDB[3].Tutorial_Image = Properties.Resources.TTI4;
            ImageDB[4].Tutorial_Image = Properties.Resources.TTI5;
            ImageDB[5].Tutorial_Image = Properties.Resources.TTI6;
            ImageDB[6].Tutorial_Image = Properties.Resources.TTI7_1;
            ImageDB[7].Tutorial_Image = Properties.Resources.TTI7_2;
            ImageDB[8].Tutorial_Image = Properties.Resources.TTI8;
            ImageDB[9].Tutorial_Image = Properties.Resources.TTI9;
            ImageDB[10].Tutorial_Image = Properties.Resources.TTI10;
        }
        public void Form3_Load(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            if (Page_count == 1) { button1.Enabled = false; }
        }
        public void Page_Image()
        {
            if (Page_count == 1) { button1.Enabled = false; }
            else { button1.Enabled = true; }
            if (Page_count == 12) { button2.Enabled = false; }
            else { button2.Enabled = true; }

            if (Page_count == 1)
            {
                pictureBox1.Image = Properties.Resources.TTI1;
                label1.Text = "카드게임 하는법!"; // 카드 제목
                label2.Text = Page_count + " / 11"; // 페이지 수
            }
            if (Page_count == 2)
            {
                pictureBox1.Image = Properties.Resources.TTI2;
                label1.Text = "카드 뽑는 법 1";
                label2.Text = Page_count + " / 11";
            }
            if (Page_count == 3)
            {
                pictureBox1.Image = Properties.Resources.TTI3;
                label1.Text = "카드 뽑는 법 2";
                label2.Text = Page_count + " / 11";
            }
            if (Page_count == 4)
            {
                pictureBox1.Image = Properties.Resources.TTI4;
                label1.Text = "카드의 분류!";
                label2.Text = Page_count + " / 11";
            }
            if (Page_count == 5)
            {
                pictureBox1.Image = Properties.Resources.TTI5;
                label1.Text = "몬스터 카드를 배치!";
                label2.Text = Page_count + " / 11";
            }
            if (Page_count == 6)
            {
                pictureBox1.Image = Properties.Resources.TTI6;
                label1.Text = "마법 카드 사용하기!";
                label2.Text = Page_count + " / 11";
            }
            if (Page_count == 7)
            {
                pictureBox1.Image = Properties.Resources.TTI7_1;
                label1.Text = "카드 버리기 1!";
                label2.Text = Page_count + " / 11";
            }
            if (Page_count == 8)
            {
                pictureBox1.Image = Properties.Resources.TTI7_2;
                label1.Text = "카드 버리기 2!";
                label2.Text = Page_count + " / 11";
            }
            if (Page_count == 9)
            {
                pictureBox1.Image = Properties.Resources.TTI8;
                label1.Text = "턴 종료와 전투!";
                label2.Text = Page_count + " / 11";
            }
            if (Page_count == 10)
            {
                pictureBox1.Image = Properties.Resources.TTI9;
                label1.Text = "전투!";
                label2.Text = Page_count + " / 11";
            }
            if (Page_count == 11)
            {
                pictureBox1.Image = Properties.Resources.TTI10;
                label1.Text = "게임의 목표!";
                label2.Text = Page_count + " / 11";
            }
            
        }

        private void Next_button(object sender, MouseEventArgs e)
        {// 12는 이미지 수에 맞게
            if (Page_count > 0 && Page_count <= 11) { Page_count++; }
            Page_Image();
        }
        private void Return_button(object sender, MouseEventArgs e)
        {// 12는 이미지 수에 맞게
            if (Page_count > 0 && Page_count <= 11) { Page_count--; }
            Page_Image();
        }
        public Form3()
        {
            InitializeComponent();
        }
    }
}
