using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PagosWebApi.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public Client Client { get; set; }
        public decimal Total { get; set; }
        public bool IsValid { get; set; }

    }
}
