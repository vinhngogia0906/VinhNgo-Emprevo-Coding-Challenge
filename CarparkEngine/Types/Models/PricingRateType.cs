using CarparkEngine.Model;

namespace CarparkEngine.Types.Models
{
    public class PricingRateType : ObjectType<PricingRate>
    {
        // Schema description for PricingRate Object
        protected override void Configure(IObjectTypeDescriptor<PricingRate> descriptor)
        {
            descriptor.Name("PricingRateType");

            // Description for Name
            descriptor
                .Field(p => p.Name)
                .Description("Represents the name of the pricing rate.")
                .Type<StringType>();

            // Description for Rate Type
            descriptor
                .Field(p => p.Type)
                .Description("Represents the type of the pricing rate.")
                .Type<StringType>();

            // Description for Rate Price
            descriptor
                .Field(p => p.TotalPrice)
                .Description("Represents the price of the pricing rate.")
                .Type<NonNullType<FloatType>>();

            // Description for Entry condition
            descriptor
                .Field(p => p.EntryCondition)
                .Description("Represents the entry condition of the pricing rate.")
                .Type<StringType>();

            // Description for Exit condition
            descriptor
                .Field(p => p.ExitCondition)
                .Description("Represents the exit condition of the pricing rate.")
                .Type<StringType>();

            // Description for special note
            descriptor
                .Field(p => p.Note)
                .Description("Represents the special note of the pricing rate.")
                .Type<StringType>();
        }
    }
}
