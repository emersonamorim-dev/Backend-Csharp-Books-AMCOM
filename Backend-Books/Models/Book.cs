using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Backend_Books.Models
{
    public class Book
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public int Edicao { get; set; }
    }
}
