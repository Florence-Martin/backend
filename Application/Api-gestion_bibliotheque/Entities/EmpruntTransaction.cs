using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Api_gestion_bibliotheque.Entities
{
    public class EmpruntTransaction
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string LivreId { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string EmprunteurId { get; set; }

        public DateTime DateEmprunt { get; set; }
        public DateTime DateRetourPrevue { get; set; }
        public bool EstRetourne { get; set; }
    }
}
