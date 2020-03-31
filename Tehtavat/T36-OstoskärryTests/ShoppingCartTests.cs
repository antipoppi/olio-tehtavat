using Microsoft.VisualStudio.TestTools.UnitTesting;
using T36_Ostoskärry;
using System;
using System.Collections.Generic;
using System.Text;

namespace T36_Ostoskärry.Tests
{
    [TestClass()]
    public class ShoppingCartTests
    {
        [TestMethod()]
        public void ShoppingCartTest_0item()
        {
            // assign
            ShoppingCart cart = new ShoppingCart();
            int expected = 0;
            // act
            int actual = cart.Cart.Count;
            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ShoppingCartTest_1item()
        {
            // assign
            ShoppingCart cart = new ShoppingCart();
            cart.Cart.Add(new Product("item", 1.0));
            int expected = 1;
            // act
            int actual = cart.Cart.Count;
            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ShoppingCartTest_2item()
        {
            // assign
            ShoppingCart cart = new ShoppingCart();
            cart.Cart.Add(new Product("item", 1.0));
            cart.Cart.Add(new Product("item", 1.0));
            int expected = 2;
            // act
            int actual = cart.Cart.Count;
            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ShoppingCartTest_5item()
        {
            // assign
            ShoppingCart cart = new ShoppingCart();
            cart.Cart.Add(new Product("item1", 1.0));
            cart.Cart.Add(new Product("item2", 1.0));
            cart.Cart.Add(new Product("item3", 1.0));
            cart.Cart.Add(new Product("item4", 1.0));
            cart.Cart.Add(new Product("item5", 1.0));
            int expected = 5;
            // act
            int actual = cart.Cart.Count;
            // assert
            Assert.AreEqual(expected, actual);
        }
    }
}