namespace SStoreprojectModel
{
    public class Orders
    {

        public int _orderID;
        public int orderID
        {
            get { return _orderID; }
            set
            {
                if (value > 0)
                {
                    _orderID = value;
                }
                else
                {
                    Console.WriteLine("orderID cannot be negative");
                }
            }
        }
        public string storeLocations { get; set; }


        public int totalPrice { get; set; }

        public override string ToString()
        {
            return $"=======\nID: {orderID}\nstoreLocations: {storeLocations}\ntotalPrice: {totalPrice}\n=======";
        }
    }
}