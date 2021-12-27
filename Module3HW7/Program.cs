using System;
using Microsoft.Extensions.DependencyInjection;
using Module3HW7.Models;
using Module3HW7.Services;
using Module3HW7.Services.Abstractions;

namespace Module3HW7
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                           .AddSingleton<ILoggerService, LoggerService>()
                           .AddTransient<IConfigService, ConfigService>()
                           .AddTransient<IFileService, FileService>()
                           .AddTransient<Starter>()
                           .BuildServiceProvider();
            var app = serviceProvider.GetService<Starter>();
            app?.Run();
        }
    }
}
