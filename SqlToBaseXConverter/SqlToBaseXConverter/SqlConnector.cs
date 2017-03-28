using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            this.connectionString = "Data Source=MAREK-KOMPUTER;Initial Catalog=" + databaseName + ";Integrated Security=true;";
            this.connection = new SqlConnection(connectionString);
        }
    }
}
