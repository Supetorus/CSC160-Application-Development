using System;
using System.Collections.Generic;
using System.Text;

namespace Foundation
{
    class DataTypes
    {
        public static void Execute()
        {
            short shortNum = 32767; //16-bit
            int integer = 10; //32-bit
            uint uInteger = 50; //32-bit
            long longNum = 9999; //64-bit
            float floatNum = 10.5f; //4-bytes
            double doubNumber = 500.6; //8-bytes
            decimal decNum = 602.25M; //16-bytes

            Console.WriteLine("short : {0}", shortNum);
            Console.WriteLine("short min: {0}", short.MinValue);
            Console.WriteLine("short min: {0}", short.MaxValue);

            Console.WriteLine();

            Console.WriteLine("int : {0}", integer);
            Console.WriteLine("int min: {0}", int.MinValue);
            Console.WriteLine("int min: {0}", int.MaxValue);

            Console.WriteLine();

            Console.WriteLine("uInt : {0}", uInteger);
            Console.WriteLine("uInt min: {0}", uint.MinValue);
            Console.WriteLine("uInt min: {0}", uint.MaxValue);

            Console.WriteLine();

            Console.WriteLine("long : {0}", longNum);
            Console.WriteLine("long min: {0}", long.MinValue);
            Console.WriteLine("long min: {0}", long.MaxValue);

            Console.WriteLine();

            Console.WriteLine("float : {0}", floatNum);
            Console.WriteLine("float min: {0}", float.MinValue);
            Console.WriteLine("float min: {0}", float.MaxValue);

            Console.WriteLine();

            Console.WriteLine("double : {0}", doubNumber);
            Console.WriteLine("double min: {0}", double.MinValue);
            Console.WriteLine("double min: {0}", double.MaxValue);

            Console.WriteLine();

            Console.WriteLine("decimal : {0}", decNum);
            Console.WriteLine("decimal min: {0}", decimal.MinValue);
            Console.WriteLine("decimal min: {0}", decimal.MaxValue);

            Console.WriteLine();

            //char is a static class (look at its fields)
            char c = 'R';
            Console.WriteLine("Char is: {0}", c);
            Console.WriteLine("IsDigit: {0}", char.IsDigit(c));
            Console.WriteLine("IsLetter: {0}", char.IsLetter(c));
        }
    }
}

