using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PhoneDirectoryApplication.Helper;
using PhoneDirectoryApplication.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace PhoneDirectoryApplication.Controllers
{
    public class ReportController : Controller
    {
        PersonAPI _api = new PersonAPI();
        // GET: Report
        public async Task<IActionResult> Report()
        {
            List<Report> report = new List<Report>();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync("api/report");
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                report = JsonConvert.DeserializeObject<List<Report>>(result);
            }
            return View(report);
        }

        // GET: Report/Create
        public ActionResult CreateReport()
        {            
            return View();
        }
    }
}
