using System;
using System.Diagnostics;

namespace PetStoreInventory
{
    public class ProductLogic : IProductLogic
    {
        public ProductLogic()
        {
            AddProduct(new DogLeash { Name = "Leather Leash", Price = 26.99M, Quantity = 5 });
            AddProduct(new DogLeash { Name = "Bedazzled Leash", Price = 26.99M, Quantity = 0 });
            AddProduct(new CatFood { Name = "Num Nums", Price = 3.99M, Quantity = 10 });
        }

        private List<IProduct> _products = new List<IProduct>();
        private Dictionary<string, DogLeash> _dogLeash = new Dictionary<string, DogLeash>();
        private Dictionary<string, CatFood> _catFood = new Dictionary<string, CatFood>();

        public void AddProduct(IProduct product)
        {
            _products.Add(product);

            if (product is DogLeash)
            {
                _dogLeash.Add(product.Name, product as DogLeash);
            }
            if (product is CatFood)
            {
                _catFood.Add(product.Name, product as CatFood);
            }
        }
        public List<IProduct> GetAllProducts()
        {
            return _products;
        }
        public DogLeash GetDogLeashName(string name)
        {
            try
            {
                return _dogLeash[name];
            }
            catch (Exception)
            {
                return null;
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

        public CatFood GetCatFoodName(string name)
        {
            try
            {
                return _catFood[name];
            }
            catch (Exception)
            {
                return null;
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
            /* BELOW IS THE STANDARD FOREACH WAY TO PARSE THIS LIST
             * THE CLEANER WAY TO WRITE IT IS USING THE ARROW
             * METHOD BELOW IT
             * List<string> inStockProductNames = new List<string>();
             * foreach (var prod in _products)
             * {
             *      if (prod.Quantity > 0)
             *      {
             *          inStockProductNames.Add(prod.Name);
             *      }
             * }
             * return inStockProductNames;
             */
            return _products.Where(x => x.Quantity > 0).Select(x => x.Name).ToList();
        }

        public List<string> GetOutOfStockProducts()
        {
            return _products.Where(p => p.Quantity == 0).Select(p => p.Name).ToList();
        }
    }
}