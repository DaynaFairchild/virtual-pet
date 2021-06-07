using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualPet
{
    public class Robot : Pet
    {
        public override void PrintStats()
        {
            Console.WriteLine($"--  Battery Used: {Hunger} | Boredom: {Boredom} | Oil level: {Health}\n");
        }
    }
}
