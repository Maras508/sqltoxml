using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlToBaseXConverter
{
    class DatabaseHelper
    {
        private List<string> tablesNames;
        public Dictionary<string, Tuple<int, List<string>>> tablesInfo;
        private SqlConnector sqlconnector;

        public DatabaseHelper(SqlConnector sqlconnector)
        {
            this.tablesInfo = new Dictionary<string, Tuple<int, List<string>>>();
            this.sqlconnector = sqlconnector;
        }
        private List<string> GetTablesNames()
        {
            List<string> tables = new List<string>();

            SqlCommand command = new SqlCommand("Select * From INFORMATION_SCHEMA.TABLES", sqlconnector.connection);

            sqlconnector.connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            try
            {
                while (reader.Read())
                {
                    tables.Add(reader["TABLE_NAME"].ToString());
                }
            }
            finally
            {
                // Always call Close when done reading.
                reader.Close();
                sqlconnector.connection.Close();
            }
            return tables;
        }

        public void GetTablesInfo()
        {
            tablesNames = this.GetTablesNames();
            int numberOfRows=0;
            List<string> columnNames;

            foreach(string name in tablesNames)
            {
                //pobieranie ilości wierszy w danej tabeli
                SqlCommand command = new SqlCommand("Select Count(*) AS number From " + name + ";", sqlconnector.connection);

                sqlconnector.connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        numberOfRows = Int32.Parse(reader["number"].ToString());
                    }
                }
                finally
                {
                    // Always call Close when done reading.
                    reader.Close();
                    sqlconnector.connection.Close();
                }

                //pobieranie nazw kolumn poszczególnej tabeli
                columnNames = new List<string>();

                SqlCommand command2 = new SqlCommand("Select * From INFORMATION_SCHEMA.COLUMNS Where TABLE_NAME='" + name + "';", sqlconnector.connection);

                sqlconnector.connection.Open();
                SqlDataReader reader2 = command2.ExecuteReader();
                try
                {
                    while (reader2.Read())
                    {
                        columnNames.Add(reader2["COLUMN_NAME"].ToString());
                    }
                }
                finally
                {
                    // Always call Close when done reading.
                    reader2.Close();
                    sqlconnector.connection.Close();
                }
                //dodawanie informacji o tabeli do słownika
                tablesInfo.Add(name, new Tuple<int, List<string>>(numberOfRows, columnNames));

            }

        }
    }
}
