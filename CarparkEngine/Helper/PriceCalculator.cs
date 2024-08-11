using CarparkEngine.Model;

namespace CarparkEngine.Helper
{
    // Helper class that does the ticket price calculation
    public class PriceCalculator
    {
        // Timezone info to covert DateTime data to Melbourne Time
        private readonly TimeZoneInfo _melbourneTimeZone;
        // Standardize DateTime format so the system won't mistake day for month and vice versa
        private const string DateTimeFormat = "M/d/yyyy, h:mm:ss tt";

        public PriceCalculator()
        {
            // Initialize the TimeZone of Melbourne in the constructor
            _melbourneTimeZone = TimeZoneInfo.FindSystemTimeZoneById("AUS Eastern Standard Time");
        }

        // Convert DateTime data to Melbourne Time
        private DateTime ConvertToMelbourneTime(DateTime dateTime)
        {
            return TimeZoneInfo.ConvertTimeFromUtc(dateTime.ToUniversalTime(), _melbourneTimeZone);
        }

        // Checking for EarlyBird condition
        private bool IsEarlyBird(DateTime entry, DateTime exit)
        {
            entry = ConvertToMelbourneTime(entry);
            exit = ConvertToMelbourneTime(exit);

            if (entry.DayOfWeek == DayOfWeek.Saturday || entry.DayOfWeek == DayOfWeek.Sunday)
            {
                return false;
            }

            var entryTime = entry.TimeOfDay;
            var exitTime = exit.TimeOfDay;

            return entryTime >= new TimeSpan(6, 0, 0) && entryTime <= new TimeSpan(9, 0, 0)
                && exitTime >= new TimeSpan(15, 30, 0) && exitTime <= new TimeSpan(23, 30, 0);
        }

        // Checking for Night Rate condition 
        private bool IsNightRate(DateTime entry, DateTime exit)
        {
            entry = ConvertToMelbourneTime(entry);
            exit = ConvertToMelbourneTime(exit);

            if (entry.DayOfWeek == DayOfWeek.Saturday || entry.DayOfWeek == DayOfWeek.Sunday)
            {
                return false;
            }

            var entryTime = entry.TimeOfDay;
            var exitTime = exit.TimeOfDay;

            return entryTime >= new TimeSpan(18, 0, 0) && entryTime <= new TimeSpan(23, 59, 59)
                && exitTime >= new TimeSpan(0, 0, 0) && exitTime < new TimeSpan(6, 0, 0)
                && (exit.Date == entry.Date.AddDays(1) || exit.Date == entry.Date);
        }

        // Checking for Weekend Rate condition
        private bool IsWeekendRate(DateTime entry, DateTime exit)
        {
            entry = ConvertToMelbourneTime(entry);
            exit = ConvertToMelbourneTime(exit);

            return (entry.DayOfWeek == DayOfWeek.Friday && entry.TimeOfDay >= TimeSpan.Zero)
             || entry.DayOfWeek == DayOfWeek.Saturday
             || (entry.DayOfWeek == DayOfWeek.Sunday && exit.TimeOfDay < new TimeSpan(23, 59, 59));
        }

        // Calculate the standard hourly rate
        private float CalculateStandardRate(DateTime entry, DateTime exit)
        {
            entry = ConvertToMelbourneTime(entry);
            exit = ConvertToMelbourneTime(exit);

            TimeSpan duration = exit - entry;

            if (duration <= TimeSpan.FromHours(1))
            {
                return 5.0f;
            }
            else if (duration <= TimeSpan.FromHours(2))
            {
                return 10.0f;
            }
            else if (duration <= TimeSpan.FromHours(3))
            {
                return 15.0f;
            }
            else
            {
                int days = (exit.Date - entry.Date).Days + 1;
                return days * 20.0f;
            }
        }

        // Calculate Ticket Price
        public float CalculatePrice(PatronTicketInput ticket)
        {
            DateTime entry = ConvertToMelbourneTime(ticket.entry);
            DateTime exit = ConvertToMelbourneTime(ticket.exit);

            // Check for Early Bird Rate first
            if (IsEarlyBird(entry, exit))
            {
                return 13.0f;
            }

            // Check for Weekend Rate
            if (IsWeekendRate(entry, exit))
            {
                // Special handling for entries before midnight on Friday
                if (entry.DayOfWeek == DayOfWeek.Friday && entry.TimeOfDay < new TimeSpan(6, 0, 0))
                {
                    // If entry is before Saturday morning and qualifies for Night Rate on Saturday morning
                    DateTime saturdayMorning = entry.Date.AddDays(1).AddHours(6); // Saturday 6 AM
                    if (IsNightRate(entry, exit))
                    {
                        return 6.5f; // Night Rate
                    }
                    // If entry qualifies for Weekend Rate but exits before Saturday morning
                    if (exit.Date < saturdayMorning.Date)
                    {
                        return 10.0f; // Weekend Rate
                    }
                }
                // Normal Weekend Rate applies
                return 10.0f;
            }

            // Check for Night Rate
            if (IsNightRate(entry, exit))
            {
                return 6.5f;
            }

            // Apply Standard Rate for any other cases
            return CalculateStandardRate(entry, exit);
        }
    }
}
