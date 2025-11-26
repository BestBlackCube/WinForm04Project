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
        private Form1 F1; public int Page_count = 1;
        struct Tutorial_ImageDB
        {
            public Image Tutorial_Image;
        }
        Tutorial_ImageDB[] ImageDB = new Tutorial_ImageDB[13]; // 이미지 수대로 임의수정

        public void Tuto_Iamge()
        {//ImageDB[0].Tutorial_Image = Properties.Resources.이미지 이름;


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
                //pictureBox1.Image = Properties.Resources.이미지이름;
                label1.Text = "카드게임 하는법!"; // 카드 제목
                label2.Text = Page_count + " / 12"; // 페이지 수
            }
            if (Page_count == 2)
            {
                //pictureBox1.Image = Properties.Resources.이미지이름;
                label1.Text = "카드 뽑는 법!";
                label2.Text = Page_count + " / 12";
            }
            if (Page_count == 3)
            {
                //pictureBox1.Image = Properties.Resources.이미지이름;
                label1.Text = "카드 선택하기!";
                label2.Text = Page_count + " / 12";
            }
            if (Page_count == 4)
            {
                //pictureBox1.Image = Properties.Resources.이미지이름;
                label1.Text = "카드 필드에 배치하기!";
                label2.Text = Page_count + " / 12";
            }
            if (Page_count == 5)
            {
                //pictureBox1.Image = Properties.Resources.이미지이름;
                label1.Text = "카드 버리기 하는 법!";
                label2.Text = Page_count + " / 12";
            }
            if (Page_count == 6)
            {
                //pictureBox1.Image = Properties.Resources.이미지이름;
                label1.Text = "마법카드 사용하기!";
                label2.Text = Page_count + " / 12";
            }
            if (Page_count == 7)
            {
                //pictureBox1.Image = Properties.Resources.이미지이름;
                label1.Text = "턴 종료 하기!";
                label2.Text = Page_count + " / 12";
            }
            if (Page_count == 8)
            {
                //pictureBox1.Image = Properties.Resources.이미지이름;
                label1.Text = "전투가 되는 방법!";
                label2.Text = Page_count + " / 12";
            }
            if (Page_count == 9)
            {
                //pictureBox1.Image = Properties.Resources.이미지이름;
                label1.Text = "기타등등 1";
                label2.Text = Page_count + " / 12";
            }
            if (Page_count == 10)
            {
                //pictureBox1.Image = Properties.Resources.이미지이름;
                label1.Text = "기타등등 2";
                label2.Text = Page_count + " / 12";
            }
            if (Page_count == 11)
            {
                //pictureBox1.Image = Properties.Resources.이미지이름;
                label1.Text = "기타등등 3";
                label2.Text = Page_count + " / 12";
            }
            if (Page_count == 12)
            {
                //pictureBox1.Image = Properties.Resources.이미지이름;
                label1.Text = "기타등등 4";
                label2.Text = Page_count + " / 12";
            }
        }

        private void Next_button(object sender, MouseEventArgs e)
        {// 12는 이미지 수에 맞게
            if (Page_count > 0 && Page_count <= 12) { Page_count++; }
            Page_Image();
        }
        private void Return_button(object sender, MouseEventArgs e)
        {// 12는 이미지 수에 맞게
            if (Page_count > 0 && Page_count <= 12) { Page_count--; }
            Page_Image();
        }
        public Form3(Form1 f1)
        {
            F1 = f1;
            InitializeComponent();
        }
    }
}
