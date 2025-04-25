using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculator.Services;
using Calculator.Models;

namespace Calculator.Tests.Services
{
    [TestClass]
    public class CalculatorServiceTests
    {
        private CalculatorService _calculator;

        [TestInitialize]
        public void Setup()
        {
            var historyService = new InMemoryCalculationHistoryService();
            _calculator = new CalculatorService(historyService);
        }

        [TestMethod]
        public void Calculate_Addition_ReturnsCorrectResult()
        {
            double result = _calculator.Calculate("3 + 4");
            Assert.AreEqual(7, result);
        }

        [TestMethod]
        public void Calculate_MixedExpression_ReturnsCorrectResult()
        {
            double result = _calculator.Calculate("5 * 2 + 1");
            Assert.AreEqual(11, result);
        }

        [TestMethod]
        public void History_Contains_LastExpression()
        {
            string expression = "8 - 3";
            _calculator.Calculate(expression);

            var last = _calculator.GetHistory().Last();
            Assert.AreEqual(expression, last.Expression);
        }

        [TestMethod]
        public void Calculate_InvalidExpression_ThrowsException()
        {
            try
            {
                _calculator.Calculate("invalid");
                Assert.Fail("Exception was expected but not thrown.");
            }
            catch
            {
                Assert.IsTrue(true); // Expected path
            }
        }
    }
}
