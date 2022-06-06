namespace StoreprojectModel
{
    public class CustomerOrders
    {
        public int orderID { get; set; }
        public string? proId { get; set; }
        public int quantity { get; set; }

        public override string ToString()
        {
            return $"=======\nID: {orderID}\nID: {proId}\nquantity: {quantity}\n=======";
        }
    }
}