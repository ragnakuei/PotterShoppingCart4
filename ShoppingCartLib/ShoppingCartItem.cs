using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingCartLib
{
    public class ShoppingCart
    {
        private Dictionary<int, decimal> Discounts = new Dictionary<int, decimal>()
        {
            { 1, 0 },
            { 2, 0.05m },
            { 3, 0.1m },
            { 4, 0.2m },
            { 5, 0.25m }
        };

        //  結帳
        public decimal CheckOut(IEnumerable<ShoppingCartItem> shoppingCartItems)
        {
            decimal payment = 0;
            while (GetCountForAmountGreaterEqual1(shoppingCartItems) >= 1)
            {
                decimal discount = 0;
                Discounts.TryGetValue(GetCountForAmountGreaterEqual1(shoppingCartItems), out discount);
                payment += 100 * GetCountForAmountGreaterEqual1(shoppingCartItems) * (1 - discount);
                ItemsAmountMinus1(ref shoppingCartItems);
            }
            return payment;
        }

        // 計算單次折扣金額
        //private decimal CalcSingleDiscountPayment(IEnumerable<ShoppingCartItem> shoppingCartItems)
        //{
        //    decimal discount = 0;
        //    Discounts.TryGetValue(GetCountForAmountGreaterEqual1(shoppingCartItems),out discount);
        //    return 100 * GetCountForAmountGreaterEqual1(shoppingCartItems) * (1 - discount);
        //}

        // 計算 數量大於等於 1 的品項數
        private int GetCountForAmountGreaterEqual1(IEnumerable<ShoppingCartItem> shouldPaymentItems)
        {
            return shouldPaymentItems.Count(item => item.Amount >= 1);
        }

        // 對數量大於等於 1 的品項數量減1
        private void ItemsAmountMinus1(ref IEnumerable<ShoppingCartItem> shouldPaymentItems)
        {
            foreach (var shoppingCartItem in shouldPaymentItems.Where(item => item.Amount >= 1))
            { shoppingCartItem.Amount--; }
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