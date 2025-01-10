using PetStoreInventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PetStoreInventory
{
    public class UserInputCheck
    {
        public static int IntegerCheck(string input)
        {
            Logging logging = new Logging();
            DataInput dataInput = new DataInput();
            bool inputCheck = false;
            int intInput = 0;
            while (inputCheck == false)
            {
                if (int.TryParse(input, out intInput))
                {
                    inputCheck = true;
                }
                else
                {
                    logging.Logger("\nSorry, that doesn't appear to be a valid number. \nYou must enter a whole number, an example would be '12'.");
                    input = dataInput.AskForUserInput();
                }
            }
            return intInput;
        }

        public static decimal DecimalCheck(string input)
        {
            Logging logging = new Logging();
            DataInput dataInput = new DataInput();
            bool inputCheck = false;
            decimal decInput = 0;
            while (inputCheck == false)
            {
                if (decimal.TryParse(input, out decInput))
                {
                    inputCheck = true;
                }
                else
                {
                    logging.Logger("\nSorry, that doesn't appear to be a valid decimal. \nYou must enter a decimal number, an example would be '1.5'.");
                    input = dataInput.AskForUserInput();
                }
            }
            return decInput;
        }

        public static bool BoolCheck(string input)
        {
            Logging logging = new Logging();
            DataInput dataInput = new DataInput();
            bool inputCheck = false;
            bool boolInput = false;
            while (inputCheck == false)
            {
                if (bool.TryParse(input, out boolInput))
                {
                    inputCheck = true;
                }
                else
                {
                    logging.Logger("\nSorry, that doesn't appear to be a valid true/false statement. \nYou must enter either 'true' or 'false'.");
                    input = dataInput.AskForUserInput();
                }
            }
            return boolInput;
        }
    }
}
