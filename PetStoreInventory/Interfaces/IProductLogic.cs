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
        public Product GetProductById(int id);
        public List<Product> GetAllProducts();
    }
}
