﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStoreInventory
{
    public interface IProductLogic
    {
        public void AddProduct(IProduct product);

        public List<IProduct> GetAllProducts();

        public DogLeash GetDogLeashName(string name);

        public decimal GetDogLeashPrice(string name);

        public CatFood GetCatFoodName(string name);

        public decimal GetCatFoodPrice(string name);

        public List<string> GetOnlyInStockProducts();

        public List<string> GetOutOfStockProducts();
    }
}
