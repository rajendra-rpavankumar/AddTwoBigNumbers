using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AddNumbers.Models;
using System.Configuration;
using System.Net.Http;
using System.Threading.Tasks;

namespace AddNumbers.Controllers
{
    public class ApiCallController : Controller
    {
        string url = null;

        // GET: ApiCall
        public async Task<ActionResult> Index(ApiCallModels model)
        {
            string num1 = model.first;
            string num2 = model.second;
            model.result = String.Empty;
            url = ConfigurationManager.AppSettings["apiUrl"];

            if (model.first != null)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(url);
                    var Res = await client.GetAsync(string.Format("api/AddTwoNumbers/GetAddResult?num1={0}&num2={1}", num1, num2));
                    if (Res.IsSuccessStatusCode)
                    {
                        var response = Res.Content.ReadAsStringAsync().Result;
                        model.result = response.ToString().Trim('"');

                    }
                }
            }
            return View(model);
        }

        public async Task<JsonResult> DisplayLog()
        {

            string url = ConfigurationManager.AppSettings["apiUrl"];
            string result = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                var Res = await client.GetAsync(string.Format("api/AddTwoNumbers/GetLogData"));
                if (Res.IsSuccessStatusCode)
                {
                    var response = Res.Content.ReadAsStringAsync().Result;
                    result = response.ToString();                 

                }
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}