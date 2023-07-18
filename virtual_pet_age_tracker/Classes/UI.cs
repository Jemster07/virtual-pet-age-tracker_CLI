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
                    loopRemovePet = false;
                    bool showUI = true;

                    try
                    {
                        UIhelper.PetToDelete();
                        userInput = Console.ReadLine();

                        while (userInput == null || userInput == "" || userInput.StartsWith(" "))
                        {
                            UIhelper.PetToDeleteUnitInvalid();
                            userInput = Console.ReadLine();
                        }

                        if (userInput == "~")
                        {
                            break;
                        }

                        string petName = userInput;

                        UIhelper.DeleteConfirm(petName);
                        userInput = Console.ReadLine();

                        while (userInput == null || userInput == "" || userInput.StartsWith(" "))
                        {
                            UIhelper.DeleteConfirmUnitInvalid(petName);
                            userInput = Console.ReadLine();
                        }

                        if (userInput == "~")
                        {
                            break;
                        }

                        userInputLower = userInput.ToLower();

                        while (!userInputLower.StartsWith("y") && !userInputLower.StartsWith("n"))
                        {
                            UIhelper.DeleteConfirmInputInvalid(petName);
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

                            UIhelper.PetDeleteSuccess();
                            userInput = Console.ReadLine();

                            while (userInput == null || userInput == "" || userInput.StartsWith(" "))
                            {
                                UIhelper.PetDeleteSuccessUnitInvalid();
                                userInput = Console.ReadLine();
                            }

                            if (userInput == "~")
                            {
                                break;
                            }

                            userInputLower = userInput.ToLower();

                            while (!userInputLower.StartsWith("y") && !userInputLower.StartsWith("n"))
                            {
                                UIhelper.PetDeleteSuccessInputInvalid();
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