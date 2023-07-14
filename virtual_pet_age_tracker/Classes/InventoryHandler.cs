using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace virtual_pet_age_tracker.Classes
{
    public class InventoryHandler
    {
        string directoryPath = ".\\Data\\";
        Dictionary<string, Pet> currentPets = new Dictionary<string, Pet>();

        /// <summary>
        /// Checks the input directory path for existing files.
        /// An empty directory will return a Length of 0.
        /// </summary>
        /// <returns>String Array containing file paths.</returns>
        /// <exception cref="Exception"></exception>
        public string[] ReadDirectory()
        {
            try
            {
                return Directory.GetFiles(directoryPath);
            }
            catch (DirectoryNotFoundException)
            {
                throw new DirectoryNotFoundException("ERROR: The directory where pets are saved is currently inaccessible.");
            }
        }

        /// <summary>
        /// Reads all files in a given directory and writes their contents to the properties of a Pet Object.
        /// Adds the generated Pet Objects to a Dictionary, using the lowercase Name property as the Key.
        /// </summary>
        /// <returns>Dictionary containing Pet Objects.</returns>
        /// <exception cref="Exception"></exception>
        public Dictionary<string, Pet> GeneratePetDictionary()
        {
            string[] readPets = ReadDirectory();

            if (readPets.Length == 0)
            {
                return currentPets;
            }
            else
            {
                string name = null;
                string petType = null;
                string dateBirth = null;
                string timeBirth = null;

                int lineCounter = 0;

                // TODO: Breakout file reading into separate class so Database can be easily swapped in

                try
                {
                    foreach (string item in readPets)
                    {
                        using (StreamReader sr = new StreamReader(item))
                        {
                            while (!sr.EndOfStream)
                            {
                                string line = sr.ReadLine();

                                if (lineCounter == 0)
                                {
                                    name = line;
                                    lineCounter++;
                                }
                                else if (lineCounter == 1)
                                {
                                    petType = line;
                                    lineCounter++;
                                }
                                else if (lineCounter == 2)
                                {
                                    dateBirth = line;
                                    lineCounter++;
                                }
                                else // lineCounter == 3
                                {
                                    timeBirth = line;
                                    lineCounter = 0;
                                }
                            }

                            Pet pet = new Pet(name, petType, dateBirth, timeBirth);

                            string petNameLower = pet.Name.ToLower();

                            currentPets.Add(petNameLower, pet);
                        }
                    }
                }
                catch (DirectoryNotFoundException)
                {
                    throw new DirectoryNotFoundException("ERROR: The directory where pets are saved is currently inaccessible.");
                }

                return currentPets;
            }
        }

        /// <summary>
        /// Creates a new file in the directory using a Pet Object.
        /// Adds the Pet Object to a Dictionary, using the lowercase Name property as the Key.
        /// </summary>
        /// <param name="pet"></param>
        /// <returns>Bool indicating if the Dictionary contains the newly created Pet Object.</returns>
        /// <exception cref="Exception"></exception>
        public bool WritePet(Pet pet)
        {
            string filePath = $"{directoryPath}{pet.Name}.txt";
            string petNameLower = pet.Name.ToLower();

            if (!currentPets.ContainsKey(petNameLower))
            {
                currentPets.Add(petNameLower, pet);

                DateOnly dateBirth = DateOnly.FromDateTime(pet.Birthday);
                TimeOnly timeBirth = TimeOnly.FromDateTime(pet.Birthday);

                try
                {
                    using (StreamWriter sw = new StreamWriter(filePath))
                    {
                        sw.WriteLine(pet.Name);
                        sw.WriteLine(pet.PetType);
                        sw.WriteLine(dateBirth);
                        sw.WriteLine(timeBirth);
                    }
                }
                catch (IOException)
                {
                    throw new IOException("ERROR: There was an issue writing the pet file.");
                }
            }
            else
            {
                throw new FileLoadException("ERROR: The specified pet already exists.");
            }

            return currentPets.ContainsKey(petNameLower);
        }

        /// <summary>
        /// Removes the given Pet Object from the Dictionary and deletes the associated file from the directory.
        /// </summary>
        /// <param name="pet"></param>
        /// <returns>Bool indicating if the Dictionary no longer contains the deleted Pet Object.</returns>
        /// <exception cref="Exception"></exception>
        public bool DeletePet(Pet pet)
        {
            string filePath = $"{directoryPath}{pet.Name}.txt";
            string petNameLower = pet.Name.ToLower();

            try
            {
                if (File.Exists(filePath))
                {
                    currentPets.Remove(petNameLower);
                    File.Delete(filePath);
                }
                else
                {
                    throw new FileNotFoundException("ERROR: The specified pet does not exist.");
                }
            }
            catch (DirectoryNotFoundException)
            {
                throw new DirectoryNotFoundException("ERROR: The directory where pets are saved is currently inaccessible.");
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

                        Console.WriteLine($"Name: {item.Value.Name}");
                        Console.WriteLine($"Pet Type: {item.Value.PetType}");
                        Console.WriteLine($"Birthday: {item.Value.Birthday}");
                        Console.WriteLine($"Age: {estimatedAge}");
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine($"Name: {item.Value.Name}");
                        Console.WriteLine($"Pet Type: {item.Value.PetType}");
                        Console.WriteLine($"Birthday: {item.Value.Birthday}");
                        Console.WriteLine($"Age: {age.Days} day(s) old");
                        Console.WriteLine();
                    }
                }
            }
            else
            {
                Console.WriteLine("There are no active pets.");
                Console.WriteLine();
            }
        }
    }
}