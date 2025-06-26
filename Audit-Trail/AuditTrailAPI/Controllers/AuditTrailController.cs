using AuditTrail.Entities.Models;
using AuditTrail.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace AuditTrailAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuditTrailController : ControllerBase
    {
        private readonly IAuditTrailService _auditTrailService;

        public AuditTrailController(IAuditTrailService auditTrailService)
        {
            _auditTrailService = auditTrailService;
        }

        [HttpPost("customer")]
        public IActionResult LogCustomerAudit([FromBody] AuditRequest<Customer> request)
        {
            if (request == null || request.Metadata == null)
                return BadRequest("Invalid request.");

            // Validation
            switch (request.Metadata.Action)
            {
                case AuditAction.Created:
                    if (request.After == null || request.Before != null)
                        return BadRequest("For Created, 'after' must be present and 'before' must be null.");
                    break;
                case AuditAction.Updated:
                    if (request.Before == null || request.After == null)
                        return BadRequest("For Updated, both 'before' and 'after' must be present.");
                    break;
                case AuditAction.Deleted:
                    if (request.Before == null || request.After != null)
                        return BadRequest("For Deleted, 'before' must be present and 'after' must be null.");
                    break;
            }

            var changes = _auditTrailService.GetAuditChanges(request.Before, request.After);

            return Ok(new
            {
                Metadata = request.Metadata,
                Changes = changes
            });
        }
    }

}
