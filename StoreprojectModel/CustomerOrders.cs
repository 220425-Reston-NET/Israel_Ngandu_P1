namespace SStoreprojectModel
{
    public class CustomerOrders
    {
        public int orderID { get; set; }
        public string storeLocations { get; set; }
        public int totalPrice { get; set; }

        public override string ToString()
        {
            return $"=======\nID: {orderID}\nLocations: {storeLocations}\totalPrice: {totalPrice}\n=======";
        }
    }
}