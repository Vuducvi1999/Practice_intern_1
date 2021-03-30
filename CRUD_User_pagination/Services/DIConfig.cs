using Microsoft.Extensions.DependencyInjection;
using Services.Jwt;
using Services.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public static class DIConfig
    {
        public static void Config(IServiceCollection services)
        {
            services.AddTransient<IProductServices,ProductServices>();
            services.AddTransient<IJwtToken, JwtToken>();
        }
    }
}
