using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module3HW7.Models
{
    public class LoggerConfig
    {
        public string FileName { get; set; }
        public string FileExtension { get; set; }
        public string DirectoryPath { get; set; }
        public int BackupFrequency { get; set; }
    }
}
