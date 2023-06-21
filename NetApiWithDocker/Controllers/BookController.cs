using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NetApiWithDocker.Business;
using NetApiWithDocker.Data.VO;

namespace NetApiWithDocker.Controllers
{
    [ApiVersion("1")] //documentação em github.com/microsoft/aspnet-api-versioning
    [ApiController]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class BookController : ControllerBase
    {
        private readonly ILogger<BookController> _logger;
        private IBookBusiness _bookBusiness;

        public BookController(ILogger<BookController> logger, IBookBusiness bookBusiness)
        {
            _logger = logger;
            _bookBusiness = bookBusiness; // Passando o serviço no construtor do controller, também é preciso injetar essa dependência na classe Startup
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_bookBusiness.FindAll());
        }


        [HttpGet("{id}")] //O metodo pode ter o mesmo nome desde que os paths sejam diferentes para não dar conflito, neste caso é passado o ID para buscar um só objeto.
        public IActionResult Get(long id)
        {
            var book = _bookBusiness.FindById(id);

            if (book == null) return NotFound();

            return Ok(book);
        }


        [HttpPost]
        public IActionResult Post([FromBody] BookVO book) // Vai postar o corpo (objeto Json) com os dados a serem criados
        {
            if (book == null) return BadRequest();

            return Ok(_bookBusiness.Create(book));
        }

        [HttpPut]
        public IActionResult Put([FromBody] BookVO book)
        {
            if (book == null) return BadRequest();

            return Ok(_bookBusiness.Update(book));

        }
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _bookBusiness.Delete(id); // Não está implementado na interface pois ainda não tem nada persistido no banco de dados.

            return NoContent();
        }
    }
}
