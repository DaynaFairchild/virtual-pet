using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualPet
{
    public class Shelter
    {

        public List<Pet> petList { get; set; }

        public Shelter()
        {
            petList = new List<Pet>();

        }

        public int GetPetCount()
        {
            return petList.Count;
        }

        public void AddPet(Pet petToAdd)
        {
            petList.Add(petToAdd);
        }

        public void RemovePet(Pet petToRemove)
        {
            petList.Remove(petToRemove);
        }


    }
}
