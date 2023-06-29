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
            // TODO: Use the PetsInDirectory method to generate an array of the pet file paths
            // For each item in the array, create a pet object and add it to a pet dictionary
            // Assign a numerical index to serve as the dictionary key - the pet object is the value

            string[] currentPets = PetsInDirectory();

            foreach (string item in currentPets)
            {
                using (StreamReader sr = new StreamReader(item))
                {
                    while (!sr.EndOfStream)
                    {
                        // EXAMPLE

                        //string line = sr.ReadLine();
                        //string[] productSourceArray = line.Split('|');

                        //string productLocation = productSourceArray[0];
                        //string productName = productSourceArray[1];
                        //decimal productPrice = decimal.Parse(productSourceArray[2]);
                        //string productType = productSourceArray[3];
                    }
                }
            }
        }
    }
}
