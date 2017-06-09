using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AddNumbers.Models
{
    public interface INumbersRepo
    {
        String Add(string num1, string num2);
    }
}