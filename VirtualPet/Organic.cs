using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualPet
{
    public class Organic : Pet
    {
        public string Name { get; set; }
        public string Species { get; set; }
        public int Id { get; set; }
        public int Hunger { get; set; }
        public int Boredom { get; set; }
        public int Health { get; set; }


        public Organic()
        {
            Hunger = 50; //battery
            Health = 30; //calibration 
            Boredom = 60;
        }
        public Organic(string name, string species)
        {
            Random rand = new Random();
            Name = name;
            Species = species;
            Hunger = rand.Next(40, 60);
            Health = rand.Next(20, 40);
            Boredom = rand.Next(50, 70);
        }
        public void SetName(string name)
        {
            Name = name;
        }
        public string GetName()
        {
            return Name;
        }
        public void SetSpecies(string species)
        {
            Species = species;
        }
        public string GetSpecies()
        {
            return Species;
        }

        public int GetHunger()
        {
            return Hunger;
        }
        public int GetBoredom()
        {
            return Boredom;
        }
        public int GetHealth()
        {
            return Health;
        }

        public void Feed()
        {
            if (Hunger < 40)
            {
                Hunger = 0;
                Health -= 10;
                Console.WriteLine($"You've overfed {Name} and the poor {Species} isn't feeling so well. (Health has decresed to {Health}.)\n");
            }
            else
            {
                Hunger -= 40;
                Console.WriteLine($"You fed {Name}. Yum, yum, yum!\n");
            }
        }

        public void SeeDoctor()
        {
            Console.WriteLine($"{Name} is feeling healthy!\n");
            if (Health >= 70)
            {
                Health = 100;
            }
            else
            {
                Health += 30;
            }
        }

        public void Play()
        {
            if (Hunger > 90)
            {
                Hunger = 100;
            }
            else
            {
                Hunger += 10;
            }
            if (Health > 90)
            {
                Health = 100;
            }
            else
            {
                Health += 10;
            }

            if (Boredom < 20)
            {
                Boredom = 0;
                Console.WriteLine($"{Name} is having OODLES of fun!!\n");
            }
            else
            {
                Boredom -= 20;
                Console.WriteLine($"Good times! {Name} is enjoying playing with you!\n");
            }
        }

        public void Tick()
        {
            if (Hunger > 95)
            {
                Hunger = 100;
            }
            else
            {
                Hunger += 5;
            }
            if (Boredom > 95)
            {
                Boredom = 100;
                Console.WriteLine($"{Name} passed out from sheer boredom!");
            }
            else
            {
                Boredom += 5;
            }

            if (Health < 5)
            {
                Health = 0;
            }
            else
            {
                Health -= 5;
            }
        }
    }
}
