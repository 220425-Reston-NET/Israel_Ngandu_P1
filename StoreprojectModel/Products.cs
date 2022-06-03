namespace StoreprojectModel
{
    public class Products
    {
        public int proId { get; set; }
        public string proName { get; set; }

       
        private int _Quantity;
        public int Quantity
        {
            get { return _Quantity; }
            set
            {
                if (value > 0)
                {
                    _Quantity = value;
                }
                else
                {
                    Console.WriteLine("Quantity cannot be negative");
                }
            }
        }

        public int proPrice { get; set; }

        public override string ToString()
        {
            return $"=======\nID: {proId}\nName: {proName}\nQuantity: {Quantity}\nproPrice: {proPrice}\n=======";
        }
    }
}