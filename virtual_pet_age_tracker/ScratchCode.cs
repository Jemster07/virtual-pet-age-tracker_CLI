using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using virtual_pet_age_tracker.Classes;

namespace virtual_pet_age_tracker
{
    public class ScratchCode
    {
        public void AddPetMenu()
        {
            string versionNum = "version 0.1.0";

            FileIO fileIO = new FileIO();
            fileIO.GeneratePetDictionary();

            bool loopAddPet = false;
            string userInput = "";
            string userInputLower = "";

            while (loopAddPet)
            {
                loopAddPet = false;

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

                if (userInput == "~")
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
                    fileIO.WritePet(newPet);
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
                    fileIO.WritePet(newPet);
                }

                // TODO: Write success message and Try/Catch to catch exception messages

                Console.WriteLine();
                Console.Write("Press any key to return to the Main Menu.");
                Console.ReadKey(true);
            }
        }
    }
}
