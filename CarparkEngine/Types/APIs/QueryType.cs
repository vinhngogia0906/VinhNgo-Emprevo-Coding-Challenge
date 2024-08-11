using CarparkEngine.API;

namespace CarparkEngine.Types.APIs
{
    // Schema description for Query APIs
    public class QueryType : ObjectTypeExtension<Query>
    {
        protected override void Configure(IObjectTypeDescriptor<Query> descriptor)
        {
            descriptor.Name(OperationTypeNames.Query);

            // Explain the Instruction Query
            descriptor
                .Field(i => i.Instruction)
                .Description("Retrieves the welcome message and instruction how to get to the submit ticket api document.");
            // Explain the PricingRates Query
            descriptor
                .Field(p => p.PricingRates())
                .Description("Retrieves the pricing convention of Carpark Engine.");
        }
    }
}
