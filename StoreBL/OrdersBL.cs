using SStoreprojectModel;
using StoreDL;

namespace OrdersBL
{
    public class OrdersListBL : IOrdersListBL
    {
        //====Dependency Injection====
        private IRepository<Orders> _orderRepo;
        public OrdersListBL(IRepository<Orders> p_orderRepo)
        {
            _orderRepo = p_orderRepo;

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
    }
}