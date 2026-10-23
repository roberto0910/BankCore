using BankCore.Infrastructure.Persistence;
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

        return services;
    }
}