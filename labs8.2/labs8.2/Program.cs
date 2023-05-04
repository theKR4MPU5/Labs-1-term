using System;
using System.Collections.Generic;
using System.IO;

namespace Labs8._2
{
    static class Program
    {
        public static List<string> _date = new List<string>();

        public static List<int> _money = new List<int>();

        public static List<string> _operation = new List<string>();

        public static List<int> _result = new List<int>();

        static void Main(string[] args)
        {
            GetRequest();
        }

        // Получает строку с запросом данных
        public static void GetRequest()
        {
            Console.WriteLine("Введите дату и время совершённой операции");
            string inputData = Console.ReadLine().Trim();
            ReadFile();
            CheckNullString(inputData);
        }

        // Считывает данные с файла
        public static void ReadFile()
        {
            string[] line = File.ReadAllLines("test.txt");
            _result.Add(int.Parse(line[0]));
            for (int i = 1; i < line.Length; i++)
            {
                string[] word = line[i].Split(" | ");
                _date.Add(word[0]);
                if (word.Length == 3)
                {
                    _money.Add(int.Parse(word[1]));
                    _operation.Add(word[2]);
                }
                else
                {
                    _money.Add(0);
                    _operation.Add(word[1]);
                }
                Operation(i - 1);
            }
        }

        // Проверяет, является ли введённая строка пустой
        public static void CheckNullString(string inputData)
        {
            if (!string.IsNullOrEmpty(inputData))
                Console.WriteLine(_result[_date.IndexOf(inputData)]);
            else
                Console.WriteLine(_result[_result.Count - 1]);
        }

        // Считывает операции с файла
        public static void Operation(int i)
        {
            int result = default;
            switch (_operation[i])
            {
                case "in":
                    result = _result[i] + _money[i];
                    _result.Add(result);
                    break;
                case "out":
                    result = _result[i] - _money[i];
                    CheckError(result);
                    _result.Add(result);
                    break;
                case "revert":
                    _result.Add(_result[i - 2]);
                    break;
            }
        }

        // Проверяет корректность данных в файле
        public static void CheckError(int result)
        {
            if (result < 0)
            {
                Console.WriteLine("Error: В файле неверно введены данные");
                Environment.Exit(0);
            }
        }
    }
}