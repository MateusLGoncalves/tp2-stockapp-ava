public interface IDiscountService
{
    decimal ApplyDiscount(decimal price, decimal discountPercentage);
}