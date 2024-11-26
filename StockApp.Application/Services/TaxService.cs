using StockApp.Application.Interfaces;

namespace StockApp.API

{
    public class TaxService : ITaxService
    {
        public decimal CalculateTax(decimal amount)
        {
            const decimal TaxRate = 0.15M; 
            // Implementação do cálculo de impostos (15% neste exemplo)
            return amount * TaxRate;
        }
    }
}