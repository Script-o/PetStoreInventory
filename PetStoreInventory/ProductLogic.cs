using FluentValidation;
using PetStore.Data;
using PetStore.Data.Interfaces;
using PetStoreInventory;
using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Reflection;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace PetStoreInventory
{
    internal class ProductLogic : IProductLogic
    {
        private readonly ProductRepository _productRepository;

        public ProductLogic(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public void AddProduct(Product product)
        {
            _productRepository.AddNewProduct(product);
        }

        public Product GetProductById(int id)
        {
            return _productRepository.GetProductById(id);
        }

        public List<Product> GetAllProducts()
        {
            return _productRepository.GetAllProducts();
        }
    }
}