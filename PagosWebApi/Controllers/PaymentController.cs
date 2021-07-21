using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PagosWebApi.Models;
using PagosWebApi.Controllers;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PagosWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        public  List<Payment> _payments = new()
        {
            new Payment
            {
                Id = 1,
                Client = new ClientController()._clients.FirstOrDefault(c => c.Id == 1),
                IsValid = false,
                Total = 0
            },
            new Payment()
            {
                Id = 2,
                Client = new ClientController()._clients.FirstOrDefault(c => c.Id == 2),
                IsValid = false,
                Total = 0
            }
        };

        // GET: api/<PaymentController>
        [HttpGet]
        public ActionResult<IEnumerable<Payment>> Get()
        {
            return _payments;
        }

        // GET api/<PaymentController>/5
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Payment>> Get(int id)
        {
            var payment = _payments.FirstOrDefault(c => c.Id == id);
            return payment == null ? NotFound(new { Message = "The payment has not been found" }) : Ok(payment);
        }

        // POST api/<PaymentController>
        [HttpPost]
        public ActionResult<IEnumerable<Payment>> Post(Payment newPayment)
        {
            _payments.Add(newPayment);
            return _payments;
        }

        // PUT api/<PaymentController>/5
        [HttpPut("{id}")]
        public ActionResult<IEnumerable<Payment>> Put(int id, Payment updatedPayment)
        {
            var payment = _payments.FirstOrDefault(c => c.Id == id);
            if (payment == null) return NotFound(new { Message = "The payment has not been found" });
            payment.Client = updatedPayment.Client;
            payment.IsValid = updatedPayment.IsValid;
            payment.Total = updatedPayment.Total;
            return _payments;
        }

        // DELETE api/<PaymentController>/5
        [HttpDelete("{id}")]
        public ActionResult<IEnumerable<Payment>> Delete(int id)
        {
            var payment = _payments.FirstOrDefault(c => c.Id == id);
            if (payment == null) return NotFound(new {Message = "The payment has not been found"});
            _payments.Remove(payment);
            return _payments;
        }
    }
}
