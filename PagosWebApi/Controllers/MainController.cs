using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PagosWebApi.Data;
using PagosWebApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PagosWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MainController : ControllerBase
    {
        private readonly DataContext _context;

        public MainController(DataContext context)
        {
            _context = context;
        }

        // GET: api/<MainController>
        [HttpGet]
        public async Task<IActionResult> GetBill(int client)
        {
            try

            {
                var dbClient = await _context.Clients.FindAsync(client);
                if (dbClient == null) return NotFound(new {Message = "The client has not been found"});

                var Pay = new Payment();
                Pay.Client = dbClient;
                Pay.Total = 0;

                if (dbClient.Cart != null)
                {
                    var message = "";

                    foreach (var item in dbClient.Cart) Pay.Total += item.Price;

                    if (dbClient.Balance >= Pay.Total)
                    {
                        Pay.IsValid = true;
                        message = "valid";
                    }
                    else
                    {
                        Pay.IsValid = false;
                        message = "invalid, insufficient balance";
                    }

                    return Ok(
                        $"Generated {message} bill id {Pay.Id} for client {dbClient.Id} with total of {Pay.Total}");
                }

                return Problem("The cart is empty");
            }
            catch (Exception e)
            {
                return Problem(e.ToString());
            }
        }

        // GET api/<MainController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<MainController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<MainController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> AddItemstoCart(int client, int item)
        {
            try
            {
                var dbClient = await _context.Clients.FindAsync(client);
                if (dbClient == null) return NotFound(new {Message = "The client has not been found"});
                var dbItem = await _context.Items.FindAsync(item);
                if (dbItem == null) return NotFound(new { Message = "The item has not been found" });
                
                dbClient.Cart.Add(dbItem);
                await _context.SaveChangesAsync();

                return Ok("Added item to cart");
            }
            catch (Exception e)
            {
                return Problem(e.ToString());
            }
        }

        // DELETE api/<MainController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}