using System;
using System.Collections.Generic;
using System.Globalization;

namespace Lab5._1
{
    //Пользователь вводит число.Если это целочисленное число(int.TryParse(...)),
    //то вывести на экран символ соответствующий этому числу.Если это число с плавающей запятой,
    //то сравнить это число с предыдущим введенным (float.NaN). Если эти числа равны, прекратить ввод, 
    //иначе повторить ввод.Также выполнение программы прекращается, если ввести символ q.
    class Program
    {
        static void Main(string[] args)
        {
            GetStringOnInput();
        }

        // Получает строку на в ввод 
        static public void GetStringOnInput()
        {
            Console.WriteLine("Введите число");
            string inputData = Console.ReadLine();
            if (inputData == "q")
                return;
            CheckValue(inputData);
        }

        // Выводит символ целого числа
        static void ConvertToSymbol(int value)
        {
            char symbol = Convert.ToChar(value);
            Console.WriteLine(symbol);
        }

        // Проверяет целостность введённого из строки числа,
        static void CheckValue(string inputData)
        {
            if (int.TryParse(inputData, out int value))
                ConvertToSymbol(value);
            else
                CompareFloatValues(inputData);
        }

        // Сравнивает два числа с плавающей точкой
        static void CompareFloatValues(string inputData)
        {
            List<float> list = new List<float>() { float.NaN, float.NaN };
            for (int i = 1; ; i++)
            {
                if (inputData == "q")
                    return;
                float value = float.Parse(inputData, CultureInfo.InvariantCulture);
                list[i] = value;
                if (list[i] == list[i - 1])
                    return;
                else
                {
                    list.Add(list[i]);
                    inputData = Console.ReadLine();
                }
            }
        }
    }
}