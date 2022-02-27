using Microsoft.AspNetCore.Mvc;
using PersonAPI.Models;
using PersonAPI.Services;
using System.Collections.Generic;

namespace personAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class reportController : ControllerBase
    {
        private readonly reportService _reportService;

        public reportController(reportService reportService)
        {
            _reportService = reportService;
        }

        [HttpGet]
        public ActionResult<List<report>> Get()
        {
            var report = _reportService.Get();

            if (report == null)
            {
                return null;
            }

            return report;
        }
    }
}
