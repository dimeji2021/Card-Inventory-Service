using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardInventoryServiceDomain.DTO
{
    public class CardRequestDto
    {
        public string CardUser { get; set; } = string.Empty;
        public Guid CardIssuerRef { get; set; }
        public Guid BranchRef { get; set; }
    }
}
