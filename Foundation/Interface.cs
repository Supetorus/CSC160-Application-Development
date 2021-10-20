using System;
using System.Collections.Generic;
using System.Text;

namespace Foundation
{
    public static class Interface
    {
        public static void Execute()
        {
            Inheritance.Animal bird = new Bird();
            bird.Name = "Sally";
            if(bird is Bird flyingBird)
            {
                flyingBird.Fly();
            }

            Bird bird1 = new Bird();
            bird1.Name = "George";
            bird1.Fly();

            Inheritance.Animal bear = new Bear();
            bear.Name = "Johnny";
            ((Bear)bear).Sleep();
        }
    }

    class Bird : Inheritance.Animal, IFly
    {
        public void Fly()
        {
            Console.WriteLine(Name + " flaps their wings.");
        }
    }

    interface IFly
    {
        public void Fly();
    }

    interface ISleep
    {
        public void Sleep();
    }

    class Bear : Inheritance.Animal, ISleep
    {
        public void Sleep()
        {
            Console.WriteLine(Name + " sleeps");
        }
    }
}
