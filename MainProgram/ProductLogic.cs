using FluentValidation;
using PetStoreInventory;
using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Reflection;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace PetStoreInventory
{
    public class ProductLogic : IProductLogic
    {
        public ProductLogic()
        {
            AddProduct(new DogLeash { Name = "Leather Leash", Price = 26.99M, Quantity = 5, ProductType = "Dog Leash" });
            AddProduct(new DogLeash { Name = "Bedazzled Leash", Price = 26.99M, Quantity = 0, ProductType = "Dog Leash" });
            AddProduct(new CatFood { Name = "Num Nums", Price = 3.99M, Quantity = 10, ProductType = "Cat Food" });
        }

        private List<Product> _products = new List<Product>();

        private Dictionary<string, DogLeash> _dogLeash = new Dictionary<string, DogLeash>();
        private Dictionary<string, CatFood> _catFood = new Dictionary<string, CatFood>();

        private ProductValidator dogLeashValidator = new ProductValidator();

        public void AddProduct(Product product)
        {
            var validatorResult = dogLeashValidator.Validate(product);
            if (!validatorResult.IsValid)
            {
                Console.WriteLine("Error in JSON: " + validatorResult + "\n");
                return;
            }
            _products.Add(product);

            if (product is DogLeash)
            {
                _dogLeash.Add(product.Name, product as DogLeash);
                Console.WriteLine($"{product.Name} has been added.\n");
            }
            if (product is CatFood)
            {
                _catFood.Add(product.Name, product as CatFood);
                Console.WriteLine($"{product.Name} has been added.\n");
            }
        }
        public List<Product> GetAllProductsAsJSON()
        {
            return _products;
        }

        public string GetProductName<T>(string name) where T : Product
        {
            try
            {
                if (typeof(T) == typeof(DogLeash))
                {
                    return _dogLeash[name].Name;
                }
                else if (typeof(T) == typeof(CatFood))
                {
                    return _catFood[name].Name;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Product JsonValidationCheck(string input)
        {
            try
            {
                return JsonSerializer.Deserialize<Product>(input);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public decimal GetProductPrice(string name, string type)
        {

            if (type == "dog")
            {
                return GetDogLeashPrice(name);
            }
            if (type == "cat")
            {
                return GetCatFoodPrice(name);
            }
            else
            {
                return 0;
            }
        }

        public decimal GetDogLeashPrice(string name)
        {
            try
            {
                return _dogLeash[name].Price;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public decimal GetCatFoodPrice(string name)
        {
            try
            {
                return _catFood[name].Price;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public List<string> GetOnlyInStockProducts()
        {
            return _products.InStock().Select(x => x.Name).ToList();
        }
        public List<string> GetOnlyInStockCatFood()
        {
            return _products.InStockCatFood().Select(x => x.Name).ToList();
        }
        public List<string> GetOnlyInStockDogLeash()
        {
            return _products.InStockDogLeash().Select(x => x.Name).ToList();
        }

        public List<string> GetOutOfStockProducts()
        {
            return _products.Where(p => p.Quantity == 0).Select(p => p.Name).ToList();
        }

        public decimal GetTotalPriceOfInventory()
        {
            return _products.InStock().Select(x => x.Price * x.Quantity).Sum();
        }
    }
}