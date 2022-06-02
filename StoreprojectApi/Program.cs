

using InventoryBL;
using SStoreprojectModel;
using StoreBL;
using StoreDL;
using StorefrontBL;
using StoreprojectModel;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IRepository<Customer>, SQLCustomerRepository>(repo => new SQLCustomerRepository(builder.Configuration.GetConnectionString("Israel ngandu")));
builder.Services.AddScoped<IStoreBL, StoreprojectBL>();
builder.Services.AddScoped<IRepository<Storefront>, SQLStoreRepository>(repo => new SQLStoreRepository(builder.Configuration.GetConnectionString("Israel ngandu")));
builder.Services.AddScoped<IStorefrontBL, StorelocationBL>();
builder.Services.AddScoped<IRepository<Inventory>, SQLInventory>(repo => new SQLInventory(builder.Configuration.GetConnectionString("Israel ngandu")));
builder.Services.AddScoped<IinventoryBL, InventoryjoinBL>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
