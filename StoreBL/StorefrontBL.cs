using StoreDL;
using StoreprojectModel;

namespace StorefrontBL
{
    public class StorelocationBL : IStorefrontBL
    {
        //================== Dependency Injection ====================
        private readonly IRepository<Storefront> _storefrontRepo;
        public StorelocationBL(IRepository<Storefront> p_storefrontRepo)
        {
            _storefrontRepo = p_storefrontRepo;
        }

        //============================================================

        public void AddProductToStore(Storefront p_store)
        {
            _storefrontRepo.Update(p_store);
        }

        public async Task<List<Storefront>> GetAllStoreAsync()
        {
            return await _storefrontRepo.GetAllAsync();
        }

        public List<Storefront> GetAllStorefront()
        {
            return _storefrontRepo.GetAll();
        }

       

        public Storefront SearchStoreById(int p_storeID)
        {
            return _storefrontRepo.GetAll().First(storefront => storefront.storeID == p_storeID);
        }

       

        public Storefront SearchStoreByName(string p_storeName)
        {
            return _storefrontRepo.GetAll().First(storefront => storefront.storeName == p_storeName);
        }

        public List<Products> ViewStoreInventory(int p_storeID)
        {
            List<Storefront> listOfCurrentStore = _storefrontRepo.GetAll();

            foreach (Storefront item in listOfCurrentStore)
            {
                //Condition to return a specific store
                if (item.storeID == p_storeID)
                {
                    return item.Products;
                }
            }

            //It will return nothing if the client specify a store that was never in the database
            return null;
            
        }
    }
}