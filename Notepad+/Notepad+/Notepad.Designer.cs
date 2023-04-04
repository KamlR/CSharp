
namespace Notepad_
{
    partial class Notepad
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьКакToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.новоеОкноToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.новоеОкноCtrlWToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьОткрытыеДокументыCtrlRToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.правкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.вырезатьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.копироватьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.вставитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выделитьВсёToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.очиститьПолеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.форматToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.настройкиШрифтаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.стильТекстаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.курсивToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.жирныйToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.подчёркнутыйToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.зачёркнутыйToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.стильТекстаToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.настройкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.цветоваяСхемаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.настроитьАвтосохранениеФайловToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.закрытьТекущуюВкладкуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Window;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.правкаToolStripMenuItem,
            this.форматToolStripMenuItem,
            this.настройкиToolStripMenuItem,
            this.закрытьТекущуюВкладкуToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 33);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.открытьToolStripMenuItem,
            this.сохранитьToolStripMenuItem,
            this.сохранитьКакToolStripMenuItem,
            this.новоеОкноToolStripMenuItem,
            this.новоеОкноCtrlWToolStripMenuItem,
            this.сохранитьОткрытыеДокументыCtrlRToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(69, 29);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // открытьToolStripMenuItem
            // 
            this.открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            this.открытьToolStripMenuItem.Size = new System.Drawing.Size(435, 34);
            this.открытьToolStripMenuItem.Text = "Открыть Ctrl+O";
            this.открытьToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItem_Click);
            // 
            // сохранитьToolStripMenuItem
            // 
            this.сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            this.сохранитьToolStripMenuItem.Size = new System.Drawing.Size(435, 34);
            this.сохранитьToolStripMenuItem.Text = "Сохранить Ctrl+S";
            this.сохранитьToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItem_Click);
            // 
            // сохранитьКакToolStripMenuItem
            // 
            this.сохранитьКакToolStripMenuItem.Name = "сохранитьКакToolStripMenuItem";
            this.сохранитьКакToolStripMenuItem.Size = new System.Drawing.Size(435, 34);
            this.сохранитьКакToolStripMenuItem.Text = "Сохранить как Ctrl+K";
            this.сохранитьКакToolStripMenuItem.Click += new System.EventHandler(this.SaveAsToolStripMenuItem_Click);
            // 
            // новоеОкноToolStripMenuItem
            // 
            this.новоеОкноToolStripMenuItem.Name = "новоеОкноToolStripMenuItem";
            this.новоеОкноToolStripMenuItem.Size = new System.Drawing.Size(435, 34);
            this.новоеОкноToolStripMenuItem.Text = "Новое вкладка Ctrl+T";
            this.новоеОкноToolStripMenuItem.Click += new System.EventHandler(this.NewTabToolStripMenuItem_Click);
            // 
            // новоеОкноCtrlWToolStripMenuItem
            // 
            this.новоеОкноCtrlWToolStripMenuItem.Name = "новоеОкноCtrlWToolStripMenuItem";
            this.новоеОкноCtrlWToolStripMenuItem.Size = new System.Drawing.Size(435, 34);
            this.новоеОкноCtrlWToolStripMenuItem.Text = "Новое окно Ctrl+W";
            this.новоеОкноCtrlWToolStripMenuItem.Click += new System.EventHandler(this.NewWindowCtrlWToolStripMenuItem_Click);
            // 
            // сохранитьОткрытыеДокументыCtrlRToolStripMenuItem
            // 
            this.сохранитьОткрытыеДокументыCtrlRToolStripMenuItem.Name = "сохранитьОткрытыеДокументыCtrlRToolStripMenuItem";
            this.сохранитьОткрытыеДокументыCtrlRToolStripMenuItem.Size = new System.Drawing.Size(435, 34);
            this.сохранитьОткрытыеДокументыCtrlRToolStripMenuItem.Text = "Сохранить открытые документы Ctrl+P";
            this.сохранитьОткрытыеДокументыCtrlRToolStripMenuItem.Click += new System.EventHandler(this.SaveAllOpenDocumentsCtrlRToolStripMenuItem_Click);
            // 
            // правкаToolStripMenuItem
            // 
            this.правкаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.вырезатьToolStripMenuItem,
            this.копироватьToolStripMenuItem,
            this.вставитьToolStripMenuItem,
            this.выделитьВсёToolStripMenuItem,
            this.очиститьПолеToolStripMenuItem});
            this.правкаToolStripMenuItem.Name = "правкаToolStripMenuItem";
            this.правкаToolStripMenuItem.Size = new System.Drawing.Size(89, 29);
            this.правкаToolStripMenuItem.Text = "Правка";
            // 
            // вырезатьToolStripMenuItem
            // 
            this.вырезатьToolStripMenuItem.Name = "вырезатьToolStripMenuItem";
            this.вырезатьToolStripMenuItem.Size = new System.Drawing.Size(233, 34);
            this.вырезатьToolStripMenuItem.Text = "Вырезать";
            this.вырезатьToolStripMenuItem.Click += new System.EventHandler(this.CutToolStripMenuItem_Click);
            // 
            // копироватьToolStripMenuItem
            // 
            this.копироватьToolStripMenuItem.Name = "копироватьToolStripMenuItem";
            this.копироватьToolStripMenuItem.Size = new System.Drawing.Size(233, 34);
            this.копироватьToolStripMenuItem.Text = "Копировать";
            this.копироватьToolStripMenuItem.Click += new System.EventHandler(this.CopyToolStripMenuItem_Click);
            // 
            // вставитьToolStripMenuItem
            // 
            this.вставитьToolStripMenuItem.Name = "вставитьToolStripMenuItem";
            this.вставитьToolStripMenuItem.Size = new System.Drawing.Size(233, 34);
            this.вставитьToolStripMenuItem.Text = "Вставить";
            this.вставитьToolStripMenuItem.Click += new System.EventHandler(this.PasteToolStripMenuItem_Click);
            // 
            // выделитьВсёToolStripMenuItem
            // 
            this.выделитьВсёToolStripMenuItem.Name = "выделитьВсёToolStripMenuItem";
            this.выделитьВсёToolStripMenuItem.Size = new System.Drawing.Size(233, 34);
            this.выделитьВсёToolStripMenuItem.Text = "Выделить всё";
            this.выделитьВсёToolStripMenuItem.Click += new System.EventHandler(this.SelectAllToolStripMenuItem_Click);
            // 
            // очиститьПолеToolStripMenuItem
            // 
            this.очиститьПолеToolStripMenuItem.Name = "очиститьПолеToolStripMenuItem";
            this.очиститьПолеToolStripMenuItem.Size = new System.Drawing.Size(233, 34);
            this.очиститьПолеToolStripMenuItem.Text = "Очистить поле";
            this.очиститьПолеToolStripMenuItem.Click += new System.EventHandler(this.ClearAllToolStripMenuItem_Click);
            // 
            // форматToolStripMenuItem
            // 
            this.форматToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.настройкиШрифтаToolStripMenuItem,
            this.стильТекстаToolStripMenuItem,
            this.стильТекстаToolStripMenuItem1});
            this.форматToolStripMenuItem.Name = "форматToolStripMenuItem";
            this.форматToolStripMenuItem.Size = new System.Drawing.Size(92, 29);
            this.форматToolStripMenuItem.Text = "Формат";
            // 
            // настройкиШрифтаToolStripMenuItem
            // 
            this.настройкиШрифтаToolStripMenuItem.Name = "настройкиШрифтаToolStripMenuItem";
            this.настройкиШрифтаToolStripMenuItem.Size = new System.Drawing.Size(341, 34);
            this.настройкиШрифтаToolStripMenuItem.Text = "Настройки шрифта";
            this.настройкиШрифтаToolStripMenuItem.Click += new System.EventHandler(this.SetFontToolStripMenuItem_Click);
            // 
            // стильТекстаToolStripMenuItem
            // 
            this.стильТекстаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.курсивToolStripMenuItem,
            this.жирныйToolStripMenuItem,
            this.подчёркнутыйToolStripMenuItem,
            this.зачёркнутыйToolStripMenuItem});
            this.стильТекстаToolStripMenuItem.Name = "стильТекстаToolStripMenuItem";
            this.стильТекстаToolStripMenuItem.Size = new System.Drawing.Size(341, 34);
            this.стильТекстаToolStripMenuItem.Text = "Стиль текста";
            // 
            // курсивToolStripMenuItem
            // 
            this.курсивToolStripMenuItem.Name = "курсивToolStripMenuItem";
            this.курсивToolStripMenuItem.Size = new System.Drawing.Size(236, 34);
            this.курсивToolStripMenuItem.Text = "Курсив";
            this.курсивToolStripMenuItem.Click += new System.EventHandler(this.ItalicsToolStripMenuItem_Click);
            // 
            // жирныйToolStripMenuItem
            // 
            this.жирныйToolStripMenuItem.Name = "жирныйToolStripMenuItem";
            this.жирныйToolStripMenuItem.Size = new System.Drawing.Size(236, 34);
            this.жирныйToolStripMenuItem.Text = "Жирный";
            this.жирныйToolStripMenuItem.Click += new System.EventHandler(this.BoldToolStripMenuItem_Click);
            // 
            // подчёркнутыйToolStripMenuItem
            // 
            this.подчёркнутыйToolStripMenuItem.Name = "подчёркнутыйToolStripMenuItem";
            this.подчёркнутыйToolStripMenuItem.Size = new System.Drawing.Size(236, 34);
            this.подчёркнутыйToolStripMenuItem.Text = "Подчёркнутый";
            this.подчёркнутыйToolStripMenuItem.Click += new System.EventHandler(this.UnderlinedToolStripMenuItem_Click);
            // 
            // зачёркнутыйToolStripMenuItem
            // 
            this.зачёркнутыйToolStripMenuItem.Name = "зачёркнутыйToolStripMenuItem";
            this.зачёркнутыйToolStripMenuItem.Size = new System.Drawing.Size(236, 34);
            this.зачёркнутыйToolStripMenuItem.Text = "Зачёркнутый";
            this.зачёркнутыйToolStripMenuItem.Click += new System.EventHandler(this.CrossedToolStripMenuItem_Click);
            // 
            // стильТекстаToolStripMenuItem1
            // 
            this.стильТекстаToolStripMenuItem1.Name = "стильТекстаToolStripMenuItem1";
            this.стильТекстаToolStripMenuItem1.Size = new System.Drawing.Size(341, 34);
            this.стильТекстаToolStripMenuItem1.Text = "Стиль текста по умолчанию";
            this.стильТекстаToolStripMenuItem1.Click += new System.EventHandler(this.DefaultFontToolStripMenuItem1_Click);
            // 
            // настройкиToolStripMenuItem
            // 
            this.настройкиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.цветоваяСхемаToolStripMenuItem,
            this.настроитьАвтосохранениеФайловToolStripMenuItem});
            this.настройкиToolStripMenuItem.Name = "настройкиToolStripMenuItem";
            this.настройкиToolStripMenuItem.Size = new System.Drawing.Size(116, 29);
            this.настройкиToolStripMenuItem.Text = "Настройки";
            // 
            // цветоваяСхемаToolStripMenuItem
            // 
            this.цветоваяСхемаToolStripMenuItem.Name = "цветоваяСхемаToolStripMenuItem";
            this.цветоваяСхемаToolStripMenuItem.Size = new System.Drawing.Size(486, 34);
            this.цветоваяСхемаToolStripMenuItem.Text = "Цветовая схема";
            this.цветоваяСхемаToolStripMenuItem.Click += new System.EventHandler(this.SetColorToolStripMenuItem_Click);
            // 
            // настроитьАвтосохранениеФайловToolStripMenuItem
            // 
            this.настроитьАвтосохранениеФайловToolStripMenuItem.Name = "настроитьАвтосохранениеФайловToolStripMenuItem";
            this.настроитьАвтосохранениеФайловToolStripMenuItem.Size = new System.Drawing.Size(486, 34);
            this.настроитьАвтосохранениеФайловToolStripMenuItem.Text = "Настроить автосохранение открытых файлов";
            this.настроитьАвтосохранениеФайловToolStripMenuItem.Click += new System.EventHandler(this.AutoSaveToolStripMenuItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // tabControl1
            // 
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 33);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(800, 417);
            this.tabControl1.TabIndex = 2;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // закрытьТекущуюВкладкуToolStripMenuItem
            // 
            this.закрытьТекущуюВкладкуToolStripMenuItem.Name = "закрытьТекущуюВкладкуToolStripMenuItem";
            this.закрытьТекущуюВкладкуToolStripMenuItem.Size = new System.Drawing.Size(244, 29);
            this.закрытьТекущуюВкладкуToolStripMenuItem.Text = "Закрыть текущую вкладку";
            this.закрытьТекущуюВкладкуToolStripMenuItem.Click += new System.EventHandler(this.TabCloseToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.ForeColor = System.Drawing.SystemColors.Window;
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Notepad+";
            this.TransparencyKey = System.Drawing.Color.Blue;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Notepad1_Load);
            this.ContextMenuStripChanged += new System.EventHandler(this.SaveAsToolStripMenuItem_Click);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem открытьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьКакToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem правкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem вырезатьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem копироватьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem вставитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem форматToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem настройкиШрифтаToolStripMenuItem;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.ToolStripMenuItem настройкиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem цветоваяСхемаToolStripMenuItem;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.ToolStripMenuItem выделитьВсёToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem очиститьПолеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem новоеОкноToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.ToolStripMenuItem стильТекстаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem курсивToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem жирныйToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem подчёркнутыйToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem зачёркнутыйToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem стильТекстаToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem настроитьАвтосохранениеФайловToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripMenuItem новоеОкноCtrlWToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьОткрытыеДокументыCtrlRToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem закрытьТекущуюВкладкуToolStripMenuItem;
    }
}

