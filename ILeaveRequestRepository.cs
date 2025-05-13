using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeLeaveManagementSystem
{
    public interface ILeaveRequestRepository
    {
        IEnumerable<LeaveRequest> GetLeaveRequests();
        LeaveRequest GetLeaveRequestById(int id);
        LeaveRequest CreateLeaveRequest(LeaveRequest leaveRequest);
        void UpdateLeaveRequest(LeaveRequest leaveRequest);
        void DeleteLeaveRequest(int id);
    }
    public class LeaveRequestRepository: ILeaveRequestRepository
    {
        private readonly AppDbContext _context;

        public IEnumerable<LeaveRequest> GetLeaveRequests()
        {
            var leavesList = _context.LeaveRequests.Include(e => e.Employee).ToList();
            return leavesList;
        }

        public LeaveRequest GetLeaveRequestById(int id)
        {
            var leave = _context.LeaveRequests.Include(lr => lr.Employee).FirstOrDefault(lr => lr.Id == id);
            return leave;
        }

        public LeaveRequest CreateLeaveRequest(LeaveRequest leaveRequest)
        {
            _context.LeaveRequests.Add(leaveRequest);
            _context.SaveChanges();
            return leaveRequest;
        }


        public void UpdateLeaveRequest(LeaveRequest leaveRequest)
        {
            _context.LeaveRequests.Update(leaveRequest);
            _context.SaveChanges();
        }

        public void DeleteLeaveRequest(int id)
        {
            var leave = _context.LeaveRequests.Find(id);
            if (leave != null)
            {
                _context.LeaveRequests.Remove(leave);
                _context.SaveChanges();
            }
        }
    }
}
