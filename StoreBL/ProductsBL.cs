using StoreprojectModel;
using StoreDL;

namespace ProductsBL
{
    public class StoreproductBL : IProductsBL
    {
        //====Dependency Injection====
        private readonly IRepository<Products> _proRepo;
        public StoreproductBL(IRepository<Products> p_proRepo)
        {
            _proRepo = p_proRepo;

        //============================
    }

        public List<Products> GetAllProducts()
        {
            return _proRepo.GetAll();
        }

        public async Task<List<Products>> GetAllProductssAsync()
        {
            return await _proRepo.GetAllAsync();
        }

        public Products SearchProductByName(string p_proName)
        {
            return _proRepo.GetAll().First(store => store.proName == p_proName);
        }
    }
}