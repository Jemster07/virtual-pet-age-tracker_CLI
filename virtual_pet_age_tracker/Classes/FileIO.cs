using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace virtual_pet_age_tracker.Classes
{
    public class FileIO
    {
        // Use this directory variable for Windows compatibility
        //string directoryPath = ".\\Data\\";

        // Use this directory variable for MacOS/Unix compatibility
        string directoryPath = "./Data/";

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
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }

                return Directory.GetFiles(directoryPath);
            }
            catch (DirectoryNotFoundException)
            {
                throw new DirectoryNotFoundException("ERROR: The directory where pets are saved is currently inaccessible.");
            }
        }

        /// <summary>
        /// Reads a file in a given directory and writes its contents to the properties of a Pet Object.
        /// </summary>
        /// <returns>Pet Object.</returns>
        /// <exception cref="Exception"></exception>
        public Pet ReadPet(string filePath)
        {
            string name = null;
            string petType = null;
            string dateBirth = null;
            string timeBirth = null;

            int lineCounter = 0;

            try
            {
                using (StreamReader sr = new StreamReader(filePath))
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

                    return pet;
                }
            }
            catch (DirectoryNotFoundException)
            {
                throw new DirectoryNotFoundException("ERROR: The directory where pets are saved is currently inaccessible.");
            }
        }

        /// <summary>
        /// Creates a new file in the directory using a Pet Object.
        /// </summary>
        /// <param name="pet"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public void WritePet(Pet pet)
        {
            string filePath = $"{directoryPath}{pet.Name}.txt";

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

        /// <summary>
        /// Deletes the given Pet Object file from the directory.
        /// </summary>
        /// <param name="pet"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public void DeletePet(Pet pet)
        {
            string filePath = $"{directoryPath}{pet.Name}.txt";

            try
            {
                if (File.Exists(filePath))
                {
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
        }
    }
}