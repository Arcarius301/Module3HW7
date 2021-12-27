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
        private readonly StreamWriter _streamWriter;
        public FileService(string path)
        {
            _streamWriter = new StreamWriter(path) { AutoFlush = true };
        }

        public string ReadFile(string path)
        {
            return File.ReadAllText(path);
        }

        public void Write(string data)
        {
            _streamWriter.WriteLine(data);
        }
    }
}