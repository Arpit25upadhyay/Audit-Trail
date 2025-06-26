using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuditTrail.Entities.Models
{
    public class AuditMetadata
    {
        public DateTime Timestamp { get; set; }
        public string UserId { get; set; }
        public string EntityName { get; set; }
        public AuditAction Action { get; set; }
    }

}
