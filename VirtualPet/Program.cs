using System;
using System.Collections.Generic;

namespace VirtualPet
{
    class Program
    {
        public static Shelter petzForDayz = new Shelter();
        static void Main(string[] args)
        {
            
            Pet Fluffy = new Pet("Fluffy","Alligator");
            Pet Spot = new Pet("Spot", "Zebra");
            Pet Brew = new Pet("Brew", "Hippogriff");
            petzForDayz.AddPet(Fluffy);
            petzForDayz.AddPet(Spot);
            petzForDayz.AddPet(Brew);

            bool keepPlaying = true;
            while (keepPlaying)
            {
                if (userPet.Health == 0)
                {
                    Console.Clear();
                    Console.WriteLine($"WOW, {userPet.Name}'s Health Reached 0, your {userPet.Species} has been seized by Animal Protective League!");
                    Console.WriteLine("Would you like to play again? y/n");
                    string playAgain = Console.ReadLine().ToLower();
                    if (playAgain == "y")
                    {
                        Console.Clear();
                        userPet = new Pet();

                        AddNewPetIntro(userPet);
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Thanks for playing.");
                        break;
                    }
                }
                Console.Clear();
                Console.WriteLine($"Hunger: {userPet.Hunger} | Boredom: {userPet.Boredom} | Health: {userPet.Health}\n");
                Console.WriteLine($"What would you like to do with {userPet.Name}?");
                Console.WriteLine($"1. Feed {userPet.Name}");
                Console.WriteLine($"2. Play with {userPet.Name}");
                Console.WriteLine($"3. Take {userPet.Name} to the vet :(");
                Console.WriteLine("4. Exit");

                string userChoice = Console.ReadLine();
                switch (userChoice)
                {
                    case "1":
                        Console.Clear();
                        userPet.Feed();
                        continueKey();
                        Console.Clear();
                        Console.WriteLine($"Hunger: {userPet.Hunger} | Boredom: {userPet.Boredom} | Health: {userPet.Health}\n");
                        Console.WriteLine($"{userPet.Name}'s Hunger decreased to {userPet.Hunger}.");
                        continueKey();
                        break;
                    case "2":
                        Console.Clear();
                        userPet.Play();
                        continueKey();
                        Console.Clear();
                        Console.WriteLine($"Hunger: {userPet.Hunger} | Boredom: {userPet.Boredom} | Health: {userPet.Health}\n");
                        Console.WriteLine($"You played a game with {userPet.Name}. Hooray!");
                        Console.WriteLine($"{userPet.Name}'s Boredom decresed to {userPet.Boredom}, Hunger increased to {userPet.Hunger}, and Health increased to {userPet.Health}.");
                        continueKey();
                        break;
                    case "3":
                        userPet.SeeDoctor();
                        Console.Clear();
                        Console.WriteLine($"Hunger: {userPet.Hunger} | Boredom: {userPet.Boredom} | Health: {userPet.Health}\n");
                        Console.WriteLine($"You took {userPet.Name} for a checkup at the vet.");
                        Console.WriteLine($"{userPet.Name}'s Health increased to {userPet.Health}.");
                        continueKey();
                        break;
                    case "4":
                        Console.WriteLine($"Thanks for playing! {userPet.Name} has enjoyed your company!");
                        keepPlaying = false;
                        break;
                    default:
                        Console.WriteLine("Please choose from options 1-4. Press any key to be able to choose again.");
                        Console.ReadKey();
                        break;

                }
                userPet.Tick();
            }

        }

        public static void StartingIntro(Pet petToChange)
        {
            Console.WriteLine("Hello! Welcome to Petz 4 Dayz Shelter!\n");
            Console.WriteLine("Thank you for volunteering with us today.\n");
            Console.WriteLine("Below is a list of animals currently sheltered.");
            foreach(Pet pet in petzForDayz.petList)
            {
                Console.WriteLine($"{pet.Name} ({pet.Species}) | Hunger: {pet.Hunger} | Boredom: {pet.Boredom} | Health: {pet.Health}");
            }
            //Console.Clear();
            //Console.WriteLine($"Your {species}'s name is {name}!\n");
            //Console.WriteLine($"Like any pet, {name} needs your love and attention.");
            //Console.WriteLine($"The passage of time (each time you return to the menu) will affect {name}'s stats.");
            //Console.WriteLine($"You will need to interact with and care for {name} to keep them happy and healthy.\n");
            //Console.WriteLine($"Press any key to begin your new friendship with your adopted {species}.");
            //Console.ReadKey();
        }
        public static  void AddNewPetIntro(Pet petToChange)
        {
            //Console.WriteLine("Hello! Welcome to Virtual Pets\n");
            Console.WriteLine("What species would you like your pet to be?"); 
            string species = Console.ReadLine();
            petToChange.SetSpecies(species);
            Console.WriteLine($"What would you like to name your {species}?");
            string name = Console.ReadLine();
            petToChange.SetName(name);
            Console.Clear();
            Console.WriteLine($"Your {species}'s name is {name}!\n");
            Console.WriteLine($"Like any pet, {name} needs your love and attention.");
            Console.WriteLine($"The passage of time (each time you return to the menu) will affect {name}'s stats.");
            Console.WriteLine($"You will need to interact with and care for {name} to keep them happy and healthy.\n");
            Console.WriteLine($"Press any key to begin your new friendship with your adopted {species}.");
            Console.ReadKey();
        }

        public static void continueKey()
        {
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }

    }
}
