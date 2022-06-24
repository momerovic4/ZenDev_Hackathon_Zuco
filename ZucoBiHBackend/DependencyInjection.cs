using Microsoft.EntityFrameworkCore;

namespace ZucoBiHBackend

{
    public static class DependencyInjection
    {

        public static IServiceCollection AddBackendServices(this IServiceCollection services)
        {
            services.AddDbContext<Context>(options =>
            {
           
                var dbConnString = @"";
                options.UseSqlServer(dbConnString,
                    dboContextOptions => dboContextOptions.EnableRetryOnFailure(2));
            });

            return services;
        }
    }
}
