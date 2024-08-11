using CarparkEngine.Model;

namespace CarparkEngine.Types.Responses
{
    public class PatronTicketResultType : ObjectType<PatronTicketResult>
    {
        // Schema description for PatronTicketResult - which is returned by submitTicket API
        protected override void Configure(IObjectTypeDescriptor<PatronTicketResult> descriptor)
        {
            descriptor.Name("PatronTicketResultType");
            descriptor.Description("Represents the payload return for the ticket submit");

            // Description for session ID
            descriptor
                .Field(r => r.Id)
                .Description("Represents the Id of the ticket invoice.");

            // Descriotion for ticket entry time
            descriptor
               .Field(r => r.entry)
               .Description("Represents the return ticket entry date time.")
               .Type<DateTimeType>();

            // Description for ticket exit time
            descriptor
                .Field(r => r.exit)
                .Description("Represents the return ticket exit date time.")
                .Type<DateTimeType>();

            // Description for total payable amount of the ticket
            descriptor
                .Field(r => r.totalPrice)
                .Description("Represents the total payable price of the return ticket.")
                .Type<FloatType>();
        }
    }
}
