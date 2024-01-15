using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Api_gestion_bibliotheque.Entities
{
    public class Auteur
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public  string Nom { get; set; } = null!;
        public string Biographie { get; set; }
        public DateTime DateNaissance { get; set; }

        public List<string> Oeuvres { get; set; }
    }
}
