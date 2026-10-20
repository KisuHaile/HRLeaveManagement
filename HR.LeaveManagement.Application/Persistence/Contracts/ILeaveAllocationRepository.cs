using HRLeaveManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LeaveManagement.Application.Persistence.Contracts
{
    public interface ILeaveAllocationRepository : IGenericRepositoty<LeaveAllocation>
    {
        Task<LeaveAllocation> GetLeaveAllocationWithDetails(int id);
        Task<List<LeaveAllocation>> GetLeaveAllocationsWithDetails();
    }
}
