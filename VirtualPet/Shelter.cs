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

       
        public void ListPets(bool withStats)
        {
            int i = 1;
            foreach (Pet pet in petList)
            {
                Console.WriteLine($"{i}. {pet.Name} ({pet.Species})");
                if (withStats)
                    pet.PrintStats();
                i++;
            }
            Console.WriteLine();
        }

        public Pet ChoosePet()
        {
            Console.Write("Please choose a pet (enter a number): ");
            int petNumber = Convert.ToInt32(Console.ReadLine());
            Pet chosenPet = petList[petNumber - 1];
            return chosenPet;
        }

    }
}
