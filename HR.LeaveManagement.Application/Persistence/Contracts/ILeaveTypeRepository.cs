using HRLeaveManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LeaveManagement.Application.Persistence.Contracts
{
    public interface ILeaveTypeRepository : IGenericRepositoty<LeaveType>
    {
        Task<LeaveType> GetLeaveTypeWithDetails(int id);
        Task<List<LeaveType>> GetLeaveTypesWithDetails();
        Task<LeaveType> Get(int id);
        Task Update(LeaveType leaveType);
    }
}
