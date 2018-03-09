using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fizzbuzz;

namespace FizzBuzz.Tests
{
    [TestClass]
    public class ExtensionMethodTests
    {
        [TestMethod]
        public void TestDivisibleByAll_15_3_5()
        {
            Assert.IsTrue(15.IsDivisibleByAll(15, 3, 5));
        }

        [TestMethod]
        public void TestDivisibleByAll_15_2_5()
        {
            Assert.IsFalse(15.IsDivisibleByAll(15, 2, 5));
        }

        [TestMethod]
        public void TestDivisibleByAll_15_5_3()
        {
            Assert.IsTrue(15.IsDivisibleByAll(15, 5, 3));
        }

        [TestMethod]
        public void TestDivisibleByAll_15_5_2()
        {
            Assert.IsFalse(15.IsDivisibleByAll(15, 5, 2));
        }

        [TestMethod]
        public void TestBanana()
        {
            Assert.AreEqual(1234.ConvertDigitsToString(true, new DigitString() { Digit = 2, String= "Banana" }), "Banana");
        }

        [TestMethod]
        public void TestBananaBanana()
        {
            Assert.AreEqual(12342.ConvertDigitsToString(true, new DigitString() { Digit = 2,String = "Banana" }), "BananaBanana");
        }

        [TestMethod]
        public void TestBananaPineappleBanana()
        {
            Assert.AreEqual(12342.ConvertDigitsToString(true, 
                new DigitString() { Digit = 2, String = "Banana" },
                new DigitString() { Digit = 3, String = "Pineapple" }
            ), "BananaPineappleBanana");
        }
    }
}
