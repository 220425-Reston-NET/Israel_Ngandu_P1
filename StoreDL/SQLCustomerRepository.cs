using Microsoft.Data.SqlClient;
using StoreprojectModel;

namespace StoreDL
{
    public class SQLCustomerRepository : IRepository<Customer>
    {

        private string _connectionString;

        public SQLCustomerRepository(string p_connectionString)
        {
            this._connectionString = p_connectionString;
        }
        public void Add(Customer p_resource)
        {
            String SQLQuery = @"insert into Customers
                                values(@customerName, @customerAddress, @customerPhone)";

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();

                SqlCommand command = new SqlCommand(SQLQuery, con);

                command.Parameters.AddWithValue("@customerName", p_resource.Name);
                command.Parameters.AddWithValue("@customerAddress", p_resource.Address);
                command.Parameters.AddWithValue("@customerPhone", p_resource.Phone);

                command.ExecuteNonQuery();
            }
        }

        public List<Customer> GetAll()
        {
            String SQLQuery = @"select * from Customers";
            List<Customer> listofCustomer = new List<Customer>();

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();

                SqlCommand command = new SqlCommand(SQLQuery, con);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    listofCustomer.Add(new Customer()
                    {
                        customerID = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Address = reader.GetString(2),
                        Phone = (double)reader.GetDecimal(3)
                    });
                }
                return listofCustomer;
            }


        }

        public async Task<List<Customer>> GetAllAsync()
        {
            String SQLQuery = @"select * from Customers";
            List<Customer> listofCustomer = new List<Customer>();

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                await con.OpenAsync();

                SqlCommand command = new SqlCommand(SQLQuery, con);

                SqlDataReader reader = await command.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {
                    listofCustomer.Add(new Customer()
                    {
                        customerID = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Address = reader.GetString(2),
                        Phone = (double)reader.GetDecimal(3)
                    });
                }
                return listofCustomer;
            }

        }

        private List<Orders> GiveOrdersToCustomers(int orderID)
        {
            string SQLquery = @"select a.orderID, a.storeLocations, a.totalPrice, a.customerID from Orders p
                        inner join orders_products pa on p.customerID = pa.customerID
                        inner join Orders a on a.orderID = pa.orderID
                        where p.orderID = @orderID";

            List<Orders> listOfOrders = new List<Orders>();

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();

                SqlCommand command = new SqlCommand(SQLquery, con);

                command.Parameters.AddWithValue("@orderID", orderID);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    listOfOrders.Add(new Orders()
                    {
                        orderID = reader.GetInt32(0),
                        storeLocations = reader.GetString(1),
                        totalPrice = reader.GetInt32(2),
                        customerID = reader.GetInt32(3),
                    });
                }
            }

            return listOfOrders;
        }


        public void Update(Customer p_resource)
        {
                string SQLquery = @"update Customers
                            set customerName = @customerName, customerAddress = @customerAddress, customerPhone = @customerPhone
                            where customerID = @customerID";

                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    con.Open();

                    SqlCommand command = new SqlCommand(SQLquery, con);
                    command.Parameters.AddWithValue("@customerName", p_resource.Name);
                    command.Parameters.AddWithValue("@customerAddress", p_resource.Address);
                    command.Parameters.AddWithValue("@customerPhone", p_resource.Phone);
                    command.Parameters.AddWithValue("@customerID", p_resource.customerID);

                    command.ExecuteNonQuery();
                }
            }
        }
    }
