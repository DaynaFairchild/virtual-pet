using System;

namespace VirtualPet
{
    class Program
    {
        static void Main(string[] args)
        {
            Pet userPet = new Pet(); 

            Intro(userPet);

           

            bool keepPlaying = true;
            while (keepPlaying)
            {
                Console.Clear();
                Console.WriteLine($"Hunger: {userPet.Hunger} | Boredom: {userPet.Boredom} | Health: {userPet.Health}");
                Console.WriteLine($"\n What would you like to do with {userPet.Name}?");
                Console.WriteLine($"1. Feed {userPet.Name}");
                Console.WriteLine($"2. Play with {userPet.Name}");
                Console.WriteLine($"3. Take {userPet.Name} to the vet :(");
                Console.WriteLine("4. Exit");

                string userChoice = Console.ReadLine();
                switch (userChoice)
                {
                    case "1":

                    case "2":
                    case "3":
                    case "4":
                    default:
                        Console.WriteLine("Please choose from options 1-4. Press any key to be able to choose again.");
                        Console.ReadKey();
                        break;

                }
            }

        }

        public static  void Intro(Pet petToChange)
        {
            Console.WriteLine("Hello! Welcome to Virtual Pets");

            Console.WriteLine("What species would you like your pet to be?"); 
            string species = Console.ReadLine();
            petToChange.SetSpecies(species);
            Console.WriteLine($"What would you like to name your {species}?");
            string name = Console.ReadLine();
            petToChange.SetName(name);
            Console.WriteLine($"Your {species}'s name is {name}!");
            Console.WriteLine($"Like any pet, {name} needs your love and attention.");
            Console.WriteLine("Press any key to begin your new friendship.");
            Console.ReadKey();
        }
    }
}
