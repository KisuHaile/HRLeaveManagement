using HR.LeaveManagement.Application.Contracts.Persistence;
using HRLeaveMangement.Persistence;
using HRLeaveMangement.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HRLeaveMangement.Persistence
{
    public static class PersistenceServicesRegistration
    {
        public static IServiceCollection ConfigurePersistenceServices(
            this IServiceCollection services,
            IConfiguration configuration)
        { 
            services.AddDbContext<HRLeaveMangementDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("LeaveManagementConnectionString")));

            services.AddScoped(typeof(IGenericRepositoty<>), typeof(GenericRepository<>));
            services.AddScoped<ILeaveTypeRepository, LeaveTypeRepositoty>();
            services.AddScoped<ILeaveRequestRepository, LeaveRequestRepositoty>();
            services.AddScoped<ILeaveAllocationRepository, LeaveAllocationRepository>();

            return services;
        }
    }
}

namespace HRLeaveMangement.Persistence
{
    public class LeaveMangementDbContextFactory :
        IDesignTimeDbContextFactory<HRLeaveMangementDbContext>
    {
        public HRLeaveMangementDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<HRLeaveMangementDbContext>();
            var connectionString = Environment.GetEnvironmentVariable(
                "LeaveManagementConnectionString");

            builder.UseSqlServer(connectionString);

            return new HRLeaveMangementDbContext(builder.Options);

        }
    }
}
