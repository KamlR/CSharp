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
    /// Класс, предназначенный для работы с информацией о пользователях.
    /// </summary>
    [Route("/api/[controller]")]
    public class UserController : Controller
    {
        /// <summary>
        /// Объект класса Random для генерации псевдослучайных символов.
        /// </summary>
        Random random = new Random();
        /// <summary>
        /// Список пользователей, который предоставляет возможность промежуточного хранения данных.
        /// Между сериализацией и десериализацией.
        /// </summary>
        private List<User> users = new List<User>();
        /// <summary>
        /// Список сообщений, который предоставляет возможность промежуточного хранения данных.
        /// Между сериализацией и десериализацией.
        /// </summary>
        private List<MessageOfUser> messages = new List<MessageOfUser>();

        /// <summary>
        /// Генерация списка сообщений и пользователей.
        /// </summary>
        /// <returns> определяет контракт, представляющий результат метода действия </returns>
        [HttpPost]
        public IActionResult Post()
        {
            string letters = "AaBbCcDdEeFfGgHhIiJjKkLlMmNnOoPpQqRrSsTtUuVvWwXxYyZz";
            string[] themes = new string[] { "Education", "Art", "Science", "Sport", "Books", "Travel" };
            // Генерация числа пользователей.
            int count1 = random.Next(2, 11);
            for (int i = 0; i < count1; i++)
            {
                string email = GenerateEmail(letters);
                string name = GenerateName(letters);
                users.Add(new User() { Email = email, UserName = name });
            }
            // Генерация числа сообщений.
            int count2 = random.Next(1, 7);
            for (int i = 0; i < count2; i++)
            {
                string theme = themes[random.Next(0, 6)];
                string senderId = users[random.Next(0, users.Count)].Email;
                string receiverId = users[random.Next(0, users.Count)].Email;
                string message = GenerateMessage(letters);
                messages.Add(new MessageOfUser
                {
                    Message = message,
                    SenderId = senderId,
                    ReceiverId = receiverId,
                    Subject = theme
                });
            }
            users.Sort();
            try
            {
                //Сериализация списка пользователей.
                JsonWork.Serializer(users, "users.json");
                //Сериализация списка сообщений.
                JsonWork.Serializer(messages, "messages.json");
                return Ok(new { Message = "Всё успешно сгенерировано!" });
            }
            catch (Exception)
            {
                return NotFound(new { Message = "Возникли проблемы при работе с файлом!" });
            }
        }

        /// <summary>
        /// Добавление нового пользователя.
        /// </summary>
        /// <param name="user"> ссылка на объект типа User</param>
        /// <returns> определяет контракт, представляющий результат метода действия </returns>
        [HttpPost("AddUser")]
        public IActionResult Post(User user)
        {
            try
            {
                users = JsonWork.Deserializer<User>("users.json");
                // Проверка на корректность введённых данных.
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                foreach (var item in users)
                {
                    if (item.Email == user.Email)
                        return NotFound(new { Message = "Пользователь с таким Email уже существует!" });
                }
                users.Add(user);
                users.Sort();
                JsonWork.Serializer(users, "users.json");
                return Ok(user);
            }
            catch (Exception)
            {
                return NotFound(new { Message = "Возникли проблемы при работе с файлом!" });
            }
        }


        /// <summary>
        /// Получение списка пользователей.
        /// </summary>
        /// <returns> определяет контракт, представляющий результат метода действия </returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(JsonWork.Deserializer<User>("users.json"));
            }
            catch
            {
                return NotFound(new { Message = "Возникли проблемы при работе с файлом!" });
            }
        }


        /// <summary>
        /// Получение инфомации о пользователе по его Email.
        /// </summary>
        /// <param name="email"> Email пользователя</param>
        /// <returns> определяет контракт, представляющий результат метода действия </returns>
        [HttpGet("{email}")]
        public IActionResult Get(string email)
        {
            try
            {
                // Десериализуем список пользователей.
                users = JsonWork.Deserializer<User>("users.json");
            }
            catch (Exception)
            {
                return NotFound(new { Message = "Возникли проблемы при работе с файлом!" });
            }
            // Поиск Email в списке users.
            var first = users.SingleOrDefault(p => p.Email == email);

            if (first == null)
            {
                return NotFound(new { Message = "Пользователь с таким email не найден!" });
            }

            return Ok(first);
        }

        /// <summary>
        /// Получение информации о заданном кол-ве пользователей, начиная с определённого индекса.
        /// </summary>
        /// <param name="limit"> кол-во пользователей, которых хочется получить информацию </param>
        /// <param name="offset"> индекс, начиная с которого будет выведена информация по пользователям </param>
        /// <returns></returns>
        [HttpGet("{limit}/{offset}")]
        public IActionResult GetByIndexAndLength(int limit, int offset)
        {
            // Переменная отвечает за кол-во пользоватлей.
            int count = 0;
            // Список пользователей, коотрых будет выведена информация.
            List<User> forTime = new List<User>();
            try
            {
                users = JsonWork.Deserializer<User>("users.json");
            }
            catch (Exception)
            {
                return NotFound(new { Message = "Возникли проблемы при работе с файлом!" });
            }
            // Проверка корректности введённых данных.
            if (limit<=0)
                return NotFound(new { Message = "Кол-во пользователей должно быть >0" });
            if (offset<0 || offset>=users.Count)
                return NotFound(new { Message = "Пользователя с таким индексом нет!" });
            for (int i = offset; i < users.Count; i++)
            {
                if (count < limit)
                    forTime.Add(users[i]);
                count += 1;
            }
            return Ok(forTime);
        }

        /// <summary>
        /// Метод предназначен для генерации уникального Email пользователя.
        /// </summary>
        /// <param name="letters"> буквы латинского алфавита в разном регистре </param>
        /// <returns> возвращается сгенерированный Email</returns>
        private string GenerateEmail(string letters)
        {
            string[] mails = new string[] { "gmail.com", "mail.ru", "inbox.com" };
            // Выйдем из while при помощи return, когда сгенерится уникальный email.
            while (true)
            {
                // Генерация длины основной части email.
                int count = random.Next(3, 7);
                StringBuilder email = new StringBuilder();
                for (int i = 0; i < count; i++)
                {
                    // Генерация индекса буквы из letters.
                    int index = random.Next(0, 52);
                    email.Append(letters[index]);
                }
                // Красивое представления email.
                email.Append("@");
                email.Append(mails[random.Next(0, 3)]);
                if (users.Count == 0)
                {
                    return email.ToString();
                }
                else
                {
                    // Проверка на уникальность email.
                    if (!users.Exists(s => s.Email == email.ToString()))
                        return email.ToString();
                }
            }
        }

        /// <summary>
        /// Генерация имени пользователя.
        /// </summary>
        /// <param name="letters"> буквы латинского алфавита в разном регистре  </param>
        /// <returns> имя пользователя </returns>
        private string GenerateName(string letters)
        {
            // Генерация длины имени.
            int count = random.Next(3, 7);
            StringBuilder name = new StringBuilder();
            for (int i = 0; i < count; i++)
            {
                if (i == 0)
                    name.Append(Char.ToUpper(letters[random.Next(0, 52)]));
                else
                    name.Append(Char.ToLower(letters[random.Next(0, 52)]));
            }
            return name.ToString();
        }

        /// <summary>
        /// Генерация сообщений пользователей.
        /// </summary>
        /// <param name="letters"> буквы латинского алфавита в разном регистре </param>
        /// <returns> сообщение </returns>
        private string GenerateMessage(string letters)
        {
            StringBuilder message = new StringBuilder();
            // Кол-во слов в сообщении
            int length = random.Next(2, 9);
            for (int i = 0; i < length; i++)
            {
                StringBuilder word = new StringBuilder();
                for (int j = 0; j < length; j++)
                {
                    // Первая буква предложения в верхнем регисре.
                    if (i == 0 && j == 0)
                        word.Append(Char.ToUpper(letters[random.Next(0, 52)]));
                    else
                        word.Append(Char.ToLower(letters[random.Next(0, 52)]));
                }
                // Добавление пробелов между словами в сообщении.
                if (i != length - 1)
                    word.Append(" ");
                message.Append(word);
            }
            return message.ToString() + ".";
        }
    }
}
