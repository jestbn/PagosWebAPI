using System.Collections.Generic;

namespace PagosWebApi.Models
{
    public class Cart
    {
        public int  Id { get; set; }
        public Client Client { get; set; }
        public List<Item> Items { get; set; }
    }
}