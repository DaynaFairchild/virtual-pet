using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualPet
{
    public class Organic : Pet
    { 
        public override void PrintStats()
        {
            Console.WriteLine($"--  Hunger: {Hunger} | Boredom: {Boredom} | Health: {Health}\n");
        }
    }
}
