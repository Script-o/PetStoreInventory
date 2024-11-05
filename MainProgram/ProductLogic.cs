﻿using System;
using System.Diagnostics;

namespace PetStoreInventory
{
	public class ProductLogic : IProductLogic
	{
		public ProductLogic()
		{
            AddProduct(new DogLeash { Name = "Leather Leash", Price = 26.99M, Quantity = 5 });
            AddProduct(new DogLeash { Name = "Bedazzled Leash", Price = 26.99M, Quantity = 0 });
        }

        private List<Product> _products = new List<Product>();
		private Dictionary<string, DogLeash> _dogLeash = new Dictionary<string, DogLeash>();
        private Dictionary<string, CatFood> _catFood = new Dictionary<string, CatFood>();

        public void AddProduct(Product product)
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
		public List<Product> GetAllProducts()
		{
			return _products;
		}
		public DogLeash GetDogLeashName(string name)
		{
			try
			{
                return _dogLeash[name];
            }
			catch (Exception ex)
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
            catch (Exception ex)
            {
                return 0;
            }
        }

        public List<string> GetOnlyInStockProducts()
        {
			List<string> inStockProductNames = new List<string>();
			foreach (var prod in _products)
			{
				if (prod.Quantity > 0)
				{
					inStockProductNames.Add(prod.Name);
				}
			}
			return inStockProductNames;
        }

        public List<string> GetOutOfStockProducts()
        {
            return _products.Where(p => p.Quantity == 0).Select(p => p.Name).ToList();
        }
    }
}