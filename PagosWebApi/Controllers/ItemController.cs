using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PagosWebApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PagosWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        public readonly List<Item> _items = new()
        {
            new Item {Id = 1, Name = "papel", Price = 800},
            new Item() {Id = 2, Name = "lapiz", Price = 1200}
        };

        // GET: api/<ItemController>
        [HttpGet]
        public ActionResult<IEnumerable<Item>> Get()
        {
            return _items;
        }

        // GET api/<ItemController>/5
        [HttpGet("{id}")]
        public ActionResult<Item> Get(int id)
        {
            var item = _items.FirstOrDefault(c => c.Id == id);
            return item == null ? NotFound(new {Message = "The item has not been found" }) : Ok(item);
        }

        // POST api/<ItemController>
        [HttpPost]
        public ActionResult<IEnumerable<Item>> Post(Item newItem)
        {
            _items.Add(newItem);
            return _items;
        }

        // PUT api/<ItemController>/5
        [HttpPut("{id}")]
        public ActionResult<IEnumerable<Item>> Put(int id, Item updatedItem)
        {
            var item = _items.FirstOrDefault(c => c.Id == id);
            if (item == null) return NotFound(new {Message = "The item has not been found"});
            item.Name = updatedItem.Name;
            item.Price = updatedItem.Price;
            return _items;
        }

        // DELETE api/<ItemController>/5
        [HttpDelete("{id}")]
        public ActionResult<IEnumerable<Item>> Delete(int id)
        {
            var item = _items.FirstOrDefault(c => c.Id == id);
            if (item == null) return NotFound(new { Message = "The item has not been found" });

            _items.Remove(item);
            return _items;
        }
    }
}