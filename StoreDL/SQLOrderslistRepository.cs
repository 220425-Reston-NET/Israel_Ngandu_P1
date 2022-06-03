using Microsoft.Data.SqlClient;
using StoreprojectModel;
using StoreDL;

namespace StoreDL
{
    public class SQLOrderslistRepository : IRepository<CustomerOrders>
    {
        //=================== Dependency Injection ==========================
        private string _connectionString;

        public SQLOrderslistRepository(string p_connectionString)
        {
            this._connectionString = p_connectionString;
        }
        //=====================Dependency Injection ========================
        public void Add(CustomerOrders p_resource)
        {
            String SQLQuery = @"insert into orders_products
                                values(@orderID, @proId, @quantity)";
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();

                SqlCommand command = new SqlCommand(SQLQuery, con);

                command.Parameters.AddWithValue("@orderID", p_resource.orderID);
                command.Parameters.AddWithValue("@proId", p_resource.proId);
                command.Parameters.AddWithValue("@quantity", p_resource.quantity);

                command.ExecuteNonQuery();
            }
        }

        public List<CustomerOrders> GetAll()
        {
            String SQLQuery = @"select * from orders_products";
            List<CustomerOrders> listofCustomerOrders = new List<CustomerOrders>();

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();

                SqlCommand command = new SqlCommand(SQLQuery, con);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    listofCustomerOrders.Add(new CustomerOrders()
                    {
                        orderID = reader.GetInt32(0),
                        proId = reader.GetString(1),
                        quantity = reader.GetInt32(2),
                    });
                }
                return listofCustomerOrders;
            }
        }
        public async Task<List<CustomerOrders>> GetAllAsync()
        {
            String SQLQuery = @"select * from orders_products";
            List<CustomerOrders> listofCustomerOrders = new List<CustomerOrders>();

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                await con.OpenAsync();

                SqlCommand command = new SqlCommand(SQLQuery, con);

                SqlDataReader reader = await command.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {
                    listofCustomerOrders.Add(new CustomerOrders()
                    {
                        orderID = reader.GetInt32(0),
                        proId = reader.GetString(1),
                        quantity = reader.GetInt32(2),
                    });
                }
                return listofCustomerOrders;
            }
        }

        public void Update(CustomerOrders p_resource)
        {
            string SQLquery = @"update orders_products
                            set quantity = @quantity
                            where orderID = @orderID and proId = @proId";

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();

                SqlCommand command = new SqlCommand(SQLquery, con);

                command.Parameters.AddWithValue("@quantity", p_resource.quantity);
                command.Parameters.AddWithValue("@orderID", p_resource.orderID);
                command.Parameters.AddWithValue("@proId", p_resource.proId);

                command.ExecuteNonQuery();
            }
        }
    }
}

      