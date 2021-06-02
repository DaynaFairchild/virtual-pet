using System;
using System.Collections.Generic;
using System.Text;

namespace VirtualPet
{
    public class Pet
    {
        public string Name { get; set; }
        public string Species { get; set; }
        public int Hunger { get; set; }
        public int Boredom { get; set; }
        public int Health { get; set; }

        public int GetHunger()
        {
            Hunger = 50;
            return Hunger;
        }
        public int GetBoredom()
        {
            Boredom = 60;
            return Boredom;
        }
        public int GetHealth()
        {
            Health = 30;
            return Health;
        }






    }
}
