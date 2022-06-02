using SStoreprojectModel;

namespace OrdersBL
{
    public interface IOrdersListBL
    {
            void AddOrdersToOrderlist(Orders p_order);
            List<Orders> GetAllOrdersList();
            Task<List<Orders>> GetAllOrdersAsync();
    }
    
}