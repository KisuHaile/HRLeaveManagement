using HR.LeaveManagement.Application.Contracts.Persistence;
using HRLeaveManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRLeaveMangement.Persistence.Repositories
{
    public class LeaveAllocationRepository : GenericRepository<LeaveAllocation>, ILeaveAllocationRepository
    {
        private readonly HRLeaveMangementDbContext _dbContext;

        public LeaveAllocationRepository(HRLeaveMangementDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<List<LeaveAllocation>> GetLeaveAllocationsWithDetails()
        {
            throw new NotImplementedException();
        }

        public Task<LeaveAllocation> GetLeaveAllocationWithDetails(int id)
        {
            throw new NotImplementedException();
        }
    }
}
