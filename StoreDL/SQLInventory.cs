using Microsoft.Data.SqlClient;
using SStoreprojectModel;

namespace StoreDL
{
    public class SQLInventory : IRepository<Inventory>
    {
        //=================== Dependency Injection ==========================
        private string _connectionString;

        public SQLInventory(string p_connectionString)
        {
            this._connectionString = p_connectionString;
        }

        //=====================Dependency Injection ========================

        public void Add(Inventory p_resource)
        {
            throw new NotImplementedException();
        }

        public Task<List<Inventory>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public void Update(Inventory p_resource)
        {
            string SQLquery = @"update inventory
                            set Quantity = @Quantity
                            where storeID = @storeID and proId = @proId";

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();

                SqlCommand command = new SqlCommand(SQLquery, con);

                command.Parameters.AddWithValue("@Quantity", p_resource.Quantity);
                command.Parameters.AddWithValue("@storeID", p_resource.storeID);
                command.Parameters.AddWithValue("@proId", p_resource.proId);

                command.ExecuteNonQuery();
            }
        }

        List<Inventory> IRepository<Inventory>.GetAll()
        {
            string SQLQuery = @"select * from inventory";
            List<Inventory> listOfStores = new List<Inventory>();

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                SqlCommand command = new SqlCommand(SQLQuery, con);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    listOfStores.Add(new Inventory()
                    {
                        storeID = reader.GetInt32(0),
                        proId = reader.GetInt32(1),
                        Quantity = reader.GetInt32(2),
                        InventoryID = reader.GetInt32(2),
                        
                    });
                }

                return listOfStores;
            }
        }
    }
}