using MyCalc2;
namespace StringCalc.Tests
{
    public class PrioirtyTests
    {
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
            Assert.AreEqual(12.5, result);
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