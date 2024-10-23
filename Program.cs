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
                        string catPriceString = Console.ReadLine();
                        decimal catPrice = decimal.Parse(catPriceString);
                        Console.WriteLine("What is the quantity of the Cat Food?");
                        string catQuantityString = Console.ReadLine();
                        int catQuantity = Int32.Parse(catQuantityString);
                        Console.WriteLine("What is the description of the Cat Food?");
                        string catDescription = Console.ReadLine();
                        Console.WriteLine("What is the weight of the Cat Food?");
                        string catWeightString = Console.ReadLine();
                        int catWeight = Int32.Parse(catWeightString);
                        Console.WriteLine("Is this kitten food?");
                        Console.WriteLine("true or false");
                        string catKitenFoodString = Console.ReadLine();
                        bool catKitenFood = bool.Parse(catKitenFoodString);

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