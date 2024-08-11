using CarparkEngine.API;
using CarparkEngine.Model;
using System;


namespace CarparkEngine.Tests
{
    public class QueryTest
    {
        [Fact]
        public void Instruction_ShouldReturnExpectedString()
        {
            // Arrange
            var query = new Query();

            // Act
            var instruction = query.Instruction;

            // Assert
            var expectedInstruction = "Welcome to Carpark Engine, please refer the Mutation type in Schema Reference and Schema Definition to investigate how to submit parking entry and exit data for parking price.";
            Assert.Equal(expectedInstruction, instruction);
        }

        [Fact]
        public void PricingRates_ShouldReturnCorrectPricingRates()
        {
            // Arrange
            var query = new Query();

            // Act
            var pricingRates = query.PricingRates();

            // Assert
            var expectedRates = new List<PricingRate>
        {
            new PricingRate
            {
                Name = "Early Bird",
                Type = "Flat Rate",
                TotalPrice = 13.0f,
                EntryCondition = "Enter between 6:00 AM to 9:00 AM",
                ExitCondition = "Exit between 3:30 PM to 11:30 PM",
                Note = ""
            },
            new PricingRate
            {
                Name = "Night Rate",
                Type = "Flat Rate",
                TotalPrice = 6.5f,
                EntryCondition = "Enter between 6:00 PM to midnight (weekdays)",
                ExitCondition = "Exit before 6 AM the following day",
                Note = ""
            },
            new PricingRate
            {
                Name = "Weekend Rate",
                Type = "Flat Rate",
                TotalPrice = 10.0f,
                EntryCondition = "Enter anytime past midnight on Friday to Sunday",
                ExitCondition = "Exit any time before midnight of Sunday",
                Note = "If a patron enters the carpark before midnight on Friday and if they qualify for Night rate on a Saturday morning, then the program should charge the night rate instead of weekend rate."
            },
            new PricingRate
            {
                Name = "Standard Rate 0 – 1 hours",
                Type = "Hourly Rate",
                TotalPrice = 5.0f,
                EntryCondition = "",
                ExitCondition = "",
                Note = ""
            },
            new PricingRate
            {
                Name = "Standard Rate 1 – 2 hours",
                Type = "Hourly Rate",
                TotalPrice = 10.0f,
                EntryCondition = "",
                ExitCondition = "",
                Note = ""
            },
            new PricingRate
            {
                Name = "Standard Rate 2 – 3 hours",
                Type = "Hourly Rate",
                TotalPrice = 15.0f,
                EntryCondition = "",
                ExitCondition = "",
                Note = ""
            },
            new PricingRate
            {
                Name = "Standard Rate 3+ hours",
                Type = "Flat Rate",
                TotalPrice = 20.0f,
                EntryCondition = "",
                ExitCondition = "",
                Note = ""
            }
        };

            var actualRates = new List<PricingRate>(pricingRates);
            Assert.Equal(expectedRates.Count, actualRates.Count);

            for (int i = 0; i < expectedRates.Count; i++)
            {
                Assert.Equal(expectedRates[i].Name, actualRates[i].Name);
                Assert.Equal(expectedRates[i].Type, actualRates[i].Type);
                Assert.Equal(expectedRates[i].TotalPrice, actualRates[i].TotalPrice);
                Assert.Equal(expectedRates[i].EntryCondition, actualRates[i].EntryCondition);
                Assert.Equal(expectedRates[i].ExitCondition, actualRates[i].ExitCondition);
                Assert.Equal(expectedRates[i].Note, actualRates[i].Note);
            }
        }
    }
}
