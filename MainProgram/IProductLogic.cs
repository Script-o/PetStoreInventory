using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStoreInventory
{
    public interface IProductLogic
    {
        void AddProduct(Product product);

        List<Product> GetAllProducts();

        DogLeash GetDogLeashName(string name);

        List<string> GetOnlyInStockProducts();

        List<string> GetOutOfStockProducts();
    }
}
