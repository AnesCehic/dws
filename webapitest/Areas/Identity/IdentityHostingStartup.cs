using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using webapitest.Areas.Identity.Data;
using webapitest.Models;

[assembly: HostingStartup(typeof(webapitest.Areas.Identity.IdentityHostingStartup))]
namespace webapitest.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<webapitestContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("webapitestContextConnection")));

                services.AddDefaultIdentity<webapitestUser>()
                    .AddEntityFrameworkStores<webapitestContext>();
            });
        }
    }
}