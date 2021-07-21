using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PagosWebApi.Models
{
    public class Payment
    {
        /*public Payment(Client client)
        {
            Id = Guid.NewGuid();
            Client = client;
            Console.WriteLine($"El total para {client.Name} es {Bill()}");
            Console.WriteLine(client.Balance >= Total ? IsValid = true : IsValid = false);
        }*/

        public int Id { get; set; }
        public Client Client { get; set; }
        public decimal Total { get; set; }
        public bool IsValid { get; set; }

        public decimal Bill()
        {
            Total = 0;
            if (Client.Cart.Any())
            {
                foreach (var item in Client.Cart) Total += item.Price;

                return Total;
            }

            return Total;
        }
    }
}
