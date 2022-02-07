using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InternalWebApi.Installs
{
    public interface IInstallers
    {
        void InstallServices(IServiceCollection services, IConfiguration configuration);
    }
}