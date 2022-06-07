using StoreprojectModel;

namespace StorefrontBL
{
    public interface IStorefrontBL
    {
        Storefront SearchStoreByName(string p_storeName);

        
        void AddProductToStore(Storefront p_store);
        List<Storefront> GetAllStorefront();

        Storefront SearchStoreById(int p_storeID);
        Task<List<Storefront>> GetAllStoreAsync();
        public List<Products> ViewStoreInventory(int p_storeID);
    }
}