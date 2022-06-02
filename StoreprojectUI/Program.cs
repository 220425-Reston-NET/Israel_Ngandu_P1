global using Serilog;
using Microsoft.Extensions.Configuration;
using StoreBL;
using StoreDL;
using StoreprojectUI;

// initializing my logger
Log.Logger = new LoggerConfiguration()
    .WriteTo.File("./logs/user.txt")
    .CreateLogger();
var Configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .Build();

Console.Clear();

//Creating MainMenu obj
IMenu menu = new MainMenu();
bool repeat = true;

while (repeat)
{
    Console.Clear();
    menu.Display();
    string ans = menu.YourChoice();

    if (ans == "MainMenu")
    {
        Log.Information("User going through the main menu");
        menu = new MainMenu();
    }
    else if (ans == "AddCustomer")
    {
        Log.Information("User going through the add customer process");
        menu = new AddCustomer(new StoreprojectBL(new SQLCustomerRepository(Configuration.GetConnectionString("Israel ngandu"))));
    }
    else if (ans == "SearchCustomer")
    {
        Log.Information("User going through the search customer");
        menu = new SearchCustomer(new StoreprojectBL(new SQLCustomerRepository(Configuration.GetConnectionString("Israel ngandu"))));
    }
    
    else if (ans == "Exit")
    {
        repeat = false;
    }
}
