/*Добромыслов
 * 2. Используя Windows Forms, разработать игру «Угадай число». 
 * Компьютер загадывает число от 1 до 100, а человек пытается его угадать за минимальное число попыток. 
 * Для ввода данных от человека используется элемент TextBox.*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace L7App02
{
    public partial class Form1 : Form
    {
        RandomNumber r;
        int max = 100;
        public Form1()
        {
            InitializeComponent();
            r = new RandomNumber();
            btnSubmit.Enabled = false;
            lblSteps.Visible = false;
            lblStepsText.Visible = false;
            textBox1.Enabled = false;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            r.StartGame(max);
            MessageBox.Show($"Игра началась. Загадано число от 1 до {max}", "Начало игры", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnSubmit.Enabled = true;
            lblSteps.Visible = true;
            lblStepsText.Visible = true;
            textBox1.Enabled = true;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            Game();
        }

        void Game()
        {
            if (r.Started)
            {
                int.TryParse(textBox1.Text, out int res);
                r.CheckNumber(res, out bool check, out string msg);
                textBox1.Text = "";
                if (check)
                {
                    MessageBox.Show(msg, "Победа!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    r.StopGame();
                }
                else
                {
                    MessageBox.Show(msg, "Неверно", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                FormUpdate();
            }
            else
            {
                MessageBox.Show("Для начала нужно начать игру!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                btnSubmit.Enabled = false;
                lblSteps.Visible = false;
                lblStepsText.Visible = false;
                textBox1.Enabled = false;
            }
        }
        
        void FormUpdate()
        {
            lblSteps.Text = r.Steps.ToString();
            Refresh();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                Game();
            }
        }
    }
}
