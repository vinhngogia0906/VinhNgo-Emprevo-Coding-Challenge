using CarparkEngine.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarparkEngine.Tests
{
    public class ModelTest
    {
        [Fact]
        public void PatronTicketInput_ShouldInitializePropertiesCorrectly()
        {
            // Arrange
            var entry = new DateTime(2024, 8, 10, 14, 30, 0);
            var exit = new DateTime(2024, 8, 10, 16, 30, 0);

            // Act
            var ticketInput = new PatronTicketInput(entry, exit);

            // Assert
            Assert.Equal(entry, ticketInput.entry);
            Assert.Equal(exit, ticketInput.exit);
        }

        [Fact]
        public void PatronTicketInput_ShouldBeEqual_WhenPropertiesAreEqual()
        {
            // Arrange
            var entry1 = new DateTime(2024, 8, 10, 14, 30, 0);
            var exit1 = new DateTime(2024, 8, 10, 16, 30, 0);
            var ticketInput1 = new PatronTicketInput(entry1, exit1);

            var entry2 = new DateTime(2024, 8, 10, 14, 30, 0);
            var exit2 = new DateTime(2024, 8, 10, 16, 30, 0);
            var ticketInput2 = new PatronTicketInput(entry2, exit2);

            // Act & Assert
            Assert.Equal(ticketInput1, ticketInput2);
            Assert.True(ticketInput1 == ticketInput2);
        }

        [Fact]
        public void PatronTicketInput_ShouldNotBeEqual_WhenPropertiesAreDifferent()
        {
            // Arrange
            var entry1 = new DateTime(2024, 8, 10, 14, 30, 0);
            var exit1 = new DateTime(2024, 8, 10, 16, 30, 0);
            var ticketInput1 = new PatronTicketInput(entry1, exit1);

            var entry2 = new DateTime(2024, 8, 11, 14, 30, 0); // Different entry date
            var exit2 = new DateTime(2024, 8, 10, 16, 30, 0);
            var ticketInput2 = new PatronTicketInput(entry2, exit2);

            // Act & Assert
            Assert.NotEqual(ticketInput1, ticketInput2);
            Assert.False(ticketInput1 == ticketInput2);
        }

        [Fact]
        public void PatronTicketResult_ShouldInitializePropertiesCorrectly()
        {
            // Arrange
            var id = Guid.NewGuid();
            var entry = new DateTime(2024, 8, 10, 14, 30, 0);
            var exit = new DateTime(2024, 8, 10, 16, 30, 0);
            var totalPrice = 25.50f;

            // Act
            var ticketResult = new PatronTicketResult
            {
                Id = id,
                entry = entry,
                exit = exit,
                totalPrice = totalPrice
            };

            // Assert
            Assert.Equal(id, ticketResult.Id);
            Assert.Equal(entry, ticketResult.entry);
            Assert.Equal(exit, ticketResult.exit);
            Assert.Equal(totalPrice, ticketResult.totalPrice);
        }

        [Fact]
        public void PatronTicketResult_ShouldHandleDefaultValues()
        {
            // Act
            var ticketResult = new PatronTicketResult();

            // Assert
            Assert.Equal(Guid.Empty, ticketResult.Id);
            Assert.Equal(default(DateTime), ticketResult.entry);
            Assert.Equal(default(DateTime), ticketResult.exit);
            Assert.Equal(0f, ticketResult.totalPrice);
        }

        [Fact]
        public void PricingRate_ShouldInitializePropertiesCorrectly()
        {
            // Arrange
            var name = "Standard Rate";
            var type = "Hourly";
            var totalPrice = 50.75f;
            var entryCondition = "Entry after 6 PM";
            var exitCondition = "Exit before 6 AM";
            var note = "Special weekend rate";

            // Act
            var pricingRate = new PricingRate
            {
                Name = name,
                Type = type,
                TotalPrice = totalPrice,
                EntryCondition = entryCondition,
                ExitCondition = exitCondition,
                Note = note
            };

            // Assert
            Assert.Equal(name, pricingRate.Name);
            Assert.Equal(type, pricingRate.Type);
            Assert.Equal(totalPrice, pricingRate.TotalPrice);
            Assert.Equal(entryCondition, pricingRate.EntryCondition);
            Assert.Equal(exitCondition, pricingRate.ExitCondition);
            Assert.Equal(note, pricingRate.Note);
        }

        [Fact]
        public void PricingRate_ShouldHandleNullValues()
        {
            // Act
            var pricingRate = new PricingRate();

            // Assert
            Assert.Null(pricingRate.Name);
            Assert.Null(pricingRate.Type);
            Assert.Equal(0f, pricingRate.TotalPrice); // Default value for float
            Assert.Null(pricingRate.EntryCondition);
            Assert.Null(pricingRate.ExitCondition);
            Assert.Null(pricingRate.Note);
        }

        [Fact]
        public void PricingRate_ShouldAllowPropertyChanges()
        {
            // Arrange
            var pricingRate = new PricingRate();
            var newName = "Premium Rate";
            var newTotalPrice = 75.50f;

            // Act
            pricingRate.Name = newName;
            pricingRate.TotalPrice = newTotalPrice;

            // Assert
            Assert.Equal(newName, pricingRate.Name);
            Assert.Equal(newTotalPrice, pricingRate.TotalPrice);
        }
    }
}
