using MasterDbStorage.MasterDbContext;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ResearchPortal.Areas.Identity.Configurations;
using ResearchPortal.Areas.Identity.Services;
using ResearchPortal.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResearchPortal.Cofiguration
{
    public static class Dependencies
    {
        public static void SetUp(IConfiguration config, IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    config.GetConnectionString("DefaultConnection")));

            services.AddDefaultIdentity<IdentityUser>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddDbContext<MasterDbContext>(options =>
                    options.UseSqlServer(
                        config.GetConnectionString("DefaultConnection")));

            services.AddTransient<IEmailSender, EmailService>();
            services.AddSingleton<IEmailConfigurations>(config.GetSection("EmailConfiguration").Get<EmailConfigurations>());

            //services.AddScoped<IProductRepository, ProductRepository>()
        }
    }
}
