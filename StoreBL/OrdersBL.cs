using StoreprojectModel;
using StoreDL;

namespace OrdersBL
{
    public class OrderslistBL : IOrdersListBL
    {
        //====Dependency Injection====
        private IRepository<Orders> _orderRepo;
        private IRepository<CustomerOrders> _cusorderRepo;
        public OrderslistBL(IRepository<Orders> p_orderRepo, IRepository<CustomerOrders> P_cusorderRepo)
        {
            _orderRepo = p_orderRepo;
            _cusorderRepo = P_cusorderRepo;
        }
        //==============================

        public void AddOrdersToOrderlist(Orders p_order)
        {
            _orderRepo.Update(p_order);
        }

        public async Task<List<Orders>> GetAllOrdersAsync()
        {
            return await _orderRepo.GetAllAsync();
        }

        public List<Orders> GetAllOrdersList()
        {
            return _orderRepo.GetAll();
        }

        public List<CustomerOrders> GetAllCustomerOrders()
        {
            return _cusorderRepo.GetAll();
        }

        public void AddProductsToOrders(Orders p_order)
        {
            _orderRepo.Update(p_order);
        }
    }
}