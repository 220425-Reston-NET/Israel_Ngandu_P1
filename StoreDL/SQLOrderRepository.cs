using Microsoft.Data.SqlClient;
using StoreprojectModel;


namespace StoreDL
{
    public class SQLOrdersRepository : IRepository<Orders>
    {
        //=================== Dependency Injection ==========================
        private string _connectionString;

        public SQLOrdersRepository(string p_connectionString)
        {
            this._connectionString = p_connectionString;
        }
        //=====================Dependency Injection ========================

        public void Add(Orders p_resource)
        {
            String SQLQuery = @"insert into Orders
                                values(@orderID, @storeLocations, @totalPrice, @customerID)";

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();

                SqlCommand command = new SqlCommand(SQLQuery, con);

                command.Parameters.AddWithValue("@orderID", p_resource.orderID);
                command.Parameters.AddWithValue("@storeLocations", p_resource.storeLocations);
                command.Parameters.AddWithValue("@totalPrice", p_resource.totalPrice);
                command.Parameters.AddWithValue("@customerID", p_resource.customerID);

                command.ExecuteNonQuery();
            }
        }

        public List<Orders> GetAll()
        {
            String SQLQuery = @"select * from Orders";
            List<Orders> listofOrders = new List<Orders>();

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();

                SqlCommand command = new SqlCommand(SQLQuery, con);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    listofOrders.Add(new Orders()
                    {
                        orderID = reader.GetInt32(0),
                        totalPrice = reader.GetInt32(1),
                        storeLocations = reader.GetString(2),
                        customerID = reader.GetInt32(3),
                    });
                }
                return listofOrders;
            }
        }

        public async Task<List<Orders>> GetAllAsync()
        {
            String SQLQuery = @"select * from Orders";
            List<Orders> listofOrders = new List<Orders>();

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
               await con.OpenAsync();

                SqlCommand command = new SqlCommand(SQLQuery, con);

                SqlDataReader reader = await command.ExecuteReaderAsync();

                while (reader.Read())
                {
                    listofOrders.Add(new Orders()
                    {
                        orderID = reader.GetInt32(0),
                        totalPrice = reader.GetInt32(1),
                        storeLocations = reader.GetString(2),
                        customerID = reader.GetInt32(3),
                    });
                }
                return listofOrders;
            }
        }

        public void Update(Orders p_resource)
        {
            string SQLquery = @"update Orders
                            set totalPrice = @totalPrice
                            where orderID = @orderID and customerId = @customerId";

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();

                SqlCommand command = new SqlCommand(SQLquery, con);
                command.Parameters.AddWithValue("@orderID", p_resource.orderID);
                command.Parameters.AddWithValue("@storeLocations", p_resource.storeLocations);
                command.Parameters.AddWithValue("@totalPrice", p_resource.totalPrice);
                command.Parameters.AddWithValue("@customerID", p_resource.customerID);

                command.ExecuteNonQuery();
            }
        }
    
    }
}
      