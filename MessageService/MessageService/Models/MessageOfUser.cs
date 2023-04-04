using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace MessageService.Models
{
    /// <summary>
    /// Данный класс содержит информацию о сообщениях пользователей.
    /// </summary>
    [DataContract]
    public class MessageOfUser
    {
        /// <summary>
        /// Тема сообщения.
        /// </summary>
        [Required]
        [DataMember]
        public string Subject { get; set; }
        /// <summary>
        /// Само сообщение.
        /// </summary>
        [Required]
        [DataMember]
        public string Message { get; set; }
        /// <summary>
        /// Email отправителя.
        /// </summary>
        [Required]
        [DataMember]
        public string  SenderId { get; set; }
        /// <summary>
        /// Email получателя.
        /// </summary>
        [Required]
        [DataMember]
        public string ReceiverId { get; set; }
    }
}
