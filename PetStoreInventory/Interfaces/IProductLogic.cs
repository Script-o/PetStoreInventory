using PetStoreInventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStoreInventory
{
    public interface IProductLogic
    {
        public void AddProduct(Product product);
        public List<Product> GetAllProductsAsJSON();
        public string GetProductName<T>(string name) where T : Product;
        public Product JsonValidationCheck(string input);
        public decimal GetProductPrice(string name, string type);
        public decimal GetDogLeashPrice(string name);
        public decimal GetCatFoodPrice(string name);
        public List<string> GetOnlyInStockProducts();
        public List<string> GetOnlyInStockCatFood();
        public List<string> GetOnlyInStockDogLeash();
        public List<string> GetOutOfStockProducts();
        public decimal GetTotalPriceOfInventory();
    }
}
