using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace LSSD.Registration.Data
{
    public class MongoDbConnection
    {
        MongoClient _client;
        public IMongoDatabase DB;

        public MongoDbConnection(string ConnectionString)
        {
            MongoUrl connectionString = new MongoUrl(ConnectionString);
            _client = new MongoClient(connectionString);
            DB = _client.GetDatabase(connectionString.DatabaseName);
        }

        public MongoDbConnection(string ConnectionString, string DatabaseName)
        {
            _client = new MongoClient(ConnectionString);
            DB = _client.GetDatabase(DatabaseName);
        }




    }
}
