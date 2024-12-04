using PetStoreInventory;
using System;
using System.Text.Json;

namespace PetStoreInventory
{
    class Program
    {
        static void Main(string[] args)
        {
            string userInput = "";

            IProductLogic productLogic = new ProductLogic();
            IUILogic uiLogic = new UILogic();
            Logging logging = new Logging();
            DataInput dataInput = new DataInput();

            while (userInput.ToLower() != "exit")
            {
                logging.Logger(
                    "[1] Insert Product, [2] View Product, [6] All Products" +
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
    }
}