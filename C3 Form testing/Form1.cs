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
using System.Reflection.Emit;
using System.Security.Permissions;

namespace C3_Form_testing
{
    public partial class Form1 : Form
    {
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
        Random Card_Number = new Random(); Random Magic_point = new Random();
        public int MyHp = 50, AiHp = 50, DeleteCardcount = 3, GameLV, BattleRectangle = 0,
                   BattlePhase = 0;
        public int Magicbool1 = 0, Magicbool2 = 0, Magicbool3 = 0, Magicbool4 = 0, Magicbool5 = 0,
                   Handbool1 = 0, Handbool2 = 0, Handbool3 = 0, Handbool4 = 0, Handbool5 = 0,
                   Fieldbool1 = 0, Fieldbool2 = 0, Fieldbool3 = 0, Fieldbool4 = 0, Fieldbool5 = 0,
                   AiFieldbool1 = 0, AiFieldbool2 = 0, AiFieldbool3 = 0, AiFieldbool4 = 0, AiFieldbool5 = 0;
        public Image NullCard = Properties.Resources.nullslot;
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
            public int ATK, AiATK, HP, AiHP, keycode, Aikeycode, MagicATK, MagicHP;
            public Image MonsterCardcode, AiMonsterCardcode, MagicCardcode_HP, MagicCardcode_ATK;
        }
        Card[] CardDB = new Card[11]; Information_Card[] Info_Card = new Information_Card[6];
        MyCardstatus[] Mycardstatus = new MyCardstatus[6]; 
        AiCardstatus[] Aicardstatus = new AiCardstatus[6];
        MyFieldCardstatus[] MyField_status = new MyFieldCardstatus[6];
        MagicCardstsatus[] Magicstatus = new MagicCardstsatus[6];
        private void Form1_Load(object sender, EventArgs e)
        {// 11 - 17 폼연결 프로토타입 ShowDialog가 아닌 Show로 하면 Form1과 2가 실행됨
            Form2 F2 = new Form2(this,true); F2.Owner = this; F2.Show();
            label31.Text = "MyHp : 50"; label32.Text = "AiHp : 50"; textBox1.MaxLength = 100;
        }
        private void Form1_Click(object sender, EventArgs e)
        {
            if(BattlePhase == 0)
            {
                textBox2.Text = ""; pictureBox11.Image = NullCard; label33.Text = ""; label34.Text = "";
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
        }
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
            // 11 - 20 HP, ATK 2개로 1~5까지 줄여서 3가지로 나눔 0, 6, 7, 8, 9는 사용하지 않음
            CardDB[1].MagicCardcode_HP = Properties.Resources.MagicCard_HP1;
            CardDB[2].MagicCardcode_HP = Properties.Resources.MagicCard_HP1;
            CardDB[3].MagicCardcode_HP = Properties.Resources.MagicCard_HP2;
            CardDB[4].MagicCardcode_HP = Properties.Resources.MagicCard_HP2;
            CardDB[5].MagicCardcode_HP = Properties.Resources.MagicCard_HP3;
            CardDB[1].MagicCardcode_ATK = Properties.Resources.MagicCard_ATK1;
            CardDB[2].MagicCardcode_ATK = Properties.Resources.MagicCard_ATK1;
            CardDB[3].MagicCardcode_ATK = Properties.Resources.MagicCard_ATK2;
            CardDB[4].MagicCardcode_ATK = Properties.Resources.MagicCard_ATK2;
            CardDB[5].MagicCardcode_ATK = Properties.Resources.MagicCard_ATK3;

            for (int i = 0; i <= 9; i++)
            {
                if(i <= 5) { CardDB[i].MagicATK = i; CardDB[i].MagicHP = i; }
                CardDB[i].ATK = ATK_point.Next(1, 7); CardDB[i].HP = HP_point.Next(1, 10);
                CardDB[i].keycode = i;
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
            {// 11 - 17 폼연결 프로토타입 : GameLV의 값을 Form2에서 받아서 대입시킴
                if(GameLV == 1)
                {
                    CardDB[i].AiATK = ATK_point.Next(1, 5); CardDB[i].AiHP = HP_point.Next(1, 6);
                    CardDB[i].Aikeycode = i;
                }
                else if(GameLV == 2)
                {
                    CardDB[i].AiATK = ATK_point.Next(2, 6); CardDB[i].AiHP = HP_point.Next(2, 8);
                    CardDB[i].Aikeycode = i;
                }
                else if(GameLV == 3)
                {
                    CardDB[i].AiATK = ATK_point.Next(3, 7); CardDB[i].AiHP = HP_point.Next(3, 10);
                    CardDB[i].Aikeycode = i;
                }
               
            }
        }
        private void Setting_button(object sender, MouseEventArgs e)
        {
            Form4 _Form4 = new Form4(this);
            _Form4.ShowDialog();
        }

        public void ChangeFont(FontFamily Nfont)
        {
            //6,7,8,9,10,11,20,t1,t2Font font = textBox1.Font;
            Font Bfont = button6.Font;
            button6.Font = new Font(Nfont, Bfont.Size, Bfont.Style);
            button7.Font = new Font(Nfont, Bfont.Size, Bfont.Style);
            button8.Font = new Font(Nfont, Bfont.Size, Bfont.Style);
            button9.Font = new Font(Nfont, Bfont.Size, Bfont.Style);
            button10.Font = new Font(Nfont, Bfont.Size, Bfont.Style);
            Bfont = button11.Font;
            button11.Font = new Font(Nfont, Bfont.Size, Bfont.Style);
            button12.Font = new Font(Nfont, Bfont.Size, Bfont.Style);
            button20.Font = new Font(Nfont, Bfont.Size, Bfont.Style);
            Bfont = textBox1.Font;
            textBox1.Font = new Font(Nfont, Bfont.Size, Bfont.Style);
            textBox2.Font = new Font(Nfont, Bfont.Size, Bfont.Style);


            // 텍스트박스 컨트롤의 글꼴 속성을 설정합니다.

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
            if (Fieldbool1 == 0) 
            { button6.Visible = true; button6.Enabled = true; button6.Text = "필드 소환"; }
            else { button6.Enabled = false; button6.Text = "필드에 카드가 있습니다"; }
            if (Fieldbool2 == 0)
            { button7.Visible = true; button7.Enabled = true; button7.Text = "필드 소환"; }
            else { button7.Enabled = false; button7.Text = "필드에 카드가 있습니다"; }
            if (Fieldbool3 == 0)
            {button8.Visible = true; button8.Enabled = true; button8.Text = "필드 소환"; }
            else { button8.Enabled = false; button8.Text = "필드에 카드가 있습니다"; }
            if (Fieldbool4 == 0)
            {button9.Visible = true; button9.Enabled = true; button9.Text = "필드 소환"; }
            else { button9.Enabled = false; button9.Text = "필드에 카드가 있습니다"; }
            if (Fieldbool5 == 0)
            {button10.Visible = true; button10.Enabled = true; button10.Text = "필드 소환"; }
            else { button10.Enabled = false; button10.Text = "필드에 카드가 있습니다"; }
        }

        public void MagicSpell_AddCard()
        {
            if (Fieldbool1 == 1) { button6.Enabled = true; button6.Text = "사용 하기"; }
            else { button6.Visible = false; }
            if (Fieldbool2 == 1) { button7.Enabled = true; button7.Text = "사용 하기"; }
            else { button7.Visible = false; }
            if (Fieldbool3 == 1) { button8.Enabled = true; button8.Text = "사용 하기"; }
            else { button8.Visible = false; }
            if (Fieldbool4 == 1) { button9.Enabled = true; button9.Text = "사용 하기"; }
            else { button9.Visible = false; }
            if (Fieldbool5 == 1) { button10.Enabled = true; button10.Text = "사용 하기"; }
            else { button10.Visible = false; }
        }
        private void MyhandCardAdd_button(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                button20.Enabled = false; MyCardcodesetting();
                int mycard1 = Card_Number.Next(0, 10), mycard2 = Card_Number.Next(0, 10),
                    mycard3 = Card_Number.Next(0, 10), mycard4 = Card_Number.Next(0, 10),
                    mycard5 = Card_Number.Next(0, 10), CardChoice1 = Card_Number.Next(0, 9),
                    CardChoice2 = Card_Number.Next(0, 9), CardChoice3 = Card_Number.Next(0, 9),
                    CardChoice4 = Card_Number.Next(0, 9), CardChoice5 = Card_Number.Next(0, 9);
                for (int j = 0; j <= 9; j++)
                {
                    if (Handbool1 == 0 && CardDB[j].keycode == mycard1)
                    {
                        if (CardChoice1 <= 6)
                        {
                            button1.Image = CardDB[j].MonsterCardcode; Handbool1 = 1;
                            label1.Text = "" + CardDB[j].HP; label2.Text = "" + CardDB[j].ATK;
                            Mycardstatus[0].MyHP_status = CardDB[j].HP; Mycardstatus[0].MyATK_status = CardDB[j].ATK;
                        }
                        if(CardChoice1 >= 7)
                        {// 11 - 15 : 마법카드 체력, 공격력 1~5 고정시켜 출력하기
                            int MagicChoice1 = Magic_point.Next(0, 9), HPATK_up = Magic_point.Next(1, 6);
                            if(MagicChoice1 <= 4)
                            {// 11 - 20 마법카드 이미지를 1~5까지 범위를 지정해 알맞는 이미지를 가져옴
                                if(HPATK_up <= 2) { button1.Image = CardDB[HPATK_up].MagicCardcode_ATK; }
                                if (HPATK_up <= 4 && HPATK_up > 2) { button1.Image = CardDB[HPATK_up].MagicCardcode_ATK; }
                                if (HPATK_up == 5) { button1.Image = CardDB[HPATK_up].MagicCardcode_ATK; }
                                Handbool1 = 1; Magicbool1 = 1;
                                Magicstatus[0].Magic_status = CardDB[HPATK_up].MagicATK;
                                label1.Text = ""; label2.Text = "" + CardDB[HPATK_up].MagicATK;
                                Info_Card[0].Info_Hand += "\r\n공격력 증가 : " + CardDB[HPATK_up].MagicATK;
                            }
                            if(MagicChoice1 >= 5)
                            {
                                if (HPATK_up <= 2) { button1.Image = CardDB[HPATK_up].MagicCardcode_HP; }
                                if (HPATK_up <= 4 && HPATK_up > 2) { button1.Image = CardDB[HPATK_up].MagicCardcode_HP; }
                                if (HPATK_up == 5) { button1.Image = CardDB[HPATK_up].MagicCardcode_HP; }
                                Handbool1 = 1; Magicbool1 = 2;
                                Magicstatus[0].Magic_status = CardDB[HPATK_up].MagicHP;
                                label1.Text = ""; label2.Text = "" + CardDB[HPATK_up].MagicHP;
                                Info_Card[0].Info_Hand += "\r\n체력 증가 : " + CardDB[HPATK_up].MagicHP;
                            }
                            
                        }
                    }
                    if (Handbool2 == 0 && CardDB[j].keycode == mycard2)
                    {
                        if(CardChoice2 <= 6)
                        {
                            button2.Image = CardDB[j].MonsterCardcode; Handbool2 = 1;
                            label3.Text = "" + CardDB[j].HP; label4.Text = "" + CardDB[j].ATK;
                            Mycardstatus[1].MyHP_status = CardDB[j].HP; Mycardstatus[1].MyATK_status = CardDB[j].ATK;
                        }
                        if(CardChoice2 >= 7)
                        {
                            int MagicChoice2 = Magic_point.Next(0, 9), HPATK_up = Magic_point.Next(1, 5);
                            if(MagicChoice2 <= 4)
                            {
                                if (HPATK_up <= 2) { button2.Image = CardDB[HPATK_up].MagicCardcode_ATK; }
                                if (HPATK_up <= 4 && HPATK_up > 2) { button2.Image = CardDB[HPATK_up].MagicCardcode_ATK; }
                                if (HPATK_up == 5) { button2.Image = CardDB[HPATK_up].MagicCardcode_ATK; }
                                Handbool2 = 1; Magicbool2 = 1;
                                Magicstatus[1].Magic_status = CardDB[HPATK_up].MagicATK;
                                label3.Text = ""; label4.Text = "" + CardDB[HPATK_up].MagicATK;
                                Info_Card[1].Info_Hand += "\r\n공격력 증가 : " + CardDB[HPATK_up].MagicATK;
                            }
                            if(MagicChoice2 >= 5)
                            {
                                if (HPATK_up <= 2) { button2.Image = CardDB[HPATK_up].MagicCardcode_HP; }
                                if (HPATK_up <= 4 && HPATK_up > 2) { button2.Image = CardDB[HPATK_up].MagicCardcode_HP; }
                                if (HPATK_up == 5) { button2.Image = CardDB[HPATK_up].MagicCardcode_HP; }
                                Handbool2 = 1; Magicbool2 = 2;
                                Magicstatus[1].Magic_status = CardDB[HPATK_up].MagicHP;
                                label3.Text = "" ; label4.Text = "" + CardDB[HPATK_up].MagicHP;
                                Info_Card[1].Info_Hand += "\r\n체력 증가 : " + CardDB[HPATK_up].MagicHP;
                            }
                        }
                    }
                    if (Handbool3 == 0 && CardDB[j].keycode == mycard3)
                    {
                        if(CardChoice3 <= 6)
                        {
                            button3.Image = CardDB[j].MonsterCardcode; Handbool3 = 1;
                            label5.Text = "" + CardDB[j].HP; label6.Text = "" + CardDB[j].ATK;
                            Mycardstatus[2].MyHP_status = CardDB[j].HP; Mycardstatus[2].MyATK_status = CardDB[j].ATK;
                        }
                        if(CardChoice3 >= 7)
                        {
                            int MagicChoice3 = Magic_point.Next(0, 9), HPATK_up = Magic_point.Next(1, 5);
                            if (MagicChoice3 <= 4)
                            {
                                if (HPATK_up <= 2) { button3.Image = CardDB[HPATK_up].MagicCardcode_ATK; }
                                if (HPATK_up <= 4 && HPATK_up > 2) { button3.Image = CardDB[HPATK_up].MagicCardcode_ATK; }
                                if (HPATK_up == 5) { button3.Image = CardDB[HPATK_up].MagicCardcode_ATK; }
                                Handbool3 = 1; Magicbool3 = 1;
                                Magicstatus[2].Magic_status = CardDB[HPATK_up].MagicATK;
                                label5.Text = ""; label6.Text = "" + CardDB[HPATK_up].MagicATK;
                                Info_Card[2].Info_Hand += "\r\n공격력 증가 : " + CardDB[HPATK_up].MagicATK;
                            }
                            if(MagicChoice3 >= 5)
                            {
                                if (HPATK_up <= 2) { button3.Image = CardDB[HPATK_up].MagicCardcode_HP; }
                                if (HPATK_up <= 4 && HPATK_up > 2) { button3.Image = CardDB[HPATK_up].MagicCardcode_HP; }
                                if (HPATK_up == 5) { button3.Image = CardDB[HPATK_up].MagicCardcode_HP; }
                                Handbool3 = 1; Magicbool3 = 2;
                                Magicstatus[2].Magic_status = CardDB[HPATK_up].MagicHP;
                                label5.Text = ""; label6.Text = "" + CardDB[HPATK_up].MagicHP;
                                Info_Card[2].Info_Hand += "\r\n체력 증가 : " + CardDB[HPATK_up].MagicHP;
                            }
                        }
                    }
                    if (Handbool4 == 0 && CardDB[j].keycode == mycard4)
                    {
                        if (CardChoice4 <= 6)
                        {
                            button4.Image = CardDB[j].MonsterCardcode; Handbool4 = 1;
                            label7.Text = "" + CardDB[j].HP; label8.Text = "" + CardDB[j].ATK;
                            Mycardstatus[3].MyHP_status = CardDB[j].HP; Mycardstatus[3].MyATK_status = CardDB[j].ATK;
                        }
                        if(CardChoice4 >= 7)
                        {
                            int MagicChoice4 = Magic_point.Next(0, 9), HPATK_up = Magic_point.Next(1, 5);
                            if (MagicChoice4 <= 4)
                            {
                                if (HPATK_up <= 2) { button4.Image = CardDB[HPATK_up].MagicCardcode_ATK; }
                                if (HPATK_up <= 4 && HPATK_up > 2) { button4.Image = CardDB[HPATK_up].MagicCardcode_ATK; }
                                if (HPATK_up == 5) { button4.Image = CardDB[HPATK_up].MagicCardcode_ATK; }
                                Handbool4 = 1; Magicbool4 = 1;
                                Magicstatus[3].Magic_status = CardDB[HPATK_up].MagicATK;
                                label7.Text = ""; label8.Text = "" + CardDB[HPATK_up].MagicATK;
                                Info_Card[3].Info_Hand += "\r\n공격력 증가 : " + CardDB[HPATK_up].MagicATK;
                            }
                            if(MagicChoice4 >= 5)
                            {
                                if (HPATK_up <= 2) { button4.Image = CardDB[HPATK_up].MagicCardcode_HP; }
                                if (HPATK_up <= 4 && HPATK_up > 2) { button4.Image = CardDB[HPATK_up].MagicCardcode_HP; }
                                if (HPATK_up == 5) { button4.Image = CardDB[HPATK_up].MagicCardcode_HP; }
                                Handbool4 = 1; Magicbool4 = 2;
                                Magicstatus[3].Magic_status = CardDB[HPATK_up].MagicHP;
                                label7.Text = ""; label8.Text = "" + CardDB[HPATK_up].MagicHP;
                                Info_Card[3].Info_Hand += "\r\n체력 증가 : " + CardDB[HPATK_up].MagicHP;
                            }
                        }
                    }
                    if (Handbool5 == 0 && CardDB[j].keycode == mycard5)
                    {
                        if(CardChoice5 <= 6)
                        {
                            button5.Image = CardDB[j].MonsterCardcode; Handbool5 = 1;
                            label9.Text = "" + CardDB[j].HP; label10.Text = "" + CardDB[j].ATK;
                            Mycardstatus[4].MyHP_status = CardDB[j].HP; Mycardstatus[4].MyATK_status = CardDB[j].ATK;
                        }
                        if(CardChoice5 >= 7)
                        {
                            int MagicChoice5 = Magic_point.Next(0, 9), HPATK_up = Magic_point.Next(1, 5);
                            if (MagicChoice5 <= 4)
                            {
                                if (HPATK_up <= 2) { button5.Image = CardDB[HPATK_up].MagicCardcode_ATK; }
                                if (HPATK_up <= 4 && HPATK_up > 2) { button5.Image = CardDB[HPATK_up].MagicCardcode_ATK; }
                                if (HPATK_up == 5) { button5.Image = CardDB[HPATK_up].MagicCardcode_ATK; }
                                Handbool5 = 1; Magicbool5 = 1;
                                Magicstatus[4].Magic_status = CardDB[HPATK_up].MagicATK;
                                label9.Text = ""; label10.Text = "" + CardDB[HPATK_up].MagicATK;
                                Info_Card[4].Info_Hand += "\r\n공격력 증가 : " + CardDB[HPATK_up].MagicATK;
                            }
                            if(MagicChoice5 >= 5)
                            {
                                if (HPATK_up <= 2) { button5.Image = CardDB[HPATK_up].MagicCardcode_HP; }
                                if (HPATK_up <= 4 && HPATK_up > 2) { button5.Image = CardDB[HPATK_up].MagicCardcode_HP; }
                                if (HPATK_up == 5) { button5.Image = CardDB[HPATK_up].MagicCardcode_HP; }
                                Handbool5 = 1; Magicbool5 = 2;
                                Magicstatus[4].Magic_status = CardDB[HPATK_up].MagicHP;
                                label9.Text = ""; label10.Text = "" + CardDB[HPATK_up].MagicHP;
                                Info_Card[4].Info_Hand += "\r\n체력 증가 : " + CardDB[HPATK_up].MagicHP;
                            }
                        }
                    }
                }
                Card_FieldFull_Fieldnull(); buttonTrue_False();
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
                if (Fieldbool1 == 0) { button6.Visible = false; }
                if (Fieldbool2 == 0) { button7.Visible = false; }
                if (Fieldbool3 == 0) { button8.Visible = false; }
                if (Fieldbool4 == 0) { button9.Visible = false; }
                if (Fieldbool5 == 0) { button10.Visible = false; }
                if (DeleteCardcount > 0)
                {
                    textBox1.Text = "버릴 카드를 선택해주세요";
                    button1.Enabled = true; button2.Enabled = true; button3.Enabled = true;
                    button4.Enabled = true; button5.Enabled = true; button12.Visible = false;
                }
                else
                {
                    textBox1.Text = "현재 라운드에 카드버리기 횟수가 없습니다";
                    Card_FieldFull_Fieldnull(); buttonTrue_False(); button12.Visible = true;
                }
                if (button1.Image == NullCard && button2.Image == NullCard && button3.Image == NullCard &&
                    button4.Image == NullCard && button5.Image == NullCard && button6.Image == NullCard &&
                    pictureBox1.Image == NullCard && pictureBox2.Image == NullCard && pictureBox3.Image == NullCard &&
                    pictureBox4.Image == NullCard && pictureBox5.Image == NullCard)
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
        {// 11 - 21 : 사각형 그리기를 통해 필드 카드끼리 전투하는 구간을 나눔
        Rectangle[] FieldRectangle ={ new Rectangle(pictureBox1.Location.X - 2, pictureBox1.Location.Y - 2, 163, 225),
                       /* 1 */           new Rectangle(pictureBox2.Location.X - 2, pictureBox2.Location.Y - 2, 163, 225),
                       /* 2 */           new Rectangle(pictureBox3.Location.X - 2, pictureBox3.Location.Y - 2, 163, 225),
                       /* 3 */           new Rectangle(pictureBox4.Location.X - 2, pictureBox4.Location.Y - 2, 163, 225),
                       /* 4 */           new Rectangle(pictureBox5.Location.X - 2, pictureBox5.Location.Y - 2, 163, 225),
                       /* 5 */           new Rectangle(pictureBox6.Location.X - 2, pictureBox6.Location.Y - 2, 163, 225),
                       /* 6 */           new Rectangle(pictureBox7.Location.X - 2, pictureBox7.Location.Y - 2, 163, 225),
                       /* 7 */           new Rectangle(pictureBox8.Location.X - 2, pictureBox8.Location.Y - 2, 163, 225),
                       /* 8 */           new Rectangle(pictureBox9.Location.X - 2, pictureBox9.Location.Y - 2, 163, 225),
                       /* 9 */           new Rectangle(pictureBox10.Location.X - 2, pictureBox10.Location.Y - 2, 163, 225),};
            DeleteCardcount = 3; BattleRectangle = 2; BattlePhase = 1;
            button12.Text = "카드 버리기\r\n3/3"; textBox1.Text = "상대가 필드에 카드를 배치합니다\r\n";
            if (e.Button == MouseButtons.Left && button11.Visible == true)
            {
                Graphics g = CreateGraphics(); 
                Pen penblack = new Pen(Color.Black, 10); Pen penWhite = new Pen(Color.DarkViolet, 10);
                Pen penRed = new Pen(Color.Red, 10); Pen penGreen = new Pen(Color.LightGreen, 10);
                button11.Visible = false; button20.Visible = false; button12.Visible = false;
                button6.Visible = false; button7.Visible = false; button8.Visible = false;
                button9.Visible = false; button10.Visible = false;
                button1.Visible = false; button2.Visible = false; button3.Visible = false;
                button4.Visible = false; button5.Visible = false;
                AiCardcodesetting();
                for (int j = 0; j <= 9; j++)
                {
                    if (AiFieldbool1 == 0)
                    {
                        if (CardDB[j].Aikeycode == Card_Number.Next(0, 9))
                        {
                            pictureBox6.Image = CardDB[j].AiMonsterCardcode; AiFieldbool1 = 1;
                            label21.Text = "" + CardDB[j].AiHP; label22.Text = "" + CardDB[j].AiATK;
                            Aicardstatus[0].AiHP_status = CardDB[j].AiHP; Aicardstatus[0].AiATK_status = CardDB[j].AiATK;
                        }
                    }
                    if (AiFieldbool2 == 0)
                    {
                        if (CardDB[j].Aikeycode == Card_Number.Next(0, 9))
                        {
                            pictureBox7.Image = CardDB[j].AiMonsterCardcode; AiFieldbool2 = 1;
                            label23.Text = "" + CardDB[j].AiHP; label24.Text = "" + CardDB[j].AiATK;
                            Aicardstatus[1].AiHP_status = CardDB[j].AiHP; Aicardstatus[1].AiATK_status = CardDB[j].AiATK;
                        }
                    }
                    if (AiFieldbool3 == 0)
                    {
                        if (CardDB[j].Aikeycode == Card_Number.Next(0, 9))
                        {
                            pictureBox8.Image = CardDB[j].AiMonsterCardcode; AiFieldbool3 = 1;
                            label25.Text = "" + CardDB[j].AiHP; label26.Text = "" + CardDB[j].AiATK;
                            Aicardstatus[2].AiHP_status = CardDB[j].AiHP; Aicardstatus[2].AiATK_status = CardDB[j].AiATK;
                        }
                    }
                    if (AiFieldbool4 == 0)
                    {
                        if (CardDB[j].Aikeycode == Card_Number.Next(0, 9))
                        {
                            pictureBox9.Image = CardDB[j].AiMonsterCardcode; AiFieldbool4 = 1;
                            label27.Text = "" + CardDB[j].AiHP; label28.Text = "" + CardDB[j].AiATK;
                            Aicardstatus[3].AiHP_status = CardDB[j].AiHP; Aicardstatus[3].AiATK_status = CardDB[j].AiATK;
                        }
                    }
                    if (AiFieldbool5 == 0)
                    {
                        if (CardDB[j].Aikeycode == Card_Number.Next(0, 9))
                        {
                            pictureBox10.Image = CardDB[j].AiMonsterCardcode; AiFieldbool5 = 1;
                            label29.Text = "" + CardDB[j].AiHP; label30.Text = "" + CardDB[j].AiATK;
                            Aicardstatus[4].AiHP_status = CardDB[j].AiHP; Aicardstatus[4].AiATK_status = CardDB[j].AiATK;
                        }
                    }
                }
                Delay(1000);
                for(int i = 0; i <= 5; i++)
                {
                    textBox1.Text += "."; Delay(500);
                }
                textBox1.Text += "\r\n카드 배치가 끝났습니다!"; Delay(2000);
                textBox1.Text = ""; textBox1.Text += "전투 시작!\r\n"; Delay(1500);
                BattleRectangle = 1; if (BattleRectangle == 1)
                { g.DrawRectangle(penblack, FieldRectangle[0]); g.DrawRectangle(penblack, FieldRectangle[5]); Delay(700); }
                if (Fieldbool1 == 0 && AiFieldbool1 == 1)
                {
                    g.DrawRectangle(penRed, FieldRectangle[0]); g.DrawRectangle(penGreen, FieldRectangle[5]); Delay(700);
                    MyHp -= Aicardstatus[0].AiATK_status; label31.Text = "MyHP : " + MyHp;
                    textBox1.Text += "\r\n첫번째 칸 적몬스터 -> 내생명" + Aicardstatus[0].AiATK_status + "피해\r\n";
                }
                if (AiFieldbool1 == 0 && Fieldbool1 == 1)
                {
                    g.DrawRectangle(penGreen, FieldRectangle[0]); g.DrawRectangle(penRed, FieldRectangle[5]); Delay(700);
                    AiHp -= MyField_status[0].FieldATK_status; label32.Text = "AiHP : " + AiHp;
                    textBox1.Text += "\r\n첫번째 칸 내몬스터 -> 적생명 " + MyField_status[0].FieldATK_status + "피해\r\n";
                }
                if (Fieldbool1 == 1 && AiFieldbool1 == 1)
                {// 11 - 22 체력과 공격력을 비교하여 공격력이 높을경우 와 같거나 낮을경우를 나누어서 데미지 반감을 구현
                    int HPATK_Check1 = 0;
                    if (Aicardstatus[0].AiATK_status > MyField_status[0].FieldHP_status)
                    {
                        g.DrawRectangle(penRed, FieldRectangle[0]); g.DrawRectangle(penGreen, FieldRectangle[5]); Delay(700);
                        MyField_status[0].FieldHP_status -= Aicardstatus[0].AiATK_status;
                        Aicardstatus[0].AiHP_status -= MyField_status[0].FieldATK_status / 2;
                        textBox1.Text += "\r\nAi의 공격력이 높습니다!"; HPATK_Check1 = 1;
                        textBox1.Text += "\r\n첫번째 칸 적몬스터 -> 내몬스터 " + Aicardstatus[0].AiATK_status + "피해";
                        textBox1.Text += "\r\n첫번째 칸 내몬스터 -> 적몬스터 " + MyField_status[0].FieldATK_status / 2 + "피해\r\n";
                    }
                    else if (MyField_status[0].FieldATK_status > Aicardstatus[0].AiHP_status)
                    {
                        g.DrawRectangle(penGreen, FieldRectangle[0]); g.DrawRectangle(penRed, FieldRectangle[5]); Delay(700);
                        MyField_status[0].FieldHP_status -= Aicardstatus[0].AiATK_status / 2;
                        Aicardstatus[0].AiHP_status -= MyField_status[0].FieldATK_status;
                        textBox1.Text += "\r\n나의 공격력이 높습니다!"; HPATK_Check1 = 1;
                        textBox1.Text += "\r\n첫번째 칸 적몬스터 -> 내몬스터 " + Aicardstatus[0].AiATK_status / 2 + "피해";
                        textBox1.Text += "\r\n첫번째 칸 내몬스터 -> 적몬스터 " + MyField_status[0].FieldATK_status + "피해\r\n";
                    }
                    if (HPATK_Check1 == 0)
                    {
                        MyField_status[0].FieldHP_status -= Aicardstatus[0].AiATK_status;
                        Aicardstatus[0].AiHP_status -= MyField_status[0].FieldATK_status;
                        textBox1.Text += "\r\n첫번째 칸 적몬스터 -> 내몬스터 " + Aicardstatus[0].AiATK_status + "피해";
                        textBox1.Text += "\r\n첫번째 칸 내몬스터 -> 적몬스터 " + MyField_status[0].FieldATK_status + "피해\r\n";
                    }
                    label11.Text = "" + MyField_status[0].FieldHP_status;
                    label21.Text = "" + Aicardstatus[0].AiHP_status;
                    if (MyField_status[0].FieldHP_status <= 0)
                    {
                        pictureBox1.Image = NullCard; Info_Card[0].Info_Field = ""; Fieldbool1 = 0;
                        label11.Text = ""; label12.Text = ""; button6.Text = "필드 소환"; button6.Enabled = true;
                    }
                    if (Aicardstatus[0].AiHP_status <= 0)
                    { 
                        pictureBox6.Image = NullCard; AiFieldbool1 = 0;
                        label21.Text = ""; label22.Text = ""; 
                    }
                    Delay(700); HPATK_Check1 = 0;
                }
                BattleRectangle = 2; if (BattleRectangle == 2)
                {
                    g.DrawRectangle(penWhite, FieldRectangle[0]); g.DrawRectangle(penWhite, FieldRectangle[5]);
                    g.DrawRectangle(penblack, FieldRectangle[1]); g.DrawRectangle(penblack, FieldRectangle[6]); Delay(700);
                }
                if (Fieldbool2 == 0 && AiFieldbool2 == 1)
                {
                    g.DrawRectangle(penRed, FieldRectangle[1]); g.DrawRectangle(penGreen, FieldRectangle[6]); Delay(700);
                    MyHp -= Aicardstatus[1].AiATK_status; label31.Text = "MyHP : " + MyHp;
                    textBox1.Text += "\r\n두번째 칸 적몬스터 -> 내생명 " + Aicardstatus[1].AiATK_status + "피해\r\n";
                }
                if (AiFieldbool2 == 0 && Fieldbool2 == 1)
                {
                    g.DrawRectangle(penGreen, FieldRectangle[1]); g.DrawRectangle(penRed, FieldRectangle[6]); Delay(700);
                    AiHp -= MyField_status[1].FieldATK_status; label32.Text = "AiHP : " + AiHp;
                    textBox1.Text += "\r\n두번째 칸 내몬스터 -> 적생명 " + MyField_status[1].FieldATK_status + "피해\r\n";
                }
                if (Fieldbool2 == 1 && AiFieldbool2 == 1)
                {
                    int HPATK_Check2 = 0;
                    if (Aicardstatus[1].AiATK_status > MyField_status[1].FieldHP_status)
                    {
                        g.DrawRectangle(penRed, FieldRectangle[1]); g.DrawRectangle(penGreen, FieldRectangle[6]); Delay(700);
                        MyField_status[1].FieldHP_status -= Aicardstatus[1].AiATK_status;
                        Aicardstatus[1].AiHP_status -= MyField_status[1].FieldATK_status / 2;
                        textBox1.Text += "\r\nAi의 공격력이 높습니다!"; HPATK_Check2 = 1;
                        textBox1.Text += "\r\n두번째 칸 적몬스터 -> 내몬스터 " + Aicardstatus[1].AiATK_status + "피해";
                        textBox1.Text += "\r\n두번째 칸 내몬스터 -> 적몬스터 " + MyField_status[1].FieldATK_status / 2 + "피해\r\n";
                    }
                    else if (MyField_status[1].FieldATK_status > Aicardstatus[1].AiATK_status)
                    {
                        g.DrawRectangle(penGreen, FieldRectangle[1]); g.DrawRectangle(penRed, FieldRectangle[6]); Delay(700);
                        MyField_status[1].FieldHP_status -= Aicardstatus[1].AiATK_status / 2;
                        Aicardstatus[1].AiHP_status -= MyField_status[1].FieldATK_status;
                        textBox1.Text += "\r\n나의 공격력이 높습니다!"; HPATK_Check2 = 1;
                        textBox1.Text += "\r\n두번째 칸 적몬스터 -> 내몬스터 " + Aicardstatus[1].AiATK_status / 2 + "피해";
                        textBox1.Text += "\r\n두번째 칸 내몬스터 -> 적몬스터 " + MyField_status[1].FieldATK_status + "피해\r\n";
                    }
                    if(HPATK_Check2 == 0)
                    {
                        MyField_status[1].FieldHP_status -= Aicardstatus[1].AiATK_status;
                        Aicardstatus[1].AiHP_status -= MyField_status[1].FieldATK_status;
                        textBox1.Text += "\r\n두번째 칸 적몬스터 -> 내몬스터 " + Aicardstatus[1].AiATK_status + "피해";
                        textBox1.Text += "\r\n두번째 칸 내몬스터 -> 적몬스터 " + MyField_status[1].FieldATK_status + "피해\r\n";
                    }
                    label13.Text = "" + MyField_status[1].FieldHP_status;
                    label23.Text = "" + Aicardstatus[1].AiHP_status;
                    if (MyField_status[1].FieldHP_status <= 0)
                    {
                        pictureBox2.Image = NullCard; Info_Card[1].Info_Field = ""; Fieldbool2 = 0;
                        label13.Text = ""; label14.Text = ""; button7.Text = "필드 소환"; button7.Enabled = true;
                    }
                    if (Aicardstatus[1].AiHP_status <= 0)
                    { 
                        pictureBox7.Image = NullCard; AiFieldbool2 = 0;
                        label23.Text = ""; label24.Text = "";
                    }
                    Delay(700); HPATK_Check2 = 0;
                }
                BattleRectangle = 3; if (BattleRectangle == 3)
                {
                    g.DrawRectangle(penWhite, FieldRectangle[1]); g.DrawRectangle(penWhite, FieldRectangle[6]);
                    g.DrawRectangle(penblack, FieldRectangle[2]); g.DrawRectangle(penblack, FieldRectangle[7]); Delay(700);
                }
                if (Fieldbool3 == 0 && AiFieldbool3 == 1)
                {
                    g.DrawRectangle(penRed, FieldRectangle[2]); g.DrawRectangle(penGreen, FieldRectangle[7]); Delay(700);
                    MyHp -= Aicardstatus[2].AiATK_status; label31.Text = "MyHP : " + MyHp;
                    textBox1.Text += "\r\n세번째 칸 적몬스터 -> 내생명 " + Aicardstatus[2].AiATK_status + "피해\r\n";
                }
                if (AiFieldbool3 == 0 && Fieldbool3 == 1)
                {
                    g.DrawRectangle(penGreen, FieldRectangle[2]); g.DrawRectangle(penRed, FieldRectangle[7]); Delay(700);
                    AiHp -= MyField_status[2].FieldATK_status; label32.Text = "AiHP : " + AiHp;
                    textBox1.Text += "\r\n세번째 칸 내몬스터 -> 적생명 " + MyField_status[2].FieldATK_status + "피해\r\n";
                }
                if (Fieldbool3 == 1 && AiFieldbool3 == 1)
                {
                    int HPATK_Check3 = 0;
                    if (Aicardstatus[2].AiATK_status > MyField_status[2].FieldHP_status)
                    {
                        g.DrawRectangle(penRed, FieldRectangle[2]); g.DrawRectangle(penGreen, FieldRectangle[7]); Delay(700);
                        MyField_status[2].FieldHP_status -= Aicardstatus[2].AiATK_status;
                        Aicardstatus[2].AiHP_status -= MyField_status[2].FieldATK_status / 2;
                        textBox1.Text += "\r\nAi의 공격력이 높습니다!"; HPATK_Check3 = 1;
                        textBox1.Text += "\r\n세번째 칸 적몬스터 -> 내몬스터 " + Aicardstatus[2].AiATK_status + "피해";
                        textBox1.Text += "\r\n세번째 칸 내몬스터 -> 적몬스터 " + MyField_status[2].FieldATK_status / 2 + "피해\r\n";
                    }
                    else if (MyField_status[2].FieldATK_status > Aicardstatus[2].AiATK_status)
                    {
                        g.DrawRectangle(penGreen, FieldRectangle[2]); g.DrawRectangle(penRed, FieldRectangle[7]); Delay(700);
                        MyField_status[2].FieldHP_status -= Aicardstatus[2].AiATK_status / 2;
                        Aicardstatus[2].AiHP_status -= MyField_status[2].FieldATK_status;
                        textBox1.Text += "\r\n나의 공격력이 높습니다!"; HPATK_Check3 = 1;
                        textBox1.Text += "\r\n세번째 칸 적몬스터 -> 내몬스터 " + Aicardstatus[2].AiATK_status / 2 + "피해";
                        textBox1.Text += "\r\n세번째 칸 내몬스터 -> 적몬스터 " + MyField_status[2].FieldATK_status + "피해\r\n";
                    }
                    if(HPATK_Check3 == 0)
                    {
                        MyField_status[2].FieldHP_status -= Aicardstatus[2].AiATK_status;
                        Aicardstatus[2].AiHP_status -= MyField_status[2].FieldATK_status;
                        textBox1.Text += "\r\n세번째 칸 적몬스터 -> 내몬스터 " + Aicardstatus[2].AiATK_status + "피해";
                        textBox1.Text += "\r\n세번째 칸 내몬스터 -> 적몬스터 " + MyField_status[2].FieldATK_status + "피해\r\n";
                    }
                    label15.Text = "" + MyField_status[2].FieldHP_status;
                    label25.Text = "" + Aicardstatus[2].AiHP_status;
                    if (MyField_status[2].FieldHP_status <= 0)
                    {
                        pictureBox3.Image = NullCard; Info_Card[2].Info_Field = ""; Fieldbool3 = 0;
                        label15.Text = ""; label16.Text = ""; button8.Text = "필드 소환"; button8.Enabled = true;
                    }
                    if (Aicardstatus[2].AiHP_status <= 0)
                    { 
                        pictureBox8.Image = NullCard; AiFieldbool3 = 0;
                        label25.Text = ""; label26.Text = ""; 
                    }
                    Delay(700); HPATK_Check3 = 0;
                }
                BattleRectangle = 4; if (BattleRectangle == 4)
                {
                    g.DrawRectangle(penWhite, FieldRectangle[2]); g.DrawRectangle(penWhite, FieldRectangle[7]);
                    g.DrawRectangle(penblack, FieldRectangle[3]); g.DrawRectangle(penblack, FieldRectangle[8]); Delay(700);
                }
                if (Fieldbool4 == 0 && AiFieldbool4 == 1)
                {
                    g.DrawRectangle(penRed, FieldRectangle[3]); g.DrawRectangle(penGreen, FieldRectangle[8]); Delay(700);
                    MyHp -= Aicardstatus[3].AiATK_status; label31.Text = "MyHP : " + MyHp;
                    textBox1.Text += "\r\n네번째 칸 적몬스터 -> 내생명 " + Aicardstatus[3].AiATK_status + "피해\r\n";
                }
                if (AiFieldbool4 == 0 && Fieldbool4 == 1)
                {
                    g.DrawRectangle(penGreen, FieldRectangle[3]); g.DrawRectangle(penRed, FieldRectangle[8]); Delay(700);
                    AiHp -= MyField_status[3].FieldATK_status; label32.Text = "AiHP : " + AiHp;
                    textBox1.Text += "\r\n네번째 칸 내몬스터 -> 적생명 " + MyField_status[3].FieldATK_status + "피해\r\n";
                }
                if (Fieldbool4 == 1 && AiFieldbool4 == 1)
                {
                    int HPATK_Check4 = 0;
                    if (Aicardstatus[3].AiATK_status > MyField_status[3].FieldHP_status)
                    {
                        g.DrawRectangle(penRed, FieldRectangle[3]); g.DrawRectangle(penGreen, FieldRectangle[8]); Delay(700);
                        MyField_status[3].FieldHP_status -= Aicardstatus[3].AiATK_status;
                        Aicardstatus[3].AiHP_status -= MyField_status[3].FieldATK_status / 2;
                        textBox1.Text += "\r\nAi의 공격력이 높습니다!"; HPATK_Check4 = 1;
                        textBox1.Text += "\r\n네번째 칸 적몬스터 -> 내몬스터 " + Aicardstatus[3].AiATK_status + "피해";
                        textBox1.Text += "\r\n네번째 칸 내몬스터 -> 적몬스터 " + MyField_status[3].FieldATK_status / 2 + "피해\r\n";
                    }
                    else if (MyField_status[3].FieldATK_status > Aicardstatus[3].AiHP_status)
                    {
                        g.DrawRectangle(penGreen, FieldRectangle[3]); g.DrawRectangle(penRed, FieldRectangle[8]); Delay(700);
                        MyField_status[3].FieldHP_status -= Aicardstatus[3].AiATK_status / 2;
                        Aicardstatus[3].AiHP_status -= MyField_status[3].FieldATK_status;
                        textBox1.Text += "\r\n나의 공격력이 높습니다!"; HPATK_Check4 = 1;
                        textBox1.Text += "\r\n네번째 칸 적몬스터 -> 내몬스터 " + Aicardstatus[3].AiATK_status / 2 + "피해";
                        textBox1.Text += "\r\n네번째 칸 내몬스터 -> 적몬스터 " + MyField_status[3].FieldATK_status + "피해\r\n";
                    }
                    if (HPATK_Check4 == 0)
                    {
                        MyField_status[3].FieldHP_status -= Aicardstatus[3].AiATK_status;
                        Aicardstatus[3].AiHP_status -= MyField_status[3].FieldATK_status;
                        textBox1.Text += "\r\n네번째 칸 적몬스터 -> 내몬스터 " + Aicardstatus[3].AiATK_status + "피해";
                        textBox1.Text += "\r\n네번째 칸 내몬스터 -> 적몬스터 " + MyField_status[3].FieldATK_status + "피해\r\n";
                    }
                    label17.Text = "" + MyField_status[3].FieldHP_status;
                    label27.Text = "" + Aicardstatus[3].AiHP_status;
                    if (MyField_status[3].FieldHP_status <= 0)
                    {
                        pictureBox4.Image = NullCard; Info_Card[3].Info_Field = ""; Fieldbool4 = 0;
                        label17.Text = ""; label18.Text = ""; button9.Text = "필드 소환"; button9.Enabled = true;
                    }
                    if (Aicardstatus[3].AiHP_status <= 0)
                    { 
                        pictureBox9.Image = NullCard; AiFieldbool4 = 0;
                        label27.Text = ""; label28.Text = ""; 
                    }
                    Delay(700); HPATK_Check4 = 0;
                }
                BattleRectangle = 5; if (BattleRectangle == 5)
                {
                    g.DrawRectangle(penWhite, FieldRectangle[3]); g.DrawRectangle(penWhite, FieldRectangle[8]);
                    g.DrawRectangle(penblack, FieldRectangle[4]); g.DrawRectangle(penblack, FieldRectangle[9]); Delay(700);
                }
                if (Fieldbool5 == 0 && AiFieldbool5 == 1)
                {
                    g.DrawRectangle(penRed, FieldRectangle[4]); g.DrawRectangle(penGreen, FieldRectangle[9]); Delay(700);
                    MyHp -= Aicardstatus[4].AiATK_status; label31.Text = "MyHP : " + MyHp;
                    textBox1.Text += "\r\n다섯번째 칸 적몬스터 -> 내생명 " + Aicardstatus[4].AiATK_status + "피해\r\n";
                }
                if (AiFieldbool5 == 0 && Fieldbool5 == 1)
                {
                    g.DrawRectangle(penGreen, FieldRectangle[4]); g.DrawRectangle(penRed, FieldRectangle[9]); Delay(700);
                    AiHp -= MyField_status[4].FieldATK_status; label32.Text = "AiHP : " + AiHp;
                    textBox1.Text += "\r\n다섯번째 칸 내몬스터 -> 적생명 " + MyField_status[4].FieldATK_status + "피해\r\n";
                }
                if (Fieldbool5 == 1 && AiFieldbool5 == 1)
                {
                    int HPATK_Check5 = 0;
                    if (Aicardstatus[4].AiATK_status > MyField_status[4].FieldHP_status)
                    {
                        g.DrawRectangle(penRed, FieldRectangle[4]); g.DrawRectangle(penGreen, FieldRectangle[9]); Delay(700);
                        MyField_status[4].FieldHP_status -= Aicardstatus[4].AiATK_status;
                        Aicardstatus[4].AiHP_status -= MyField_status[4].FieldATK_status / 2;
                        textBox1.Text += "\r\nAi의 공격력이 높습니다!"; HPATK_Check5 = 1;
                        textBox1.Text += "\r\n다섯번째 칸 적몬스터 -> 내몬스터 " + Aicardstatus[4].AiATK_status + "피해";
                        textBox1.Text += "\r\n다섯번째 칸 내몬스터 -> 적몬스터 " + MyField_status[4].FieldATK_status / 2 + "피해\r\n";
                    }
                    if (MyField_status[4].FieldATK_status > Aicardstatus[4].AiATK_status)
                    {
                        g.DrawRectangle(penGreen, FieldRectangle[4]); g.DrawRectangle(penRed, FieldRectangle[9]); Delay(700);
                        MyField_status[4].FieldHP_status -= Aicardstatus[4].AiATK_status / 2;
                        Aicardstatus[4].AiHP_status -= MyField_status[4].FieldATK_status;
                        textBox1.Text += "\r\n나의 공격력이 높습니다!"; HPATK_Check5 = 1;
                        textBox1.Text += "\r\n다섯번째 칸 적몬스터 -> 내몬스터 " + Aicardstatus[4].AiATK_status / 2 + "피해";
                        textBox1.Text += "\r\n다섯번째 칸 내몬스터 -> 적몬스터 " + MyField_status[4].FieldATK_status + "피해\r\n";
                    }
                    if(HPATK_Check5 == 0)
                    {
                        MyField_status[4].FieldHP_status -= Aicardstatus[4].AiATK_status;
                        Aicardstatus[4].AiHP_status -= MyField_status[4].FieldATK_status;
                        textBox1.Text += "\r\n다섯번째 칸 적몬스터 -> 내몬스터 " + Aicardstatus[4].AiATK_status + "피해";
                        textBox1.Text += "\r\n다섯번째 칸 내몬스터 -> 적몬스터 " + MyField_status[4].FieldATK_status + "피해\r\n";
                    }
                    label19.Text = "" + MyField_status[4].FieldHP_status;
                    label29.Text = "" + Aicardstatus[4].AiHP_status;
                    if (MyField_status[4].FieldHP_status <= 0)
                    {
                        pictureBox5.Image = NullCard; Info_Card[4].Info_Field = ""; Fieldbool5 = 0;
                        label19.Text = ""; label20.Text = ""; button10.Text = "필드 소환"; button10.Enabled = true;
                    }
                    if (Aicardstatus[4].AiHP_status <= 0)
                    { 
                        pictureBox10.Image = NullCard; AiFieldbool5 = 0; 
                        label29.Text = ""; label30.Text = ""; 
                    }
                    Delay(700); HPATK_Check5 = 0;
                }
                this.Invalidate(); Delay(1000);
                textBox1.Text += "\r\n전투 종료!"; BattleRectangle = 0; BattlePhase = 0;
                button6.Visible = true; button7.Visible = true; button8.Visible = true;
                button9.Visible = true; button10.Visible = true; button20.Enabled = true;
                button11.Visible = true; button12.Visible = true; button20.Visible = true;
                button1.Visible = true; button2.Visible = true; button3.Visible = true;
                button4.Visible = true; button5.Visible = true;
                if (MyHp <= 0)
                { MessageBox.Show("플레이어가 졌습니다!"); this.Close(); }
                else if(AiHp <= 0)
                { MessageBox.Show("인공지능이 졌습니다!"); this.Close(); }
            }
        }
        private void CardAdd1_button(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (button1.Enabled == false && Magicbool1 == 0)
                {
                    pictureBox1.Image = button1.Image; Handbool1 = 0; Fieldbool1 = 1;
                    label11.Text = label1.Text; label12.Text = label2.Text;
                    MyField_status[0].FieldHP_status = Mycardstatus[0].MyHP_status;
                    MyField_status[0].FieldATK_status = Mycardstatus[0].MyATK_status;
                    Info_Card[0].Info_Field = Info_Card[0].Info_Hand;
                    button1.Image = NullCard; 
                    label1.Text = ""; label2.Text = "";
                    button6.Text = "필드에 카드가 있습니다"; 
                }
                if (button2.Enabled == false && Magicbool2 == 0)
                {
                    pictureBox1.Image = button2.Image; Handbool2 = 0; Fieldbool1 = 1;
                    label11.Text = label3.Text; label12.Text = label4.Text;
                    MyField_status[0].FieldHP_status = Mycardstatus[1].MyHP_status;
                    MyField_status[0].FieldATK_status = Mycardstatus[1].MyATK_status;
                    Info_Card[0].Info_Field = Info_Card[1].Info_Hand;
                    button2.Image = NullCard; 
                    label3.Text = ""; label4.Text = "";
                    button6.Text = "필드에 카드가 있습니다"; 
                }
                if (button3.Enabled == false && Magicbool3 == 0)
                {
                    pictureBox1.Image = button3.Image; Handbool3 = 0; Fieldbool1 = 1;
                    label11.Text = label5.Text; label12.Text = label6.Text;
                    MyField_status[0].FieldHP_status = Mycardstatus[2].MyHP_status;
                    MyField_status[0].FieldATK_status = Mycardstatus[2].MyATK_status;
                    Info_Card[0].Info_Field = Info_Card[2].Info_Hand;
                    button3.Image = NullCard;
                    label5.Text = ""; label6.Text = "";
                    button6.Text = "필드에 카드가 있습니다";
                }
                if (button4.Enabled == false && Magicbool4 == 0)
                {
                    pictureBox1.Image = button4.Image; Handbool4 = 0; Fieldbool1 = 1;
                    label11.Text = label7.Text; label12.Text = label8.Text;
                    MyField_status[0].FieldHP_status = Mycardstatus[3].MyHP_status;
                    MyField_status[0].FieldATK_status = Mycardstatus[3].MyATK_status;
                    Info_Card[0].Info_Field = Info_Card[3].Info_Hand;
                    button4.Image = NullCard;
                    label7.Text = ""; label8.Text = "";
                    button6.Text = "필드에 카드가 있습니다";
                }
                if (button5.Enabled == false && Magicbool5 == 0)
                {
                    pictureBox1.Image = button5.Image; Handbool5 = 0; Fieldbool1 = 1;
                    label11.Text = label9.Text; label12.Text = label10.Text;
                    MyField_status[0].FieldHP_status = Mycardstatus[4].MyHP_status;
                    MyField_status[0].FieldATK_status = Mycardstatus[4].MyATK_status;
                    Info_Card[0].Info_Field = Info_Card[4].Info_Hand;
                    button5.Image = NullCard;
                    label9.Text = ""; label10.Text = "";
                    button6.Text = "필드에 카드가 있습니다";
                }

                if(button1.Enabled == false && Magicbool1 > 0)
                {
                    if (Magicbool1 == 1)
                    {
                        MyField_status[0].FieldATK_status += Magicstatus[0].Magic_status;
                        label12.Text = "" + MyField_status[0].FieldATK_status;
                        textBox1.Text = "첫번째 필드 카드에 공격력 " + Magicstatus[0].Magic_status + "를 더한다";
                        Info_Card[0].Info_Field += "\r\n마법 카드 : 공격력 " + Magicstatus[0].Magic_status + "증가";
                    }
                    if (Magicbool1 == 2)
                    {
                        MyField_status[0].FieldHP_status += Magicstatus[0].Magic_status;
                        label11.Text = "" + MyField_status[0].FieldHP_status;
                        textBox1.Text = "첫번째 필드 카드에 체력 " + Magicstatus[0].Magic_status + "를 더한다";
                        Info_Card[0].Info_Field += "\r\n마법 카드 : 체력 " + Magicstatus[0].Magic_status + "증가";
                    }
                    pictureBox11.Image = NullCard; Handbool1 = 0; Magicbool1 = 0;
                    textBox2.Text = ""; Info_Card[0].Info_Hand = ""; button1.Image = NullCard; 
                    label1.Text = ""; label2.Text = ""; label33.Text = ""; label34.Text = "";
                }
                if(button2.Enabled == false && Magicbool2 > 0)
                {
                    if (Magicbool2 == 1)
                    {
                        MyField_status[0].FieldATK_status += Magicstatus[1].Magic_status;
                        label12.Text = "" + MyField_status[0].FieldATK_status;
                        textBox1.Text = "첫번째 필드 카드에 공격력 " + Magicstatus[1].Magic_status + "를 더한다";
                        Info_Card[0].Info_Field += "\r\n마법 카드 : 공격력 " + Magicstatus[1].Magic_status + "증가";
                    }
                    if (Magicbool2 == 2)
                    {
                        MyField_status[0].FieldHP_status += Magicstatus[1].Magic_status;
                        label11.Text = "" + MyField_status[0].FieldHP_status;
                        textBox1.Text = "첫번째 필드 카드에 체력 " + Magicstatus[1].Magic_status + "를 더한다";
                        Info_Card[0].Info_Field += "\r\n마법 카드 : 체력 " + Magicstatus[1].Magic_status + "증가";
                    }
                    pictureBox11.Image = NullCard; Handbool2 = 0; Magicbool2 = 0;
                    textBox2.Text = ""; Info_Card[1].Info_Hand = ""; button2.Image = NullCard; 
                    label3.Text = ""; label4.Text = ""; label33.Text = ""; label34.Text = "";
                }
                if(button3.Enabled == false && Magicbool3 > 0)
                {
                    if (Magicbool3 == 1)
                    {
                        MyField_status[0].FieldATK_status += Magicstatus[2].Magic_status;
                        label12.Text = "" + MyField_status[0].FieldATK_status;
                        textBox1.Text = "첫번째 필드 카드에 공격력 " + Magicstatus[2].Magic_status + "를 더한다";
                        Info_Card[0].Info_Field += "\r\n마법 카드 : 공격력 " + Magicstatus[2].Magic_status + "증가";
                    }
                    if (Magicbool3 == 2)
                    {
                        MyField_status[0].FieldHP_status += Magicstatus[2].Magic_status;
                        label11.Text = "" + MyField_status[0].FieldHP_status;
                        textBox1.Text = "첫번째 필드 카드에 체력 " + Magicstatus[2].Magic_status + "를 더한다";
                        Info_Card[0].Info_Field += "\r\n마법 카드 : 체력 " + Magicstatus[2].Magic_status + "증가";
                    }
                    pictureBox11.Image = NullCard; Handbool3 = 0; Magicbool3 = 0;
                    textBox2.Text = ""; Info_Card[2].Info_Hand = ""; button3.Image = NullCard;
                    label5.Text = ""; label6.Text = ""; label33.Text = ""; label34.Text = "";
                }
                if(button4.Enabled == false && Magicbool4 > 0)
                {
                    if (Magicbool4 == 1)
                    {
                        MyField_status[0].FieldATK_status += Magicstatus[3].Magic_status;
                        label12.Text = "" + MyField_status[0].FieldATK_status;
                        textBox1.Text = "첫번째 필드 카드에 공격력 " + Magicstatus[3].Magic_status + "를 더한다";
                        Info_Card[0].Info_Field += "\r\n마법 카드 : 공격력 " + Magicstatus[3].Magic_status + "증가";
                    }
                    if (Magicbool4 == 2)
                    {
                        MyField_status[0].FieldHP_status += Magicstatus[3].Magic_status;
                        label11.Text = "" + MyField_status[0].FieldHP_status;
                        textBox1.Text = "첫번째 필드 카드에 체력 " + Magicstatus[3].Magic_status + "를 더한다";
                        Info_Card[0].Info_Field += "\r\n마법 카드 : 체력 " + Magicstatus[3].Magic_status + "증가";
                    }
                    pictureBox11.Image = NullCard; Handbool4 = 0; Magicbool4 = 0;
                    textBox2.Text = ""; Info_Card[3].Info_Hand = ""; button4.Image = NullCard; 
                    label7.Text = ""; label8.Text = ""; label33.Text = ""; label34.Text = "";
                }
                if(button5.Enabled == false && Magicbool5 > 0)
                {
                    if (Magicbool5 == 1)
                    {
                        MyField_status[0].FieldATK_status += Magicstatus[4].Magic_status;
                        label12.Text = "" + MyField_status[0].FieldATK_status;
                        textBox1.Text = "첫번째 필드 카드에 공격력 " + Magicstatus[4].Magic_status + "를 더한다";
                        Info_Card[0].Info_Field += "\r\n마법 카드 : 공격력 " + Magicstatus[4].Magic_status + "증가";
                    }
                    if (Magicbool5 == 2)
                    {
                        MyField_status[0].FieldHP_status += Magicstatus[4].Magic_status;
                        label11.Text = "" + MyField_status[0].FieldHP_status;
                        textBox1.Text = "첫번째 필드 카드에 체력 " + Magicstatus[4].Magic_status + "를 더한다";
                        Info_Card[0].Info_Field += "\r\n마법 카드 : 체력 " + Magicstatus[4].Magic_status + "증가";
                    }
                    pictureBox11.Image = NullCard; Handbool5 = 0; Magicbool5 = 0;
                    textBox2.Text = ""; Info_Card[4].Info_Hand = ""; button5.Image = NullCard; 
                    label9.Text = ""; label10.Text = ""; label33.Text = ""; label34.Text = "";
                }
                Card_FieldFull_Fieldnull(); buttonTrue_False();
            }
            if (button12.Visible == false && e.Button == MouseButtons.Left)
            {
                if (Fieldbool1 == 1)
                { button6.Text = "필드에 카드가 있습니다"; button6.Enabled = false; }
                label11.Text = ""; label12.Text = ""; Fieldbool1 = 0;
                MyField_status[0].FieldHP_status = 0; MyField_status[0].FieldATK_status = 0;
                Card_FieldFull_Fieldnull();
                button12.Visible = true; pictureBox1.Image = NullCard;
                textBox1.Text = "필드 첫번째 카드를 버리셨습니다";
                textBox2.Text = Info_Card[0].Info_Field = "";
                button12.Text = "카드 버리기 \r\n" + --DeleteCardcount + "/3";
            }
        }
        private void CardAdd2_button(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                if (button1.Enabled == false && Magicbool1 == 0)
                {
                    pictureBox2.Image = button1.Image; Handbool1 = 0; Fieldbool2 = 1;
                    label13.Text = label1.Text; label14.Text = label2.Text;
                    MyField_status[1].FieldHP_status = Mycardstatus[0].MyHP_status;
                    MyField_status[1].FieldATK_status = Mycardstatus[0].MyATK_status;
                    Info_Card[1].Info_Field = Info_Card[0].Info_Hand;
                    button1.Image = NullCard;
                    label1.Text = ""; label2.Text = "";
                    button7.Text = "필드에 카드가 있습니다";
                }
                if (button2.Enabled == false && Magicbool2 == 0)
                {
                    pictureBox2.Image = button2.Image; Handbool2 = 0; Fieldbool2 = 1;
                    label13.Text = label3.Text; label14.Text = label4.Text;
                    MyField_status[1].FieldHP_status = Mycardstatus[1].MyHP_status;
                    MyField_status[1].FieldATK_status = Mycardstatus[1].MyATK_status;
                    Info_Card[1].Info_Field = Info_Card[1].Info_Hand;
                    button2.Image = NullCard;
                    label3.Text = ""; label4.Text = "";
                    button7.Text = "필드에 카드가 있습니다";
                }
                if (button3.Enabled == false && Magicbool3 == 0)
                {
                    pictureBox2.Image = button3.Image; Handbool3 = 0; Fieldbool2 = 1;
                    label13.Text = label5.Text; label14.Text = label6.Text;
                    MyField_status[1].FieldHP_status = Mycardstatus[2].MyHP_status;
                    MyField_status[1].FieldATK_status = Mycardstatus[2].MyATK_status;
                    Info_Card[1].Info_Field = Info_Card[2].Info_Hand;
                    button3.Image = NullCard;
                    label5.Text = ""; label6.Text = "";
                    button7.Text = "필드에 카드가 있습니다";
                }
                if (button4.Enabled == false && Magicbool4 == 0)
                {
                    pictureBox2.Image = button4.Image; Handbool4 = 0; Fieldbool2 = 1;
                    label13.Text = label7.Text; label14.Text = label8.Text;
                    MyField_status[1].FieldHP_status = Mycardstatus[3].MyHP_status;
                    MyField_status[1].FieldATK_status = Mycardstatus[3].MyATK_status;
                    Info_Card[1].Info_Field = Info_Card[3].Info_Hand;
                    button4.Image = NullCard;
                    label7.Text = ""; label8.Text = "";
                    button7.Text = "필드에 카드가 있습니다";
                }
                if (button5.Enabled == false && Magicbool5 == 0)
                {
                    pictureBox2.Image = button5.Image; Handbool5 = 0; Fieldbool2 = 1;
                    label13.Text = label9.Text; label14.Text = label10.Text;
                    MyField_status[1].FieldHP_status = Mycardstatus[4].MyHP_status;
                    MyField_status[1].FieldATK_status = Mycardstatus[4].MyATK_status;
                    Info_Card[1].Info_Field = Info_Card[4].Info_Hand;
                    button5.Image = NullCard;
                    label9.Text = ""; label10.Text = "";
                    button7.Text = "필드에 카드가 있습니다";
                }

                if(button1.Enabled == false && Magicbool1 > 0)
                {
                    if (Magicbool1 == 1)
                    {
                        MyField_status[1].FieldATK_status += Magicstatus[0].Magic_status;
                        label14.Text = "" + MyField_status[1].FieldATK_status;
                        textBox1.Text = "두번째 필드 카드에 공격력" + Magicstatus[0].Magic_status + "를 더한다";
                        Info_Card[1].Info_Field += "\r\n마법 카드 : 공격력 " + Magicstatus[0].Magic_status + "증가";
                    }
                    if(Magicbool1 == 2)
                    {
                        MyField_status[1].FieldHP_status += Magicstatus[0].Magic_status;
                        label13.Text = "" + MyField_status[1].FieldHP_status;
                        textBox1.Text = "두번째 필드 카드에 체력" + Magicstatus[0].Magic_status + "를 더한다";
                        Info_Card[1].Info_Field += "\r\n마법 카드 : 체력 " + Magicstatus[0].Magic_status + "증가";
                    }
                    pictureBox11.Image = NullCard; Handbool1 = 0; Magicbool1 = 0;
                    textBox2.Text = ""; Info_Card[0].Info_Hand = ""; button1.Image = NullCard; 
                    label1.Text = ""; label2.Text = ""; label33.Text = ""; label34.Text = "";
                }
                if(button2.Enabled == false && Magicbool2 > 0)
                {
                    if (Magicbool2 == 1)
                    {
                        MyField_status[1].FieldATK_status += Magicstatus[1].Magic_status;
                        label14.Text = "" + MyField_status[1].FieldATK_status;
                        textBox1.Text = "두번째 필드 카드에 공격력 " + Magicstatus[1].Magic_status + "를 더한다";
                        Info_Card[1].Info_Field += "\r\n마법 카드 : 공격력 " + Magicstatus[1].Magic_status + "증가";
                    }
                    if(Magicbool2 == 2)
                    {
                        MyField_status[1].FieldHP_status += Magicstatus[1].Magic_status;
                        label13.Text = "" + MyField_status[1].FieldHP_status;
                        textBox1.Text = "두번째 필드 카드에 체력 " + Magicstatus[1].Magic_status + "를 더한다";
                        Info_Card[1].Info_Field += "\r\n마법 카드 : 체력 " + Magicstatus[1].Magic_status + "증가";
                    }
                    pictureBox11.Image = NullCard; Handbool2 = 0; Magicbool2 = 0;
                    textBox2.Text = ""; Info_Card[1].Info_Hand = ""; button2.Image = NullCard; 
                    label3.Text = ""; label4.Text = ""; label33.Text = ""; label34.Text = "";
                }
                if(button3.Enabled == false && Magicbool3 > 0)
                {
                    if (Magicbool3 == 1)
                    {
                        MyField_status[1].FieldATK_status += Magicstatus[2].Magic_status;
                        label14.Text = "" + MyField_status[1].FieldATK_status;
                        textBox1.Text = "두번째 필드 카드에 공격력 " + Magicstatus[2].Magic_status + "를 더한다";
                        Info_Card[1].Info_Field += "\r\n마법 카드 : 공격력 " + Magicstatus[2].Magic_status + "증가";
                    }
                    if(Magicbool3 == 2)
                    {
                        MyField_status[1].FieldHP_status += Magicstatus[2].Magic_status;
                        label13.Text = "" + MyField_status[1].FieldHP_status;
                        textBox1.Text = "두번째 필드 카드에 체력 " + Magicstatus[2].Magic_status + "를 더한다";
                        Info_Card[1].Info_Field += "\r\n마법 카드 : 체력 " + Magicstatus[2].Magic_status + "증가";
                    }
                    pictureBox11.Image = NullCard; Handbool3 = 0; Magicbool3 = 0;
                    textBox2.Text = ""; Info_Card[2].Info_Hand = ""; button3.Image = NullCard; 
                    label5.Text = ""; label6.Text = ""; label33.Text = ""; label34.Text = "";
                }
                if (button4.Enabled == false && Magicbool4 > 0)
                {
                    if (Magicbool4 == 1)
                    {
                        MyField_status[1].FieldATK_status += Magicstatus[3].Magic_status;
                        label14.Text = "" + MyField_status[1].FieldATK_status;
                        textBox1.Text = "두번째 필드 카드에 공격력 " + Magicstatus[3].Magic_status + "를 더한다";
                        Info_Card[1].Info_Field += "\r\n마법 카드 : 공격력 " + Magicstatus[3].Magic_status + "증가";
                    }
                    if(Magicbool4 == 2)
                    {
                        MyField_status[1].FieldHP_status += Magicstatus[3].Magic_status;
                        label13.Text = "" + MyField_status[1].FieldHP_status;
                        textBox1.Text = "두번째 필드 카드에 체력 " + Magicstatus[3].Magic_status + "를 더한다";
                        Info_Card[1].Info_Field += "\r\n마법 카드 : 체력 " + Magicstatus[3].Magic_status + "증가";
                    }
                    pictureBox11.Image = NullCard; Handbool4 = 0; Magicbool4 = 0;
                    textBox2.Text = ""; Info_Card[3].Info_Hand = ""; button4.Image = NullCard; 
                    label7.Text = ""; label8.Text = ""; label33.Text = ""; label34.Text = "";
                }
                if(button5.Enabled == false && Magicbool5 > 0)
                {
                    if (Magicbool5 == 1)
                    {
                        MyField_status[1].FieldATK_status += Magicstatus[4].Magic_status;
                        label14.Text = "" + MyField_status[1].FieldATK_status;
                        textBox1.Text = "두번째 필드 카드에 공격력 " + Magicstatus[4].Magic_status + "를 더한다";
                        Info_Card[1].Info_Field += "\r\n마법 카드 : 공격력 " + Magicstatus[4].Magic_status + "증가";
                    }
                    if(Magicbool5 == 2)
                    {
                        MyField_status[1].FieldHP_status += Magicstatus[4].Magic_status;
                        label13.Text = "" + MyField_status[1].FieldHP_status;
                        textBox1.Text = "두번째 필드 카드에 체력 " + Magicstatus[4].Magic_status + "를 더한다";
                        Info_Card[1].Info_Field += "\r\n마법 카드 : 체력 " + Magicstatus[4].Magic_status + "증가";
                    }
                    pictureBox11.Image = NullCard; Handbool5 = 0; Magicbool5 = 0;
                    textBox2.Text = ""; Info_Card[4].Info_Hand = ""; button5.Image = NullCard; 
                    label9.Text = ""; label10.Text = ""; label33.Text = ""; label34.Text = "";
                }
                Card_FieldFull_Fieldnull(); buttonTrue_False();
            }
            if (button12.Visible == false && e.Button == MouseButtons.Left)
            {
                if (Fieldbool2 == 1)
                { button7.Text = "필드에 카드가 있습니다"; button7.Enabled = false; }
                label13.Text = ""; label14.Text = ""; Fieldbool2 = 0;
                MyField_status[1].FieldHP_status = 0; MyField_status[1].FieldATK_status = 0;
                Card_FieldFull_Fieldnull();
                button12.Visible = true; pictureBox2.Image = NullCard;
                textBox1.Text = "필드 두번째 카드를 버리셨습니다";
                textBox2.Text = Info_Card[1].Info_Field = "";
                button12.Text = "카드 버리기 \r\n" + --DeleteCardcount + "/3";
            }
        }
        private void CardAdd3_button(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                if (button1.Enabled == false && Magicbool1 == 0)
                {
                    pictureBox3.Image = button1.Image; Handbool1 = 0; Fieldbool3 = 1;
                    label15.Text = label1.Text; label16.Text = label2.Text;
                    MyField_status[2].FieldHP_status = Mycardstatus[0].MyHP_status;
                    MyField_status[2].FieldATK_status = Mycardstatus[0].MyATK_status;
                    button1.Image = NullCard; 
                    label1.Text = ""; label2.Text = "";
                    button8.Text = "필드에 카드가 있습니다"; 
                }
                if (button2.Enabled == false && Magicbool2 == 0)
                {
                    pictureBox3.Image = button2.Image; Handbool2 = 0; Fieldbool3 = 1;
                    label15.Text = label3.Text; label16.Text = label4.Text;
                    MyField_status[2].FieldHP_status = Mycardstatus[1].MyHP_status;
                    MyField_status[2].FieldATK_status = Mycardstatus[1].MyATK_status;
                    button2.Image = NullCard;
                    label3.Text = ""; label4.Text = "";
                    button8.Text = "필드에 카드가 있습니다";
                }
                if (button3.Enabled == false && Magicbool3 == 0)
                {
                    pictureBox3.Image = button3.Image; Handbool3 = 0; Fieldbool3 = 1;
                    label15.Text = label5.Text; label16.Text = label6.Text;
                    MyField_status[2].FieldHP_status = Mycardstatus[2].MyHP_status;
                    MyField_status[2].FieldATK_status = Mycardstatus[2].MyATK_status;
                    button3.Image = NullCard; 
                    label5.Text = ""; label6.Text = "";
                    button8.Text = "필드에 카드가 있습니다";
                }
                if (button4.Enabled == false && Magicbool4 == 0)
                {
                    pictureBox3.Image = button4.Image; Handbool4 = 0; Fieldbool3 = 1;
                    label15.Text = label7.Text; label16.Text = label8.Text;
                    MyField_status[2].FieldHP_status = Mycardstatus[3].MyHP_status;
                    MyField_status[2].FieldATK_status = Mycardstatus[3].MyATK_status;
                    button4.Image = NullCard;
                    label7.Text = ""; label8.Text = "";
                    button8.Text = "필드에 카드가 있습니다";
                }
                if (button5.Enabled == false && Magicbool5 == 0)
                {
                    pictureBox3.Image = button5.Image; Handbool5 = 0; Fieldbool3 = 1;
                    label15.Text = label9.Text; label16.Text = label10.Text;
                    MyField_status[2].FieldHP_status = Mycardstatus[4].MyHP_status;
                    MyField_status[2].FieldATK_status = Mycardstatus[4].MyATK_status;
                    button5.Image = NullCard;
                    label9.Text = ""; label10.Text = "";
                    button8.Text = "필드에 카드가 있습니다";
                }
                if(button1.Enabled == false && Magicbool1 > 0)
                {
                    if (Magicbool1 == 1)
                    {
                        MyField_status[2].FieldATK_status += Magicstatus[0].Magic_status;
                        label16.Text = "" + MyField_status[2].FieldATK_status;
                        textBox1.Text = "세번째 필드 카드에 공격력 " + Magicstatus[0].Magic_status + "를 더한다";
                        Info_Card[2].Info_Field += "\r\n마법 카드 : 공격력 " + Magicstatus[0].Magic_status + "증가";
                    }
                    if(Magicbool1 == 2)
                    {
                        MyField_status[2].FieldHP_status += Magicstatus[0].Magic_status;
                        label15.Text = "" + MyField_status[2].FieldHP_status;
                        textBox1.Text = "세번째 필드 카드에 체력 " + Magicstatus[0].Magic_status + "를 더한다";
                        Info_Card[2].Info_Field += "\r\n마법 카드 : 체력 " + Magicstatus[0].Magic_status + "증가";
                    }
                    pictureBox11.Image = NullCard; Handbool1 = 0; Magicbool1 = 0;
                    textBox2.Text = ""; Info_Card[0].Info_Hand = ""; button1.Image = NullCard; 
                    label1.Text = ""; label2.Text = ""; label33.Text = ""; label34.Text = "";
                }
                if(button2.Enabled == false && Magicbool2 > 0)
                {
                    if (Magicbool2 == 1)
                    {
                        MyField_status[2].FieldATK_status += Magicstatus[1].Magic_status;
                        label16.Text = "" + MyField_status[2].FieldATK_status;
                        textBox1.Text = "세번째 필드 카드에 공격력 " + Magicstatus[1].Magic_status + "를 더한다";
                        Info_Card[2].Info_Field += "\r\n마법 카드 : 공격력 " + Magicstatus[1].Magic_status + "증가";
                    }
                    if (Magicbool2 == 2)
                    {
                        MyField_status[2].FieldHP_status += Magicstatus[1].Magic_status;
                        label15.Text = "" + MyField_status[2].FieldHP_status;
                        textBox1.Text = "세번째 필드 카드에 체력 " + Magicstatus[1].Magic_status + "를 더한다";
                        Info_Card[2].Info_Field += "\r\n마법 카드 : 체력 " + Magicstatus[1].Magic_status + "증가";
                    }
                    pictureBox11.Image = NullCard; Handbool2 = 0; Magicbool2 = 0;
                    textBox2.Text = ""; Info_Card[1].Info_Hand = ""; button2.Image = NullCard; 
                    label3.Text = ""; label4.Text = ""; label33.Text = ""; label34.Text = "";
                }
                if(button3.Enabled == false && Magicbool3 > 0)
                {
                    if (Magicbool3 == 1)
                    {
                        MyField_status[2].FieldATK_status += Magicstatus[2].Magic_status;
                        label16.Text = "" + MyField_status[2].FieldATK_status;
                        textBox1.Text = "세번째 필드 카드에 공격력 " + Magicstatus[2].Magic_status + "를 더한다";
                        Info_Card[2].Info_Field += "\r\n마법 카드 : 공격력 " + Magicstatus[2].Magic_status + "증가";
                    }
                    if(Magicbool3 == 2)
                    {
                        MyField_status[2].FieldHP_status += Magicstatus[2].Magic_status;
                        label15.Text = "" + MyField_status[2].FieldHP_status;
                        textBox1.Text = "세번째 필드 카드에 체력 " + Magicstatus[2].Magic_status + "를 더한다";
                        Info_Card[2].Info_Field += "\r\n마법 카드 : 체력 " + Magicstatus[2].Magic_status + "증가";
                    }
                    pictureBox11.Image = NullCard; Handbool3 = 0; Magicbool3 = 0;
                    textBox2.Text = ""; Info_Card[2].Info_Hand = ""; button3.Image = NullCard;
                    label5.Text = ""; label6.Text = ""; label33.Text = ""; label34.Text = "";
                }
                if(button4.Enabled == false && Magicbool4 > 0 )
                {
                    if (Magicbool4 == 1)
                    {
                        MyField_status[2].FieldATK_status += Magicstatus[3].Magic_status;
                        label16.Text = "" + MyField_status[2].FieldATK_status;
                        textBox1.Text = "세번째 필드 카드에 공격력 " + Magicstatus[3].Magic_status + "를 더한다";
                        Info_Card[2].Info_Field += "\r\n마법 카드 : 공격력 " + Magicstatus[3].Magic_status + "증가";
                    }
                    if (Magicbool4 == 2)
                    {
                        MyField_status[2].FieldHP_status += Magicstatus[3].Magic_status;
                        label15.Text = "" + MyField_status[2].FieldHP_status;
                        textBox1.Text = "세번째 필드 카드에 체력 " + Magicstatus[3].Magic_status + "를 더한다";
                        Info_Card[2].Info_Field += "\r\n마법 카드 : 체력 " + Magicstatus[3].Magic_status + "증가";
                    }
                    pictureBox11.Image = NullCard; Handbool4 = 0; Magicbool4 = 0;
                    textBox2.Text = ""; Info_Card[3].Info_Hand = ""; button4.Image = NullCard;
                    label7.Text = ""; label8.Text = ""; label33.Text = ""; label34.Text = "";
                }
                if(button5.Enabled == false && Magicbool5 > 0)
                {
                    if (Magicbool5 == 1)
                    {
                        MyField_status[2].FieldATK_status += Magicstatus[4].Magic_status;
                        label16.Text = "" + MyField_status[2].FieldATK_status;
                        textBox1.Text = "세번째 필드 카드에 공격력 " + Magicstatus[4].Magic_status + "를 더한다";
                        Info_Card[2].Info_Field += "\r\n마법 카드 : 공격력 " + Magicstatus[4].Magic_status + "증가";
                    }
                    if(Magicbool5 == 2)
                    {
                        MyField_status[2].FieldHP_status += Magicstatus[4].Magic_status;
                        label15.Text = "" + MyField_status[2].FieldHP_status;
                        textBox1.Text = "세번째 필드 카드에 체력 " + Magicstatus[4].Magic_status + "를 더한다";
                        Info_Card[2].Info_Field += "\r\n마법 카드 : 체력 " + Magicstatus[4].Magic_status + "증가";
                    }
                    pictureBox11.Image = NullCard; Handbool5 = 0; Magicbool5 = 0;
                    textBox2.Text = ""; Info_Card[4].Info_Hand = ""; button5.Image = NullCard; 
                    label9.Text = ""; label10.Text = ""; label33.Text = ""; label34.Text = "";
                }
                Card_FieldFull_Fieldnull(); buttonTrue_False();
            }
            if (button12.Visible == false && e.Button == MouseButtons.Left)
            {
                if (Fieldbool3 == 1)
                { button8.Text = "필드에 카드가 있습니다"; button8.Enabled = false; }
                label15.Text = ""; label16.Text = ""; Fieldbool3 = 0;
                MyField_status[2].FieldHP_status = 0; MyField_status[2].FieldATK_status = 0;
                Card_FieldFull_Fieldnull();
                button12.Visible = true; pictureBox3.Image = NullCard;
                textBox1.Text = "필드 세번째 카드를 버리셨습니다";
                textBox2.Text = Info_Card[2].Info_Field = "";
                button12.Text = "카드 버리기 \r\n" + --DeleteCardcount + "/3";
            }
        }
        private void CardAdd4_button(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                if (button1.Enabled == false && Magicbool1 == 0)
                {
                    pictureBox4.Image = button1.Image; Handbool1 = 0; Fieldbool4 = 1;
                    label17.Text = label1.Text; label18.Text = label2.Text;
                    MyField_status[3].FieldHP_status = Mycardstatus[0].MyHP_status;
                    MyField_status[3].FieldATK_status = Mycardstatus[0].MyATK_status;
                    button1.Image = NullCard;
                    label1.Text = ""; label2.Text = "";
                    button9.Text = "필드에 카드가 있습니다";
                }
                if (button2.Enabled == false && Magicbool2 == 0)
                {
                    pictureBox4.Image = button2.Image; Handbool2 = 0; Fieldbool4 = 1;
                    label17.Text = label3.Text; label18.Text = label4.Text;
                    MyField_status[3].FieldHP_status = Mycardstatus[1].MyHP_status;
                    MyField_status[3].FieldATK_status = Mycardstatus[1].MyATK_status;
                    button2.Image = NullCard;
                    label3.Text = ""; label4.Text = "";
                    button9.Text = "필드에 카드가 있습니다";
                }
                if (button3.Enabled == false && Magicbool3 == 0)
                {
                    pictureBox4.Image = button3.Image; Handbool3 = 0; Fieldbool4 = 1;
                    label17.Text = label5.Text; label18.Text = label6.Text;
                    MyField_status[3].FieldHP_status = Mycardstatus[2].MyHP_status;
                    MyField_status[3].FieldATK_status = Mycardstatus[2].MyATK_status;
                    button3.Image = NullCard;
                    label5.Text = ""; label6.Text = "";
                    button9.Text = "필드에 카드가 있습니다";
                }
                if (button4.Enabled == false && Magicbool4 == 0)
                {
                    pictureBox4.Image = button4.Image; Handbool4 = 0; Fieldbool4 = 1;
                    label17.Text = label7.Text; label18.Text = label8.Text;
                    MyField_status[3].FieldHP_status = Mycardstatus[3].MyHP_status;
                    MyField_status[3].FieldATK_status = Mycardstatus[3].MyATK_status;
                    button4.Image = NullCard;
                    label7.Text = ""; label8.Text = "";
                    button9.Text = "필드에 카드가 있습니다";
                }
                if (button5.Enabled == false && Magicbool5 == 0)
                {
                    pictureBox4.Image = button5.Image; Handbool5 = 0; Fieldbool4 = 1;
                    label17.Text = label9.Text; label18.Text = label10.Text;
                    MyField_status[3].FieldHP_status = Mycardstatus[4].MyHP_status;
                    MyField_status[3].FieldATK_status = Mycardstatus[4].MyATK_status;
                    button5.Image = NullCard;
                    label9.Text = ""; label10.Text = "";
                    button9.Text = "필드에 카드가 있습니다";
                }

                if(button1.Enabled == false && Magicbool1 > 0)
                {
                    if (Magicbool1 == 1)
                    {
                        MyField_status[3].FieldATK_status += Magicstatus[0].Magic_status;
                        label18.Text = "" + MyField_status[3].FieldATK_status;
                        textBox1.Text = "네번째 필드 카드에 공격력 " + Magicstatus[0].Magic_status + "를 더한다";
                        Info_Card[3].Info_Field += "\r\n마법 카드 : 공격력 " + Magicstatus[0].Magic_status + "증가";
                    }
                    if (Magicbool1 == 2)
                    {
                        MyField_status[3].FieldHP_status += Magicstatus[0].Magic_status;
                        label17.Text = "" + MyField_status[3].FieldHP_status;
                        textBox1.Text = "네번째 필드 카드에 체력 " + Magicstatus[0].Magic_status + "를 더한다";
                        Info_Card[3].Info_Field += "\r\n마법 카드 : 체력 " + Magicstatus[0].Magic_status + "증가";
                    }
                    pictureBox11.Image = NullCard; Handbool1 = 0; Magicbool1 = 0;
                    textBox2.Text = ""; Info_Card[0].Info_Hand = ""; button1.Image = NullCard; 
                    label1.Text = ""; label2.Text = ""; label33.Text = ""; label34.Text = "";
                }
                if(button2.Enabled == false && Magicbool2 > 0)
                {
                    if (Magicbool2 == 1)
                    {
                        MyField_status[3].FieldATK_status += Magicstatus[1].Magic_status;
                        label18.Text = "" + MyField_status[3].FieldATK_status;
                        textBox1.Text = "네번째 필드 카드에 공격력 " + Magicstatus[1].Magic_status + "를 더한다";
                        Info_Card[3].Info_Field += "\r\n마법 카드 : 공격력 " + Magicstatus[1].Magic_status + "증가";
                    }
                    if(Magicbool2 == 2)
                    {
                        MyField_status[3].FieldHP_status += Magicstatus[1].Magic_status;
                        label17.Text = "" + MyField_status[3].FieldHP_status;
                        textBox1.Text = "네번째 필드 카드에 체력 " + Magicstatus[1].Magic_status + "를 더한다";
                        Info_Card[3].Info_Field += "\r\n마법 카드 : 체력 " + Magicstatus[1].Magic_status + "증가";
                    }
                    pictureBox11.Image = NullCard; Handbool2 = 0; Magicbool2 = 0;
                    textBox2.Text = ""; Info_Card[1].Info_Hand = ""; button2.Image = NullCard; 
                    label3.Text = ""; label4.Text = ""; label33.Text = ""; label34.Text = "";
                }
                if(button3.Enabled == false && Magicbool3 > 0)
                {
                    if (Magicbool3 == 1)
                    {
                        MyField_status[3].FieldATK_status += Magicstatus[2].Magic_status;
                        label18.Text = "" + MyField_status[3].FieldATK_status;
                        textBox1.Text = "네번째 필드 카드에 공격력 " + Magicstatus[2].Magic_status + "를 더한다";
                        Info_Card[3].Info_Field += "\r\n마법 카드 : 공격력 " + Magicstatus[2].Magic_status + "증가";
                    }
                    if(Magicbool3 ==  2)
                    {
                        MyField_status[3].FieldHP_status += Magicstatus[2].Magic_status;
                        label17.Text = "" + MyField_status[3].FieldHP_status;
                        textBox1.Text = "네번째 필드 카드에 체력 " + Magicstatus[2].Magic_status + "를 더한다";
                        Info_Card[3].Info_Field += "\r\n마법 카드 : 체력 " + Magicstatus[2].Magic_status + "증가";
                    }
                    pictureBox11.Image = NullCard; Handbool3 = 0; Magicbool3 = 0;
                    textBox2.Text = ""; Info_Card[2].Info_Hand = ""; button3.Image = NullCard; 
                    label5.Text = ""; label6.Text = ""; label33.Text = ""; label34.Text = "";
                }
                if(button4.Enabled == false && Magicbool4 > 0)
                {
                    if (Magicbool4 == 1)
                    {
                        MyField_status[3].FieldATK_status += Magicstatus[3].Magic_status;
                        label18.Text = "" + MyField_status[3].FieldATK_status;
                        textBox1.Text = "네번째 필드 카드에 공격력 " + Magicstatus[3].Magic_status + "를 더한다";
                        Info_Card[3].Info_Field += "\r\n마법 카드 : 공격력 " + Magicstatus[3].Magic_status + "증가";
                    }
                    if(Magicbool4 == 2)
                    {
                        MyField_status[3].FieldHP_status += Magicstatus[3].Magic_status;
                        label17.Text = "" + MyField_status[3].FieldHP_status;
                        textBox1.Text = "네번째 필드 카드에 체력 " + Magicstatus[3].Magic_status + "를 더한다";
                        Info_Card[3].Info_Field += "\r\n마법 카드 : 체력 " + Magicstatus[3].Magic_status + "증가";
                    }
                    pictureBox11.Image = NullCard; Handbool4 = 0; Magicbool4 = 0;
                    textBox2.Text = ""; Info_Card[3].Info_Hand = ""; button4.Image = NullCard; 
                    label7.Text = ""; label8.Text = ""; label33.Text = ""; label34.Text = "";
                }
                if(button5.Enabled == false && Magicbool5 > 0)
                {
                    if (Magicbool5 == 1)
                    {
                        MyField_status[3].FieldATK_status += Magicstatus[4].Magic_status;
                        label18.Text = "" + MyField_status[3].FieldATK_status;
                        textBox1.Text = "네번째 필드 카드에 공격력 " + Magicstatus[4].Magic_status + "를 더한다";
                        Info_Card[3].Info_Field += "\r\n마법 카드 : 공격력 " + Magicstatus[4].Magic_status + "증가";
                    }
                    if(Magicbool5 == 2)
                    {
                        MyField_status[3].FieldHP_status += Magicstatus[4].Magic_status;
                        label17.Text = "" + MyField_status[3].FieldHP_status;
                        textBox1.Text = "네번째 필드 카드에 체력 " + Magicstatus[4].Magic_status + "를 더한다";
                        Info_Card[3].Info_Field += "\r\n마법 카드 : 체력 " + Magicstatus[4].Magic_status + "증가";
                    }
                    pictureBox11.Image = NullCard; Handbool5 = 0; Magicbool5 = 0;
                    textBox2.Text = ""; Info_Card[4].Info_Hand = ""; button5.Image = NullCard; 
                    label9.Text = ""; label10.Text = ""; label33.Text = ""; label34.Text = "";
                }
                Card_FieldFull_Fieldnull(); buttonTrue_False();
            }
            if (button12.Visible == false && e.Button == MouseButtons.Left)
            {
                if (Fieldbool4 == 1)
                { button9.Text = "필드에 카드가 있습니다"; button9.Enabled = false; }
                label17.Text = ""; label18.Text = ""; Fieldbool4 = 0;
                MyField_status[3].FieldHP_status = 0; MyField_status[3].FieldATK_status = 0;
                Card_FieldFull_Fieldnull();
                button12.Visible = true; pictureBox4.Image = NullCard;
                textBox1.Text = "필드 네번째 카드를 버리셨습니다";
                textBox2.Text = Info_Card[3].Info_Field = "";
                button12.Text = "카드 버리기 \r\n" + --DeleteCardcount + "/3";
            }
        }
        private void CardAdd5_button(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                if (button1.Enabled == false && Magicbool1 == 0)
                {
                    pictureBox5.Image = button1.Image; Handbool1 = 0; Fieldbool5 = 1;
                    label19.Text = label1.Text; label20.Text = label2.Text;
                    MyField_status[4].FieldHP_status = Mycardstatus[0].MyHP_status;
                    MyField_status[4].FieldATK_status = Mycardstatus[0].MyATK_status;
                    button1.Image = NullCard;
                    label1.Text = ""; label2.Text = "";
                    button10.Text = "필드에 카드가 있습니다";
                }
                if (button2.Enabled == false && Magicbool2 == 0)
                {
                    pictureBox5.Image = button2.Image; Handbool2 = 0; Fieldbool5 = 1;
                    label19.Text = label3.Text; label20.Text = label4.Text;
                    MyField_status[4].FieldHP_status = Mycardstatus[1].MyHP_status;
                    MyField_status[4].FieldATK_status = Mycardstatus[1].MyATK_status;
                    button2.Image = NullCard;
                    label3.Text = ""; label4.Text = "";
                    button10.Text = "필드에 카드가 있습니다";
                }
                if (button3.Enabled == false && Magicbool3 == 0)
                {
                    pictureBox5.Image = button3.Image; Handbool3 = 0; Fieldbool5 = 1;
                    label19.Text = label5.Text; label20.Text = label6.Text;
                    MyField_status[4].FieldHP_status = Mycardstatus[2].MyHP_status;
                    MyField_status[4].FieldATK_status = Mycardstatus[2].MyATK_status;
                    button3.Image = NullCard;
                    label5.Text = ""; label6.Text = "";
                    button10.Text = "필드에 카드가 있습니다";
                }
                if (button4.Enabled == false && Magicbool4 == 0)
                {
                    pictureBox5.Image = button4.Image; Handbool4 = 0; Fieldbool5 = 1;
                    label19.Text = label7.Text; label20.Text = label8.Text;
                    MyField_status[4].FieldHP_status = Mycardstatus[3].MyHP_status;
                    MyField_status[4].FieldATK_status = Mycardstatus[3].MyATK_status;
                    button4.Image = NullCard;
                    label7.Text = ""; label8.Text = "";
                    button10.Text = "필드에 카드가 있습니다";
                }
                if (button5.Enabled == false && Magicbool5 == 0)
                {
                    pictureBox5.Image = button5.Image; Handbool5 = 0; Fieldbool5 = 1;
                    label19.Text = label9.Text; label20.Text = label10.Text;
                    MyField_status[4].FieldHP_status = Mycardstatus[4].MyHP_status;
                    MyField_status[4].FieldATK_status = Mycardstatus[4].MyATK_status;
                    button5.Image = NullCard;
                    label9.Text = ""; label10.Text = "";
                    button10.Text = "필드에 카드가 있습니다";
                }

                if(button1.Enabled == false && Magicbool1 > 0)
                {
                    if (Magicbool1 == 1)
                    {
                        MyField_status[4].FieldATK_status += Magicstatus[0].Magic_status;
                        label20.Text = "" + MyField_status[4].FieldATK_status;
                        textBox1.Text = "다섯번째 필드 카드에 공격력 " + Magicstatus[0].Magic_status + "를 더한다";
                        Info_Card[4].Info_Field += "\r\n마법 카드 : 공격력 " + Magicstatus[0].Magic_status + "증가";
                    }
                    if(Magicbool1 == 2)
                    {
                        MyField_status[4].FieldHP_status += Magicstatus[0].Magic_status;
                        label19.Text = "" + MyField_status[4].FieldHP_status;
                        textBox1.Text = "다섯번째 필드 카드에 체력 " + Magicstatus[0].Magic_status + "를 더한다";
                        Info_Card[4].Info_Field += "\r\n마법 카드 : 체력 " + Magicstatus[0].Magic_status + "증가";
                    }
                    pictureBox11.Image = NullCard; Handbool1 = 0; Magicbool1 = 0;
                    textBox2.Text = ""; Info_Card[0].Info_Hand = ""; button1.Image = NullCard; 
                    label1.Text = ""; label2.Text = ""; label33.Text = ""; label34.Text = "";
                }
                if(button2.Enabled == false && Magicbool2 > 0)
                {
                    if (Magicbool2 == 1)
                    {
                        MyField_status[4].FieldATK_status += Magicstatus[1].Magic_status;
                        label20.Text = "" + MyField_status[4].FieldATK_status;
                        textBox1.Text = "다섯번째 필드 카드에 공격력 " + Magicstatus[1].Magic_status + "를 더한다";
                        Info_Card[4].Info_Field += "\r\n마법 카드 : 공격력 " + Magicstatus[1].Magic_status + "증가";
                    }
                    if(Magicbool2 == 2)
                    {
                        MyField_status[4].FieldHP_status += Magicstatus[1].Magic_status;
                        label19.Text = "" + MyField_status[4].FieldHP_status;
                        textBox1.Text = "다섯번째 필드 카드에 체력 " + Magicstatus[1].Magic_status + "를 더한다";
                        Info_Card[4].Info_Field += "\r\n마법 카드 : 체력 " + Magicstatus[1].Magic_status + "증가";
                    }
                    pictureBox11.Image = NullCard; Handbool2 = 0; Magicbool2 = 0;
                    textBox2.Text = ""; Info_Card[1].Info_Hand = ""; button2.Image = NullCard; 
                    label3.Text = ""; label4.Text = ""; label33.Text = ""; label34.Text = "";
                }
                if(button3.Enabled == false && Magicbool3 > 0)
                {
                    if (Magicbool3 == 1)
                    {
                        MyField_status[4].FieldATK_status += Magicstatus[2].Magic_status;
                        label20.Text = "" + MyField_status[4].FieldATK_status;
                        textBox1.Text = "다섯번째 필드 카드에 공격력 " + Magicstatus[2].Magic_status + "를 더한다";
                        Info_Card[4].Info_Field += "\r\n마법 카드 : 공격력 " + Magicstatus[2].Magic_status + "증가";
                    }
                    if(Magicbool3 == 2)
                    {
                        MyField_status[4].FieldHP_status += Magicstatus[2].Magic_status;
                        label19.Text = "" + MyField_status[4].FieldHP_status;
                        textBox1.Text = "다섯번째 필드 카드에 체력 " + Magicstatus[2].Magic_status + "를 더한다";
                        Info_Card[4].Info_Field += "\r\n마법 카드 : 체력 " + Magicstatus[2].Magic_status + "증가";
                    }
                    pictureBox11.Image = NullCard; Handbool3 = 0; Magicbool3 = 0;
                    textBox2.Text = ""; Info_Card[2].Info_Hand = ""; button3.Image = NullCard; 
                    label5.Text = ""; label6.Text = ""; label33.Text = ""; label34.Text = "";
                }
                if(button4.Enabled == false && Magicbool4 > 0)
                {
                    if (Magicbool4 == 1)
                    {
                        MyField_status[4].FieldATK_status += Magicstatus[3].Magic_status;
                        label20.Text = "" + MyField_status[4].FieldATK_status;
                        textBox1.Text = "다섯번째 필드 카드에 공격력 " + Magicstatus[3].Magic_status + "를 더한다";
                        Info_Card[4].Info_Field += "\r\n마법 카드 : 공격력 " + Magicstatus[3].Magic_status + "증가";
                    }
                    if(Magicbool4 == 2)
                    {
                        MyField_status[4].FieldHP_status += Magicstatus[3].Magic_status;
                        label19.Text = "" + MyField_status[4].FieldHP_status;
                        textBox1.Text = "다섯번째 필드 카드에 체력 " + Magicstatus[3].Magic_status + "를 더한다";
                        Info_Card[4].Info_Field += "\r\n마법 카드 : 체력 " + Magicstatus[3].Magic_status + "증가";
                    }
                    pictureBox11.Image = NullCard; Handbool4 = 0; Magicbool4 = 0;
                    textBox2.Text = ""; Info_Card[3].Info_Hand = ""; button4.Image = NullCard; 
                    label7.Text = ""; label8.Text = ""; label33.Text = ""; label34.Text = "";
                }
                if(button5.Enabled == false && Magicbool5 > 0)
                {
                    if (Magicbool5 == 1)
                    {
                        MyField_status[4].FieldATK_status += Magicstatus[4].Magic_status;
                        label20.Text = "" + MyField_status[4].FieldATK_status;
                        textBox1.Text = "다섯번째 필드 카드에 공격력 " + Magicstatus[4].Magic_status + "를 더한다";
                        Info_Card[4].Info_Field += "\r\n마법 카드 : 공격력 " + Magicstatus[4].Magic_status + "증가";
                    }
                    if(Magicbool5 == 2)
                    {
                        MyField_status[4].FieldHP_status += Magicstatus[4].Magic_status;
                        label19.Text = "" + MyField_status[4].FieldHP_status;
                        textBox1.Text = "다섯번째 필드 카드에 체력 " + Magicstatus[4].Magic_status + "를 더한다";
                        Info_Card[4].Info_Field += "\r\n마법 카드 : 체력 " + Magicstatus[4].Magic_status + "증가";
                    }
                    pictureBox11.Image = NullCard; Handbool5 = 0; Magicbool5 = 0;
                    textBox2.Text = ""; Info_Card[4].Info_Hand = ""; button5.Image = NullCard;
                    label9.Text = ""; label10.Text = ""; label33.Text = ""; label34.Text = "";
                }
                Card_FieldFull_Fieldnull(); buttonTrue_False();
            }
            if (button12.Visible == false && e.Button == MouseButtons.Left)
            {
                if (Fieldbool5 == 1)
                { button10.Text = "필드에 카드가 있습니다"; button10.Enabled = false; }
                label19.Text = ""; label20.Text = ""; Fieldbool5 = 0;
                MyField_status[4].FieldHP_status = 0; MyField_status[4].FieldATK_status = 0;
                Card_FieldFull_Fieldnull();
                button12.Visible = true; pictureBox5.Image = NullCard;
                textBox1.Text = "필드 다섯번째 카드를 버리셨습니다";
                textBox2.Text = Info_Card[4].Info_Field = "";
                button12.Text = "카드 버리기 \r\n" + --DeleteCardcount + "/3";
            }
        }
        private void Card1_button(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                textBox2.Text = "첫번째 나의 카드 정보\r\n" + Info_Card[0].Info_Hand;
                label33.Text = label1.Text; label34.Text = label2.Text;
                pictureBox11.Image = button1.Image; button1.Enabled = false;
                if (button2.Enabled == false) { button2.Enabled = true; }
           else if (button3.Enabled == false) { button3.Enabled = true; }
           else if (button4.Enabled == false) { button4.Enabled = true; }
           else if (button5.Enabled == false) { button5.Enabled = true; }
           else if (Handbool1 == 0) { button1.Enabled = true; }

                if (e.Button == MouseButtons.Left && Magicbool1 > 0)
                { MagicSpell_AddCard(); }
                else if(e.Button == MouseButtons.Left && Magicbool1 == 0)
                { Card_FieldFull_Fieldnull(); }
                if (button12.Visible == false && e.Button == MouseButtons.Left && Handbool1 == 1)
                {
                    label1.Text = ""; label2.Text = ""; Handbool1 = 0; Magicbool1 = 0;
                    button12.Visible = true; button1.Enabled = true; button1.Image = NullCard;
                    textBox1.Text = "나의 패에 있는 첫번째 카드를 버리셨습니다";
                    button12.Text = "카드 버리기 \r\n" + --DeleteCardcount + "/3";
                    textBox2.Text = Info_Card[0].Info_Hand = "";
                    Card_FieldFull_Fieldnull(); button12.Visible = true;
                }
                if (button12.Enabled == false && e.Button == MouseButtons.Left && Handbool1 == 0)
                { textBox1.Text = "그곳에는 버릴 카드가 없습니다"; button12.Visible = true; button1.Enabled = true; }
            }
        }
        private void Card2_button(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                textBox2.Text = "두번째 나의 카드 정보\r\n" + Info_Card[1].Info_Hand;
                label33.Text = label3.Text; label34.Text = label4.Text;
                pictureBox11.Image = button2.Image; button2.Enabled = false;
                if (button1.Enabled == false) { button1.Enabled = true; }
           else if (button3.Enabled == false) { button3.Enabled = true; }
           else if (button4.Enabled == false) { button4.Enabled = true; }
           else if (button5.Enabled == false) { button5.Enabled = true; }
           else if (Handbool2 == 0) { button2.Enabled = true; }

                if (e.Button == MouseButtons.Left && Magicbool2 > 0)
                { MagicSpell_AddCard(); }
                else if (e.Button == MouseButtons.Left && Magicbool2 == 0)
                { Card_FieldFull_Fieldnull(); }
                if (button12.Visible == false && e.Button == MouseButtons.Left && Handbool2 == 1)
                {
                    label3.Text = ""; label4.Text = ""; Handbool2 = 0; Magicbool2 = 0;
                    button12.Visible = true; button2.Enabled = true; button2.Image = NullCard;
                    textBox1.Text = "나의 패에 있는 두번째 카드를 버리셨습니다";
                    button12.Text = "카드 버리기 \r\n" + --DeleteCardcount + "/3";
                    textBox2.Text = Info_Card[1].Info_Hand = "";
                    Card_FieldFull_Fieldnull(); button12.Visible = true;
                }
                if (button12.Enabled == false && e.Button == MouseButtons.Left && Handbool2 == 0)
                { textBox1.Text = "그곳에는 버릴 카드가 없습니다"; button12.Visible = true; button2.Enabled = true; }
            }
        }
        private void Card3_button(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                textBox2.Text = "세번째 나의 카드 정보\r\n" + Info_Card[2].Info_Hand;
                label33.Text = label5.Text; label34.Text = label6.Text;
                pictureBox11.Image = button3.Image; button3.Enabled = false;
                if (button1.Enabled == false) { button1.Enabled = true; }
           else if (button2.Enabled == false) { button2.Enabled = true; }
           else if (button4.Enabled == false) { button4.Enabled = true; }
           else if (button5.Enabled == false) { button5.Enabled = true; }
           else if (Handbool3 == 0) { button3.Enabled = true; }
            }
            if (e.Button == MouseButtons.Left && Magicbool3 > 0)
            { MagicSpell_AddCard(); }
            else if (e.Button == MouseButtons.Left && Magicbool3 == 0)
            { Card_FieldFull_Fieldnull(); }
            if (button12.Visible == false && e.Button == MouseButtons.Left && Handbool3 == 1)
            {
                label5.Text = ""; label6.Text = ""; Handbool3 = 0; Magicbool3 = 0;
                button12.Visible = true; button3.Enabled = true; button3.Image = NullCard;
                textBox1.Text = "나의 패에 있는 세번째 카드를 버리셨습니다";
                button12.Text = "카드 버리기 \r\n" + --DeleteCardcount + "/3";
                textBox2.Text = Info_Card[2].Info_Hand = "";
                Card_FieldFull_Fieldnull(); button12.Visible = true;
            }
            if (button12.Enabled == false && e.Button == MouseButtons.Left && Handbool3 == 0)
            { textBox1.Text = "그곳에는 버릴 카드가 없습니다"; button12.Visible = true; button3.Enabled = true; }
        }
        private void Card4_button(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                textBox2.Text = "네번째 나의 카드 정보\r\n" + Info_Card[3].Info_Hand;
                label33.Text = label7.Text; label34.Text = label8.Text;
                pictureBox11.Image = button4.Image; button4.Enabled = false;
                if (button1.Enabled == false) { button1.Enabled = true; }
           else if (button2.Enabled == false) { button2.Enabled = true; }
           else if (button3.Enabled == false) { button3.Enabled = true; }
           else if (button5.Enabled == false) { button5.Enabled = true; }
           else if (Handbool4 == 0) { button4.Enabled = true; }
            }
            if (e.Button == MouseButtons.Left && Magicbool4 > 0)
            { MagicSpell_AddCard(); }
            else if (e.Button == MouseButtons.Left && Magicbool4 == 0)
            { Card_FieldFull_Fieldnull(); }
            if (button12.Visible == false && e.Button == MouseButtons.Left && Handbool4 == 1)
            {
                label7.Text = ""; label8.Text = ""; Handbool4 = 0; Magicbool4 = 0;
                button12.Visible = true; button4.Enabled = true; button4.Image = NullCard;
                textBox1.Text = "나의 패에 있는 네번째 카드를 버리셨습니다";
                button12.Text = "카드 버리기 \r\n" + --DeleteCardcount + "/3";
                textBox2.Text = Info_Card[3].Info_Hand = "";
                Card_FieldFull_Fieldnull(); button12.Visible = true;
            }
            if (button12.Enabled == false && e.Button == MouseButtons.Left && Handbool4 == 0)
            { textBox1.Text = "그곳에는 버릴 카드가 없습니다"; button12.Visible = true; button4.Enabled = true; }
        }
        private void Card5_button(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                textBox2.Text = "다섯번째 나의 카드 정보\r\n" + Info_Card[4].Info_Hand;
                label33.Text = label9.Text; label34.Text = label10.Text;
                pictureBox11.Image = button5.Image; button5.Enabled = false;
                if (button1.Enabled == false) { button1.Enabled = true; }
           else if (button2.Enabled == false) { button2.Enabled = true; }
           else if (button3.Enabled == false) { button3.Enabled = true; }
           else if (button4.Enabled == false) { button4.Enabled = true; }
           else if (Handbool5 == 0) { button5.Enabled = true; }
            }
            if (e.Button == MouseButtons.Left && Magicbool5 > 0)
            { MagicSpell_AddCard(); }
            else if (e.Button == MouseButtons.Left && Magicbool5 == 0)
            { Card_FieldFull_Fieldnull(); }
            if (button12.Visible == false && e.Button == MouseButtons.Left && Handbool5 == 1)
            {
                label9.Text = ""; label10.Text = ""; Handbool5 = 0; Magicbool5 = 0;
                button12.Visible = true; button5.Enabled = true; button5.Image = NullCard;
                textBox1.Text = "나의 패에 있는 다섯번째 카드를 버리셨습니다";
                button12.Text = "카드 버리기 \r\n" + --DeleteCardcount + "/3";
                textBox2.Text = Info_Card[4].Info_Hand = "";
                Card_FieldFull_Fieldnull(); button12.Visible = true;
            }
            if (button12.Enabled == false && e.Button == MouseButtons.Left && Handbool5 == 0)
            { textBox1.Text = "그곳에는 버릴 카드가 없습니다"; button12.Visible = true; button5.Enabled = true; }
        }
        private void FieldCard_Info1(object sender, MouseEventArgs e)
        {
            if(BattlePhase == 0)
            {
                textBox2.Text = "첫번째 필드 카드 정보\r\n";
                label33.Text = label11.Text; label34.Text = label12.Text;
                pictureBox11.Image = pictureBox1.Image; textBox2.Text += Info_Card[0].Info_Field;
                button1.Enabled = true; button2.Enabled = true; button3.Enabled = true;
                button4.Enabled = true; button5.Enabled = true;
            }
        }

        private void FieldCard_Info2(object sender, MouseEventArgs e)
        {
            if(BattlePhase == 0)
            {
                textBox2.Text = "두번째 필드 카드 정보\r\n";
                label33.Text = label13.Text; label34.Text = label14.Text;
                pictureBox11.Image = pictureBox2.Image; textBox2.Text += Info_Card[1].Info_Field;
                button1.Enabled = true; button2.Enabled = true; button3.Enabled = true;
                button4.Enabled = true; button5.Enabled = true;
            }
        }
        private void FieldCard_Info3(object sender, MouseEventArgs e)
        {
            if(BattlePhase == 0)
            {
                textBox2.Text = "세번째 필드 카드 정보\r\n";
                label33.Text = label15.Text; label34.Text = label16.Text;
                pictureBox11.Image = pictureBox3.Image; textBox2.Text += Info_Card[2].Info_Field;
                button1.Enabled = true; button2.Enabled = true; button3.Enabled = true;
                button4.Enabled = true; button5.Enabled = true;
            }
        }
        private void FieldCard_Info4(object sender, MouseEventArgs e)
        {
            if(BattlePhase == 0)
            {
                textBox2.Text = "네번째 필드 카드 정보\r\n";
                label33.Text = label17.Text; label34.Text = label18.Text;
                pictureBox11.Image = pictureBox4.Image; textBox2.Text += Info_Card[3].Info_Field;
                button1.Enabled = true; button2.Enabled = true; button3.Enabled = true;
                button4.Enabled = true; button5.Enabled = true;
            }
        }
        private void FieldCard_Info5(object sender, MouseEventArgs e)
        {
            if(BattlePhase == 0)
            {
                textBox2.Text = "다섯번째 필드 카드 정보\r\n";
                label33.Text = label19.Text; label34.Text = label20.Text;
                pictureBox11.Image = pictureBox5.Image; textBox2.Text += Info_Card[4].Info_Field;
                button1.Enabled = true; button2.Enabled = true; button3.Enabled = true;
                button4.Enabled = true; button5.Enabled = true;
            }
        }
        private void MagicClick(object sender, EventArgs e)
        { if (BattlePhase == 0) { Card_FieldFull_Fieldnull(); if (button12.Visible == false) button12.Visible = true; } }
        public Form1()
        {
            InitializeComponent();
            //나의 손패 체력, 공격력
            label1.Parent = button1; label1.Location = new Point(38, 179);
            label2.Parent = button1; label2.Location = new Point(112, 179);
            label3.Parent = button2; label3.Location = new Point(38, 179);
            label4.Parent = button2; label4.Location = new Point(112, 179);
            label5.Parent = button3; label5.Location = new Point(38, 179);
            label6.Parent = button3; label6.Location = new Point(112, 179);
            label7.Parent = button4; label7.Location = new Point(38, 179);
            label8.Parent = button4; label8.Location = new Point(112, 179);
            label9.Parent = button5; label9.Location = new Point(38, 179);
            label10.Parent = button5; label10.Location = new Point(112, 179);
            // 나의 필드 체력, 공격력
            label11.Parent = pictureBox1; label11.Location = new Point(38, 179);
            label12.Parent = pictureBox1; label12.Location = new Point(112, 179);
            label13.Parent = pictureBox2; label13.Location = new Point(38, 179);
            label14.Parent = pictureBox2; label14.Location = new Point(112, 179);
            label15.Parent = pictureBox3; label15.Location = new Point(38, 179);
            label16.Parent = pictureBox3; label16.Location = new Point(112, 179);
            label17.Parent = pictureBox4; label17.Location = new Point(38, 179);
            label18.Parent = pictureBox4; label18.Location = new Point(112, 179);
            label19.Parent = pictureBox5; label19.Location = new Point(38, 179);
            label20.Parent = pictureBox5; label20.Location = new Point(112, 179);
            //AI 필드 체력, 공격력
            label21.Parent = pictureBox6; label21.Location = new Point(38, 179);
            label22.Parent = pictureBox6; label22.Location = new Point(112, 179);
            label23.Parent = pictureBox7; label23.Location = new Point(38, 179);
            label24.Parent = pictureBox7; label24.Location = new Point(112, 179);
            label25.Parent = pictureBox8; label25.Location = new Point(38, 179);
            label26.Parent = pictureBox8; label26.Location = new Point(112, 179);
            label27.Parent = pictureBox9; label27.Location = new Point(38, 179);
            label28.Parent = pictureBox9; label28.Location = new Point(112, 179);
            label29.Parent = pictureBox10; label29.Location = new Point(38, 179);
            label30.Parent = pictureBox10; label30.Location = new Point(112, 179);
            //카드 정보 불러오기 칸 체력, 공격력
            label33.Parent = pictureBox11; label33.Location = new Point(38, 179);
            label34.Parent = pictureBox11; label34.Location = new Point(112, 179);
        }
    }
}
