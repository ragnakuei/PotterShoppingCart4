using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingCartLib
{
    public class ShoppingCart
    {
        public decimal CheckOut(List<ShoppingCartItem> shoppingCartItems)
        {
            decimal discount = 0;
            if (shoppingCartItems.Count() == 2)
            { discount = 0.05m; }

            return 100 * shoppingCartItems.Sum(item => item.Amount) * (1 - discount);
        }
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