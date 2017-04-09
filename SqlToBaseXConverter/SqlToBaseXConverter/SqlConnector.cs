using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SqlToBaseXConverter
{
    class SqlConnector:DatabaseConnector
    {
        private string connectionString;
        public SqlConnection connection;
        public static SqlConnector sqlConnector = null;

        public static SqlConnector GetConnector()
        {
            if (sqlConnector == null)
            {
                sqlConnector = new SqlConnector();
                return sqlConnector;
            }
            else
            {
                return sqlConnector;
            }
        }

        public override void Connect(string databaseName)
        {
            GetConnectionSettings();
            connectionString = connectionString.Replace("###databaseName###", databaseName);
            connection = new SqlConnection(connectionString);
        }
        protected override void GetConnectionSettings()
        {
            XmlReader xmlReader = XmlReader.Create(new StreamReader("connectionSettings.xml"));

            xmlReader.ReadToFollowing("sql");
            this.connectionString = xmlReader.ReadElementContentAsString();
        }
    }
}
