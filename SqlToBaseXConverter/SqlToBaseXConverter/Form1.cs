using MongoDB.Bson;
using MongoDB.Driver;
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
            converterFacade = new ConverterFacade(this);
        }

        private ConverterFacade converterFacade;


        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void bt_loadDatabase_Click(object sender, EventArgs e)
        {
            string nazwaBazy = tx_databaseName.Text;

            if (nazwaBazy != "")
            {
                converterFacade.loadDatabase(nazwaBazy);
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
                if (rb_modeSemiAutomatic.Checked)
                {
                    converterFacade.convertSqlToBasex(false);
                }
                else if(rb_modeAutomatic.Checked)
                {
                    converterFacade.convertSqlToBasex(true);
                }
                else
                {
                    MessageBox.Show("Musisz wybrać tryb pracy konwertera!");
                }
                
            }
            else if(rb_sqlToMongoDB.Checked)
            {
                converterFacade.convertSqlToMongoDB();
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
        public void setProgress(int value)
        {
            progress.Value = value;
        }
        public void setTimeInfo(TimeSpan timeOfConvertionExecution)
        {
            string time = String.Format("Czas konwersji to: {0:00} godzin {1:00} minut {2:00} sekund i {3:00} milisekund",timeOfConvertionExecution.Hours,timeOfConvertionExecution.Minutes,timeOfConvertionExecution.Seconds,timeOfConvertionExecution.Milliseconds);
            MessageBox.Show("Zadanie wykonane! " + time);
        }
        public void setQuantityOfTables(int quantity)
        {
            lb_quantityOfTables.Text = quantity.ToString();
        }
    }
}
