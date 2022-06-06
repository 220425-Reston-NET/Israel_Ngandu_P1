using Microsoft.Data.SqlClient;
using StoreprojectModel;

namespace StoreDL
{
    public class SQLStoreRepository : IRepository<Storefront>
    {
        //=================== Dependency Injection ==========================
        private string _connectionString;

        public SQLStoreRepository(string p_connectionString)
        {
            this._connectionString = p_connectionString;
        }

        //=====================Dependency Injection ========================

        public void Add(Storefront p_resource)
        {
            string SQLQuery = @"insert into Storefront 
                                values (@storeID, @storeName, @storeAddress)";

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();

                SqlCommand command = new SqlCommand(SQLQuery, con);

                command.Parameters.AddWithValue("@storeIDe", p_resource.storeID);
                command.Parameters.AddWithValue("@storeName", p_resource.storeName);
                command.Parameters.AddWithValue("@storeAddress", p_resource.storeAddress);

                command.ExecuteNonQuery();
            }
        }

        List<Storefront> IRepository<Storefront>.GetAll()
        {
            string SQLQuery = @"select * from Storefront";
            List<Storefront> listOfStores = new List<Storefront>();

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                SqlCommand command = new SqlCommand(SQLQuery, con);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    listOfStores.Add(new Storefront()
                    {
                        storeID = reader.GetInt32(0),
                        storeName = reader.GetString(1),
                        storeAddress = reader.GetString(2),
                        Products = GiveProductsToStorefront(reader.GetInt32(0))
                    });
                }

                return listOfStores;
            }
        }

        private List<Products> GiveProductsToStorefront(int storeID)
        {
            string SQLquery = @"select a.proId, a.proName, pa.Quantity, a.proPrice from Storefront p
                        inner join inventory pa on p.StoreID = pa.StoreID
                        inner join Products a on a.proId = pa.proId
                        where p.storeID = @storeID";

            List<Products> listOfProducts = new List<Products>();

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();

                SqlCommand command = new SqlCommand(SQLquery, con);

                command.Parameters.AddWithValue("@storeID", storeID);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    listOfProducts.Add(new Products()
                    {
                        proId = reader.GetInt32(0),
                        proName = reader.GetString(1),
                        Quantity = reader.GetInt32(2),
                        proPrice = reader.GetInt32(3),
                    });
                }
            }

            return listOfProducts;
        }

        public async Task<List<Storefront>> GetAllAsync()
        {
            string SQLQuery = @"select * from Storefront";
            List<Storefront> listOfStores = new List<Storefront>();

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                await con.OpenAsync();
                SqlCommand command = new SqlCommand(SQLQuery, con);
                SqlDataReader reader = command.ExecuteReader();

                while (await reader.ReadAsync())
                {
                    listOfStores.Add(new Storefront()
                    {
                        storeID = reader.GetInt32(0),
                        storeName = reader.GetString(1),
                        storeAddress = reader.GetString(2),
                        Products = GiveProductsToStorefront(reader.GetInt32(0))
                    });
                }
                return listOfStores;
            }
        }

        public void Update(Storefront p_resource)
        {
            throw new NotImplementedException();
        }
    }
}