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
        public List<Product> GetAllProducts();
        public string GetProductName(string name, string type);
        public DogLeash GetDogLeashName(string name);
        public CatFood GetCatFoodName(string name);
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
