using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace virtual_pet_age_tracker.Classes
{
    public class InventoryHandler
    {
        FileIO fileIO = new FileIO();
        Dictionary<string, Pet> currentPets = new Dictionary<string, Pet>();

        /// <summary>
        /// Generates a Dictionary containing Pet Objects, using the lowercase Name property as the Key.
        /// </summary>
        /// <returns>Dictionary containing Pet Objects.</returns>
        /// <exception cref="Exception"></exception>
        public Dictionary<string, Pet> GeneratePetDictionary()
        {
            string[] pathArray = fileIO.ReadDirectory();

            if (pathArray.Length == 0)
            {
                return currentPets;
            }
            else
            {
                foreach (string filePath in pathArray)
                {
                    Pet pet = fileIO.ReadPet(filePath);

                    string petNameLower = pet.Name.ToLower();

                    currentPets.Add(petNameLower, pet);
                }
            }

            return currentPets;
        }

        /// <summary>
        /// Adds the Pet Object to the Dictionary, using the lowercase Name property as the Key.
        /// </summary>
        /// <param name="pet"></param>
        /// <returns>Bool indicating if the Dictionary contains the newly created Pet Object.</returns>
        /// <exception cref="Exception"></exception>
        public bool AddToDictionary(Pet pet)
        {
            string petNameLower = pet.Name.ToLower();

            if (!currentPets.ContainsKey(petNameLower))
            {
                fileIO.WritePet(pet);

                currentPets.Add(petNameLower, pet);
            }
            else
            {
                throw new FileLoadException("ERROR: The specified pet already exists.");
            }

            return currentPets.ContainsKey(petNameLower);
        }

        /// <summary>
        /// Removes the given Pet Object from the Dictionary.
        /// </summary>
        /// <param name="pet"></param>
        /// <returns>Bool indicating if the Dictionary no longer contains the deleted Pet Object.</returns>
        /// <exception cref="Exception"></exception>
        public bool DeleteFromDictionary(string petName)
        {
            string petNameLower = petName.ToLower();

            if (currentPets.ContainsKey(petNameLower))
            {
                Pet pet = currentPets[petNameLower];
                
                fileIO.DeletePet(pet);               
                currentPets.Remove(petNameLower);
            }
            else
            {
                throw new KeyNotFoundException("ERROR: The specified pet does not exist.");
            }

            return !currentPets.ContainsKey(petNameLower);
        }

        /// <summary>
        /// Writes the current pets to the Console.
        /// </summary>
        public void PrintCurrentPets()
        {
            if (currentPets.Count > 0)
            {
                foreach (KeyValuePair<string, Pet> item in currentPets)
                {
                    TimeSpan age = item.Value.CalculateAge(item.Value.Birthday);

                    if (age.Days >= 365)
                    {
                        int yearCounter = 0;
                        int ageDays = age.Days;

                        while (ageDays >= 365)
                        {
                            yearCounter++;
                            ageDays -= 365;
                        }

                        string estimatedAge = $"{yearCounter} year(s) and {ageDays} day(s) old";

                        Console.WriteLine();
                        Console.WriteLine($"Name: {item.Value.Name}");
                        Console.WriteLine($"Pet Type: {item.Value.PetType}");
                        Console.WriteLine($"Birthday: {item.Value.Birthday.ToString("g", CultureInfo.CreateSpecificCulture("en-us"))}");
                        Console.WriteLine($"Age: {estimatedAge}");
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine($"Name: {item.Value.Name}");
                        Console.WriteLine($"Pet Type: {item.Value.PetType}");
                        Console.WriteLine($"Birthday: {item.Value.Birthday.ToString("g", CultureInfo.CreateSpecificCulture("en-us"))}");
                        Console.WriteLine($"Age: {age.Days} day(s) old");
                    }
                }
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("There are no active pets.");
            }
        }
    }
}