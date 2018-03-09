using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fizzbuzz;
namespace FizzBuzz.Tests
{
    [TestClass]
    public class FizzBuzzDivisibleTests
    {
        [TestMethod]
        public void FizzBuzzDivisible_5()
        {
            var stringwriter = new FizzBuzzDivisible();
            Assert.AreEqual(stringwriter.GetString(10), "Buzz");
        }

        [TestMethod]
        public void FizzBuzzDivisible_6()
        {
            var stringwriter = new FizzBuzzDivisible();
            Assert.AreEqual(stringwriter.GetString(6), "Fizz");
        }

        [TestMethod]
        public void FizzBuzzDivisible_12()
        {
            var stringwriter = new FizzBuzzDivisible();
            Assert.AreEqual(stringwriter.GetString(12), "Fizz");
        }

        [TestMethod]
        public void FizzBuzzDivisible_13()
        {
            var stringwriter = new FizzBuzzDivisible();
            Assert.AreEqual(stringwriter.GetString(13), "13");
        }

        [TestMethod]
        public void FizzBuzzDivisible_14()
        {
            var stringwriter = new FizzBuzzDivisible();
            Assert.AreEqual(stringwriter.GetString(14), "14");
        }

        [TestMethod]
        public void FizzBuzzDivisible_15()
        {
            var stringwriter = new FizzBuzzDivisible();
            Assert.AreEqual(stringwriter.GetString(15), "FizzBuzz");
        }
    }


    [TestClass]
    public class FizzBuzzBoomBangCrashDivisibleTests
    {
        [TestMethod]
        public void FizzBuzzDivisible_12()
        {
            var stringwriter = new FizzBuzzBoomBangCrashDivisible();
            Assert.AreEqual(stringwriter.GetString(28), "Boom");
        }

        [TestMethod]
        public void FizzBuzzDivisible_13()
        {
            var stringwriter = new FizzBuzzBoomBangCrashDivisible();
            Assert.AreEqual(stringwriter.GetString(33), "FizzBang");
        }

        [TestMethod]
        public void FizzBuzzDivisible_14()
        {
            var stringwriter = new FizzBuzzBoomBangCrashDivisible();
            Assert.AreEqual(stringwriter.GetString(65), "BuzzCrash");
        }

        [TestMethod]
        public void FizzBuzzDivisible_15()
        {
            var stringwriter = new FizzBuzzBoomBangCrashDivisible();
            Assert.AreEqual(stringwriter.GetString(64), "64");
        }
    }


    [TestClass]
    public class FizzBuzzDigitsTests
    {
        [TestMethod]
        public void FizzBuzzDivisible_13()
        {
            var stringwriter = new FizzBuzzDigits();
            Assert.AreEqual(stringwriter.GetString(13), "Fizz");
        }

        [TestMethod]
        public void FizzBuzzDivisible_51()
        {
            var stringwriter = new FizzBuzzDigits();
            Assert.AreEqual(stringwriter.GetString(51), "Buzz");
        }

        [TestMethod]
        public void FizzBuzzDivisible_365()
        {
            var stringwriter = new FizzBuzzDigits();
            Assert.AreEqual(stringwriter.GetString(365), "FizzBuzz");
        }

        [TestMethod]
        public void FizzBuzzDivisible_532()
        {
            var stringwriter = new FizzBuzzDigits();
            Assert.AreEqual(stringwriter.GetString(532), "BuzzFizz");
        }

        [TestMethod]
        public void FizzBuzzDivisible_315395()
        {
            var stringwriter = new FizzBuzzDigits();
            Assert.AreEqual(stringwriter.GetString(315395), "FizzBuzzFizzBuzz");
        }


        [TestMethod]
        public void FizzBuzzDivisible_91()
        {
            var stringwriter = new FizzBuzzDigits();
            Assert.AreEqual(stringwriter.GetString(91), "91");
        }
    }

    [TestClass]
    public class FizzBuzzDivisibleOrDigitsTests
    {
        [TestMethod]
        public void FizzBuzzDivisibleOrDigits_10()
        {
            var stringwriter = new FizzBuzzDivisibleOrDigits();
            Assert.AreEqual(stringwriter.GetString(10), "Buzz");
        }
        [TestMethod]
        public void FizzBuzzDivisibleOrDigits_12()
        {
            var stringwriter = new FizzBuzzDivisibleOrDigits();
            Assert.AreEqual(stringwriter.GetString(12), "Fizz");
        }

        [TestMethod]
        public void FizzBuzzDivisibleOrDigits_13()
        {
            var stringwriter = new FizzBuzzDivisibleOrDigits();
            Assert.AreEqual(stringwriter.GetString(13), "Fizz");
        }

        [TestMethod]
        public void FizzBuzzDivisibleOrDigits_53()
        {
            var stringwriter = new FizzBuzzDivisibleOrDigits();
            Assert.AreEqual(stringwriter.GetString(53), "BuzzFizz");
        }

        [TestMethod]
        public void FizzBuzzDivisibleOrDigits_30()
        {
            var stringwriter = new FizzBuzzDivisibleOrDigits();
            Assert.AreEqual(stringwriter.GetString(30), "FizzBuzzFizz");
        }

        [TestMethod]
        public void FizzBuzzDivisibleOrDigits_51435()
        {
            var stringwriter = new FizzBuzzDivisibleOrDigits();
            Assert.AreEqual(stringwriter.GetString(51435), "FizzBuzzBuzzFizzBuzz");
        }

        [TestMethod]
        public void FizzBuzzDivisibleOrDigits_92()
        {
            var stringwriter = new FizzBuzzDivisibleOrDigits();
            Assert.AreEqual(stringwriter.GetString(92), "92");
        }
    }

}
