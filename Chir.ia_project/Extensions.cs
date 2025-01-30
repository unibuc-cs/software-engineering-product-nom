using Chir.ia_project.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Chir.ia_project.Services;
using Chir.ia_project.Models.Repository;
using Chir.ia_project.Models.Entities;
using Microsoft.AspNetCore.Http.Features;

namespace Chir.ia_project
{
    public static class Extensions
    {
        public static IServiceCollection AddDbContextAndIdentity(this IServiceCollection services, IConfiguration configuration, IHostEnvironment environment)
        {
            if (environment.IsDevelopment())
            {
                services.AddDbContext<Context>(options => options.UseSqlServer(configuration.GetConnectionString("AZURE_SQL_CONNECTIONSTRING")));
            }
            else
            {
                services.AddDbContext<Context>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            }
            
            services.AddRazorPages();
            services.AddDefaultIdentity<User>()
                .AddEntityFrameworkStores<Context>();

            //builder.Services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<Context>();

            //services.Configure<FormOptions>(options =>
            //{
            //    options.MultipartBodyLengthLimit = 5242880;
            //});

            //services.AddScoped<DbSeeder>();
            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IMovieService, MovieService>()
                .AddScoped<IListingService, ListingService>()
                .AddScoped<IImageService, ImageService>()
                .AddScoped<IListingEngagementService, ListingEngagementService>();

            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services) => services
            .AddScoped<IUnitOfWork, UnitOfWork>()
            .AddScoped<IMovieRepository, MovieRepository>()
            .AddScoped<IUserRepository, UserRepository>()
            .AddScoped<IConversationRepository, ConversationRepository>()
            .AddScoped<IListingRepository, ListingRepository>()
            .AddScoped<IListingEngagementRepository, ListingEngagementRepository>()
            .AddScoped<IMessageRepository, MessageRepository>()
            .AddScoped<IUserConversationRepository, UserConversationRepository>()
            .AddScoped<IImageRepository, ImageRepository>();
    }
}
