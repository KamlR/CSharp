using System;
using System.IO;
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
    public partial class Notepad : Form
    {
        // Интервал для таймера.
        public int Minutes;
        // Переменные отвечают за смену стиля текста.
        bool flag1, flag2, flag3, flag4;
        // Список всех вкладок.
        List<TabPage> tabs = new List<TabPage>();
        // Список названий вкладок.
        List<string> fullnames = new List<string>();
        // Список изменений , которые происходят в каждом richTextBox.
        List<bool> changes = new List<bool>();
        // Цветовая схема приложения.
        Color color;
        // Пути для сохранения файлов.
        string paths;

        /// <summary>
        /// Конструктор класса.
        /// </summary>
        public Notepad()
        {
            InitializeComponent();
            saveFileDialog1.Filter = "Text file(*.txt) | *.txt|Text file(*.rtf) | *.rtf";
        }

        /// <summary>
        /// Событие, которое обрабатывется до появления формы.
        /// В данном случае тут подгружаются все настройки.
        /// </summary>
        /// <param name="sender"> издатель события </param>
        /// <param name="e"> информация о событии </param>
        private void Notepad1_Load(object sender, EventArgs e)
        {
            try
            {
                color = Properties.Settings.Default.Colorback;
                Minutes = Properties.Settings.Default.Minutes;
                paths = Properties.Settings.Default.Filepaths;
                menuStrip1.BackColor = color;
                int counter = 0;
                if (paths != "")
                {
                    paths = paths.Remove(paths.Length - 1);
                    string[] pathsNames = paths.Split(';');
                    foreach (var item in pathsNames)
                    {
                        if (File.Exists(item))
                        {
                            TabPage tabPage = new TabPage(Path.GetFileName(item));
                            RichTextBox richTextBox = new RichTextBox();
                            richTextBox.TextChanged += RichTextBox_TextChanged;
                            tabs.Add(tabPage);
                            fullnames.Add(tabPage.Text);
                            changes.Add(true);
                            richTextBox.Dock = DockStyle.Fill;
                            tabPage.Controls.Add(richTextBox);
                            tabControl1.TabPages.Add(tabPage);
                            richTextBox.BackColor = color;
                            Menu(richTextBox);
                            OpenTransfer(richTextBox, item, counter);
                            counter += 1;
                        }
                    }
                }
                else
                {
                    NewTabToolStripMenuItem_Click(sender, e);
                }
                if (Minutes > 0)
                {
                    MessageBox.Show($"Напоминаем, что интервал автосохранения равен {Minutes * 60} секундам");
                    timer1.Interval = Minutes * 60000;
                    timer1.Start();
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Возникли проблемы с работой Notepad +");
            }
        }

        /// <summary>
        /// Событие направлено на сохранение нового файла.
        /// </summary>
        /// <param name="sender">издатель события</param>
        /// <param name="e">информация о событии</param>
        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                RichTextBox richTextBox = (RichTextBox)tabControl1.SelectedTab.Controls[0];
                if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                    return;
                StreamWriter sw = new StreamWriter(saveFileDialog1.FileName);

                if (Path.GetExtension(saveFileDialog1.FileName) == ".rtf")
                    sw.WriteLine(richTextBox.Rtf);
                else
                    sw.WriteLine(richTextBox.Text);
                sw.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Возникли проблемы с файлом!");
            }
        }

        /// <summary>
        /// Событие реализует открытие заданного файла.
        /// </summary>
        /// <param name="sender"> издатель события </param>
        /// <param name="e"> информация о событии </param>
        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                RichTextBox richTextBox = (RichTextBox)tabControl1.SelectedTab.Controls[0];
                if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                    return;
                string filename = openFileDialog1.FileName;
                if (Path.GetExtension(filename) == ".rtf")
                {
                    richTextBox.LoadFile(filename);
                }
                else
                {
                    string filetext;
                    using (StreamReader sr = new StreamReader(filename, Encoding.UTF8))
                    {
                        filetext = sr.ReadToEnd();
                        richTextBox.Text = filetext;
                    }
                }
                string newFilename = Path.GetFileName(filename);
                tabControl1.SelectedTab.Text = newFilename;
                fullnames[tabControl1.SelectedIndex] = filename;
                changes[tabControl1.SelectedIndex] = false;

            }
            catch (Exception)
            {
                MessageBox.Show("Возникли проблемы с файлом!");
            }
        }

        /// <summary>
        /// Событие направлено на вырезку текста.
        /// </summary>
        /// <param name="sender"> издатель события </param>
        /// <param name="e"> информация о событии </param>
        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                RichTextBox richTextBox = (RichTextBox)tabControl1.SelectedTab.Controls[0];
                if (richTextBox.TextLength > 0)
                    richTextBox.Cut();
                else
                    MessageBox.Show("В поле не найдено симолов!");
            }
            catch(Exception)
            {
                MessageBox.Show("Возникли проблемы с вырезкой текста!");
            }
        }

        /// <summary>
        /// Событие обрабатывает копирование текста. 
        /// </summary>
        /// <param name="sender"> издатель события </param>
        /// <param name="e"> информация о событии </param>
        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                RichTextBox richTextBox = (RichTextBox)tabControl1.SelectedTab.Controls[0];
                if (richTextBox.TextLength > 0)
                    richTextBox.Copy();
                else
                    MessageBox.Show("В поле не найдено симолов!");
            }
            catch (Exception)
            {
                MessageBox.Show("Возникли проблемы с копированием текста!");
            }
        }

        /// <summary>
        /// Событие обрабатывает вставку текста.
        /// </summary>
        /// <param name="sender"> издатель события </param>
        /// <param name="e"> информация о событии </param>
        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                RichTextBox richTextBox = (RichTextBox)tabControl1.SelectedTab.Controls[0];
                richTextBox.Paste();
            }
            catch (Exception)
            {
                MessageBox.Show("Возникли проблемы с вставкой текста!");
            }
        }

        /// <summary>
        /// Событие обрабатывает установку шрифта.
        /// </summary>
        /// <param name="sender"> издатель события </param>
        /// <param name="e"> информация о событии </param>
        private void SetFontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                RichTextBox richTextBox = (RichTextBox)tabControl1.SelectedTab.Controls[0];
                fontDialog1.ShowDialog();
                richTextBox.Font = fontDialog1.Font;
            }
            catch (Exception)
            {
                MessageBox.Show("Возникли проблемы с установкой шрифта!");
            }
        }

        /// <summary>
        /// Событие обрабатывает установку цветовой схемы приложения.
        /// </summary>
        /// <param name="sender"> издатель события </param>
        /// <param name="e"> информация о событии </param>
        private void SetColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {

                colorDialog1.ShowDialog();
                color = colorDialog1.Color;
                foreach (var item in tabs)
                {
                    tabControl1.SelectedTab = item;
                    RichTextBox richTextBox = (RichTextBox)tabControl1.SelectedTab.Controls[0];
                    richTextBox.BackColor = color;
                }
                menuStrip1.BackColor = color;
            }
            catch (Exception)
            {
                MessageBox.Show("Возникли проблемы с установкий цвета!");
            }

        }

        /// <summary>
        /// Обработка выделения всего текста.
        /// </summary>
        /// <param name="sender"> издатель события </param>
        /// <param name="e"> информация о событии </param>
        private void SelectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                RichTextBox richTextBox = (RichTextBox)tabControl1.SelectedTab.Controls[0];
                if (richTextBox.TextLength > 0)
                    richTextBox.SelectAll();
                else
                    MessageBox.Show("В поле не найдено симолов!");
            }
            catch (Exception)
            {
                MessageBox.Show("Возникли проблемы с выделением текста!");
            }
        }

        /// <summary>
        /// Обработка очищения формы.
        /// </summary>
        /// <param name="sender"> издатель события </param>
        /// <param name="e"> информация о событии </param>
        private void ClearAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                RichTextBox richTextBox = (RichTextBox)tabControl1.SelectedTab.Controls[0];
                richTextBox.Clear();
            }
            catch (Exception)
            {
                MessageBox.Show("Возникли проблемы с очисткой текста!");
            }
        }

        /// <summary>
        /// Создание новой вкладки и привязка к ней richTextBox.
        /// </summary>
        /// <param name="sender"> издатель события </param>
        /// <param name="e"> информация о событии </param>
        public void NewTabToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                TabPage tabPage = new TabPage("New document");
                RichTextBox richTextBox = new RichTextBox();
                richTextBox.TextChanged += RichTextBox_TextChanged;
                tabs.Add(tabPage);
                fullnames.Add(tabPage.Text);
                changes.Add(false);
                richTextBox.Dock = DockStyle.Fill;
                tabPage.Controls.Add(richTextBox);
                tabControl1.TabPages.Add(tabPage);
                richTextBox.BackColor = color;
                Menu(richTextBox);
            }
            catch(Exception)
            {
                MessageBox.Show("Возникли проблемы с созданием новой вкладки!");
            }
        }

        /// <summary>
        /// Обрабатывает информацию об изменениях в тексте.
        /// </summary>
        /// <param name="sender"> издатель события </param>
        /// <param name="e"> информация о событии </param>
        private void RichTextBox_TextChanged(object sender, EventArgs e)
        {
            RichTextBox richTextBox = (RichTextBox)tabControl1.SelectedTab.Controls[0];
            changes[tabControl1.SelectedIndex] = true;
        }

        /// <summary>
        /// Создание контекстного меню и привязка к richTextBox.
        /// </summary>
        /// <param name="richTextBox"> richTextBox , с которым ведётся работа</param>
        private void Menu(RichTextBox richTextBox)
        {
            richTextBox.ContextMenuStrip = new ContextMenuStrip();
            ToolStripMenuItem selectAll = new ToolStripMenuItem("Выбрать всё");
            ToolStripMenuItem cutText = new ToolStripMenuItem("Вырезать");
            ToolStripMenuItem copyText = new ToolStripMenuItem("Копировать");
            ToolStripMenuItem pasteText = new ToolStripMenuItem("Вставить");
            ToolStripMenuItem italic = new ToolStripMenuItem("Курсив");
            ToolStripMenuItem bold = new ToolStripMenuItem("Жирный");
            ToolStripMenuItem underline = new ToolStripMenuItem("Подчёркнутый");
            ToolStripMenuItem stricked = new ToolStripMenuItem("Зачёркнутый");
            richTextBox.ContextMenuStrip.Items.AddRange(new[] { selectAll, cutText, copyText, pasteText, italic, bold, underline, stricked });
            selectAll.Click += SelectAllToolStripMenuItem_Click;
            cutText.Click += CutToolStripMenuItem_Click;
            copyText.Click += CopyToolStripMenuItem_Click;
            pasteText.Click += PasteToolStripMenuItem_Click;
            italic.Click += ItalicsToolStripMenuItem_Click;
            bold.Click += BoldToolStripMenuItem_Click;
            underline.Click += UnderlinedToolStripMenuItem_Click;
            stricked.Click += CrossedToolStripMenuItem_Click;
        }

        /// <summary>
        /// Задаётся курсивный стиль текста.
        /// </summary>
        /// <param name="sender"> издатель события </param>
        /// <param name="e"> информация о событии </param>
        private void ItalicsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RichTextBox richTextBox = (RichTextBox)tabControl1.SelectedTab.Controls[0];
            if (flag1 == false)
            {
                richTextBox.SelectionFont = new Font(richTextBox.Font, FontStyle.Italic | richTextBox.SelectionFont.Style);
                flag1 = true;
            }
            else
            {
                richTextBox.SelectionFont = new Font(richTextBox.SelectionFont, richTextBox.SelectionFont.Style & ~FontStyle.Italic);
                flag1 = false;
            }
        }

        /// <summary>
        /// Задаётся жирный стиль текста.
        /// </summary>
        /// <param name="sender"> издатель события </param>
        /// <param name="e"> информация о событии </param>
        private void BoldToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RichTextBox richTextBox = (RichTextBox)tabControl1.SelectedTab.Controls[0];
            if (flag2 == false)
            {
                richTextBox.SelectionFont = new Font(richTextBox.Font, FontStyle.Bold | richTextBox.SelectionFont.Style);
                flag2 = true;
            }
            else
            {
                richTextBox.SelectionFont = new Font(richTextBox.SelectionFont, richTextBox.SelectionFont.Style & ~FontStyle.Bold);
                flag2 = false;
            }
        }

        /// <summary>
        /// Задаётся подчёркнутый стиль текста.
        /// </summary>
        /// <param name="sender"> издатель события </param>
        /// <param name="e"> информация о событии </param>
        private void UnderlinedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RichTextBox richTextBox = (RichTextBox)tabControl1.SelectedTab.Controls[0];
            if (flag3 == false)
            {
                richTextBox.SelectionFont = new Font(richTextBox.Font, FontStyle.Underline | richTextBox.SelectionFont.Style);
                flag3 = true;
            }
            else
            {
                richTextBox.SelectionFont = new Font(richTextBox.SelectionFont, richTextBox.SelectionFont.Style & ~FontStyle.Underline);
                flag3 = false;
            }
        }

        /// <summary>
        /// Задаётся зачёркнутый стиль текста.
        /// </summary>
        /// <param name="sender"> издатель события </param>
        /// <param name="e"> информация о событии </param>
        private void CrossedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RichTextBox richTextBox = (RichTextBox)tabControl1.SelectedTab.Controls[0];
            if (flag4 == false)
            {
                richTextBox.SelectionFont = new Font(richTextBox.Font, FontStyle.Strikeout | richTextBox.SelectionFont.Style);
                flag4 = true;
            }
            else
            {
                richTextBox.SelectionFont = new Font(richTextBox.SelectionFont, richTextBox.SelectionFont.Style & ~FontStyle.Strikeout);
                flag4 = false;
            }
        }

        /// <summary>
        /// Возвращение стиля текста к дефолтному.
        /// Использование переменных, назначение которых описано в самом начале.
        /// </summary>
        /// <param name="sender"> издатель события </param>
        /// <param name="e"> информация о событии </param>
        private void DefaultFontToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            RichTextBox richTextBox = (RichTextBox)tabControl1.SelectedTab.Controls[0];
            richTextBox.SelectionFont = new Font(richTextBox.SelectionFont, FontStyle.Regular);
            flag1 = false;
            flag2 = false;
            flag3 = false;
            flag4 = false;
        }

        /// <summary>
        /// Реализуется передача информации об автосохранении.
        /// </summary>
        /// <param name="sender"> издатель события </param>
        /// <param name="e"> информация о событии </param>
        private void AutoSaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                AutoSet newOne = new AutoSet(this);
                newOne.ShowDialog();
                if (Minutes == 0)
                {
                    MessageBox.Show("Вы выбрали интревал для автосохранения равным 0" + Environment.NewLine +
                        "Открытые файлы не будут автоматически сохранятся!", "Предупреждение");
                    return;
                }
                else
                {
                    MessageBox.Show($"Окртые файлы будут сохранятся через каждые {Minutes * 60} секунд");
                    timer1.Interval = Minutes * 60000;
                    timer1.Start();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Возникли проблемы с созданием нового окна!");
            }
        }

        /// <summary>
        /// Автосохранение файлов по таймеру.
        /// </summary>
        /// <param name="sender"> издатель события </param>
        /// <param name="e"> информация о событии </param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                int count = 0;
                foreach (var item in tabs)
                {
                    tabControl1.SelectedTab = item;
                    RichTextBox richTextBox = (RichTextBox)tabControl1.SelectedTab.Controls[0];
                    if (item.Text != "New document" & File.Exists(fullnames[count]))
                    {
                        if (changes[count] == true)
                        {
                            HelpWithUpdate(richTextBox, fullnames[count]);
                            changes[count] = false;
                        }
                    }
                    count += 1;
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Возникли проблемы с работой таймера!");
            }
        }

        /// <summary>
        /// Релизуется обработка каждой вкладки.
        /// Получение информации о тексте, имени и об изменениях.
        /// Обработчик закрытия приложения.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                // Счётчик для перебора полных путей файлов.
                int count = 0;
                // Хранение путей для передачи настроек.
                string transfernames = "";
                foreach (var item in tabs)
                {
                    tabControl1.SelectedTab = item;
                    RichTextBox richTextBox = (RichTextBox)tabControl1.SelectedTab.Controls[0];
                    if (item.Text == "New document" & richTextBox.TextLength != 0)
                    {
                        item.Show();
                        DialogResult dialog = MessageBox.Show("Сохранить внесённые изменения?", "Предупреждение",
                            MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
                        if (dialog == DialogResult.Yes)
                        {
                            HelpWithSaving(richTextBox, out string filepath);
                            transfernames += filepath + ';';
                        }
                        else if (dialog == DialogResult.Cancel)
                        {
                            e.Cancel = true;
                            return;
                        }
                    }
                    else if (item.Text != "New document")
                    {
                        if (changes[count] == true)
                        {
                            item.Show();
                            DialogResult dialog = MessageBox.Show("Сохранить внесённые изменения?", "Предупреждение",
                                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
                            if (dialog == DialogResult.Yes)
                            {
                                if (File.Exists(fullnames[count]))
                                {
                                    HelpWithUpdate(richTextBox, fullnames[count]);
                                    transfernames += fullnames[count] + ';';
                                }
                                else
                                {
                                    int number = Error(richTextBox);
                                    if (number == 0)
                                    {
                                        e.Cancel = true;
                                        return;
                                    }
                                }
                            }
                            else if (dialog == DialogResult.Cancel)
                            {
                                e.Cancel = true;
                                return;
                            }
                        }
                        else
                        {
                            if (File.Exists(fullnames[count]))
                                transfernames += fullnames[count] + ';';
                        }
                    }

                    count += 1;
                }
                Transfers(transfernames, color, Minutes);
                Application.ExitThread();
            }
            catch (Exception)
            {
                MessageBox.Show("Возникли проблемы пи закрытии приложения!");
            }
        }

        /// <summary>
        /// Обработчик нажатия горячих клавиш.
        /// </summary>
        /// <param name="sender"> издатель события </param>
        /// <param name="e"> информация о событии </param>
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Control && e.KeyCode == Keys.T)
                    NewTabToolStripMenuItem_Click(sender, e);
                else if (e.Control && e.KeyCode == Keys.O)
                    OpenToolStripMenuItem_Click(sender, e);
                else if (e.Control && e.KeyCode == Keys.S)
                    SaveToolStripMenuItem_Click(sender, e);
                else if (e.Control && e.KeyCode == Keys.K)
                    SaveAsToolStripMenuItem_Click(sender, e);
                else if (e.Control && e.KeyCode == Keys.W)
                    NewWindowCtrlWToolStripMenuItem_Click(sender, e);
                else if (e.Control && e.KeyCode == Keys.E)
                    Form1_FormClosing(sender, null);
                else if (e.Control && e.KeyCode == Keys.P)
                    SaveAllOpenDocumentsCtrlRToolStripMenuItem_Click(sender, e);
            }
            catch (Exception)
            {
                MessageBox.Show("Возникли проблемы с работой горячих клавиш!");
            }
        }

        /// <summary>
        /// Реализуется обработка сохранения файла.
        /// </summary>
        /// <param name="sender"> издатель события </param>
        /// <param name="e"> информация о событии </param>
        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                RichTextBox richTextBox = (RichTextBox)tabControl1.SelectedTab.Controls[0];
                string path = fullnames[tabControl1.SelectedIndex];
                if (tabControl1.SelectedTab.Text == "New document" | !(File.Exists(path)))
                {
                    DialogResult dialog = MessageBox.Show("Такого файла не существует" + Environment.NewLine +
                        "Хотите воспользоваться функцией СОХРАНИТЬ КАК?", "Предупреждение",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dialog == DialogResult.Yes)
                        HelpWithSaving(richTextBox, out string namefile);
                }
                else
                {
                    HelpWithUpdate(richTextBox, path);
                    changes[tabControl1.SelectedIndex] = true;
                }
            }
            catch
            {
                MessageBox.Show("Возникли проблемы с сохранением файла!");
            }
        }

        /// <summary>
        /// Создание нового окна.
        /// </summary>
        /// <param name="sender"> издатель события </param>
        /// <param name="e"> информация о событии </param>
        private void NewWindowCtrlWToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Notepad form1 = new Notepad();
                form1.Show();
            }
            catch (Exception)
            {
                MessageBox.Show("Возникла проблема с новым окном!");
            }
        }

        /// <summary>
        /// Сохранение всех открытых документов.
        /// </summary>
        /// <param name="sender"> издатель события </param>
        /// <param name="e"> информация о событии </param>
        private void SaveAllOpenDocumentsCtrlRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int count = 0;
                foreach (var item in tabs)
                {
                    tabControl1.SelectedTab = item;
                    RichTextBox richTextBox = (RichTextBox)tabControl1.SelectedTab.Controls[0];
                    string path = fullnames[count];
                    if (tabControl1.SelectedTab.Text == "New document" | !(File.Exists(path)))
                    {
                        item.Show();
                        DialogResult dialog = MessageBox.Show("Такого файла не существует" + Environment.NewLine +
                            "Хотите воспользоваться функцией СОХРАНИТЬ КАК?", "Предупреждение",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (dialog == DialogResult.Yes)
                            HelpWithSaving(richTextBox, out string namefile);
                    }
                    else
                    {
                        HelpWithUpdate(richTextBox, path);
                    }
                    count += 1;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Возникли проблемы с сохранением файлов!");
            }
        }

        /// <summary>
        /// Метод реализует сохранение файла.
        /// </summary>
        /// <param name="richTextBox"> получение данных с конкретного richTextBox</param>
        /// <param name="filepath"> получение на выходн данных о пути к файлу</param>
        private void HelpWithSaving(RichTextBox richTextBox, out string filepath)
        {
            filepath = "";
            try
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                    return;
                filepath = saveFileDialog1.FileName;
                StreamWriter sw = new StreamWriter(filepath);
                if (Path.GetExtension(filepath) == ".rtf")
                    sw.WriteLine(richTextBox.Rtf);
                else
                    sw.WriteLine(richTextBox.Text);
                sw.Close();
            }
            catch (Exception)
            {

                MessageBox.Show("Возникли проблемы с сохранением!");
            }
        }

        /// <summary>
        /// Сохранение всех изменений в файле.
        /// </summary>
        /// <param name="richTextBox">получение данных с конкретного richTextBox</param>
        /// <param name="name">получение имени файла</param>
        private void HelpWithUpdate(RichTextBox richTextBox, string name)
        {
            try
            {
                StreamWriter sw = new StreamWriter(name);
                if (Path.GetExtension(name) == ".rtf")
                    sw.WriteLine(richTextBox.Rtf);
                else
                    sw.WriteLine(richTextBox.Text);
                sw.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Возникли проблемы с сохранением!");
            }
        }

        /// <summary>
        /// Обработка закрытия вклакди.
        /// </summary>
        /// <param name="sender">издатель события</param>
        /// <param name="e">информация о событии</param>
        private void TabCloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                RichTextBox richTextBox = (RichTextBox)tabControl1.SelectedTab.Controls[0];
                if (changes[tabControl1.SelectedIndex])
                {
                    DialogResult dialog = MessageBox.Show("В данном файле есть несохранённые изменения" +
                        Environment.NewLine + "Хотите их сохранить?", "Предупреждение", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
                    if (dialog == DialogResult.Yes & tabControl1.SelectedTab.Text != "New document" & File.Exists(fullnames[tabControl1.SelectedIndex]))
                    {
                        HelpWithUpdate(richTextBox, fullnames[tabControl1.SelectedIndex]);
                        DeleteLists(sender, e);
                    }
                    else if (dialog == DialogResult.Yes & tabControl1.SelectedTab.Text == "New document")
                    {
                        HelpWithSaving(richTextBox, out string namefile);
                        DeleteLists(sender, e);
                    }
                    else if (dialog == DialogResult.Yes & tabControl1.SelectedTab.Text != "New document" & !File.Exists(fullnames[tabControl1.SelectedIndex]))
                        DeleteLists(sender, e);
                    else if (dialog == DialogResult.No)
                        DeleteLists(sender, e);
                }
                else
                    DeleteLists(sender, e);
            }
            catch (Exception)
            {
                MessageBox.Show("Возникли проблемы с закрытием вкладки!");
            }
        }

        /// <summary>
        /// Метод для удаления данных из списков.
        /// Нужен при удалении вкладки.
        /// </summary>
        /// <param name="sender"> издатель события </param>
        /// <param name="e"> информация о событии </param>
        private void DeleteLists(object sender, EventArgs e)
        {
            try
            {
                tabs.RemoveAt(tabControl1.SelectedIndex);
                fullnames.RemoveAt(tabControl1.SelectedIndex);
                changes.RemoveAt(tabControl1.SelectedIndex);
                tabControl1.TabPages.Remove(tabControl1.SelectedTab);
                if (tabs.Count == 0)
                    NewTabToolStripMenuItem_Click(sender, e);
            }
            catch (Exception)
            {
                MessageBox.Show("Возникли проблемы с работой Notepad +!");
            }
        }

        /// <summary>
        /// Обработка несуществующих файлов.
        /// </summary>
        /// <param name="richTextBox"> передача нужного для обработки поля</param>
        /// <returns>возвращение информации об ошибке в виде 1 или 0</returns>
        private int Error(RichTextBox richTextBox)
        {
            try
            {
                DialogResult dialog = MessageBox.Show("Файл, в который вы хотите дописать данные не существует" + Environment.NewLine +
                    "Хотите сохранить данный файл?", "Предупреждение", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Error);
                if (dialog == DialogResult.Yes)
                {
                    HelpWithSaving(richTextBox, out string namefile);
                }
                else if (dialog == DialogResult.Cancel)
                    return 0;
            }
            catch (Exception)
            {
                MessageBox.Show("Возникли проблемы с работой Notepad +!");
            }
            return 1;
        }

        /// <summary>
        /// Передача настроек приложения.
        /// </summary>
        /// <param name="transfernames"> пепредача путей файлов</param>
        /// <param name="colors">цветовая схема приложения</param>
        /// <param name="minutes">передача интервала автосохранения</param>
        private void Transfers(string transfernames, Color colors, int minutes)
        {
            try
            {
                Properties.Settings.Default.Filepaths = transfernames;
                Properties.Settings.Default.Colorback = colors;
                Properties.Settings.Default.Minutes = minutes;
                Properties.Settings.Default.Save();
            }
            catch (Exception)
            {
                MessageBox.Show("Возникли проблемы с сохранением настроек!");
            }
        }

        /// <summary>
        /// Считывание данных из файлов при передаче информации о настройках.
        /// </summary>
        /// <param name="richTextBox"> передача нужного для обработки поля</param>
        /// <param name="filename"> передача пути к файлу</param>
        /// <param name="counter">передача счётчика вкладок</param>
        private void OpenTransfer(RichTextBox richTextBox,string filename,int counter)
        {
            try
            {
                if (Path.GetExtension(filename) == ".rtf")
                {
                    richTextBox.LoadFile(filename);
                }
                else
                {
                    string filetext;
                    using (StreamReader sr = new StreamReader(filename))
                    {
                        filetext = sr.ReadToEnd();
                        richTextBox.Text = filetext;
                    }
                }
                fullnames[counter] = filename;
                changes[counter] = false;
                changes[0] = false;
            }
            catch (Exception)
            {
                MessageBox.Show("Возниколи проблемы с работой Notepad +!");
            }
        }
    }
}


