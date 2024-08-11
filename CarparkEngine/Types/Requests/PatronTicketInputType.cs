using CarparkEngine.Model;

namespace CarparkEngine.Types.Requests
{
    public class PatronTicketInputType : InputObjectType<PatronTicketInput>
    {
        // Schema description for PatronTicketInput Object
        protected override void Configure(IInputObjectTypeDescriptor<PatronTicketInput> descriptor)
        {
            descriptor.Name("PatronTicketInput");
            descriptor.Description("Represents the input to submit the ticket to get the price result");

            // Description for entry time input
            descriptor
                .Field(t => t.entry)
                .Description("Represents the entry date time input")
                .Type<DateTimeType>();

            // Description for exit time input
            descriptor
                .Field(t => t.exit)
                .Description("Represents the exit date time input")
                .Type<DateTimeType>();
        }
    }
}
