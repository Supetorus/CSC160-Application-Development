using System;
using System.Collections.Generic;

namespace ConsoleLibrary
{
    public class IO
    {
        public static ConsoleColor textColor = ConsoleColor.Gray;
        public static ConsoleColor backgroundColor = ConsoleColor.Black;

        public static void println(string str)
        {
            Console.ForegroundColor = textColor;
            Console.BackgroundColor = backgroundColor;
            Console.WriteLine(str);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.BackgroundColor = ConsoleColor.Black;
        }

        public static void print(string str)
        {
            Console.ForegroundColor = textColor;
            Console.BackgroundColor = backgroundColor;
            Console.Write(str);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.BackgroundColor = ConsoleColor.Black;
        }

        public static int GetConsoleInt(string message, int min = int.MinValue, int max = int.MaxValue)
        {
            if (max < min) throw new System.ArgumentException("Min must be less than max.");
            bool success = false;
            int typedValue;

            do
            {
                print(message);

                success = int.TryParse(Console.ReadLine(), out typedValue)
                    && typedValue >= min && typedValue <= max;

                if (!success)
                {
                    println($"You entered an invalid number. Must be between {min} and {max} and a valid integer.");
                }
            } while (!success);
            return typedValue;
        }

        public static float GetConsoleFloat(string message, float min = float.MinValue, float max = float.MaxValue)
        {
            bool success = false;
            float typedValue;

            do
            {
                Console.Write(message);

                success = float.TryParse(Console.ReadLine(), out typedValue)
                    && typedValue >= min && typedValue <= max;

                if (!success)
                {
                    println($"You entered an invalid number. Must be between {min} and {max} and a valid number.");
                }
            } while (!success);
            return typedValue;
        }

        public static bool GetConsoleBool(string message)
        {
            bool success = false;
            bool typedValue;

            do
            {
                Console.Write(message);

                success = bool.TryParse(Console.ReadLine(), out typedValue);

                if (!success)
                {
                    println("You entered an invalid input. Must be true or false.");
                }
            } while (!success);
            return typedValue;
        }

        public static char GetConsoleChar(string message)
        {
            bool success = false;
            char typedValue;

            do
            {
                Console.Write(message);

                success = char.TryParse(Console.ReadLine(), out typedValue);

                if (!success)
                {
                    println("You entered an invalid input.");
                }
            } while (!success);
            return typedValue;
        }

        public static string GetConsoleString(string message)
        {
            Console.Write(message);
            return Console.ReadLine();
        }

        public static int GetConsoleMenu(List<string> items)
        {
            return GetConsoleMenu(items.ToArray());
        }

        public static int GetConsoleMenu(string[] items)
        {
            bool invalidInput = true;
            int input;
            do
            {
                for (int i = 0; i < items.Length; i++)
                {
                    println($"{i+1} - {items[i]}");
                }

                invalidInput = !int.TryParse(Console.ReadLine(), out input)
                    || input < 1 || input > items.Length;

            } while (invalidInput);

            return input;
        }
    }
}
