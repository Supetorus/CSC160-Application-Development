using System;
using System.Collections.Generic;
using System.Text;

namespace Foundation
{
    class Practice
    {
        public static void Execute()
        {
            Animal dog = new Dog("Johnny the dog");
            Animal cat = new Cat("Sally the cat");
            Animal fish = new Fish("Sylvia the fish");
            Animal[] animals = new Animal[3] { dog, cat, fish };
            foreach (Animal animal in animals)
            {
                Console.Write("Speak() - "); animal.Speak();
                Console.Write("Move()  - "); animal.Move();
            }

            IPettable[] pettables = new IPettable[2] { (IPettable)dog, (IPettable)cat };
            foreach (IPettable p in pettables)
            {
                Console.Write("Pet()   - "); p.Pet();
            }
        }
    }

    public abstract class Animal
    {
        public string Name { get; }
        public Animal(string name)
        {
            Name = name;
        }

        public void Speak()
        {
            Console.WriteLine($"{Name} says hello!");
        }

        public virtual void Strike()
        {
            Console.WriteLine($"{Name} raises their paw and strikes");
        }

        public abstract void Move();
    }

    public class Dog : Animal, IPettable
    {
        public Dog(string name) : base(name)
        { }

        public override void Move()
        {
            Console.WriteLine($"{Name} wags its tail and walks");
        }

        public void Pet()
        {
            Console.WriteLine($"You pet {Name} and they wag their tail rapidly");
        }
    }

    public class Cat : Animal, IPettable
    {
        public Cat(string name) : base(name)
        { }

        public override void Move()
        {
            Console.WriteLine($"{Name} wags its tail and slinks");
        }

        public void Pet()
        {
            Console.WriteLine($"You pet {Name} and they hiss and glare at you.");
        }
    }

    public class Fish : Animal
    {
        public Fish(string name) : base(name)
        { }

        public override void Move()
        {
            Console.WriteLine($"{Name} gurgles and swims");
        }

        public override void Strike()
        {
            Console.WriteLine($"{Name} squirts water");
        }
    }

    public interface IPettable
    {
        public void Pet();
    }
}
