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

        private SqlConnector sqlConnector;
        private DatabaseHelper databaseHelper;


        private void button1_Click(object sender, EventArgs e)
        {
            
            string nazwaBazy = "AdventureWorksDW2008R2";
            SqlConnector sql = new SqlConnector();
            sql.Connect(nazwaBazy);

            DatabaseHelper dh = new DatabaseHelper(sql);
            dh.GetTablesInfo();
            BaseXConnector basexConnector = new BaseXConnector();
            basexConnector.Connect();
            
            
            // MemoryStream ms = new MemoryStream(
            // System.Text.Encoding.UTF8.GetBytes("<" + nazwaBazy + "></" + nazwaBazy + ">"));

            // create database
            //*************************
            /*
            basexConnector.session.Create(nazwaBazy, ms);
            basexConnector.Connect(nazwaBazy);
            Converter converter = new Converter(basexConnector, sql, nazwaBazy, dh);
            converter.SqlToXml();
            */
            //*********************************************************
           // Converter converter = new Converter(basexConnector, sql, nazwaBazy, dh);
           // converter.SqlToXml();

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

        private void bt_loadDatabase_Click(object sender, EventArgs e)
        {
            string nazwaBazy = tx_databaseName.Text;

            if (nazwaBazy != "")
            {
                sqlConnector = SqlConnector.GetConnector();
                sqlConnector.Connect(nazwaBazy);

                databaseHelper = new DatabaseHelper(sqlConnector);
                databaseHelper.GetTablesInfo();

                lb_quantityOfTables.Text = databaseHelper.tablesInfo.Count().ToString();
            }
            else
            {
                MessageBox.Show("Musisz podać nazwę bazy danych!");
            }
        }

        private void rb_modeSemiAutomatic_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rb_sqlToBasex_CheckedChanged(object sender, EventArgs e)
        {
            if(rb_sqlToBasex.Checked)
            {
                lb_converterMode.Visible = true;
                rb_modeSemiAutomatic.Visible = true;
                rb_modeAutomatic.Visible = true;
            }
            else
            {
                lb_converterMode.Visible = false;
                rb_modeSemiAutomatic.Visible = false;
                rb_modeAutomatic.Visible = false;
            }
        }

        private void bt_Convert_Click(object sender, EventArgs e)
        {
            if(rb_sqlToBasex.Checked)
            {
                BaseXConnector basexConnector = new BaseXConnector();
                basexConnector.Connect();

                
                //setActualTable("None");
                
                Converter converter = new BaseXConverter(basexConnector, sqlConnector, tx_databaseName.Text, databaseHelper, this);

                if (rb_modeSemiAutomatic.Checked)
                {
                    converter.Convert(false);
                }
                else if(rb_modeAutomatic.Checked)
                {
                    converter.Convert(true);
                }
                else
                {
                    MessageBox.Show("Musisz wybrać tryb pracy konwertera!");
                }
                
            }
            else if(rb_sqlToMongoDB.Checked)
            {

            }
            else
            {
                MessageBox.Show("Wybierz opcję konwersji");
            }
        }

        public void setActualTable(string text)
        {
            lb_actualTable.Text = text;
        }

        public void setRowAmount(string text)
        {
            lb_rowAmount.Text = text;
        }

        public void setActualRow(string text)
        {
            lb_actualRow.Text = text;
        }
    }
}
