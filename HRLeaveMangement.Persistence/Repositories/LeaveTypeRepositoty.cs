using HR.LeaveManagement.Application.Contracts.Persistence;
using HRLeaveManagement.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRLeaveMangement.Persistence.Repositories
{
    public class LeaveTypeRepositoty : GenericRepository<LeaveType>, ILeaveTypeRepository
    {
        private readonly HRLeaveMangementDbContext _dbContext;
        public LeaveTypeRepositoty(HRLeaveMangementDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<LeaveType> GetLeaveTypeWithDetails(int id)
        {
            return await _dbContext.LeaveTypes.FindAsync(id);
        }

        public async Task<List<LeaveType>> GetLeaveTypesWithDetails()
        {
            return await _dbContext.LeaveTypes.ToListAsync();
        }
    }
}
