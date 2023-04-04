using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows.Media;

namespace Fractals
{
    /// <summary>
    /// Отрисовка ковра Серпинского.
    /// </summary>
    public class Carpet : AllFractals
    {
        public Carpet(int depth) : base(depth) { }

        /// <summary>
        /// Метод отрисовки "Ковра Серпинского".
        /// </summary>
        /// <param name="canvas"> ссылка на canvas </param>
        /// <param name="x"> координата по x </param>
        /// <param name="y">кооордината по y </param>
        /// <param name="width"> ширина квадрата </param>
        /// <param name="height"> высота квадрата </param>
        /// <param name="depth1"> глубина рекурсии </param>
        public void DrawCarpet(Canvas canvas, int x, int y, int width, int height, int depth1)
        {
            int x1, x2, x3, y1, y2, y3;

            if (depth1 == 0)
            {
                Rectangle rectangle = new Rectangle();
                rectangle.Height = height;
                rectangle.Width = width;
                rectangle.Margin = new System.Windows.Thickness(x, y, 0, 0);
                rectangle.Fill = new SolidColorBrush(Colors.Magenta);
                canvas.Children.Add(rectangle);
            }
            else
            {
                width = width / 3;
                height = height / 3;
                x1 = x;
                x2 = x1 + width;
                x3 = x1 + 2 * width;
                y1 = y;
                y2 = y1 + height;
                y3 = y1 + 2 * height;
                if (depth1 > 0)
                {
                    DrawCarpet(canvas, x1, y1, width, height, depth1 - 1); // левый 1(верхний)
                    DrawCarpet(canvas, x2, y1, width, height, depth1 - 1); // средний 1
                    DrawCarpet(canvas, x3, y1, width, height, depth1 - 1); // правый 1
                    DrawCarpet(canvas, x1, y2, width, height, depth1 - 1); // левый 2
                    DrawCarpet(canvas, x3, y2, width, height, depth1 - 1); // правый 2
                    DrawCarpet(canvas, x1, y3, width, height, depth1 - 1); // левый 3
                    DrawCarpet(canvas, x2, y3, width, height, depth1 - 1); // средний 3
                    DrawCarpet(canvas, x3, y3, width, height, depth1 - 1); // правый 3
                }
            }
        }

        /// <summary>
        /// Переопределённый метод базового класса.
        /// </summary>
        public override void Draw() { }
    }

}
