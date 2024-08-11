namespace CarparkEngine.Model
{
    // PatronTicketInput object, used in submitTicket as the request input
    [GraphQLName("PatronTicketInput")]
    public record PatronTicketInput
    (
        DateTime entry,
        DateTime exit
    );
}
