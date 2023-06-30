using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace virtual_pet_age_tracker.Classes
{
    public class FileIO
    {
        string directoryPath = ".\\Data\\";
        Dictionary<string, Pet> currentPets = new Dictionary<string, Pet>();

        public string[] ReadDirectory()
        {
            try
            {
                return Directory.GetFiles(directoryPath);
            }
            catch (Exception)
            {
                throw new Exception("ERROR: The directory where pets are saved is currently inaccessible.");
            }
        }

        public Dictionary<string, Pet> GeneratePetDictionary()
        {
            string[] readPets = ReadDirectory();

            string name = null;
            string petType = null;
            string dateBirth = null;
            string timeBirth = null;

            int lineCounter = 0;

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
            catch (Exception)
            {
                throw new Exception("ERROR: The directory where pets are saved is currently inaccessible.");
            }

            return currentPets;
        }

        public bool WritePet(Pet newPet)
        {
            string filePath = $"{directoryPath}{newPet.Name}.txt";
            string petNameLower = newPet.Name.ToLower();

            if (!currentPets.ContainsKey(petNameLower))
            {
                currentPets.Add(petNameLower, newPet);
            }
            else
            {
                throw new Exception("ERROR: The specified pet already exists.");
            }

            DateOnly dateBirth = DateOnly.FromDateTime(newPet.Birthday);
            TimeOnly timeBirth = TimeOnly.FromDateTime(newPet.Birthday);

            try
            {
                using (StreamWriter sw = new StreamWriter(filePath))
                {
                    sw.WriteLine(newPet.Name);
                    sw.WriteLine(newPet.PetType);
                    sw.WriteLine(dateBirth);
                    sw.WriteLine(timeBirth);
                }
            }
            catch (Exception)
            {
                throw new Exception("ERROR: There was an issue writing the pet file.");
            }

            return currentPets.ContainsKey(petNameLower);
        }

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
                    throw new Exception("ERROR: The specified pet does not exist.");
                }
            }
            catch (Exception)
            {
                throw new Exception("ERROR: The directory where pets are saved is currently inaccessible.");
            }

            return !currentPets.ContainsKey(petNameLower);
        }
    }
}
