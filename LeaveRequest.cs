﻿namespace EmployeeLeaveManagementSystem
{
    public class LeaveRequest
    {
        public int Id { get; set; }
        public string EmployeeId { get; set; }
        public string LeaveType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Status { get; set; }
        public ApplicationUser Employee { get; set; }
    }
}
