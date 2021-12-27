using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module3HW7.Services.Abstractions
{
    public interface IFileService
    {
        public int LinesCount { get; }
        public string ReadFile(string path);
        public Task WriteAsync(string data);
        public void Copy();
    }
}
