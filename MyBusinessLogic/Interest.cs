namespace MyBusinessLogic
{
    public class Interest
    {
        public decimal Calculate(ValidInterestArgs args)
        {
            return args.Principal * args.Rate * args.PeriodInYears / 100;
        }
    }
}
