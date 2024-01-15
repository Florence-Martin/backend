using Api_gestion_bibliotheque.Configurations;
using Api_gestion_bibliotheque.Entities;
using Api_gestion_bibliotheque.Services.Contracts;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Api_gestion_bibliotheque.Services.Implementations
{
    public class LivreService : ILivreService
    {
        private readonly IMongoCollection<Livre> _livreCollection;

        //private readonly IMongoCollection<Emprunteur> _emprunteurCollection;
        //private readonly IMongoCollection<EmpruntTransaction> _empruntTransactionCollection;
        //private readonly IMongoCollection<EmpruntRetour> _retourTransactionCollection;

        public LivreService(IMongoClient mongoClient, IOptions<MongoDbSettings> options)
        {
            var database = mongoClient.GetDatabase(options.Value.DatabaseName);
            _livreCollection = database.GetCollection<Livre>(options.Value.BooksCollectionName);
            //_auteurCollection = database.GetCollection<Auteur>(options.Value.AuthorsCollectionName);
            //_emprunteurCollection = database.GetCollection<Emprunteur>(options.Value.BorrowersCollectionName);
            //_empruntTransactionCollection = database.GetCollection<EmpruntTransaction>(options.Value.LoanTransactionCollectionName);
            //_retourTransactionCollection = database.GetCollection<EmpruntRetour>(options.Value.LoanReturnCollectionName);
        }
        
        /// <summary>
        /// Création d'un livre
        /// </summary>
        /// <param name="livreToCreate"></param>
        /// <returns></returns>
        public async Task<Livre> CreateLivre(Livre livreToCreate)
        {
            await _livreCollection.InsertOneAsync(livreToCreate);
            return livreToCreate;
        }

        /// <summary>
        /// Obtenir le livre par son identifiant
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Livre> GetLivreByIdAsync(string id)
        {
            return await _livreCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
        }
    }
}
