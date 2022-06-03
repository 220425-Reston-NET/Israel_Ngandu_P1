using StoreprojectModel;

namespace CustomerOrderBL
{
    public interface ICustomerOrderBL
    {
        List<CustomerOrders> GetAllCustomerOrders();
    }
}