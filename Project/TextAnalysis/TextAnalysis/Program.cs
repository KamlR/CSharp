using TextAnalysis;
using System.Threading;
using System;
using System.Diagnostics;

class Program
{
    // Словарь, который хранит кол-во каждого триплета в тексте.
    static Dictionary<string, int> patterns = new Dictionary<string, int>();

    //Два следующих словаря предназначены для корректной работы в многопоточном режиме.
    

    // Объект, который позволит корректно организовать доступ к общим ресурсам потоков. В данном случае к словарю patterns.
    static object locker = new();
    static string text;

    /// <summary>
    /// Метод, который будет выполняться двумя потоками параллельно.
    /// Первый поток анализирует первую половину текста, второй поток вторую половину текста.
    /// Перебираются всевозможные триплеты и ищется кол-во их вхождений в текст при помощи алгоритма Кнута—Морриса—Пратта.
    /// Для того чтобы не анализировать одинаковые триплеты несколько раз используются словари firstThreadPatts и secondThreadPatts для каждого из двух потоков по отдельности.
    /// Они хранят в себе те триплеты, для которых уже был проведён анализ.
    /// Есть блок, находящийся в lock (locker). Он позволяет не допускать доступ к главному словарю patterns сразу двум потокам.
    /// </summary>
    /// <param name="obj">При запуске метода в отдельном потоке передаём ему объект структры TextProp.
    /// Он хранит индексы начала и конца обрабатываемого текста, а также сам кусок текста, который анализирует метод.
    /// Индексы начала и конца текста и он сам вычисляются в методе Main.</param>
    static void AnalyzeText(object? obj)
    {
        Dictionary<string, int> threadPatts = new Dictionary<string, int>();
        int start = 0, end = 0;
        string text_sub = "";
        if (obj is TextProp textProp)
        {
            start = textProp.start;
            end = textProp.end;
            text_sub = textProp.text_sub;

        }
        int count_patterns;
        string pattern = "";
        for (int i = start; i <= end - 2; i++)
        {
            count_patterns = 0;
            pattern = text[i].ToString() + text[i + 1].ToString() + text[i + 2].ToString();
            
            if (!threadPatts.ContainsKey(pattern))
            {
                count_patterns = TemplateSearch.KmpAlgorithm(ref text_sub, pattern);
                threadPatts[pattern] = 1;
            }
            else
            {
                continue;
            }
            
            lock (locker)
            {
                if (patterns.ContainsKey(pattern))
                {
                    patterns[pattern] += count_patterns;
                }
                else
                {
                    patterns[pattern] = count_patterns;
                }

            }
        }
    }

    /// <summary>
    /// Метод для открытия файла, указанного пользователем, и чтения из него текста для дальньйшего анализа.
    /// Предусмотрена обработка соотв. исключений на случай возникновения ошибок при попытке открыть файл по указанному пути.
    /// Организован цикл do while(true), чтобы при возникновении ошибки у пользователя была возможность её поправить и заново ввести путь к файлу.
    /// </summary>
    /// <param name="path">Полный путь к файлу. Переменная передаётся по ссылке в метод.</param>
    static void ReadStrFromFile(ref string path)
    {
        Console.Write("Enter the path to the file: ");
        do
        {
            path = Console.ReadLine();
            try
            {
                if (path is not null && path != "")
                {
                    text = File.ReadAllText(path);
                    break;
                }
                else
                {
                    Console.WriteLine("Your path is null or empty");
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File not found!");
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("Directory not found!");
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("There is no access to file!");
            }
            catch (IOException)
            {
                Console.WriteLine("Input/Output error");
            }

            Console.Write("Enter the path to the file one more time: ");
        } while (true);
    }

    /// <summary>
    /// Метод проверяет исключительный случай, чтобы в словаре триплет не посчитался лишний раз.
    /// </summary>
    /// <param name="str1">ссылка на первую половину текста</param>
    /// <param name="str2">ссылка на вторую половину текста</param>
    /// <returns></returns>
    static bool check(ref string str1, ref string str2)
    {
        if(str1.Length + str2.Length > 3)
        {
            if (str1[str1.Length - 2] == str1[str1.Length - 1] && str2[0] == str2[1] && str1[str1.Length - 2] == str2[0])
            {
                return true;
            }
        }
        return false;
    }

    /// <summary>
    /// Входная точка в программу.
    /// Здесь происходит следующее:
    /// Замер времени выполнения программы. Для этого использован класс Stopwatch.
    /// Распределение задач между потоками "FirstThread" и "SecondThread".
    /// Ожидание завершения работы двух потоков при помощи метода Join.
    /// Сортировка словаря по убыванию, чтобы была возможность вывести 10 самых часто встречающихся триплетов в тексте.
    /// Вывод всех результатов: 10 самых часто встречающихся триплетов в тексте, время выполнения программы.
    /// </summary>
    /// <param name="args"></param>
    static void Main(string[] args)
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        string? path = "";
        ReadStrFromFile(ref path);
        if (text.Length <= 2)
        {
            Console.WriteLine("There is no tripltes");
            stopwatch.Stop();
            Console.WriteLine("Время выполнения: " + stopwatch.Elapsed.TotalMilliseconds);
            return;
        }
        Thread firstThred = new Thread(new ParameterizedThreadStart(AnalyzeText));
        Thread secondThred = new Thread(new ParameterizedThreadStart(AnalyzeText));
        firstThred.Name = "FirstThread";
        secondThred.Name = "SecondThread";
        string text_sub1 = text.Substring(0, (text.Length / 2) + 1);
        string text_sub2 = text.Substring((text.Length / 2) - 1, text.Length - (text.Length / 2) + 1);
        firstThred.Start(new TextProp(0, text.Length / 2, text_sub1));
        secondThred.Start(new TextProp((text.Length / 2) - 1, text.Length - 1, text_sub2));
        firstThred.Join();
        secondThred.Join();
        var sortedPatterns = patterns.OrderByDescending(x => x.Value);
        Console.WriteLine();
        Console.WriteLine("The 10 (or less) most common triplets in the text from the file " + Path.GetFileName(path) + ":");
        int count_answer = 0;
        if (check(ref text_sub1, ref text_sub2))
        {
            patterns[text_sub2[0].ToString() + text_sub2[0].ToString() + text_sub2[0].ToString()] -= 1;
        }
        foreach (var pattern in sortedPatterns)
        {
            Console.WriteLine(pattern.Key + ": " + pattern.Value);
            count_answer += 1;
            if (count_answer == 10)
            {
                break;
            }
        }
        stopwatch.Stop();
        Console.WriteLine("Время выполнения: " + stopwatch.Elapsed.TotalMilliseconds);
    }
}
