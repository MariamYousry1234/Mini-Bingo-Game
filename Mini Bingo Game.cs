using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mini_Bingo_Game
{
    public partial class MiniBingoGame : Form
    {
        public MiniBingoGame()
        {
            InitializeComponent();
        }

        List<Button> Buttons = new List<Button>();
        int CardsNumber = 25;
        int RowColumnFinished = 0;
        int TimeSeconds = 60;
        Random rn = new Random();


        void Reset()
        {
            GetButtons();

            foreach(Button btn in Buttons)
            {
                btn.BackColor = Color.Aqua;
            }
            SetRandomNumbersToButtons();
            listBox1.Items.Clear();
            timer1.Start();
            RowColumnFinished = 0;
            TimeSeconds=60;

            lblB.Enabled = true;
            lblI.Enabled = true;
            lblN.Enabled = true;
            lblG.Enabled = true;
            lblO.Enabled = true;

        }
        void GetButtons()
        {
            Buttons.AddRange(new Button[] {button1,button2,button3,button4,button5,button6,
            button7,button8,button9,button10,button11,button12,button13,
            button14,button15,button16,button17,button18,button19,button20,
            button21,button22,button23,button24,button25});
        }

        void NumberToButton(int Number)
        {
            int index= rn.Next(0, Buttons.Count);

            Buttons[index].Text = Number.ToString();
            Buttons[index].Tag = Number;

            Buttons.RemoveAt(index);
        }
      
        void SetRandomNumbersToButtons()
        {

            for (int i = 1; i <= CardsNumber; i++) 
            {
                NumberToButton(i);
            }

        }


        int GetRandomNumber()
        {
            return  rn.Next(1, CardsNumber+1);
        }


        bool IsRowColumnFinished(Button btn1,Button btn2,Button btn3,Button btn4,Button btn5)
        {
            if (btn1.BackColor == Color.Red &&
               btn2.BackColor == Color.Red &&
             btn3.BackColor == Color.Red &&
             btn4.BackColor == Color.Red &&
            btn5.BackColor == Color.Red)
                return false;

            return (btn1.BackColor == Color.Green ||  btn1.BackColor ==Color.Red) &&
                  ( btn2.BackColor == Color.Green  ||  btn2.BackColor == Color.Red) &&
                  (btn3.BackColor == Color.Green  ||  btn3.BackColor == Color.Red) &&
                 (btn4.BackColor == Color.Green   ||  btn4.BackColor == Color.Red) &&
                 (btn5.BackColor == Color.Green   ||  btn5.BackColor == Color.Red);

        }

        void ConvertToRedBackground(Button btn1, Button btn2, Button btn3, Button btn4, Button btn5)
        {
            btn1.BackColor = Color.Red;
            btn2.BackColor = Color.Red;
            btn3.BackColor = Color.Red;
            btn4.BackColor = Color.Red;
            btn5.BackColor = Color.Red;
        }

        string TimePlayerFinshedGame()
        {
            int Time = 60 - TimeSeconds;

            int Minutes = 0, Seconds = 0;

            Minutes = Time / 60;
            Seconds = Time % 60;

            return $"{Minutes:D2} :{Seconds:D2}";
        }
        void EndGame()
        {
            if(RowColumnFinished == 5)
            {
                timer1.Stop();
                if(MessageBox.Show($"Perfect, you got it in {TimePlayerFinshedGame()}\nDo you want to paly again? ","You win",MessageBoxButtons.OKCancel)==DialogResult.OK)
                {
                    Reset();
                }
            }
        }
        void UpdateBINGOWord()
        {
            switch(RowColumnFinished)
            {
                case 1:
                    lblB.Enabled = false;
                    break;

                case 2:
                    lblI.Enabled = false;
                    break;

                case 3:
                    lblN.Enabled = false;
                    break;


                case 4:
                    lblG.Enabled = false;
                    break;

                case 5:
                    lblO.Enabled = false;
                    break;

            }

            EndGame();
        }
        void RowsColumnsFinished(Button btn1, Button btn2, Button btn3, Button btn4, Button btn5)
        {
            RowColumnFinished++;

            ConvertToRedBackground(btn1, btn2, btn3, btn4, btn5);

            UpdateBINGOWord();
        }

   
        void CheckRowsAndColumns()
        {
            
            if (IsRowColumnFinished(button1,button2,button3,button4,button5))
            {
                RowsColumnsFinished(button1, button2, button3, button4, button5);
                return;
            }

            if (IsRowColumnFinished(button6, button7, button8, button9, button10))
            {
                RowsColumnsFinished(button6, button7, button8, button9, button10);
                return;
            }

            if (IsRowColumnFinished(button11, button12, button13, button14, button15))
            {
                RowsColumnsFinished(button11, button12, button13, button14, button15);
                return;
            }

            if (IsRowColumnFinished(button16, button17, button18, button19, button20))
            {
                RowsColumnsFinished(button16, button17, button18, button19, button20);
                return;
            }

            if (IsRowColumnFinished(button21, button22, button23, button24, button25))
            {
                RowsColumnsFinished(button21, button22, button23, button24, button25);
                return;
            }

            if (IsRowColumnFinished(button1, button6, button11, button16, button21))
            {
                RowsColumnsFinished(button1, button6, button11, button16, button21);
                return;
            }

            if (IsRowColumnFinished(button2, button7, button12, button17, button22))
            {
                RowsColumnsFinished(button2, button7, button12, button17, button22);
                return;
            }

            if (IsRowColumnFinished(button3, button8, button13, button18, button23))
            {
                RowsColumnsFinished(button3, button8, button13, button18, button23);
                return;
            }


            if (IsRowColumnFinished(button4, button9, button14, button19, button24))
            {
                RowsColumnsFinished(button4, button9, button14, button19, button24);
                return;
            }

            if (IsRowColumnFinished(button5, button10, button15, button20, button25))
            {
                RowsColumnsFinished(button5, button10, button15, button20, button25);
                return;
            }

            if (IsRowColumnFinished(button1, button7, button13, button19, button25))
            {
                RowsColumnsFinished(button1, button7, button13, button19, button25);
                return;
            }

            if (IsRowColumnFinished(button5, button9, button13, button17, button21))
            {
                RowsColumnsFinished(button5, button9, button13, button17, button21);
                return;
            }
        }


        void ChangeBackground(int RandomNumber)
        {
            foreach (Button btn in Buttons)
            {
                if (Convert.ToSingle(btn.Tag) == RandomNumber )
                {
                    if (btn.BackColor == Color.Aqua)
                        btn.BackColor = Color.Green;   
              

                    CheckRowsAndColumns();
                    break;
                }
            }
        }
        void UpdateGame(int RandomNumber)
        {
            listBox1.Items.Add(RandomNumber);

            GetButtons();

            ChangeBackground(RandomNumber);
        }


        
        void UpdateTime()
        {
            TimeSeconds--;

            
            int Minutes=0, Seconds=0;

            Minutes = TimeSeconds / 60;
            Seconds = TimeSeconds % 60;

            lblTime.Text = $"{Minutes:D2} : {Seconds:D2}";

            if(TimeSeconds ==0)
            {
                timer1.Stop();
                MessageBox.Show("Time is up\nTry again");
                Reset();
            }
        }
        private void MiniBingoGame_Load(object sender, EventArgs e)
        {
            Reset();
        }

        private void btnRandomNumber_Click(object sender, EventArgs e)
        {
            UpdateGame(GetRandomNumber());
        }

        private void btnNewGame_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            UpdateTime();
        }
    }
}
