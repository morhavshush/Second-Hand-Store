using Services.Interfaces;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Services.ServicesFolder
{
    public class Logger : ILoggerException
    {
        string _fileName = "ErrorMessageFile.txt";
        public void WriteToFile(string message)
        {
            StreamWriter writer=null;
            try
            {
                using (writer = new StreamWriter(_fileName, true))
                {
                    writer.WriteLine(DateTime.Now.ToString() + "\n" + message + "\n");
                }
            }
            finally
            {
                if (writer != null)
                    writer.Dispose();
            }
        }
    }
}
