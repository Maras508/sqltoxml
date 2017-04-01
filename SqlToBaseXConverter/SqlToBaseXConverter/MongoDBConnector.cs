using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlToBaseXConverter
{
    class MongoDBConnector: DatabaseConnector
    {
        public static MongoDBConnector mongoDBConnector;
        private MongoClient client;
        public IMongoDatabase database;

        public static MongoDBConnector GetConnector()
        {
            if (mongoDBConnector == null)
            {
                mongoDBConnector = new MongoDBConnector();
                return mongoDBConnector;
            }
            else
            {
                return mongoDBConnector;
            }
        }

        public override void Connect(string databaseName)
        {
            client = new MongoClient();
            database = client.GetDatabase(databaseName);
        }
    }
}
