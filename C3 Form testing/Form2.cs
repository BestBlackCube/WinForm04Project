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
        Form1 F1 = new Form1();
        public int GameCount = 0;
        private void button1_Click(object sender, MouseEventArgs e)
        {
            GameCount = 1;
            this.Close();
            F1.Show();
        }
        private void button2_Click(object sender, MouseEventArgs e)
        {
            GameCount = 2;
            this.Close();
        }
        private void button3_Click(object sender, MouseEventArgs e)
        {
            GameCount = 3;
            this.Close();
        }

        public Form2()
        {
            InitializeComponent();
        }
    }
}
