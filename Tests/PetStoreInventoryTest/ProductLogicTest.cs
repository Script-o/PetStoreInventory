using PetStoreInventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PetStoreInventoryTest
{
    [TestClass]
    public class ProductLogicTest
    {
        [TestMethod]
        public void GetProductNameTest()
        {
            //-- Arrange
            IProductLogic productLogic = new ProductLogic();
            DogLeash expected = new DogLeash { Name = "Leather Leash", Price = 26.99M, Quantity = 5 };
            //-- Act
            var actual = productLogic.GetProductName<DogLeash>("Leather Leash");
            //-- Assert
            Assert.AreEqual(expected.Name, actual);
        }

        [TestMethod]
        public void GetDogLeashPriceTest()
        {
            //-- Arrange
            IProductLogic productLogic = new ProductLogic();
            DogLeash expected = new DogLeash { Name = "Leather Leash", Price = 26.99M, Quantity = 5 };
            //-- Act
            var actual = productLogic.GetDogLeashPrice("Leather Leash");
            //-- Assert
            Assert.AreEqual(expected.Price, actual);
        }
    }
}
