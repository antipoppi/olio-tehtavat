using Microsoft.VisualStudio.TestTools.UnitTesting;
using T35_Laskutoimituksia;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace T35_Laskutoimituksia.Tests
{
    [TestClass()]
    public class ArrayCalcsTests
    {
        [TestMethod()]
        public void SumTest()
        {
            // arrange
            double[] taulukko = { 1.0, 2.0, 3.3, 5.5, 6.3, -4.5, 12.0 };
            double expected = 25.6;
            // act
            double actual = ArrayCalcs.Sum(taulukko);
            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void AverageTest()
        {
            // arrange
            double[] taulukko = { 1.0, 2.0, 3.3, 5.5, 6.3, -4.5, 12.0 };
            double expected = 3.7;
            // act
            double actual = ArrayCalcs.Average(taulukko);
            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void MinTest()
        {
            // arrange
            double[] taulukko = { 1.0, 2.0, 3.3, 5.5, 6.3, -4.5, 12.0 };
            double expected = -4.5;
            // act
            double actual = ArrayCalcs.Min(taulukko);
            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void MaxTest()
        {
            // arrange
            double[] taulukko = { 1.0, 2.0, 3.3, 5.5, 6.3, -4.5, 12.0 };
            double expected = 12.0;
            // act
            double actual = ArrayCalcs.Max(taulukko);
            // assert
            Assert.AreEqual(expected, actual);
        }
    }
}