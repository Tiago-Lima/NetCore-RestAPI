using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NetApiWithDocker.Model;
using NetApiWithDocker.Services.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetApiWithDocker.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly ILogger<PersonController> _logger;
        private IPersonService _personService;

        public PersonController(ILogger<PersonController> logger, IPersonService personService)
        {
            _logger = logger;
            _personService = personService; // Passando o serviço no construtor do controller, também é preciso injetar essa dependência na classe Startup
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_personService.FindAll());
        }


        [HttpGet("{id}")] //O metodo pode ter o mesmo nome desde que os paths sejam diferentes para não dar conflito, neste caso é passado o ID para buscar um só objeto.
        public IActionResult Get(long id)
        {
            var person = _personService.FindById(id);
            
            if (person == null) return NotFound();

            return Ok(person);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Person person) // Vai postar o corpo (objeto Json) com os dados a serem criados
        {
            if (person == null) return BadRequest();

            return Ok(_personService.Create(person));
        }

        [HttpPut]
        public IActionResult Put([FromBody] Person person)
        {
            if (person == null) return BadRequest();

            return Ok(_personService.Update(person));

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _personService.Delete(id); // Não está implementado na interface pois ainda não tem nada persistido no banco de dados.

            return NoContent();
        }

    }
}
