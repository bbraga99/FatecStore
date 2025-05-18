using Fatec.Store.Carts.Api.Context;
using Fatec.Store.Carts.Api.Domain.Interfaces.HttpClient;
using Fatec.Store.Carts.Api.Domain.Interfaces.Repositories;
using Fatec.Store.Carts.Api.Domain.Interfaces.Services;
using Fatec.Store.Carts.Api.Mappings;
using Fatec.Store.Carts.Api.Models.ServicesClient;
using Fatec.Store.Carts.Api.Repository;
using Fatec.Store.Carts.Api.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string? SqlConnection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(
    options => options.UseMySql(SqlConnection, ServerVersion.AutoDetect(SqlConnection)));

builder.Services.AddScoped<ICartsService, CartsService>();
builder.Services.AddScoped<ICartsRepository, CartsRepository>();
builder.Services.AddScoped<IProductsRepository, ProductsRepository>();
builder.Services.AddScoped<IDiscountServiceClient, DiscountServiceClient>();
builder.Services.AddHttpClient();

builder.Services.AddAutoMapper(typeof(CartProfile).Assembly);

var app = builder.Build();

app.MigrationInitialisation();

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors(options =>
{
    options.AllowAnyHeader();
    options.AllowAnyOrigin();
    options.AllowAnyMethod();
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
