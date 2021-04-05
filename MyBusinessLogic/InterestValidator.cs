using System.Collections.Generic;
using System.Linq;

namespace MyBusinessLogic
{
    public class InterestValidator
    {
        public InterestValidatorResult Validate(InterestArgs rawArgs) 
        {
            var errors = GetErrors(rawArgs);
            if (errors.Any())
            {
                return new InterestValidatorResult(errors);
            }          

            var validArgs = new ValidInterestArgs()
            {
                Principal = rawArgs.Principal!.Value,
                Rate = rawArgs.Rate!.Value,
                PeriodInYears = rawArgs.PeriodInYears!.Value,
            };
            
            return new InterestValidatorResult(validArgs);
        }

        private static IEnumerable<string> GetErrors(InterestArgs rawArgs)
        {
            if (rawArgs.Principal == null)
            {
                yield return "Principal cannot be null";
            }
            else if (rawArgs.Principal <= 0)
            {
                yield return "Principal must be greater than zero.";
            }

            if (rawArgs.Rate == null)
            {
                yield return "Rate cannot be null";
            }
            else if (rawArgs.Rate <= 0)
            {
                yield return "Rate must be greater than zero.";
            }

            if (rawArgs.PeriodInYears == null)
            {
                yield return "PeriodInYears cannot be null";
            }
            else if (rawArgs.PeriodInYears <= 0)
            {
                yield return "PeriodInYears must be greater than zero.";
            }
        }
    }
}
