using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using SStoreprojectModel;

namespace StoreprojectModel
{
    public class Customer
    {
        public int _customerID;
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
                     new ValidationException("customerID needs to be above 0.");

                }
            }
        }
        public string _name;
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
                     new ValidationException("Can only have letters");
                }
            }
        }
        public string Address { get; set; }

        public double _phone;
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
                    new ValidationException("Phone should have 10 Numbers");
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