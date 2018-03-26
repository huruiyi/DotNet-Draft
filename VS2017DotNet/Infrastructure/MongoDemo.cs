using Infrastructure.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class MongoDemo
    {
        private const string CONNECTION_STRING = "mongodb://root:root@127.0.0.1:27017";
        private const string DB_NAME = "test";
        private const string COLL_NAME = "foo";
        private static MongoClient _client = null;

        public MongoClient Client
        {
            get
            {
                if (_client == null)
                {
                    _client = new MongoClient(CONNECTION_STRING);
                }

                return _client;
            }
        }

        public IMongoCollection<T> GetCollection<T>(string dbName, string collName)
        {
            var db = Client.GetDatabase(dbName);
            return db.GetCollection<T>(collName);
        }

        #region Mongodb Json操作

        public async void InsertOne()
        {
            BsonDocument document = new BsonDocument
            {
                { "name", "SQL Server" },
                { "type", "Database" },
                { "count", 1 },
                { "info", new BsonDocument
                          {
                              { "x", 203 },
                              { "y", 102 }
                          }}
            };

            IMongoCollection<BsonDocument> coll = GetCollection<BsonDocument>(DB_NAME, COLL_NAME);
            await coll.InsertOneAsync(document);
        }

        public async void InsertMany()
        {
            IMongoCollection<BsonDocument> coll = GetCollection<BsonDocument>(DB_NAME, COLL_NAME);
            IEnumerable<BsonDocument> mList = Enumerable.Range(0, 100).Select(x => new BsonDocument
            {
                {"name", "Oracle"+x},
                {"type", "Database"},
                {"count", x},
                {
                    "info", new BsonDocument
                    {
                        {"x", 203+x},
                        {"y", 102+x}
                    }
                }
            });
            await coll.InsertManyAsync(mList);
        }

        public async Task<BsonDocument> SimpleQuery()
        {
            IMongoCollection<BsonDocument> coll = GetCollection<BsonDocument>(DB_NAME, COLL_NAME);
            BsonDocument doc = await coll.Find(new BsonDocument()).FirstOrDefaultAsync();
            return doc;
        }

        public async Task<List<BsonDocument>> SimpleQueryAll()
        {
            IMongoCollection<BsonDocument> coll = GetCollection<BsonDocument>(DB_NAME, COLL_NAME);
            List<BsonDocument> docs = await coll.Find(new BsonDocument()).ToListAsync();
            return docs;
        }

        public async Task<List<BsonDocument>> Query()
        {
            IMongoCollection<BsonDocument> coll = GetCollection<BsonDocument>(DB_NAME, COLL_NAME);
            FilterDefinitionBuilder<BsonDocument> filterBuilder = Builders<BsonDocument>.Filter;
            FilterDefinition<BsonDocument> filter = filterBuilder.Eq("name", "MongoDB") & filterBuilder.Gt("count", 1);
            return await coll.Find(filter).ToListAsync();
        }

        public async Task<UpdateResult> Update()
        {
            IMongoCollection<BsonDocument> coll = GetCollection<BsonDocument>(DB_NAME, COLL_NAME);
            FilterDefinition<BsonDocument> filter = Builders<BsonDocument>.Filter.Eq("name", "MongoDB");
            UpdateDefinition<BsonDocument> update = Builders<BsonDocument>.Update.Set("count", 2);
            return await coll.UpdateOneAsync(filter, update);
        }

        public async Task<DeleteResult> Delete()
        {
            IMongoCollection<BsonDocument> coll = GetCollection<BsonDocument>(DB_NAME, COLL_NAME);
            FilterDefinition<BsonDocument> filter = Builders<BsonDocument>.Filter.Eq("type", "Database");
            return await coll.DeleteManyAsync(filter);
        }

        #endregion Mongodb Json操作

        #region Mongodb Model操作

        public async void InsertOneModel()
        {
            Person person = new Person { Int1 = 1, Int2 = 2, Str1 = "s1", Str2 = "s2" };
            IMongoCollection<Person> col = GetCollection<Person>(DB_NAME, "person");
            await col.InsertOneAsync(person);
        }

        public async void InsertManyModel()
        {
            List<Person> listPersons = new List<Person>
            {
                new Person {Int1 = 1, Int2 = 2, Str1 = "s1", Str2 = "s2"},
                new Person {Int1 = 11, Int2 = 22, Str1 = "s1", Str2 = "s2"},
                new Person {Int1 = 111, Int2 = 222, Str1 = "s1", Str2 = "s2",Int3 = 333},
            };

            IMongoCollection<Person> col = GetCollection<Person>(DB_NAME, "person");
            await col.InsertManyAsync(listPersons);
        }

        #endregion Mongodb Model操作
    }
}