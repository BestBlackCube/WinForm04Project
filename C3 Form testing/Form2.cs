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
    {
        public Form2(Form1 form1)
        {
            _form1 = form1;
            InitializeComponent();
        }

        private Form1 _form1;
        private int Cardkeycode;
        public int Form1CardKeycode
        {
            get { return Cardkeycode; }
            set { Cardkeycode = value; }
        }
        struct Keycode
        {
            public Image MonsterCardcode;
            public int Cardcode;
        }
        Keycode[] keycode = new Keycode[11];

        public void Form2Card()
        {
            keycode[0].MonsterCardcode = Properties.Resources.MonsterCard1;
            keycode[1].MonsterCardcode = Properties.Resources.MonsterCard2;
            keycode[2].MonsterCardcode = Properties.Resources.MonsterCard3;
            keycode[3].MonsterCardcode = Properties.Resources.MonsterCard4;
            keycode[4].MonsterCardcode = Properties.Resources.MonsterCard5;
            keycode[5].MonsterCardcode = Properties.Resources.MonsterCard6;
            keycode[6].MonsterCardcode = Properties.Resources.MonsterCard7;
            keycode[7].MonsterCardcode = Properties.Resources.MonsterCard8;
            keycode[8].MonsterCardcode = Properties.Resources.MonsterCard9;
            keycode[9].MonsterCardcode = Properties.Resources.MonsterCard10;
            for (int i = 0; i <= 9; i++)
            {
                keycode[i].Cardcode = i;
            }
        }

        private void Form_Load(object sender, EventArgs e)
        {
            int code = Form1CardKeycode;
            for (int i = 0; i <= 9; i++)
            {
                if (i >= code)
                {
                    pictureBox1.Image = keycode[i].MonsterCardcode;
                    break;
                }
            }
        }
    }
}
