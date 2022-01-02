using System.Threading.Tasks;

namespace Module3HW7.Services.Abstractions
{
    public interface IFileService
    {
        public int LinesCount { get; }
        public Task WriteAsync(string data);
        public void Copy();
    }
}
