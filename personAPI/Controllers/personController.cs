using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using PersonAPI.Services;
using PersonAPI.Models;

namespace PersonAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class personController : ControllerBase
    {
        private readonly personService _personService;

        public personController(personService personService)
        {
            _personService = personService;
        }

        [HttpGet]
        public List<person> Get()
        {
            var person = _personService.Get();

            if (person == null)
            {
                return null;
            }

            return person;
        }

        [HttpGet("{id}")]
        public person Get(string id)
        {
            var person = _personService.Get(id);

            if (person == null)
            {
                return null;
            }

            return person;
        }

        [HttpPost]
        public IActionResult Post([FromBody] person person)
        {
            _personService.InsertPerson(person);
            return CreatedAtAction(nameof(Get), new { id = person.id }, person);
        }

        [HttpPut("{id}")]
        public IActionResult Update(string id, person updatedPerson)
        {
            _personService.Update(id, updatedPerson);
            updatedPerson.id = id;
            return CreatedAtAction(nameof(Get), updatedPerson);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            _personService.Delete(id);
            return new OkResult();
        }
    }
}
