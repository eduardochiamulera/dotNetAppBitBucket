using ApiBitBucket.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiBitBucket.Service
{
    public class LogService
    {
        private readonly string LogName = $"{DateTime.Now.ToString("MM-dd-yyyy HH-mm-ss")}-log.txt";
        public void GenerateLog(string url, string logs)
        {
            var path = ApplicationUtils.DefaultDirectory() + LogName;
            if (!File.Exists(path))
                File.Create(path).Close();

            File.AppendAllText(path, url + Environment.NewLine + logs + Environment.NewLine);
        }
    }
}
