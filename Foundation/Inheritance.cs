using System;
using System.Collections.Generic;
using System.Text;

namespace Foundation
{
    public static class Inheritance
    {
        public static void Execute()
        {
            //Animal animal = new Animal() { Name = "Garfield" };
            Animal animal = new Animal("Garfield", 16);
            Animal dog = new Mammal("Ody", 14, true, true);
            
        }

        public class Animal
        {
            private int lifespan;
            public string Name { get; set; }

            public bool IsNocturnal { get; }

            public Animal() { }

            public Animal(string name, int lifespan, bool isNocturnal = false)
            {
                Name = name;
                this.lifespan = lifespan;
                this.IsNocturnal = isNocturnal;
            }

            public virtual void Speak()
            {
                Console.WriteLine(Name + " Speak (Animal) ");
            }

        }

        class Mammal : Animal 
        {
            public bool IsCarnivore { get; set; }
            public bool LivesOnLand { get; set; }

            public Mammal(string name, int lifespan, bool isCarnivore, bool livesOnLand, bool isNocturnal = false)
                : base(name, lifespan, isNocturnal)
            {
                IsCarnivore = isCarnivore;
                LivesOnLand = livesOnLand;
            }

            public override void Speak()
            {
                Console.WriteLine(Name );
            }
        }
    }
}
