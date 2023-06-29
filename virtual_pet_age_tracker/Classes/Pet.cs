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
        public string PetType { get; private set; }
        private string DateBirth { get; set; }
        private string TimeBirth { get; set; }
        public DateTime Birthday
        {
            get
            {
                DateOnly date = DateOnly.Parse(DateBirth);

                TimeOnly time = TimeOnly.Parse(TimeBirth);

                string combinedDateTime = $"{date} {time}";

                DateTime birthday = DateTime.Parse(combinedDateTime);

                return birthday;
            }
        }

        // Constructor
        public Pet(string name, string petType, string dateBirth, string timeBirth)
        {
            Name = name;
            PetType = petType;
            DateBirth = dateBirth;
            TimeBirth = timeBirth;
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
