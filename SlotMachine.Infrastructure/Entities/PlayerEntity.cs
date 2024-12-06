using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SlotMachine.Infrastructure.Entities
{
    internal class PlayerEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public Guid Id { get; set; }
        public long Balance { get; set; }
        public int MatrixWidth { get; set; }
        public int MatrixHeight { get; set; }
    }
}
