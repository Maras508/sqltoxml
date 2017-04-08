using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlToBaseXConverter
{
    sealed class BaseXConverter : Converter
    {
        private BaseXConnector baseXConnect;
        private StringBuilder xqueryElementToInsert;

        public BaseXConverter(BaseXConnector baseXConnect, SqlConnector sqlConnect, string databaseName, DatabaseHelper databaseHelper, Form1 form1) : base(sqlConnect, databaseName, databaseHelper, form1)
        {
            this.baseXConnect = baseXConnect;
            this.xqueryElementToInsert = new StringBuilder();
        }

        protected override void ReadAndConvertSingleSqlTable(SqlDataReader reader, List<string> columnNames, string tableName, int tableSize)
        {
            int rowCounter = 0;
            form1.setRowAmount(tableSize.ToString());
            form1.Refresh();

            
            try
            {
               
                while (reader.Read())
                {
                    rowCounter++;
                    totalRowCounter++;

                    form1.setActualRow(rowCounter.ToString());
                    float progress = ((float)totalRowCounter / totalRowAmount) * 100;
                    form1.setProgress((int)progress);

                    if (rowCounter % 50 == 0)
                    {
                        form1.Refresh();
                    }

                    xqueryElementToInsert.Clear();

                    xqueryElementToInsert.Append("<");
                    xqueryElementToInsert.Append(tableName);
                    xqueryElementToInsert.Append(">");

                    foreach (string name in columnNames)
                    {
                        xqueryElementToInsert.Append("<");
                        xqueryElementToInsert.Append(name);
                        xqueryElementToInsert.Append(">");

                        xqueryElementToInsert.Append(reader[name].ToString().Replace("&", "and"));

                        xqueryElementToInsert.Append("<");
                        xqueryElementToInsert.Append("/");
                        xqueryElementToInsert.Append(name);
                        xqueryElementToInsert.Append(">");

                    }

                    xqueryElementToInsert.Append("<");
                    xqueryElementToInsert.Append("/");
                    xqueryElementToInsert.Append(tableName);
                    xqueryElementToInsert.Append(">");


                    string input = "let $node := " + xqueryElementToInsert.ToString() + " return insert node " + "$node" + " into /" + this.databaseName;
                    try
                    {
                       File.AppendAllText("przekonwertowanaBaza.xml", this.xqueryElementToInsert.ToString());
                    }
                    catch (IOException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                   
                }
            }
            finally
            {
                reader.Close();
                this.sqlConnect.connection.Close();
            }
        }

        public override void Convert(bool modeAutomatic)
        {
            File.AppendAllText("przekonwertowanaBaza.xml", "<" + this.databaseName + ">");
            base.Convert(modeAutomatic);
            File.AppendAllText("przekonwertowanaBaza.xml", "</" + this.databaseName + ">");

            if(modeAutomatic)
            {
                FileStream fs = File.Open("przekonwertowanaBaza.xml", FileMode.Open);
                try
                {
                    this.baseXConnect.session.Create(this.databaseName, fs);
                }
                catch (Exception ex)
                {

                }
                
            }
        }


    }
}
