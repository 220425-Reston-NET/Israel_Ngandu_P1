using StoreBL;
using StoreprojectModel;

public class AddCustomer : IMenu
{
    private Customer customerobj = new Customer();

    private IStoreBL _storeBL;


    public AddCustomer(IStoreBL p_storeBL)
    {
        _storeBL = p_storeBL;
    }



    public void Display()
    {

        Console.WriteLine("Please enter the customer details by following the questions");
        Console.Write("Name: ");
        customerobj.Name = Console.ReadLine();
        Console.Write("Address: ");
        customerobj.Address = Console.ReadLine();
        Console.Write("Phone: ");
        try
        {
            customerobj.Phone = Convert.ToDouble(Console.ReadLine());
        }
        catch (System.Exception)
        {

            Console.WriteLine("Pnone number must contian 10 digits!");
            customerobj.Phone = 0;

        }
        Console.WriteLine("[1] - Add the Customer");
        Console.WriteLine("[0] - Exit");
    }

    public string YourChoice()
    {

        string userInput = Console.ReadLine();

        if (userInput == "1")
        {

            try
            {
                _storeBL.AddCustomer(customerobj);

            }
            catch (System.Exception)
            {
                Log.Warning("Customer Phone already exists!");
                Log.Information(customerobj.ToString());
                Console.WriteLine("Customer Phone already exists!");
                Console.WriteLine("====================================");
                Console.WriteLine("Would you like to try again?");
                Console.WriteLine("[2] - Add a new Customer");
                Console.WriteLine("[1] - Search Customer");
                Console.WriteLine("[0] - Exit");

                userInput = Console.ReadLine();

                if (userInput == "2")
                {
                    return "AddCustomer";
                }
                else if (userInput == "1")
                {
                    return "SearchCustomer";
                }
                else if (userInput == "0")
                {
                    return "Exit";
                }
            }
            Console.WriteLine("Customer was saved successfully");
            return "MainMenu";
        }
        else if (userInput == "0")
        {
            return "Exit";
        }
        else
        {
            Log.Warning("Customer did not eneter any valid response");
            Console.WriteLine("Please enter a correct response");
            Console.ReadLine();
            return "AddCustomer";
        }

    }


}
