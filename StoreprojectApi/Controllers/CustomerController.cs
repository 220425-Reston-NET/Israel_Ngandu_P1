using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using OrdersBL;
using StoreprojectModel;
using StoreBL;
using Serilog;

namespace StoreprojectApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CustomerController : ControllerBase
{
    // =============Dependency injection==========
    private readonly IStoreBL _storeBL;
    private readonly IOrdersListBL _orderlist;
    public CustomerController(IStoreBL p_storeBL, IOrdersListBL p_orderlist)
    {
        _storeBL = p_storeBL;
        _orderlist = p_orderlist;
    }

    // ===========================================

    [HttpGet("GetAllCustomers")]
    public async Task<IActionResult> GetAllCustomers()
    {
        try
        {
            Log.Warning("Getting all customer");
            List<Customer> listofCurrentCustomer = await _storeBL.GetAllCustomersAsync();
            return Ok(listofCurrentCustomer);
        }
        catch (SqlException)
        {
            Log.Warning("Exception found");
            return NotFound("No Customer was found or exists.");
        }
    }

    [HttpPost("AddCustomer")]
    public IActionResult AddCustomer([FromBody] Customer c_cus)
    {
        try
        {
            Log.Warning("Adding new customer");
            _storeBL.AddCustomer(c_cus);
            return Created("Customer was added!", c_cus);
        }
        catch (SqlException)
        {
            Log.Warning("Exception found");
            return Conflict();
        }

    }
    [HttpGet("SearchCustomerByName")]
    public IActionResult SearchCustomerByName([FromQuery] string customerName)
    {
        try
        {
            Log.Warning("Search Customer By Name");
            return Ok(_storeBL.SearchCustomerByName(customerName));
        }
        catch (SqlException)
        {
            Log.Warning("Exception found");
            return Conflict();
        }

    }
    [HttpGet("SearchCustomerByPhone")]
    public IActionResult SearchCustomerByPhone([FromQuery] double customerPhone)
    {
        try
        {
            Log.Warning("Search Customer By Phone");
            return Ok(_storeBL.SearchCustomerByPhone(customerPhone));
        }
        catch (SqlException)
        {
            Log.Warning("Exception found");
            return Conflict();
        }

    }
    [HttpGet("GetAllOrders")]
    public IActionResult GetAllOrders()
    {
        try
        {
            Log.Warning("Get All Orders");
            List<CustomerOrders> listofCurrentOrders = _orderlist.GetAllCustomerOrders();
            return Ok(listofCurrentOrders);
        }
        catch (SqlException)
        {
            Log.Warning("Exception found");
            return NotFound("No Store was found or exists.");
        }
    }
    [HttpPost("AddProductsToOrders")]
    public IActionResult AddProductsToOrders([FromBody] Orders o_orders)
    {
        try
        {
            Log.Warning("Add Products To Orders");
            _orderlist.AddProductsToOrders(o_orders);
            return Created("Customer was added!", o_orders);
        }
        catch (SqlException)
        {
            Log.Warning("Exception found");
            return Conflict();
        }

    }
}