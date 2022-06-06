using StoreprojectModel;

using System.Text.Json;

namespace StoreDL
{
    //This class is responsible for storing and reading our data
    public class CustomerRepository : IRepository<Customer>
    {
        private string _filepath = "../StoreDL/Data/Storeproject.json";

        //Purpose of this method is to add a pokemon to our data
        public void Add(Customer c_cus)
        {
            List<Customer> listOfCus = GetAll();
            listOfCus.Add(c_cus);

            string jsonString = JsonSerializer.Serialize(listOfCus, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_filepath, jsonString);
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
            // Current information from the database
            List<Customer> listOfCustomer = GetAll();

            //Finds the matching customers object in the database
            foreach (Customer CustomerObj in listOfCustomer)
            {
                //Condition to find the same pokemon
                if (CustomerObj.Name == p_resource.Name)
                {

                }
            }

            //Saves this information to the database
            string jsonString = JsonSerializer.Serialize(listOfCustomer, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_filepath, jsonString);
        }


    }
}