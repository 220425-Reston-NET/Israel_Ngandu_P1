using StoreBL;
using StoreprojectModel;

public class SearchCustomer : IMenu
{
    public static Customer foundedCustomer;

    //===========Dependency Injection===========
    private IStoreBL _storeBL;
    public SearchCustomer(IStoreBL p_storeBL)
    {
        _storeBL = p_storeBL;
    }
    // =========================================
    public void Display()
    {
        
        Console.WriteLine("How would you like to search your customer Account?");
        Console.WriteLine("[2] - Search by Name");
        Console.WriteLine("[1] - Search by Phone");
        Console.WriteLine("[0] - Exit");
    }

    public string YourChoice()
    {
        string userInput = Console.ReadLine();

        if (userInput == "2")
        {
            //Search logic by Name
            Console.WriteLine("Please enter a Name: ");
            string Name = Console.ReadLine();
            Customer foundedCustomer = _storeBL.SearchCustomerByName(Name);

            if (foundedCustomer == null)
            {
                Console.WriteLine("Customer was not found!");
                Console.WriteLine("Would you like to add a new customer or try search again?");
                Console.WriteLine("[2] - search Customer");
                Console.WriteLine("[1] - Add new Customer");
                Console.WriteLine("[0] - Exit");

                userInput = Console.ReadLine();

                if (userInput == "1")
                {
                    return "SearchCustomer";
                }
                else if (userInput == "1")
                {
                    return "AddCustomer";
                }
                else if (userInput == "0")
                {
                    return "MainMenu";
                }

            }
            else
            {
                // Customer foundedCustomer = _storeBL.SearchCustomerByName(Name);
                Console.WriteLine("===Customer info===");
                Console.WriteLine("Name: " + foundedCustomer.Name);
                Console.WriteLine("Address: " + foundedCustomer.Address);
                Console.WriteLine("Phone: " + foundedCustomer.Phone);
                Console.WriteLine("==========================");

                Console.WriteLine("Welcome back " + foundedCustomer.Name);
                Console.WriteLine("Please pick an option from the menu below");
                Console.WriteLine("[1] - View Store locations");
                Console.WriteLine("[0] - Return to the Main Menu");

                userInput = Console.ReadLine();
            
                 if (userInput == "1")
                {
                    return "SearchStore";
                }
                else if (userInput == "0")
                {
                    return "MainMenu";
                }
                else if (userInput == null)
                {
                    Console.WriteLine("Please Choose an option");
                    Console.ReadLine();
                    return "";
                }

                Console.ReadLine();
                return "MainMenu";
            }
        }
        else if (userInput == "1")
        {
            //Search logic by Phone
            Console.WriteLine("Please enter a Phone: ");
            double Phone = Convert.ToDouble(Console.ReadLine());
            Customer foundedCustomer = _storeBL.SearchCustomerByPhone(Phone);

            if (foundedCustomer == null)
            {
                Console.WriteLine("Customer was not found!");
                Console.WriteLine("Would you like to add a new customer or try search again?");
                Console.WriteLine("[2] - search Customer");
                Console.WriteLine("[1] - Add new Customer");
                Console.WriteLine("[0] - Exit");

                userInput = Console.ReadLine();

                if (userInput == "1")
                {
                    return "SearchCustomer";
                }
                else if (userInput == "1")
                {
                    return "AddCustomer";
                }
                else if (userInput == "0")
                {
                    return "MainMenu";
                }

            }
            else
            {
                Console.WriteLine("===Customer info===");
                Console.WriteLine("Name: " + foundedCustomer.Name);
                Console.WriteLine("Address: " + foundedCustomer.Address);
                Console.WriteLine("Phone: " + foundedCustomer.Phone);
                Console.WriteLine("==========================");

                Console.WriteLine("Welcome back " + foundedCustomer.Name);
                Console.WriteLine("Please pick an option from the menu below");
                Console.WriteLine("[1] - View Store locations");
                Console.WriteLine("[0] - Return to the Main Menu");

                userInput = Console.ReadLine();

               
             if (userInput == "1")
                {
                    return "mainmenu";
                }
                else if (userInput == "0")
                {
                    return "MainMenu";
                }
                else if (userInput == null)
                {
                    Console.WriteLine("Please Choose an option");
                    Console.ReadLine();
                    return "";
                }




                
            }

            Console.ReadLine();
            return "MainMenu";
        }
        else if (userInput == "0")
        {
            //Exit
            return "MainMenu";
        }
        else if (userInput == null)
        {
            Console.WriteLine("Please enter a valid response");
            Console.ReadLine();
            return "SearchCustomer";
        }

        return "MainMenu";
    }
}