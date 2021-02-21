/*Добромыслов
1. а) Создать приложение, показанное на уроке, добавив в него защиту от возможных ошибок (не создана база данных, обращение к несуществующему вопросу, открытие слишком большого файла и т.д.).
    б) Изменить интерфейс программы, увеличив шрифт, поменяв цвет элементов и добавив другие «косметические» улучшения на свое усмотрение.
    в) Добавить в приложение меню «О программе» с информацией о программе (автор, версия,авторские права и др.).
    г) Добавить в приложение сообщение с предупреждением при попытке удалить вопрос.
    д) Добавить пункт меню Save As, в котором можно выбрать имя для сохранения базы данных (элемент SaveFileDialog).
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace L8App01
{
    public partial class Form1 : Form
    {
        private TrueFalse database;

        public Form1()
        {
            InitializeComponent();
            EnableButtons(false);
        }

        private void menuItemExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void menuItemNew_Click(object sender, EventArgs e)
        {
            SaveFileDialog s = new SaveFileDialog();
            s.Title = "Создать новый файл с вопросами";
            s.Filter = "Файлы с вопросами (*.xml)|*.xml|Все файлы (*.*)|*.*";
            if (s.ShowDialog() == DialogResult.OK)
            {
                database = new TrueFalse(s.FileName);
                database.Add("Земля круглая?", true);
                database.Save();

                nudNumber.Minimum = 1;
                nudNumber.Maximum = 1;
                nudNumber.Value = 1;

                EnableButtons(true);
            }
        }

        private void menuItemOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog o = new OpenFileDialog();
            o.Title = "Открыть файл с вопросами";
            o.Filter = "Файлы с вопросами (*.xml)|*.xml|Все файлы (*.*)|*.*";
            if (o.ShowDialog() == DialogResult.OK)
            {
                database = new TrueFalse(o.FileName);
                database.Load();

                nudNumber.Minimum = 1;
                nudNumber.Maximum = database.Count;
                nudNumber.Value = 1;

                if (database.Count != 0)
                {
                    tbQuestion.Text = database[0].Text;
                    cbTrue.Checked = database[0].TrueFalse;
                }

                EnableButtons(true);

            }
        }

        private void menuItemSave_Click(object sender, EventArgs e)
        {
            if (database != null)
            {
                database.Save();
            }
            else
            {
                MessageBox.Show("Вы попытались сохранить пустую базу вопросов", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void nudNumber_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                tbQuestion.Text = database[(int)nudNumber.Value - 1].Text;
                cbTrue.Checked = database[(int)nudNumber.Value - 1].TrueFalse;
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show($"Подробности: {ex.Message}", "Данный вопрос отсутствует");
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (database == null)
            {
                MessageBox.Show("Попытка записи вопроса в несуществующую базу. Сначала откройте или создайте новую базу вопросов.", "Сообщение");
                return;
            }
            database.Add(((int)nudNumber.Maximum + 1).ToString(), true);
            nudNumber.Maximum = database.Count;
            nudNumber.Value = database.Count;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (nudNumber.Maximum == 1 || database == null) return;
            DialogResult res = MessageBox.Show("Вы точно хотите удалить вопрос?", "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (res == DialogResult.Yes)
            {
                database.Remove((int)nudNumber.Value - 1);
                nudNumber.Maximum--;
                if (nudNumber.Value > 1) nudNumber.Value = nudNumber.Value;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (database != null)
            {
                database[(int)nudNumber.Value - 1].Text = tbQuestion.Text;
                database[(int)nudNumber.Value - 1].TrueFalse = cbTrue.Checked;
            }
            else
            {
                MessageBox.Show("База данных не создана", "Сообщение");
            }
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Автор: Владимир Добромыслов\nСпециально для GeekBrains\n\n2021 год.", "О программе", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void cbTrue_CheckedChanged(object sender, EventArgs e)
        {
            if (cbTrue.Checked)
            {
                cbTrue.ForeColor = Color.DarkGreen;
            }
            else
            {
                cbTrue.ForeColor = Color.DarkRed;
            }
        }

        private void EnableButtons(bool state)
        {
            btnAdd.Enabled = state;
            btnDelete.Enabled = state;
            btnSave.Enabled = state;
            cbTrue.Enabled = state;
            nudNumber.Enabled = state;
        }

        private void menuItemSaveAs_Click(object sender, EventArgs e)
        {
            SaveFileDialog s = new SaveFileDialog();
            if (database == null)
            {
                MessageBox.Show("Вы попытались сохранить пустую базу вопросов", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            else
            {
                database.FileName = s.FileName;
                database.Save();
            }
            if (s.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
        }
    }
}
