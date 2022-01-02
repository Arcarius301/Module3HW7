using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Module3HW7.Services.Abstractions;

namespace Module3HW7.Services
{
    public class FileService : IFileService
    {
        private readonly IConfigService _configService;
        private readonly SemaphoreSlim _semaphoreSlim;
        private readonly StreamWriter _streamWriter;
        private readonly string _logName;
        private readonly string _logDirectoryPath;
        private readonly string _backupDirectoryPath;
        private readonly string _logPath;
        private readonly string _absolutePath;

        public FileService(IConfigService configService)
        {
            _configService = configService;
            _semaphoreSlim = new SemaphoreSlim(1);

            _logName = _configService.FileConfig.LogName;
            _logDirectoryPath = _configService.FileConfig.LogPath;
            _backupDirectoryPath = _configService.FileConfig.BackupPath;
            _logPath = Path.Combine(_logDirectoryPath, _logName);
            _absolutePath = Directory.GetCurrentDirectory();

            Init();
            _streamWriter = new StreamWriter(_logPath, true);
        }

        public int LinesCount { get; private set; }

        public async Task WriteAsync(string data)
        {
            await _semaphoreSlim.WaitAsync();

            await _streamWriter.WriteLineAsync(data);
            await _streamWriter.FlushAsync();

            _semaphoreSlim.Release();
        }

        public void Copy()
        {
            var path = Path.Combine(_absolutePath, _logPath);
            var destinationPath = Path.Combine(_absolutePath, _backupDirectoryPath, $"{DateTime.UtcNow.ToString("yyyyMMddHHmmssffffff")}.txt");
            File.Copy(path, destinationPath);
        }

        private void Init()
        {
            if (!Directory.Exists(_logDirectoryPath))
            {
                Directory.CreateDirectory(_logDirectoryPath);
            }

            if (!Directory.Exists(_backupDirectoryPath))
            {
                Directory.CreateDirectory(_backupDirectoryPath);
            }
            else
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(_backupDirectoryPath);

                if (directoryInfo.GetFiles().Length != 0 && File.Exists(_logPath))
                {
                    var lastBackupLines = File.ReadLines(Path.Combine(_backupDirectoryPath, directoryInfo.GetFiles()
                        .OrderByDescending(f => f.CreationTimeUtc)
                        .First().Name))
                        .Count();

                    LinesCount = File.ReadLines(_logPath).Count() - lastBackupLines;
                }
            }
        }
    }
}