using Chir.ia_project.Models.Entities;
using Chir.ia_project.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Chir.ia_project.Services;

namespace Chir.ia_project
{
    public static class Extensions
    {
        public static IServiceCollection AddDbContextAndIdentity(this IServiceCollection services, IConfiguration configuration, IHostEnvironment environment)
        {
            services.AddDbContext<Context>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<AppUser, AppRole>()
                .AddEntityFrameworkStores<Context>()
                .AddDefaultTokenProviders();

            //services.AddScoped<DbSeeder>();
            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IMoviesService, MoviesService>();

            return services;
        }

    }
}
