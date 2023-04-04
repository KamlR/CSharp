using System;
using System.Runtime.Serialization;

namespace EKRLib
{
    /// <summary>
    /// Класс предствляет обработку исключений, кототые могут вознкать при работе программы с транспортными средствами.
    /// </summary>
    [Serializable]
    public class TransportException : Exception
    {
        /// <summary>
        /// Обычный конструктор без параметров.
        /// </summary>
        public TransportException() { }

        /// <summary>
        /// Конструктор, принмающий на вход строку с информацией о возникшей ошибке.
        /// </summary>
        /// <param name="message">сообщеине с ошибкой </param>
        public TransportException(string message) : base(message) { }
       
        /// <summary>
        /// Конструктор принимает на вход сообщние о сбое и ошибку, которая произошла во время выполнения приложения.
        /// </summary>
        /// <param name="message"> сообщние об ошибке </param>
        /// <param name="innerException"> исключение </param>
        public TransportException(string message, Exception innerException) : base(message, innerException) { }

        /// <summary>
        /// Конструктор принимает на вход необходимые данные для сериализации и десериализации.
        /// </summary>
        /// <param name="info"> cодержит все данные, необходимые для сериализации или десериализации объекта </param>
        /// <param name="context"> описывает источник и назначение заданного потока сериализации </param>
        protected TransportException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}