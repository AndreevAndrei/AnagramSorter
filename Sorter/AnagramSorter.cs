using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SorterNS
{
    public class AnagramSorter
    {
        /// <summary>
        /// Группировка слов по признаку анаграмм.
        /// </summary>
        /// <param name="wordsArray">Одномерный массив негруппированных слов.</param>
        /// <returns>Список слова группированных по признаку анаграмм</returns>
        public static List<List<string>> Group(string[] wordsArray)
        {
            var tagToExamplesDictionary = new Dictionary<string, List<string>>();
            foreach (string word in wordsArray)
            {
                char[] temp = word.ToLower().ToCharArray();
                Array.Sort(temp);
                var tag = new string(temp);

                if (!tagToExamplesDictionary.ContainsKey(tag))
                {
                    tagToExamplesDictionary.Add(tag, new List<string>());
                }
                tagToExamplesDictionary[tag].Add(word);
            }

            return tagToExamplesDictionary.Values.ToList();
        }


        /// <summary>
        /// Преобразует массива слов в читабельную строку.
        /// <param name="words">Входные слова.</param>
        public static string ToString(string[] words)
        {
            StringBuilder sb = new StringBuilder("[\"");
            sb.AppendJoin("\", \"", words);
            sb.Append("\"]");

            return sb.ToString();
        }
        /// <summary>
        /// Преобразует список группированных слов в читабельную строку.
        /// </summary>
        /// <param name="listOfWords">Группированные по какому-то признаку слова.</param>
        public static string ToString(List<List<string>> listOfWords)
        {
            StringBuilder sb = new StringBuilder("[\r\n");
            foreach (List<string> words in listOfWords)
            {
                sb.AppendFormat("\t[\"{0}\"]\r\n", string.Join("\", \"", words));
            }
            sb.Append("]");

            return sb.ToString();
        }

        /// <summary>
        /// Имитация задания аналогичного тестовому. Удобна для запуска из среды. Можно передать кастомные параметры.
        /// </summary>
        /// <param name="words">Слова являются аргумантами через пробел. Если не задать - будет использован дефолтный список.</param>
        static void Main(string[] words)
        {
            if (words.Length == 0)
            {
                words = new string[] { "ток", "рост", "кот", "торс", "Кто", "фывап", "рок" };
            }

            var result = Group(words);
            Console.WriteLine("Input: {0}\r\nOutput:\r\n{1}", ToString(words), ToString(result));
        }
    }
}
