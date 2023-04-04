using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace MessageService.Models
{
    /// <summary>
    /// Класс содержит информацию о пользователях.
    /// </summary>
    [DataContract]
    public class User:IComparable<User>
    {
        /// <summary>
        /// Имя пользователя.
        /// </summary>
        [Required]
        [DataMember]
        public string UserName { get; set; }
        /// <summary>
        /// Email пользователя.
        /// </summary>
        [Required]
        [DataMember]
        public string Email { get; set; }

        /// <summary>
        /// Метод предназначен для сравнения двух пользователей по Email.
        /// </summary>
        /// <param name="user">ссылка на объект типа User </param>
        /// <returns> результатом сравнения ялвются 1, -1 или 0 </returns>
        public int CompareTo(User user)
        {
            return (GetLowerLetters(Email)).CompareTo(GetLowerLetters(user.Email));
        }

        /// <summary>
        /// Метод предназначен для получения Email в нижнем регистре для корректной сортировки.
        /// </summary>
        /// <param name="email">Email конкретного пользователя </param>
        /// <returns> строка с буквами в нижнем регистре </returns>
        private string GetLowerLetters(string email)
        {
            StringBuilder newEmail = new StringBuilder();
            foreach (var item in email)
            {
                newEmail.Append(Char.ToLower(item));
            }
            return newEmail.ToString();
        }
    }
}
