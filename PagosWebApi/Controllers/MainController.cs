using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        // GET: api/GetInvoice/<MainController>
        /// <summary>
        ///     Generates invoice for the customer with the associated items
        /// </summary>
        /// <param name="client"> Client Id</param>
        /// <param name="idItem">List of Items by </param>
        /// <returns></returns>
        [HttpGet]
        //[ActionName("GetInvoice")]

        public async Task<IActionResult> GetInvoice(int client, int idItem)
        {
            try
            {
                var dbClient = await _context.Clients.FindAsync(client);
                if (dbClient == null) return NotFound(new { Message = "The client has not been found" });

                var Pay = new Payment();
                Pay.Client = dbClient;
                Pay.Total = 0;

                await AddItemsToCart(dbClient.Id, idItem);

                if (dbClient.Cart != null)
                {
                    var message = "";

                    foreach (var item in dbClient.Cart) Pay.Total += item.Price;

                    if (dbClient.Balance >= Pay.Total)
                    {
                        Pay.IsValid = true;
                        message = "valid invoice";
                    }
                    else
                    {
                        Pay.IsValid = false;
                        message = "invalid invoice, insufficient balance";
                    }

                    _context.Payments.Add(Pay);
                    await _context.SaveChangesAsync();
                    return Ok($"Generated {message} ; id {Pay.Id} for client {dbClient.Id} with total of {Pay.Total}");
                }

                return Problem("The cart is empty");
            }
            catch (Exception e)
            {
                return Problem(e.ToString());
            }
        }

        [HttpPost]
        //[ActionName("AddItemToCart")]

        public async Task<ActionResult<Client>> AddItemsToCart(int client, int item)
        {
            try
            {

                var dbClient = await _context.Clients.FindAsync(client);
                if (dbClient == null) return NotFound(new { Message = "The client has not been found" });
                var dbItem = await _context.Items.FindAsync(item);
                if (dbItem == null) return NotFound(new { Message = "The item has not been found" });
                var carrito = dbClient.Cart;

                if (dbClient.Cart == null) dbClient.Cart = new List<Item>();

                dbClient.Cart.Add(dbItem);
                _context.Entry(dbClient).State = EntityState.Modified;

                await _context.SaveChangesAsync();
                return Ok(dbClient);
            }
            catch (Exception e)
            {
                return Problem(e.ToString());
            }
        }

    }
}