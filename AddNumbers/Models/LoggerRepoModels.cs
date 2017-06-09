using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;

namespace AddNumbers.Models
{
    public class LoggerRepoModels : ILoggerRepo
    {

        public void WritetoLog(String lines)
        {
            StreamWriter sw = null;
            try
            {
                string relativePath = ConfigurationManager.AppSettings["filePath"];
                string fullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, relativePath);
                using (sw = File.AppendText(fullPath))
                {
                    sw.WriteLine(lines);
                    sw.Close();
                }
            }
            catch (Exception ex)
            {
                sw.WriteLine(ex.Message);
            }
        }

        public string ReadfromLog()
        {
            string relativePath = ConfigurationManager.AppSettings["filePath"];
            string fullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, relativePath);
            String line = null;
            try
            {
                using (StreamReader sr = new StreamReader(fullPath))
                {
                    line = sr.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                line = "Could not find file";
            }
            return line;
        }
    }
}