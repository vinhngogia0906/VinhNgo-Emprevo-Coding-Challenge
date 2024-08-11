using CarparkEngine.API;

namespace CarparkEngine.Types.APIs
{
    // Schema description for Mutation API
    public class MutationType : ObjectTypeExtension<Mutation>
    {
        protected override void Configure(IObjectTypeDescriptor<Mutation> descriptor)
        {
            descriptor.Name(OperationTypeNames.Mutation);
            // Explain submitTicket API
            descriptor
                .Field(s => s.submitTicket(default!))
                .Description("Submits the entry and exit of a ticket to get total price and ticket invoice.");
        }
    }
}
