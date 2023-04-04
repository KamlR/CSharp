using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MessageService.Models;
using System.Text;
using MessageService;
using System.IO;

namespace MessageService.Controllers
{
    /// <summary>
    /// Класс, предназначенный для работы с сообщениями пользователей.
    /// </summary>
    public class MessageController : Controller
    {
        /// <summary>
        /// Список пользователей, который предоставляет возможность промежуточного хранения данных.
        /// Между сериализацией и десериализацией.
        /// </summary>
        private List<MessageOfUser> messages = new List<MessageOfUser>();
        /// <summary>
        /// Список сообщений, который предоставляет возможность промежуточного хранения данных.
        /// Между сериализацией и десериализацией.
        /// </summary>
        private List<User> users = new List<User>();

        /// <summary>
        /// Получение всех сообщений между конкретным отправителем и получателем.
        /// </summary>
        /// <param name="senderId"> Email отправителя </param>
        /// <param name="receiverId"> Email получателя </param>
        /// <returns> определяет контракт, представляющий результат метода действия </returns>
        [HttpGet("{senderId}/{receiverId}")]
        public IActionResult Get(string senderId, string receiverId)
        {
            try
            {
                // Десериализуем список сообщений.
                messages = JsonWork.Deserializer<MessageOfUser>("messages.json");
            }
            catch (Exception)
            {
                return NotFound(new { Message = "Возникли проблемы при работе с файлом!" });
            }
            // Список сообщений
            List<string> localMessage = new List<string>();
            // Проверка существования отправителя.
            var first = messages.FirstOrDefault(p => p.SenderId == senderId);
            // Проверка существования получателя.
            var second = messages.FirstOrDefault(p => p.ReceiverId == receiverId);
            if (first == null || second == null)
                return NotFound(new { Message = "Не нашлось отправителя или получателя!" });
            foreach (var item in messages)
            {
                if (senderId == item.SenderId && receiverId == item.ReceiverId)
                    localMessage.Add(item.Message);
            }
            return Ok(localMessage);
        }

        /// <summary>
        /// Все сообщения, отправленные конкретным пользователем.
        /// </summary>
        /// <param name="senderId"> Email отправителя </param>
        /// <returns> определяет контракт, представляющий результат метода действия </returns>
        [HttpGet("GetSenderMessages/{senderId}")]
        public IActionResult GetSenderMessages(string senderId)
        {
            try
            {
                // Десериализуем список сообщений.
                messages = JsonWork.Deserializer<MessageOfUser>("messages.json");
            }
            catch (Exception)
            {
                return NotFound(new { Message = "Возникли проблемы при работе с файлом!" });
            }
            // Список сообщений конкретного пользователя.
            List<string> localMessage = new List<string>();
            // Проверка существования отправителя.
            var first = messages.FirstOrDefault(p => p.SenderId == senderId);
            if (first == null)
                return NotFound(new { Message = "Не найден отправитель!" });
            foreach (var item in messages)
            {
                if (senderId == item.SenderId)
                    localMessage.Add(item.Message);
            }
            return Ok(localMessage);
        }


        /// <summary>
        /// Все сообщения, полученные конкретным пользователем.
        /// </summary>
        /// <param name="receiverId">Email получателя </param>
        /// <returns> определяет контракт, представляющий результат метода действия </returns>
        [HttpGet("GetReceiverMessages/{receiverId}")]
        public IActionResult GetReceiverMessages(string receiverId)
        {
            try
            {
                // Десериализуем список сообщений.
                messages = JsonWork.Deserializer<MessageOfUser>("messages.json");
            }
            catch (Exception)
            {
                return NotFound(new { Message = "Возникли проблемы при работе с файлом!" });
            }
            // Список сообщений, отправленные конкретному пользователю.
            List<string> localMessage = new List<string>();
            // Проверка существования получателя.
            var first = messages.FirstOrDefault(p => p.ReceiverId == receiverId);
            if (first == null)
                return NotFound(new { Message = "Не найден получатель!" });
            foreach (var item in messages)
            {
                if (receiverId == item.ReceiverId)
                    localMessage.Add(item.Message);
            }
            return Ok(localMessage);
        }

        /// <summary>
        /// Добавление нового сообщения.
        /// </summary>
        /// <param name="messageInfo">вся информация о сообщении </param>
        /// <returns> определяет контракт, представляющий результат метода действия </returns>
        [HttpPost("NewMessage")]
        public IActionResult Post(MessageOfUser messageInfo)
        {
            try
            {
                users = JsonWork.Deserializer<User>("users.json");
                // Проверка корректности вводимых данных.
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var first = users.FirstOrDefault(p => p.Email == messageInfo.SenderId);
                var second = users.FirstOrDefault(p => p.Email == messageInfo.ReceiverId);
                // Проверка существования отправителя и получателя.
                if (first == null || second == null)
                    return NotFound(new { Message = "Нет данных о пользователе!" });
                messages = JsonWork.Deserializer<MessageOfUser>("messages.json");
                messages.Add(messageInfo);
                JsonWork.Serializer(messages, "messages.json");
                return Ok(messageInfo);
            }
            catch (Exception)
            {
                return NotFound(new { Message = "Возникли проблемы при работе с файлом!" });
            }
        }

       
    }
}
