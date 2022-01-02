using System;
using System.Threading.Tasks;

namespace Module3HW7.Services.Abstractions
{
    public interface ILoggerService
    {
        public event Action OnBackup;
        public Task LogAsync(string message);
    }
}
