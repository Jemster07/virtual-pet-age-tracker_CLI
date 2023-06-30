using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using virtual_pet_age_tracker.Classes;

namespace virtual_pet_age_tracker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UI RunProgram = new UI();
            // Comment out the CallUI method and return statement to use the scratch code
            RunProgram.CallUI();
            return;

            // Scratch Code

            FileIO testIO = new FileIO();
            Dictionary<string, Pet> currentPets = testIO.GeneratePetDictionary();

            Pet petToDelete = currentPets["Carl"];

            string name = "Carl";
            string petType = "Pixel Puppy";
            DateTime currentTime = DateTime.Now;

            string dateBirth = "03/28/1992";
            string timeBirth = "5:30 am";
            
            Pet testPet = new Pet(name, petType, dateBirth, timeBirth);

            testIO.WritePet(testPet);

            Console.WriteLine(testPet.Birthday);
            Console.WriteLine();

            string filePath = ".\\Data\\" + name + ".txt";

            Console.WriteLine(filePath);
            Console.WriteLine();

            Console.WriteLine($"{testPet.Name}, {testPet.PetType}, {testPet.Birthday}");
            Console.WriteLine();

            try
            {
                testIO.DeletePet(petToDelete);
                Console.WriteLine("Your pet has been successfully deleted.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine();
            Console.Write("Enter the pet's birthday: ");

            string userInput = Console.ReadLine();
            DateOnly date = DateOnly.Parse(userInput);
            // Make sure to include a Try/Catch to handle non-DateOnly inputs
            
            Console.WriteLine();
            Console.Write("Enter the pet's time of birth using AM/PM or 24-hour format: ");
            // Make sure to include a Try/Catch to handle non-TimeOnly inputs

            userInput = Console.ReadLine();
            TimeOnly time = TimeOnly.Parse(userInput);

            string combinedDateTime = date + " " + time;
            DateTime birthday = DateTime.Parse(combinedDateTime);
            
            Console.WriteLine();
            Console.WriteLine($"Your pet's birthday is: {birthday}");

            Console.Write("Press any key to return to the Main Menu.");
            Console.ReadKey(true);
        }
    }
}