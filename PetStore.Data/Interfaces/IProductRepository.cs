using PetStoreInventory;

namespace PetStore.Data.Interfaces
{
    public interface IProductRepository
    {
        public void AddNewProduct(Product product);
        public Product GetProductById(int productId);
        public List<Product> GetAllProducts();
    }
}