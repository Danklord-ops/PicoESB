using Microsoft.Extensions.DependencyInjection;
using Overlord.PicoEsb.Interfaces;

namespace Overlord.PicoEsb
{
    public static class RegisterServices
    {
        public static IServiceCollection RegisterService(this IServiceCollection services)
        {
            return services.AddSingleton<IStackMessage, StackMessage>();
        }
    }
}
