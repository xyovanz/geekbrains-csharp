/* Добромыслов
 * 1. а) Добавить в программу «Удвоитель» подсчет количества отданных команд.
б) Добавить меню и команду «Играть». При нажатии появляется сообщение, какое число должен получить игрок. 
Игрок должен постараться получить это число за минимальное количество ходов.
в) * Добавить кнопку «Отменить», которая отменяет последние ходы.*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lesson7
{
    public delegate void ClickCounter (object sender, EventArgs e);

    public partial class Form1 : Form
    {
        Doubler d;
        public Form1()
        {
            d = new Doubler();
            InitializeComponent();
            btnCommand1.Text = "+1";
            btnCommand2.Text = "x2";
            lblNumber.Text = "0";
            btnReset.Text = "Сброс";
            Text = "Удвоитель";
            lblGoal.Visible = false;
            lblGoalText.Visible = false;
            lblStepsCount.Text = "0";
        }
        
        /// <summary>
        /// Обновляет информацию в компонентах формы
        /// </summary>
        public void DoublerUpdate()
        {
            lblNumber.Text = d.Value.ToString();
            lblStepsCount.Text = d.Steps.ToString();
            Refresh();
            if (lblGoal.Visible)
            {
                if (d.CheckGoal())
                {
                    MessageBox.Show($"Вы достигли заданного числа за {d.Steps} ходов");
                    lblGoal.Visible = false;
                    lblGoalText.Visible = false;
                    d.Reset();
                }
            }
        }
        private void btnCommand1_Click(object sender, EventArgs e)
        {
            d.Plus();
            DoublerUpdate();
        }
        private void btnCommand2_Click(object sender, EventArgs e)
        {
            d.Double();
            DoublerUpdate();
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            d.Reset();
            DoublerUpdate();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            d.Return();
            DoublerUpdate();
        }

        private void menuStart_Click(object sender, EventArgs e)
        {
            d.Reset();
            d.GetGoal();
            MessageBox.Show($"Получите значение: {d.Goal}");
            lblGoal.Visible = true;
            lblGoalText.Visible = true;
            lblGoal.Text = d.Goal.ToString();
            d.Reset();
            Update();
        }

        private void menuStop_Click(object sender, EventArgs e)
        {
            d.Reset();
            DoublerUpdate();
            lblGoal.Visible = false;
            lblGoalText.Visible = false;
        }

        private void menuCancel_Click(object sender, EventArgs e)
        {
            d.Return();
            DoublerUpdate();
        }
    }
}
