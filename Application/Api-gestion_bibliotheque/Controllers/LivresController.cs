using Api_gestion_bibliotheque.Entities;
using Api_gestion_bibliotheque.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api_gestion_bibliotheque.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivresController : ControllerBase
    {
        private readonly ILivreService _livreService;
        public LivresController(ILivreService livreService)
        {
            _livreService = livreService;
        }

        // GET: api/<LivresController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        /// <summary>
        /// Obtenir un livre
        /// </summary>
        /// <param name="id">Obtenir un livre en fonction de son identifiant</param>
        /// <returns></returns>
        // GET api/<LivresController>/5
        [HttpGet("{id}:length(24)")]
        public async Task<ActionResult> Get(string id)
        {
            var livre = await _livreService.GetLivreByIdAsync(id);
            if (livre == null)
            {
                return NotFound();
            }
            return Ok(livre);
        }

        /// <summary>
        /// Créer un nouveau livre
        /// </summary>
        /// <param name="livre"></param>
        /// <returns></returns>
        // POST api/<LivresController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Livre livre)
        {
            var addedLivre = _livreService.CreateLivre(livre);
            return Ok(addedLivre);
        }

        // PUT api/<LivresController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<LivresController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
