using Api_gestion_bibliotheque.Configurations;
using Api_gestion_bibliotheque.Entities;
using Api_gestion_bibliotheque.Services.Contracts;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Api_gestion_bibliotheque.Services.Implementations
{
    public class AuteurService : IAuteurService
    {
        private readonly IMongoCollection<Auteur> _auteurCollection;
        public AuteurService(IMongoClient mongoClient, IOptions<MongoDbSettings> options)
        {
            var database = mongoClient.GetDatabase(options.Value.DatabaseName);
            _auteurCollection = database.GetCollection<Auteur>(options.Value.AuthorsCollectionName);
        }

        /// <summary>
        /// Création d'un auteur
        /// </summary>
        /// <param name="auteurToCreate"></param>
        /// <returns></returns>
        public async Task<Auteur> CreateAuteur(Auteur auteurToCreate)
        {
            await _auteurCollection.InsertOneAsync(auteurToCreate);
            return auteurToCreate;
        }

        /// <summary>
        /// Obtenir l'auteur par son identifiant
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Auteur> GetAuteurByIdAsync(string id)
        {
            try
            {
                return await _auteurCollection.Find(x => x.Id == id).SingleAsync();
            }
            catch (Exception a)
            {
                Console.WriteLine(a);
                throw;
            }
        }
    }
}
