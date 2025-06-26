using AuditTrail.Entities.Models;
using AuditTrail.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuditTrail.Service.Service
{
    public class AuditTrailService : IAuditTrailService
    {
        public List<AuditChange> GetAuditChanges<T>(T before, T after)
        {
            var changes = new List<AuditChange>();
            var props = typeof(T).GetProperties();

            foreach (var prop in props)
            {
                var oldValue = before == null ? null : prop.GetValue(before);
                var newValue = after == null ? null : prop.GetValue(after);

                if (!Equals(oldValue, newValue))
                {
                    changes.Add(new AuditChange
                    {
                        PropertyName = prop.Name,
                        OldValue = oldValue,
                        NewValue = newValue
                    });
                }
            }

            return changes;
        }
    }

}
