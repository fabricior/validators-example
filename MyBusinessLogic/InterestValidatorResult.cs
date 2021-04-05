using System.Collections.Generic;
using System.Linq;

namespace MyBusinessLogic
{
    public record InterestValidatorResult
    {
        public ValidInterestArgs? ValidArgs { get; }
        public List<string> Errors { get; }

        public InterestValidatorResult(ValidInterestArgs validArgs)
        {
            this.ValidArgs = validArgs;
            this.Errors = Enumerable.Empty<string>().ToList();
        }

        public InterestValidatorResult(IEnumerable<string> errors)
        {
            this.ValidArgs = null;
            this.Errors = errors.ToList();
        }
    } 
}
