using AutoMapper;
using IdeaSoft.Test.Api.Domain;
using IdeaSoft.Test.Api.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IdeaSoft.Test.Api.Controllers
{
    [Route("api/person")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _service;
        private readonly IMapper _mapper;

        public PersonController(IPersonService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet("get-by-filter")]
        public ActionResult<List<SearchPersonDto>> GetByFilter([FromQuery] string filter = "")
        {
            var personList = _service.GetPersonByFilter(filter);
            var result = _mapper.Map<List<SearchPersonDto>>(personList);
            return Ok(result);
        }

        [HttpGet("get-by-id/{id}")]

        public ActionResult<UpdatePersonDto> GetById([FromRoute] string id)
        {
            var person = _service.GetPersonById(id);
            if (person == null) return NotFound();

            var personFound = _mapper.Map<UpdatePersonDto>(person);
            return Ok(personFound);
        }

        [HttpPost]
        public async Task<ActionResult> SavePerson([FromBody] SavePersonDto person)
        {
            var newPerson = _mapper.Map<Person>(person);
            await _service.SavePerson(newPerson);
            return Created(string.Empty, newPerson.Id);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult> UpdatePerson([FromRoute] string id, [FromBody] UpdatePersonDto person)
        {
            var lastPerson = _service.GetPersonById(id);
            if (lastPerson == null) return NotFound();

            lastPerson.UpdatePerson(person.Name, person.LastName, person.PhoneNumber);

            await _service.UpdatePerson(id , lastPerson);
            return Created(string.Empty, lastPerson.Id);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> RemovePerson([FromRoute] string id)
        {
            var lastPerson = _service.GetPersonById(id);
            if (lastPerson == null) return NotFound();

            await _service.RemovePerson(id);

            return Ok();
        }
    }
}
