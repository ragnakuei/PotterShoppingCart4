using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingCartLib
{
    public class ShoppingCart
    {
        public decimal CheckOut(List<ShoppingCartItem> shoppingCartItems)
        {
            decimal discount = CalcDiscount(shoppingCartItems);
            return 100 * shoppingCartItems.Sum(item => item.Amount) * (1 - discount);
        }

        // 取得 折扣
        private decimal CalcDiscount(IEnumerable<ShoppingCartItem> shoudPaymentItems)
        {
            decimal discount = 0;
            switch (shoudPaymentItems.Count())
            {
                case 2:
                    discount = 0.05m;
                    break;
                case 3:
                    discount = 0.1m;
                    break;
            }

            return discount;
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