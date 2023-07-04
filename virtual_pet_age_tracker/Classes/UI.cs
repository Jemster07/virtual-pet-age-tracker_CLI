using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace virtual_pet_age_tracker.Classes
{
    public class UI
    {
        public void CallUI()
        {
            string versionNum = "version 0.1.0";

            FileIO fileIO = new FileIO();
            fileIO.GeneratePetDictionary();

            bool endProgram = false;
            bool loopCurrentPets = false;
            bool loopAddPet = false;
            bool loopRemovePet = false;

            // Main Menu

            while (!endProgram)
            {
                Console.Clear();
                Console.WriteLine($"---{{ Pet Age Tracker {versionNum} }}---");
                Console.WriteLine();
                Console.WriteLine("--- Main Menu ---");
                Console.WriteLine();
                Console.WriteLine("[C]urrent Pets");
                Console.WriteLine("[A]dd Pet");
                Console.WriteLine("[R]emove Pet");
                Console.WriteLine("[E]xit");
                Console.WriteLine();
                Console.Write("Please make a selection: ");

                string userInput = Console.ReadLine();

                while (userInput == null)
                {
                    Console.Clear();
                    Console.WriteLine($"---{{ Pet Age Tracker {versionNum} }}---");
                    Console.WriteLine();
                    Console.WriteLine("[UNIT TYPE INVALID]");
                    Console.WriteLine();
                    Console.WriteLine("[C]urrent Pets");
                    Console.WriteLine("[A]dd Pet");
                    Console.WriteLine("[R]emove Pet");
                    Console.WriteLine("[E]xit");
                    Console.WriteLine();
                    Console.Write("Please make a selection: ");

                    userInput = Console.ReadLine();
                }

                string userInputLower = userInput.ToLower();

                while (!userInputLower.StartsWith("c")
                    && !userInputLower.StartsWith("a")
                    && !userInputLower.StartsWith("r")
                    && !userInputLower.StartsWith("e"))
                {
                    Console.Clear();
                    Console.WriteLine($"---{{ Pet Age Tracker {versionNum} }}---");
                    Console.WriteLine();
                    Console.WriteLine("[INVALID INPUT]");
                    Console.WriteLine();
                    Console.WriteLine("[C]urrent Pets");
                    Console.WriteLine("[A]dd Pet");
                    Console.WriteLine("[R]emove Pet");
                    Console.WriteLine("[E]xit");
                    Console.WriteLine();
                    Console.Write("Please make a selection: ");

                    userInput = Console.ReadLine();
                    userInputLower = userInput.ToLower();
                }

                if (userInputLower.StartsWith("c"))
                {
                    loopCurrentPets = true;
                }
                else if (userInputLower.StartsWith("a"))
                {
                    loopAddPet = true;
                }
                else if (userInputLower.StartsWith("r"))
                {
                    loopRemovePet = true;
                }
                else // Exit
                {
                    Console.Clear();
                    Console.WriteLine($"---{{ Pet Age Tracker {versionNum} }}---");
                    Console.WriteLine();
                    Console.WriteLine("Thank you for using my Pet Age Tracker!");
                    endProgram = true;
                }

                // Current Pets Menu

                while (loopCurrentPets)
                {
                    loopCurrentPets = false;

                    Console.Clear();
                    Console.WriteLine($"---{{ Pet Age Tracker {versionNum} }}---");
                    Console.WriteLine();
                    Console.WriteLine("--- Current Pets ---");
                    Console.WriteLine();

                    fileIO.PrintCurrentPets();

                    Console.Write("Press any key to return to the Main Menu.");
                    Console.ReadKey(true);
                }

                // Add Pet Menu

                while (loopAddPet)
                {
                    loopAddPet = false;

                    Console.Clear();
                    Console.WriteLine($"---{{ Pet Age Tracker {versionNum} }}---");
                    Console.WriteLine();
                    Console.WriteLine("--- Add Pet ---");
                    Console.WriteLine();

                    // Accommodate for Null
                    Console.Write("Enter the pet's name: ");
                    userInput = Console.ReadLine();
                    string name = userInput;
                    Console.WriteLine();

                    // Accommodate for Null
                    Console.Write("Enter the type of pet: ");
                    userInput = Console.ReadLine();
                    string petType = userInput;
                    Console.WriteLine();

                    // TODO: Ask if user wants to use current date/time for birthday
                    Console.WriteLine("Is today your pet's birthday? [Y/N]");
                    userInput = Console.ReadLine();

                    while (userInput == null)
                    {
                        Console.Clear();
                        Console.WriteLine($"---{{ Pet Age Tracker {versionNum} }}---");
                        Console.WriteLine();
                        Console.WriteLine("--- Add Pet ---");
                        Console.WriteLine();
                        Console.Write($"Enter the pet's name: {name}");
                        Console.WriteLine();
                        Console.Write($"Enter the type of pet: {petType}");
                        Console.WriteLine();
                        Console.WriteLine("Is today your pet's birthday? [Y/N]");
                        Console.Write("[UNIT TYPE INVALID] ");

                        userInput = Console.ReadLine();
                    }

                    userInputLower = userInput.ToLower();

                    while (!userInputLower.StartsWith("y") && !userInputLower.StartsWith("n"))
                    {
                        Console.Clear();
                        Console.WriteLine($"---{{ Pet Age Tracker {versionNum} }}---");
                        Console.WriteLine();
                        Console.WriteLine("--- Add Pet ---");
                        Console.WriteLine();
                        Console.Write($"Enter the pet's name: {name}");
                        Console.WriteLine();
                        Console.Write($"Enter the type of pet: {petType}");
                        Console.WriteLine();
                        Console.WriteLine("Is today your pet's birthday? [Y/N]");
                        Console.Write("[INVALID INPUT] ");

                        userInput = Console.ReadLine();
                        userInputLower = userInput.ToLower();
                    }

                    string dateBirth = null;
                    string timeBirth = null;

                    if (userInput.StartsWith("y"))
                    {
                        DateTime currentDate = DateTime.Now;
                        dateBirth = currentDate.Date.ToString();
                        timeBirth = currentDate.TimeOfDay.ToString();

                        Pet newPet = new Pet(name, petType, dateBirth, timeBirth);
                        fileIO.WritePet(newPet);
                    }
                    else
                    {
                        // Accommodate for Null AND non-Date formats
                        Console.Write("Enter the pet's birthday: ");
                        userInput = Console.ReadLine();
                        dateBirth = userInput;
                        Console.WriteLine();

                        // Accommodate for Null AND non-Time formats
                        Console.Write("Enter the pet's time of birth using AM/PM or 24-hour format: ");
                        userInput = Console.ReadLine();
                        timeBirth = userInput;
                        Console.WriteLine();

                        Pet newPet = new Pet(name, petType, dateBirth, timeBirth);
                        fileIO.WritePet(newPet);
                    }

                    // TODO: Write success message and Try/Catch to catch exception messages

                    Console.Write("Press any key to return to the Main Menu.");
                    Console.ReadKey(true);
                }

                // Remove Pet Menu

                while (loopRemovePet)
                {
                    // TODO: Instantiate DeletePet method

                    loopRemovePet = false;
                    Console.Write("Press any key to return to the Main Menu.");
                    Console.ReadKey(true);
                }
            }
        }
    }
}
