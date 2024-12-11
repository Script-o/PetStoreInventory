using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStoreInventory
{
    public class DataInput
    {
        public string AskForUserInput()
        {
            return Console.ReadLine() ?? "";
        }
    }
}
