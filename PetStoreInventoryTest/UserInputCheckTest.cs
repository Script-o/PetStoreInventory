using PetStoreInventory;

namespace PetStoreInventoryTest
{
    [TestClass]
    public class UserInputCheckTest
    {
        [TestMethod]
        public void IntegerCheckValid()
        {
            //-- Arrange
            int expected = 10;
            //-- Act
            int actual = UserInputCheck.IntegerCheck("10");
            //-- Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DecimalCheckValid()
        {
            //-- Arrange
            decimal expected = 10.56M;
            //-- Act
            decimal actual = UserInputCheck.DecimalCheck("10.56");
            //-- Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void BoolCheckValid()
        {
            //-- Arrange
            bool expected = true;
            //-- Act
            bool actual = UserInputCheck.BoolCheck("true");
            //-- Assert
            Assert.AreEqual(expected, actual);
        }
    }
}