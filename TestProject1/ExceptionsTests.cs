using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MyCalc2;

namespace CalculatorApp.Tests
{
    [TestClass]
    public class ExceptionsTests
    {
        private Calculator calculator;

        [TestInitialize]
        public void Setup()
        {
            calculator = new Calculator();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void InvalidExpression()
        {
            calculator.Calculate("2 + + 3");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void UnbalancedParentheses()
        {
            calculator.Calculate("(2 + 3 * 4");
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void DivisionByZero()
        {
            calculator.Calculate("10 / 0");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Should_ThrowException_For_EmptyExpression()
        {
            calculator.Calculate("");
        }


        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void UnsupportedOperation()
        {
            calculator.Calculate("2 ^ 3");
        }
    }
}
