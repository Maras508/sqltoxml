using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SqlToBaseXConverter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nazwaBazy = "AdventureWorksDW2008R2";
            SqlConnector sql = new SqlConnector();
            sql.Connect(nazwaBazy);

            DatabaseHelper dh = new DatabaseHelper(sql);
            dh.GetTablesInfo();
            BaseXConnector basexConnector = new BaseXConnector();
            basexConnector.Connect();
            MemoryStream ms = new MemoryStream(
            System.Text.Encoding.UTF8.GetBytes("<" + nazwaBazy + "></" + nazwaBazy + ">"));

            // create database
            basexConnector.session.Create(nazwaBazy, ms);
            basexConnector.Connect(nazwaBazy);
            Converter converter = new Converter(basexConnector, sql, nazwaBazy, dh);
            converter.SqlToXml();
            //Console.WriteLine("To jest to!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            //Console.WriteLine(dh.tablesInfo["Towary"].Item1);
            /*
            SqlCommand command = new SqlCommand("Select * From Towary", sql.connection);
           
            sql.connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            try
            {
                while (reader.Read())
                {
                    Console.WriteLine(reader["Marka"]);// etc
                }
            }
            finally
            {
                // Always call Close when done reading.
                reader.Close();
            }
            */
        }
    }
}
