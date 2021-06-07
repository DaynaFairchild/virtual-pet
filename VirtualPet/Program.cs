using System;
using System.Collections.Generic;

namespace VirtualPet
{   //adopt pet bug
    class Program
    {
        public static Shelter petzForDayz = new Shelter();
       
        static void Main(string[] args)
        {

            StartingIntro();

            MainMenu();
        }

        public static void continueKey()
        {
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
            Console.Clear();
        }
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
                Console.WriteLine("4. Choose up to three pets to interact with");
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
                        GroupInteraction();
                        break;
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
            Console.WriteLine("Is the pet 1. organic or 2. robotic?");
            string petType = Console.ReadLine();
            if (petType == "1")
            {
                NewOrganicPet();
            }
            else if (petType == "2")
            {
                NewRoboticPet();
            }
        }

        public static void NewOrganicPet()
        {
            Console.Clear();
            Console.WriteLine("What species is this pet?"); 
            string species = Console.ReadLine();
            
            Console.WriteLine($"What is the name of this {species}?");
            string name = Console.ReadLine();

            Organic newPet = new Organic(name, species);
            petzForDayz.AddPet(newPet);

            Console.Clear();
            Console.WriteLine($"Your {species}'s name is {name}!\n");
            Console.WriteLine($"Like any pet, {name} needs your love and attention.");
            Console.WriteLine($"The passage of time (each time you return to the menu) will affect {name}'s stats.");
            Console.WriteLine($"You will need to interact with and care for {name} to keep them happy and healthy.\n");
            continueKey();
        }

        public static void NewRoboticPet()
        {
            Console.Clear();
            Console.WriteLine("What robotic species is this pet?");
            string species = Console.ReadLine();

            Console.WriteLine($"What is the name of this {species}?");
            string name = Console.ReadLine();

            Robot newPet = new Robot(name, species);
            petzForDayz.AddPet(newPet);

            Console.Clear();
            Console.WriteLine($"Your robotic {species}'s name is {name}!\n");
            Console.WriteLine($"Even a robotic pet, like {name}, needs your love and attention.");
            Console.WriteLine($"The passage of time (each time you return to the menu) will affect {name}'s stats.");
            Console.WriteLine($"You will need to interact with and care for {name} to keep them happy and operational.\n");
            continueKey();
        }


        public static void AdoptPet()
        {
            Console.Clear();
            petzForDayz.ListPets(false);
            Pet chosenPet = petzForDayz.ChoosePet();
            petzForDayz.RemovePet(chosenPet);
            Console.Clear();
            continueKey($"{chosenPet.Name} has found a new home. Great work!\nPress any key to continue: ");
            //Fix the bug for when the user input is null
            // also maybe a fix for choices beyond the number in the list
        }

        public static void ZeroHealth(Pet tocheck)
        {
                Console.Clear();
                Console.WriteLine($"WOW... {tocheck.Name}'s Health reached 0. The poor {tocheck.Species} has been seized by the Animal Protective League!\n");
                Console.WriteLine("Please DO NOT mistreat the pets!\n");
                petzForDayz.RemovePet(tocheck);
                continueKey();
        }

        public static void GroupInteraction()
        {
            List<Pet> GroupList = new List<Pet>();
            for (int i =0; i < ((petzForDayz.petList.Count < 3) ? petzForDayz.petList.Count : 3); i++)
            {
                Pet userPet = petzForDayz.ChoosePet();
                GroupList.Add(userPet);
            }

            bool keepPlaying = true;
            while (keepPlaying)
            {
                int deadCount = 0;
                List<Pet> deadPets = new List<Pet>(); 
                foreach(var pet in GroupList)
                {
                    if(pet.Health == 0)
                    {
                        ZeroHealth(pet);
                        deadPets.Add(pet);
                        deadCount++;
                    }
                    
                }
                foreach(var dead in deadPets)
                {
                    GroupList.Remove(dead);
                }


                if (deadCount == GroupList.Count)
                {
                    break;
                }
                
                Console.Clear();
                bool withStats = true;
                int i = 1;
                foreach (Pet pet in GroupList)
                {
                    Console.WriteLine($"{i}. {pet.Name} ({pet.Species})");
                    if (withStats)
                        Console.WriteLine($"--  Hunger: {pet.Hunger} | Boredom: {pet.Boredom} | Health: {pet.Health}\n");
                    i++;
                }
                Console.WriteLine();
                Console.WriteLine($"What would you like to do with the pets?");
                Console.WriteLine($"1. Feeding time");
                Console.WriteLine($"2. Play time");
                Console.WriteLine($"3. Group vet visit");
                Console.WriteLine("4. Exit");

                string userChoice = Console.ReadLine();
                switch (userChoice)
                {
                    case "1":
                        Console.Clear();
                        foreach(var pet in GroupList)
                        {
                            pet.Feed();
                        }
                        continueKey();
                        break;
                    case "2":
                        Console.Clear();
                        foreach (var pet in GroupList)
                        {
                            pet.Play();
                        }
                        continueKey();
                        break;
                    case "3":
                        Console.Clear();
                        foreach (var pet in GroupList)
                        {
                            pet.SeeDoctor();
                        }
                        continueKey();
                        break;
                    case "4":
                        Console.WriteLine($"Thanks for caring for the pets! They has enjoyed your company!");
                        keepPlaying = false;
                        break;
                    default:
                        Console.WriteLine("You must choose from options 1-4.\n");
                        continueKey("Press any key to make another selection.");
                        break;

                }
                foreach(var pet in GroupList)
                {
                    pet.Tick();
                }
            }
        }
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
