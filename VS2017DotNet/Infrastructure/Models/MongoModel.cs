using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Infrastructure.Models
{
    class MongoModel
    {
        private const string _readonly = "dobbi";

        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement]
        public string ReadOnlyProperty { get { return _readonly; } }

        [BsonElement("n", Order = 1)]
        public string Name { get; set; }

        [BsonElement("bd", Order = 2)]
        [BsonDateTimeOptions(DateOnly = true, Kind = DateTimeKind.Local)]
        public DateTime Birthday { get; set; }

        public void Foo()
        {
            BsonDocument book = new BsonDocument
            {
                {"author", "Ernest Hemingway"},
                {"title", "For Whom the Bell Tolls"}
            };
        }
    }

    public enum BsonType
    {
        Double = 0x01,
        String = 0x02,
        Document = 0x03,
        Array = 0x04,
        Binary = 0x05,
        Undefined = 0x06,
        ObjectId = 0x07,
        Boolean = 0x08,
        DateTime = 0x09,
        Null = 0x0a,
        RegularExpression = 0x0b,
        JavaScript = 0x0d,
        Symbol = 0x0e,
        JavaScriptWithScope = 0x0f,
        Int32 = 0x10,
        Timestamp = 0x11,
        Int64 = 0x12,
        MinKey = 0xff,
        MaxKey = 0x7f
    }
}
