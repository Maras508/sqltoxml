using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseXClient;
using System.Data.SqlClient;
using System.IO;

namespace SqlToBaseXConverter
{
    class Converter
    {
        private BaseXConnector baseXConnect;
        private SqlConnector sqlConnect;
        private string databaseName;
        private DatabaseHelper databaseHelper;
        private Query query;

        public Converter(BaseXConnector baseXConnect, SqlConnector sqlConnect, string databaseName, DatabaseHelper databaseHelper)
        {
            this.baseXConnect = baseXConnect;
            this.sqlConnect = sqlConnect;
            this.databaseName = databaseName;
            this.databaseHelper = databaseHelper;
        }
        public void SqlToXml()
        {
            foreach(var dictionaryElement in this.databaseHelper.tablesInfo)
            {
                ReadSqlWriteToXml(GetSingleSqlTable(dictionaryElement.Key), dictionaryElement.Value.Item2, dictionaryElement.Key);
            }
        }
        private SqlDataReader GetSingleSqlTable(string tableName)
        {
            SqlCommand command = new SqlCommand("Select * From " + tableName + ";", this.sqlConnect.connection);

            
            this.sqlConnect.connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            //this.sqlConnect.connection.Close();

            return reader;
        }
        private void ReadSqlWriteToXml(SqlDataReader reader, List<string> columnNames, string tableName)
        {
            StringBuilder xqueryElementToInsert = new StringBuilder();
            this.baseXConnect.session.Execute("open " + this.databaseName);
            try
            {
                while (reader.Read())
                {
                    xqueryElementToInsert.Clear();

                    xqueryElementToInsert.Append("<");
                    xqueryElementToInsert.Append(tableName);
                    xqueryElementToInsert.Append(">");

                    foreach (string name in columnNames)
                    {
                        xqueryElementToInsert.Append("<");
                        xqueryElementToInsert.Append(name);
                        xqueryElementToInsert.Append(">");

                        xqueryElementToInsert.Append(reader[name].ToString().Replace("&","and"));

                        xqueryElementToInsert.Append("<");
                        xqueryElementToInsert.Append("/");
                        xqueryElementToInsert.Append(name);
                        xqueryElementToInsert.Append(">");

                    }

                    xqueryElementToInsert.Append("<");
                    xqueryElementToInsert.Append("/");
                    xqueryElementToInsert.Append(tableName);
                    xqueryElementToInsert.Append(">");


                    string input = "let $node := " + xqueryElementToInsert.ToString() + " return insert node " + "$node" +  " into /"+ this.databaseName;
                    try
                    {
                        this.baseXConnect.session.Query(input).Execute();
                        /*
                        while (query.More())
                        {
                            Console.WriteLine(query.Next());

                        }
                        query.Close();
                        */
                    }
                    catch (IOException e)
                    {
                        // print exception
                        Console.WriteLine(e.Message);
                    }
                    xqueryElementToInsert.Clear();
                }
            }
            finally
            {
                // Always call Close when done reading.
                reader.Close();
               // this.baseXConnect.session.Close();
                this.sqlConnect.connection.Close();
            }
        }
    }
}
