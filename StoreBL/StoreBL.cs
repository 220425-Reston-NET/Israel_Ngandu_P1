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