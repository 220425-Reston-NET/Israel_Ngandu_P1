using StoreprojectModel;

namespace OrdersBL
{
    public interface IOrdersListBL
    {
            void AddProductsToOrders(Orders p_order);
            List<Orders> GetAllOrdersList();
            Task<List<Orders>> GetAllOrdersAsync();
            List<CustomerOrders>GetAllCustomerOrders();
    }
    
}