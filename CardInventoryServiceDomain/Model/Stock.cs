using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardInventoryServiceDomain.Model
{
    public class Stock
    {
        public Guid Id { get; set; }
        public string SupplierName { get; set; } = String.Empty;
        public string ReceiverName { get; set; } = String.Empty ;
        public DateTime DateSupplied { get; set; } 
        public DateTime DateReceived { get; set; }
        public int QuantityReceived { get; set; }
    }
}