using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SqlToBaseXConverter
{
    class MongoDBConnector: DatabaseConnector
    {
        public static MongoDBConnector mongoDBConnector;
        private MongoClient client;
        public IMongoDatabase database;
        private string connectionString;

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
            GetConnectionSettings();
            client = new MongoClient(connectionString);
            database = client.GetDatabase(databaseName);
        }

        protected override void GetConnectionSettings()
        {
            XmlReader xmlReader = XmlReader.Create(new StreamReader("connectionSettings.xml"));

            xmlReader.ReadToFollowing("mongoDB");
            this.connectionString = xmlReader.ReadElementContentAsString();
        }
    }
}
