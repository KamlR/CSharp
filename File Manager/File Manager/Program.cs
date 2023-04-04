using System;
using System.IO;
using System.Text;

/// <summary>
/// Класс реализует работу с файловой системой компьютера.
/// </summary>
class Program
{
    /// <summary>
    /// Метод ChooseNember() направлен на запрос у пользователя желаемой операции.
    /// Также реализуется проверка корректности введённых значений.
    /// </summary>
    static int ChooseNumber()
    {
        int number;
        int flag = 0;
        do
        {
            Console.Write("Введите номер желаемой операции: ");
            string num = Console.ReadLine();
            if (!int.TryParse(num, out number) | number <= 0 | number > 8)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ваши данные некорректны!");
                Console.ResetColor();
            }
            else
                flag = 1;
        } while (flag == 0);
        return number;
    }

    /// <summary>
    /// Метод StartPoint вызывает нужный метод в зависимости от выбранной операции.
    /// Отсюда начинается основная работа с файловой системой.
    /// </summary>
    /// <param name="number"></param> Метод принимает на вход номер операции.
    static void StartPoint(in int number)
    {
        switch (number)
        {
            case 1:
                JustSee();
                break;
            case 2:
                SeeFiles();
                break;
            case 3:
                PrintFile();
                break;
            case 4:
                CopyFile();
                break;
            case 5:
                MoveFile();
                break;
            case 6:
                DeleteFile();
                break;
            case 7:
                CreateFile();
                break;
            case 8:
                ConcatFiles();
                break;
        }
    }

    /// <summary>
    /// Метод Select позволяет проверяет правильно ли пользователь ввёл номер диска папки или же файла, который ему нужно открыть.
    /// </summary>
    /// <param name="count"></param> Количество нужныx папок\дисков\файлов.
    /// <param name="word"></param> Отвечает за правильный вывод слова.
    /// <param name="ending"></param> Отвечает за правильный вывод окончания.
    /// <returns></returns> Возвращается номер выбранного пункта.
    static int Select(int count, string word)
    {
        int flag = 0;
        int position;
        do
        {
            Console.Write(word);
            string positionStart = Console.ReadLine();
            if (!int.TryParse(positionStart, out position) | position <= 0 | position > count)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Вы ввели некорректный номер!");
                Console.ResetColor();
            }
            else
                flag = 1;
        } while (flag == 0);
        return position;
    }

    /// <summary>
    /// Метод реализует выбор кодировки, в которой пользователь хочет вывести/записать файл.
    /// </summary>
    /// <returns></returns> Возвращается сама кодировка.
    static string ChooseEncoding(string sentence)
    {
        // Массив кодировок.
        string[] array = new string[4] { "Encoding.UTF8", "Encoding.ASCII", "Encoding.Latin1", "Encoding.UTF32" };
        int count = 0;
        for (int i = 0; i < array.Length; i++)
        {
            count += 1;
            Console.WriteLine($"{count}) {array[i].Remove(0, 9)}");
        }
        int position = Select(count, sentence);
        return array[position - 1];
    }

    /// <summary>
    /// Метод CheckForTxt проверяет, правильное ли расширение у файла.
    /// Если у файла расширение не txt, то программа просто завершается.
    /// </summary>
    /// <param name="path"></param> Принимает на вход расположение файла.
    static void CheckForTxt(string path)
    {
        if (path[^1] != 't' | path[^2] != 'x' | path[^3] != 't' | path[^4] != '.')
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("У вашего файла неверное расширение");
            Console.WriteLine("Программа работает с файлами вида *.txt");
            Console.WriteLine("Программа будет завершена!");
            Console.ResetColor();
            Environment.Exit(0);
        }
    }

    /// <summary>
    /// Метод OutPutText позволяет вывести данные из файла в заданной пользователем кодировке.
    /// </summary>
    /// <param name="code"></param> Передаётся выбранная пользователем кодировка.
    /// <param name="path"></param> Передаётся путь, по которому расположен файл.
    static void OutPutText(string code, string path)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        switch (code)
        {
            case "Encoding.UTF8":
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Содержимое вашего файла в кодировке UTF8");
                Console.ResetColor();
                Console.WriteLine(File.ReadAllText(path, Encoding.UTF8));
                break;
            case "Encoding.ASCII":
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Содержимое вашего файла в кодировке ASCII");
                Console.ResetColor();
                Console.WriteLine(File.ReadAllText(path, Encoding.ASCII));
                break;
            case "Encoding.Latin1":
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Содержимое вашего файла в кодировке Latin1");
                Console.ResetColor();
                Console.WriteLine(File.ReadAllText(path, Encoding.Latin1));
                break;
            case "Encoding.UTF32":
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Содержимое вашего файла в кодировке UTF32");
                Console.ResetColor();
                Console.WriteLine(File.ReadAllText(path, Encoding.UTF8));
                break;
        }
    }

    /// <summary>
    /// Метод InputText создаёт файл в заданной пользлвателем кодировке.
    /// </summary>
    /// <param name="code"></param> Передаётся нужная кодировка файла.
    /// <param name="path"></param> Передаётся путь к создаваемому файлу.
    static void InputText(string code, string path)
    {
        switch (code)
        {
            case "Encoding.UTF8":
                Console.ForegroundColor = ConsoleColor.Green;
                Console.ResetColor();
                File.WriteAllText(path, null, Encoding.UTF8);
                break;
            case "Encoding.ASCII":
                Console.ForegroundColor = ConsoleColor.Green;
                Console.ResetColor();
                File.WriteAllText(path, null, Encoding.ASCII);
                break;
            case "Encoding.Latin1":
                Console.ForegroundColor = ConsoleColor.Green;
                Console.ResetColor();
                File.WriteAllText(path, null, Encoding.Latin1);
                break;
            case "Encoding.UTF32":
                Console.ForegroundColor = ConsoleColor.Green;
                Console.ResetColor();
                File.WriteAllText(path, null, Encoding.UTF32);
                break;
        }
    }

    /// <summary>
    /// В методе InputStrings создаётся новый файл по указанному пути , и в него записываются строки, введённые пользователем.
    /// </summary>
    /// <param name="path"></param> Передаётся путь к файлу.
    /// <param name="code"></param> Передаётся кодировка файла.
    /// <param name="strings"></param> Передаются строки для записи в файл.
    static void InputStrings(string path, string code,string[] strings)
    {
        switch (code)
        {
            case "Encoding.UTF8":
                Console.ForegroundColor = ConsoleColor.Green;
                Console.ResetColor();
                File.WriteAllLines(path, strings, Encoding.UTF8);
                break;
            case "Encoding.ASCII":
                Console.ForegroundColor = ConsoleColor.Green;
                Console.ResetColor();
                File.WriteAllLines(path, strings, Encoding.ASCII);
                break;
            case "Encoding.Latin1":
                Console.ForegroundColor = ConsoleColor.Green;
                Console.ResetColor();
                File.WriteAllLines(path, strings , Encoding.Latin1);
                break;
            case "Encoding.UTF32":
                Console.ForegroundColor = ConsoleColor.Green;
                Console.ResetColor();
                File.WriteAllLines(path,strings , Encoding.UTF32);
                break;
        }
    }

    /// <summary>
    /// Метод CheckFile помогает некоторым другим методам реализовать работу.
    /// А именно, указывает на проблемы, которые могут возникнуть при работе с файлами.
    /// </summary>
    /// <param name="path"></param>
    /// <param name="num"></param>
    static void CheckFile(string path, in int num)
    {
        try
        {
            if (!File.Exists(path) & num != 2)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Tакого файла не существует");
                Console.WriteLine("Программа будет завершена");
                Console.ResetColor();
                Environment.Exit(0);
            }
            else
            {
                CheckForTxt(path);
            }
        }
        catch (Exception)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("С вашим файлом возникли проблемы");
            Console.ResetColor();
        }
    }

    /// <summary>
    /// Метод HelperForCreateFile() упрощает работу метода для создания файла в различных кодировках.
    /// Он просто помогает разгрузить метод для создания файла.
    /// </summary>
    static void HelperForCreateFile()
    {
        Console.WriteLine("Введите путь к файлу для одновременного создания и записи данных: ");
        string path = Console.ReadLine();
        try
        {
            CheckForTxt(path);
            string[] strings = CreateStrings();
            string code = ChooseEncoding("Введите номер кодировки, в которой вы хотите создать файл: ");
            InputStrings(path,code,strings);
            Console.WriteLine($"Ваш файл успешно создан в кодировке {code}"); ;
        }
        catch (Exception)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("С созданием вашего файла возникли проблемы");
            Console.ResetColor();
        }
    }

    /// <summary>
    /// Метод CreateStrings() запрашивает у пользователя строки, которые он хочет передать в создаваемый файл.
    /// </summary>
    /// <returns></returns> Возвращается массив строк.
    static string[] CreateStrings()
    {
        // Кол-во строк, которое пользователь хочет записать в файл.
        int calculate = WhatIsNumber("Введите, какое количество строк будет в вашем файле: ");
        // Массив строк для записи в создаваемый файл.
        string[] strings = new string[calculate];
        for (int i = 0; i < strings.Length; i++)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Введите {i + 1} строку:");
            Console.ResetColor();
            strings[i] = Console.ReadLine();
        }
        return strings;
    }

    /// <summary>
    /// Метод HelperForCreateStrings() проверятет корректность входных данных (правильно ли введено число).
    /// </summary>
    /// <returns></returns> Возвращает корректный номер для дальнейшей обработки.
    static int WhatIsNumber(string sentence)
    {
        int flag = 0;
        int calculate;
        do
        {
            Console.Write(sentence);
            string tester = Console.ReadLine();
            if (!int.TryParse(tester, out calculate) | calculate <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ваши данные некорректны!");
                Console.ResetColor();
            }
            else
                flag = 1;

        } while (flag == 0);
        return calculate;
    }

    /// <summary>
    /// Метод Menu() осуществляет вывод возможных команд, которые доступны пользователю.
    /// </summary>
    static void Menu()
    {
        Console.WriteLine("Программа работает только с файлами расширения *.txt");
        Console.WriteLine("При работе с файлами вам нужно будет указывать полный путь к ним\n");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("1)Просмотр списка дисков компьютера и выбор диска;");
        Console.WriteLine("  Переход в другую директорию (выбор папки);\n");
        Console.WriteLine("2)Просмотр списка файлов в директории;\n");
        Console.WriteLine("3)Вывод содержимого текстового файла в консоль в выбранной");
        Console.WriteLine("пользователем кодировке (предоставляется не менее четырех вариантов);\n");
        Console.WriteLine("4)Копирование файла;\n");
        Console.WriteLine("5)Перемещение файла в выбранную пользователем директорию;\n");
        Console.WriteLine("6)Удаление файла;\n");
        Console.WriteLine("7)Создание простого текстового файла в выбранной пользователем");
        Console.WriteLine("кодировке (предоставляется не менее четырех вариантов);\n");
        Console.WriteLine("8)Конкатенация содержимого двух или более текстовых файлов и вывод");
        Console.WriteLine("результата в консоль в кодировке UTF-8.\n");
        Console.ResetColor();
    }

    /// <summary>
    /// Метод Main() является точкой входа в программу.
    /// С него начинается вызов всех методов.
    /// Также тут реализовано повторение решения.
    /// </summary>
    static void Main()
    {
        do
        {
            Console.Clear();
            Console.WriteLine("Привет!!!\nПеред тобой файловый менеджер\n" +
                "Он будет работать с файловой системой твоего компьютера");
            Menu();
            int number = ChooseNumber();
            StartPoint(in number);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Если вы хотите завершить программу, то нажмите Escape\n" +
                "Если же хотите запустить заново, то нажмите любую другую клавишу");
            Console.ResetColor();
        } while (Console.ReadKey().Key != ConsoleKey.Escape);
    }

    /// <summary>
    /// Метод JustSee() даёт возможность пользователю просмотреть все возможные диски.
    /// Также можно посмотреть файлы, которые хранятся на выбранном диске.
    /// </summary>
    static void JustSee()
    {
        try
        {
            DriveInfo[] drives = DriveInfo.GetDrives();
            // Переменная нужна для вывода пронумерованного списка дисков компьютера.
            Console.WriteLine("В этом пункте вы сможете посмотреть, какие папки содержатся на вашем диске, а также перейти в одну из них.");
            int count = 0;
            foreach (var item in drives)
            {
                count += 1;
                Console.WriteLine($"{count}) {item}");
            }
            int position = Select(count, "Введите номер диска, который хотите открыть: ");
            string[] dirs = Directory.GetDirectories(drives[position - 1].ToString());
            count = 0;
            Console.ForegroundColor = ConsoleColor.Blue;
            foreach (var item in dirs)
            {
                count += 1;
                Console.WriteLine($"{count}) {item}");
            }
            Console.ResetColor();
            position = Select(count, "Введите номер папки, которую хотите открыть: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            string[] dirsTwo = Directory.GetDirectories(dirs[position - 1].ToString());
            count = 0;
            if (dirsTwo.Length==0)
                Console.WriteLine("Данная папка пуста!");
            foreach (var item in dirsTwo)
            {
                count += 1;
                Console.WriteLine($"{count}) {item}");
            }
            Console.ResetColor();
        }
        catch (Exception)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("При работе с файловой системой возникли проблемы");
            Console.ResetColor();
        }
    }


    /// <summary>
    /// Метод SeeFiles() реализует вывод всех файлов заданной пользователем папки.
    /// </summary>
    static void SeeFiles()
    {
        Console.WriteLine("Введите путь к директории, файлы которой хотите просмотреть: \n");
        string path = Console.ReadLine();
        try
        {
            if (!Directory.Exists(path))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Tакой папки не существует");
                Console.WriteLine("Программа будет завершена");
                Console.ResetColor();
                Environment.Exit(0);
                return;
            }
            else
            {
                string[] files = Directory.GetFiles(path);
                if (files.Length == 0)
                    Console.WriteLine("В заданной папке нет файлов");
                else
                {
                    Console.WriteLine("Все файлы заданного каталога:\n");
                    for (int i = 0; i < files.Length; i++)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine(files[i]);
                    }
                    Console.ResetColor();
                }
            }
        }
        catch (Exception)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("При работе с папкой возникли проблемы");
            Console.ResetColor();
        }
    }


    /// <summary>
    /// Метод PrintFile() обрабатывает запрос на вывод файла в заданной кодировке.
    /// </summary>
    static void PrintFile()
    {
        Console.WriteLine("Введите путь к файлу, содержимое которого хотите вывести");
        string path = Console.ReadLine();
        try
        {
            if (!File.Exists(path))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Tакого файла не существует");
                Console.WriteLine("Программа будет завершена");
                Console.ResetColor();
                Environment.Exit(0);
            }
            else
            {
                CheckForTxt(path);
                string code = ChooseEncoding("Введите номер кодировки, в которой хотите вывести содержимое файла: ");
                OutPutText(code, path);
            }
        }
        catch (Exception)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("С вашим файлом возникли проблемы");
            Console.ResetColor();
        }
    }

    /// <summary>
    /// Метод CopyFile() копирует файл по указанному пути.
    /// </summary>
    static void CopyFile()
    {
        Console.WriteLine("Введите путь к файлу, содержимое которого хотите скопировать");
        string path1 = Console.ReadLine();
        // Переменная num указывает на номер файл, путь к которому укахывается.
        int num = 1;
        CheckFile(path1, in num);
        Console.WriteLine("Введите путь к файлу, куда нужно скопировать данные");
        string path2 = Console.ReadLine();
        num = 2;
        CheckFile(path2, in num);
        try
        {
            Console.WriteLine("При попытке скопировать что-то уже в существующий файл, данные просто перезапишутся");
            File.Copy(path1, path2, true);
        }
        catch (Exception)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("С вашим файлом возникли проблемы");
            Console.ResetColor();
        }
        Console.WriteLine("Ваш файл удачно скопирован!");
    }

    /// <summary>
    /// Метод MoveFile() позволяет переместить файл по нужному адресу.
    /// </summary>
    static void MoveFile()
    {
        Console.WriteLine("Нужно будет указывать польный путь, как 1, так и 2 файла\n");
        Console.WriteLine("Введите путь к файлу, который вы хотите перемеcтить");
        string path1 = Console.ReadLine();
        int num = 1;
        CheckFile(path1, in num);
        Console.WriteLine("Введите путь, куда конкретно вы хотите переместить файл");
        string path2 = Console.ReadLine();
        num = 2;
        CheckFile(path1, in num);
        try
        {
            Console.WriteLine("Если по адресу, куда вы перемещаете файл уже имеется такой, то он будет перезаписан\n");
            File.Move(path1, path2, true);
            Console.WriteLine("Ваш файл удачно перемещён!\n");
        }
        catch (Exception)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("С вашим файлом возникли проблемы");
            Console.ResetColor();
        }
    }

    /// <summary>
    /// Метод DeleteFile() удалет файл по указанному пути.
    /// </summary>
    static void DeleteFile()
    {
        Console.WriteLine("Введите путь к файлу, который вы хотите удалить");
        string path = Console.ReadLine();
        int num = 1;
        CheckFile(path, in num);
        try
        {
            File.Delete(path);
        }
        catch (Exception)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("С вашим файлом возникли проблемы");
            Console.ResetColor();
        }
        Console.WriteLine("Файл успешно удалён!\n");
    }

    /// <summary>
    /// Метод CreateFile() создаёт либо путой файл, либо же создаёт файл и записывает в него данные, на выбор пользователя.
    /// Если файл, который хочет создать пользователь уже существует, то он перезапишется.
    /// </summary>
    static void CreateFile()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("В этом пункте, если вы будете создавать уже существующий файл, то он просто перезапишется");
        Console.WriteLine("1) Просто создать файл, ничего в него не записывая");
        Console.WriteLine("2) Создать файл и записать в него нужный текст");
        Console.ResetColor();
        int point = Select(2, "Выбирете нужный вам пункт: ");
        if (point == 1)
        {
            Console.WriteLine("Введите путь к файлу, который хотите создать");
            string path = Console.ReadLine();
            try
            {
                CheckForTxt(path);
                string code = ChooseEncoding("Введите номер кодировки, в которой вы хотите создать файл: ");
                InputText(code, path);
                Console.WriteLine($"Ваш файл успешно создан в кодировке {code.Remove(0, 9)}");
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("С созданием вашего файла возникли проблемы!");
                Console.ResetColor();
            }
        }
        if (point == 2)
            HelperForCreateFile();
    }

    /// <summary>
    /// Метод ConcatFiles() конкатенирует содержимое заданного кол-ва файлов.
    ///</summary>
    static void ConcatFiles()
    {
        Console.WriteLine("В этом пункте вам предлагается сконкотенировать уже имеющиеся файлы");
        int digit = WhatIsNumber("Введите, какое кол-во файлов вы хотите сконкотенировать: ");
        // Массив с расположением файлов для конкатенации.
        string[] fileDist = new string[digit];
        for (int i = 0; i < fileDist.Length; i++)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Введите расположениие {i+1} файла для конкатенации");
            Console.ResetColor();
            string path = Console.ReadLine();
            int num = 1;
            CheckFile(path, num);
            fileDist[i] = path;
        }
        string[] contentFiles = new string[digit];
        for (int i = 0; i < contentFiles.Length; i++)
        {
            try
            {
                contentFiles[i] = File.ReadAllText(fileDist[i], Encoding.UTF8);
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("С одним из ваших возникли проблемы!");
                Console.ResetColor();
            }
        }
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Результат конкатенации {digit} файлов");
        Console.ResetColor();
        for (int i = 0; i < contentFiles.Length; i++)
        {
            Console.WriteLine(contentFiles[i]);
        }
    }
}
