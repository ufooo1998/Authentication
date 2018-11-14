using System;
using Authentication.Areas.Identity.Data;
using Authentication.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(Authentication.Areas.Identity.IdentityHostingStartup))]
namespace Authentication.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<AuthenticationContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("AuthenticationContextConnection")));

                services.AddDefaultIdentity<AuthenticationUser>()
                    .AddEntityFrameworkStores<AuthenticationContext>();
            });
        }
    }
}