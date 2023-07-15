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

            InventoryHandler inventoryHandler = new InventoryHandler();

            try
            {
                inventoryHandler.GeneratePetDictionary();
            }
            catch (Exception generateDictionaryError)
            {
                Console.WriteLine($"---{{ Pet Age Tracker {versionNum} }}---");
                Console.WriteLine();
                Console.WriteLine(generateDictionaryError.Message);
                endProgram = true;
            }

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

                while (userInput == null || userInput == "")
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

                    inventoryHandler.PrintCurrentPets();

                    Console.Write("Press any key to return to the Main Menu.");
                    Console.ReadKey(true);
                }

                // Add Pet Menu

                while (loopAddPet)
                {
                    loopAddPet = false;

                    try
                    {
                        Console.Clear();
                        Console.WriteLine($"---{{ Pet Age Tracker {versionNum} }}---");
                        Console.WriteLine();
                        Console.WriteLine("--- Add Pet or [~] to Cancel ---");
                        Console.WriteLine();
                        Console.Write("Enter the pet's name: ");

                        userInput = Console.ReadLine();

                        if (userInput == "~")
                        {
                            Console.WriteLine();
                            Console.Write("Press any key to return to the Main Menu.");
                            Console.ReadKey(true);

                            break;
                        }

                        while (userInput == null || userInput == "" || userInput.StartsWith(" "))
                        {
                            Console.Clear();
                            Console.WriteLine($"---{{ Pet Age Tracker {versionNum} }}---");
                            Console.WriteLine();
                            Console.WriteLine("[UNIT TYPE INVALID]");
                            Console.WriteLine();
                            Console.Write($"Enter the pet's name: ");

                            userInput = Console.ReadLine();
                        }

                        string name = userInput;

                        Console.Clear();
                        Console.WriteLine($"---{{ Pet Age Tracker {versionNum} }}---");
                        Console.WriteLine();
                        Console.WriteLine("--- Add Pet or [~] to Cancel ---");
                        Console.WriteLine();
                        Console.Write("Enter the type of pet: ");

                        userInput = Console.ReadLine();

                        if (userInput == "~")
                        {
                            Console.WriteLine();
                            Console.Write("Press any key to return to the Main Menu.");
                            Console.ReadKey(true);

                            break;
                        }

                        while (userInput == null || userInput == "" || userInput.StartsWith(" "))
                        {
                            Console.Clear();
                            Console.WriteLine($"---{{ Pet Age Tracker {versionNum} }}---");
                            Console.WriteLine();
                            Console.WriteLine("[UNIT TYPE INVALID]");
                            Console.WriteLine();
                            Console.Write($"Enter the type of pet: ");

                            userInput = Console.ReadLine();
                        }

                        string petType = userInput;

                        Console.Clear();
                        Console.WriteLine($"---{{ Pet Age Tracker {versionNum} }}---");
                        Console.WriteLine();
                        Console.WriteLine("--- Add Pet or [~] to Cancel ---");
                        Console.WriteLine();
                        Console.Write("Is today your pet's birthday? [Y/N]: ");

                        string userInput_YN = Console.ReadLine();

                        if (userInput_YN == "~")
                        {
                            Console.WriteLine();
                            Console.Write("Press any key to return to the Main Menu.");
                            Console.ReadKey(true);

                            break;
                        }

                        while (userInput_YN == null || userInput == "" || userInput.StartsWith(" "))
                        {
                            Console.Clear();
                            Console.WriteLine($"---{{ Pet Age Tracker {versionNum} }}---");
                            Console.WriteLine();
                            Console.WriteLine("[UNIT TYPE INVALID]");
                            Console.WriteLine();
                            Console.Write("Is today your pet's birthday? [Y/N]: ");

                            userInput_YN = Console.ReadLine();
                        }

                        userInputLower = userInput_YN.ToLower();

                        while (!userInputLower.StartsWith("y") && !userInputLower.StartsWith("n"))
                        {
                            Console.Clear();
                            Console.WriteLine($"---{{ Pet Age Tracker {versionNum} }}---");
                            Console.WriteLine();
                            Console.WriteLine("[INVALID INPUT]");
                            Console.WriteLine();
                            Console.Write("Is today your pet's birthday? [Y/N]: ");

                            userInput_YN = Console.ReadLine();
                            userInputLower = userInput_YN.ToLower();
                        }

                        string dateBirth = null;
                        string timeBirth = null;

                        if (userInputLower.StartsWith("y"))
                        {
                            DateOnly currentDate = DateOnly.FromDateTime(DateTime.Now);
                            TimeOnly currentTime = TimeOnly.FromDateTime(DateTime.Now);

                            dateBirth = currentDate.ToString();
                            timeBirth = currentTime.ToString();

                            Pet newPet = new Pet(name, petType, dateBirth, timeBirth);
                            inventoryHandler.AddToDictionary(newPet);

                            // TODO: Need to check for bool that confirms pet was added successfully

                            Console.WriteLine();
                            Console.WriteLine("Pet successfully added!");
                            Console.WriteLine();
                            Console.WriteLine($"Name: {newPet.Name}");
                            Console.WriteLine($"Pet Type: {newPet.PetType}");
                            Console.WriteLine($"Birthday: {newPet.Birthday}");
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine($"---{{ Pet Age Tracker {versionNum} }}---");
                            Console.WriteLine();
                            Console.WriteLine("--- Add Pet or [~] to Cancel ---");
                            Console.WriteLine();
                            Console.Write("Enter the pet's birthday: ");

                            userInput = Console.ReadLine();

                            if (userInput == "~")
                            {
                                Console.WriteLine();
                                Console.Write("Press any key to return to the Main Menu.");
                                Console.ReadKey(true);

                                break;
                            }

                            while (userInput == null || userInput == "" || userInput.StartsWith(" "))
                            {
                                Console.Clear();
                                Console.WriteLine($"---{{ Pet Age Tracker {versionNum} }}---");
                                Console.WriteLine();
                                Console.WriteLine("[UNIT TYPE INVALID]");
                                Console.WriteLine();
                                Console.Write("Enter the pet's birthday: ");

                                userInput = Console.ReadLine();
                            }

                            while (!DateOnly.TryParse(userInput, out DateOnly tryResult))
                            {
                                Console.Clear();
                                Console.WriteLine($"---{{ Pet Age Tracker {versionNum} }}---");
                                Console.WriteLine();
                                Console.WriteLine("[INVALID FORMAT]");
                                Console.WriteLine();
                                Console.Write("Enter the pet's birthday: ");

                                userInput = Console.ReadLine();
                            }

                            dateBirth = userInput;

                            Console.Clear();
                            Console.WriteLine($"---{{ Pet Age Tracker {versionNum} }}---");
                            Console.WriteLine();
                            Console.WriteLine("--- Add Pet or [~] to Cancel ---");
                            Console.WriteLine();
                            Console.Write("Enter the pet's time of birth using AM/PM or 24-hour format: ");

                            userInput = Console.ReadLine();

                            if (userInput == "~")
                            {
                                Console.WriteLine();
                                Console.Write("Press any key to return to the Main Menu.");
                                Console.ReadKey(true);

                                break;
                            }

                            while (userInput == null || userInput == "" || userInput.StartsWith(" "))
                            {
                                Console.Clear();
                                Console.WriteLine($"---{{ Pet Age Tracker {versionNum} }}---");
                                Console.WriteLine();
                                Console.WriteLine("[UNIT TYPE INVALID]");
                                Console.WriteLine();
                                Console.Write("Enter the pet's time of birth using AM/PM or 24-hour format: ");

                                userInput = Console.ReadLine();
                            }

                            while (!TimeOnly.TryParse(userInput, out TimeOnly tryResult))
                            {
                                Console.Clear();
                                Console.WriteLine($"---{{ Pet Age Tracker {versionNum} }}---");
                                Console.WriteLine();
                                Console.WriteLine("[INVALID FORMAT]");
                                Console.WriteLine();
                                Console.Write("Enter the pet's time of birth using AM/PM or 24-hour format: ");

                                userInput = Console.ReadLine();
                            }

                            timeBirth = userInput;

                            Pet newPet = new Pet(name, petType, dateBirth, timeBirth);
                            inventoryHandler.AddToDictionary(newPet);

                            // TODO: Need to check for bool that confirms pet was added successfully

                            Console.WriteLine();
                            Console.WriteLine("Pet successfully added!");
                            Console.WriteLine();
                            Console.WriteLine($"Name: {newPet.Name}");
                            Console.WriteLine($"Pet Type: {newPet.PetType}");
                            Console.WriteLine($"Birthday: {newPet.Birthday}");
                        }
                    }
                    catch (Exception addPetError)
                    {
                        Console.Clear();
                        Console.WriteLine($"---{{ Pet Age Tracker {versionNum} }}---");
                        Console.WriteLine();
                        Console.WriteLine(addPetError.Message);
                    }
                    finally
                    {
                        Console.WriteLine();
                        Console.Write("Press any key to return to the Main Menu.");
                        Console.ReadKey(true);
                    }
                }

                // Remove Pet Menu
                // TODO: Instantiate DeletePet method

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
