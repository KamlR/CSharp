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

    //public delegate int Name(int x, int y);
    /// <summary>
    /// Отрисвка треугольника Серпинского.
    /// </summary>
    public class Triangle : AllFractals
    {
        public Triangle(int depth) : base(depth) { }

        /// <summary>
        /// Метод отрисовки фрактала "Треугольник Серпинского".
        /// </summary>
        /// <param name="canvas"> сслыка на canvas </param>
        /// <param name="xTop"> координата по x (верхняяя) </param>
        /// <param name="yTop"> координата по y (верхняяя) </param>
        /// <param name="xLeft"> координата по x (левая) </param>
        /// <param name="yLeft"> координата по y (левая) </param>
        /// <param name="xRight"> координата по x (правая) </param>
        /// <param name="yRight"> координата по y (правая) </param>
        /// <param name="depth1"></param>
        public void DrawTriangle(Canvas canvas, int xTop, int yTop, int xLeft, int yLeft, int xRight, int yRight, int depth1)
        {
            // Координаты середин сторон треугольника.
            int xMid1, yMid1, xMid2, yMid2, xMid3, yMid3;
            if (depth1 == 0)
            {
                Line line1 = new Line();
                line1.X1 = xLeft;
                line1.Y1 = yLeft;
                line1.X2 = xTop;
                line1.Y2 = yTop;
                line1.Stroke = new SolidColorBrush(Colors.Blue);
                canvas.Children.Add(line1);
                Line line2 = new Line();
                line2.X1 = xTop;
                line2.Y1 = yTop;
                line2.X2 = xRight;
                line2.Y2 = yRight;
                line2.Stroke = new SolidColorBrush(Colors.Blue);
                canvas.Children.Add(line2);
                Line line3 = new Line();
                line3.X1 = xRight;
                line3.Y1 = yRight;
                line3.X2 = xLeft;
                line3.Y2 = yLeft;
                line3.Stroke = new SolidColorBrush(Colors.Blue);
                canvas.Children.Add(line3);
            }
            else
            {
                xMid1 = (xTop + xLeft) / 2; 
                yMid1 = (yTop + yLeft) / 2;
                xMid2 = (xTop + xRight) / 2; 
                yMid2 = (yTop + yRight) / 2;
                xMid3 = (xLeft + xRight) / 2; 
                yMid3 = (yLeft + yRight) / 2;
                if (depth1 > 0)
                {
                    DrawTriangle(canvas, xTop, yTop, xMid1, yMid1, xMid2, yMid2, depth1 - 1);
                    DrawTriangle(canvas, xMid1, yMid1, xLeft, yLeft, xMid3, yMid3, depth1-1);
                    DrawTriangle(canvas,xMid2, yMid2, xMid3, yMid3, xRight, yRight, depth1-1);
                }
            }
        }

        /// <summary>
        /// Переопределённый метод базового класса.
        /// </summary>
        public override void Draw() { }
    }
}
