using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Module3HW7.Models;
using Module3HW7.Services;
using Module3HW7.Services.Abstractions;

namespace Module3HW7
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                           .AddSingleton<ILoggerService, LoggerService>()
                           .AddTransient<IConfigService, ConfigService>()
                           .AddSingleton<IFileService, FileService>()
                           .AddTransient<Starter>()
                           .BuildServiceProvider();

            var starter = serviceProvider.GetService<Starter>();
            await starter?.Run();
        }
    }
}
