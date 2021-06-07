using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualPet
{
    public class Robot : Pet
    {
        public Robot(string name, string species)
        {
            Random rand = new Random();
            Name = name;
            Species = species;
            Hunger = rand.Next(40, 60);
            Health = rand.Next(20, 40);
            Boredom = rand.Next(50, 70);
        }

        public override void PrintStats()
        {
            Console.WriteLine($"--  Battery Used: {Hunger} | Boredom: {Boredom} | Oil level: {Health}\n");
        }
    }
}
