namespace Hospital.UI.Extensions
{
    public static class AuthServiceExtensions
    {
        public static IServiceCollection AddCustomAuth(this IServiceCollection services)
        {
           
            services.AddHttpContextAccessor();

            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30); 
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

           
            services.AddAuthentication("AdminCookie")
                .AddCookie("AdminCookie", options =>
                {
                    options.LoginPath = "/Admin/Account/Login";   
                    options.LogoutPath = "/Admin/Account/Logout"; 
                    options.AccessDeniedPath = "/Error/403";     
                    options.ExpireTimeSpan = TimeSpan.FromMinutes(30); 
                    options.SlidingExpiration = true; 
                    options.Cookie.HttpOnly = true;
                    options.Cookie.IsEssential = true;
                });

           
            services.AddAuthorization();

            return services;
        }
    }
}