namespace SStoreprojectModel
{
    public class Inventory
    {
        public int storeID { get; set; }
        public int proId { get; set; }
        public int Quantity { get; set; }
        public int InventoryID { get; set; }

        public override string ToString()
        {
            return $"=======\nID: {storeID}\nID: {proId}\nQuantity: {Quantity}\nID: {InventoryID}\n=======";
        }

        //Stephen.pagdilao@revature.com
    }
}