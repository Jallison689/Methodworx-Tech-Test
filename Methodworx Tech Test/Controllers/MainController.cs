using Microsoft.AspNetCore.Mvc;
using Methodworx_Tech_Test.Data;
using Methodworx_Tech_Test.Models.DTO;
using Methodworx_Tech_Test.Models.Generated;

namespace Methodworx_Tech_Test.Controllers
{
    [ApiController]
    [Route("api")]
    public class MainController : ControllerBase
    {
        private readonly ILogger<MainController> _logger;
        private readonly DatabaseContext _dbContext;

        public MainController(ILogger<MainController> logger, DatabaseContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        [HttpGet("GetAllProducts")]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            try
            {
                return Ok(_dbContext.Products
                .Select(p => new Product
                {
                    ProductID = p.ProductID,
                    ProductName = p.ProductName,
                    ProductDescription = p.ProductDescription,
                    ProductPrice = p.ProductPrice,
                    ProductCount = p.ProductCount
                }).ToList());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("CreateBasket")]
        public async Task<IActionResult> CreateBasket()
        {
            try
            {
                Basket newBasket = new()
                {
                    BasketStatusID = 1
                };
                _dbContext.Baskets.Add(newBasket);
                _dbContext.SaveChanges();
                return Ok(newBasket.BasketID);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("PutItemIntoBasket")]
        public async Task<IActionResult> PutItemInBasket(BasketItem basketItem)
        {
            try
            {
                _dbContext.BasketItems.Add(basketItem);
                _dbContext.SaveChanges();
                return StatusCode(200, "Basket Item Added");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("RemoveItemFromBasket")]
        public async Task<IActionResult> RemoveItemFromBasket(int basketItemID)
        {
            try
            {
                var itemToRemove = _dbContext.BasketItems
                    .Where(bi => bi.BasketItemID == basketItemID)
                    .Select(bi => new BasketItem())
                    .FirstOrDefault();
                _dbContext.BasketItems.Remove(itemToRemove);
                _dbContext.SaveChanges();
                return StatusCode(200, "Basket Item Removed");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("GetBasket")]
        public async Task<ActionResult<List<BasketItemDTO>>> GetBasket(int basketID)
        {
            try
            {
                return Ok(_dbContext.BasketItems
                .Join(
                    _dbContext.Products,
                    bid => bid.ProductId,
                    pid => pid.ProductID,
                    (bid, pid) => new
                    {
                        BasketID = bid.BasketID,
                        BasketItemID = bid.BasketItemID,
                        ProductID = pid.ProductID,
                        ProductName = pid.ProductName,
                        ProductDescription = pid.ProductDescription,
                        ProductPrice = pid.ProductPrice,
                    }
                )
                .Where(jt => jt.BasketID == basketID)
                .Select(jt => new BasketItemDTO
                {
                    BasketItemID = jt.BasketItemID,
                    ProductID = jt.ProductID,
                    ProductName = jt.ProductName,
                    ProductDescription = jt.ProductDescription,
                    ProductPrice = jt.ProductPrice,
                }).ToList());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("CreateOrder")]
        public async Task<ActionResult<int>> CreateOrder(Order order)
        {
            try
            {
                _dbContext.Add(order);
                _dbContext.SaveChanges();
                return order.OrderID;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("CancelOrder")]
        public async Task<IActionResult> CancelOrder(int orderID)
        {
            try
            {
                var itemToUpdate = _dbContext.Orders
                    .Where(o => o.OrderID == orderID)
                    .Select(o => new Order())
                    .FirstOrDefault();
                itemToUpdate.OrderStatusID = 2;
                _dbContext.Orders.Update(itemToUpdate);
                _dbContext.SaveChanges();
                return StatusCode(200, "Basket Item Removed");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }
    }
}
