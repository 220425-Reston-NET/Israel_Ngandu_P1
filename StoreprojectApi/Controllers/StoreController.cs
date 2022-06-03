using System.Security.Cryptography.X509Certificates;
using InventoryBL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using OrdersBL;
using SStoreprojectModel;
using StoreBL;
using StorefrontBL;
using StoreprojectModel;


namespace StoreprojectApi.Controllers;

[ApiController]
[Route("[controller]")]
public class StoreController : ControllerBase
{
    // =============Dependency injection==========
    private IStorefrontBL _storefrontBL;
    private IinventoryBL _inventoryJoin;
    private OrderslistBL _orderlist;
    public StoreController(IStorefrontBL storefrontBL, IinventoryBL inventoryJoin, OrderslistBL orderlist)
    {
        _storefrontBL = storefrontBL;
        _inventoryJoin = inventoryJoin;
         _orderlist = orderlist;
    }
    // ===========================================

    [HttpGet("GetAllStores")]
    public async Task<IActionResult> GetAllStores()
    {
        try
        {
            List<Storefront> listofCurrentStore = await _storefrontBL.GetAllStoreAsync();
            return Ok(listofCurrentStore);
        }
        catch (SqlException)
        {
            return NotFound("No Store was found or exists.");
        }
    }
    [HttpGet("SearchStoreByName")]
    public IActionResult SearchStoreByName([FromQuery] string StoreName)
    {
        try
        {
            return Ok(_storefrontBL.SearchStoreByName(StoreName));
        }
        catch (SqlException)
        {
            return Conflict();
        }

    }

    [HttpGet("SearchStoreByID")]
    public IActionResult SearchStoreByID([FromQuery] int storeID)
    {
        try
        {
            return Ok(_storefrontBL.SearchStoreById(storeID));
        }
        catch (SqlException)
        {
            return Conflict();
        }

    }

    [HttpPut("ReplenishQuantity")]
    public IActionResult ReplenishQuantity([FromBody]Inventory p_inventory )
    {
        Storefront found = _storefrontBL.SearchStoreById(p_inventory.storeID);

        if (found == null)
        {
            return NotFound("Store was not found!");
        }
        
        else
        {
            try
            {
                _inventoryJoin.ReplenishInventoryQuantity(p_inventory.proId, p_inventory.storeID, p_inventory.Quantity, p_inventory.InventoryID);

                return Ok();
            }
            catch (SqlException)
            {
                return Conflict();
            }
        }
    }

    [HttpGet("GetAllInventory")]
    public IActionResult GetAllInventory()
    {
        try
        {
            List<Inventory> listofCurrentInventory = _inventoryJoin.GetAllInventory();
            return Ok(listofCurrentInventory);
        }
        catch (SqlException)
        {
            return NotFound("No Store was found or exists.");
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