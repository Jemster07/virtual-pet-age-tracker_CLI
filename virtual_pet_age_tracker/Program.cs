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
            RunProgram.CallUI();
            // Comment out the return statement to use the sample code
            return;

            // Sample Code
            
            string name = "Carl";
            string type = "Pixel Puppy";
            string currentTime = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss tt");
            
            Pet testPet = new Pet(name, type, currentTime);

            string filePath = ".\\Data\\" + name + ".txt";

            Console.WriteLine(filePath);
            Console.WriteLine();

            Console.WriteLine($"{testPet.Name}, {testPet.Type}, {testPet.Birthday}");
            Console.WriteLine();

            try
            {
                testPet.DeletePet(filePath);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine();
            Console.Write("Enter the pet's birthday: ");

            string userInput = Console.ReadLine();
            DateOnly date = DateOnly.Parse(userInput);
            
            Console.WriteLine();
            Console.Write("Enter the pet's time of birth using AM/PM or 24-hour format: ");

            userInput = Console.ReadLine();
            TimeOnly time = TimeOnly.Parse(userInput);

            string combinedDateTime = date + " " + time;
            DateTime birthday = DateTime.Parse(combinedDateTime);
            
            Console.WriteLine();
            Console.WriteLine($"Your pet's birthday is: {birthday}");
        }
    }
}