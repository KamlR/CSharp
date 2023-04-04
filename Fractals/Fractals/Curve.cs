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
    /// Отрисовка кривой Коха.
    /// </summary>
    public class Curve : AllFractals
    {
        public Curve(int depth) : base(depth) { }

        /// <summary>
        /// Метод отрисовки "Кривой Коха"
        /// </summary>
        /// <param name="canvas">ссылка на canvas </param>
        /// <param name="x1"> координата по x (справа)/param>
        /// <param name="y1">координата по y (справа </param>
        /// <param name="x2"> координата по x (слева) </param>
        /// <param name="y2"> координата по y (слева) </param>
        /// <param name="depth1"> глубина рекурсии </param>
        public void DrawCurve(Canvas canvas, double x1, double y1, double x2, double y2, int depth1)
        {
            double dx, dy, x1n, y1n, x2n, y2n, xmid, ymid;
            double pi = Math.PI;
            dx = (x2 - x1) / 3; dy = (y2 - y1) / 3;
            x1n = x1 + dx;
            y1n = y1 + dy;
            x2n = x1 + 2 * dx;
            y2n = y1 + 2 * dy;
            xmid = dx / 2 + dy * Math.Cos(pi / 3) + x1n;
            ymid = dy / 2 - dx * Math.Sin(pi / 3) + y1n;
            Line line = new Line();
            line.X1 = x1;
            line.Y1 = y1;
            line.X2 = x2;
            line.Y2 = y2;
            line.Stroke = new SolidColorBrush(Colors.Black);
            line.StrokeThickness = 2;
            canvas.Children.Add(line);
            if (depth1 >= 1 & depth1 <= recursionDepth)
            {
                Line line2 = new Line();
                line2.X1 = x1;
                line.Y1 = 250;
                line.X2 = x2;
                line.Y2 = 250;
                line.Stroke = new SolidColorBrush(Colors.White);
                line.StrokeThickness = 2;
                canvas.Children.Add(line2);
            }
            if (depth1 > 0)
            {
                DrawCurve(canvas, x1, y1, x1n, y1n, depth1 - 1);
                DrawCurve(canvas, x1n, y1n, xmid, ymid, depth1 - 1);
                DrawCurve(canvas, xmid, ymid, x2n, y2n, depth1 - 1);
                DrawCurve(canvas, x2n, y2n, x2, y2, depth1 - 1);
            }
        }

        /// <summary>
        /// Переопределённый метод базового класса.
        /// </summary>
        public override void Draw() { }
    }
}
