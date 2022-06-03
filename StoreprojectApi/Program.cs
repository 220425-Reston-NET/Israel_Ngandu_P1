
using InventoryBL;
using OrdersBL;
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

// Will use this if there is need for console testing
// builder.Configuration.GetConnectionString("Israel ngandu")


builder.Services.AddScoped<IRepository<Customer>, SQLCustomerRepository>(repo => new SQLCustomerRepository(Environment.GetEnvironmentVariable("Connection_String")));
builder.Services.AddScoped<IStoreBL, StoreprojectBL>();
builder.Services.AddScoped<IRepository<Storefront>, SQLStoreRepository>(repo => new SQLStoreRepository(Environment.GetEnvironmentVariable("Connection_String")));
builder.Services.AddScoped<IStorefrontBL, StorelocationBL>();
builder.Services.AddScoped<IRepository<Inventory>, SQLInventory>(repo => new SQLInventory(Environment.GetEnvironmentVariable("Connection_String")));
builder.Services.AddScoped<IinventoryBL, InventoryjoinBL>();
builder.Services.AddScoped<IRepository<CustomerOrders>, SQLOrderslistRepository>(repo => new SQLOrderslistRepository(Environment.GetEnvironmentVariable("Connection_String")));
builder.Services.AddScoped<IOrdersListBL, OrderslistBL>();

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
