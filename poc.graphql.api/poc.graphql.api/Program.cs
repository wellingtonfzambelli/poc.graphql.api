using poc.graphql.api.GraphQL;
using poc.graphql.api.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddSingleton<INewsRepository, NewsRepository>();

// Register GraphQL
builder.Services
    .AddGraphQLServer()
    .AddQueryType<NewsQueryGraphQL>()
    .AddFiltering()
    .AddSorting();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


// GraphQL endpoint
app.MapGraphQL("/graphql");

// Optional: redirect root to GraphQL Playground
app.MapGet("/", () => Results.Redirect("/graphql"));


app.Run();
