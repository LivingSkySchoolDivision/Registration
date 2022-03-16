using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace LSSD.Registration.Data
{
     public class MongoDbConnection
    {
        readonly MongoClient _client;
        public readonly IMongoDatabase DB;

        public MongoDbConnection(string ConnectionString)
        {
            MongoUrl connectionString = new MongoUrl(ConnectionString);

            var pack = new ConventionPack();
            pack.Add(new IgnoreExtraElementsConvention(true));
            ConventionRegistry.Register("My Solution Conventions", pack, t => true);

            _client = new MongoClient(connectionString);
            DB = _client.GetDatabase(connectionString.DatabaseName);
        }

        public MongoDbConnection(string ConnectionString, string DatabaseName)
        {
            _client = new MongoClient(ConnectionString);

            var pack = new ConventionPack();
            pack.Add(new IgnoreExtraElementsConvention(true));
            ConventionRegistry.Register("My Solution Conventions", pack, t => true);

            DB = _client.GetDatabase(DatabaseName);
        }
    }
}
