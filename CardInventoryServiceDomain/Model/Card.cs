using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardInventoryServiceDomain.Model
{
    public class Card
    {
        public Guid Id { get; set; }
        public string CardUser { get; set; } = string.Empty;
        public Guid CardIssuerRef { get; set; }
        public Guid BranchRef { get; set; }
        public DateTime PrintedAt { get; set; }
    }
}
