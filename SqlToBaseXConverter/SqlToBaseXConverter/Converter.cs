﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseXClient;
using System.Data.SqlClient;
using System.IO;
using System.Diagnostics;

namespace SqlToBaseXConverter
{
    abstract class Converter
    {
        public SqlConnector sqlConnect;
        public string databaseName;
        public DatabaseHelper databaseHelper;
        public Form1 form1;
        public Query query;
        public int totalRowAmount;
        public int totalRowCounter;
        public Stopwatch stopWatch;
        //private Stopwatch stopwatch;
        
        

        public Converter(SqlConnector sqlConnect, string databaseName, DatabaseHelper databaseHelper, Form1 form1)
        {
            this.sqlConnect = sqlConnect;
            this.databaseName = databaseName;
            this.databaseHelper = databaseHelper;
            this.form1 = form1;
            //this.stopwatch = new Stopwatch();
            
        }

        public virtual void ReadAndConvertSingleSqlTable(SqlDataReader reader, List<string> columnNames, string tableName, int tableSize) { }
        public virtual void Convert(bool mode)
        {
            stopWatch = new Stopwatch();
            stopWatch.Start();

            int tableCounter = 0;
            totalRowAmount = 0;
            totalRowCounter = 0;
            foreach (var dictionaryElement in this.databaseHelper.tablesInfo)
            {
                totalRowAmount += dictionaryElement.Value.Item1;
            }

            foreach (var dictionaryElement in this.databaseHelper.tablesInfo)
            {
                tableCounter++;
                form1.setActualTable(tableCounter.ToString() + " (" + dictionaryElement.Key + ")");
                form1.Refresh();
                ReadAndConvertSingleSqlTable(GetSingleSqlTable(dictionaryElement.Key), dictionaryElement.Value.Item2, dictionaryElement.Key, dictionaryElement.Value.Item1);
                
            }
            stopWatch.Stop();
            form1.setTimeInfo(stopWatch.Elapsed);
            form1.Refresh();
        }
        public SqlDataReader GetSingleSqlTable(string tableName)
        {
            SqlCommand command = new SqlCommand("Select * From " + tableName + ";", this.sqlConnect.connection);

            if (this.sqlConnect.connection.State != System.Data.ConnectionState.Open)
            {
                this.sqlConnect.connection.Open();
            }
            SqlDataReader reader = command.ExecuteReader();

            return reader;
        }
        
    }
}
