using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Collections;
using static System.Net.Mime.MediaTypeNames;

class Program
{
    // Словарь, который хранит кол-во каждого триплета в тексте.
    static Dictionary<string, int> triplets = new Dictionary<string, int>();
    static object locker = new();

    /// <summary>
    /// Проходимся циклом по полученной строке и при необходимости вносим изменения в словарь
    /// </summary>
    /// <param name="text_sub">текст для обработки</param>
    static void CountTriplets(string text_sub)
    {
        string triplet;
        for (int i = 0; i < text_sub.Length - 2 ; i++)
        {
            triplet = text_sub[i].ToString() + text_sub[i + 1].ToString() + text_sub[i + 2].ToString();
            lock (locker)
            {
                if (triplets.ContainsKey(triplet))
                {
                    triplets[triplet] += 1;
                }
                else
                {
                    triplets[triplet] = 1;
                }
            }
     
        }
    }
    static void WorkWithText(ref string text)
    {
        string text_sub1 = text.Substring(0, (text.Length / 2) + 1);
        string text_sub2 = text.Substring((text.Length / 2) - 1, text.Length - (text.Length / 2) + 1);
        Task taskFirst = new Task(() => CountTriplets(text_sub1));
        Task taskSecond = new Task(() => CountTriplets(text_sub2));
        taskFirst.Start();
        taskSecond.Start();
        taskFirst.Wait();
        taskSecond.Wait();
    }
    static void Main(string[] args)
    {
        // /Users/karinamavletova/desktop/test.txt
        string text; 
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        Console.Write("Enter the path to the file: ");
        string path = Console.ReadLine();
        try
        {
            using (StreamReader sr = new StreamReader(path))
            {
                while ((text = sr.ReadLine())!=null)
                {
                    if (text.Length >= 3)
                    {
                        WorkWithText(ref text);
                    }   
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Problem: " + e.Message);
            return;
        }
        if (triplets.Count == 0)
        {
            Console.WriteLine("There is no triplets in this text!");
            return;
        }
        Console.WriteLine("The 10 (or less) most common triplets in the text from the file " + Path.GetFileName(path) + ":");
        int count = 0;
        var sortedTriplets = triplets.OrderByDescending(x => x.Value);
        foreach (var triplet in sortedTriplets)
        {
            Console.WriteLine(triplet.Key + ":" + triplet.Value);
            count += 1;
            if (count == 10)
            {
                break;
            }
        }
        stopwatch.Stop();
        Console.Write("Programm working time: ");
        Console.WriteLine(stopwatch.Elapsed.TotalMilliseconds);
    }
   
}
