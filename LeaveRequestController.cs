using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeLeaveManagementSystem
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveRequestController : ControllerBase
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        public LeaveRequestController(ILeaveRequestRepository leaveRequestRepository)
        {
            leaveRequestRepository = _leaveRequestRepository;
        }
        [HttpPost]
        [Authorize(Roles ="Employee")]
        public async Task<IActionResult> ApplyForLeave([FromBody]LeaveRequest leaveRequest)
        {
            leaveRequest.Status = "Pending";
            var createdRequest=_leaveRequestRepository.CreateLeaveRequest(leaveRequest);
            return CreatedAtAction(nameof(GetLeaveRequest), new { id = createdRequest.Id }, createdRequest);
        }
        public IActionResult GetLeaveRequest(int id)
        {
            var leaveRequest =_leaveRequestRepository.GetLeaveRequestById(id);
            if (leaveRequest == null) return NotFound();
            return Ok(leaveRequest);
        }
        [HttpGet("my-leaves")]
        [Authorize(Roles ="Employee")]
        public IActionResult GetMyLeaves()
        {
            var empId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            var leaves = _leaveRequestRepository.GetLeaveRequests()
                .Where(lr => lr.EmployeeId == empId)
                .ToList();
            return Ok(leaves);
        }
        [HttpPut("{id}")]
        [Authorize(Policy="ManagerOnly")]
        public IActionResult ApproveRejectLeave(int id, [FromBody] string status)
        {
            var leaveRequest = _leaveRequestRepository.GetLeaveRequestById(id);
            if (leaveRequest == null)
            {
                return NotFound();
            }
            leaveRequest.Status = status;
            _leaveRequestRepository.UpdateLeaveRequest(leaveRequest);
            return NoContent();
        }
        [HttpGet]
        [Authorize(Policy ="HrOnly")]
        public IActionResult GetAllLeaveRequests()
        {
            var leaveRequests = _leaveRequestRepository.GetLeaveRequests();
            return Ok(leaveRequests);
        }
    }
}
