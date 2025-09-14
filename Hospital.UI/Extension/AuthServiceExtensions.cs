using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Hospital.UI.Extensions
{
    public static class AuthServiceExtensions
    {
        public static IServiceCollection AddCustomAuth(this IServiceCollection services)
        {
            // HttpContextAccessor (Session için gerekli)
            services.AddHttpContextAccessor();

            // Session
            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30); // 30 dk sonra session düşer
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            // Cookie Authentication
            services.AddAuthentication("AdminCookie")
                .AddCookie("AdminCookie", options =>
                {
                    options.LoginPath = "/Admin/Account/Login";   // Login sayfası
                    options.LogoutPath = "/Admin/Account/Logout"; // Logout sayfası
                    options.AccessDeniedPath = "/Error/403";      // Yetkisiz erişim
                    options.ExpireTimeSpan = TimeSpan.FromMinutes(30); // 30 dk
                    options.SlidingExpiration = true; // her request süresini uzatır
                    options.Cookie.HttpOnly = true;
                    options.Cookie.IsEssential = true;
                });

            // Authorization
            services.AddAuthorization();

            return services;
        }
    }
}