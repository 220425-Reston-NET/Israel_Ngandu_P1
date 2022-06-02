using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using StoreBL;
using StoreprojectModel;


namespace StoreprojectApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CustomerController : ControllerBase{
    // =============Dependency injection==========
    private IStoreBL _storeBL;
    public CustomerController(IStoreBL p_storeBL)
    {
        _storeBL = p_storeBL;
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
}