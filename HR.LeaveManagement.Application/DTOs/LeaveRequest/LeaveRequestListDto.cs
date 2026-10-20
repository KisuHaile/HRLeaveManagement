using HR.LeaveManagement.Application.DTOs.LeaveType;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LeaveManagement.Application.DTOs.LeaveRequest
{
    public class LeaveRequestListDto
    {
        public LeaveTypeDto LeaveType { get; set; }
        public DateTime StartDate { get; set; }
        public bool? Approved { get; set; }
    }
}
