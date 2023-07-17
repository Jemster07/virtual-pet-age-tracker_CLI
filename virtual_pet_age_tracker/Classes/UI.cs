using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace virtual_pet_age_tracker.Classes
{
    public class UI
    {
        public void CallUI()
        {
            UIHelper UIhelper = new UIHelper();
            InventoryHandler inventoryHandler = new InventoryHandler();

            bool endProgram = false;
            bool loopCurrentPets = false;
            bool loopAddPet = false;
            bool loopRemovePet = false;

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
                UIhelper.MainMenu();
                string userInput = Console.ReadLine();

                while (userInput == null || userInput == "")
                {
                    UIhelper.MainMenuUnitInvalid();
                    userInput = Console.ReadLine();
                }

                string userInputLower = userInput.ToLower();

                while (!userInputLower.StartsWith("c")
                    && !userInputLower.StartsWith("a")
                    && !userInputLower.StartsWith("r")
                    && !userInputLower.StartsWith("e"))
                {
                    UIhelper.MainMenuInputInvalid();
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
                    // TODO: Figure out a way to count how many lines are printed to screen
                    // when the print current pets menu is triggered

                    loopCurrentPets = false;

                    UIhelper.CurrentPetsMenu();
                    inventoryHandler.PrintCurrentPets();
                    UIhelper.ReturnToMainMenu();
                }

                // Add Pet Menu

                while (loopAddPet)
                {
                    loopAddPet = false;

                    try
                    {
                        UIhelper.EnterPetName();
                        userInput = Console.ReadLine();

                        while (userInput == null || userInput == "" || userInput.StartsWith(" "))
                        {
                            UIhelper.EnterPetNameUnitInvalid();
                            userInput = Console.ReadLine();
                        }

                        if (userInput == "~")
                        {
                            break;
                        }

                        string name = userInput;

                        UIhelper.EnterPetType();
                        userInput = Console.ReadLine();

                        while (userInput == null || userInput == "" || userInput.StartsWith(" "))
                        {
                            UIhelper.EnterPetTypeUnitInvalid();
                            userInput = Console.ReadLine();
                        }

                        if (userInput == "~")
                        {
                            break;
                        }

                        string petType = userInput;

                        UIhelper.PetBirthdayToday();
                        userInput = Console.ReadLine();

                        while (userInput == null || userInput == "" || userInput.StartsWith(" "))
                        {
                            UIhelper.PetBirthdayTodayUnitInvalid();
                            userInput = Console.ReadLine();
                        }

                        if (userInput == "~")
                        {
                            break;
                        }

                        userInputLower = userInput.ToLower();

                        while (!userInputLower.StartsWith("y") && !userInputLower.StartsWith("n"))
                        {
                            UIhelper.PetBirthdayTodayInputInvalid();
                            userInput = Console.ReadLine();

                            if (userInput == "~")
                            {
                                break;
                            }

                            userInputLower = userInput.ToLower();
                        }

                        if (userInput == "~")
                        {
                            break;
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
                            UIhelper.EnterPetBirthday();
                            userInput = Console.ReadLine();

                            while (userInput == null || userInput == "" || userInput.StartsWith(" "))
                            {
                                UIhelper.EnterPetBirthdayUnitInvalid();
                                userInput = Console.ReadLine();
                            }

                            if (userInput == "~")
                            {
                                break;
                            }

                            while (!DateOnly.TryParse(userInput, out DateOnly tryResult))
                            {
                                UIhelper.EnterPetBirthdayFormatInvalid();
                                userInput = Console.ReadLine();

                                if (userInput == "~")
                                {
                                    break;
                                }
                            }

                            if (userInput == "~")
                            {
                                break;
                            }

                            dateBirth = userInput;

                            UIhelper.EnterPetBirthTime();
                            userInput = Console.ReadLine();

                            while (userInput == null || userInput == "" || userInput.StartsWith(" "))
                            {
                                UIhelper.EnterPetBirthTimeUnitInvalid();
                                userInput = Console.ReadLine();
                            }

                            if (userInput == "~")
                            {
                                break;
                            }

                            while (!TimeOnly.TryParse(userInput, out TimeOnly tryResult))
                            {
                                UIhelper.EnterPetBirthTimeFormatInvalid();
                                userInput = Console.ReadLine();

                                if (userInput == "~")
                                {
                                    break;
                                }
                            }

                            if (userInput == "~")
                            {
                                break;
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

                while (loopRemovePet)
                {
                    // TODO: Implement UIHelper methods to clean up Console.WriteLine code

                    loopRemovePet = false;
                    bool showUI = true;

                    string versionNum = "version 0.1.0";

                    try
                    {
                        Console.Clear();
                        Console.WriteLine($"---{{ Pet Age Tracker {versionNum} }}---");
                        Console.WriteLine();
                        Console.WriteLine("--- Delete Pet or [~] to Cancel ---");
                        Console.WriteLine();
                        Console.Write("What is the name of the pet that you want to delete? ");

                        userInput = Console.ReadLine();

                        while (userInput == null || userInput == "" || userInput.StartsWith(" "))
                        {
                            Console.Clear();
                            Console.WriteLine($"---{{ Pet Age Tracker {versionNum} }}---");
                            Console.WriteLine();
                            Console.WriteLine("[UNIT TYPE INVALID]");
                            Console.WriteLine();
                            Console.Write("What is the name of the pet that you want to delete? ");

                            userInput = Console.ReadLine();
                        }

                        if (userInput == "~")
                        {
                            break;
                        }

                        string petName = userInput;

                        Console.Clear();
                        Console.WriteLine($"---{{ Pet Age Tracker {versionNum} }}---");
                        Console.WriteLine();
                        Console.WriteLine("--- Delete Pet or [~] to Cancel ---");
                        Console.WriteLine();
                        Console.WriteLine("WARNING: Deleting a pet is PERMANENT and cannot be undone!");
                        Console.WriteLine();
                        Console.WriteLine($"Are you sure you want to delete {petName}?");
                        Console.WriteLine();
                        Console.Write("Choose wisely [Y/N]: ");

                        userInput = Console.ReadLine();

                        while (userInput == null || userInput == "" || userInput.StartsWith(" "))
                        {
                            Console.Clear();
                            Console.WriteLine($"---{{ Pet Age Tracker {versionNum} }}---");
                            Console.WriteLine();
                            Console.WriteLine("[UNIT TYPE INVALID]");
                            Console.WriteLine();
                            Console.WriteLine("WARNING: Deleting a pet is PERMANENT and cannot be undone!");
                            Console.WriteLine();
                            Console.WriteLine($"Are you sure you want to delete {petName}?");
                            Console.WriteLine();
                            Console.Write("Choose wisely [Y/N]: ");

                            userInput = Console.ReadLine();
                        }

                        if (userInput == "~")
                        {
                            break;
                        }

                        userInputLower = userInput.ToLower();

                        while (!userInputLower.StartsWith("y") && !userInputLower.StartsWith("n"))
                        {
                            Console.Clear();
                            Console.WriteLine($"---{{ Pet Age Tracker {versionNum} }}---");
                            Console.WriteLine();
                            Console.WriteLine("[INVALID INPUT]");
                            Console.WriteLine();
                            Console.WriteLine("WARNING: Deleting a pet is PERMANENT and cannot be undone!");
                            Console.WriteLine();
                            Console.WriteLine($"Are you sure you want to delete {petName}?");
                            Console.WriteLine();
                            Console.Write("Choose wisely [Y/N]: ");

                            userInput = Console.ReadLine();

                            if (userInput == "~")
                            {
                                break;
                            }

                            userInputLower = userInput.ToLower();
                        }

                        if (userInput == "~")
                        {
                            break;
                        }

                        if (userInputLower.StartsWith("n"))
                        {
                            break;
                        }
                        else
                        {
                            inventoryHandler.DeleteFromDictionary(petName);

                            Console.Clear();
                            Console.WriteLine($"---{{ Pet Age Tracker {versionNum} }}---");
                            Console.WriteLine();
                            Console.WriteLine("--- Delete Pet or [~] to Cancel ---");
                            Console.WriteLine();
                            Console.WriteLine("Pet successfully deleted!");
                            Console.WriteLine();
                            Console.Write("Would you like to delete another pet? [Y/N]: ");

                            userInput = Console.ReadLine();

                            while (userInput == null || userInput == "" || userInput.StartsWith(" "))
                            {
                                Console.Clear();
                                Console.WriteLine($"---{{ Pet Age Tracker {versionNum} }}---");
                                Console.WriteLine();
                                Console.WriteLine("--- Delete Pet or [~] to Cancel ---");
                                Console.WriteLine();
                                Console.WriteLine("[UNIT TYPE INVALID]");
                                Console.WriteLine();
                                Console.Write("Would you like to delete another pet? [Y/N]: ");

                                userInput = Console.ReadLine();
                            }

                            if (userInput == "~")
                            {
                                break;
                            }

                            userInputLower = userInput.ToLower();

                            while (!userInputLower.StartsWith("y") && !userInputLower.StartsWith("n"))
                            {
                                Console.Clear();
                                Console.WriteLine($"---{{ Pet Age Tracker {versionNum} }}---");
                                Console.WriteLine();
                                Console.WriteLine("--- Delete Pet or [~] to Cancel ---");
                                Console.WriteLine();
                                Console.WriteLine("[INVALID INPUT]");
                                Console.WriteLine();
                                Console.Write("Would you like to delete another pet? [Y/N]: ");

                                userInput = Console.ReadLine();

                                if (userInput == "~")
                                {
                                    break;
                                }

                                userInputLower = userInput.ToLower();
                            }

                            if (userInput == "~")
                            {
                                break;
                            }

                            if (userInputLower.StartsWith("y"))
                            {
                                loopRemovePet = true;
                                showUI = false;
                            }
                        }
                    }
                    catch (Exception deletePetError)
                    {
                        UIhelper.Header();
                        Console.WriteLine(deletePetError.Message);
                    }
                    finally
                    {
                        if (showUI)
                        {
                            UIhelper.ReturnToMainMenu();
                        }
                    }
                }
            }
        }
    }
}