using System;
using System.Collections.Generic;
using System.Text;

namespace Foundation
{
    class Generics
    {
        public static void Engage()
        {
            int one = 1;
            int two = 2;

            Console.WriteLine($"one: {one}, two: {two}");
            Swap(ref one, ref two);
            Console.WriteLine($"one: {one}, two: {two}");
        }

        static void Swap<T>(ref T first, ref T second)
        {
            T temp = first;
            first = second;
            second = temp;
        }
    }
}
