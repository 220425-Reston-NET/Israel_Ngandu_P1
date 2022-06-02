using SStoreprojectModel;

namespace InventoryBL
{
    public interface IinventoryBL
    {
        void ReplenishInventoryQuantity(int p_proId, int p_storeID, int p_Quantity, int p_inventory);
        List<Inventory> GetAllInventory();
    }
}