using CarparkEngine.Model;

namespace CarparkEngine.API
{
    // Query API, used for Read operation
    public class Query
    {
        // Instruction Query returns instructions how to explore and use the Carpark Engine App
        public string Instruction => "Welcome to Carpark Engine, please refer the Mutation type in Schema Reference and Schema Definition to investigate how to submit parking entry and exit data for parking price.";

        // PricingRates returns a list of pricing rates, their prices, conditions, descriptions and special note
        public IEnumerable<PricingRate> PricingRates()
        {
            List<PricingRate> pricingRates = new List<PricingRate>();

            // Populate the pricing rate list
            pricingRates.Add(new PricingRate()
            {
                Name = "Early Bird",
                Type = "Flat Rate",
                TotalPrice = 13,
                EntryCondition = "Enter between 6:00 AM to 9:00 AM",
                ExitCondition = "Exit between 3:30 PM to 11:30 PM",
                Note = ""
            });

            pricingRates.Add(new PricingRate()
            {
                Name = "Night Rate",
                Type = "Flat Rate",
                TotalPrice = 6.5f,
                EntryCondition = "Enter between 6:00 PM to midnight (weekdays)",
                ExitCondition = "Exit before 6 AM the following day",
                Note = ""
            });

            pricingRates.Add(new PricingRate()
            {
                Name = "Weekend Rate",
                Type = "Flat Rate",
                TotalPrice = 10,
                EntryCondition = "Enter anytime past midnight on Friday to Sunday",
                ExitCondition = "Exit any time before midnight of Sunday",
                Note = "If a patron enters the carpark before midnight on Friday and if they qualify for Night rate on a Saturday morning, then the program should charge the night rate instead of weekend rate."
            });

            pricingRates.Add(new PricingRate()
            {
                Name = "Standard Rate 0 – 1 hours",
                Type = "Hourly Rate",
                TotalPrice = 5,
                EntryCondition = "",
                ExitCondition = "",
                Note = ""
            });

            pricingRates.Add(new PricingRate()
            {
                Name = "Standard Rate 1 – 2 hours",
                Type = "Hourly Rate",
                TotalPrice = 10,
                EntryCondition = "",
                ExitCondition = "",
                Note = ""
            });

            pricingRates.Add(new PricingRate()
            {
                Name = "Standard Rate 2 – 3 hours",
                Type = "Hourly Rate",
                TotalPrice = 15,
                EntryCondition = "",
                ExitCondition = "",
                Note = ""
            });

            pricingRates.Add(new PricingRate()
            {
                Name = "Standard Rate 3+ hours",
                Type = "Flat Rate",
                TotalPrice = 20,
                EntryCondition = "",
                ExitCondition = "",
                Note = ""
            });

            return pricingRates;
        }
    }
}
