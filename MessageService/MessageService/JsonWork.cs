using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text.Json;
using System.Threading.Tasks;
using MessageService.Models;
namespace MessageService
{
    /// <summary>
    /// Данный класс преднзначен для сериализации и десериализации.
    /// </summary>
    public class JsonWork
    {
        /// <summary>
        /// Метод сериализует список объектов в файл с расширением json.
        /// </summary>
        /// <typeparam name="T"> тип, сериализуемого объекта </typeparam>
        /// <param name="list"> список нужного типа </param>
        /// <param name="path"> путь к файлу </param>
        public static void Serializer<T>(List<T> list, string path)
        {

            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(List<T>));
            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                serializer.WriteObject(fs, list);
            }

        }

        /// <summary>
        /// Метод десериализует данные из файла с расширением json.
        /// </summary>
        /// <typeparam name="T">тип, десериализуемого объекта </typeparam>
        /// <param name="path"> путь к файлу </param>
        /// <returns></returns>
        public static List<T> Deserializer<T>(string path)
        {
            List<T> list;
            DataContractJsonSerializer deserializer = new DataContractJsonSerializer(typeof(List<T>));
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                list = deserializer.ReadObject(fs) as List<T>;
            }
            return list;
        }
    }
}
