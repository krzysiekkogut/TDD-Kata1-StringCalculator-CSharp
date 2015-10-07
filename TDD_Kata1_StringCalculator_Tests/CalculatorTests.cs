using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TDD_Kata1_StringCalculator;

namespace TDD_Kata1_StringCalculator_Tests
{
    [TestClass]
    public class CalculatorTests
    {
        [TestMethod]
        public void Add_EmptyString()
        {
            var calc = new Calculator();

            Assert.AreEqual(0, calc.Add(string.Empty));
        }

        [TestMethod]
        public void Add_OneNumber()
        {
            var calc = new Calculator();

            Assert.AreEqual(5, calc.Add("5"));
        }

        [TestMethod]
        public void Add_StringWithTwoNumbersWithCommaBetween()
        {
            var calc = new Calculator();

            Assert.AreEqual(16, calc.Add("11,5"));
        }

        [TestMethod]
        public void Add_FiveNumbers()
        {
            var calc = new Calculator();

            Assert.AreEqual(152, calc.Add("7,13,9,0,123"));
        }

        [TestMethod]
        public void Add_NewLineBetween()
        {
            var calc = new Calculator();

            Assert.AreEqual(6, calc.Add("1,2\n3"));
        }

        [TestMethod]
        public void Add_SpecifiedDelimiter()
        {
            var calc = new Calculator();

            Assert.AreEqual(6, calc.Add("//;\n1;2;3"));
        }

        [TestMethod]
        [ExpectedException(typeof(NegativesNotAllowedException))]
        public void Add_NegativesNotSupportedOneNegative()
        {
            try
            {
                new Calculator().Add("-5,2");
            }
            catch (NegativesNotAllowedException ex)
            {
                Assert.AreEqual(-5, ex.Negatives[0]);
                throw ex;
            }
        }

        [TestMethod]
        [ExpectedException(typeof(NegativesNotAllowedException))]
        public void Add_NegativesNotSupportedTwoNegatives()
        {
            try
            {
                new Calculator().Add("//;\n-5;2;6;-10");
            }
            catch (NegativesNotAllowedException ex)
            {
                Assert.AreEqual(-5, ex.Negatives[0]);
                Assert.AreEqual(-10, ex.Negatives[1]);
                throw ex;
            }
        }

        [TestMethod]
        public void Add_IgnoreBiggerThanThousand()
        {
            var calc = new Calculator();

            Assert.AreEqual(2, calc.Add("2,1001"));
        }

        [TestMethod]
        public void Add_StringDelimeters()
        {
            var calc = new Calculator();

            Assert.AreEqual(6, calc.Add("//[***]\n1***2***3"));
        }

        [TestMethod]
        public void Add_MultipleStringDelimeters()
        {
            var calc = new Calculator();

            Assert.AreEqual(6, calc.Add("//[%][***]\n1%2***3"));
        }
    }
}
