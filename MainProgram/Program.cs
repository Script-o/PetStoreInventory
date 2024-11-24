using PetStoreInventory;
using System;
using System.Text.Json;

namespace PetStoreInventory
{
    class Program
    {
        static void Main(string[] args)
        {
            string userInput = "start";
            string productType = "start";

            IProductLogic productLogic = new ProductLogic();

            while (userInput.ToLower() != "exit")
            {
                Console.WriteLine("\n[1] Insert Product, [2] View Product, [8] All Products");
                Console.WriteLine("[9] In Stock, [10] Out of Stock, 'exit'");
                userInput = Console.ReadLine() ?? "";

                if (userInput == "1")
                {
                    Console.WriteLine("\nDo you want to add Cat Food or Dog Leash?");
                    Console.WriteLine("Type 'cat' or 'dog'");
                    userInput = Console.ReadLine() ?? "";

                    if (userInput.ToLower() == "cat" || userInput.ToLower() == "dog")
                    {
                        if (userInput.ToLower() == "cat")
                        {
                            Console.WriteLine("What is the name of the Cat Food?");
                            productType = "cat";
                        }
                        if (userInput.ToLower() == "dog")
                        {
                            Console.WriteLine("What is the name of the Dog Leash?");
                            productType = "dog";
                        }
                        string ProductName = Console.ReadLine() ?? "";

                        Console.WriteLine($"What is the price of the {ProductName}?");
                        userInput = Console.ReadLine() ?? "";
                        decimal ProductPrice = UserInputCheck.DecimalCheck(userInput);

                        Console.WriteLine($"What is the quantity of the {ProductName}?");
                        userInput = Console.ReadLine() ?? "";
                        int ProductQuantity = UserInputCheck.IntegerCheck(userInput);

                        Console.WriteLine($"What is the description of the {ProductName}?");
                        string ProductDescription = Console.ReadLine() ?? "";

                        if (productType == "cat")
                        {
                            Console.WriteLine($"What is the weight of the {ProductName}?");
                            userInput = Console.ReadLine() ?? "";
                            int ProductWeightPounds = UserInputCheck.IntegerCheck(userInput);

                            Console.WriteLine($"Is the {ProductName} kitten food?");
                            Console.WriteLine("true or false");
                            userInput = Console.ReadLine() ?? "";
                            bool ProductKittenFood = UserInputCheck.BoolCheck(userInput);

                            CatFood product = new CatFood()
                            {
                                Name = ProductName,
                                Price = ProductPrice,
                                Quantity = ProductQuantity,
                                Description = ProductDescription,
                                WeightPounds = ProductWeightPounds,
                                KittenFood = ProductKittenFood
                            };

                            productLogic.AddProduct(product);
                            Console.WriteLine($"{product.Name} has been added.");
                            Console.WriteLine(JsonSerializer.Serialize(product));
                        }
                        if (productType == "dog")
                        {
                            Console.WriteLine($"What is the length of the {ProductName}?");
                            userInput = Console.ReadLine() ?? "";
                            int ProductLength = UserInputCheck.IntegerCheck(userInput);

                            Console.WriteLine($"What material is the {ProductName} made of?");
                            string ProductMaterial = Console.ReadLine() ?? "";

                            IProduct product = new DogLeash()
                            {
                                Name = ProductName,
                                Price = ProductPrice,
                                Quantity = ProductQuantity,
                                Description = ProductDescription,
                                LengthInches = ProductLength,
                                Material = ProductMaterial
                            };

                            productLogic.AddProduct(product);
                            Console.WriteLine($"{product.Name} has been added.");
                            Console.WriteLine(JsonSerializer.Serialize(product));
                        }
                    }
                    else
                    {
                        Console.WriteLine("Sorry, that doesn't appear to be a vaild command. You must enter 'cat or 'dog'.");
                    }

                }
                else if (userInput == "2")
                {
                    Console.WriteLine("Do you want to view a Cat Food or a Dog Leash?");
                    Console.WriteLine("Enter \"cat\" or \"dog\"");
                    var input = Console.ReadLine() ?? "";
                    if (input.ToLower() == "cat")
                    {
                        Console.WriteLine("Enter the name of the Cat Food you want to view.");
                        input = Console.ReadLine() ?? "";
                        var product = productLogic.GetCatFoodName(input);
                        var discount = productLogic.GetCatFoodPrice(input);
                        if (product == null)
                        {
                            Console.WriteLine("Sorry, that product doesn't exist.");
                        }
                        else
                        {
                            Console.WriteLine(JsonSerializer.Serialize(product));
                            Console.WriteLine($"Discounted Price= {discount.DiscountThisPrice()}");
                        }
                    }
                    else if (input.ToLower() == "dog")
                    {
                        Console.WriteLine("Enter the name of the Dog Leash you want to view.");
                        input = Console.ReadLine() ?? "";
                        var product = productLogic.GetDogLeashName(input);
                        var discount = productLogic.GetDogLeashPrice(input);
                        if (product == null)
                        {
                            Console.WriteLine("Sorry, that product doesn't exist.");
                        }
                        else
                        {
                            Console.WriteLine(JsonSerializer.Serialize(product));
                            Console.WriteLine($"Discounted Price= {discount.DiscountThisPrice()}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Sorry, you must enter either \"cat\" or \"dog\".");
                    }
                }
                else if (userInput == "8")
                {
                    var product = productLogic.GetAllProducts();
                    Console.WriteLine(JsonSerializer.Serialize(product));
                }
                else if (userInput == "9")
                {
                    var product = productLogic.GetOnlyInStockProducts();
                    Console.WriteLine(JsonSerializer.Serialize(product));
                }
                else if (userInput == "10")
                {
                    var product = productLogic.GetOutOfStockProducts();
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