using System;
namespace TextAnalysis
{
	public class TemplateSearch
	{
        static int[]? prefixes;
        /// <summary>
        /// Составление массива префиксов
        /// </summary>
        /// <param name="pattern">триплет, который рассматривается, как шаблон</param>
        private static void Prefixes(string pattern)
		{
            prefixes = new int[pattern.Length];
            
            int j = 0, i = 1;
            while (i < pattern.Length)
            {
                if (pattern[i] == pattern[j])
                {
                    prefixes[i] = j + 1;
                    j++;
                    i++;
                }
                else if (j == 0)
                {
                    prefixes[i] = 0;
                    i++;
                }
                else
                {
                    j = prefixes[j - 1];
                }
            }
        }

        /// <summary>
        /// Для начала вызываем метод, который составляет массив префиксов.
        /// Далее, используя массив префиксов, исходный текст и триплет считаем кол-во вхождений.
        /// Как раз этот метод реализует идею алгоритма Кнута—Морриса—Пратта.
        /// </summary>
        /// <param name="text">текст, в котором считаем кол-во соотв. триплетов, передаётся по ссылке</param>
        /// <param name="pattern">триплет, кол-во вхождений которого следует подсчитать</param>
        /// <returns></returns>
		public static int KmpAlgorithm(ref string text, string pattern)
		{
            Prefixes(pattern);
            int count_patterns = 0;
            int j = 0;
            for (int i = 0; i < text.Length; ++i)
            {
                while (j > 0 && text[i] != pattern[j])
                {
                    if (prefixes is not null)
                    {
                        j = prefixes[j - 1];
                    }
                    
                }
                if (text[i] == pattern[j])
                {
                    j++;
                }
                if (j == pattern.Length)
                {
                    count_patterns++;
                    j = 0;
                }
            }
            return count_patterns;
        }
	}
}

