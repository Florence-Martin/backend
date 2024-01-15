using Api_gestion_bibliotheque.Entities;
using Api_gestion_bibliotheque.Services.Contracts;
using Api_gestion_bibliotheque.Services.Implementations;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api_gestion_bibliotheque.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuteursController : ControllerBase
    {
        private readonly IAuteurService _auteurService;
        public AuteursController(IAuteurService auteurService)
        {
            _auteurService = auteurService ?? throw new ArgumentNullException(nameof(auteurService));
        }

        // GET: api/<AuteursController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        /// <summary>
        /// Obtenir un auteur
        /// </summary>
        /// <param name="id">Obtenir un auteur en fonction de son identifiant</param>
        /// <returns></returns>
        // GET api/<LivresController>/5
        [HttpGet("{id}:length(24)")]
        public async Task<ActionResult> Get(string id)
        {
            var auteur = await _auteurService.GetAuteurByIdAsync(id);
            if (auteur == null)
            {
                return NotFound();
            }
            return Ok(auteur);
        }

        /// <summary>
        /// Créer un nouvel auteur
        /// </summary>
        /// <param name="auteur"></param>
        /// <returns></returns>
        // POST api/<LivresController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Auteur auteur)
        {
            var addedAuteur = _auteurService.CreateAuteur(auteur);
            return Ok(addedAuteur);
        }

        // PUT api/<AuteursController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AuteursController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
