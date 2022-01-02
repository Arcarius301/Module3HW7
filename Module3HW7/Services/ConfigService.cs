using System.IO;
using Newtonsoft.Json;
using Module3HW7.Models;
using Module3HW7.Services.Abstractions;

namespace Module3HW7.Services
{
    public class ConfigService : IConfigService
    {
        private const string ConfigPath = "config.json";
        private Config _config;

        public ConfigService()
        {
            Init();
        }

        public Config Config => _config;
        public LoggerConfig LoggerConfig => _config.LoggerConfig;

        public FileConfig FileConfig => _config.FileConfig;

        private void Init()
        {
            var configFile = File.ReadAllText(ConfigPath);
            _config = JsonConvert.DeserializeObject<Config>(configFile);
        }
    }
}
