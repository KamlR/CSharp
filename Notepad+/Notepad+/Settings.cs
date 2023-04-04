using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Notepad_
{
    public partial class AutoSet : Form
    {
        // номер выбранной настройки.
        int number;
        // сслылка на передачу данных второй форме
        Notepad notepad;

        /// <summary>
        /// Конструктор формы.
        /// </summary>
        /// <param name="form">ссылка на 1 форму</param>
        public AutoSet(Notepad form)
        {
            InitializeComponent();
            label2.Text = '0'.ToString();
            notepad = form;
        }

        /// <summary>
        /// Обработка информации с ползунка.
        /// </summary>
        /// <param name="sender">издатель события</param>
        /// <param name="e">информация о событии</param>
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label2.Text = trackBar1.Value.ToString();
        }

        /// <summary>
        /// Получение информации о нажатии 1 кнопки.
        /// </summary>
        /// <param name="sender">издатель события</param>
        /// <param name="e">информация о событии</param>
        private void button1_Click(object sender, EventArgs e)
        {
            number = int.Parse(label2.Text);
            notepad.Minutes = number;
            this.Close();
        }

        /// <summary>
        /// Получение информации о нажатии 2 кнопки.
        /// </summary>
        /// <param name="sender">издатель события</param>
        /// <param name="e">информация о событии</param>
        private void button2_Click(object sender, EventArgs e)
        {
            number = 0;
            notepad.Minutes = number;
            this.Close();
        }
    }
}
