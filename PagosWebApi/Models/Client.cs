using System;
using System.Collections.Generic;

namespace PagosWebApi.Models
{
    public class Client
    {
        /*
        public Client(string name, decimal balance)
        {
            Id = Guid.NewGuid();
            Name = name;
            Balance = balance;
            Cart = new List<Item>();
            CreationDateTime = DateTime.Now;
        }*/

        public int Id { get; set; } 
        public string Name { get; set; }
        public decimal Balance { get; set; }
        private DateTime CreationDateTime { get; set; } = DateTime.Now;

        public List<Item> Cart { get; set; }
    }
}