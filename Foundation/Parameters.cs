using System;
using System.Collections.Generic;
using System.Text;

namespace Foundation
{
    public class Parameters
    {
        public static void Execute()
        {
            //create Func(int n)
            int i = 50;
            Func(i);
            Console.WriteLine("i: {0}", i);

            Console.WriteLine();

            //create RefFunc
            //ref required here and in function
            RefFunc(ref i);
            Console.WriteLine("ref i: {0}", i);

            Console.WriteLine();

            //create Swap(int, int)
            //needs to pass by ref so they actually swap
            //variables passed by ref must be initialized 
            int leftSide = 50;
            int rightSide = 100;

            Console.WriteLine("LeftSide:  {0} | RightSide: {1} ", leftSide, rightSide);
            Swap(ref leftSide, ref rightSide);
            Console.WriteLine("LeftSide:  {0} | RightSide: {1} ", leftSide, rightSide);

            Console.WriteLine();

            //out keyword
            //create OutFunc(out int n)
            //out does not require the param be initilaized before its passed
            int valueIGetBack;
            OutFunc(out valueIGetBack);
            Console.WriteLine("out valueIGetBack: {0}", valueIGetBack);
            //can declare the variable in method signature
            OutFunc(out int setupInMethodParam);
            Console.WriteLine("out setupInMethodParam: {0}", setupInMethodParam);

            //out used in tryparse
            bool success = int.TryParse("1337", out int parseValue);
            if (success)
            {
                Console.WriteLine("out parseValue: {0}", parseValue);
            }

            Console.WriteLine();

            //Create DefaultParam
            //Default params
            DefaultParam();
            DefaultParam(50);

            //create NamedFunction
            //Named Param allow us to change the order or params
            NamedFunction(20, 10);
            NamedFunction(y: 60, x: 15);

            //examples of passing variables by value, by reference, and sending array by value
            int intRef = 7;
            int[] ary = new int[] { 5, 6 };
            string strByVal = "Fred";
            RefTest clsRT = new RefTest();
            clsRT.x = 1;

            int[] ary2 = new int[2];
            ary.CopyTo(ary2, 0);

            ByValRefTest(ref intRef, strByVal, ary2, clsRT);
            //Console.WriteLine("Int ByRef: {0}", intRef);
            //Console.WriteLine("String ByVal: " + strByVal);
            //Console.WriteLine("ary[0]: {0}", ary2[0]);
            //Console.WriteLine("clsRT.x: {0}", clsRT.x);

        }

        static void Func(int n)
        {
            n += 1;
            //number passed in changed, but i from original did not. Passed by value since int (value type)
            Console.WriteLine("n: {0}", n);
        }

        static void RefFunc(ref int n)
        {
            n += 1;
            //number passed in changed, i also gets updated since referenced. Passed by reference
            Console.WriteLine("ref n: {0}", n);
        }

        static void Swap(ref int leftHandSide, ref int rightHandSide)
        {
            int temp = leftHandSide;
            leftHandSide = rightHandSide;
            rightHandSide = temp;
        }

        static void OutFunc(out int n)
        {
            n = 2000;
            Console.WriteLine("out n: {0}", n);
        }

        static void DefaultParam(int n = 20)
        {
            //creates a default set optional param (not required to be passed in)
            Console.WriteLine("Default Param: {0}", n);
        }

        static void NamedFunction(int x, int y)
        {
            Console.WriteLine("NamedParam: {0} - {1}", x, y);
        }


        public class RefTest
        {
            public int x;

        }

        public static void ByValRefTest(ref int xRef, string sVal, int[] ary, RefTest clsRefTest)
        {
            xRef = xRef * xRef;
            sVal = "Fanny";
            ary[0] = 10;
            clsRefTest.x = 88;
        }

    }
}