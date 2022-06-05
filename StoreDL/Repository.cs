using System.Text.Json;
using StoreprojectModel;

namespace StoreDL
{
    public class  Repository : IRepository<Customer>
    {
        private static string _filepath = "../StoreDL/Data/Storeproject.json";

        public static void AddCustomer(Customer c_cus)
        {
            List<Customer> listOfCus = GetAllCustomers();
            listOfCus.Add(c_cus);

            string jsonString = JsonSerializer.Serialize(listOfCus, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_filepath, jsonString);
        }

        public static Customer AddCustomer()
        {
            throw new NotImplementedException();
        }

        public static List<Customer> GetAllCustomers()
        {
            string jsonString = File.ReadAllText(_filepath);
            List<Customer> listofCustomer = JsonSerializer.Deserialize<List<Customer>>(jsonString);

            return listofCustomer;
        }

        public void Add(Customer p_resource)
        {
            throw new NotImplementedException();
        }

        public List<Customer> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<List<Customer>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public void Update(Customer p_resource)
        {
            throw new NotImplementedException();
        }
    }

}