using Microsoft.Extensions.Configuration;
using ApplicationLayer.Interfaces;
using InfrastructureLayer.Auth;
using InfrastructureLayer.Data;
using InfrastructureLayer.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
namespace InfrastructureLayer;
using ApplicationLayer.Mappings;
using ApplicationLayer.Services;

public static class DependencyInjection
    {
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        // Exempel: Lägg till din DbContext här
        services.AddDbContext<Bite2DbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        // Lägg till dina repos
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddScoped<IUserService, UserService>();
        // 👉 Lägg till AutoMapper-registreringen här:
        services.AddAutoMapper(typeof(MappingProfile).Assembly);

        return services;
    }

}


