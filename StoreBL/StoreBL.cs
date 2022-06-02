using StoreDL;
using StoreprojectModel;

namespace StoreBL 
{
    public class StoreprojectBL : IStoreBL
    {
        //================== Dependency Injection ====================
        private IRepository<Customer> storeRepo;
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

        


        public Customer SearchCustomerByName(string p_name)
        {
            // List<Customer> currentListOfCustomer = storeRepo.GetAll();
            // foreach (Customer customerObj in currentListOfCustomer)
            // {
            //     if (customerObj.Name == name)
            //     {
            //         return customerObj;
            //     }
            // }
            // // throw new Exception("No customer was found");
            // return null;
            return storeRepo.GetAll().First(store => store.Name == p_name);
        }

        public Customer SearchCustomerByPhone(double p_Phone)
        {
            // List<Customer> currentListOfCustomer = storeRepo.GetAll();
            // foreach (Customer customerObj in currentListOfCustomer)
            // {
            //     if (customerObj.Phone == Phone)
            //     {
            //         return customerObj;
            //     }
            // }
            // // throw new Exception("No customer was found");
            // return null;
            // // throw new NotImplementedException();
            return storeRepo.GetAll().First(store => store.Phone == p_Phone);
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