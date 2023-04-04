using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
namespace Fractals
{
    /// <summary>
    /// Главный класс для вызова методов отрисовки фракталов.
    /// Создание дизайна и добавление нужных элементов управления.
    /// </summary>
    public partial class MainWindow : Window
    {
        // Массив текстовых полей.
        List<TextBox> textBoxes = new List<TextBox>();
        // Кол-во вводов глубины рекурсии.
        int inputs;
        // Имя текущего фрактала.
        string name;
        Canvas canvas = new Canvas();
        TextBox textBox1;
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Обработчик нажатия на кнопку "Дерево".
        /// Добавление всех нужных надписей и текстовых полей.
        /// </summary>
        /// <param name="sender"> издатель события </param>
        /// <param name="e"> информация о событии </param>
        private void Tree_Click(object sender, RoutedEventArgs e)
        {
            inputs = 0;
            name = "tree";
            canvas.Children.Clear();
            canvas.HorizontalAlignment = HorizontalAlignment.Left;
            textBoxes.Clear();
            grid.Children.Clear();
            grid.Background = new SolidColorBrush(Colors.BlanchedAlmond);
            TextBlock textBlock5 = new TextBlock();
            NameFractal(textBlock5, "Дерево", 545, 10, 0, 0);
            TextBlock textBlock1 = new TextBlock();
            ForText(textBlock1, "Введите глубину рекурсии:", 15, 540, 50, 0, 0);
            TextBlock textBlock2 = new TextBlock();
            ForText(textBlock2, "Введите отношение длин отрезков:", 15, 540, 110, 0, 0);
            TextBlock textBlock3 = new TextBlock();
            ForText(textBlock3, "Введите угол наклона 1-ого отрезка:", 15, 540, 170, 0, 0);
            TextBlock textBlock4 = new TextBlock();
            ForText(textBlock4, "Введите угол наклона 2-ого отрезка:", 15, 540, 230, 0, 0);
            textBox1 = new TextBox();
            ForInput(textBox1, 350, 0, 0, 385);
            TextBox textBox2 = new TextBox();
            ForInput(textBox2, 350, 0, 0, 265);
            TextBox textBox3 = new TextBox();
            ForInput(textBox3, 350, 0, 0, 145);
            TextBox textBox4 = new TextBox();
            ForInput(textBox4, 350, 0, 0, 25);
            canvas.Width = 500;
            canvas.Height = 500;
            canvas.Margin = new Thickness(10, 0, 650, 0);
            grid.Children.Add(canvas);
            canvas.Background = new SolidColorBrush(Colors.White);
            Button button = new Button();
            ForButton(button, "tree", 345, 100, 0, 0);
            AdditionalButtons(1,"tree");
            textBox1.TextChanged += TextBox1_TextChanged;
        }

        /// <summary>
        /// Обработчик нажатия на кнопку "Кривая Коха".
        /// Добавление всех нужных надписей и текстовых полей.
        /// </summary>
        /// <param name="sender"> издатель события </param>
        /// <param name="e"> информация о событии </param>
        private void TheKochCurve_Click(object sender, RoutedEventArgs e)
        {
            inputs = 0;
            name = "curve";
            canvas.Children.Clear();
            textBoxes.Clear();
            grid.Children.Clear();
            grid.Background = new SolidColorBrush(Colors.BlanchedAlmond);
            TextBlock textBlock2 = new TextBlock();
            NameFractal(textBlock2, "Кривая Коха", 545, 10, 0, 0);
            TextBlock textBlock1 = new TextBlock();
            ForText(textBlock1, "Введите глубину рекурсии:", 15, 540, 55, 0, 0);
            textBox1 = new TextBox();
            ForInput(textBox1, 350, 0, 0, 375);
            canvas.Width = 500;
            canvas.Height = 500;
            canvas.Margin = new Thickness(10, 0, 650, 0);
            grid.Children.Add(canvas);
            canvas.Background = new SolidColorBrush(Colors.White);
            Button button = new Button();
            ForButton(button, "curve", 345, 10, 8, 200);
            AdditionalButtons(2, "curve");
            textBox1.TextChanged += TextBox1_TextChanged;
        }

        /// <summary>
        /// Обработчик нажатия на кнопку "Ковёр Серпинского".
        /// Добавление всех нужных надписей и текстовых полей.
        /// </summary>
        /// <param name="sender"> издатель события </param>
        /// <param name="e"> информация о событии </param>
        private void Carpet_Click(object sender, RoutedEventArgs e)
        {
            inputs = 0;
            name = "carpet";
            canvas.Children.Clear();
            textBoxes.Clear();
            grid.Children.Clear();
            grid.Background = new SolidColorBrush(Colors.BlanchedAlmond);
            TextBlock textBlock2 = new TextBlock();
            NameFractal(textBlock2, "Ковёр Серпинского", 545, 10, 0, 0);
            TextBlock textBlock1 = new TextBlock();
            ForText(textBlock1, "Введите глубину рекурсии:", 15, 540, 55, 0, 0);
            textBox1 = new TextBox();
            ForInput(textBox1, 350, 0, 0, 375);
            canvas.Width = 500;
            canvas.Height = 500;
            canvas.Margin = new Thickness(10, 0, 650, 0);
            grid.Children.Add(canvas);
            canvas.Background = new SolidColorBrush(Colors.White);
            Button button = new Button();
            ForButton(button, "carpet", 345, 10, 8, 200);
            AdditionalButtons(2, "carpet");
            textBox1.TextChanged += TextBox1_TextChanged;
        }

        /// <summary>
        /// Обработчик нажатия на кнопку "Треугольник Серпинского".
        /// Добавление всех нужных надписей и текстовых полей.
        /// </summary>
        /// <param name="sender"> издатель события </param>
        /// <param name="e"> информация о событии </param>
        private void Triangle_Click(object sender, RoutedEventArgs e)
        {
            inputs = 0;
            name = "triangle";
            canvas.Children.Clear();
            textBoxes.Clear();
            grid.Children.Clear();
            grid.Background = new SolidColorBrush(Colors.BlanchedAlmond);
            TextBlock textBlock2 = new TextBlock();
            NameFractal(textBlock2, "Треугольник Серпинского", 540, 10, 0, 0);
            TextBlock textBlock1 = new TextBlock();
            ForText(textBlock1, "Введите глубину рекурсии:", 15, 540, 55, 0, 0);
            textBox1 = new TextBox();
            ForInput(textBox1, 350, 0, 0, 375);
            canvas.Width = 500;
            canvas.Height = 500;
            canvas.Margin = new Thickness(10, 0, 650, 0);
            grid.Children.Add(canvas);
            canvas.Background = new SolidColorBrush(Colors.White);
            Button button = new Button();
            ForButton(button, "triangle", 345, 10, 8, 200);
            AdditionalButtons(2, "triangle");
            textBox1.TextChanged += TextBox1_TextChanged;
        }

        /// <summary>
        /// Обработчик нажатия на кнопку "Множество Кантора".
        /// Добавление всех нужных надписей и текстовых полей.
        /// </summary>
        /// <param name="sender"> издатель события </param>
        /// <param name="e"> информация о событии </param>
        private void CantorSet_Click(object sender, RoutedEventArgs e)
        {
            inputs = 0;
            name = "cantor";
            canvas.Children.Clear();
            textBoxes.Clear();
            grid.Children.Clear();
            grid.Background = new SolidColorBrush(Colors.BlanchedAlmond);
            TextBlock textBlock3 = new TextBlock();
            NameFractal(textBlock3, "Множество Кантора", 545, 10, 0, 0);
            TextBlock textBlock1 = new TextBlock();
            ForText(textBlock1, "Введите глубину рекурсии:", 15, 540, 50, 0, 0);
            TextBlock textBlock2 = new TextBlock();
            ForText(textBlock2, "Введите расстояние между отрезками:", 15, 540, 110, 0, 0);
            textBox1 = new TextBox();
            ForInput(textBox1, 350, 0, 0, 385);
            TextBox textBox2 = new TextBox();
            ForInput(textBox2, 350, 0, 0, 265);
            canvas.Width = 500;
            canvas.Height = 500;
            canvas.Margin = new Thickness(10, 0, 650, 0);
            grid.Children.Add(canvas);
            canvas.Background = new SolidColorBrush(Colors.White);
            Button button = new Button();
            ForButton(button, "cantor", 345, 70, 8, 200);
            AdditionalButtons(5, "cantor");
            textBox1.TextChanged += TextBox1_TextChanged;
        }

        /// <summary>
        /// Метод ForText располагет переданную надпись на гриде.
        /// </summary>
        /// <param name="textBlock"> сслыка на нужную надпись </param>
        /// <param name="text"> текст надписи </param>
        /// <param name="sizeText"> размер текста </param>
        /// <param name="digits"> числа, задающие расположение надписи </param>
        private void ForText(TextBlock textBlock, string text, int sizeText, params int[] digits)
        {
            textBlock.Margin = new Thickness(digits[0], digits[1], digits[2], digits[3]);
            textBlock.HorizontalAlignment = HorizontalAlignment.Left;
            textBlock.Text = text;
            textBlock.FontSize = sizeText;
            grid.Children.Add(textBlock);
        }

        /// <summary>
        /// Метод ForInput располагет переданное текстовое поле на гриде.
        /// </summary>
        /// <param name="textBox">ссылка на нужное текстовое поле </param>
        /// <param name="digits"> числа, задающие расположение текстового поля </param>
        private void ForInput(TextBox textBox, params int[] digits)
        {
            textBox.Margin = new Thickness(digits[0], digits[1], digits[2], digits[3]);
            textBox.FontSize = 11;
            textBox.Height = 25;
            textBox.Width = 100;
            textBox.BorderThickness = new Thickness(2);
            textBox.FontWeight = FontWeights.DemiBold;
            grid.Children.Add(textBox);
            textBoxes.Add(textBox);
        }

        /// <summary>
        /// Метод ForButton привязывате нужные обработчики событий к кнопке "Готово".
        /// Всё зависит от текущего фрактала.
        /// Также располагается сама кнопка.
        /// </summary>
        /// <param name="button"> ссылка на нужную кнопку </param>
        /// <param name="name"> имя фрактала, для которого создаётся кнопка </param>
        /// <param name="digits"> числа, задающие расположение кнопки </param>
        private void ForButton(Button button, string name, params int[] digits)
        {
            button.Content = "Готово";
            button.Margin = new Thickness(digits[0], digits[1], digits[2], digits[3]);
            button.Width = 80;
            grid.Children.Add(button);
            switch (name)
            {
                case "tree":
                    button.Click += ButtonTree_Click;
                    break;
                case "curve":
                    button.Click += ButtonCurve_Click;
                    break;
                case "carpet":
                    button.Click += ButtonCarpet_Click;
                    break;
                case "triangle":
                    button.Click += ButtonTriangle_Click;
                    break;
                case "cantor":
                    button.Click += ButtonCantor_Click;
                    break;
            }
        }

        /// <summary>
        /// Обработчик события нажатия на кнопку "Готово" для фрактала "Дерево".
        /// Проверка корректности введённых значений.
        /// Вызов метод отрисовки фрактала по экземплярной ссылке.
        /// </summary>
        /// <param name="sender"> издатель события </param>
        /// <param name="e"> информация о событии </param>
        private void ButtonTree_Click(object sender, RoutedEventArgs e)
        {
            int depth = 0;
            double coefficient = 0;
            int firstAngle = 0, secondAngle = 0;
            if (!int.TryParse(textBoxes[0].Text, out depth) || !double.TryParse(textBoxes[1].Text, out coefficient) ||
           !int.TryParse(textBoxes[2].Text, out firstAngle) || !int.TryParse(textBoxes[3].Text, out secondAngle)
           || depth<1 || depth>14 || coefficient<1.3 || coefficient>2 || firstAngle<10 || firstAngle>50 || secondAngle<10 || secondAngle>50)
            {
                MessageBox.Show("Проблемы с данными!\nГлубина рекурсии: 1-14\n" +
                    "Отношение длин отрезков: 1.3-2\n" +
                    "Значения уголов: 10-50");
                return;
            }
            canvas.Children.Clear();
            Tree tree = new Tree(depth, coefficient, firstAngle, secondAngle);
            inputs += 1;
            tree.DrawTree(canvas, 250, 500, 110, 0, depth - 1);
        }

        /// <summary>
        /// Обработчик события нажатия на кнопку "Готово" для фрактала "Кривая Коха".
        /// Проверка корректности введённых значений.
        /// Вызов метод отрисовки фрактала по экземплярной ссылке.
        /// </summary>
        /// <param name="sender"> издатель события </param>
        /// <param name="e"> информация о событии </param>
        private void ButtonCurve_Click(object sender, RoutedEventArgs e)
        {
            int depth = 0;
            if (!int.TryParse(textBoxes[0].Text, out depth) || depth<1 || depth>6)
            {
                MessageBox.Show("Проблемы с данными!\nГлубина рекурсии: 1-6");
                return;
            }
            canvas.Children.Clear();
            Curve curve = new Curve(depth);
            inputs += 1;
            curve.DrawCurve(canvas, 50, 250, 450, 250, depth-1);
        }

        /// <summary>
        /// Обработчик события нажатия на кнопку "Готово" для фрактала "Ковёр Серпинского".
        /// Проверка корректности введённых значений.
        /// Вызов метод отрисовки фрактала по экземплярной ссылке.
        /// </summary>
        /// <param name="sender"> издатель события </param>
        /// <param name="e"> информация о событии </param>
        private void ButtonCarpet_Click(object sender, RoutedEventArgs e)
        {
            int depth = 0;
            if (!int.TryParse(textBoxes[0].Text, out depth) || depth<0 || depth>5)
            {
                MessageBox.Show("Проблемы с данными!\nГлубина рекурсии: 0-5");
                return;
            }
            canvas.Children.Clear();
            Carpet carpet = new Carpet(depth);
            inputs += 1;
            carpet.DrawCarpet(canvas, 80, 80, 350, 350, depth);
        }

        /// <summary>
        /// Обработчик события нажатия на кнопку "Готово" для фрактала "Треугольник Серпинского".
        /// Проверка корректности введённых значений.
        /// Вызов метод отрисовки фрактала по экземплярной ссылке.
        /// </summary>
        /// <param name="sender"> издатель события </param>
        /// <param name="e"> информация о событии </param>
        private void ButtonTriangle_Click(object sender, RoutedEventArgs e)
        {
            int depth = 0;
            if (!int.TryParse(textBoxes[0].Text, out depth) || depth<0 || depth>8)
            {
                MessageBox.Show("Проблемы с данными!\nГлубина рекурсии: 0-8");
                return;
            }
            canvas.Children.Clear();
            Triangle triangle = new Triangle(depth);
            inputs += 1;
            triangle.DrawTriangle(canvas, (int)(canvas.Width/2), 0, 0, (int)(canvas.Height), (int)canvas.Width, (int)canvas.Height, depth);
        }

        /// <summary>
        /// Обработчик события нажатия на кнопку "Готово" для фрактала "Множество Кантора".
        /// Проверка корректности введённых значений.
        /// Вызов метод отрисовки фрактала по экземплярной ссылке.
        /// </summary>
        /// <param name="sender"> издатель события </param>
        /// <param name="e"> информация о событии </param>
        private void ButtonCantor_Click(object sender, RoutedEventArgs e)
        {
            int depth = 0;
            int distance = 0;
            if (!int.TryParse(textBoxes[0].Text, out depth) || !int.TryParse(textBoxes[1].Text, out distance)
                || depth<0 || depth>5 || distance<30 || distance>70)
            {
                MessageBox.Show("Проблемы с данными!\nГлубина рекурсии: 0-5\n" +
                    "Расстояние между отрезками: 30-70");
                return;
            }
            canvas.Children.Clear();
            Cantor cantor = new Cantor(depth, distance);
            inputs += 1;
            cantor.DrawCantorSet(canvas, 50, 120, 400,  depth);

        }

        /// <summary>
        /// Метод AdditionalButtons создаёт дополнительные кнопки "Назад" и "Вперёд" для удобства использования программы.
        /// </summary>
        /// <param name="x">номер, отвечающий за кол-во дополнительных кнопок </param>
        /// <param name="name"> имя фрактала, для которого создаются кнопки </param>
        private void AdditionalButtons(int x, string name)
        {
            Button button1 = new Button();
            Button button2 = new Button();
            if (x == 1 || x == 2)
            {
                button1.Content = "Вперёд";
                button1.Background = new SolidColorBrush(Colors.BlueViolet);
                button1.Margin = new Thickness(690, 465, 0, 0);
                button1.Width = 100;
                grid.Children.Add(button1);
            }
            if (x == 2 || x == 5)
            { 
                button2.Content = "Назад";
                button2.Background = new SolidColorBrush(Colors.CadetBlue);
                if (x==5)
                    button2.Margin = new Thickness(690, 465, 0, 0);
                else
                    button2.Margin = new Thickness(400, 465, 0, 0);
                button2.Width = 100;
                grid.Children.Add(button2);
            }
            HelperForAddButtons(button1, button2, name);
        }

        /// <summary>
        /// Метод HelperForAddButtons привязывает к кнопкам нужные обработчики событий.
        /// Всё зависит от следующего фрактала и предыдущего.
        /// </summary>
        /// <param name="button1"> сслыка на кнопку "Вперёд" </param>
        /// <param name="button2"> сслыка на кнопку "Назад" </param>
        /// <param name="name"> имя фрактала, для которого создаются кнопки </param>
        private void HelperForAddButtons(Button button1, Button button2, string name)
        {
            switch (name)
            {
                case "tree":
                    button1.Click += TheKochCurve_Click;
                    break;
                case "curve":
                    button1.Click += Carpet_Click;
                    button2.Click += Tree_Click;
                    break;
                case "carpet":
                    button2.Click += TheKochCurve_Click;
                    button1.Click += Triangle_Click;
                    break;
                case "triangle":
                    button2.Click += Carpet_Click;
                    button1.Click += CantorSet_Click;
                    break;
                case "cantor":
                    button2.Click += Triangle_Click;
                    break;
            }
        }

        /// <summary>
        /// Метод NameFractal располагает название фрактала.
        /// </summary>
        /// <param name="textBlock">ссылка на нужную надпись </param>
        /// <param name="text">название фрактала </param>
        /// <param name="digits"> числа, задающие расположение названия фрактала </param>
        private void NameFractal(TextBlock textBlock, string text, params int[] digits)
        {
            textBlock.Margin = new Thickness(digits[0], digits[1], digits[2], digits[3]);
            textBlock.FontSize = 25;
            textBlock.FontFamily = new FontFamily("Times New Roman Bold Italic");
            textBlock.Text = text;
            grid.Children.Add(textBlock);
        }

        /// <summary>
        /// Данный обработчик реагирует на изменения в текстовом поле, где вводится глубина рекурсии.
        /// Отвечает за автоматическую перерисовку.
        /// </summary>
        /// <param name="sender"> издатель события </param>
        /// <param name="e"> информация о событии </param>
        private void TextBox1_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (inputs>0 & textBox1.Text != "")
            {
                switch (name)
                {
                    case "tree":
                        ButtonTree_Click(sender,e);
                        break;
                    case "curve":
                        ButtonCurve_Click(sender, e);
                        break;
                    case "carpet":
                        ButtonCarpet_Click(sender, e);
                        break;
                    case "triangle":
                        ButtonTriangle_Click(sender,e);
                        break;
                    case "cantor":
                        ButtonCantor_Click(sender, e);
                        break;
                }
            }
        }
    }
}

