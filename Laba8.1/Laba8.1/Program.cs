﻿using System;
using System.Collections.Generic;
using System.Timers;
using System.IO;

namespace Laba8._1
{
    class Subtitles
    {
        public string _position;

        public string _color;

        public int _startTime;

        public int _endTime;

        public string _text;

        public Subtitles(string position, string color, int startTime, int endTime, string text)
        {
            _position = position;
            _color = color;
            _startTime = startTime;
            _endTime = endTime;
            _text = text;
        }
    }

    static class Program
    {
        static void Main(string[] args)
        {
            ReadFile();
            CreateScreen();
            StartTimer();
            Console.ReadKey();
        }

        private static readonly int _width = Console.WindowWidth;
        private static readonly int _height = Console.WindowHeight;

        static Timer _aTimer;
        static int _time = 0;
        static List<Subtitles> _subtitles;


        // Считывает данные с файла
        private static void ReadFile()
        {
            string[] line = File.ReadAllLines("taskOneTest.txt");
            _subtitles = new List<Subtitles>();
            foreach (string words in line)
                if (words != "")
                    _subtitles.Add(GetParameters(words));
        }

        // Запускает таймер
        private static void StartTimer()
        {
            _aTimer = new Timer(1000);
            _aTimer.Elapsed += Tick;
            _aTimer.AutoReset = true;
            _aTimer.Enabled = true;
        }

        static void Tick(Object source, ElapsedEventArgs e)
        {
            foreach (Subtitles subtitle in _subtitles)
            {
                if (subtitle._startTime == _time)
                    Write(subtitle);
                else if (subtitle._endTime == _time)
                    Delete(subtitle);
            }
            _time++;
        }

        private static void Write(Subtitles subtitle)
        {
            SetPosition(subtitle._position, subtitle._text.Length);
            SetColor(subtitle._color);
            Console.WriteLine(subtitle._text);
        }

        private static void Delete(Subtitles subtitle)
        {
            SetPosition(subtitle._position, subtitle._text.Length);
            for (int i = 0; i < subtitle._text.Length; i++)
                Console.Write(" ");
        }

        private static Subtitles GetParameters(string words)
        {
            string text;
            string position = "Bottom";
            string color = "White";
            string[] timeDuration = words[..13].Replace(" ", "").Split('-');
            string[] timeStart = timeDuration[0].Split(':');
            string[] timeEnd = timeDuration[1].Split(':');
            int startTime = int.Parse(timeStart[0]) * 60 + int.Parse(timeStart[1]);
            int endTime = int.Parse(timeEnd[0]) * 60 + int.Parse(timeEnd[1]);
            if (words.Contains('['))
            {
                string[] textInfo = words.Substring(words.IndexOf('[') + 1, words.IndexOf(']') - words.IndexOf('[') - 1).Split(',');
                position = textInfo[0].Replace(" ", "");
                color = textInfo[1].Replace(" ", "");
                text = words.Substring(words.IndexOf(']') + 2, words.Length - words.IndexOf(']') - 2);
            }
            else
                text = words[14..];
            return new Subtitles(position, color, startTime, endTime, text);
        }

        // Определяет цвет текста
        private static void SetColor(string color)
        {
            switch (color)
            {
                case "Red":
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case "Green":
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case "Blue":
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                case "White":
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
            }
        }

        // Определяет расположение текста
        private static void SetPosition(string position, int textLength)
        {
            switch (position)
            {
                case "Top":
                    Console.SetCursorPosition((_width - 2) / 2 - textLength / 2, 1);
                    break;
                case "Bottom":
                    Console.SetCursorPosition((_width - 2) / 2 - textLength / 2, _height - 2);
                    break;
                case "Right":
                    Console.SetCursorPosition(_width - 1 - textLength, (_height - 2) / 2);
                    break;
                case "Left":
                    Console.SetCursorPosition(1, (_height - 2) / 2);
                    break;
            }
        }

        // Создаёт экран в консоли
        private static void CreateScreen()
        {
            for (int i = 0; i < _width; i++)
                Console.Write("-");
            Console.WriteLine();
            for (int i = 0; i < _height - 2; i++)
            {
                Console.Write("|");
                for (int j = 0; j < _width - 2; j++)
                    Console.Write(" ");
                Console.WriteLine("|");
            }
            for (int i = 0; i < _width; i++)
                Console.Write("-");
        }
    }
}