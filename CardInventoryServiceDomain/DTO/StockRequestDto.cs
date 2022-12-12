using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardInventoryServiceDomain.DTO
{
    public class StockRequestDto
    {
        public string SupplierName { get; set; } = string.Empty;
        public int QuantitySupplied { get; set; }
        public DateTime DateSupplied { get; set; }
        public string ReceiverName { get; set; } = string.Empty;
    }
}
