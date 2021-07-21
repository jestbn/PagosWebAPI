using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PagosWebApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PagosWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly List<Client> _clients = new()
        {
            new Client
            {
                Id = 1,
                Name = "Jose",
                Balance = 10000,
                Cart = new List<Item>
                {
                    new() {Id = 1, Name = "papel", Price = 800},
                    new() {Id = 2, Name = "lapiz", Price = 1200}
                }
            },
            new Client()
            {
                Id = 2,
                Name = "Juan",
                Balance = 20000,
                Cart = new List<Item>
                {
                    new() {Id = 3, Name = "aaaa", Price = 800},
                    new() {Id = 4, Name = "bbbb", Price = 1200}
                }
            }
        };

        // GET: api/<ClientController>
        [HttpGet]
        public ActionResult<IEnumerable<Client>> Get()
        {
            return _clients;
        }

        // GET api/<ClientController>/5
        [HttpGet("{id}")]
        public ActionResult<Client> Get(int id)
        {
            var client = _clients.FirstOrDefault(c => c.Id == id);
            return client == null ? NotFound(new {Message = "The client has not been found"}) : Ok(client);
        }

        // POST api/<ClientController>
        [HttpPost]
        public ActionResult<IEnumerable<Client>> Post(Client newClient)
        {
            _clients.Add(newClient);
            return _clients;
        }

        // PUT api/<ClientController>/5
        [HttpPut("{id}")]
        public ActionResult<IEnumerable<Client>> Put(int id, Client updatedClient)
        {
            var client = _clients.FirstOrDefault(c => c.Id == id);
            if (client == null) return NotFound(new {Message = "The client has not been found"});
            client.Name = updatedClient.Name;
            client.Balance = updatedClient.Balance;
            client.Cart = updatedClient.Cart;
            return _clients;
        }

        // DELETE api/<ClientController>/5
        [HttpDelete("{id}")]
        public ActionResult<IEnumerable<Client>> Delete(int id)
        {
            var client = _clients.FirstOrDefault(c => c.Id == id);
            if (client == null) return NotFound(new {Message = "The client has not been found"});
            _clients.Remove(client);
            return _clients;
        }
    }
}