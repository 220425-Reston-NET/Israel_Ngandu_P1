using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using OrdersBL;
using StoreprojectModel;
using StoreBL;


namespace StoreprojectApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CustomerController : ControllerBase{
    // =============Dependency injection==========
    private IStoreBL _storeBL;
    private OrderslistBL _orderlist;
    public CustomerController(IStoreBL p_storeBL, OrderslistBL p_orderlist)
    {
        _storeBL = p_storeBL;
        _orderlist = p_orderlist;
        }

    // ===========================================

    [HttpGet("GetAllCustomers")]
    public async Task<IActionResult> GetAllCustomers()
    {
        try{
        List<Customer> listofCurrentCustomer = await _storeBL.GetAllCustomersAsync();
        return Ok(listofCurrentCustomer);
        }
        catch(SqlException) 
        {
            return NotFound("No Customer was found or exists.");
        }
    }

    [HttpPost("AddCustomer")]
    public IActionResult AddCustomer([FromBody]Customer c_cus)
    {
        try
        {
            _storeBL.AddCustomer(c_cus);
            return Created("Customer was added!", c_cus);
        }
        catch (SqlException)
        {
            return Conflict();
        }
    
    }
    [HttpGet("SearchCustomerByName")]
    public IActionResult SearchCustomerByName([FromQuery] string customerName)
    {
        try
        {    
            return Ok(_storeBL.SearchCustomerByName(customerName));
        }
        catch (SqlException)
        {
            return Conflict();
        }

    }
    [HttpGet("SearchCustomerByPhone")]
    public IActionResult SearchCustomerByPhone([FromQuery] double customerPhone)
    {
        try
        {
            return Ok(_storeBL.SearchCustomerByPhone(customerPhone));
        }
        catch (SqlException)
        {
            return Conflict();
        }

    }
    [HttpGet("GetAllOrders")]
    public IActionResult GetAllOrders()
    {
        try
        {
            List<CustomerOrders> listofCurrentOrders = _orderlist.GetAllCustomerOrders();
            return Ok(listofCurrentOrders);
        }
        catch (SqlException)
        {
            return NotFound("No Store was found or exists.");
        }
    }
    [HttpPost("AddProductsToOrders")]
    public IActionResult AddProductsToOrders([FromBody] Orders o_orders)
    {
        try
        {
            _orderlist.AddProductsToOrders(o_orders);
            return Created("Customer was added!", o_orders);
        }
        catch (SqlException)
        {
            return Conflict();
        }

    }
}