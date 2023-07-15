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
            UIHelper UIhelper = new UIHelper();

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
                UIhelper.Header();
                Console.WriteLine(generateDictionaryError.Message);
                endProgram = true;
            }

            // Main Menu

            while (!endProgram)
            {
                UIhelper.Header();
                Console.WriteLine("--- Main Menu ---");
                UIhelper.MainMenu();

                string userInput = Console.ReadLine();

                while (userInput == null || userInput == "")
                {
                    UIhelper.Header();
                    Console.WriteLine("[UNIT TYPE INVALID]");
                    UIhelper.MainMenu();

                    userInput = Console.ReadLine();
                }

                string userInputLower = userInput.ToLower();

                while (!userInputLower.StartsWith("c")
                    && !userInputLower.StartsWith("a")
                    && !userInputLower.StartsWith("r")
                    && !userInputLower.StartsWith("e"))
                {
                    UIhelper.Header();
                    Console.WriteLine("[INVALID INPUT]");
                    UIhelper.MainMenu();

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
                    UIhelper.Header();
                    Console.WriteLine("Thank you for using my Pet Age Tracker!");
                    endProgram = true;
                }

                // Current Pets Menu

                while (loopCurrentPets)
                {
                    loopCurrentPets = false;

                    UIhelper.Header();
                    Console.WriteLine("--- Current Pets ---");

                    inventoryHandler.PrintCurrentPets();

                    UIhelper.ReturnToMainMenu();
                }

                // Add Pet Menu

                while (loopAddPet)
                {
                    loopAddPet = false;

                    try
                    {
                        UIhelper.Header();
                        UIhelper.CancelHeader();
                        Console.Write("Enter the pet's name: ");

                        userInput = Console.ReadLine();

                        if (userInput == "~")
                        {
                            break;
                        }

                        while (userInput == null || userInput == "" || userInput.StartsWith(" "))
                        {
                            UIhelper.Header();
                            Console.WriteLine("[UNIT TYPE INVALID]");
                            Console.WriteLine();
                            Console.Write($"Enter the pet's name: ");

                            userInput = Console.ReadLine();
                        }

                        string name = userInput;

                        UIhelper.Header();
                        UIhelper.CancelHeader();
                        Console.Write("Enter the type of pet: ");

                        userInput = Console.ReadLine();

                        if (userInput == "~")
                        {
                            break;
                        }

                        while (userInput == null || userInput == "" || userInput.StartsWith(" "))
                        {
                            UIhelper.Header();
                            Console.WriteLine("[UNIT TYPE INVALID]");
                            Console.WriteLine();
                            Console.Write($"Enter the type of pet: ");

                            userInput = Console.ReadLine();
                        }

                        string petType = userInput;

                        UIhelper.Header();
                        UIhelper.CancelHeader();
                        Console.Write("Is today your pet's birthday? [Y/N]: ");

                        string userInput_YN = Console.ReadLine();

                        if (userInput_YN == "~")
                        {
                            break;
                        }

                        while (userInput_YN == null || userInput == "" || userInput.StartsWith(" "))
                        {
                            UIhelper.Header();
                            Console.WriteLine("[UNIT TYPE INVALID]");
                            Console.WriteLine();
                            Console.Write("Is today your pet's birthday? [Y/N]: ");

                            userInput_YN = Console.ReadLine();
                        }

                        userInputLower = userInput_YN.ToLower();

                        while (!userInputLower.StartsWith("y") && !userInputLower.StartsWith("n"))
                        {
                            UIhelper.Header();
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

                            UIhelper.PetAddSuccess(newPet);
                        }
                        else
                        {
                            UIhelper.Header();
                            UIhelper.CancelHeader();
                            Console.Write("Enter the pet's birthday: ");

                            userInput = Console.ReadLine();

                            if (userInput == "~")
                            {
                                break;
                            }

                            while (userInput == null || userInput == "" || userInput.StartsWith(" "))
                            {
                                UIhelper.Header();
                                Console.WriteLine("[UNIT TYPE INVALID]");
                                Console.WriteLine();
                                Console.Write("Enter the pet's birthday: ");

                                userInput = Console.ReadLine();
                            }

                            while (!DateOnly.TryParse(userInput, out DateOnly tryResult))
                            {
                                UIhelper.Header();
                                Console.WriteLine("[INVALID FORMAT]");
                                Console.WriteLine();
                                Console.Write("Enter the pet's birthday: ");

                                userInput = Console.ReadLine();
                            }

                            dateBirth = userInput;

                            UIhelper.Header();
                            UIhelper.CancelHeader();
                            Console.Write("Enter the pet's time of birth using AM/PM or 24-hour format: ");

                            userInput = Console.ReadLine();

                            if (userInput == "~")
                            {
                                break;
                            }

                            while (userInput == null || userInput == "" || userInput.StartsWith(" "))
                            {
                                UIhelper.Header();
                                Console.WriteLine("[UNIT TYPE INVALID]");
                                Console.WriteLine();
                                Console.Write("Enter the pet's time of birth using AM/PM or 24-hour format: ");

                                userInput = Console.ReadLine();
                            }

                            while (!TimeOnly.TryParse(userInput, out TimeOnly tryResult))
                            {
                                UIhelper.Header();
                                Console.WriteLine("[INVALID FORMAT]");
                                Console.WriteLine();
                                Console.Write("Enter the pet's time of birth using AM/PM or 24-hour format: ");

                                userInput = Console.ReadLine();
                            }

                            timeBirth = userInput;

                            Pet newPet = new Pet(name, petType, dateBirth, timeBirth);
                            inventoryHandler.AddToDictionary(newPet);

                            UIhelper.PetAddSuccess(newPet);
                        }
                    }
                    catch (Exception addPetError)
                    {
                        UIhelper.Header();
                        Console.WriteLine(addPetError.Message);
                    }
                    finally
                    {
                        UIhelper.ReturnToMainMenu();
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
