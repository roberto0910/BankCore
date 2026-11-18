using BankCore.Domain.Common;
using BankCore.Infrastructure.Persistence;
using BankCore.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BankCore.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        // Registrar el DbContext utilizando PostgreSQL (Npgsql)
        services.AddDbContext<BankCoreDbContext>(options => 
        options.UseNpgsql(
            configuration.GetConnectionString("DefaultConnection"),
            b => b.MigrationsAssembly(typeof(BankCoreDbContext).Assembly.FullName)));

        // --- REGISTRO DE REPOSITORIOS Y UNIT OF WORK ---  
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}