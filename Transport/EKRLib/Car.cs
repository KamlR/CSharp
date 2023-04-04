using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EKRLib
{
    /// <summary>
    /// Класс описывает машину.
    /// </summary>
    public class Car : Transport
    {
        /// <summary>
        /// Конструктор принимает на вход нужные для работы с программой характеристики автомобиля.
        /// </summary>
        /// <param name="model"> модель автомобиля </param>
        /// <param name="power"> мощность автомобиля </param>
        public Car(string model, uint power) : base(model, power) { }

        /// <summary>
        /// Переопределённый метод базового класса.
        /// </summary>
        /// <returns> возвращает строку с моделью автомобиля и звуком, который издаёт машина </returns>
        public override string StartEngine()
        {
            return $"{Model}: Vroom";
        }

        /// <summary>
        /// Переопределённый метод ToString().
        /// </summary>
        /// <returns> возвращается строка с информацией о модели и мощности автомобиля </returns>
        public override string ToString()
        {
            return "Car. " + base.ToString();
        }
    }
}
