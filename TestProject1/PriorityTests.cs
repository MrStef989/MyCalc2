using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MyCalc2;
namespace CalculatorApp.Tests
{
    [TestClass]
    public class PrioirtyTests

    {
        private Calculator calculator;

        [TestInitialize]
        public void Setup()
        {
            calculator = new Calculator();
        }
        [TestMethod]
        public void Should_RespectPrecedenceOfOperations()
        {
            var calculator = new Calculator();

            var result = calculator.Calculate("2 + 3 * 4");
            Assert.AreEqual(14, result);
        }
        [TestMethod]
        public void Should_RespectDivision()
        {
            var calculator = new Calculator();

            var result = calculator.Calculate("10 - 6 / 2");
            Assert.AreEqual(7, result);
        }
        [TestMethod]
        public void HandleMultipleOperations()
        {
            var calculator = new Calculator();

            var result = calculator.Calculate("2 + 3 * 4 - 5 / 2");
            Assert.AreEqual(11.5, result);
        }
        [TestMethod]
        public void WithParentheses()
        {
            var calculator = new Calculator();

            var result = calculator.Calculate("(2 + 3) * 4");
            Assert.AreEqual(20, result);
        }
        [TestMethod]
        public void Should_HandleNestedParentheses()
        {
            var calculator = new Calculator();

            var result = calculator.Calculate("2 * (3 + (4 - 1))");
            Assert.AreEqual(12, result);
        }
    }
}