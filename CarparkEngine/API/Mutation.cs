using CarparkEngine.Helper;
using CarparkEngine.Model;
using System.Globalization;

namespace CarparkEngine.API
{
    // Mutation API, used for Create, Update and Delete Operations
    public class Mutation
    {
        // PriceCalculator Helper
        private readonly PriceCalculator _priceCalculator;

        public Mutation(PriceCalculator priceCalculator)
        {
            _priceCalculator = priceCalculator;
        }

        // SubmitTicket API, get input of entry and exit time and returns the Session ID, entry time, exit time and total payable amount.
        public PatronTicketResult submitTicket(PatronTicketInput ticket)
        {
            // Validation: Check if entry and exit are not null
            if (ticket.entry == default || ticket.exit == default)
            {
                throw new ArgumentException("Entry and Exit times cannot be null or default DateTime values.");
            }

            // Attempt to parse entry and exit times from the input
            if (!DateTime.TryParse(ticket.entry.ToString(CultureInfo.InvariantCulture), out DateTime entry) ||
                !DateTime.TryParse(ticket.exit.ToString(CultureInfo.InvariantCulture), out DateTime exit))
            {
                throw new ArgumentException("Invalid DateTime format for entry or exit.");
            }

            // Validate that entry and exit are valid DateTime values
            if (ticket.entry == DateTime.MinValue || ticket.exit == DateTime.MinValue)
            {
                throw new ArgumentException("Invalid entry or exit DateTime value, they need to be larger than the minimum DateTime value.");
            }

            // Check that entry is before exit
            if (ticket.entry >= ticket.exit)
            {
                throw new ArgumentException("Entry time must be before Exit time.");
            }

            // Validation: Check if entry and exit are not in the future
            if (ticket.entry.Day > DateTime.Now.Day || ticket.exit.Day > DateTime.Now.Day)
            {
                throw new ArgumentException("Entry and Exit times cannot exceed today's date.");
            }

            // Proceed with creating the result if all validations pass
            PatronTicketResult result = new PatronTicketResult()
            {
                Id = Guid.NewGuid(),
                entry = ticket.entry.ToLocalTime(),
                exit = ticket.exit.ToLocalTime(),
                totalPrice = _priceCalculator.CalculatePrice(ticket)
            };
            return result;
        }
    }
}
