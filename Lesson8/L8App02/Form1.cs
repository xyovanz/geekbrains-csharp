/*Добромыслов
 2. Используя полученные знания и класс TrueFalse, разработать игру «Верю — не верю».*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Timers;

namespace L8App02
{
    public partial class Form1 : Form
    {
        private TrueFalse database;
        private int score = 0;
        private Question q;
        int n = 5;

        public Form1()
        {
            InitializeComponent();
            EnableButtons(false);
            database = new TrueFalse(AppDomain.CurrentDomain.BaseDirectory + "questions.xml");
            database.Load();
            lblScore.Text = score.ToString();

            EnableButtons(false);
        }


        private void tsbtnNewGame_Click(object sender, EventArgs e)
        {
            if (database.Count != 0)
            {
                PlayGame(ref n);
                EnableButtons(true);
                lblQuestionsCount.Text = n.ToString();
            }
        }

        private void tsbtnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            CheckAnswer(true, out bool check);

            if (check)
            {
                FlashButton(true);
            }
            else
            {
                FlashButton(false);
            }
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            CheckAnswer(false, out bool check);

            if (check)
            {
                FlashButton(false);
            }
            else
            {
                FlashButton(true);
            }
        }

        private void EnableButtons(bool state)
        {
            btnYes.Enabled = state;
            btnNo.Enabled = state;
        }

        private void PlayGame(ref int n)
        {
            if (n > 0)
            {
                Random r = new Random();
                int i = r.Next(database.Count);
                q = database[i];
                tbQuestion.Text = q.Text;
            }
            if (n <= 0)
            {
                MessageBox.Show($"Ваш итоговый счет: {score}", "Конец игры", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                tbQuestion.Text = $"Ваш итоговый счет: {score}. Спасибо за игру";
            }
        }

        private void CheckAnswer(bool answer, out bool check)
        {
            check = true;
            if (n > 0)
            {
                if (answer == q.TrueFalse)
                {
                    score++;
                    check = true;
                }
                else
                {
                    check = false;
                }

                lblScore.Text = score.ToString();
                n--;
                lblQuestionsCount.Text = n.ToString();
                PlayGame(ref n);
            }
            if (n == 0)
            {
                EnableButtons(false);
                MessageBox.Show($"Игра закончена. Начните новую игру.", "Конец игры", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void FlashButton(bool check)
        {
            Color yesColor = btnYes.BackColor;
            Color noColor = btnNo.BackColor;
            Color flashColor = Color.Green;

            System.Timers.Timer t = new System.Timers.Timer(1000);
            t.Interval = 500;
            t.Enabled = true;

            if (check)
            {
                btnYes.BackColor = Color.DarkGreen;
                t.Elapsed += new ElapsedEventHandler(FlashYes);
            }
            else
            {
                btnNo.BackColor = Color.DarkRed;
                t.Elapsed += new ElapsedEventHandler(FlashNo);
            }
        }

        void FlashYes(object sender, EventArgs e)
        {
            btnYes.BackColor = Color.LimeGreen;
        }
        void FlashNo(object sender, EventArgs e)
        {
            btnNo.BackColor = Color.OrangeRed;
        }
    }
}
