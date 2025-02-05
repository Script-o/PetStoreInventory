using Microsoft.Extensions.DependencyInjection;
using PetStore.Data.Interfaces;
using PetStoreInventory;
using System;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Xml.Linq;

namespace PetStoreInventory
{
    class Program
    {
        static void Main(string[] args)
        {
            var services = CreateServiceCollection();

            string userInput = "";

            var productLogic = services.GetService<ProductLogic>();

            IUILogic uiLogic = new UILogic();
            Logging logging = new Logging();
            DataInput dataInput = new DataInput();

            while (userInput.ToLower() != "exit")
            {
                logging.Logger(
                    "[1] Insert Product, [2] View Product, [3] All Products" +
                    "\n[exit] Close Program");

                userInput = dataInput.AskForUserInput();

                if (userInput == "1")
                {
                    var product = uiLogic.AddProductMenu();
                    if (product != null)
                    {
                        productLogic.AddProduct(product);
                    }

                }
                else if (userInput == "2")
                {
                    logging.Logger("Enter the name of the Product you want to view.");

                    var input = dataInput.AskForUserInput();
                    int inputAsInt = UserInputCheck.IntegerCheck(input);
                    productLogic.GetProductById(inputAsInt);
                }
                else if (userInput == "3")
                {
                    var products = productLogic.GetAllProducts();
                    foreach (var product in products)
                    {
                        logging.Logger(product.Name);
                    }
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
                //AddSingleton instead??
                .AddTransient<IProductLogic, ProductLogic>()
                .BuildServiceProvider();
        }
    }
}