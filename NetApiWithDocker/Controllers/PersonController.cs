using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NetApiWithDocker.Business.Implementations;
using NetApiWithDocker.Data.VO;
using NetApiWithDocker.Hypermedia.Filters;

namespace NetApiWithDocker.Controllers
{
    [ApiVersion("1")] //documentação em github.com/microsoft/aspnet-api-versioning
    [ApiController]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class PersonController : ControllerBase
    {
        private readonly ILogger<PersonController> _logger;
        private IPersonBusiness _personBusiness;

        public PersonController(ILogger<PersonController> logger, IPersonBusiness personBusiness)
        {
            _logger = logger;
            _personBusiness = personBusiness; // Passando o serviço no construtor do controller, também é preciso injetar essa dependência na classe Startup
        }

        [HttpGet]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get()
        {
            return Ok(_personBusiness.FindAll());
        }


        [HttpGet("{id}")] //O metodo pode ter o mesmo nome desde que os paths sejam diferentes para não dar conflito, neste caso é passado o ID para buscar um só objeto.
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get(long id)
        {
            var person = _personBusiness.FindById(id);
            
            if (person == null) return NotFound();

            return Ok(person);
        }

        [HttpPost]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Post([FromBody] PersonVO person) // Vai postar o corpo (objeto Json) com os dados a serem criados
        {
            if (person == null) return BadRequest();

            return Ok(_personBusiness.Create(person));
        }

        [HttpPut]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Put([FromBody] PersonVO person)
        {
            if (person == null) return BadRequest();

            return Ok(_personBusiness.Update(person));

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _personBusiness.Delete(id); // Não está implementado na interface pois ainda não tem nada persistido no banco de dados.

            return NoContent();
        }

    }
}
