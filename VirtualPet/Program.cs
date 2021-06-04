using System;
using System.Collections.Generic;

namespace VirtualPet
{   //Create mathod for showing current pets
    //fix bug for after new pet is added for referencing list
    class Program
    {
        public static Shelter petzForDayz = new Shelter();
       
        static void Main(string[] args)
        {
            //THE CREATION OF THE INITIAL PETS WAS MOVED INTO StartingIntro()
            //Pet Fluffy = new Pet("Fluffy","Alligator");
            //Pet Spot = new Pet("Spot", "Zebra");
            //Pet Brew = new Pet("Brew", "Hippogriff");
            //petzForDayz.AddPet(Fluffy);
            //petzForDayz.AddPet(Spot);
            //petzForDayz.AddPet(Brew);

            StartingIntro();

            MainMenu();
        }

        public static void continueKey()
        {
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
            Console.Clear();
        }
        // Second continueKey() method can be used to change generic message above to the string passed to it as parameter
        public static void continueKey(string uniqueText)
        {
            Console.WriteLine(uniqueText);
            Console.ReadKey();
            Console.Clear();
        }

        public static void StartingIntro()
        {
            Pet Fluffy = new Pet("Fluffy", "Alligator");
            Pet Spot = new Pet("Spot", "Zebra");
            Pet Brew = new Pet("Brew", "Hippogriff");
            petzForDayz.AddPet(Fluffy);
            petzForDayz.AddPet(Spot);
            petzForDayz.AddPet(Brew);

            Console.WriteLine("Hello! Welcome to Petz 4 Dayz Shelter!\n");
            Console.WriteLine("Thank you for volunteering with us today.\n");
            Console.WriteLine("Below is a list of the (future) pets currently sheltered.\n");
            petzForDayz.ListPets(true);
            continueKey("Press any key to begin your new friendships!");
        }

        public static void MainMenu()
        {
            bool continueGame = true;
            while (continueGame)
            {
                Console.Clear();
                petzForDayz.ListPets(true);
                Console.WriteLine("What would you like to do?\n");
                Console.WriteLine("1. Take in a new pet");
                Console.WriteLine("2. Adopt a pet to a good home");
                Console.WriteLine("3. Interact with an individual pet");
                Console.WriteLine("4. Interact with all pets");
                Console.WriteLine("5. Quit");
                string menuChoice = Console.ReadLine();
                switch (menuChoice)
                {
                    case "1":
                        NewPet();
                        break;
                    case "2":
                        AdoptPet();
                        break;
                    case "3":
                        IndividualInteraction();
                        break;
                    case "4":
                    // Need GroupInteraction() method
                    case "5":
                        Console.WriteLine("Thanks for playing!");
                        continueGame = false;
                        continueKey();
                        break;
                    default:
                        Console.WriteLine("Please choose from options 1-5.\n");
                        continueKey();
                        break;

                }
            }

        }

        public static void NewPet()
        {
            Console.Clear();
            Console.WriteLine("What species is this pet?"); 
            string species = Console.ReadLine();
            
            Console.WriteLine($"What is the name of this {species}?");
            string name = Console.ReadLine();

            Pet newPet = new Pet(name, species);
            petzForDayz.AddPet(newPet);

            Console.Clear();
            Console.WriteLine($"Your {species}'s name is {name}!\n");
            Console.WriteLine($"Like any pet, {name} needs your love and attention.");
            Console.WriteLine($"The passage of time (each time you return to the menu) will affect {name}'s stats.");
            Console.WriteLine($"You will need to interact with and care for {name} to keep them happy and healthy.\n");
            continueKey();
        }

        public static void AdoptPet()
        {
            Console.Clear();
            petzForDayz.ListPets(false);
            Pet chosenPet = petzForDayz.ChoosePet();
            petzForDayz.RemovePet(chosenPet);
            Console.Clear();
            Console.WriteLine($"{chosenPet.Name} has found a new home. Great work!\n");
            continueKey();
        }
        //public static void RemovePet(Pet chosenPet)
        //{
        //    petzForDayz.petList.Remove(chosenPet);
        //}

        //public static Pet ChoosePet()
        //{
        //    Console.Clear();
        //    Console.WriteLine("Please choose a pet (type the number):\n\n");
        //    foreach (Pet pet in petzForDayz.petList)
        //    {
        //        Console.WriteLine($"{pet.Id}. {pet.Name} ({pet.Species})\n");
        //    }
        //    int petNumber = Convert.ToInt32(Console.ReadLine());
        //    Pet chosenPet = petzForDayz.petList[petNumber - 1];
        //    return chosenPet;
        //}


        public static void IndividualInteraction()
        {
            Pet userPet = petzForDayz.ChoosePet();
            bool keepPlaying = true; 
            while (keepPlaying)
            {
                if (userPet.Health == 0)
                {
                    Console.Clear();
                    Console.WriteLine($"WOW... {userPet.Name}'s Health reached 0. The poor {userPet.Species} has been seized by the Animal Protective League!\n");
                    Console.WriteLine("Please DO NOT mistreat the pets!\n");
                    petzForDayz.RemovePet(userPet);
                    continueKey();
                    break;
                }
                Console.Clear();
                Console.WriteLine($"Hunger: {userPet.Hunger} | Boredom: {userPet.Boredom} | Health: {userPet.Health}\n");
                Console.WriteLine($"What would you like to do with {userPet.Name}?");
                Console.WriteLine($"1. Feed {userPet.Name}");
                Console.WriteLine($"2. Play with {userPet.Name}");
                Console.WriteLine($"3. Take {userPet.Name} to the vet :-(");
                Console.WriteLine("4. Exit");

                string userChoice = Console.ReadLine();
                switch (userChoice)
                {
                    case "1":
                        Console.Clear();
                        userPet.Feed();
                        continueKey();
                        Console.Clear();
                        Console.WriteLine($"Hunger: {userPet.Hunger} | Boredom: {userPet.Boredom} | Health: {userPet.Health}");
                        Console.WriteLine($"{userPet.Name}'s Hunger decreased to {userPet.Hunger}.\n");
                        continueKey();
                        break;
                    case "2":
                        Console.Clear();
                        userPet.Play();
                        continueKey();
                        Console.Clear();
                        Console.WriteLine($"Hunger: {userPet.Hunger} | Boredom: {userPet.Boredom} | Health: {userPet.Health}\n");
                        Console.WriteLine($"You played a game with {userPet.Name}. Hooray!");
                        Console.WriteLine($"{userPet.Name}'s Boredom decresed to {userPet.Boredom}, Hunger increased to {userPet.Hunger}, and Health increased to {userPet.Health}.\n");
                        continueKey();
                        break;
                    case "3":
                        Console.Clear();
                        userPet.SeeDoctor();
                        Console.WriteLine($"Hunger: {userPet.Hunger} | Boredom: {userPet.Boredom} | Health: {userPet.Health}\n");
                        Console.WriteLine($"You took {userPet.Name} for a checkup at the vet.");
                        Console.WriteLine($"{userPet.Name}'s Health increased to {userPet.Health}.\n");
                        continueKey();
                        break;
                    case "4":
                        Console.WriteLine($"Thanks for caring for {userPet.Name}. The {userPet.Species} has enjoyed your company!");
                        keepPlaying = false;
                        break;
                    default:
                        Console.WriteLine("You must choose from options 1-4.\n");
                        continueKey("Press any key to make another selection.");
                        break;

                }
                userPet.Tick();
            }
        }
       
    }
}
