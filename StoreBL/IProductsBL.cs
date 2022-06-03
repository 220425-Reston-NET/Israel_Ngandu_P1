using StoreprojectModel;


namespace ProductsBL
{
    public interface IProductsBL
    {
        
        List<Products> GetAllProducts();
        Products SearchProductByName(string p_proName);
        Task<List<Products>> GetAllProductssAsync();
    }
}