using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace virtual_pet_age_tracker.Classes
{
    public class UI_Helper
    {
        string versionNum = "version 0.1.0";

        public void Header()
        {
            Console.Clear();
            Console.WriteLine($"---{{ Pet Age Tracker {versionNum} }}---");
            Console.WriteLine();
        }

        public void MainMenu()
        {
            Console.WriteLine();
            Console.WriteLine("[C]urrent Pets");
            Console.WriteLine("[A]dd Pet");
            Console.WriteLine("[R]emove Pet");
            Console.WriteLine("[E]xit");
            Console.WriteLine();
            Console.Write("Please make a selection: ");
        }

        public void ReturnToMainMenu()
        {
            Console.WriteLine();
            Console.Write("Press any key to return to the Main Menu.");
            Console.ReadKey(true);
        }        
        
        public void CancelAction()
        {
            Console.WriteLine("--- Add Pet or [~] to Cancel ---");
            Console.WriteLine();
        }

        public void PetAddSuccess(Pet newPet)
        {
            Console.WriteLine();
            Console.WriteLine("Pet successfully added!");
            Console.WriteLine();
            Console.WriteLine($"Name: {newPet.Name}");
            Console.WriteLine($"Pet Type: {newPet.PetType}");
            Console.WriteLine($"Birthday: {newPet.Birthday}");
        }
    }
}
