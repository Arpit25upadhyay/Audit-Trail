using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuditTrail.Entities.Models
{
    public class AuditRequest<T>
    {
        public T Before { get; set; }
        public T After { get; set; }
        public AuditMetadata Metadata { get; set; }
    }

}
