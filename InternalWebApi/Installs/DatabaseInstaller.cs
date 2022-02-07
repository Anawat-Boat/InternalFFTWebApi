using InternalWebApi.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InternalWebApi.Installs
{
    public class DatabaseInstaller : IInstallers
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            string mySqlConnectionStr = configuration.GetConnectionString("ConnectionMySQL");
            services.AddDbContext<DatabaseContext>(options => options.UseMySql(mySqlConnectionStr, ServerVersion.AutoDetect(mySqlConnectionStr)));
        }
    }
}