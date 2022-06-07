using CustomerOrderBL;
using StoreprojectModel;
using StoreDL;


namespace StoreBL
{
    public class CustomerOrderBL : ICustomerOrderBL
    {
        //========================================
        private readonly IRepository<CustomerOrders>  _cusorderRepo;
        public CustomerOrderBL(IRepository<CustomerOrders> p_cusorderRepo)
        {
            _cusorderRepo = p_cusorderRepo;
        }

        public List<CustomerOrders> GetAllCustomerOrders()
        {
            return _cusorderRepo.GetAll();
        }
    }
}
