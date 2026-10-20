using HR.LeaveManagement.Application.Persistence.Contracts;
using HRLeaveMangement.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HRLeaveMangement.Persistence
{
    public class PersistenceServicesRegistration
    {
        public static IServiceCollection ConfigurePersistenceServices(
            IServiceCollection services,
            IConfiguration configuration)
        { 
            services.AddDbContext<HRLeaveMangementDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("LeaveMangementCoonectionString")));

            services.AddScoped(typeof(IGenericRepositoty<>), typeof(GenericRepository<>));
            services.AddScoped<ILeaveTypeRepository, LeaveTypeRepositoty>();
            services.AddScoped<ILeaveRequestRepository, LeaveRequestRepositoty>();
            services.AddScoped<ILeaveAllocationRepository, LeaveAllocationRepository>();

            return services;
        }
    }
}
