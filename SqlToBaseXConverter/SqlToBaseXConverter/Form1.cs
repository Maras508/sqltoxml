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

        private DatabaseHelper databaseHelper;


        private void button1_Click(object sender, EventArgs e)
        {
            
            
        }

        private void bt_loadDatabase_Click(object sender, EventArgs e)
        {
            string nazwaBazy = tx_databaseName.Text;

            if (nazwaBazy != "")
            {
                //sqlConnector = SqlConnector.GetConnector();
                SqlConnector.GetConnector().Connect(nazwaBazy);

                databaseHelper = new DatabaseHelper(SqlConnector.GetConnector());
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
                BaseXConnector.GetConnector().Connect();

                
                //setActualTable("None");
                
                Converter converter = new BaseXConverter(BaseXConnector.GetConnector(), SqlConnector.GetConnector(), tx_databaseName.Text, databaseHelper, this);

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
