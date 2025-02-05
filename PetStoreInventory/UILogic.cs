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
            logging.Logger("\nDo you want to add Cat Food or Dog Leash?");
            logging.Logger("Type 'cat' or 'dog'");
            string userInput = dataInput.AskForUserInput();

            if (userInput.ToLower() == "cat" || userInput.ToLower() == "dog")
            {
                string productType = "";
                if (userInput.ToLower() == "cat")
                {
                    logging.Logger("What is the name of the Cat Food?");
                    productType = "cat";
                }
                if (userInput.ToLower() == "dog")
                {
                    logging.Logger("What is the name of the Dog Leash?");
                    productType = "dog";
                }
                string ProductName = dataInput.AskForUserInput();

                logging.Logger($"What is the price of the {ProductName}?");
                userInput = dataInput.AskForUserInput();
                decimal ProductPrice = UserInputCheck.DecimalCheck(userInput);

                logging.Logger($"What is the quantity of the {ProductName}?");
                userInput = dataInput.AskForUserInput();
                int ProductQuantity = UserInputCheck.IntegerCheck(userInput);

                logging.Logger($"What is the description of the {ProductName}?");
                string ProductDescription = dataInput.AskForUserInput();

                if (productType == "cat")
                {
                    logging.Logger($"What is the weight of the {ProductName}?");
                    userInput = dataInput.AskForUserInput();
                    int ProductWeightPounds = UserInputCheck.IntegerCheck(userInput);

                    logging.Logger($"Is the {ProductName} kitten food?");
                    logging.Logger("true or false");
                    userInput = dataInput.AskForUserInput();
                    bool ProductKittenFood = UserInputCheck.BoolCheck(userInput);

                    Product product = new CatFood()
                    {
                        Name = ProductName,
                        Price = ProductPrice,
                        Quantity = ProductQuantity,
                        Description = ProductDescription,
                        WeightPounds = ProductWeightPounds,
                        KittenFood = ProductKittenFood
                    };

                    return product;
                }
                if (productType == "dog")
                {
                    logging.Logger($"What is the length of the {ProductName}?");
                    userInput = dataInput.AskForUserInput();
                    int ProductLength = UserInputCheck.IntegerCheck(userInput);

                    logging.Logger($"What material is the {ProductName} made of?");
                    string ProductMaterial = dataInput.AskForUserInput();

                    Product product = new DogLeash()
                    {
                        Name = ProductName,
                        Price = ProductPrice,
                        Quantity = ProductQuantity,
                        Description = ProductDescription,
                        LengthInches = ProductLength,
                        Material = ProductMaterial
                    };

                    return product;
                }
            }
            else
            {
                logging.Logger("Sorry, that doesn't appear to be a vaild command. You must enter 'cat or 'dog'.\n");
            }
            return null;
        }
        public void ViewProductMenu(IProductLogic productLogic)
        {
            logging.Logger("\nDo you want to view a Cat Food or a Dog Leash?");
            logging.Logger("Enter \"cat\" or \"dog\"");
            var productType = dataInput.AskForUserInput();
            if (productType.ToLower() == "cat")
            {
                logging.Logger("Enter the name of the Cat Food you want to view.");
                logging.Logger(JsonSerializer.Serialize(productLogic.GetOnlyInStockCatFood()));
            }
            if (productType.ToLower() == "dog")
            {
                logging.Logger("Enter the name of the Dog Leash you want to view.");
                logging.Logger(JsonSerializer.Serialize(productLogic.GetOnlyInStockDogLeash()));
            }
            if (productType.ToLower() == "cat" || productType.ToLower() == "dog")
            {
                var input = dataInput.AskForUserInput();
                if (productType.ToLower() == "cat")
                {
                    var product = productLogic.GetProductName<CatFood>(input);
                    var discount = productLogic.GetProductPrice(input, productType);
                    if (product == null)
                    {
                        logging.Logger("Sorry, that product doesn't exist.\n");
                    }
                    else
                    {
                        logging.Logger(product);
                        logging.Logger($"Discounted Price= {discount.DiscountThisPrice()}\n");
                    }
                }
                else if (productType.ToLower() == "dog")
                {
                    var product = productLogic.GetProductName<DogLeash>(input);
                    var discount = productLogic.GetProductPrice(input, productType);
                    if (product == null)
                    {
                        logging.Logger("Sorry, that product doesn't exist.\n");
                    }
                    else
                    {
                        logging.Logger(product);
                        logging.Logger($"Discounted Price= {discount.DiscountThisPrice()}\n");
                    }
                }         
            }
            else
            {
                logging.Logger("Sorry, you must enter either \"cat\" or \"dog\".\n");
            }

        }

        public string OutputJsonToConsoleClean(List<Product> _products)
        {
            var output = "";
            foreach (Product product in _products)
            {
                output += $"--- {product.Name} ---\n";
                foreach (var propertyInfo in product.GetType().GetProperties())
                {
                    if (propertyInfo.Name == "Name")
                    {

                    }
                    else if (propertyInfo.GetValue(product) is null)
                    {
                        output += $"{propertyInfo.Name}: NULL, ";
                    }
                    else
                    {
                        output += $"{propertyInfo.Name}: {propertyInfo.GetValue(product)}, ";
                    }
                }
                //Come back to this Regex to understand it. Matches every instance of , then selects last one?
                output = Regex.Replace(output, "(?:,)([^,]+)$", "\n");
            }
            return output;
        }
    }
}
