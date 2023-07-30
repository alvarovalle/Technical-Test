using Backend.State;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IListingRepository, ListingRepository>();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "all",
                      policy  =>
                      {
                          policy.WithOrigins("*");
                      });
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var connectionString = "";
builder.Services.AddDbContext<Context>((options)=>options.UseNpgsql(connectionString, x =>
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

app.MapPost("/listing", (IListingRepository repo, Backend.Model.Listing listing) =>
{
   return repo.Create(listing);
})
.WithOpenApi();

app.MapPut("/listing", (IListingRepository repo, Backend.Model.Listing listing) =>
{
   return repo.Update(listing);
})
.WithOpenApi();

app.MapGet("/listing/{id}", (IListingRepository repo, int id) =>
{
   return repo.GetListingPriceHistory(id);
})
.WithOpenApi();

app.Run();
