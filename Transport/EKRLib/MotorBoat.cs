using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EKRLib
{
    /// <summary>
    /// Класс описывает моторную лодку.
    /// </summary>
    public class MotorBoat : Transport
    {
        /// <summary>
        /// Конструктор принимает на вход нужные для работы с программой характеристики моторной лодки.
        /// </summary>
        /// <param name="model"> модель моторной лодки </param>
        /// <param name="power"> мощность моторной лодки </param>
        public MotorBoat(string model, uint power) : base(model, power) { }

        /// <summary>
        /// Переопределённый метод базового класса.
        /// </summary>
        /// <returns> возвращает строку с моделью моторной лодки и звуком, который она издаёт </returns>
        public override string StartEngine()
        {
            return $"{Model}: Brrrbrr";
        }

        /// <summary>
        /// Переопределённый метод ToString().
        /// </summary>
        /// <returns> возвращается строка с информацией о модели и мощности моторной лодки </returns>
        public override string ToString()
        {
            return "MotorBoat. " + base.ToString();
        }
    }
}
