using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Api_gestion_bibliotheque.Entities
{
    public class Livre
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string? Titre { get; set; } = null!;

        public Auteur Auteur { get; set; } = null!;

        public List<string> Genres { get; set; } = null!;

        public string ISBN { get; set; } = null!;

        public bool Disponibilite { get; set; }

        public DateTime AnneePublication { get; set; }


        [BsonRepresentation(BsonType.ObjectId)]
        public string AuteurId { get; set; }


        [BsonRepresentation(BsonType.ObjectId)]
        public List<string> EmprunteursIds { get; set; } = null!;


        [BsonRepresentation(BsonType.ObjectId)]
        public List<string> EmpruntTransactionsIds { get; set; }
    }
}
