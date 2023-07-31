using Backend.State.Listing;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IListingRepository, ListingRepository>();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "all",
                      policy =>
                      {
                          policy.WithOrigins("*");
                      });
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
var connectionString = "Host=localhost;Port=5432;Pooling=true;Database=Backend;User Id=postgres;Password=LltF8Nx*yo;";
builder.Services.AddDbContext<Context>((options) => options.UseNpgsql(connectionString, x =>
                                                {
                                                    x.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10),
                                                                           new List<string>());
                                                }));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(builder =>
{
    builder.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader();
});
app.UseHttpsRedirection();

app.MapGet("/listing", (IListingRepository repo) =>
{
    return repo.GetAll();
})
.WithOpenApi();

app.MapPost("/listing", (HttpContext http, IListingRepository repo, Backend.Model.Listing listing) =>
{
    if (repo.Create(listing))
        return listing;
    else
    {
        http.Response.StatusCode = 500;
        return null;
    }
})
.WithOpenApi();

app.MapPut("/listing/{id}", (HttpContext http, IListingRepository repo, int id, Backend.Model.Listing listing) =>
{
    listing.SetId(id);
    if (repo.Update(listing))
        return listing;
    else
    {
        http.Response.StatusCode = 500;
        return null;
    }
})
.WithOpenApi();

app.MapGet("/listing/{id}", (HttpContext http, IListingRepository repo, int id) =>
{
    return repo.GetListingPriceHistory(id);
})
.WithOpenApi();

app.Run();
