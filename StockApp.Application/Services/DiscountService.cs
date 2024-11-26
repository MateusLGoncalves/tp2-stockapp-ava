﻿public class DiscountService : IDiscountService
{
    public decimal ApplyDiscount(decimal price, decimal discountPercentage)
    {
        return price - (price * discountPercentage / 100);
    }
}