using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Module3HW7.Services.Abstractions;

namespace Module3HW7.Services
{
    public class FileService : IFileService
    {
        private readonly IConfigService _configService;
        private readonly StreamWriter _streamWriter;
        private readonly string _directoryPath;
        private readonly string _fileName;
        private readonly string _path;

        public FileService(IConfigService configService)
        {
            _configService = configService;
            _directoryPath = _configService.FileConfig.DirectoryPath;
            _fileName = _configService.FileConfig.FileName;
            _path = Path.Combine(_directoryPath, _fileName);
            Init();
            _streamWriter = new StreamWriter(_path, true) { AutoFlush = true };
        }

        public int LinesCount { get; private set; }
        public string ReadFile(string path)
        {
            return File.ReadAllText(path);
        }

        public void Write(string data)
        {
            _streamWriter.WriteLine(data);
            _streamWriter.Flush();
        }

        public void Copy()
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), _directoryPath, _fileName);
            var destinationPath = Path.Combine(Directory.GetCurrentDirectory(), _directoryPath, "Backup", $"{DateTime.Now.ToString("yyyyMMddHHmmssffffff")}.txt");
            File.Copy(path, destinationPath);
        }

        private void Init()
        {
            if (!Directory.Exists(_directoryPath))
            {
                Directory.CreateDirectory(_directoryPath);
            }

            if (!Directory.Exists($@"{_directoryPath}/Backup"))
            {
                Directory.CreateDirectory($@"{_directoryPath}/Backup");
            }

            DirectoryInfo directoryInfo = new DirectoryInfo(Path.Combine(_directoryPath, "Backup"));
            var lastBackupLines = 0;

            if (directoryInfo.GetFiles().Length != 0)
            {
                lastBackupLines = File.ReadLines(Path.Combine(_directoryPath, "Backup", directoryInfo.GetFiles()
                    .OrderByDescending(f => f.CreationTimeUtc)
                    .First().Name)).Count();
            }

            if (File.Exists(_path))
            {
                LinesCount = File.ReadLines(_path).Count() - lastBackupLines;
            }
        }
    }
}