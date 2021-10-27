using System;
using System.Collections.Generic;
using System.Text;

namespace Foundation
{
    class Extensions
    {
        public static void Execute()
        {
            string helloWorld = "abcdefghijklmnopqrstuvwxyz";

            Console.WriteLine(helloWorld.Shift(-100));
        }
    }

    public static class StringHelper
    {
        public static bool IsFirstCap(this string strIn)
        {
            return char.IsUpper(strIn[0]);
        }

        public static string AppendToEnd(this string incoming, string append)
        {
            return incoming + append;
        }

        public static string Flip(this string str)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = str.Length-1; i >= 0; i--)
            {
                sb.Append(str[i]);
            }
            return sb.ToString();
        }

        public static string Shift(this string str, int shift)
        {
            string alphabet = "abcdefghijklmnopqrstuvwxyz";

            shift = shift % alphabet.Length;

            StringBuilder sb = new StringBuilder();
            foreach (char letter in str.ToLower())
            {
                if (alphabet.Contains(letter))
                {
                    int index = (alphabet.IndexOf(letter) + shift) % alphabet.Length;
                    index = index < 0 ? alphabet.Length + index : index;
                    sb.Append(alphabet[index]);
                }
                else sb.Append(letter);
            }
            return sb.ToString();
        }
    }
}
