using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace infrastructure;

public static class DependencyInjection
{


    public static IServiceCollection AddInfrustucture(this IServiceCollection services, IConfiguration configuration)
    {

             
        services.AddDbContext<ApplicationDbContext>(option =>
        {
            option.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));                
            option.EnableSensitiveDataLogging();                                
            
        });



        return services;
    }


}