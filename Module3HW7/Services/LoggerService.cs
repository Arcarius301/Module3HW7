using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Module3HW7.Services.Abstractions;

namespace Module3HW7.Services
{
    public class LoggerService : ILoggerService
    {
        private readonly IConfigService _configService;
        private readonly IFileService _fileService;
        private readonly int _backupFrequency;
        private int _counter = 0;

        public LoggerService(IConfigService configService, IFileService fileService)
        {
            _configService = configService;
            _fileService = fileService;
            _backupFrequency = _configService.LoggerConfig.BackupFrequency;
        }

        public void Log(string message)
        {
            _counter++;
            if (_counter % _backupFrequency == 0)
            {
                _fileService.Copy();
            }

            Console.WriteLine(message);
            _fileService.Write(message);
        }
    }
}
