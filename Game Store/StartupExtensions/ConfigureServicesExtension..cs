using GameStore.Core.Domain.IdentityEntities;
using GameStore.Core.Domain.RepositoryContracts;
using GameStore.Infrastructure.DbContext;
using GameStore.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using Microsoft.Extensions.Configuration;
namespace Game_Store
{
    public static class ConfigureServicesExtension
    {
        public static void AddGameStoreServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllersWithViews();

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();



            services.AddAuthorization(options =>
            {
                // This will require authentication for ALL endpoints by default
                options.FallbackPolicy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();
            });

            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/account/signin";
            });


            services.AddScoped<IGameRepository, GameRepository>();
            services.AddScoped<IReviewRepository, ReviewRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
        }
    }
}
