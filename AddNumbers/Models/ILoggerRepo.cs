using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AddNumbers.Models
{
    public interface ILoggerRepo
    {
        void WritetoLog(String data);

        string ReadfromLog();
    }
}