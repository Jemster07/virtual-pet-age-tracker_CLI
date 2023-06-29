using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace virtual_pet_age_tracker.Classes
{
    // TODO: Exception Handling!!
    public class FileIO
    {
        string directoryPath = ".\\Data\\";
        Dictionary<string, Pet> currentPets = new Dictionary<string, Pet>();

        public string[] ReadDirectory()
        {
            return Directory.GetFiles(directoryPath);
        }

        public Dictionary<string, Pet> GeneratePetDictionary()
        {
            string[] readPets = ReadDirectory();

            string name = null;
            string petType = null;
            string dateBirth = null;
            string timeBirth = null;

            string petNameLower = null;

            int lineCounter = 0;

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

                    petNameLower = pet.Name.ToLower();

                    currentPets.Add(petNameLower, pet);
                }
            }

            return currentPets;
        }

        public bool WritePet(Pet newPet)
        {
            string filePath = $"{directoryPath}{newPet.Name}.txt";
            string petNameLower = null;

            DateOnly dateBirth = DateOnly.FromDateTime(newPet.Birthday);
            TimeOnly timeBirth = TimeOnly.FromDateTime(newPet.Birthday);

            using (StreamWriter sw = new StreamWriter(filePath))
            {
                sw.WriteLine(newPet.Name);
                sw.WriteLine(newPet.PetType);
                sw.WriteLine(dateBirth);
                sw.WriteLine(timeBirth);
            }

            petNameLower = newPet.Name.ToLower();

            currentPets.Add(petNameLower, newPet);
            // TODO: Put a Try/Catch loop here in case pet is already in dictionary

            return currentPets.ContainsKey(petNameLower);
        }

        public bool DeletePet(Pet pet)
        {
            string filePath = $"{directoryPath}{pet.Name}.txt";
            string petNameLower = pet.Name.ToLower();

            if (File.Exists(filePath))
            {
                currentPets.Remove(petNameLower);
                File.Delete(filePath);
            }
            else
            {
                throw new Exception("The specified pet does not exist or the file is in use.");
            }

            return !currentPets.ContainsKey(petNameLower);
        }
    }
}
