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
            var userInputCheck = new UserInputCheck();
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
            var userInputCheck = new UserInputCheck();
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
            var userInputCheck = new UserInputCheck();
            bool expected = true;
            //-- Act
            bool actual = UserInputCheck.BoolCheck("true");
            //-- Assert
            Assert.AreEqual(expected, actual);
        }
    }

}