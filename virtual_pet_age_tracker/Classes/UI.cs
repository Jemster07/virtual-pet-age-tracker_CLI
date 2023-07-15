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

                        if (userInput == "~")
                        {
                            break;
                        }

                        while (userInput == null || userInput == "" || userInput.StartsWith(" "))
                        {
                            UIhelper.EnterPetNameUnitInvalid();
                            userInput = Console.ReadLine();
                        }

                        string name = userInput;

                        UIhelper.EnterPetType();
                        userInput = Console.ReadLine();

                        if (userInput == "~")
                        {
                            break;
                        }

                        while (userInput == null || userInput == "" || userInput.StartsWith(" "))
                        {
                            UIhelper.EnterPetTypeUnitInvalid();
                            userInput = Console.ReadLine();
                        }

                        string petType = userInput;

                        UIhelper.PetBirthdayToday();
                        string userInput_YN = Console.ReadLine();

                        if (userInput_YN == "~")
                        {
                            break;
                        }

                        while (userInput_YN == null || userInput == "" || userInput.StartsWith(" "))
                        {
                            UIhelper.PetBirthdayTodayUnitInvalid();
                            userInput_YN = Console.ReadLine();
                        }

                        userInputLower = userInput_YN.ToLower();

                        while (!userInputLower.StartsWith("y") && !userInputLower.StartsWith("n"))
                        {
                            UIhelper.PetBirthdayTodayInputInvalid();
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
                            UIhelper.EnterPetBirthday();
                            userInput = Console.ReadLine();

                            if (userInput == "~")
                            {
                                break;
                            }

                            while (userInput == null || userInput == "" || userInput.StartsWith(" "))
                            {
                                UIhelper.EnterPetBirthdayUnitInvalid();
                                userInput = Console.ReadLine();
                            }

                            while (!DateOnly.TryParse(userInput, out DateOnly tryResult))
                            {
                                UIhelper.EnterPetBirthdayFormatInvalid();
                                userInput = Console.ReadLine();
                            }

                            dateBirth = userInput;

                            UIhelper.EnterPetBirthTime();
                            userInput = Console.ReadLine();

                            if (userInput == "~")
                            {
                                break;
                            }

                            while (userInput == null || userInput == "" || userInput.StartsWith(" "))
                            {
                                UIhelper.EnterPetBirthTimeUnitInvalid();
                                userInput = Console.ReadLine();
                            }

                            while (!TimeOnly.TryParse(userInput, out TimeOnly tryResult))
                            {
                                UIhelper.EnterPetBirthTimeFormatInvalid();
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
