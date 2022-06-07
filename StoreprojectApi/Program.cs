
using InventoryBL;
using OrdersBL;
using Serilog;
using SStoreprojectModel;
using StoreBL;
using StoreDL;
using StorefrontBL;
using StoreprojectModel;

var builder = WebApplication.CreateBuilder(args);

// initializing my logger
Log.Logger = new LoggerConfiguration()
    .WriteTo.File("./logs/user.txt")
    .CreateLogger();


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();




builder.Services.AddScoped<IRepository<Customer>, SqlCustomerRepository>(repo => new SqlCustomerRepository(Environment.GetEnvironmentVariable("Connection_String")));
builder.Services.AddScoped<IStoreBL, StoreprojectBL>();
builder.Services.AddScoped<IRepository<Storefront>, SqlStoreRepository>(repo => new SqlStoreRepository(Environment.GetEnvironmentVariable("Connection_String")));
builder.Services.AddScoped<IStorefrontBL, StorelocationBL>();
builder.Services.AddScoped<IRepository<Inventory>, SqlInventory>(repo => new SqlInventory(Environment.GetEnvironmentVariable("Connection_String")));
builder.Services.AddScoped<IinventoryBL, InventoryjoinBL>();
builder.Services.AddScoped<IRepository<Orders>, SqlOrdersRepository>(repo => new SqlOrdersRepository(Environment.GetEnvironmentVariable("Connection_String")));
builder.Services.AddScoped<IRepository<CustomerOrders>, SqlOrderslistRepository>(repo => new SqlOrderslistRepository(Environment.GetEnvironmentVariable("Connection_String")));
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
