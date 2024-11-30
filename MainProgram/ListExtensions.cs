using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStoreInventory
{
    public static class ListExtensions
    {
        public static List<T> InStock<T>(this List<T> list) where T : Product
        {
            return list.Where(x => x.Quantity > 0).ToList();
        }
        public static List<T> InStockCatFood<T>(this List<T> list) where T : Product
        {
            return list.Where(x => x.ProductType == "Cat Food" && x.Quantity > 0).ToList();
        }
        public static List<T> InStockDogLeash<T>(this List<T> list) where T : Product
        {
            return list.Where(x => x.ProductType == "Dog Leash" && x.Quantity > 0).ToList();
        }
    }
}
