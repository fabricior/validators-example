using System.Collections.Generic;
using System.Linq;

namespace MyBusinessLogic
{
    public record ProcessInvoiceValidatorResult
    {
        public ValidProcessInvoiceArgs? ValidArgs { get; }
        public List<string> Errors { get; }
        
        public ProcessInvoiceValidatorResult(ValidProcessInvoiceArgs validArgs)
        {
            this.ValidArgs = validArgs;
            this.Errors = Enumerable.Empty<string>().ToList();
        }

        public ProcessInvoiceValidatorResult(IEnumerable<string> errors)
        {           
            this.ValidArgs = null;
            this.Errors = errors.ToList();
        }
    }
    public class ProcessInvoiceValidator
    {
        public ProcessInvoiceValidatorResult Validate(ProcessInvoiceArgs rawArgs) 
        {
            var errors = GetErrors(rawArgs);
            if (errors.Any())
            {
                return new ProcessInvoiceValidatorResult(errors);
            }          

            var validArgs = new ValidProcessInvoiceArgs()
            {
                Date = rawArgs.Date!.Value,
                Amount = rawArgs.Amount!.Value,
            };
            
            return new ProcessInvoiceValidatorResult(validArgs);
        }

        private static IEnumerable<string> GetErrors(ProcessInvoiceArgs rawArgs) 
        {
            if (rawArgs.Date == null)
            {
                yield return "Date cannot be null";
            }

            if (rawArgs.Amount == null)
            {
                yield return "Amount cannot be null";
            }
            else if (rawArgs.Amount < 0)
            {
                yield return "Amount cannot be a negative number.";
            }
        }
    }
}
