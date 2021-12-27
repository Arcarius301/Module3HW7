using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Module3HW7.Services.Abstractions;

namespace Module3HW7.Services
{
    public class LoggerService : ILoggerService
    {
        private readonly SemaphoreSlim _semaphoreSlim;
        private readonly IConfigService _configService;
        private readonly IFileService _fileService;
        private readonly int _backupFrequency;
        private int _counter;

        public LoggerService(IConfigService configService, IFileService fileService)
        {
            _configService = configService;
            _fileService = fileService;
            _semaphoreSlim = new SemaphoreSlim(1);
            _counter = _fileService.LinesCount;
            _backupFrequency = _configService.LoggerConfig.BackupFrequency;
        }

        public event Action OnBackup;

        public async Task LogAsync(string message)
        {
            await _semaphoreSlim.WaitAsync();

            if (_counter % _backupFrequency == 0 && _counter != 0)
            {
                OnBackup?.Invoke();
                Console.WriteLine(_counter);
            }

            Console.WriteLine(message);
            await _fileService.WriteAsync(message);
            _counter++;

            _semaphoreSlim.Release();
        }
    }
}
