using System;

namespace Laba5._2
{
    class Program
    {
        //Пользователь вводит целочисленное число. 
        //Нужно проверить, что число корректно без использования любого стороннего преобразования строки
        //в число, т.е.нельзя использовать int.Parse(), int.TryParse(), Convert.ToInt() и т.д..Если нет,
        //то вывести сообщение и завершить программу.Если корретно, то опять же без вызова сторонних методов
        //и без конвертирования строки в число найти сумму цифр введенного числа.
        static void Main(string[] args)
        {
            CheckValue();
        }

        // Проверяет, введено ли целое число
        static public void CheckValue()
        {
            Console.WriteLine("Введите целое число: ");
            string inputData = Console.ReadLine();
            if (CheckEqualSymbols(inputData))
                PrintResult(GetNumerSum(inputData));
            else
            {
                Console.WriteLine($"{inputData} - это не число или оно нецелое");
                return;
            }
        }

        // Считает сумму цифр числа
        static int GetNumerSum(string inputData)
        {
            int result = 0;
            int value;
            for (int i = 0; i < inputData.Length; i++)
            {
                switch (inputData[i])
                {
                    case '1':
                        value = 1;
                        break;
                    case '2':
                        value = 2;
                        break;
                    case '3':
                        value = 3;
                        break;
                    case '4':
                        value = 4;
                        break;
                    case '5':
                        value = 5;
                        break;
                    case '6':
                        value = 6;
                        break;
                    case '7':
                        value = 7;
                        break;
                    case '8':
                        value = 8;
                        break;
                    case '9':
                        value = 9;
                        break;
                    default:
                        value = 0;
                        break;
                }
                result += value;
            }
            return result;
        }

        // Выводит результат в консоль
        static void PrintResult(int result)
        {
            Console.Write($"Сумма цифр числа = {result}");
        }

        // Проверяет, равны ли символы строки цифрам 
        static bool CheckEqualSymbols(string str)
        {
            bool isDigit = true;
            foreach (char symbol in str)
                if (!char.IsDigit(symbol)) isDigit = false;
            return isDigit;
        }
    }
}