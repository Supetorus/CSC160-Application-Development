using System;
using System.Collections.Generic;
using System.Text;

namespace Foundation
{
    class Converting
    {
        public static void Execute()
        {
            // Implicit conversion. A long can hold any value an int can hold...
            //For built-in numeric types, an implicit conversion can be made when the value to be stored can fit into the variable without being truncated or rounded off.
            int intNum = 1147489647;
            long lngBigNum = intNum;
            var c = 'C';
            //Console.WriteLine("var type: {0}", c.GetType());

            //Exlicit Conversions
            //if a conversion cannot be made without a risk of losing information, the compiler requires that you perform an explicit conversion, which is called a cast.
            //A cast is a way of explicitly informing the compiler that you intend to make the conversion and that you are aware that data loss might occur, or the cast may fail at runtime.
            double x = 1234.7;
            int a;
            // Cast double to int.
            a = (int)x;
            //System.Console.WriteLine(a);

            //int intWasString = "5"; 
            string strNum = "5";
            int intResult = 0;
            //intResult = int.Parse(strNum);
            Console.WriteLine("Parse: {0} {1}", intResult, intResult.GetType());
            //bool bSuccess = int.TryParse(strNum, out intResult);
            //Console.WriteLine(strNum + " converts to int? " + bSuccess);

        }
    }
}
