using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlToBaseXConverter
{
    class MongoDBConverter : Converter
    {
        private MongoDBConnector mongoDBConnector;
        private BsonDocument bsonDocument;
        private BsonElement bsonElement;
        

        public MongoDBConverter(MongoDBConnector mongoDBConnector, SqlConnector sqlConnect, string databaseName, DatabaseHelper databaseHelper, Form1 form1) : base(sqlConnect, databaseName, databaseHelper, form1)
        {
            this.mongoDBConnector = mongoDBConnector;
        }

        public override void ReadAndConvertSingleSqlTable(SqlDataReader reader, List<string> columnNames, string tableName, int tableSize)
        {
            int rowCounter = 0;
            form1.setRowAmount(tableSize.ToString());
            form1.Refresh();

            Console.WriteLine(tableName + "!!!!!!!!!!!!!!!!!!!!!!!!!!!");

            //reader.AsParallel();
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

                

                bsonDocument = new BsonDocument();


                for (int j = 0; j < reader.FieldCount; j++)
                {
                    Type t = reader[j].GetType();
                    if (reader[j].GetType() == typeof(String))
                        bsonDocument.Add(new BsonElement(reader.GetName(j), reader[j].ToString()));
                    else if ((reader[j].GetType() == typeof(Int32)))
                    {
                        bsonDocument.Add(new BsonElement(reader.GetName(j), BsonValue.Create(reader.GetInt32(j))));
                    }
                    else if (reader[j].GetType() == typeof(Int16))
                    {
                        bsonDocument.Add(new BsonElement(reader.GetName(j), BsonValue.Create(reader.GetInt16(j))));
                    }
                    else if (reader[j].GetType() == typeof(Int64))
                    {
                        bsonDocument.Add(new BsonElement(reader.GetName(j), BsonValue.Create(reader.GetInt64(j))));
                    }
                    else if (reader[j].GetType() == typeof(float))
                    {
                        bsonDocument.Add(new BsonElement(reader.GetName(j), BsonValue.Create(reader.GetFloat(j))));
                    }
                    else if (reader[j].GetType() == typeof(Double))
                    {
                        bsonDocument.Add(new BsonElement(reader.GetName(j), BsonValue.Create(reader.GetDouble(j))));
                    }
                    else if (reader[j].GetType() == typeof(DateTime))
                    {
                        bsonDocument.Add(new BsonElement(reader.GetName(j), BsonValue.Create(reader.GetDateTime(j))));
                    }
                    else if (reader[j].GetType() == typeof(Guid))
                        bsonDocument.Add(new BsonElement(reader.GetName(j), BsonValue.Create(reader.GetGuid(j))));
                    else if (reader[j].GetType() == typeof(Boolean))
                    {
                        bsonDocument.Add(new BsonElement(reader.GetName(j), BsonValue.Create(reader.GetBoolean(j))));
                    }
                    else if (reader[j].GetType() == typeof(DBNull))
                    {
                        bsonDocument.Add(new BsonElement(reader.GetName(j), BsonNull.Value));
                    }
                    else if (reader[j].GetType() == typeof(Byte))
                    {
                        bsonDocument.Add(new BsonElement(reader.GetName(j), BsonValue.Create(reader.GetByte(j))));
                    }
                    else if (reader[j].GetType() == typeof(Byte[]))
                    {
                        bsonDocument.Add(new BsonElement(reader.GetName(j), BsonValue.Create(reader[j] as Byte[])));
                    }
                    else if (reader[j].GetType() == typeof(Decimal))
                    {
                        bsonDocument.Add(new BsonElement(reader.GetName(j), BsonValue.Create(reader.GetDecimal(j))));
                    }
                    else
                        throw new Exception();
                }

                var collection = mongoDBConnector.database.GetCollection<BsonDocument>(tableName);
                collection.InsertOne(bsonDocument);
                //tableName

            }
            reader.Close();

        }
    }
}
