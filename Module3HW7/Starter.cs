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

        public async Task Run()
        {
            var list = new List<Task>();
            list.Add(Task.Run(async () => { await FirstMethod(); }));
            list.Add(Task.Run(async () => { await SecondMethod(); }));
            await Task.WhenAll(list);
        }

        public async Task FirstMethod()
        {
            for (var i = 1; i <= 50; i++)
            {
                var j = i;
                await _loggerService.LogAsync($"{nameof(FirstMethod)}: {j}");
            }
        }

        public async Task SecondMethod()
        {
            for (var i = 1; i <= 50; i++)
            {
                var j = i;
                await _loggerService.LogAsync($"{nameof(SecondMethod)}: {j}");
            }
        }

        private void MakeBackup()
        {
            _fileService.Copy();
        }
    }
}
