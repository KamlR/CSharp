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
    /// Отрисовка множества Кантора.
    /// </summary>
    public class Cantor : AllFractals
    {
        private int distance;
        public Cantor(int depth, int distance) : base(depth)
        {
            this.distance = distance;
        }

        /// <summary>
        /// Метод отрисовки фрактала "Множество Кантора".
        /// </summary>
        /// <param name="canvas"> ссылка на canvas </param>
        /// <param name="x"> координата по x </param>
        /// <param name="y"> координата по y </param>
        /// <param name="len"> длина изначального отрезка </param>
        /// <param name="depth"> глубина рекурсии </param>
        public void DrawCantorSet(Canvas canvas, int x, int y, int len, int depth)
        {
            if (depth >= 0)
            {
                Rectangle rectangle = new Rectangle();
                rectangle.Width = len;
                rectangle.Height = 15;
                rectangle.Margin = new System.Windows.Thickness(x, y, 0, 0);
                rectangle.Fill = new SolidColorBrush(Colors.Black);
                canvas.Children.Add(rectangle);
                y += distance;
                DrawCantorSet(canvas, x + len * 2 / 3, y, len / 3, depth - 1);
                DrawCantorSet(canvas, x, y, len / 3, depth - 1);
            }
        }

        /// <summary>
        /// Переопределённый метод базового класса.
        /// </summary>
        public override void Draw() { }
    }
}
