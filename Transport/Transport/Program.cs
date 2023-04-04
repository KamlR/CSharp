using System;
using System.Text;
using System.IO;
using EKRLib;

/// <summary>
/// Оснонвной класс работы программы.
/// Взаимодействует с классами из библиотеки EKRLib для успешной работы приложения.
/// </summary>
class Program
{
    /// <summary>
    /// Создаётся экзмемпляр класса рандом.
    /// Класс представляет генератор псевдослучайных чисел.
    /// </summary>
    static Random random = new Random();

    /// <summary>
    /// Точка входа в программу.
    /// Производится вызов нужных методов для успешной работы программы.
    /// </summary>
    static void Main()
    {
        do
        {
            Console.Clear();
            // Длина массива транспортных средств.
            int length = random.Next(6, 10);
            Transport[] transports = new Transport[length];
            FillingTheArray(ref transports);
           
            SendToFiles(transports);
            ModifyCosole();
        } while (Console.ReadKey().Key != ConsoleKey.Escape);
    }

    /// <summary>
    /// Метод CreateModel реализовывает случайную генерацию модели транспортного средства.
    /// </summary>
    /// <returns> возвращается полученная модель транспортного средства </returns>
    public static string CreateModel()
    {
        StringBuilder model = new StringBuilder();
        for (int j = 0; j < 5; j++)
        {
            // Выбор того, что будет находиться на данном месте в строке: буква или цифра.
            int n = random.Next(0, 2);
            if (n == 0)
                model.Append(random.Next(1, 10));
            else
                model.Append((char)random.Next('A', 'Z' + 1));
        }
        return model.ToString();
    }

    /// <summary>
    /// Метод ForStartEngine позволяет выводить на экран информацию о звуке, который издёт транспортное средство.
    /// Используется сслылка на соответствующий объект.
    /// </summary>
    /// <param name="transport"> ссылка на конкретный элемент массива transports </param>
    public static void ForStartEngine(Transport transport)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(transport.StartEngine());
        Console.ResetColor();
    }

    /// <summary>
    /// Метод SendToFiles записывает информацию о транспортных средсвах в нужные файлы.
    /// </summary>
    /// <param name="transports"> передаётся ссылка на массив с транспортными средствами </param>
    public static void SendToFiles(Transport[] transports)
    {
        try
        {
            // Путь к папке с проектом.
            string path = Path.GetFullPath(Directory.GetCurrentDirectory() + "../../../../../");
            string pathCar = path + "Cars.txt";
            // Запись информации об автомобилях в файл Cars.txt .
            using (StreamWriter sw = new StreamWriter(pathCar, false, Encoding.Unicode))
            {
                foreach (var item in transports)
                {
                    if (item is Car)
                        sw.WriteLine(item);
                }
            }
            string pathBoat = path + "MotorBoats.txt";
            // Запись информации о моторных лодках в файл MotorBoats.txt .
            using (StreamWriter sw = new StreamWriter(pathBoat, false, Encoding.Unicode))
            {
                foreach (var item in transports)
                {
                    if (item is MotorBoat)
                        sw.WriteLine(item);
                }
            }
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Два файла успешно созданы"+Environment.NewLine+"Приятного просмотра!");
            Console.ResetColor();
        }
        catch (Exception ex)
        {
            Console.WriteLine("С работой файлов возникла проблема!");
            Console.WriteLine(ex.Message);
        }
    }

    /// <summary>
    /// Метолд ModifyCosole предлагает пользователю завершить программу или же запустить её снова.
    /// </summary>
    public static void ModifyCosole()
    {
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Если вы хотите завершить программу, то нажмите Escape\n" +
            "Если же хотите запустить заново, то нажмите любую другую клавишу");
        Console.ResetColor();
    }

    /// <summary>
    /// Метод FillingTheArray заполняет массив ссылками на объекты различных транспортных средств.
    /// </summary>
    /// <param name="transports"> принимает на вход сслылку на массив, который будет заполняться транспортными средствами </param>
    public static void FillingTheArray(ref Transport[] transports)
    {
        for (int i = 0; i < transports.Length; i++)
        {
            do
            {
                string model = CreateModel();
                uint power = (uint)random.Next(10, 100);
                // Выбор генерации объекта.
                int choice = random.Next(0, 2);
                try
                {
                    if (choice == 0)
                    {
                        Car car = new Car(model, power);
                        transports[i] = car;
                        ForStartEngine(transports[i]);
                    }
                    else
                    {
                        MotorBoat motorBoat = new MotorBoat(model, power);
                        transports[i] = motorBoat;
                        ForStartEngine(transports[i]);
                    }
                }
                catch (TransportException ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                    Console.ResetColor();
                    Console.WriteLine("Объект будет создан заново");
                }
            } while (transports[i] == null);
        }
    }
}

