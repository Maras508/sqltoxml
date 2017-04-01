using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlToBaseXConverter
{
    class ConverterFacade
    {
        private DatabaseHelper databaseHelper;
        private Converter converter;
        private string databaseName;
        private Form1 form1;

        public ConverterFacade(Form1 form1)
        {
            this.form1 = form1;
        }

        public void loadDatabase(string databaseName)
        {
            this.databaseName = databaseName;

            
            SqlConnector.GetConnector().Connect(this.databaseName);

            databaseHelper = new DatabaseHelper(SqlConnector.GetConnector());
            databaseHelper.GetTablesInfo();

            form1.setQuantityOfTables(databaseHelper.tablesInfo.Count());
        }

        public void convertSqlToBasex(bool mode)
        {
            BaseXConnector.GetConnector().Connect();
            converter = new BaseXConverter(BaseXConnector.GetConnector(), SqlConnector.GetConnector(), databaseName, databaseHelper, form1);
            converter.Convert(mode);
        }
        public void convertSqlToMongoDB()
        {
            MongoDBConnector.GetConnector().Connect(databaseName);
            converter = new MongoDBConverter(MongoDBConnector.GetConnector(), SqlConnector.GetConnector(), databaseName, databaseHelper, form1);
            converter.Convert(false);
        }

    }
}
