using System;
using System.Collections.Generic;
using System.Text;

namespace Foundation
{
    class Classes
    {
        public static void Execute()
        {
            float circ = 2 * Math.PI * 2.0f;
            circ = Math.CalculateCirc(2.0f);

            ExampleProps ep = new ExampleProps();
            ep.prop2 = "bob";
            string prop2 = ep.prop2;
            string prop3 = ep.Prop3;

            Student milton = new Student(45);
            milton.Name = "Milton";
            Console.WriteLine("Student's name is: {0}, age: {1}", milton.Name, milton.Age);
        }

        class Student
        {
            private string name;
            private int cohort = 36;
            private float gpa;

            public string Name
            {
                get { return name; }
                set { name = value; }
            }

            public float GPA
            {
                get { return gpa; }
                set
                {
                    if (value >= 0 && value <= 4.0f) gpa = value;
                }
            }

            public int Age = 21;
            static int numberOfStudents = 0;

            public Student(int Age)
            {
                this.Age = Age;
                Console.WriteLine("In Constructor");
                numberOfStudents++;
            }

            public void HowManyStudents()
            {
                Console.WriteLine("Number of students: {0}", numberOfStudents);
            }
        }

        static class Math
        {
            public const float PI = 3.14159f;

            public static float CalculateCirc(float radius)
            {
                return 2 * PI * radius;
            }
        }

        class ExampleProps
        {
            public string prop2;
            private string prop3;

            public string Prop3
            {
                get
                {
                    return prop3;
                }
                set
                {
                    prop3 = value;
                }
            }
        }
    }
}
