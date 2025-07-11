
using ECommerceApp.Application.Interfaces;
using ECommerceApp.Application.Interfaces.Auth;
using ECommerceApp.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceApp.Infrastructure.Seeding;

namespace ECommerceApp.Infrastructure
{
    public static  class InfrastrcutureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services , IConfiguration configuration)
        {
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<ISuperAdminSeeder, SuperAdminSeeder>();

            return services;
        }
    }
}
