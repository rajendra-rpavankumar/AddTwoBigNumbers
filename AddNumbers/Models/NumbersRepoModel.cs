using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Numerics;
using System.Text.RegularExpressions;

namespace AddNumbers.Models
{
    public class NumbersRepoModel : INumbersRepo
    {
        public ILoggerRepo logRepo;     
        public NumbersRepoModel(ILoggerRepo tempLoggerRepoModels)
        {
            this.logRepo = tempLoggerRepoModels;
        }
        public string Add(string num1, string num2)
        {
            bool value1 = CheckInput(num1);
            bool value2 = CheckInput(num2);
            if (value1 == false || value2 == false)
            {
                return "Enter valid data with only numeric and integer values";
            }
            BigInteger n1 = BigInteger.Parse(num1);
            BigInteger n2 = BigInteger.Parse(num2);
            String result = BigInteger.Add(n1, n2).ToString();
            LogData(num1, num2, result);
            return result;
        }


        public bool CheckInput(string number)
        {
            Regex reNum = new Regex(@"^[-+]?\d+$");
            return reNum.Match(number).Success;

        }

        private void LogData(string num1, string num2, string result)
        {
            string time = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString().ToString();
            string logvalue = time + "," + num1 + "," + num2 + "," + result;
            logRepo.WritetoLog(logvalue);
        }
    }
}