﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module3HW7.Services.Abstractions
{
    public interface IFileService
    {
        public string ReadFile(string path);
        public void Write(string data);
    }
}
