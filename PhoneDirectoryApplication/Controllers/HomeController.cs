using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using PhoneDirectoryApplication.Models;
using PhoneDirectoryApplication.Helper;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text;

namespace PhoneDirectoryApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        PersonAPI _api = new PersonAPI();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            List<Person> person = new List<Person>();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync("api/person");
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                person = JsonConvert.DeserializeObject<List<Person>>(result);
            }
            return View(person);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Person person)
        {
            HttpClient client = _api.Initial();

            var postTask = client.PostAsync("api/person", new StringContent(JsonConvert.SerializeObject(person), Encoding.UTF8, "application/json"));
            postTask.Wait();

            var result = postTask.Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        public async Task<IActionResult> Edit(string id)
        {
            Person person = new Person();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync($"api/person/{id}");
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                person = JsonConvert.DeserializeObject<Person>(result);
            }
            return View(person);
        }

        [HttpPost]
        public IActionResult Edit(Person person)
        {
            HttpClient client = _api.Initial();

            var putTask = client.PutAsync($"api/person/{person.id}", new StringContent(JsonConvert.SerializeObject(person), Encoding.UTF8, "application/json"));
            var result = putTask.Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> Delete(string id)
        {
            var person = new Person();
            HttpClient client = _api.Initial();

            HttpResponseMessage res = await client.DeleteAsync($"api/person/{id}");

            return RedirectToAction("Index");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
