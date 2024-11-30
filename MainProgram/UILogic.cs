using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PetStoreInventory
{
    public class UILogic :IUILogic
    {
        public Product AddProductMenu()
        {
            Console.WriteLine("\nDo you want to add Cat Food or Dog Leash?");
            Console.WriteLine("Type 'cat' or 'dog'");
            string userInput = Console.ReadLine() ?? "";

            if (userInput.ToLower() == "cat" || userInput.ToLower() == "dog")
            {
                string productType = "";
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

                    Product product = new CatFood()
                    {
                        Name = ProductName,
                        Price = ProductPrice,
                        Quantity = ProductQuantity,
                        Description = ProductDescription,
                        WeightPounds = ProductWeightPounds,
                        KittenFood = ProductKittenFood,
                        ProductType = "Cat Food"
                    };

                    return product;
                }
                if (productType == "dog")
                {
                    Console.WriteLine($"What is the length of the {ProductName}?");
                    userInput = Console.ReadLine() ?? "";
                    int ProductLength = UserInputCheck.IntegerCheck(userInput);

                    Console.WriteLine($"What material is the {ProductName} made of?");
                    string ProductMaterial = Console.ReadLine() ?? "";

                    Product product = new DogLeash()
                    {
                        Name = ProductName,
                        Price = ProductPrice,
                        Quantity = ProductQuantity,
                        Description = ProductDescription,
                        LengthInches = ProductLength,
                        Material = ProductMaterial,
                        ProductType = "Dog Leash"
                    };

                    return product;
                }
            }
            else
            {
                Console.WriteLine("Sorry, that doesn't appear to be a vaild command. You must enter 'cat or 'dog'.");
            }
            return null;
        }
        public void ViewProductMenu(IProductLogic productLogic)
        {
            Console.WriteLine("Do you want to view a Cat Food or a Dog Leash?");
            Console.WriteLine("Enter \"cat\" or \"dog\"");
            var productType = Console.ReadLine() ?? "";
            if (productType.ToLower() == "cat")
            {
                Console.WriteLine("Enter the name of the Cat Food you want to view.");
                Console.WriteLine(JsonSerializer.Serialize(productLogic.GetOnlyInStockCatFood()));
            }
            if (productType.ToLower() == "dog")
            {
                Console.WriteLine("Enter the name of the Dog Leash you want to view.");
                Console.WriteLine(JsonSerializer.Serialize(productLogic.GetOnlyInStockDogLeash()));
            }
            if (productType.ToLower() == "cat" || productType.ToLower() == "dog")
            {
                var input = Console.ReadLine() ?? "";
                var product = productLogic.GetProductName(input, productType);
                var discount = productLogic.GetProductPrice(input, productType);
                if (product == null)
                {
                    Console.WriteLine("Sorry, that product doesn't exist.");
                }
                else
                {
                    Console.WriteLine(product);
                    Console.WriteLine($"Discounted Price= {discount.DiscountThisPrice()}");
                }
            }
            else
            {
                Console.WriteLine("Sorry, you must enter either \"cat\" or \"dog\".");
            }

        }
    }
}
