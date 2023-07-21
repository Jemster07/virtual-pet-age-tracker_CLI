using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace virtual_pet_age_tracker.Classes
{
    public class UIHelper
    {
        string versionNum = "version 1.0.0";

        public void Header()
        {
            Console.Clear();
            Console.WriteLine($"---{{ Pet Age Tracker {versionNum} }}---");
            Console.WriteLine();
        }

        public void MainMenu()
        {
            Console.Clear();
            Console.WriteLine($"---{{ Pet Age Tracker {versionNum} }}---");
            Console.WriteLine();
            Console.WriteLine("--- Main Menu ---");
            Console.WriteLine();
            Console.WriteLine("[C]urrent Pets");
            Console.WriteLine("[A]dd Pet");
            Console.WriteLine("[R]emove Pet");
            Console.WriteLine("[E]xit");
            Console.WriteLine();
            Console.Write("Please make a selection: ");
        }

        public void MainMenuInputInvalid()
        {
            Console.Clear();
            Console.WriteLine($"---{{ Pet Age Tracker {versionNum} }}---");
            Console.WriteLine();
            Console.WriteLine("[INVALID INPUT]");
            Console.WriteLine();
            Console.WriteLine("[C]urrent Pets");
            Console.WriteLine("[A]dd Pet");
            Console.WriteLine("[R]emove Pet");
            Console.WriteLine("[E]xit");
            Console.WriteLine();
            Console.Write("Please make a selection: ");
        }

        public void MainMenuUnitInvalid()
        {
            Console.Clear();
            Console.WriteLine($"---{{ Pet Age Tracker {versionNum} }}---");
            Console.WriteLine();
            Console.WriteLine("[UNIT TYPE INVALID]");
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

        public void CurrentPetsMenu()
        {
            Console.Clear();
            Console.WriteLine($"---{{ Pet Age Tracker {versionNum} }}---");
            Console.WriteLine();
            Console.WriteLine("--- Current Pets ---");
        }

        public void EnterPetName()
        {
            Console.Clear();
            Console.WriteLine($"---{{ Pet Age Tracker {versionNum} }}---");
            Console.WriteLine();
            Console.WriteLine("--- Add Pet or [~] to Cancel ---");
            Console.WriteLine();
            Console.Write("Enter the pet's name: ");
        }

        public void EnterPetNameUnitInvalid()
        {
            Console.Clear();
            Console.WriteLine($"---{{ Pet Age Tracker {versionNum} }}---");
            Console.WriteLine();
            Console.WriteLine("[UNIT TYPE INVALID]");
            Console.WriteLine();
            Console.Write("Enter the pet's name: ");
        }

        public void EnterPetType()
        {
            Console.Clear();
            Console.WriteLine($"---{{ Pet Age Tracker {versionNum} }}---");
            Console.WriteLine();
            Console.WriteLine("--- Add Pet or [~] to Cancel ---");
            Console.WriteLine();
            Console.Write("Enter the type of pet: ");
        }

        public void EnterPetTypeUnitInvalid()
        {
            Console.Clear();
            Console.WriteLine($"---{{ Pet Age Tracker {versionNum} }}---");
            Console.WriteLine();
            Console.WriteLine("[UNIT TYPE INVALID]");
            Console.WriteLine();
            Console.Write($"Enter the type of pet: ");
        }

        public void PetBirthdayToday()
        {
            Console.Clear();
            Console.WriteLine($"---{{ Pet Age Tracker {versionNum} }}---");
            Console.WriteLine();
            Console.WriteLine("--- Add Pet or [~] to Cancel ---");
            Console.WriteLine();
            Console.Write("Is today your pet's birthday? [Y/N]: ");
        }

        public void PetBirthdayTodayUnitInvalid()
        {
            Console.Clear();
            Console.WriteLine($"---{{ Pet Age Tracker {versionNum} }}---");
            Console.WriteLine();
            Console.WriteLine("[UNIT TYPE INVALID]");
            Console.WriteLine();
            Console.Write("Is today your pet's birthday? [Y/N]: ");
        }

        public void PetBirthdayTodayInputInvalid()
        {
            Console.Clear();
            Console.WriteLine($"---{{ Pet Age Tracker {versionNum} }}---");
            Console.WriteLine();
            Console.WriteLine("[INVALID INPUT]");
            Console.WriteLine();
            Console.Write("Is today your pet's birthday? [Y/N]: ");
        }

        public void EnterPetBirthday()
        {
            Console.Clear();
            Console.WriteLine($"---{{ Pet Age Tracker {versionNum} }}---");
            Console.WriteLine();
            Console.WriteLine("--- Add Pet or [~] to Cancel ---");
            Console.WriteLine();
            Console.Write("Enter the pet's birthday: ");
        }

        public void EnterPetBirthdayUnitInvalid()
        {
            Console.Clear();
            Console.WriteLine($"---{{ Pet Age Tracker {versionNum} }}---");
            Console.WriteLine();
            Console.WriteLine("[UNIT TYPE INVALID]");
            Console.WriteLine();
            Console.Write("Enter the pet's birthday: ");
        }

        public void EnterPetBirthdayFormatInvalid()
        {
            Console.Clear();
            Console.WriteLine($"---{{ Pet Age Tracker {versionNum} }}---");
            Console.WriteLine();
            Console.WriteLine("[INVALID FORMAT]");
            Console.WriteLine();
            Console.Write("Enter the pet's birthday: ");
        }

        public void EnterPetBirthTime()
        {
            Console.Clear();
            Console.WriteLine($"---{{ Pet Age Tracker {versionNum} }}---");
            Console.WriteLine();
            Console.WriteLine("--- Add Pet or [~] to Cancel ---");
            Console.WriteLine();
            Console.Write("Enter the pet's time of birth using AM/PM or 24-hour format: ");
        }

        public void EnterPetBirthTimeUnitInvalid()
        {
            Console.Clear();
            Console.WriteLine($"---{{ Pet Age Tracker {versionNum} }}---");
            Console.WriteLine();
            Console.WriteLine("[UNIT TYPE INVALID]");
            Console.WriteLine();
            Console.Write("Enter the pet's time of birth using AM/PM or 24-hour format: ");
        }

        public void EnterPetBirthTimeFormatInvalid()
        {
            Console.Clear();
            Console.WriteLine($"---{{ Pet Age Tracker {versionNum} }}---");
            Console.WriteLine();
            Console.WriteLine("[INVALID FORMAT]");
            Console.WriteLine();
            Console.Write("Enter the pet's time of birth using AM/PM or 24-hour format: ");
        }

        public void PetAddSuccess(Pet newPet)
        {
            Console.Clear();
            Console.WriteLine($"---{{ Pet Age Tracker {versionNum} }}---");
            Console.WriteLine();
            Console.WriteLine("Pet successfully added!");
            Console.WriteLine();
            Console.WriteLine($"Name: {newPet.Name}");
            Console.WriteLine($"Pet Type: {newPet.PetType}");
            Console.WriteLine($"Birthday: {newPet.Birthday.ToString("g", CultureInfo.CreateSpecificCulture("en-us"))}");
        }

        public void PetToDelete()
        {
            Console.Clear();
            Console.WriteLine($"---{{ Pet Age Tracker {versionNum} }}---");
            Console.WriteLine();
            Console.WriteLine("--- Delete Pet or [~] to Cancel ---");
            Console.WriteLine();
            Console.Write("What is the name of the pet that you want to delete? ");
        }

        public void PetToDeleteUnitInvalid()
        {
            Console.Clear();
            Console.WriteLine($"---{{ Pet Age Tracker {versionNum} }}---");
            Console.WriteLine();
            Console.WriteLine("[UNIT TYPE INVALID]");
            Console.WriteLine();
            Console.Write("What is the name of the pet that you want to delete? ");
        }

        public void DeleteConfirm(string petName)
        {
            Console.Clear();
            Console.WriteLine($"---{{ Pet Age Tracker {versionNum} }}---");
            Console.WriteLine();
            Console.WriteLine("--- Delete Pet or [~] to Cancel ---");
            Console.WriteLine();
            Console.WriteLine("WARNING: Deleting a pet is PERMANENT and cannot be undone!");
            Console.WriteLine();
            Console.WriteLine($"Are you sure you want to delete {petName}?");
            Console.WriteLine();
            Console.Write("Choose wisely [Y/N]: ");
        }

        public void DeleteConfirmUnitInvalid(string petName)
        {
            Console.Clear();
            Console.WriteLine($"---{{ Pet Age Tracker {versionNum} }}---");
            Console.WriteLine();
            Console.WriteLine("[UNIT TYPE INVALID]");
            Console.WriteLine();
            Console.WriteLine("WARNING: Deleting a pet is PERMANENT and cannot be undone!");
            Console.WriteLine();
            Console.WriteLine($"Are you sure you want to delete {petName}?");
            Console.WriteLine();
            Console.Write("Choose wisely [Y/N]: ");
        }

        public void DeleteConfirmInputInvalid(string petName)
        {
            Console.Clear();
            Console.WriteLine($"---{{ Pet Age Tracker {versionNum} }}---");
            Console.WriteLine();
            Console.WriteLine("[INVALID INPUT]");
            Console.WriteLine();
            Console.WriteLine("WARNING: Deleting a pet is PERMANENT and cannot be undone!");
            Console.WriteLine();
            Console.WriteLine($"Are you sure you want to delete {petName}?");
            Console.WriteLine();
            Console.Write("Choose wisely [Y/N]: ");
        }

        public void PetDeleteSuccess()
        {
            Console.Clear();
            Console.WriteLine($"---{{ Pet Age Tracker {versionNum} }}---");
            Console.WriteLine();
            Console.WriteLine("--- Delete Pet or [~] to Cancel ---");
            Console.WriteLine();
            Console.WriteLine("Pet successfully deleted!");
            Console.WriteLine();
            Console.Write("Would you like to delete another pet? [Y/N]: ");
        }

        public void PetDeleteSuccessUnitInvalid()
        {
            Console.Clear();
            Console.WriteLine($"---{{ Pet Age Tracker {versionNum} }}---");
            Console.WriteLine();
            Console.WriteLine("--- Delete Pet or [~] to Cancel ---");
            Console.WriteLine();
            Console.WriteLine("[UNIT TYPE INVALID]");
            Console.WriteLine();
            Console.Write("Would you like to delete another pet? [Y/N]: ");
        }

        public void PetDeleteSuccessInputInvalid()
        {
            Console.Clear();
            Console.WriteLine($"---{{ Pet Age Tracker {versionNum} }}---");
            Console.WriteLine();
            Console.WriteLine("--- Delete Pet or [~] to Cancel ---");
            Console.WriteLine();
            Console.WriteLine("[INVALID INPUT]");
            Console.WriteLine();
            Console.Write("Would you like to delete another pet? [Y/N]: ");
        }
    }
}