using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace StoreprojectModel
{
    public class Customer
    {
        private int _customerID;
        public int customerID
        {
            get { return _customerID; }
            set
            {
                if (value > 0)
                {
                    _customerID = value;
                }
                else
                {
                    throw new ValidationException("customerID needs to be above 0.");

                }
            }
        }
        private string ? _name;
        public string Name
        {
            get { return _name; }
            set
            {

                if (Regex.IsMatch(value, @"^[a-zA-Z]+$"))
                {
                     _name = value;
                }
                else
                {
                    throw new ValidationException("Can only have letters");
                }
            }
        }
        public string Address { get; set; }

        private double _phone;
        public double Phone
        {

            get { return _phone; }
            set
            {
                if (value.ToString().Length == 10)

                {
                    _phone = value;
                }
                else
                {
                    throw new ValidationException("Phone should have 10 Numbers");
                }
            }
        }

        public List<CustomerOrders> CustomerOrders { get; set; }
        public Customer()
        {
            customerID = 1;
            Name = "Walmart";
            Address = "1234 farway";
            Phone = 9197066325;
            CustomerOrders = new List<CustomerOrders>();
        }



        public override string ToString()
        {

            return $"===Customer info===/ncustomerID: {customerID}Name: {Name}/nAddress: {Address}/nPhone: {Phone}/n==========================";

        }

    }
}