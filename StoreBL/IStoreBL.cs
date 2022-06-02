using StoreprojectModel;

namespace StoreBL
{
    public interface IStoreBL
    {
        void AddCustomer(Customer c_cus);
        Customer SearchCustomerByName(string name);
        Customer SearchCustomerByPhone(double Phone);
        List<Customer> GetAllCustomers();
        Task<List<Customer>> GetAllCustomersAsync();
    }
}