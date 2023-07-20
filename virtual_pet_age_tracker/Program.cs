using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using virtual_pet_age_tracker.Classes;

namespace virtual_pet_age_tracker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UI RunProgram = new UI();
            RunProgram.CallUI();
            return;
        }
    }
}