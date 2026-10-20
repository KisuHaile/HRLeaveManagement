using HRLeaveManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LeaveManagement.Application.Persistence.Contracts
{
    public interface ILeaveRequestRepository : IGenericRepositoty<LeaveRequest>
    {
        Task<LeaveRequest> GetLeaveRequestWithDetails(int id);
        Task<List<LeaveRequest>> GetLeaveRequestsWithDetails();
        Task ChangeApprovalStatus(LeaveRequest leaveRequest, bool? approvalStatus);
    }
}
