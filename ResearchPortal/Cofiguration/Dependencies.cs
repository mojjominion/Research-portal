using MasterDbStorage.DbRespository;
using MasterDbStorage.DbRespository.Interfaces;
using MasterDbStorage.MasterDbContext;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ResearchPortal.Areas.Identity.Configurations;
using ResearchPortal.Areas.Identity.Services;

namespace ResearchPortal.Cofiguration
{
    public static class Dependencies
    {
        public static void SetUp(IConfiguration config, IServiceCollection services)
        {
            services.AddDefaultIdentity<IdentityUser>()
                .AddEntityFrameworkStores<MasterDBContext>();
            //options.UseSqlServer(connection, b => b.MigrationsAssembly("ResearchPortal"))
            services.AddDbContext<MasterDBContext>(options =>
                options.UseSqlServer(config.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly("ResearchPortal")));

            services.AddTransient<IEmailSender, EmailService>();
            services.AddSingleton<IEmailConfigurations>(config.GetSection("EmailConfiguration").Get<EmailConfigurations>());

            services.AddScoped<IArticlesRepository, ArticleRepository>();
        }
    }
}
