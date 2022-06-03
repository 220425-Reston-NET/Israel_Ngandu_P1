using InventoryBL;
using SStoreprojectModel;
using StoreDL;

namespace StoreBL
{
    public class InventoryjoinBL : IinventoryBL
    {
        //========================================
        private IRepository<Inventory> _inventoryRepo;
        public InventoryjoinBL(IRepository<Inventory> p_inventoryRepo)
        {
            _inventoryRepo = p_inventoryRepo;
        }

        public List<Inventory> GetAllInventory()
        {
            return _inventoryRepo.GetAll();
        }

        //=======================================

        public void ReplenishInventoryQuantity(int p_proId, int p_storeID, int p_Quantity, int p_inventory)
        {
            Inventory joinTable = new Inventory();
            joinTable.proId = p_proId;
            joinTable.storeID = p_storeID;
            joinTable.Quantity = p_Quantity;

            _inventoryRepo.Update(joinTable);
        }
    }
}