using CarparkEngine.Helper;
using CarparkEngine.Model;


namespace CarparkEngine.Tests
{
    public class PriceCalculatorTest
    {
        private readonly PriceCalculator _priceCalculator;

        public PriceCalculatorTest()
        {
            _priceCalculator = new PriceCalculator();
        }

        [Theory]
        [InlineData("2024-08-09 02:00:00", "2024-08-09 07:00:00", 10.0)]   // Weekend Rate (Saturday)
        public void CalculatePrice_ShouldReturnCorrectPrice(string entryTime, string exitTime, float expectedPrice)
        {
            // Arrange
            var ticket = new PatronTicketInput(DateTime.Parse(entryTime), DateTime.Parse(exitTime));

            // Act
            float actualPrice = _priceCalculator.CalculatePrice(ticket);

            // Assert
            Assert.Equal(expectedPrice, actualPrice);
        }


        [Theory]
        [InlineData("2024-08-10 03:01:00", "2024-08-10 22:59:59", 10.0)] // Weekend Rate (Saturday)
        [InlineData("2024-08-10 01:00:00", "2024-08-10 22:59:59", 10.0)] // Weekend Rate (Sunday)
        public void CalculatePrice_ShouldReturnCorrectPriceForWeekendRate(string entryTime, string exitTime, float expectedPrice)
        {
            // Arrange
            var ticket = new PatronTicketInput(DateTime.Parse(entryTime), DateTime.Parse(exitTime));

            // Act
            float actualPrice = _priceCalculator.CalculatePrice(ticket);

            // Assert
            Assert.Equal(expectedPrice, actualPrice);
        }

        [Theory]
        [InlineData("2024-08-08 00:00:00", "2024-08-08 01:00:00", 5.0)]   // Standard Rate (1 hour)
        [InlineData("2024-08-01 02:00:00", "2024-08-01 03:40:00", 10.0)]  // Standard Rate (2 hours)
        [InlineData("2024-08-06 10:00:00", "2024-08-07 17:30:00", 40.0)]  // Standard Rate (2 days)
        public void CalculatePrice_ShouldReturnCorrectPriceForStandardRate(string entryTime, string exitTime, float expectedPrice)
        {
            // Arrange
            var ticket = new PatronTicketInput(DateTime.Parse(entryTime), DateTime.Parse(exitTime));

            // Act
            float actualPrice = _priceCalculator.CalculatePrice(ticket);

            // Assert
            Assert.Equal(expectedPrice, actualPrice);
        }
    }
}
