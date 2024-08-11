using CarparkEngine.API;
using CarparkEngine.Helper;
using CarparkEngine.Types.APIs;
using CarparkEngine.Types.Models;
using CarparkEngine.Types.Requests;
using CarparkEngine.Types.Responses;

var builder = WebApplication.CreateBuilder(args);

// adding  services, GraphQL Server, Query, Mutation and schema descriptions
builder.Services.AddScoped<PriceCalculator>();
builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>()
    .AddType<QueryType>()
    .AddType<MutationType>()
    .AddType<PricingRateType>()
    .AddType<PatronTicketInputType>()
    .AddType<PatronTicketResultType>();

// Retrieve frontend URI for CORS
var frontendUris = builder.Configuration.GetSection("Uri:Frontend").Get<string[]>() ?? throw new Exception("No frontend URIs configured.");

// Add CORS
builder.Services.AddCors(opt =>
{
    opt.AddPolicy(
        name: "Frontend",
        builder =>
        {
            builder
                .WithOrigins(frontendUris)
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseRouting();

app.UseCors("Frontend");

app.UseEndpoints(endpoints =>
{
    endpoints.MapGraphQL();
});

app.Run();
