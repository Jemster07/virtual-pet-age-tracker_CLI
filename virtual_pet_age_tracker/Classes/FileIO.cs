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

        public void WritePet()
        {
            // TODO: This method writes a new pet text file
        }

        public string[] PetsInDirectory()
        {
            return Directory.GetFiles(directoryPath);
        }

        public void ReadPets()
        {
            string[] readPets = PetsInDirectory();

            Dictionary<string, Pet> currentPets = new Dictionary<string, Pet>();

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
        }

        public void DeletePet(string filePath)
        {
            // TODO: When a pet is deleted, run the Dictionary Object.Remove() method to remove it from the dictionary
            
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            else
            {
                throw new Exception("The specified pet does not exist or the file is in use.");
            }
        }
    }
}
