using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interfaces
{
   public interface ILoggerException
    {
        void WriteToFile(string message);
    }
}
