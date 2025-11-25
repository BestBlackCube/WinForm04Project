using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks; // 지연시간
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Threading; // 지연시간 추가
using System.Timers;

namespace C3_Form_testing
{

    public partial class Form1 : Form
    {
        //Form1 form1 = new Form1();
        private static DateTime Delay(int ms)
        {
            DateTime ThisMoment = DateTime.Now;
            TimeSpan duration = new TimeSpan(0, 0, 0, 0, ms);
            DateTime AfterWards = ThisMoment.Add(duration);

            while (AfterWards >= ThisMoment)
            { System.Windows.Forms.Application.DoEvents(); ThisMoment = DateTime.Now; }
            return DateTime.Now;
        }
        Random HP_point = new Random(); Random ATK_point = new Random();
        Random Card_Number = new Random(); Random MagicATK_point = new Random();
        public int MyHp = 50, AiHp = 50, DeleteCardcount = 3;
        public int Magicbool1 = 0, Magicbool2 = 0, Magicbool3 = 0, Magicbool4 = 0, Magicbool5 = 0;
        struct Information_Card
        { public String Info_Hand, Info_Field; }
        struct MyCardstatus
        { public int MyHP_status, MyATK_status; }
        struct MyFieldCardstatus
        { public int FieldHP_status, FieldATK_status; }
        struct AiCardstatus
        { public int AiHP_status, AiATK_status; }
        struct MagicCardstsatus
        { public int Magic_status; }
        struct Card
        {
            public int ATK, AiATK, HP, AiHP, keycode, Aikeycode, MagicATK;
            public Image MonsterCardcode, AiMonsterCardcode, MagicCardcode;
        }
        Card[] CardDB = new Card[11]; MyFieldCardstatus[] MyField_status = new MyFieldCardstatus[6];
        MyCardstatus[] Mycardstatus = new MyCardstatus[6]; AiCardstatus[] Aicardstatus = new AiCardstatus[6];
        Information_Card[] Info_Card = new Information_Card[6]; MagicCardstsatus[] Magicstatus = new MagicCardstsatus[6];
        public void MyCardcodesetting()
        {
            CardDB[0].MonsterCardcode = Properties.Resources.MonsterCard1;
            CardDB[1].MonsterCardcode = Properties.Resources.MonsterCard2;
            CardDB[2].MonsterCardcode = Properties.Resources.MonsterCard3;
            CardDB[3].MonsterCardcode = Properties.Resources.MonsterCard4;
            CardDB[4].MonsterCardcode = Properties.Resources.MonsterCard5;
            CardDB[5].MonsterCardcode = Properties.Resources.MonsterCard6;
            CardDB[6].MonsterCardcode = Properties.Resources.MonsterCard7;
            CardDB[7].MonsterCardcode = Properties.Resources.MonsterCard8;
            CardDB[8].MonsterCardcode = Properties.Resources.MonsterCard9;
            CardDB[9].MonsterCardcode = Properties.Resources.MonsterCard10;

            CardDB[0].MagicCardcode = Properties.Resources.MagicCard1;
            CardDB[1].MagicCardcode = Properties.Resources.MagicCard2;
            CardDB[2].MagicCardcode = Properties.Resources.MagicCard3;
            CardDB[3].MagicCardcode = Properties.Resources.MagicCard4;
            CardDB[4].MagicCardcode = Properties.Resources.MagicCard5;
            CardDB[5].MagicCardcode = Properties.Resources.MagicCard6;
            CardDB[6].MagicCardcode = Properties.Resources.MagicCard7;
            CardDB[7].MagicCardcode = Properties.Resources.MagicCard8;
            CardDB[8].MagicCardcode = Properties.Resources.MagicCard9;
            CardDB[9].MagicCardcode = Properties.Resources.MagicCard10;
            for (int i = 0; i <= 9; i++)
            {
                CardDB[i].ATK = ATK_point.Next(1, 7); CardDB[i].HP = HP_point.Next(1, 10);
                CardDB[i].MagicATK = MagicATK_point.Next(1, 5); CardDB[i].keycode = i;
            }
        }
        public void AiCardcodesetting()
        {
            CardDB[0].AiMonsterCardcode = Properties.Resources.MonsterCard1;
            CardDB[1].AiMonsterCardcode = Properties.Resources.MonsterCard2;
            CardDB[2].AiMonsterCardcode = Properties.Resources.MonsterCard3;
            CardDB[3].AiMonsterCardcode = Properties.Resources.MonsterCard4;
            CardDB[4].AiMonsterCardcode = Properties.Resources.MonsterCard5;
            CardDB[5].AiMonsterCardcode = Properties.Resources.MonsterCard6;
            CardDB[6].AiMonsterCardcode = Properties.Resources.MonsterCard7;
            CardDB[7].AiMonsterCardcode = Properties.Resources.MonsterCard8;
            CardDB[8].AiMonsterCardcode = Properties.Resources.MonsterCard9;
            CardDB[9].AiMonsterCardcode = Properties.Resources.MonsterCard10;
            for (int i = 0; i <= 9; i++)
            {
                CardDB[i].AiATK = ATK_point.Next(1, 7); CardDB[i].AiHP = HP_point.Next(1, 10);
                CardDB[i].Aikeycode = i;
            }
        }
        public void buttonTrue_False()
        {
            if (button1.Enabled == false) { button1.Enabled = true; }
            else if (button2.Enabled == false) { button2.Enabled = true; }
            else if (button3.Enabled == false) { button3.Enabled = true; }
            else if (button4.Enabled == false) { button4.Enabled = true; }
            else if (button5.Enabled == false) { button5.Enabled = true; }
        }
        public void Card_FieldFull_Fieldnull()
        {
            if (pictureBox1.Image == null) 
            { button6.Visible = true; button6.Enabled = true; button6.Text = "필드 소환"; }
            else { button6.Enabled = false; button6.Text = "필드에 카드가 있습니다"; }
            if (pictureBox2.Image == null)
            { button7.Visible = true; button7.Enabled = true; button7.Text = "필드 소환"; }
            else { button7.Enabled = false; button7.Text = "필드에 카드가 있습니다"; }
            if (pictureBox3.Image == null)
            {button8.Visible = true; button8.Enabled = true; button8.Text = "필드 소환"; }
            else { button8.Enabled = false; button8.Text = "필드에 카드가 있습니다"; }
            if (pictureBox4.Image == null)
            {button9.Visible = true; button9.Enabled = true; button9.Text = "필드 소환"; }
            else { button9.Enabled = false; button9.Text = "필드에 카드가 있습니다"; }
            if (pictureBox5.Image == null)
            {button10.Visible = true; button10.Enabled = true; button10.Text = "필드 소환"; }
            else { button10.Enabled = false; button10.Text = "필드에 카드가 있습니다"; }
        }

        public void MagicSpell_AddCard()
        {
            if (pictureBox1.Image != null) { button6.Enabled = true; button6.Text = "사용 하기"; }
            if (pictureBox2.Image != null) { button7.Enabled = true; button7.Text = "사용 하기"; }
            if (pictureBox3.Image != null) { button8.Enabled = true; button8.Text = "사용 하기"; }
            if (pictureBox4.Image != null) { button9.Enabled = true; button9.Text = "사용 하기"; }
            if (pictureBox5.Image != null) { button10.Enabled = true; button10.Text = "사용 하기"; }
        }
        private void Form1_Load(object sender, EventArgs e)
        { label31.Text = "MyHp : 50"; label32.Text = "AiHp : 50"; textBox1.MaxLength = 100; }
        private void Form1_Click(object sender, EventArgs e)
        {
            textBox2.Text = ""; pictureBox11.Image = null;
            if (button12.Visible == false)
            {
                button12.Visible = true; textBox1.Text = ""; 
                button6.Visible = true; button6.Text = "필드 소환";
                button7.Visible = true; button7.Text = "필드 소환";
                button8.Visible = true; button8.Text = "필드 소환";
                button9.Visible = true; button9.Text = "필드 소환";
                button10.Visible = true; button10.Text = "필드 소환";
            }
            buttonTrue_False(); Card_FieldFull_Fieldnull();
        }
        private void MyhandCardAdd_button(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                button20.Enabled = false; MyCardcodesetting();
                int mycard1 = Card_Number.Next(0, 9), mycard2 = Card_Number.Next(0, 9),
                    mycard3 = Card_Number.Next(0, 9), mycard4 = Card_Number.Next(0, 9),
                    mycard5 = Card_Number.Next(0, 9), CardChoice1 = Card_Number.Next(0, 9),
                    CardChoice2 = Card_Number.Next(0, 9), CardChoice3 = Card_Number.Next(0, 9),
                    CardChoice4 = Card_Number.Next(0, 9), CardChoice5 = Card_Number.Next(0, 9);
                for (int j = 0; j <= 9; j++)
                {
                    if (button1.Image == null && CardDB[j].keycode == mycard1)
                    {
                        if (CardChoice1 <= 6)
                        {
                            button1.Image = CardDB[j].MonsterCardcode;
                            label1.Text = "HP : " + CardDB[j].HP; label2.Text = "ATK : " + CardDB[j].ATK;
                            Mycardstatus[0].MyHP_status = CardDB[j].HP; Mycardstatus[0].MyATK_status = CardDB[j].ATK;
                        }
                        if(CardChoice1 >= 7)
                        {
                            button1.Image = CardDB[j].MagicCardcode; Magicbool1 = 1;
                            Magicstatus[0].Magic_status = CardDB[j].MagicATK;
                            label1.Text = "HP : 0"; label2.Text = "ATK : " + CardDB[j].MagicATK;
                            Info_Card[0].Info_Hand += "\r\n공격력 증가 : " + CardDB[j].MagicATK;
                        }
                    }
                    if (button2.Image == null && CardDB[j].keycode == mycard2)
                    {
                        if(CardChoice2 <= 6)
                        {
                            button2.Image = CardDB[j].MonsterCardcode;
                            label3.Text = "HP : " + CardDB[j].HP; label4.Text = "ATK : " + CardDB[j].ATK;
                            Mycardstatus[1].MyHP_status = CardDB[j].HP; Mycardstatus[1].MyATK_status = CardDB[j].ATK;
                        }
                        if(CardChoice2 >= 7)
                        {
                            button2.Image = CardDB[j].MagicCardcode; Magicbool2 = 1;
                            Magicstatus[1].Magic_status = CardDB[j].MagicATK;
                            label3.Text = "HP : 0"; label4.Text = "ATK : " + CardDB[j].MagicATK;
                            Info_Card[1].Info_Hand += "\r\n공격력 증가 : " + CardDB[j].MagicATK;
                        }
                    }
                    if (button3.Image == null && CardDB[j].keycode == mycard3)
                    {
                        if(CardChoice3 <= 6)
                        {
                            button3.Image = CardDB[j].MonsterCardcode; 
                            label5.Text = "HP : " + CardDB[j].HP; label6.Text = "ATK : " + CardDB[j].ATK;
                            Mycardstatus[2].MyHP_status = CardDB[j].HP; Mycardstatus[2].MyATK_status = CardDB[j].ATK;
                        }
                        if(CardChoice3 >= 7)
                        {
                            button3.Image = CardDB[j].MagicCardcode; Magicbool3 = 1;
                            Magicstatus[2].Magic_status = CardDB[j].MagicATK;
                            label5.Text = "HP : 0"; label6.Text = "ATK : " + CardDB[j].MagicATK;
                            Info_Card[2].Info_Hand += "\r\n공격력 증가 : " + CardDB[j].MagicATK;
                        }
                    }
                    if (button4.Image == null && CardDB[j].keycode == mycard4)
                    {
                        if (CardChoice4 <= 6)
                        {
                            button4.Image = CardDB[j].MonsterCardcode;
                            label7.Text = "HP : " + CardDB[j].HP; label8.Text = "ATK : " + CardDB[j].ATK;
                            Mycardstatus[3].MyHP_status = CardDB[j].HP; Mycardstatus[3].MyATK_status = CardDB[j].ATK;
                        }
                        if(CardChoice4 >= 7)
                        {
                            button4.Image = CardDB[j].MagicCardcode; Magicbool4 = 1;
                            Magicstatus[3].Magic_status = CardDB[j].MagicATK;
                            label7.Text = "HP : 0"; label8.Text = "ATK : " + CardDB[j].MagicATK;
                            Info_Card[3].Info_Hand += "\r\n공격력 증가 : " + CardDB[j].MagicATK;
                        }
                    }
                    if (button5.Image == null && CardDB[j].keycode == mycard5)
                    {
                        if(CardChoice5 <= 6)
                        {
                            button5.Image = CardDB[j].MonsterCardcode;
                            label9.Text = "HP : " + CardDB[j].HP; label10.Text = "ATK : " + CardDB[j].ATK;
                            Mycardstatus[4].MyHP_status = CardDB[j].HP; Mycardstatus[4].MyATK_status = CardDB[j].ATK;
                        }
                        if(CardChoice5 >= 7)
                        {
                            button5.Image = CardDB[j].MagicCardcode; Magicbool5 = 1;
                            Magicstatus[4].Magic_status = CardDB[j].MagicATK;
                            label9.Text = "HP : 0"; label10.Text = "ATK : " + CardDB[j].MagicATK;
                            Info_Card[4].Info_Hand += "\r\n공격력 증가 : " + CardDB[j].MagicATK;
                        }
                    }
                }
                buttonTrue_False();
            }
        }
        private void DeleteCard_button(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                button6.Text = "필드카드 버리기"; button6.Enabled = true;
                button7.Text = "필드카드 버리기"; button7.Enabled = true;
                button8.Text = "필드카드 버리기"; button8.Enabled = true;
                button9.Text = "필드카드 버리기"; button9.Enabled = true;
                button10.Text = "필드카드 버리기"; button10.Enabled = true;
                if (pictureBox1.Image == null)
                { button6.Visible = false; }
                if (pictureBox2.Image == null)
                { button7.Visible = false; }
                if (pictureBox3.Image == null)
                { button8.Visible = false; }
                if (pictureBox4.Image == null)
                { button9.Visible = false; }
                if (pictureBox5.Image == null)
                { button10.Visible = false; }
                if (DeleteCardcount > 0)
                {
                    textBox1.Text = "버릴 카드를 선택해주세요";
                    button1.Enabled = true; button2.Enabled = true; button3.Enabled = true;
                    button4.Enabled = true; button5.Enabled = true; button12.Visible = false;
                }
                else
                {
                    textBox1.Text = "현재 라운드에 카드버리기 횟수가 없습니다";
                    Card_FieldFull_Fieldnull();
                    button12.Visible = true;
                }
                if (button1.Image == null && button2.Image == null && button3.Image == null &&
                    button4.Image == null && button5.Image == null && button6.Image == null &&
                    pictureBox1.Image == null && pictureBox2.Image == null && pictureBox3.Image == null &&
                    pictureBox4.Image == null && pictureBox5.Image == null)
                {
                    textBox1.Text = "버릴 카드가 없습니다"; button12.Enabled = true;
                    button6.Visible = true; button7.Visible = true; button8.Visible = true;
                    button9.Visible = true; button10.Visible = true; button12.Visible = true;
                    button6.Text = "필드 소환"; button7.Text = "필드 소환"; button8.Text = "필드 소환";
                    button9.Text = "필드 소환"; button10.Text = "필드 소환";
                }
            }
        }
        private void End_button(object sender, MouseEventArgs e)
        {
            DeleteCardcount = 3;
            button12.Text = "카드 버리기\r\n3/3"; textBox1.Text = "상대가 필드에 카드를 배치합니다";
            if (e.Button == MouseButtons.Left && button11.Visible == true)
            {
                button11.Visible = false; button20.Visible = false; button12.Visible = false;
                button6.Visible = false; button7.Visible = false; button8.Visible = false;
                button9.Visible = false; button10.Visible = false;
                Delay(3000);
                AiCardcodesetting();
                for (int j = 0; j <= 9; j++)
                {
                    if (pictureBox6.Image == null)
                    {
                        if (CardDB[j].Aikeycode == Card_Number.Next(0, 9))
                        {
                            pictureBox6.Image = CardDB[j].AiMonsterCardcode;
                            label21.Text = "HP : " + CardDB[j].AiHP; label22.Text = "ATK : " + CardDB[j].AiATK;
                            Aicardstatus[0].AiHP_status = CardDB[j].AiHP; Aicardstatus[0].AiATK_status = CardDB[j].AiATK;
                        }
                    }
                    if (pictureBox7.Image == null)
                    {
                        if (CardDB[j].Aikeycode == Card_Number.Next(0, 9))
                        {
                            pictureBox7.Image = CardDB[j].AiMonsterCardcode;
                            label23.Text = "HP : " + CardDB[j].AiHP; label24.Text = "ATK : " + CardDB[j].AiATK;
                            Aicardstatus[1].AiHP_status = CardDB[j].AiHP; Aicardstatus[1].AiATK_status = CardDB[j].AiATK;
                        }
                    }
                    if (pictureBox8.Image == null)
                    {
                        if (CardDB[j].Aikeycode == Card_Number.Next(0, 9))
                        {
                            pictureBox8.Image = CardDB[j].AiMonsterCardcode;
                            label25.Text = "HP : " + CardDB[j].AiHP; label26.Text = "ATK : " + CardDB[j].AiATK;
                            Aicardstatus[2].AiHP_status = CardDB[j].AiHP; Aicardstatus[2].AiATK_status = CardDB[j].AiATK;
                        }
                    }
                    if (pictureBox9.Image == null)
                    {
                        if (CardDB[j].Aikeycode == Card_Number.Next(0, 9))
                        {
                            pictureBox9.Image = CardDB[j].AiMonsterCardcode;
                            label27.Text = "HP : " + CardDB[j].AiHP; label28.Text = "ATK : " + CardDB[j].AiATK;
                            Aicardstatus[3].AiHP_status = CardDB[j].AiHP; Aicardstatus[3].AiATK_status = CardDB[j].AiATK;
                        }
                    }
                    if (pictureBox10.Image == null)
                    {
                        if (CardDB[j].Aikeycode == Card_Number.Next(0, 9))
                        {
                            pictureBox10.Image = CardDB[j].AiMonsterCardcode;
                            label29.Text = "HP : " + CardDB[j].AiHP; label30.Text = "ATK : " + CardDB[j].AiATK;
                            Aicardstatus[4].AiHP_status = CardDB[j].AiHP; Aicardstatus[4].AiATK_status = CardDB[j].AiATK;
                        }
                    }
                }
                textBox1.Text = ""; textBox1.Text += "전투 시작!\r\n";
                if (pictureBox1.Image == null && pictureBox6.Image != null)
                {
                    MyHp -= Aicardstatus[0].AiATK_status; label31.Text = "MyHP : " + MyHp;
                    textBox1.Text += "\r\n첫번째 칸 적몬스터 -> 내생명" + Aicardstatus[0].AiATK_status + "피해\r\n";
                }
                if (pictureBox6.Image == null && pictureBox1.Image != null)
                {
                    AiHp -= MyField_status[0].FieldATK_status; label32.Text = "AiHP : " + AiHp;
                    textBox1.Text += "\r\n첫번째 칸 내몬스터 -> 적생명 " + MyField_status[0].FieldATK_status + "피해\r\n";
                }
                if (pictureBox1.Image != null && pictureBox6.Image != null)
                {
                    MyField_status[0].FieldHP_status -= Aicardstatus[0].AiATK_status;
                    Aicardstatus[0].AiHP_status -= MyField_status[0].FieldATK_status;
                    label11.Text = "HP : " + MyField_status[0].FieldHP_status;
                    label21.Text = "HP : " + Aicardstatus[0].AiHP_status;
                    textBox1.Text += "\r\n첫번째 칸 적몬스터 -> 내몬스터 " + Aicardstatus[0].AiATK_status + "피해";
                    textBox1.Text += "\r\n첫번째 칸 내몬스터 -> 적몬스터 " + MyField_status[0].FieldATK_status + "피해\r\n";

                    if (MyField_status[0].FieldHP_status <= 0)
                    {
                        pictureBox1.Image = null; Info_Card[0].Info_Field = "";
                        label11.Text = "HP : 0"; label12.Text = "ATK : 0"; button6.Text = "필드 소환"; button6.Enabled = true;
                    }
                    if (Aicardstatus[0].AiHP_status <= 0)
                    { pictureBox6.Image = null; label21.Text = "HP : 0"; label22.Text = "ATK : 0"; }
                }
                if (pictureBox2.Image == null && pictureBox7.Image != null)
                {
                    MyHp -= Aicardstatus[1].AiATK_status; label31.Text = "MyHP : " + MyHp;
                    textBox1.Text += "\r\n두번째 칸 적몬스터 -> 내생명 " + Aicardstatus[1].AiATK_status + "피해\r\n";
                }
                if (pictureBox7.Image == null && pictureBox2.Image != null)
                {
                    AiHp -= MyField_status[1].FieldATK_status; label32.Text = "AiHP : " + AiHp;
                    textBox1.Text += "\r\n두번째 칸 내몬스터 -> 적생명 " + MyField_status[1].FieldATK_status + "피해\r\n";
                }
                if (pictureBox2.Image != null && pictureBox7.Image != null)
                {
                    MyField_status[1].FieldHP_status -= Aicardstatus[1].AiATK_status;
                    Aicardstatus[1].AiHP_status -= MyField_status[1].FieldATK_status;
                    label13.Text = "HP : " + MyField_status[1].FieldHP_status;
                    label23.Text = "HP : " + Aicardstatus[1].AiHP_status;
                    textBox1.Text += "\r\n두번째 칸 적몬스터 -> 내몬스터 " + Aicardstatus[1].AiATK_status + "피해";
                    textBox1.Text += "\r\n두번째 칸 내몬스터 -> 적몬스터 " + MyField_status[1].FieldATK_status + "피해\r\n";
                    if (MyField_status[1].FieldHP_status <= 0)
                    {
                        pictureBox2.Image = null; Info_Card[1].Info_Field = "";
                        label13.Text = "HP : 0"; label14.Text = "ATK : 0"; button7.Text = "필드 소환"; button7.Enabled = true;
                    }
                    if (Aicardstatus[1].AiHP_status <= 0)
                    { pictureBox7.Image = null; label23.Text = "HP : 0"; label24.Text = "ATK : 0"; }
                }
                if (pictureBox3.Image == null && pictureBox8.Image != null)
                {
                    MyHp -= Aicardstatus[2].AiATK_status; label31.Text = "MyHP : " + MyHp;
                    textBox1.Text += "\r\n세번째 칸 적몬스터 -> 내생명 " + Aicardstatus[2].AiATK_status + "피해\r\n";
                }
                if (pictureBox8.Image == null && pictureBox3.Image != null)
                {
                    AiHp -= MyField_status[2].FieldATK_status; label32.Text = "AiHP : " + AiHp;
                    textBox1.Text += "\r\n세번째 칸 내몬스터 -> 적생명 " + MyField_status[2].FieldATK_status + "피해\r\n";
                }
                if (pictureBox3.Image != null && pictureBox8.Image != null)
                {
                    MyField_status[2].FieldHP_status -= Aicardstatus[2].AiATK_status;
                    Aicardstatus[2].AiHP_status -= MyField_status[2].FieldATK_status;
                    label15.Text = "HP : " + MyField_status[2].FieldHP_status;
                    label25.Text = "HP : " + Aicardstatus[2].AiHP_status;
                    textBox1.Text += "\r\n세번째 칸 적몬스터 -> 내몬스터 " + Aicardstatus[2].AiATK_status + "피해";
                    textBox1.Text += "\r\n세번째 칸 내몬스터 -> 적몬스터 " + MyField_status[2].FieldATK_status + "피해\r\n";
                    if (MyField_status[2].FieldHP_status <= 0)
                    {
                        pictureBox3.Image = null; Info_Card[2].Info_Field = "";
                        label15.Text = "HP : 0"; label16.Text = "ATK : 0"; button8.Text = "필드 소환"; button8.Enabled = true;
                    }
                    if (Aicardstatus[2].AiHP_status <= 0)
                    { pictureBox8.Image = null; label25.Text = "HP : 0"; label26.Text = "ATK : 0"; }
                }
                if (pictureBox4.Image == null && pictureBox9.Image != null)
                {
                    MyHp -= Aicardstatus[3].AiATK_status; label31.Text = "MyHP : " + MyHp;
                    textBox1.Text += "\r\n네번째 칸 적몬스터 -> 내생명 " + Aicardstatus[3].AiATK_status + "피해\r\n";
                }
                if (pictureBox9.Image == null && pictureBox4.Image != null)
                {
                    AiHp -= MyField_status[3].FieldATK_status; label32.Text = "AiHP : " + AiHp;
                    textBox1.Text += "\r\n네번째 칸 내몬스터 -> 적생명 " + MyField_status[3].FieldATK_status + "피해\r\n";
                }
                if (pictureBox4.Image != null && pictureBox9.Image != null)
                {
                    MyField_status[3].FieldHP_status -= Aicardstatus[3].AiATK_status;
                    Aicardstatus[3].AiHP_status -= MyField_status[3].FieldATK_status;
                    label17.Text = "HP : " + MyField_status[3].FieldHP_status;
                    label27.Text = "HP : " + Aicardstatus[3].AiHP_status;
                    textBox1.Text += "\r\n네번째 칸 적몬스터 -> 내몬스터 " + Aicardstatus[3].AiATK_status + "피해";
                    textBox1.Text += "\r\n네번째 칸 내몬스터 -> 적몬스터 " + MyField_status[3].FieldATK_status + "피해\r\n";
                    if (MyField_status[3].FieldHP_status <= 0)
                    {
                        pictureBox4.Image = null; Info_Card[3].Info_Field = "";
                        label17.Text = "HP : 0"; label18.Text = "ATK : 0"; button9.Text = "필드 소환"; button9.Enabled = true;
                    }
                    if (Aicardstatus[3].AiHP_status <= 0)
                    { pictureBox9.Image = null; label27.Text = "HP : 0"; label28.Text = "ATK : 0"; }
                }
                if (pictureBox5.Image == null && pictureBox10.Image != null)
                {
                    MyHp -= Aicardstatus[4].AiATK_status; label31.Text = "MyHP : " + MyHp;
                    textBox1.Text += "\r\n다섯번째 칸 적몬스터 -> 내생명 " + Aicardstatus[4].AiATK_status + "피해\r\n";
                }
                if (pictureBox10.Image == null && pictureBox5.Image != null)
                {
                    AiHp -= MyField_status[4].FieldATK_status; label32.Text = "AiHP : " + AiHp;
                    textBox1.Text += "\r\n다섯번째 칸 내몬스터 -> 적생명 " + MyField_status[4].FieldATK_status + "피해\r\n";
                }
                if (pictureBox5.Image != null && pictureBox10.Image != null)
                {
                    MyField_status[4].FieldHP_status -= Aicardstatus[4].AiATK_status;
                    Aicardstatus[4].AiHP_status -= MyField_status[4].FieldATK_status;
                    label19.Text = "HP : " + MyField_status[4].FieldHP_status;
                    label29.Text = "HP : " + Aicardstatus[4].AiHP_status;
                    textBox1.Text += "\r\n다섯번째 칸 적몬스터 -> 내몬스터 " + Aicardstatus[4].AiATK_status + "피해";
                    textBox1.Text += "\r\n다섯번째 칸 내몬스터 -> 적몬스터 " + MyField_status[4].FieldATK_status + "피해\r\n";
                    if (MyField_status[4].FieldHP_status <= 0)
                    {
                        pictureBox5.Image = null; Info_Card[4].Info_Field = "";
                        label19.Text = "HP : 0"; label20.Text = "ATK : 0"; button10.Text = "필드 소환"; button10.Enabled = true;
                    }
                    if (Aicardstatus[4].AiHP_status <= 0)
                    { pictureBox10.Image = null; label29.Text = "HP : 0"; label30.Text = "ATK : 0"; }
                }
                textBox1.Text += "\r\n전투 종료!";
                button6.Visible = true; button7.Visible = true; button8.Visible = true; 
                button9.Visible = true; button10.Visible = true; button20.Enabled = true;
                button11.Visible = true; button12.Visible = true; button20.Visible = true;
                if(MyHp <= 0)
                { MessageBox.Show("플레이어가 졌습니다!"); this.Close(); }
                else if(AiHp <= 0)
                { MessageBox.Show("인공지능이 졌습니다!"); this.Close(); }
            }
        }
        private void CardAdd1_button(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && button1.Enabled == false && button1.Image != null && Magicbool1 == 0)
            {
                pictureBox1.Image = button1.Image;
                label11.Text = label1.Text; label12.Text = label2.Text;
                MyField_status[0].FieldHP_status = Mycardstatus[0].MyHP_status;
                MyField_status[0].FieldATK_status = Mycardstatus[0].MyATK_status;
                Info_Card[0].Info_Field = Info_Card[0].Info_Hand;
                button1.Image = null; button1.Enabled = true;
                label1.Text = "HP : 0"; label2.Text = "ATK : 0";
                button6.Text = "필드에 카드가 있습니다"; button6.Enabled = false;
            }
            if (e.Button == MouseButtons.Left && button2.Enabled == false && button2.Image != null && Magicbool2 == 0)
            {
                pictureBox1.Image = button2.Image;
                label11.Text = label3.Text; label12.Text = label4.Text;
                MyField_status[0].FieldHP_status = Mycardstatus[1].MyHP_status;
                MyField_status[0].FieldATK_status = Mycardstatus[1].MyATK_status;
                Info_Card[0].Info_Field = Info_Card[1].Info_Hand;
                button2.Image = null; button2.Enabled = true;
                label3.Text = "HP : 0"; label4.Text = "ATK : 0";
                button6.Text = "필드에 카드가 있습니다"; button6.Enabled = false;
            }
            if (e.Button == MouseButtons.Left && button3.Enabled == false && button3.Image != null && Magicbool3 == 0)
            {
                pictureBox1.Image = button3.Image;
                label11.Text = label5.Text; label12.Text = label6.Text;
                MyField_status[0].FieldHP_status = Mycardstatus[2].MyHP_status;
                MyField_status[0].FieldATK_status = Mycardstatus[2].MyATK_status;
                Info_Card[0].Info_Field = Info_Card[2].Info_Hand;
                button3.Image = null; button3.Enabled = true;
                label5.Text = "HP : 0"; label6.Text = "ATK : 0";
                button6.Text = "필드에 카드가 있습니다"; button6.Enabled = false;
            }
            if (e.Button == MouseButtons.Left && button4.Enabled == false && button4.Image != null && Magicbool4 == 0)
            {
                pictureBox1.Image = button4.Image;
                label11.Text = label7.Text; label12.Text = label8.Text;
                MyField_status[0].FieldHP_status = Mycardstatus[3].MyHP_status;
                MyField_status[0].FieldATK_status = Mycardstatus[3].MyATK_status;
                Info_Card[0].Info_Field = Info_Card[3].Info_Hand;
                button4.Image = null; button4.Enabled = true;
                label7.Text = "HP : 0"; label8.Text = "ATK : 0";
                button6.Text = "필드에 카드가 있습니다"; button6.Enabled = false;
            }
            if (e.Button == MouseButtons.Left && button5.Enabled == false && button5.Image != null && Magicbool5 == 0)
            {
                pictureBox1.Image = button5.Image;
                label11.Text = label9.Text; label12.Text = label10.Text;
                MyField_status[0].FieldHP_status = Mycardstatus[4].MyHP_status;
                MyField_status[0].FieldATK_status = Mycardstatus[4].MyATK_status;
                Info_Card[0].Info_Field = Info_Card[4].Info_Hand;
                button5.Image = null; button5.Enabled = true;
                label9.Text = "HP : 0"; label10.Text = "ATK : 0";
                button6.Text = "필드에 카드가 있습니다"; button6.Enabled = false;
            }

            if (button12.Visible == false && e.Button == MouseButtons.Left)
            {
                label11.Text = "HP : 0"; label12.Text = "ATK : 0";
                Card_FieldFull_Fieldnull();
                button12.Visible = true; pictureBox1.Image = null;
                textBox1.Text = "필드 첫번째 카드를 버리셨습니다";
                button12.Text = "카드 버리기 \r\n" + --DeleteCardcount + "/3";
            }
            if (e.Button == MouseButtons.Left)
            {
                if (button1.Enabled == false && button1.Image != null && pictureBox1.Image != null && Magicbool1 == 1)
                {
                    pictureBox11.Image = null; textBox2.Text = ""; Info_Card[0].Info_Hand = "";
                    button1.Image = null; label1.Text = "HP : 0"; label2.Text = "ATK : 0"; Magicbool1 = 0;
                    MyField_status[0].FieldATK_status += Magicstatus[0].Magic_status;
                    label12.Text = "ATK : " + MyField_status[0].FieldATK_status;
                    textBox1.Text = "첫번째 필드 카드에 공격력 " + Magicstatus[0].Magic_status + "를 더한다";
                    Info_Card[0].Info_Field += "\r\n마법 카드 : 공격력 " + Magicstatus[0].Magic_status + "증가";
                }
                if (button2.Enabled == false && button2.Image != null && pictureBox1.Image != null && Magicbool2 == 1)
                {
                    pictureBox11.Image = null; textBox2.Text = ""; Info_Card[1].Info_Hand = "";
                    button2.Image = null; label3.Text = "HP : 0"; label4.Text = "ATK : 0"; Magicbool2 = 0;
                    MyField_status[0].FieldATK_status += Magicstatus[1].Magic_status;
                    label12.Text = "ATK : " + MyField_status[0].FieldATK_status;
                    textBox1.Text = "첫번째 필드 카드에 공격력 " + Magicstatus[1].Magic_status + "를 더한다";
                    Info_Card[0].Info_Field += "\r\n마법 카드 : 공격력 " + Magicstatus[1].Magic_status + "증가";
                }
                if (button3.Enabled == false && button3.Image != null && pictureBox1.Image != null && Magicbool3 == 1)
                {
                    pictureBox11.Image = null; textBox2.Text = ""; Info_Card[2].Info_Hand = "";
                    button3.Image = null; label5.Text = "HP : 0"; label6.Text = "ATK : 0"; Magicbool3 = 0;
                    MyField_status[0].FieldATK_status += Magicstatus[2].Magic_status;
                    label12.Text = "ATK : " + MyField_status[0].FieldATK_status;
                    textBox1.Text = "첫번째 필드 카드에 공격력 " + Magicstatus[2].Magic_status + "를 더한다";
                    Info_Card[0].Info_Field += "\r\n마법 카드 : 공격력 " + Magicstatus[2].Magic_status + "증가";
                }
                if (button4.Enabled == false && button4.Image != null && pictureBox1.Image != null && Magicbool4 == 1)
                {
                    pictureBox11.Image = null; textBox2.Text = ""; Info_Card[3].Info_Hand = "";
                    button4.Image = null; label7.Text = "HP : 0"; label8.Text = "ATK : 0"; Magicbool4 = 0;
                    MyField_status[0].FieldATK_status += Magicstatus[3].Magic_status;
                    label12.Text = "ATK : " + MyField_status[0].FieldATK_status;
                    textBox1.Text = "첫번째 필드 카드에 공격력 " + Magicstatus[3].Magic_status + "를 더한다";
                    Info_Card[0].Info_Field += "\r\n마법 카드 : 공격력 " + Magicstatus[3].Magic_status + "증가";
                }
                if (button5.Enabled == false && button5.Image != null && pictureBox1.Image != null && Magicbool5 == 1)
                {
                    pictureBox11.Image = null; textBox2.Text = ""; Info_Card[4].Info_Hand = "";
                    button5.Image = null; label9.Text = "HP : 0"; label10.Text = "ATK : 0"; Magicbool5 = 0;
                    MyField_status[0].FieldATK_status += Magicstatus[4].Magic_status;
                    label12.Text = "ATK : " + MyField_status[0].FieldATK_status;
                    textBox1.Text = "첫번째 필드 카드에 공격력 " + Magicstatus[4].Magic_status + "를 더한다";
                    Info_Card[0].Info_Field += "\r\n마법 카드 : 공격력 " + Magicstatus[4].Magic_status + "증가";
                }
                Card_FieldFull_Fieldnull();
            }
        }
        private void CardAdd2_button(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && button1.Enabled == false && Magicbool1 == 0)
            {
                pictureBox2.Image = button1.Image;
                label13.Text = label1.Text; label14.Text = label2.Text;
                MyField_status[1].FieldHP_status = Mycardstatus[0].MyHP_status;
                MyField_status[1].FieldATK_status = Mycardstatus[0].MyATK_status;
                Info_Card[1].Info_Field = Info_Card[0].Info_Hand;
                button1.Image = null; button1.Enabled = true;
                label1.Text = "HP : 0"; label2.Text = "ATK : 0";
                button7.Text = "필드에 카드가 있습니다"; button7.Enabled = false;
            }
            if (e.Button == MouseButtons.Left && button2.Enabled == false && Magicbool2 == 0)
            {
                pictureBox2.Image = button2.Image;
                label13.Text = label3.Text; label14.Text = label4.Text;
                MyField_status[1].FieldHP_status = Mycardstatus[1].MyHP_status;
                MyField_status[1].FieldATK_status = Mycardstatus[1].MyATK_status;
                Info_Card[1].Info_Field = Info_Card[1].Info_Hand;
                button2.Image = null; button2.Enabled = true;
                label3.Text = "HP : 0"; label4.Text = "ATK : 0";
                button7.Text = "필드에 카드가 있습니다"; button7.Enabled = false;
            }
            if (e.Button == MouseButtons.Left && button3.Enabled == false && Magicbool3 == 0)
            {
                pictureBox2.Image = button3.Image;
                label13.Text = label5.Text; label14.Text = label6.Text;
                MyField_status[1].FieldHP_status = Mycardstatus[2].MyHP_status;
                MyField_status[1].FieldATK_status = Mycardstatus[2].MyATK_status;
                Info_Card[1].Info_Field = Info_Card[2].Info_Hand;
                button3.Image = null; button3.Enabled = true;
                label5.Text = "HP : 0"; label6.Text = "ATK : 0";
                button7.Text = "필드에 카드가 있습니다"; button7.Enabled = false;
            }
            if (e.Button == MouseButtons.Left && button4.Enabled == false && Magicbool4 == 0)
            {
                pictureBox2.Image = button4.Image;
                label13.Text = label7.Text; label14.Text = label8.Text;
                MyField_status[1].FieldHP_status = Mycardstatus[3].MyHP_status;
                MyField_status[1].FieldATK_status = Mycardstatus[3].MyATK_status;
                Info_Card[1].Info_Field = Info_Card[3].Info_Hand;
                button4.Image = null; button4.Enabled = true;
                label7.Text = "HP : 0"; label8.Text = "ATK : 0";
                button7.Text = "필드에 카드가 있습니다"; button7.Enabled = false;
            }
            if (e.Button == MouseButtons.Left && button5.Enabled == false && Magicbool5 == 0)
            {
                pictureBox2.Image = button5.Image;
                label13.Text = label9.Text; label14.Text = label10.Text;
                MyField_status[1].FieldHP_status = Mycardstatus[4].MyHP_status;
                MyField_status[1].FieldATK_status = Mycardstatus[4].MyATK_status;
                Info_Card[1].Info_Field = Info_Card[4].Info_Hand;
                button5.Image = null; button5.Enabled = true;
                label9.Text = "HP : 0"; label10.Text = "ATK : 0";
                button7.Text = "필드에 카드가 있습니다"; button7.Enabled = false;
            }

            if (button12.Visible == false && e.Button == MouseButtons.Left)
            {
                label13.Text = "HP : 0"; label14.Text = "ATK : 0";
                Card_FieldFull_Fieldnull();
                button12.Visible = true; pictureBox2.Image = null;
                textBox1.Text = "필드 두번째 카드를 버리셨습니다";
                button12.Text = "카드 버리기 \r\n" + --DeleteCardcount + "/3";
                if (pictureBox2.Image != null)
                {
                    button7.Text = "필드에 카드가 있습니다"; button7.Enabled = false;
                }
            }
            if (e.Button == MouseButtons.Left)
            {
                if (button1.Enabled == false && button1.Image != null && pictureBox2.Image != null && Magicbool1 == 1)
                {
                    pictureBox11.Image = null; textBox2.Text = ""; Info_Card[0].Info_Hand = "";
                    button1.Image = null; label1.Text = "HP : 0"; label2.Text = "ATK : 0"; Magicbool1 = 0;
                    MyField_status[1].FieldATK_status += Magicstatus[0].Magic_status;
                    label14.Text = "ATK : " + MyField_status[1].FieldATK_status;
                    textBox1.Text = "두번째 필드 카드에 공격력" + Magicstatus[0].Magic_status + "를 더한다";
                    Info_Card[1].Info_Field += "\r\n마법 카드 : 공격력 " + Magicstatus[0].Magic_status + "증가";
                }
                if (button2.Enabled == false && button2.Image != null && pictureBox2.Image != null && Magicbool2 == 1)
                {
                    pictureBox11.Image = null; textBox2.Text = ""; Info_Card[1].Info_Hand = "";
                    button2.Image = null; label3.Text = "HP : 0"; label4.Text = "ATK : 0"; Magicbool2 = 0;
                    MyField_status[1].FieldATK_status += Magicstatus[1].Magic_status;
                    label14.Text = "ATK : " + MyField_status[1].FieldATK_status;
                    textBox1.Text = "두번째 필드 카드에 공격력 " + Magicstatus[1].Magic_status + "를 더한다";
                    Info_Card[1].Info_Field += "\r\n마법 카드 : 공격력 " + Magicstatus[1].Magic_status + "증가";
                }
                if (button3.Enabled == false && button3.Image != null && pictureBox2.Image != null && Magicbool3 == 1)
                {
                    pictureBox11.Image = null; textBox2.Text = ""; Info_Card[2].Info_Hand = "";
                    button3.Image = null; label5.Text = "HP : 0"; label6.Text = "ATK : 0"; Magicbool3 = 0;
                    MyField_status[1].FieldATK_status += Magicstatus[2].Magic_status;
                    label14.Text = "ATK : " + MyField_status[1].FieldATK_status;
                    textBox1.Text = "두번째 필드 카드에 공격력 " + Magicstatus[2].Magic_status + "를 더한다";
                    Info_Card[1].Info_Field += "\r\n마법 카드 : 공격력 " + Magicstatus[2].Magic_status + "증가";
                }
                if (button4.Enabled == false && button4.Image != null && pictureBox2.Image != null && Magicbool4 == 1)
                {
                    pictureBox11.Image = null; textBox2.Text = ""; Info_Card[3].Info_Hand = "";
                    button4.Image = null; label7.Text = "HP : 0"; label8.Text = "ATK : 0"; Magicbool4 = 0;
                    MyField_status[1].FieldATK_status += Magicstatus[3].Magic_status;
                    label14.Text = "ATK : " + MyField_status[1].FieldATK_status;
                    textBox1.Text = "두번째 필드 카드에 공격력 " + Magicstatus[3].Magic_status + "를 더한다";
                    Info_Card[1].Info_Field += "\r\n마법 카드 : 공격력 " + Magicstatus[3].Magic_status + "증가";
                }
                if (button5.Enabled == false && button5.Image != null && pictureBox2.Image != null && Magicbool5 == 1)
                {
                    pictureBox11.Image = null; textBox2.Text = ""; Info_Card[4].Info_Hand = "";
                    button5.Image = null; label9.Text = "HP : 0"; label10.Text = "ATK : 0"; Magicbool5 = 0;
                    MyField_status[1].FieldATK_status += Magicstatus[4].Magic_status;
                    label14.Text = "ATK : " + MyField_status[1].FieldATK_status;
                    textBox1.Text = "두번째 필드 카드에 공격력 " + Magicstatus[4].Magic_status + "를 더한다";
                    Info_Card[1].Info_Field += "\r\n마법 카드 : 공격력 " + Magicstatus[4].Magic_status + "증가";
                }
                Card_FieldFull_Fieldnull();
            }
        }
        private void CardAdd3_button(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && button1.Enabled == false && button1.Image != null && Magicbool1 == 0)
            {
                pictureBox3.Image = button1.Image;
                label15.Text = label1.Text; label16.Text = label2.Text;
                MyField_status[2].FieldHP_status = Mycardstatus[0].MyHP_status;
                MyField_status[2].FieldATK_status = Mycardstatus[0].MyATK_status;
                button1.Image = null; button1.Enabled = true;
                label1.Text = "HP : 0"; label2.Text = "ATK : 0";
                button8.Text = "필드에 카드가 있습니다"; button8.Enabled = false;
            }
            if (e.Button == MouseButtons.Left && button2.Enabled == false && button2.Image != null && Magicbool2 == 0)
            {
                pictureBox3.Image = button2.Image;
                label15.Text = label3.Text; label16.Text = label4.Text;
                MyField_status[2].FieldHP_status = Mycardstatus[1].MyHP_status;
                MyField_status[2].FieldATK_status = Mycardstatus[1].MyATK_status;
                button2.Image = null; button2.Enabled = true;
                label3.Text = "HP : 0"; label4.Text = "ATK : 0";
                button8.Text = "필드에 카드가 있습니다"; button8.Enabled = false;
            }
            if (e.Button == MouseButtons.Left && button3.Enabled == false && button3.Image != null && Magicbool3 == 0)
            {
                pictureBox3.Image = button3.Image;
                label15.Text = label5.Text; label16.Text = label6.Text;
                MyField_status[2].FieldHP_status = Mycardstatus[2].MyHP_status;
                MyField_status[2].FieldATK_status = Mycardstatus[2].MyATK_status;
                button3.Image = null; button3.Enabled = true;
                label5.Text = "HP : 0"; label6.Text = "ATK : 0";
                button8.Text = "필드에 카드가 있습니다"; button8.Enabled = false;
            }
            if (e.Button == MouseButtons.Left && button4.Enabled == false && button4.Image != null && Magicbool4 == 0)
            {
                pictureBox3.Image = button4.Image;
                label15.Text = label7.Text; label16.Text = label8.Text;
                MyField_status[2].FieldHP_status = Mycardstatus[3].MyHP_status;
                MyField_status[2].FieldATK_status = Mycardstatus[3].MyATK_status;
                button4.Image = null; button4.Enabled = true;
                label7.Text = "HP : 0"; label8.Text = "ATK : 0";
                button8.Text = "필드에 카드가 있습니다"; button8.Enabled = false;
            }
            if (e.Button == MouseButtons.Left && button5.Enabled == false && button5.Image != null && Magicbool5 == 0)
            {
                pictureBox3.Image = button5.Image;
                label15.Text = label9.Text; label16.Text = label10.Text;
                MyField_status[2].FieldHP_status = Mycardstatus[4].MyHP_status;
                MyField_status[2].FieldATK_status = Mycardstatus[4].MyATK_status;
                button5.Image = null; button5.Enabled = true;
                label9.Text = "HP : 0"; label10.Text = "ATK : 0";
                button8.Text = "필드에 카드가 있습니다"; button8.Enabled = false;
            }

            if (button12.Visible == false && e.Button == MouseButtons.Left)
            {
                label15.Text = "HP : 0"; label16.Text = "ATK : 0";
                label13.Text = "HP : 0"; label14.Text = "ATK : 0";
                Card_FieldFull_Fieldnull();
                button12.Visible = true; pictureBox3.Image = null;
                textBox1.Text = "필드 세번째 카드를 버리셨습니다";
                button12.Text = "카드 버리기 \r\n" + --DeleteCardcount + "/3";
                if (pictureBox3.Image != null)
                {
                    button8.Text = "필드에 카드가 있습니다"; button8.Enabled = false;
                }
            }
            if (e.Button == MouseButtons.Left)
            {
                if (button1.Enabled == false && button1.Image != null && pictureBox3.Image != null && Magicbool1 == 1)
                {
                    pictureBox11.Image = null; textBox2.Text = ""; Info_Card[0].Info_Hand = "";
                    button1.Image = null; label1.Text = "HP : 0"; label2.Text = "ATK : 0"; Magicbool1 = 0;
                    MyField_status[2].FieldATK_status += Magicstatus[0].Magic_status;
                    label16.Text = "ATK : " + MyField_status[2].FieldATK_status;
                    textBox1.Text = "세번째 필드 카드에 공격력 " + Magicstatus[0].Magic_status + "를 더한다";
                    Info_Card[2].Info_Field += "\r\n마법 카드 : 공격력 " + Magicstatus[0].Magic_status + "증가";
                }
                if (button2.Enabled == false && button2.Image != null && pictureBox3.Image != null && Magicbool2 == 1)
                {
                    pictureBox11.Image = null; textBox2.Text = ""; Info_Card[1].Info_Hand = "";
                    button2.Image = null; label3.Text = "HP : 0"; label4.Text = "ATK : 0"; Magicbool2 = 0;
                    MyField_status[2].FieldATK_status += Magicstatus[1].Magic_status;
                    label16.Text = "ATK : " + MyField_status[2].FieldATK_status;
                    textBox1.Text = "세번째 필드 카드에 공격력 " + Magicstatus[1].Magic_status + "를 더한다";
                    Info_Card[2].Info_Field += "\r\n마법 카드 : 공격력 " + Magicstatus[1].Magic_status + "증가";
                }
                if (button3.Enabled == false && button3.Image != null && pictureBox3.Image != null && Magicbool3 == 1)
                {
                    pictureBox11.Image = null; textBox2.Text = ""; Info_Card[2].Info_Hand = "";
                    button3.Image = null; label5.Text = "HP : 0"; label6.Text = "ATK : 0"; Magicbool3 = 0;
                    MyField_status[2].FieldATK_status += Magicstatus[2].Magic_status;
                    label16.Text = "ATK : " + MyField_status[2].FieldATK_status;
                    textBox1.Text = "세번째 필드 카드에 공격력 " + Magicstatus[2].Magic_status + "를 더한다";
                    Info_Card[2].Info_Field += "\r\n마법 카드 : 공격력 " + Magicstatus[2].Magic_status + "증가";
                }
                if (button4.Enabled == false && button4.Image != null && pictureBox3.Image != null && Magicbool4 == 1)
                {
                    pictureBox11.Image = null; textBox2.Text = ""; Info_Card[3].Info_Hand = "";
                    button4.Image = null; label7.Text = "HP : 0"; label8.Text = "ATK : 0"; Magicbool4 = 0;
                    MyField_status[2].FieldATK_status += Magicstatus[3].Magic_status;
                    label16.Text = "ATK : " + MyField_status[2].FieldATK_status;
                    textBox1.Text = "세번째 필드 카드에 공격력 " + Magicstatus[3].Magic_status + "를 더한다";
                    Info_Card[2].Info_Field += "\r\n마법 카드 : 공격력 " + Magicstatus[3].Magic_status + "증가";
                }
                if (button5.Enabled == false && button5.Image != null && pictureBox3.Image != null && Magicbool5 == 1)
                {
                    pictureBox11.Image = null; textBox2.Text = ""; Info_Card[4].Info_Hand = "";
                    button5.Image = null; label9.Text = "HP : 0"; label10.Text = "ATK : 0"; Magicbool5 = 0;
                    MyField_status[2].FieldATK_status += Magicstatus[4].Magic_status;
                    label16.Text = "ATK : " + MyField_status[2].FieldATK_status;
                    textBox1.Text = "세번째 필드 카드에 공격력 " + Magicstatus[4].Magic_status + "를 더한다";
                    Info_Card[2].Info_Field += "\r\n마법 카드 : 공격력 " + Magicstatus[4].Magic_status + "증가";
                }
                Card_FieldFull_Fieldnull();
            }
        }
        private void CardAdd4_button(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && button1.Enabled == false && button1.Image != null && Magicbool1 == 0)
            {
                pictureBox4.Image = button1.Image;
                label17.Text = label1.Text; label18.Text = label2.Text;
                MyField_status[3].FieldHP_status = Mycardstatus[0].MyHP_status;
                MyField_status[3].FieldATK_status = Mycardstatus[0].MyATK_status;
                button1.Image = null; button1.Enabled = true;
                label1.Text = "HP : 0"; label2.Text = "ATK : 0";
                button9.Text = "필드에 카드가 있습니다"; button9.Enabled = false;
            }
            if (e.Button == MouseButtons.Left && button2.Enabled == false && button2.Image != null && Magicbool2 == 0)
            {
                pictureBox4.Image = button2.Image;
                label17.Text = label3.Text; label18.Text = label4.Text;
                MyField_status[3].FieldHP_status = Mycardstatus[1].MyHP_status;
                MyField_status[3].FieldATK_status = Mycardstatus[1].MyATK_status;
                button2.Image = null; button2.Enabled = true;
                label3.Text = "HP : 0"; label4.Text = "ATK : 0";
                button9.Text = "필드에 카드가 있습니다"; button9.Enabled = false;
            }
            if (e.Button == MouseButtons.Left && button3.Enabled == false && button3.Image != null && Magicbool3 == 0)
            {
                pictureBox4.Image = button3.Image;
                label17.Text = label5.Text; label18.Text = label6.Text;
                MyField_status[3].FieldHP_status = Mycardstatus[2].MyHP_status;
                MyField_status[3].FieldATK_status = Mycardstatus[2].MyATK_status;
                button3.Image = null; button3.Enabled = true;
                label5.Text = "HP : 0"; label6.Text = "ATK : 0";
                button9.Text = "필드에 카드가 있습니다"; button9.Enabled = false;
            }
            if (e.Button == MouseButtons.Left && button4.Enabled == false && button4.Image != null && Magicbool4 == 0)
            {
                pictureBox4.Image = button4.Image;
                label17.Text = label7.Text; label18.Text = label8.Text;
                MyField_status[3].FieldHP_status = Mycardstatus[3].MyHP_status;
                MyField_status[3].FieldATK_status = Mycardstatus[3].MyATK_status;
                button4.Image = null; button4.Enabled = true;
                label7.Text = "HP : 0"; label8.Text = "ATK : 0";
                button9.Text = "필드에 카드가 있습니다"; button9.Enabled = false;
            }
            if (e.Button == MouseButtons.Left && button5.Enabled == false && button5.Image != null && Magicbool5 == 0)
            {
                pictureBox4.Image = button5.Image;
                label17.Text = label9.Text; label18.Text = label10.Text;
                MyField_status[3].FieldHP_status = Mycardstatus[4].MyHP_status;
                MyField_status[3].FieldATK_status = Mycardstatus[4].MyATK_status;
                button5.Image = null; button5.Enabled = true;
                label9.Text = "HP : 0"; label10.Text = "ATK : 0";
                button9.Text = "필드에 카드가 있습니다"; button9.Enabled = false;
            }

            if (button12.Visible == false && e.Button == MouseButtons.Left)
            {
                label17.Text = "HP : 0"; label18.Text = "ATK : 0";
                Card_FieldFull_Fieldnull();
                button12.Visible = true; pictureBox4.Image = null;
                textBox1.Text = "필드 네번째 카드를 버리셨습니다";
                button12.Text = "카드 버리기 \r\n" + --DeleteCardcount + "/3";
                if (pictureBox4.Image != null)
                {
                    button9.Text = "필드에 카드가 있습니다"; button9.Enabled = false;
                }
            }
            if (e.Button == MouseButtons.Left)
            {
                if (button1.Enabled == false && button1.Image != null && pictureBox4.Image != null && Magicbool1 == 1)
                {
                    pictureBox11.Image = null; textBox2.Text = ""; Info_Card[0].Info_Hand = "";
                    button1.Image = null; label1.Text = "HP : 0"; label2.Text = "ATK : 0"; Magicbool1 = 0;
                    MyField_status[3].FieldATK_status += Magicstatus[0].Magic_status;
                    label18.Text = "ATK : " + MyField_status[3].FieldATK_status;
                    textBox1.Text = "네번째 필드 카드에 공격력 " + Magicstatus[0].Magic_status + "를 더한다";
                    Info_Card[3].Info_Field += "\r\n마법 카드 : 공격력 " + Magicstatus[0].Magic_status + "증가";
                }
                if (button2.Enabled == false && button2.Image != null && pictureBox4.Image != null && Magicbool2 == 1)
                {
                    pictureBox11.Image = null; textBox2.Text = ""; Info_Card[1].Info_Hand = "";
                    button2.Image = null; label3.Text = "HP : 0"; label4.Text = "ATK : 0"; Magicbool2 = 0;
                    MyField_status[3].FieldATK_status += Magicstatus[1].Magic_status;
                    label18.Text = "ATK : " + MyField_status[3].FieldATK_status;
                    textBox1.Text = "네번째 필드 카드에 공격력 " + Magicstatus[1].Magic_status + "를 더한다";
                    Info_Card[3].Info_Field += "\r\n마법 카드 : 공격력 " + Magicstatus[1].Magic_status + "증가";
                }
                if (button3.Enabled == false && button3.Image != null && pictureBox4.Image != null && Magicbool3 == 1)
                {
                    pictureBox11.Image = null; textBox2.Text = ""; Info_Card[2].Info_Hand = "";
                    button3.Image = null; label5.Text = "HP : 0"; label6.Text = "ATK : 0"; Magicbool3 = 0;
                    MyField_status[3].FieldATK_status += Magicstatus[2].Magic_status;
                    label18.Text = "ATK : " + MyField_status[3].FieldATK_status;
                    textBox1.Text = "네번째 필드 카드에 공격력 " + Magicstatus[2].Magic_status + "를 더한다";
                    Info_Card[3].Info_Field += "\r\n마법 카드 : 공격력 " + Magicstatus[2].Magic_status + "증가";
                }
                if (button4.Enabled == false && button4.Image != null && pictureBox4.Image != null && Magicbool4 == 1)
                {
                    pictureBox11.Image = null; textBox2.Text = ""; Info_Card[3].Info_Hand = "";
                    button4.Image = null; label7.Text = "HP : 0"; label8.Text = "ATK : 0"; Magicbool4 = 0;
                    MyField_status[3].FieldATK_status += Magicstatus[3].Magic_status;
                    label18.Text = "ATK : " + MyField_status[3].FieldATK_status;
                    textBox1.Text = "네번째 필드 카드에 공격력 " + Magicstatus[3].Magic_status + "를 더한다";
                    Info_Card[3].Info_Field += "\r\n마법 카드 : 공격력 " + Magicstatus[3].Magic_status + "증가";
                }
                if (button5.Enabled == false && button5.Image != null && pictureBox4.Image != null && Magicbool5 == 1)
                {
                    pictureBox11.Image = null; textBox2.Text = ""; Info_Card[4].Info_Hand = "";
                    button5.Image = null; label9.Text = "HP : 0"; label10.Text = "ATK : 0"; Magicbool5 = 0;
                    MyField_status[3].FieldATK_status += Magicstatus[4].Magic_status;
                    label18.Text = "ATK : " + MyField_status[3].FieldATK_status;
                    textBox1.Text = "네번째 필드 카드에 공격력 " + Magicstatus[4].Magic_status + "를 더한다";
                    Info_Card[3].Info_Field += "\r\n마법 카드 : 공격력 " + Magicstatus[4].Magic_status + "증가";
                }
                Card_FieldFull_Fieldnull();
            }
        }
        private void CardAdd5_button(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && button1.Enabled == false && button1.Image != null && Magicbool1 == 0)
            {
                pictureBox5.Image = button1.Image;
                label19.Text = label1.Text; label20.Text = label2.Text;
                MyField_status[4].FieldHP_status = Mycardstatus[0].MyHP_status;
                MyField_status[4].FieldATK_status = Mycardstatus[0].MyATK_status;
                button1.Image = null; button1.Enabled = true;
                label1.Text = "HP : 0"; label2.Text = "ATK : 0";
                button10.Text = "필드에 카드가 있습니다"; button10.Enabled = false;
            }
            if (e.Button == MouseButtons.Left && button2.Enabled == false && button2.Image != null && Magicbool2 == 0)
            {
                pictureBox5.Image = button2.Image;
                label19.Text = label3.Text; label20.Text = label4.Text;
                MyField_status[4].FieldHP_status = Mycardstatus[1].MyHP_status;
                MyField_status[4].FieldATK_status = Mycardstatus[1].MyATK_status;
                button2.Image = null; button2.Enabled = true;
                label3.Text = "HP : 0"; label4.Text = "ATK : 0";
                button10.Text = "필드에 카드가 있습니다"; button10.Enabled = false;
            }
            if (e.Button == MouseButtons.Left && button3.Enabled == false && button3.Image != null && Magicbool3 == 0)
            {
                pictureBox5.Image = button3.Image;
                label19.Text = label5.Text; label20.Text = label6.Text;
                MyField_status[4].FieldHP_status = Mycardstatus[2].MyHP_status;
                MyField_status[4].FieldATK_status = Mycardstatus[2].MyATK_status;
                button3.Image = null; button3.Enabled = true;
                label5.Text = "HP : 0"; label6.Text = "ATK : 0";
                button10.Text = "필드에 카드가 있습니다"; button10.Enabled = false;
            }
            if (e.Button == MouseButtons.Left && button4.Enabled == false && button4.Image != null && Magicbool4 == 0)
            {
                pictureBox5.Image = button4.Image;
                label19.Text = label7.Text; label20.Text = label8.Text;
                MyField_status[4].FieldHP_status = Mycardstatus[3].MyHP_status;
                MyField_status[4].FieldATK_status = Mycardstatus[3].MyATK_status;
                button4.Image = null; button4.Enabled = true;
                label7.Text = "HP : 0"; label8.Text = "ATK : 0";
                button10.Text = "필드에 카드가 있습니다"; button10.Enabled = false;
            }
            if (e.Button == MouseButtons.Left && button5.Enabled == false && button5.Image != null && Magicbool5 == 0)
            {
                pictureBox5.Image = button5.Image;
                label19.Text = label9.Text; label20.Text = label10.Text;
                MyField_status[4].FieldHP_status = Mycardstatus[4].MyHP_status;
                MyField_status[4].FieldATK_status = Mycardstatus[4].MyATK_status;
                button5.Image = null; button5.Enabled = true;
                label9.Text = "HP : 0"; label10.Text = "ATK : 0";
                button10.Text = "필드에 카드가 있습니다"; button10.Enabled = false;
            }

            if (button12.Visible == false && e.Button == MouseButtons.Left)
            {
                label19.Text = "HP : 0"; label20.Text = "ATK : 0";
                Card_FieldFull_Fieldnull();
                button12.Visible = true; pictureBox5.Image = null;
                textBox1.Text = "필드 다섯번째 카드를 버리셨습니다";
                button12.Text = "카드 버리기 \r\n" + --DeleteCardcount + "/3";
                if (pictureBox5.Image != null)
                {
                    button10.Text = "필드에 카드가 있습니다"; button10.Enabled = false;
                }
            }
            if (e.Button == MouseButtons.Left)
            {
                if (button1.Enabled == false && button1.Image != null && pictureBox5.Image != null && Magicbool1 == 1)
                {
                    pictureBox11.Image = null; textBox2.Text = ""; Info_Card[0].Info_Hand = "";
                    button1.Image = null; label1.Text = "HP : 0"; label2.Text = "ATK : 0"; Magicbool1 = 0;
                    MyField_status[4].FieldATK_status += Magicstatus[0].Magic_status;
                    label20.Text = "ATK : " + MyField_status[4].FieldATK_status;
                    textBox1.Text = "다섯번째 필드 카드에 공격력 " + Magicstatus[0].Magic_status + "를 더한다";
                    Info_Card[4].Info_Field += "\r\n마법 카드 : 공격력 " + Magicstatus[0].Magic_status + "증가";
                }
                if (button2.Enabled == false && button2.Image != null && pictureBox5.Image != null && Magicbool2 == 1)
                {
                    pictureBox11.Image = null; textBox2.Text = ""; Info_Card[1].Info_Hand = "";
                    button2.Image = null; label3.Text = "HP : 0"; label4.Text = "ATK : 0"; Magicbool2 = 0;
                    MyField_status[4].FieldATK_status += Magicstatus[1].Magic_status;
                    label20.Text = "ATK : " + MyField_status[4].FieldATK_status;
                    textBox1.Text = "다섯번째 필드 카드에 공격력 " + Magicstatus[1].Magic_status + "를 더한다";
                    Info_Card[4].Info_Field += "\r\n마법 카드 : 공격력 " + Magicstatus[1].Magic_status + "증가";
                }
                if (button3.Enabled == false && button3.Image != null && pictureBox5.Image != null && Magicbool3 == 1)
                {
                    pictureBox11.Image = null; textBox2.Text = ""; Info_Card[2].Info_Hand = "";
                    button3.Image = null; label5.Text = "HP : 0"; label6.Text = "ATK : 0"; Magicbool3 = 0;
                    MyField_status[4].FieldATK_status += Magicstatus[2].Magic_status;
                    label20.Text = "ATK : " + MyField_status[4].FieldATK_status;
                    textBox1.Text = "다섯번째 필드 카드에 공격력 " + Magicstatus[2].Magic_status + "를 더한다";
                    Info_Card[4].Info_Field += "\r\n마법 카드 : 공격력 " + Magicstatus[2].Magic_status + "증가";
                }
                if (button4.Enabled == false && button4.Image != null && pictureBox5.Image != null && Magicbool4 == 1)
                {
                    pictureBox11.Image = null; textBox2.Text = ""; Info_Card[3].Info_Hand = "";
                    button4.Image = null; label7.Text = "HP : 0"; label8.Text = "ATK : 0"; Magicbool4 = 0;
                    MyField_status[4].FieldATK_status += Magicstatus[3].Magic_status;
                    label20.Text = "ATK : " + MyField_status[4].FieldATK_status;
                    textBox1.Text = "다섯번째 필드 카드에 공격력 " + Magicstatus[3].Magic_status + "를 더한다";
                    Info_Card[4].Info_Field += "\r\n마법 카드 : 공격력 " + Magicstatus[3].Magic_status + "증가";
                }
                if (button5.Enabled == false && button5.Image != null && pictureBox5.Image != null && Magicbool5 == 1)
                {
                    pictureBox11.Image = null; textBox2.Text = ""; Info_Card[4].Info_Hand = "";
                    button5.Image = null; label9.Text = "HP : 0"; label10.Text = "ATK : 0"; Magicbool5 = 0;
                    MyField_status[4].FieldATK_status += Magicstatus[4].Magic_status;
                    label20.Text = "ATK : " + MyField_status[4].FieldATK_status;
                    textBox1.Text = "다섯번째 필드 카드에 공격력 " + Magicstatus[4].Magic_status + "를 더한다";
                    Info_Card[4].Info_Field += "\r\n마법 카드 : 공격력 " + Magicstatus[4].Magic_status + "증가";
                }
                Card_FieldFull_Fieldnull();
            }
        }
        private void Card1_button(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                textBox2.Text = "첫번째 나의 카드 정보\r\n" + label1.Text + "\t" + label2.Text + "\r\n" + Info_Card[0].Info_Hand;
                pictureBox11.Image = button1.Image; button1.Enabled = false;
                if (button2.Enabled == false) { button2.Enabled = true; }
           else if (button3.Enabled == false) { button3.Enabled = true; }
           else if (button4.Enabled == false) { button4.Enabled = true; }
           else if (button5.Enabled == false) { button5.Enabled = true; }
           else if (button1.Image == null) { button1.Enabled = true; }

                if (e.Button == MouseButtons.Left && Magicbool1 == 1)
                { MagicSpell_AddCard(); }
                else if(e.Button == MouseButtons.Left && Magicbool1 == 0)
                { Card_FieldFull_Fieldnull(); }
                if (button12.Visible == false && e.Button == MouseButtons.Left && button1.Image != null)
                {
                    label1.Text = "HP : 0"; label2.Text = "ATK : 0"; button1.Image = null;
                    button12.Visible = true; button1.Enabled = true;
                    textBox1.Text = "나의 패에 있는 첫번째 카드를 버리셨습니다";
                    button12.Text = "카드 버리기 \r\n" + --DeleteCardcount + "/3";
                    Card_FieldFull_Fieldnull(); button12.Visible = true;
                }
                if (button12.Enabled == false && e.Button == MouseButtons.Left && button1.Image == null)
                { textBox1.Text = "그곳에는 버릴 카드가 없습니다"; button12.Visible = true; button1.Enabled = true; }
            }
        }
        private void Card2_button(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                textBox2.Text = "두번째 나의 카드 정보\r\n" + label3.Text + "\t" + label4.Text + "\r\n" + Info_Card[1].Info_Hand;
                pictureBox11.Image = button2.Image; button2.Enabled = false;
                if (button1.Enabled == false) { button1.Enabled = true; }
           else if (button3.Enabled == false) { button3.Enabled = true; }
           else if (button4.Enabled == false) { button4.Enabled = true; }
           else if (button5.Enabled == false) { button5.Enabled = true; }
           else if (button2.Image == null) { button2.Enabled = true; }

                if (e.Button == MouseButtons.Left && Magicbool2 == 1)
                { MagicSpell_AddCard(); }
                else if (e.Button == MouseButtons.Left && Magicbool2 == 0)
                { Card_FieldFull_Fieldnull(); }
                if (button12.Visible == false && e.Button == MouseButtons.Left && button2.Image != null)
                {
                    label3.Text = "HP : 0"; label4.Text = "ATK : 0";
                    button2.Image = null; button12.Visible = true; button2.Enabled = true;
                    textBox1.Text = "나의 패에 있는 두번째 카드를 버리셨습니다";
                    button12.Text = "카드 버리기 \r\n" + --DeleteCardcount + "/3";
                    Card_FieldFull_Fieldnull(); button12.Visible = true;
                }
                if (button12.Enabled == false && e.Button == MouseButtons.Left && button2.Image == null)
                { textBox1.Text = "그곳에는 버릴 카드가 없습니다"; button12.Visible = true; button2.Enabled = true; }
            }
        }
        private void Card3_button(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                textBox2.Text = "세번째 나의 카드 정보\r\n" + label5.Text + "\t" + label6.Text + "\r\n" + Info_Card[2].Info_Hand;
                pictureBox11.Image = button3.Image; button3.Enabled = false;
                if (button1.Enabled == false) { button1.Enabled = true; }
           else if (button2.Enabled == false) { button2.Enabled = true; }
           else if (button4.Enabled == false) { button4.Enabled = true; }
           else if (button5.Enabled == false) { button5.Enabled = true; }
           else if (button3.Image == null) { button3.Enabled = true; }
            }
            if (e.Button == MouseButtons.Left && Magicbool3 == 1)
            { MagicSpell_AddCard(); }
            else if (e.Button == MouseButtons.Left && Magicbool3 == 0)
            { Card_FieldFull_Fieldnull(); }
            if (button12.Visible == false && e.Button == MouseButtons.Left && button3.Image != null)
            {
                label5.Text = "HP : 0"; label6.Text = "ATK : 0";
                button3.Image = null; button12.Visible = true; button3.Enabled = true;
                textBox1.Text = "나의 패에 있는 세번째 카드를 버리셨습니다";
                button12.Text = "카드 버리기 \r\n" + --DeleteCardcount + "/3";
                Card_FieldFull_Fieldnull(); button12.Visible = true;
            }
            if (button12.Enabled == false && e.Button == MouseButtons.Left && button3.Image == null)
            { textBox1.Text = "그곳에는 버릴 카드가 없습니다"; button12.Visible = true; button3.Enabled = true; }
        }
        private void Card4_button(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                textBox2.Text = "네번째 나의 카드 정보\r\n" + label7.Text + "\t" + label8.Text + "\r\n" + Info_Card[3].Info_Hand;
                pictureBox11.Image = button4.Image; button4.Enabled = false;
                if (button1.Enabled == false) { button1.Enabled = true; }
           else if (button2.Enabled == false) { button2.Enabled = true; }
           else if (button3.Enabled == false) { button3.Enabled = true; }
           else if (button5.Enabled == false) { button5.Enabled = true; }
           else if (button4.Image == null) { button4.Enabled = true; }
            }
            if (e.Button == MouseButtons.Left && Magicbool4 == 1)
            { MagicSpell_AddCard(); }
            else if (e.Button == MouseButtons.Left && Magicbool4 == 0)
            { Card_FieldFull_Fieldnull(); }
            if (button12.Visible == false && e.Button == MouseButtons.Left && button4.Image != null)
            {
                label7.Text = "HP : 0"; label8.Text = "ATK : 0";
                button4.Image = null; button12.Visible = true; button4.Enabled = true;
                textBox1.Text = "나의 패에 있는 네번째 카드를 버리셨습니다";
                button12.Text = "카드 버리기 \r\n" + --DeleteCardcount + "/3";
                Card_FieldFull_Fieldnull(); button12.Visible = true;
            }
            if (button12.Enabled == false && e.Button == MouseButtons.Left && button4.Image == null)
            { textBox1.Text = "그곳에는 버릴 카드가 없습니다"; button12.Visible = true; button4.Enabled = true; }
        }
        private void Card5_button(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                textBox2.Text = "다섯번째 나의 카드 정보\r\n" + label9.Text + "\t" + label10.Text + "\r\n" + Info_Card[4].Info_Hand;
                pictureBox11.Image = button5.Image; button5.Enabled = false;
                if (button1.Enabled == false) { button1.Enabled = true; }
           else if (button2.Enabled == false) { button2.Enabled = true; }
           else if (button3.Enabled == false) { button3.Enabled = true; }
           else if (button4.Enabled == false) { button4.Enabled = true; }
           else if (button5.Image == null) { button5.Enabled = true; }
            }
            if (e.Button == MouseButtons.Left && Magicbool5 == 1)
            { MagicSpell_AddCard(); }
            else if (e.Button == MouseButtons.Left && Magicbool5 == 0)
            { Card_FieldFull_Fieldnull(); }
            if (button12.Visible == false && e.Button == MouseButtons.Left && button5.Image != null)
            {
                label9.Text = "HP : 0"; label10.Text = "ATK : 0";
                button5.Image = null; button12.Visible = true; button5.Enabled = true;
                textBox1.Text = "나의 패에 있는 다섯번째 카드를 버리셨습니다";
                button12.Text = "카드 버리기 \r\n" + --DeleteCardcount + "/3";
                Card_FieldFull_Fieldnull(); button12.Visible = true;
            }
            if (button12.Enabled == false && e.Button == MouseButtons.Left && button5.Image == null)
            { textBox1.Text = "그곳에는 버릴 카드가 없습니다"; button12.Visible = true; button5.Enabled = true; }
        }
        private void FieldCard_Info1(object sender, MouseEventArgs e)
        {
            textBox2.Text = "첫번째 필드 카드 정보\r\n" + label11.Text + "\t" + label12.Text + "\r\n";
            pictureBox11.Image = pictureBox1.Image; textBox2.Text += Info_Card[0].Info_Field;
            button1.Enabled = true; button2.Enabled = true; button3.Enabled = true; button4.Enabled = true; button5.Enabled = true;
        }

        private void FieldCard_Info2(object sender, MouseEventArgs e)
        {
            textBox2.Text = "두번째 필드 카드 정보\r\n" + label13.Text + "\t" + label14.Text + "\r\n";
            pictureBox11.Image = pictureBox2.Image; textBox2.Text += Info_Card[1].Info_Field;
            button1.Enabled = true; button2.Enabled = true; button3.Enabled = true; button4.Enabled = true; button5.Enabled = true;
        }
        private void FieldCard_Info3(object sender, MouseEventArgs e)
        {
            textBox2.Text = "세번째 필드 카드 정보\r\n" + label15.Text + "\t" + label16.Text + "\r\n";
            pictureBox11.Image = pictureBox3.Image; textBox2.Text += Info_Card[2].Info_Field;
            button1.Enabled = true; button2.Enabled = true; button3.Enabled = true; button4.Enabled = true; button5.Enabled = true;
        }
        private void FieldCard_Info4(object sender, MouseEventArgs e)
        {
            textBox2.Text = "네번째 필드 카드 정보\r\n" + label17.Text + "\t" + label18.Text + "\r\n";
            pictureBox11.Image = pictureBox4.Image; textBox2.Text += Info_Card[3].Info_Field;
            button1.Enabled = true; button2.Enabled = true; button3.Enabled = true; button4.Enabled = true; button5.Enabled = true;
        }
        private void FieldCard_Info5(object sender, MouseEventArgs e)
        {
            textBox2.Text = "다섯번째 필드 카드 정보\r\n" + label19.Text + "\t" + label20.Text + "\r\n";
            pictureBox11.Image = pictureBox5.Image; textBox2.Text += Info_Card[4].Info_Field;
            button1.Enabled = true; button2.Enabled = true; button3.Enabled = true; button4.Enabled = true; button5.Enabled = true;
        }
        private void MagicClick(object sender, EventArgs e)
        { Card_FieldFull_Fieldnull(); }
        public Form1()
        { InitializeComponent(); this.Load += new EventHandler(Form1_Load); }
    }
}
