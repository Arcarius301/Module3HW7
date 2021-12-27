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
            _path = $@"{_directoryPath}/{_fileName}";
            Init();
            _streamWriter = new StreamWriter($@"{_directoryPath}/{_fileName}") { AutoFlush = true };
        }

        public string ReadFile(string path)
        {
            return File.ReadAllText(path);
        }

        public void Write(string data)
        {
            _streamWriter.WriteLine(data);
        }

        public void Copy()
        {
            var fileInfo = new FileInfo(_path);
            File.Copy(_path, @$"{_directoryPath}/Backup/{fileInfo.CreationTimeUtc}");
        }

        private void Init()
        {
            if (!Directory.Exists(_path))
            {
                Directory.CreateDirectory(_path);
            }
        }
    }
}