using StoreDL;
using StoreprojectModel;

namespace StoreBL 
{
    public class StoreprojectBL : IStoreBL
    {
        //================== Dependency Injection ====================
        private readonly IRepository<Customer> storeRepo;
        public StoreprojectBL(IRepository<Customer> p_storeRepo)
        {
            storeRepo = p_storeRepo;
        }
        //============================================================

        public List<Customer> GetAllCustomers()
        {
            return storeRepo.GetAll();
        }

        public async Task<List<Customer>> GetAllCustomersAsync()
        {
            return await storeRepo.GetAllAsync();
        }

        


        public Customer SearchCustomerByName(string name)
        {
            return storeRepo.GetAll().First(store => store.Name == name);
        }

        public Customer SearchCustomerByPhone(double Phone)
        {
            return storeRepo.GetAll().First(store => store.Phone == Phone);
        }

        public List<Orders> ViewCustomerOrders(int p_CustomerID)
        {
            List<Customer> listOfCurrentCustomers = storeRepo.GetAll();

            foreach (Customer item in listOfCurrentCustomers)
            {
                //Condition to return a specific store
                if (item.customerID == p_CustomerID)
                {
                    return item.Orders;
                }
            }

            //It will return nothing if the client specify a store that was never in the database
            return null;
        }

        void IStoreBL.AddCustomer(Customer c_cus)
         {
           Customer foundedcustomer = SearchCustomerByPhone(c_cus.Phone);

            if (foundedcustomer == null)
            {
                storeRepo.Add(c_cus);
            }
            else
            {
                throw new Exception("Customer Name already exists");
            }
        }
    }
}