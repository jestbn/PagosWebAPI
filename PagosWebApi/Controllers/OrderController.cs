using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PagosWebApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PagosWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        public List<Order> _Orders = new()
        {
            new Order()
            {
                Id = 1,
                Payment = new PaymentController()._payments.FirstOrDefault(z=>z.Id == 1),
                DeliveryAddress = "calle 13"
            },
            new Order()
            {
                Id = 2,
                Payment = new PaymentController()._payments.FirstOrDefault(z => z.Id == 2),
                DeliveryAddress = "Casa grande"
            }
        };
        // GET: api/<OrderController>
        [HttpGet]
        public ActionResult<IEnumerable<Order>> Get()
        {
            return _Orders;
        }

        // GET api/<OrderController>/5
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Order>> Get(int id)
        {
            var order = _Orders.FirstOrDefault(c => c.Id == id);
            return order == null ? NotFound(new { Message = "The order has not been found" }) : Ok(order);
        }

        // POST api/<OrderController>
        [HttpPost]
        public ActionResult<IEnumerable<Order>> Post(Order newOrder)
        {
            _Orders.Add(newOrder);
            return _Orders;

        }

        // PUT api/<OrderController>/5
        [HttpPut("{id}")]
        public ActionResult<IEnumerable<Order>> Put(int id, Order updatedOrder)
        {
            var order = _Orders.FirstOrDefault(c => c.Id == id);
            if (order == null) return NotFound(new { Message = "The order has not been found" });
            order.Payment = updatedOrder.Payment;
            order.DeliveryAddress = updatedOrder.DeliveryAddress;
            return _Orders;
        }

        // DELETE api/<OrderController>/5
        [HttpDelete("{id}")]
        public ActionResult<IEnumerable<Order>> Delete(int id)
        {
            var order = _Orders.FirstOrDefault(c => c.Id == id);
            if (order == null) return NotFound(new { Message = "The order has not been found" });
            _Orders.Remove(order);
            return _Orders;
        }
    }
}
