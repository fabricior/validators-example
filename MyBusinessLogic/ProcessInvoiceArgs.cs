using System;

namespace MyBusinessLogic
{    
    public record ProcessInvoiceArgs
    {
        public DateTime? Date { get; init; }
        public decimal? Amount { get; init; }
    }

    public class ValidProcessInvoiceArgs
    {
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
    }
}
