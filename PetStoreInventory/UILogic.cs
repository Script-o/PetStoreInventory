using PetStore.Data;
using PetStore.Data.Interfaces;
using PetStoreInventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PetStoreInventory
{
    public class UILogic :IUILogic
    {
        Logging logging = new Logging();
        DataInput dataInput = new DataInput();
        public Product AddProductMenu()
        {
            logging.Logger("What is the name of the Product?");
 
            string ProductName = dataInput.AskForUserInput();

            logging.Logger($"What is the price of the {ProductName}?");
            string userInput = dataInput.AskForUserInput();
            decimal ProductPrice = UserInputCheck.DecimalCheck(userInput);

            logging.Logger($"What is the quantity of the {ProductName}?");
            userInput = dataInput.AskForUserInput();
            int ProductQuantity = UserInputCheck.IntegerCheck(userInput);

            logging.Logger($"What is the description of the {ProductName}?");
            string ProductDescription = dataInput.AskForUserInput();

            Product product = new Product()
            {
                ProductId = 1,
                Name = ProductName,
                Price = ProductPrice,
                Quantity = ProductQuantity,
                Description = ProductDescription
            };

            return product;
        }
    }
}
