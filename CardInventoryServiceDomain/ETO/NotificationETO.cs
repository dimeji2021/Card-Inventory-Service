using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardInventoryServiceDomain.ETO
{
    public class NotificationETO
    {
        public string EmailType { get; set; } = String.Empty;
        public List<Recipients>? ToRecipients { get; set; }
        public string Subject { get; set; } = String.Empty;
        public string Body { get; set; } = String.Empty;
    }
    public class Recipients
    {
        [Required]
        public string? ToAddress { get; set; }

        public string? ToName { get; set; }
    }
}
