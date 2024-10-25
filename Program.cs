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

            var productLogic = new ProductLogic();

            while (userInput.ToLower() != "exit")
            {
                Console.WriteLine("Press 1 to add a product");
                Console.WriteLine("Press 2 to view a dog leash by name");
                Console.WriteLine("Press 8 to view all products");
                Console.WriteLine("Type 'exit' to quit");
                userInput = Console.ReadLine();

                if (userInput == "1")
                {
                    Console.WriteLine("Do you want to add Cat Food or Dog Leash?");
                    Console.WriteLine("Type 'cat' or 'dog'");
                    userInput = Console.ReadLine();
//Cat Food Section                    
                    if (userInput.ToLower() == "cat")
                    {
                        Console.WriteLine("What is the name of the Cat Food?");
                        CatFood product = new CatFood() { Name = Console.ReadLine()};

                        Console.WriteLine("What is the price of the Cat Food?");
                        userInput = Console.ReadLine();
                        bool intCheck = false;
                        decimal catPrice = 0;
                        while (intCheck == false)
                        {
                            if (decimal.TryParse(userInput, out catPrice))
                            {
                                product.Price = catPrice;
                                intCheck = true;
                            }
                            else
                            {
                                Console.WriteLine("Sorry, that doesn't appear to be a price. Please try again.");
                                userInput = Console.ReadLine();
                            }
                        }

                        Console.WriteLine("What is the quantity of the Cat Food?");
                        userInput = Console.ReadLine();
                        intCheck = false;
                        int catQuantity = 0;
                        while (intCheck == false)
                        {
                            if (int.TryParse(userInput, out catQuantity))
                            {
                                product.Quantity = catQuantity;
                                intCheck = true;
                            }
                            else
                            {
                                Console.WriteLine("Sorry, that doesn't appear to be a valid quantity. Please try again.");
                                userInput = Console.ReadLine();
                            }
                        }

                        Console.WriteLine("What is the description of the Cat Food?");
                        product.Description = Console.ReadLine();

                        Console.WriteLine("What is the weight of the Cat Food?");
                        userInput = Console.ReadLine();
                        intCheck = false;
                        int catWeight = 0;
                        while (intCheck == false)
                        {
                            if (int.TryParse(userInput, out catWeight))
                            {
                                product.WeightPounds = catWeight;
                                intCheck = true;
                            }
                            else
                            {
                                Console.WriteLine("Sorry, that doesn't appear to be a valid weight. Please try again.");
                                userInput = Console.ReadLine();
                            }
                        }

                        Console.WriteLine("Is this kitten food?");
                        Console.WriteLine("true or false");
                        userInput = Console.ReadLine();
                        intCheck = false;
                        bool catKitenFood = false;
                        while (intCheck == false)
                        {
                            if (bool.TryParse(userInput, out catKitenFood))
                            {
                                product.KittenFood = catKitenFood;
                                intCheck = true;
                            }
                            else
                            {
                                Console.WriteLine("Sorry, you must enter either 'true' or 'false'. Please try again.");
                                userInput = Console.ReadLine();
                            }
                        }
                        
                        productLogic.AddProduct(product);
                        Console.WriteLine($"{ product.Name} has been added.");
                        Console.WriteLine(JsonSerializer.Serialize(product));

                    }
//Dog Leash Section
                    if (userInput.ToLower() == "dog")
                    {
                        Console.WriteLine("What is the name of the Dog Leash?");
                        DogLeash product = new DogLeash() { Name = Console.ReadLine() };

                        Console.WriteLine("What is the price of the Dog Leash?");
                        userInput = Console.ReadLine();
                        bool intCheck = false;
                        decimal dogPrice = 0;
                        while (intCheck == false)
                        {
                            if (decimal.TryParse(userInput, out dogPrice))
                            {
                                product.Price = dogPrice;
                                intCheck = true;
                            }
                            else
                            {
                                Console.WriteLine("Sorry, that doesn't appear to be a price. Please try again.");
                                userInput = Console.ReadLine();
                            }
                        }

                        Console.WriteLine("What is the quantity of the Dog Leash?");
                        userInput = Console.ReadLine();
                        intCheck = false;
                        int dogQuantity = 0;
                        while (intCheck == false)
                        {
                            if (int.TryParse(userInput, out dogQuantity))
                            {
                                product.Quantity = dogQuantity;
                                intCheck = true;
                            }
                            else
                            {
                                Console.WriteLine("Sorry, that doesn't appear to be a valid quantity. Please try again.");
                                userInput = Console.ReadLine();
                            }
                        }

                        Console.WriteLine("What is the description of the Dog Leash?");
                        product.Description = Console.ReadLine();

                        Console.WriteLine("What is the length of the Dog Leash?");
                        userInput = Console.ReadLine();
                        intCheck = false;
                        int dogLength = 0;
                        while (intCheck == false)
                        {
                            if (int.TryParse(userInput, out dogLength))
                            {
                                product.LengthInches = dogLength;
                                intCheck = true;
                            }
                            else
                            {
                                Console.WriteLine("Sorry, that doesn't appear to be a valid length. Please try again.");
                                userInput = Console.ReadLine();
                            }
                        }

                        Console.WriteLine("What material is this made of?");
                        product.Material = Console.ReadLine();

                        productLogic.AddProduct(product);
                        Console.WriteLine($"{product.Name} has been added.");
                        Console.WriteLine(JsonSerializer.Serialize(product));

                    }

                }
                else if (userInput == "2")
                {
                    Console.WriteLine("Enter the name of the product you want to view.");
                    var product = productLogic.GetDogLeashName(Console.ReadLine());
                    if (product == null)
                    {
                        Console.WriteLine("Sorry, that product doesn't exist.");
                    }
                    else
                    {
                        Console.WriteLine(JsonSerializer.Serialize(product));
                    }
                }
                else if (userInput == "8")
                {
                    var product = productLogic.GetAllProducts();
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