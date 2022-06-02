using System.ComponentModel.DataAnnotations;
using SStoreprojectModel;

namespace StoreprojectModel
{
    public class Storefront
    {
        public int _storeID;
        public int storeID
        {

            get { return _storeID; }
            set
            {
                if (value > 0)
                {
                    _storeID = value;
                }
                else
                {
                    throw new ValidationException("Name can only contain Letters");

                }
            }


        }
        
        public string storeName
        {get; set;}
        public string storeAddress { get; set; }

        public List<Products> Products { get; set; }

        public Storefront()
        {
            storeID = 1;
            storeName = "Walmart";
            storeAddress = "1234 farway";
            Products = new List<Products>();
        }

        public override string ToString()
        {
            return $"===Store Info===\nID {storeID}\nName:  {storeName}\nAdress: {storeAddress}\n==============";
        }
       
    }

}
