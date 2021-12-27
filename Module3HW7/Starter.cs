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

        public Starter(ILoggerService loggerService)
        {
            _loggerService = loggerService;
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
    }
}
