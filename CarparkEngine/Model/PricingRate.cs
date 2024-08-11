namespace CarparkEngine.Model
{
    // PricingRate object, used in the response of get PricingRates query
    public class PricingRate
    {
        public string? Name { get; set; }
        public string? Type { get; set; }
        public float TotalPrice { get; set; }
        public string? EntryCondition { get; set; }
        public string? ExitCondition { get; set; }
        public string? Note { get; set; }
    }
}
