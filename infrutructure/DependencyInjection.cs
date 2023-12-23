using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace infrutructure;

public static class DependencyInjection
{


    public static IServiceCollection AddInfrustucture(this IServiceCollection services, IConfiguration configuration)
    {

        // services.AddIdentity<Account, Role>(options =>
        //     {
        //         options.User.RequireUniqueEmail = false;
        //         options.Password.RequireNonAlphanumeric = false;
        //         options.Password.RequireDigit = false;
        //         options.Password.RequireLowercase = false;
        //         options.Password.RequireUppercase = false;
        //
        //     })
        //     .AddEntityFrameworkStores<ApplicationDbContext>();
        //     
        // services.AddDbContext<ApplicationDbContext>(option =>
        // {
        //     option.UseLazyLoadingProxies()                
        //         .UseSqlServer(configuration.GetConnectionString("DefaultConnection"));                
        //     option.LogTo(Console.WriteLine,LogLevel.Information);
        //     option.EnableSensitiveDataLogging();                                
        //
        // });



        return services;
    }


}