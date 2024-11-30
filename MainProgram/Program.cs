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

            while (userInput.ToLower() != "exit")
            {
                Console.WriteLine(
                    "\n[1] Insert Product, [2] View Product, [6] All Products" +
                    "\n[7] In Stock, [8] Out of Stock, [9] Total Price" +
                    "\n[exit] Close Program");



                userInput = Console.ReadLine() ?? "";



                if (userInput == "1")
                {
                    var product = uiLogic.AddProductMenu();
                    if (product != null)
                    {
                        productLogic.AddProduct(product);
                        Console.WriteLine($"{product.Name} has been added.");
                        Console.WriteLine(JsonSerializer.Serialize(product));
                    }

                }
                else if (userInput == "2")
                {
                    uiLogic.ViewProductMenu(productLogic);
                }
                else if (userInput == "6")
                {
                    var product = productLogic.GetAllProducts();
                    Console.WriteLine(JsonSerializer.Serialize(product));
                }
                else if (userInput == "7")
                {
                    var product = productLogic.GetOnlyInStockProducts();
                    Console.WriteLine(JsonSerializer.Serialize(product));
                }
                else if (userInput == "8")
                {
                    var product = productLogic.GetOutOfStockProducts();
                    Console.WriteLine(JsonSerializer.Serialize(product));
                }
                else if (userInput == "9")
                {
                    var product = productLogic.GetTotalPriceOfInventory();
                    Console.WriteLine(JsonSerializer.Serialize(product));
                }
                else if (userInput.ToLower() == "exit")
                {
                    Console.WriteLine("Logging off.");
                }
                else
                {
                    Console.WriteLine("Sorry, that isn't a valid command.");
                }
            }
        }
    }
}