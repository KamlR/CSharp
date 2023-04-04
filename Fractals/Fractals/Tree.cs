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
    /// Отрисовка фрактального дерева.
    /// </summary>
    public class Tree : AllFractals
    {
        private  double coefficient;
        private int firstAngle;
        private int secondAngle;
        public Tree(int depth, double coefficient, int firstAngle, int secondAngle) : base(depth)
        {
            this.coefficient = coefficient;
            this.firstAngle = firstAngle;
            this.secondAngle = secondAngle;
        }

        /// <summary>
        /// Метод отрисовка фрактального дерева.
        /// </summary>
        /// <param name="canvas">ссылка на canvas </param>
        /// <param name="x"> координата по x </param>
        /// <param name="y"> координата по y </param>
        /// <param name="len"> длина ствола </param>
        /// <param name="anglee"> угол наклона </param>
        /// <param name="depth1">глубина рекурсии </param>
        public void DrawTree(Canvas canvas, int x, int y, int len, int anglee, int depth1)
        {
            double x1;
            double y1;
            x1 = x - len * Math.Sin(anglee * Math.PI * 2 / 360.0);
            y1 = y - len * Math.Cos(anglee * Math.PI * 2 / 360.0);
            Line line = new Line();
            line.X1 = x;
            line.Y1 = y;
            line.X2 = x1;
            line.Y2 = y1;
            line.Stroke = new SolidColorBrush(Colors.Black);
            line.StrokeThickness = 2;
            canvas.Children.Add(line);
            if (depth1>0)
            {
                DrawTree(canvas, (int)x1, (int)y1, (int)(len / coefficient), anglee + firstAngle, depth1-1);
                DrawTree(canvas, (int)x1, (int)y1, (int)(len / coefficient), anglee - secondAngle, depth1-1);
            }
        }

        /// <summary>
        /// Переопределённый метод базового класса.
        /// </summary>
        public override void Draw() { }
    }
}
