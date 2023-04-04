using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EKRLib
{
    /// <summary>
    /// Данный класс описывает абстрактное транспортное средство.
    /// Его можно применять для многих средств передвижения.
    /// </summary>
    public abstract class Transport
    {
        private string model;
        private uint power;

        /// <summary>
        /// Принимает нужные для работы с программой характеристики для транспортного средства.
        /// </summary>
        /// <param name="model"> модель транспортного средства </param>
        /// <param name="power"> мощность транспортного средства </param>
        public Transport(string model, uint power)
        {
            Model = model;
            Power = power;
        }

        /// <summary>
        /// Свойство для работы с моделью транспортного средства.
        /// При некорректных входных данных выбрасывается исключение TransportException.
        /// Проверка данных идёт согласно описанному алгоритму.
        /// </summary>
        public string Model
        {
            get
            {
                return model;
            }
            set
            {
                // Подсчёт кол-ва подходящих символов.
                int count = 0;
                for (int i = 0; i < value.Length; i++)
                {
                    // Проверяется, подходит ли символ для названия модели.
                    if (('A' <= value[i] && value[i] <= 'Z') || Char.IsDigit(value[i]))
                        count += 1;
                }
                if (value.Length == 5 && count == value.Length)
                    model = value;
                else
                    throw new TransportException($"Недопустимая модель {Model}");
            }
        }

        /// <summary>
        /// Свойство для работы с мощностью транспортного средства. 
        /// При некорректных входных данных выбрасывается исключение TransportException.
        /// Проверка данных идёт согласно описанному алгоритму.
        /// </summary>
        public uint Power
        {
            get
            {
                return power;
            }
            set
            {
                if (value < 20)
                    throw new TransportException("Мощность не может быть меньше 20 л.с");
                power = value;
            }
        }

        /// <summary>
        /// Метод, переопределяемый в производных классах.
        /// </summary>
        /// <returns> возвращает строку со звуком транспортного средства </returns>
        public abstract string StartEngine();
        
        /// <summary>
        /// Переопределённый метод ToString().
        /// </summary>
        /// <returns> возвращает строку с информацией о модели и мощности автомобиля </returns>
        public override string ToString()
        {
            return $"Model: {Model}, Power: {Power}";
        }
    }
}
