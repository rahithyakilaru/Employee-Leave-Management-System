﻿using Microsoft.AspNetCore.Identity;
namespace EmployeeLeaveManagementSystem
{
    public class ApplicationUser:IdentityUser
    {
        public string FullName { get; set; }
        public string Role { get; set; }
    }
}
