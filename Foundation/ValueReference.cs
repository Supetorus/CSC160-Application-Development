using System;
using System.Collections.Generic;
using System.Text;

namespace Foundation
{
    public class ValueReference
    {

        public static void Execute()
        {

            //Value types
            int v1 = 10;
            int v2 = v1;
            Console.WriteLine("Value type v1: {0}", v1);
            Console.WriteLine("Value type v2: {0}", v2);

            v1 = 5;
            Console.WriteLine("Value type v1: {0}", v1);
            Console.WriteLine("Value type v2: {0}", v2);

            // Reference types

            int[] numbers1 = new int[] { 1, 2, 3 };
            int[] numbers2 = numbers1;
            Console.WriteLine("Ref type v1: {0}", String.Join(", ", numbers1));
            Console.WriteLine("Ref type v2: {0}", String.Join(", ", numbers2));

            numbers1[0] = 5;
            Console.WriteLine("Ref type v1: {0}", String.Join(", ", numbers1));
            Console.WriteLine("Ref type v2: {0}", String.Join(", ", numbers2));

            //custom value types

            Point p1 = new Point(10, 20);
            Point p2 = p1;

            p1.Write();
            p2.Write();

            p1.x = 200;
            p1.Write();
            p2.Write();

            //change struct to class and rerun


        }


        /// <summary>
        /// Struct is very similar to a class with addtional rules. 
        /// Is a value type instead of reference type
        /// Can't have empty constructor
        /// </summary>
        struct Point
        {
            public int x;
            public int y;

            public Point(int x, int y)
            {
                this.x = x;
                this.y = y;
            }

            public void Write()
            {
                Console.WriteLine("{0} - {1}", x, y); //string format
                //Console.WriteLine($"{x} - {y}"); //string interpretation
                //Console.WriteLine(x + " - " + y); //string concat
            }
        }
    }

}