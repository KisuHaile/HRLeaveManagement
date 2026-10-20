using HR.LeaveManagement.Application.Contracts.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace HRLeaveMangement.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepositoty<T> where T : class
    {
        private readonly HRLeaveMangementDbContext _dbContext;

        public GenericRepository(HRLeaveMangementDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<T> Add(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<T> Get(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }
        public async Task<IReadOnlyList<T>> GetAll()
               {
                   return await _dbContext.Set<T>().ToListAsync();
               }
        public async Task<bool> Exists(int id)
        {
            var entity = await _dbContext.Set<T>().FindAsync(id);
            return entity != null;
        }

        public async Task Update(T entity)
        {
            _dbContext.Set<T>().Update(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
