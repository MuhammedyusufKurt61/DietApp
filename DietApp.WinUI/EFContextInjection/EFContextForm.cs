using DietApp.BLL;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DietApp.WinUI.EFContextInjection
{
    public static class EFContextForm
    {
        private static IServiceProvider _serviceProvider;

        private static IHostBuilder CreateHostBuilder<T>() where T : Form
        {
            var result = Host.CreateDefaultBuilder()
                             .ConfigureServices((context, services) =>
                             {
                                 services.AddScopeBLL();
                                 services.AddTransient<T>();
                             });

            return result;
        }

        public static Form ConfigureServices<T>() where T : Form
        {
            var host = CreateHostBuilder<T>().Build();
            _serviceProvider = host.Services;
            return _serviceProvider.GetRequiredService<T>();
        }
    }
}
