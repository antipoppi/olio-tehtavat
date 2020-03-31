using Microsoft.VisualStudio.TestTools.UnitTesting;
using DemoLaskin;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoLaskin.Tests
{
    [TestClass()]
    public class CalculatorTests
    {
        [TestMethod()]
        public void AddTest()
        {
            // AAA-periaate
            // Arrange
            DemoLaskin.Calculator calc = new Calculator();
            int a = 5;
            int b = 6;
            int expected = 11;

            // Act
            int result = calc.Add(a, b);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void MultiplyTest()
        {
            // Arrange
            DemoLaskin.Calculator calc = new Calculator();
            int a = 5;
            int b = 6;
            int expected = 30;

            // Act
            int result = calc.Multiply(a, b);

            // Assert
            Assert.AreEqual(expected, result);
        }
        [TestMethod()]
        public void AddTest0()
        {
            // AAA-periaate
            // Arrange
            DemoLaskin.Calculator calc = new Calculator();
            int a = 5;
            int b = 0;
            int expected = 5;

            // Act
            int result = calc.Add(a, b);

            // Assert
            Assert.AreEqual(expected, result);
        }
    }
}