using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingCartLib
{
    public class ShoppingCart
    {
        public decimal CheckOut(List<ShoppingCartItem> shoppingCartItems)
        { return 100 * shoppingCartItems.Sum(item => item.Amount); }
    }

    public class ShoppingCartItem
    {

        public ShoppingCartItem(int productId, string productName, int amount)
        {
            this.Id = productId;
            this.Name = productName;
            this.Amount = amount;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public int Amount { get; internal set; }
    }
}