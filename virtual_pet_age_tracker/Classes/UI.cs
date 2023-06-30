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

            bool endProgram = false;
            bool loopCurrentPets = false;
            bool loopAddPet = false;
            bool loopRemovePet = false;

            // Main Menu

            while (!endProgram)
            {
                // TODO: Add check for Current Pets, if none, don't display the Current Pets menu
                // Use the [FileIO.PetsInDirectory.Length != 0] method as a bool to check for current pets
                
                Console.Clear();
                Console.WriteLine($"---{{ Virtual Pet Age Tracker {versionNum} }}---");
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
                    Console.WriteLine($"---{{ Virtual Pet Age Tracker {versionNum} }}---");
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
                    Console.WriteLine($"---{{ Virtual Pet Age Tracker {versionNum} }}---");
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
                    Console.WriteLine($"---{{ Virtual Pet Age Tracker {versionNum} }}---");
                    Console.WriteLine();
                    Console.WriteLine("Thank you for using my Virtual Pet Age Tracker!");
                    Console.WriteLine();
                    endProgram = true;
                }

                // Current Pets Menu

                while (loopCurrentPets)
                {
                    loopCurrentPets = false;
                    Console.Write("Press any key to return to the Main Menu.");
                    Console.ReadKey(true);
                }

                // Add Pet Menu

                while (loopAddPet)
                {
                    loopAddPet = false;
                    Console.Write("Press any key to return to the Main Menu.");
                    Console.ReadKey(true);
                }

                // Remove Pet Menu

                while (loopRemovePet)
                {
                    loopRemovePet = false;
                    Console.Write("Press any key to return to the Main Menu.");
                    Console.ReadKey(true);
                }
            }
        }
    }
}
