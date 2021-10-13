using System;
using System.Collections.Generic;
using System.Text;

namespace Foundation
{
    public class MyString
    {
        //call this in program.cs

        public static void Execute()
        {
            string randomString = "Neumont College of Computer Science";

            Console.WriteLine(randomString);

            Console.WriteLine("Length: {0}", randomString.Length);
            Console.WriteLine("Contains 'of': {0}", randomString.Contains("of"));
            int indexOf = randomString.IndexOf("of");
            Console.WriteLine("IndexOf Contains: {0}", indexOf != -1 ? indexOf.ToString() : "Not found");

            Console.WriteLine("Remove: {0}", randomString.Remove(indexOf, 3)); //with space

            //all these operations return a new string. It does not change the original string.
            //Reason for this is string is immutable. It cannot be changed. New string is always created.

            Console.WriteLine(randomString);

            //String builder handles a string, but allows you to add and remove from it. Its mutable

            StringBuilder sb = new StringBuilder("This is a string builder.", 255);
            sb.Append(" It is really neat!");

            Console.WriteLine("StringBuilder: {0}", sb);
        }
    }
}