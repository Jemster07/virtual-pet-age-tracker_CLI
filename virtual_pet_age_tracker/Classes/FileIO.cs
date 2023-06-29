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

                    Pet newPet = new(name, petType, dateBirth, timeBirth);
                    currentPets.Add(newPet.Name, newPet);
                }
            }

            return currentPets;
        }

        public void WritePet()
        {
            // TODO: This method writes a new pet text file
        }

        public void DeletePet(string petName, string filePath)
        {
            if (File.Exists(filePath))
            {
                currentPets.Remove(petName);
                File.Delete(filePath);
            }
            else
            {
                throw new Exception("The specified pet does not exist or the file is in use.");
            }
        }
    }
}
