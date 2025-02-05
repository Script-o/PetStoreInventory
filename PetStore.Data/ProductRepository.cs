using PetStore.Data.Interfaces;
using PetStoreInventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStore.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductContext _context;

        public ProductRepository(ProductContext context) 
        {
            _context = context;
        }

        public void AddNewProduct(Product product)
        {
            _context.Products.Add(product);
            var dbResult = _context.SaveChanges();
        }

        public Product GetProductById(int productId)
        {
            var productById = _context.Products.Where(p => p.ProductId == productId)
                                                     .FirstOrDefault();

            return productById;
        }

        public List<Product> GetAllProducts()
        {
            List<Product> allProducts = _context.Products.ToList();
            return allProducts;
        }
    }
}
