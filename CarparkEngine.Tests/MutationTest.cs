using CarparkEngine.API;
using CarparkEngine.Helper;
using CarparkEngine.Model;


namespace CarparkEngine.Tests
{
    public class MutationTest
    {
        private readonly PriceCalculator _priceCalculator;

        public MutationTest()
        {
            // Initialize a mock or real PriceCalculator depending on your test needs
            _priceCalculator = new PriceCalculator();
        }

        [Fact]
        public void SubmitTicket_ShouldReturnPatronTicketResult_ForValidInput()
        {
            // Arrange
            var mutation = new Mutation(_priceCalculator);
            var entry = new DateTime(2024, 8, 10, 10, 0, 0);
            var exit = new DateTime(2024, 8, 10, 12, 0, 0);
            var ticket = new PatronTicketInput(entry, exit);

            // Act
            var result = mutation.submitTicket(ticket);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(ticket.entry.ToLocalTime(), result.entry);
            Assert.Equal(ticket.exit.ToLocalTime(), result.exit);
            Assert.True(result.totalPrice >= 0); // Assuming the price should be non-negative
        }

        [Fact]
        public void SubmitTicket_ShouldThrowArgumentException_WhenEntryOrExitIsDefault()
        {
            // Arrange
            var mutation = new Mutation(_priceCalculator);
            var invalidTicket1 = new PatronTicketInput(default, new DateTime(2024, 8, 10, 12, 0, 0));
            var invalidTicket2 = new PatronTicketInput(new DateTime(2024, 8, 10, 10, 0, 0), default);

            // Act & Assert
            Assert.Throws<ArgumentException>(() => mutation.submitTicket(invalidTicket1));
            Assert.Throws<ArgumentException>(() => mutation.submitTicket(invalidTicket2));
        }

        [Fact]
        public void SubmitTicket_ShouldThrowArgumentException_WhenEntryIsAfterExit()
        {
            // Arrange
            var mutation = new Mutation(_priceCalculator);
            var ticket = new PatronTicketInput(new DateTime(2024, 8, 10, 12, 0, 0), new DateTime(2024, 8, 10, 10, 0, 0));

            // Act & Assert
            Assert.Throws<ArgumentException>(() => mutation.submitTicket(ticket));
        }

        [Fact]
        public void SubmitTicket_ShouldThrowArgumentException_WhenEntryOrExitIsInTheFuture()
        {
            // Arrange
            var mutation = new Mutation(_priceCalculator);
            var futureDate = DateTime.Now.AddDays(1);
            var ticket1 = new PatronTicketInput(DateTime.Now, futureDate);
            var ticket2 = new PatronTicketInput(futureDate, DateTime.Now);

            // Act & Assert
            Assert.Throws<ArgumentException>(() => mutation.submitTicket(ticket1));
            Assert.Throws<ArgumentException>(() => mutation.submitTicket(ticket2));
        }

        [Fact]
        public void SubmitTicket_ShouldThrowArgumentException_WhenEntryOrExitIsMinValue()
        {
            // Arrange
            var mutation = new Mutation(_priceCalculator);
            var minValueDate = DateTime.MinValue;
            var ticket1 = new PatronTicketInput(minValueDate, new DateTime(2024, 8, 10, 12, 0, 0));
            var ticket2 = new PatronTicketInput(new DateTime(2024, 8, 10, 10, 0, 0), minValueDate);

            // Act & Assert
            Assert.Throws<ArgumentException>(() => mutation.submitTicket(ticket1));
            Assert.Throws<ArgumentException>(() => mutation.submitTicket(ticket2));
        }
    }
}
