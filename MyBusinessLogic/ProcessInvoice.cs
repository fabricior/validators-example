using System;

namespace MyBusinessLogic
{
    public class ProcessInvoice
    {
        public void Process(ValidProcessInvoiceArgs args)
        {
            Console.WriteLine($"Args are valid! {args.Date} {args.Amount}");
        }
    }
}
