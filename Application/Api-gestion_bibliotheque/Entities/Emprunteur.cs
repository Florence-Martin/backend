using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Api_gestion_bibliotheque.Entities
{
    public class Emprunteur
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public required string Nom { get; set; } = null!;
        public required string Adresse { get; set; } = null!;
        public required string NumeroTelephone { get; set; } = null!;

        [BsonRepresentation(BsonType.ObjectId)]
        public List<string> LivresEmpruntes { get; set; }
    }
}
