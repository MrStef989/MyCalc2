
using Microsoft.VisualStudio.TestTools.UnitTesting; 
using System;
using MyCalc2;
namespace CalculatorApp.Tests
{
    [TestClass]
    public class BasicTests
    {
        private Calculator calculator;

        [TestInitialize]
        public void Setup()
        {
            calculator = new Calculator();
        }

        [TestMethod]
        public void Calculate_Addition_ReturnsCorrectResult()
        {
            string expression = "5 + 3";

            double result = calculator.Calculate(expression);

            Assert.AreEqual(8, result, "5 + 3 должно быть 8");
        }

        [TestMethod]
        public void Calculate_Subtraction_ReturnsCorrectResult()
        {
            string expression = "10 - 4";

            double result = calculator.Calculate(expression);

            Assert.AreEqual(6, result, "10 - 4 должно быть 6");
        }

        [TestMethod]
        public void Calculate_Multiplication_ReturnsCorrectResult()
        {
            string expression = "7 * 6";

            double result = calculator.Calculate(expression);

            Assert.AreEqual(42, result, "7 * 6 должно быть 42");
        }

        [TestMethod]
        public void Calculate_Division_ReturnsCorrectResult()
        {
            string expression = "20 / 4";

            double result = calculator.Calculate(expression);

            Assert.AreEqual(5, result, "20 / 4 должно быть 5");
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void Calculate_DivisionByZero_ThrowsDivideByZeroException()
        {
            // Arrange
            string expression = "10 / 0";

            // Act
            calculator.Calculate(expression);

            // Assert: Ожидается исключение, поэтому Assert не нужен
        }

    }
}
