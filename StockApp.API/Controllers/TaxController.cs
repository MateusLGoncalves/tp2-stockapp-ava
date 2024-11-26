using Microsoft.AspNetCore.Mvc;
using StockApp.Application.Interfaces;

namespace StockApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaxController : ControllerBase
    {
        private readonly ITaxService _taxService;

        public TaxController(ITaxService taxService)
        {
            _taxService = taxService;
        }

        // Endpoint para calcular o imposto
        [HttpGet("calculate")]
        public IActionResult Calculate(decimal amount)
        {
            if (amount < 0)
            {
                return BadRequest("O valor não pode ser negativo.");
            }

            var tax = _taxService.CalculateTax(amount);
            return Ok(new
            {
                Amount = amount,
                Tax = tax,
                Total = amount + tax
            });
        }
    }
}