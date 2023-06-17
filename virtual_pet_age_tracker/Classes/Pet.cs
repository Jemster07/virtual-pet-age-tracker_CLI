using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace virtual_pet_age_tracker.Classes
{
    public class Pet
    {
        // Properties
        public string Name { get; private set; }
        public string Type { get; private set; }
        public string Birthday { get; private set; }

        // Constructor
        public Pet(string name, string type, string birthday)
        {
            Name = name;
            Type = type;
            Birthday = birthday;
        }

        // Methods
        public void DeletePet(string filePath)
        {
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
