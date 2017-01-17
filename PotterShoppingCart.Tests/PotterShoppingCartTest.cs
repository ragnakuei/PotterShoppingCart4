﻿using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShoppingCartLib;

namespace PotterShoppingCart.Tests
{
    /// <summary>
    /// PotterShoppingCartTest 的摘要描述
    /// </summary>
    [TestClass]
    public class ShoppingCartForPotterTest
    {
        [TestMethod]
        public void Payment_第1集買一本_應為100()
        {
            // arrange
            var target = new ShoppingCart();
            var shoppingCartItems = new List<ShoppingCartItem> {
                new ShoppingCartItem(1,"哈利波特第一集",1)
            };

            // act:結帳
            decimal actual = target.CheckOut(shoppingCartItems);

            // assert
            decimal expected = 100;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Payment_第1_2集各買一本_應為190()
        {
            // arrange
            var target = new ShoppingCart();
            var shoppingCartItems = new List<ShoppingCartItem> {
                new ShoppingCartItem(1,"哈利波特第一集",1),
                new ShoppingCartItem(2,"哈利波特第二集",1)
            };

            // act:結帳
            decimal actual = target.CheckOut(shoppingCartItems);

            // assert
            decimal expected = 190;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Payment_第1_2_3集各買一本_應為270()
        {
            // arrange
            var target = new ShoppingCart();
            var shoppingCartItems = new List<ShoppingCartItem> {
                new ShoppingCartItem(1,"哈利波特第一集",1),
                new ShoppingCartItem(2,"哈利波特第二集",1),
                new ShoppingCartItem(3,"哈利波特第三集",1)
            };

            // act:結帳
            decimal actual = target.CheckOut(shoppingCartItems);

            // assert
            decimal expected = 270;
            Assert.AreEqual(expected, actual);
        }
    }
}
