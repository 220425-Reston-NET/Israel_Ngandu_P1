using System.ComponentModel.DataAnnotations;

namespace StoreprojectModel
{
    public class Orders
    {

        private int _orderID;
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
                    throw new ValidationException("orderID cannot be negative");
                }
            }
        }
        public string? storeLocations { get; set; }


        public int totalPrice { get; set; }

        public int customerID { get; set; }

        public override string ToString()
        {
            return $"=======\nID: {orderID}\nstoreLocations: {storeLocations}\ntotalPrice: {totalPrice}\ncustomerID: {customerID}=======";
        }
    }
}