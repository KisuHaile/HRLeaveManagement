using HRLeaveManagement.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRLeaveManagement.Domain
{
    public class LeaveRequest : BaseDomainEntity
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int LeaveTypeId { get; set; }
        public DateTime DateRequested { get; set; }
        public DateTime DataActioned { get; set; }
        public bool? Approved { get; set; }
        public bool Cancelled { get; set; }

    }
}
