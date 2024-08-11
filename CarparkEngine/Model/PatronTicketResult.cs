namespace CarparkEngine.Model
{
    // PatronTicketResult object, is returned as the Response of submitTicket API
    public class PatronTicketResult
    {
        public Guid Id { get; set; }
        public DateTime entry { get; set; }
        public DateTime exit { get; set; }
        public float totalPrice { get; set; }
    }
}
