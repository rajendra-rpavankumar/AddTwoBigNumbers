using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AddNumbers.Models;

namespace AddNumbers.Controllers
{
    public class AddTwoNumbersController : ApiController
    {
        ILoggerRepo logRepo;
        INumbersRepo numRepo;
        AddTwoNumbersController()
        {
            logRepo = new LoggerRepoModels();
            numRepo = new NumbersRepoModel(logRepo);
        }

        /// <summary>
        ///  GET Api method for adding two big values
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <returns></returns>
        public string GetAddResult(String num1, String num2)
        {
            string result = numRepo.Add(num1, num2);
            return result;
        }

        /// <summary>
        /// GET Api method for displaying log data
        /// </summary>
        /// <returns>string</returns>
        public string GetLogData()
        {
            string result = logRepo.ReadfromLog();
            return result;
        }
    }
}
