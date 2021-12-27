using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Module3HW7.Services;
using Module3HW7.Services.Abstractions;
using Module3HW7.Models;
using Newtonsoft.Json;

namespace Module3HW7
{
    public class Starter
    {
        private readonly ILoggerService _loggerService;
        private readonly IFileService _fileService;

        public Starter(ILoggerService loggerService, IFileService fileService)
        {
            _loggerService = loggerService;
            _fileService = fileService;
            _loggerService.OnBackup += () => MakeBackup();
        }

        public void Run()
        {
            FirstMethod();
            SecondMethod();
        }

        public void FirstMethod()
        {
            for (var i = 1; i <= 50; i++)
            {
                var j = i;
                _loggerService.Log($"{nameof(FirstMethod)}: {j}");
            }
        }

        public void SecondMethod()
        {
            for (var i = 1; i <= 50; i++)
            {
                var j = i;
                _loggerService.Log($"{nameof(SecondMethod)}: {j}");
            }
        }

        private void MakeBackup()
        {
            _fileService.Copy();
        }
    }
}
