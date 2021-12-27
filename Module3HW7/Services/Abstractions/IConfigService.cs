using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Module3HW7.Models;

namespace Module3HW7.Services.Abstractions
{
    public interface IConfigService
    {
        public Config Config { get; }
        public LoggerConfig LoggerConfig { get; }
    }
}