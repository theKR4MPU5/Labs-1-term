using System;
using System.Collections.Generic;

namespace Laba8._3
{
    static class Program
    {
        private static readonly List<string> _originalList = new() { "code", "doce", "ecod", "framer", "frame" };

        private static List<bool> _isAnagrams = new();

        private static List<string> _resultList = new();

        static void Main(string[] args)
        {
            FindAnagrams();
        }

        // Находит анаграмы в массиве
        static void FindAnagrams()
        {
            string word;
            for (int i = 0; i < _originalList.Count; i++)
            {
                word = _originalList[i];
                _isAnagrams.Add(false);
                if (!_isAnagrams[i])
                {
                    _resultList.Add(word);
                    for (int numWordCheck = i + 1; numWordCheck < _originalList.Count; numWordCheck++)
                    {
                        for (int numLetter = 0; numLetter < word.Length; numLetter++)
                        {
                            if (!_originalList[numWordCheck].Contains(word[numLetter]))
                            {
                                _resultList.Add(_originalList[numWordCheck]);
                                break;
                            }
                        }
                        _isAnagrams.Insert(numWordCheck, true);
                    }
                }
            }
            PrintOriginalList();
            PrintResult();
        }

        // Выводит начальный массив
        private static void PrintOriginalList()
        {
            Console.Write("Исходный массив -> ");
            foreach (string word in _originalList)
                Console.Write($"{word} ");
        }

        // Выводит отсортированный массив без анаграм
        private static void PrintResult()
        {
            Console.Write("\nОтсортированный массив -> ");
            _resultList.Sort();
            foreach (string word in _resultList)
                Console.Write($"{word} ");
        }
    }
}