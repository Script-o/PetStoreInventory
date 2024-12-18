using Microsoft.Extensions.DependencyInjection;
using PetStoreInventory;
using System;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace PetStoreInventory
{
    class Program
    {
        static void Main(string[] args)
        {
            var services = CreateServiceCollection();

            string userInput = "";

            var productLogic = services.GetService<IProductLogic>();
            IUILogic uiLogic = new UILogic();
            Logging logging = new Logging();
            DataInput dataInput = new DataInput();

            while (userInput.ToLower() != "exit")
            {
                logging.Logger(
                    "[1] Insert Product, [2] Insert JSON, [3] View Product, [6] All Products" +
                    "\n[7] In Stock, [8] Out of Stock, [9] Total Price" +
                    "\n[exit] Close Program");

                userInput = dataInput.AskForUserInput();

                if (userInput == "1")
                {
                    var product = uiLogic.AddProductMenu();
                    if (product != null)
                    {
                        productLogic.AddProduct(product);
                        logging.Logger($"{product.Name} has been added.");
                        logging.Logger(JsonSerializer.Serialize(product) + "\n");
                    }

                }
                else if (userInput == "2")
                {
                    logging.Logger("\nDo you want to add Cat Food or Dog Leash?");
                    logging.Logger("Type 'cat' or 'dog'");
                    var productType = dataInput.AskForUserInput();

                    if (productType.ToLower() == "cat" || productType.ToLower() == "dog")
                    {
                        logging.Logger("Enter your product in JSON format");
                        var userInputAsJson = Console.ReadLine();

                        //JsonObject jsonParsed = UserInputCheck.JsonCheck(userInputAsJson);
                        //if (jsonParsed != null) 
                        //{
                            if (productType.ToLower() == "cat")
                            {
                                productLogic.AddProduct(JsonSerializer.Deserialize<CatFood>(userInputAsJson));
                            }
                            else if (productType.ToLower() == "dog")
                            {
                                productLogic.AddProduct(JsonSerializer.Deserialize<CatFood>(userInputAsJson));
                            }
                        //}
                    }
                    else
                    {
                        logging.Logger("Sorry, that doesn't appear to be a vaild command. You must enter 'cat or 'dog'.\n");
                    }
                }
                else if (userInput == "3")
                {
                    uiLogic.ViewProductMenu(productLogic);
                }
                else if (userInput == "6")
                {
                    var product = productLogic.GetAllProducts();
                    logging.Logger(JsonSerializer.Serialize(product) + "\n");
                }
                else if (userInput == "7")
                {
                    var product = productLogic.GetOnlyInStockProducts();
                    logging.Logger(JsonSerializer.Serialize(product) + "\n");
                }
                else if (userInput == "8")
                {
                    var product = productLogic.GetOutOfStockProducts();
                    logging.Logger(JsonSerializer.Serialize(product) + "\n");
                }
                else if (userInput == "9")
                {
                    var product = productLogic.GetTotalPriceOfInventory();
                    logging.Logger(JsonSerializer.Serialize(product) + "\n");
                }
                else if (userInput.ToLower() == "exit")
                {
                    logging.Logger("Logging off.");
                }
                else
                {
                    logging.Logger("Sorry, that isn't a valid command.\n");
                }
            }
        }

        static IServiceProvider CreateServiceCollection()
        {
            return new ServiceCollection()
                .AddTransient<IProductLogic, ProductLogic>()
                .BuildServiceProvider();
        }
    }
}