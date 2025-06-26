using AuditTrail.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuditTrail.Service.Interface
{
    public interface IAuditTrailService
    {
        List<AuditChange> GetAuditChanges<T>(T before, T after);
    }

}
