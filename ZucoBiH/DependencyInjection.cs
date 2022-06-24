using Microsoft.EntityFrameworkCore;

namespace ZucoBiH

{
    public static class DependencyInjection
    {

        public static IServiceCollection AddBackendServices(this IServiceCollection services)
        {
            services.AddDbContext<Context>(options =>
            {

                var dbConnString = @"Server=tcp:znedevtest.database.windows.net,1433;Initial Catalog=ZenDev;Persist Security Info=False;User ID=zendevadmin;Password=Password1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                options.UseSqlServer(dbConnString,
                    dboContextOptions => dboContextOptions.EnableRetryOnFailure(2));
            });

            return services;
        }
    }
}
