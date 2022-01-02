using Module3HW7.Models;

namespace Module3HW7.Services.Abstractions
{
    public interface IConfigService
    {
        public Config Config { get; }
        public LoggerConfig LoggerConfig { get; }
        public FileConfig FileConfig { get; }
    }
}