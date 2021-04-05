namespace MyBusinessLogic
{    
    public record InterestArgs
    {
        public decimal? Principal { get; init; }
        public decimal? Rate { get; init; }
        public int? PeriodInYears { get; init; }
    }

    public record ValidInterestArgs
    {      
        public decimal Principal { get; init; }
        public decimal Rate { get; init; }
        public int PeriodInYears { get; init; }
    }
}
