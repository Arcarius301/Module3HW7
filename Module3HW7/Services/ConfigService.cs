using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Module3HW7.Services.Abstractions;
using Module3HW7.Models;

namespace Module3HW7.Services
{
    public class ConfigService : IConfigService
    {
        private const string ConfigPath = "config.json";
        private readonly IFileService _fileService;
        private Config _config;

        public ConfigService(IFileService fileService)
        {
            _fileService = fileService;
            Init();
        }

        public Config Config => _config;
        public LoggerConfig LoggerConfig => _config.LoggerConfig;

        private void Init()
        {
            var configFile = _fileService.ReadFile(ConfigPath);
            _config = JsonConvert.DeserializeObject<Config>(configFile);
        }
    }
}
