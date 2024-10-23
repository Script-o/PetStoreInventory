using System;
using System.Text.Json;

namespace Templates
{
    class Program
    {
        static void Main(string[] args)
        {
            string userInput = "start";

            while (userInput.ToLower() != "exit")
            {
                Console.WriteLine("Press 1 to add a product");
                Console.WriteLine("Type 'exit' to quit");
                userInput = Console.ReadLine();

                if (userInput == "1")
                {
                    Console.WriteLine("Do you want to add Cat Food or Dog Leash?");
                    Console.WriteLine("Type 'cat' or 'dog'");
                    userInput = Console.ReadLine();
                    if (userInput == "cat")
                    {
                        Console.WriteLine("What is the name of the Cat Food?");
                        string catName = Console.ReadLine();

                        Console.WriteLine("What is the price of the Cat Food?");
                        userInput = Console.ReadLine();
                        bool intCheck = false;
                        decimal catPrice = 0;
                        while (intCheck == false)
                        {
                            if (decimal.TryParse(userInput, out catPrice))
                            {
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
                                intCheck = true;
                            }
                            else
                            {
                                Console.WriteLine("Sorry, that doesn't appear to be a valid quantity. Please try again.");
                                userInput = Console.ReadLine();
                            }
                        }

                        Console.WriteLine("What is the description of the Cat Food?");
                        string catDescription = Console.ReadLine();

                        Console.WriteLine("What is the weight of the Cat Food?");
                        userInput = Console.ReadLine();
                        intCheck = false;
                        int catWeight = 0;
                        while (intCheck == false)
                        {
                            if (int.TryParse(userInput, out catWeight))
                            {
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
                                intCheck = true;
                            }
                            else
                            {
                                Console.WriteLine("Sorry, you must enter either 'true' or 'false'. Please try again.");
                                userInput = Console.ReadLine();
                            }
                        }

                        CatFood catFood = new CatFood() { 
                            Name = catName, Price = catPrice, Quantity = catQuantity, Description = catDescription, 
                            WeightPounds = catWeight, KittenFood = catKitenFood
                        };

                        Console.WriteLine(JsonSerializer.Serialize(catFood));

                        //Console.WriteLine($"Name: {catFood.Name} Price: {catFood.Price} Quantity: {catFood.Quantity}");
                        //Console.WriteLine($"Weight: {catFood.WeightPounds} Kitten Food?: {catFood.KittenFood}");
                        //Console.WriteLine($"Description: {catFood.Description}");
                    }
                }
                else
                {
                    break;
                }
            }
        }
    }
}