using Microsoft.AspNetCore.Mvc;
using StockApp.Application.Interfaces;

namespace StockApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountService _discountService;

        public DiscountController(IDiscountService discountService)
        {
            _discountService = discountService;
        }

        /// <summary>
        /// Aplica um desconto a um preço fornecido.
        /// </summary>
        /// <param name="price">Preço original.</param>
        /// <param name="discountPercentage">Percentual de desconto.</param>
        /// <returns>Preço com o desconto aplicado.</returns>
        [HttpGet("apply")]
        public IActionResult ApplyDiscount(decimal price, decimal discountPercentage)
        {
            if (price <= 0)
            {
                return BadRequest("O preço deve ser maior que zero.");
            }

            if (discountPercentage < 0 || discountPercentage > 100)
            {
                return BadRequest("O percentual de desconto deve estar entre 0 e 100.");
            }

            var discountedPrice = _discountService.ApplyDiscount(price, discountPercentage);
            return Ok(new
            {
                OriginalPrice = price,
                DiscountPercentage = discountPercentage,
                DiscountedPrice = discountedPrice
            });
        }
    }
}