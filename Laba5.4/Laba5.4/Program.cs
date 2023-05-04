using System;
using System.Globalization;

namespace Laba5._4
{
    //Пользователь вводит массив.Числа могут быть положительными, отрицательными, целыми или дробными.
    //Заменить все положительные целые числа в массиве на их факториал.
    //Отрицательные целые числа оставить без изменений. Любое дробное число заменить на его дробную часть
    //с откинутой целой частью, округленную до сотых.
    class Program
    {
        static void Main(string[] args)
        {
            GetString();
        }
        // Принимает строку на ввод
        static public void GetString()
        {
            Console.WriteLine("Введите элементы массива через пробел");
            string inputData = Console.ReadLine();
            ConvertToArray(inputData);
        }

        // Конвертирует строку в массив и изменяет его
        static void ConvertToArray(string inputdata)
        {
            string[] array = inputdata.Split(" ");
            PrintArray(array);
            for (int i = 0; i < array.Length; i++)
            {
                if (int.TryParse(array[i], out int value))
                {
                    if (value >= 0)
                        array[i] = Factorial(value);
                }
                else
                    array[i] = GetFractionalPart(array[i]);
            }
            PrintArray(array);
        }

        // Вычисляет факториал целого положительного числа
        static string Factorial(int value)
        {
            int result = 1;
            for (int i = 1; i <= value; i++)
                result *= i;
            if (value == 0)
                result = 1;
            return result.ToString();
        }

        // Получает дробную часть числа, округлённую до сотых
        static string GetFractionalPart(string str)
        {
            double value = double.Parse(str, CultureInfo.InvariantCulture);
            if (value < 0)
                value *= -1;
            value = (int)((value - (int)value) * 100);
            return value.ToString();
        }

        // Выводит массив
        static void PrintArray(string[] array)
        {
            foreach (string item in array)
                Console.Write($"| {item} |");
            Console.WriteLine();
        }
    }
}