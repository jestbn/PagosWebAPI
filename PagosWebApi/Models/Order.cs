using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PagosWebApi.Models
{
    public class Order
    {
        public int Id { get; init; }
        public DateTime PurchasedDate { get; set; } = DateTime.Now;
        public Payment Payment { get; set; }

        public string DeliveryAddress { get; set; }
    }
}
