using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(WebApplication15.Startup))]

namespace WebApplication15
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(
                 options => options.AddPolicy("AllowMyOrigin", buider => buider.WithOrigins("http://localhost:3000", "http://sndapp.spikotech.com").AllowAnyMethod().AllowAnyHeader()
                  ));
        }

    }
}
