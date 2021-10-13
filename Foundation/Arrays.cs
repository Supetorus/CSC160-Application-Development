using System;
using System.Collections.Generic;
using System.Text;

namespace Foundation
{
    public class Arrays
    {
        public static void Execute()
        {
            int[] myArray1 = new int[3];
            myArray1[0] = 55;
            myArray1[1] = 125;
            myArray1.SetValue(23, 2);
            myArray1 = new int[6];
            //defaults to zero if nothing in it
            //all other types usually go to null (nothing in it)

            //implicititly knows its an int array
            int[] myArray2 = { 1, 2, 3, 4 };
            //short hand (above) vs long hand (below)
            int[] myArray3 = new int[] { 1, 2, 3, 4 };

            //testing out how indexing into it works
            for (int i = 0; i < myArray1.Length; i++)
            {
                Console.Write("{0} ", myArray1[i]);
            }

            Console.WriteLine(); //just goes to next line

            //Iterating over without caring about index
            foreach (int number in myArray1)
            {
                Console.Write("{0} ", number);
                //continue; immediately goes to next iteration ignoring all code after
                //break; exits the foreach loop entirely
            }

            Console.WriteLine();

            //array to allow multiple types
            //everything in C# is derived from object
            object[] myThings = new object[] { 10, "Bob", 10.4f };

            //multi dimension arrays
            //grid based rows and columns
            string[,] alphabet = new string[2, 2] { { "A", "B" }, { "C", "D" } };

            //GetLength(0) is row
            //GetLength(1) is column
            for (int row = 0; row < alphabet.GetLength(0); row++)
            {
                for (int column = 0; column < alphabet.GetLength(1); column++)
                {
                    Console.Write("{0} ", alphabet[row, column]);
                }
                Console.WriteLine();
            }

            Console.WriteLine();

            //Jagged array
            //could define rows, but columns could be varying sizes
            //define row size, but not columns.
            //maybe useful for bar chart data?
            int[][] jagged = new int[3][];

            jagged[0] = new int[] { 1, 2, 3, 4 };
            jagged[1] = new int[] { 5, 6, 7 };
            jagged[2] = new int[] { 8, 9, 10, 11, 12, 13 };


            //create the void WriteArray method below (extract code you use a lot to methods)
            //show how slicing works
            int[] numbers = { 1, 2, 3, 4, 5, 6 };

            WriteArray(numbers);
            //two dots are the range from beginning to end what you want to slice
            //This is exclusive. It does not include index 3
            //first/last number not required if you want to start from beginning or go until end
            WriteArray(numbers[..3]);
            WriteArray(numbers[1..4]);
            WriteArray(numbers[4..]);


            //Array object has many functions
            //Static function to reverse numbers - Note this will modify the original array
            Array.Reverse(numbers);
            WriteArray(numbers);

            Array.Sort(numbers);
            WriteArray(numbers);

            Console.WriteLine("Find index of 6: {0}", Array.IndexOf(numbers, 6));

            //Find all numbers less than 4
            //Takes a method that returns a true/false (predicate)
            //Array.Find finds first instance
            Console.Write("All numbers less than 4: ");
            WriteArray(Array.FindAll(numbers, LessThanFour));
        }

        static void WriteArray(int[] values)
        {
            for (int i = 0; i < values.Length; i++)
            {
                Console.Write("{0}", values[i]);
            }
            Console.WriteLine();

            //show String.Join(", ", array); ?
        }

        static bool LessThanFour(int value)
        {
            return value < 4;
        }
    }
}