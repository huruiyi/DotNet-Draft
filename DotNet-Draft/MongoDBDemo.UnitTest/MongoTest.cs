using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using Infrastructure;
using Xunit;

namespace MongoDBDemo.UnitTest
{
    public class MongoTest
    {
        private static readonly MongoDemo Test;
        private const string DbName = "test";
        private const string CollName = "foo";

        static MongoTest()
        {
            Test = new MongoDemo();
        }

        [Fact]
        public void should_return_client()
        {
            try
            {
                Assert.IsType<MongoClient>(Test.Client);
            }
            catch
            {
                Assert.True(false);
            }
        }

        [Fact]
        public void should_return_collection()
        {
            IMongoCollection<BsonDocument> actual = Test.GetCollection<BsonDocument>(DbName, CollName);
            Assert.IsAssignableFrom<IMongoCollection<BsonDocument>>(actual);
        }

        [Fact]
        public void should_insert_one_succeed()
        {
            try
            {
                Test.InsertOne();
                Assert.True(true);
            }
            catch (Exception)
            {
                Assert.True(false);
            }
        }

        [Fact]
        public void should_insert_many_succeed()
        {
            try
            {
                Test.InsertMany();
                Assert.True(true);
            }
            catch
            {
                Assert.True(false);
            }
        }

        [Fact]
        public void should_return_single_doc()
        {
            BsonDocument actual = Test.SimpleQuery().Result;
            Assert.IsType<BsonDocument>(actual);
        }

        [Fact]
        public void should_return_all_doc()
        {
            List<BsonDocument> actual = Test.SimpleQueryAll().Result;
            IMongoCollection<BsonDocument> coll = Test.GetCollection<BsonDocument>(DbName, CollName);
            long count = coll.CountAsync(new BsonDocument()).Result;

            Assert.Equal(actual.Count, count);
        }

        [Fact]
        public void should_return_delete_succeed()
        {
            DeleteResult actual = Test.Delete().Result;
            Assert.True(actual.IsAcknowledged);
            // Assert.Equal(1, actual.DeletedCount);
        }
    }
}