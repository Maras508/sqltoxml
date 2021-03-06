﻿namespace SqlToBaseXConverter
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.tx_databaseName = new System.Windows.Forms.TextBox();
            this.bt_loadDatabase = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lb_quantityOfTables = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.rb_sqlToBasex = new System.Windows.Forms.RadioButton();
            this.rb_sqlToMongoDB = new System.Windows.Forms.RadioButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.bt_Convert = new System.Windows.Forms.Button();
            this.lb_converterMode = new System.Windows.Forms.Label();
            this.rb_modeSemiAutomatic = new System.Windows.Forms.RadioButton();
            this.rb_modeAutomatic = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lb_actualTable = new System.Windows.Forms.Label();
            this.lb_rowAmount = new System.Windows.Forms.Label();
            this.lb_actualRow = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.progress = new System.Windows.Forms.ProgressBar();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Wprowadź nazwę bazy danych:\r\n";
            // 
            // tx_databaseName
            // 
            this.tx_databaseName.Location = new System.Drawing.Point(176, 18);
            this.tx_databaseName.Name = "tx_databaseName";
            this.tx_databaseName.Size = new System.Drawing.Size(156, 20);
            this.tx_databaseName.TabIndex = 2;
            this.tx_databaseName.Text = "AdventureWorksDW2008R2";
            // 
            // bt_loadDatabase
            // 
            this.bt_loadDatabase.Location = new System.Drawing.Point(351, 16);
            this.bt_loadDatabase.Name = "bt_loadDatabase";
            this.bt_loadDatabase.Size = new System.Drawing.Size(99, 23);
            this.bt_loadDatabase.TabIndex = 3;
            this.bt_loadDatabase.Text = "Załaduj";
            this.bt_loadDatabase.UseVisualStyleBackColor = true;
            this.bt_loadDatabase.Click += new System.EventHandler(this.bt_loadDatabase_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Liczba tabel w bazie:";
            // 
            // lb_quantityOfTables
            // 
            this.lb_quantityOfTables.AutoSize = true;
            this.lb_quantityOfTables.Location = new System.Drawing.Point(115, 97);
            this.lb_quantityOfTables.Name = "lb_quantityOfTables";
            this.lb_quantityOfTables.Size = new System.Drawing.Size(25, 13);
            this.lb_quantityOfTables.TabIndex = 5;
            this.lb_quantityOfTables.Text = "      ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Co konwertować?";
            // 
            // rb_sqlToBasex
            // 
            this.rb_sqlToBasex.AutoSize = true;
            this.rb_sqlToBasex.Location = new System.Drawing.Point(3, 5);
            this.rb_sqlToBasex.Name = "rb_sqlToBasex";
            this.rb_sqlToBasex.Size = new System.Drawing.Size(95, 17);
            this.rb_sqlToBasex.TabIndex = 7;
            this.rb_sqlToBasex.TabStop = true;
            this.rb_sqlToBasex.Text = "SQL do BaseX";
            this.rb_sqlToBasex.UseVisualStyleBackColor = true;
            this.rb_sqlToBasex.CheckedChanged += new System.EventHandler(this.rb_sqlToBasex_CheckedChanged);
            // 
            // rb_sqlToMongoDB
            // 
            this.rb_sqlToMongoDB.AutoSize = true;
            this.rb_sqlToMongoDB.Location = new System.Drawing.Point(121, 5);
            this.rb_sqlToMongoDB.Name = "rb_sqlToMongoDB";
            this.rb_sqlToMongoDB.Size = new System.Drawing.Size(112, 17);
            this.rb_sqlToMongoDB.TabIndex = 8;
            this.rb_sqlToMongoDB.TabStop = true;
            this.rb_sqlToMongoDB.Text = "SQL do MongoDB";
            this.rb_sqlToMongoDB.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 240);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(466, 22);
            this.statusStrip1.TabIndex = 9;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // bt_Convert
            // 
            this.bt_Convert.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bt_Convert.Location = new System.Drawing.Point(351, 48);
            this.bt_Convert.Name = "bt_Convert";
            this.bt_Convert.Size = new System.Drawing.Size(99, 40);
            this.bt_Convert.TabIndex = 10;
            this.bt_Convert.Text = "Konwertuj";
            this.bt_Convert.UseVisualStyleBackColor = true;
            this.bt_Convert.Click += new System.EventHandler(this.bt_Convert_Click);
            // 
            // lb_converterMode
            // 
            this.lb_converterMode.AutoSize = true;
            this.lb_converterMode.Location = new System.Drawing.Point(12, 75);
            this.lb_converterMode.Name = "lb_converterMode";
            this.lb_converterMode.Size = new System.Drawing.Size(31, 13);
            this.lb_converterMode.TabIndex = 11;
            this.lb_converterMode.Text = "Tryb:";
            this.lb_converterMode.Visible = false;
            // 
            // rb_modeSemiAutomatic
            // 
            this.rb_modeSemiAutomatic.AutoSize = true;
            this.rb_modeSemiAutomatic.Location = new System.Drawing.Point(49, 73);
            this.rb_modeSemiAutomatic.Name = "rb_modeSemiAutomatic";
            this.rb_modeSemiAutomatic.Size = new System.Drawing.Size(107, 17);
            this.rb_modeSemiAutomatic.TabIndex = 12;
            this.rb_modeSemiAutomatic.TabStop = true;
            this.rb_modeSemiAutomatic.Text = "Półautomatyczny";
            this.rb_modeSemiAutomatic.UseVisualStyleBackColor = true;
            this.rb_modeSemiAutomatic.Visible = false;
            this.rb_modeSemiAutomatic.CheckedChanged += new System.EventHandler(this.rb_modeSemiAutomatic_CheckedChanged);
            // 
            // rb_modeAutomatic
            // 
            this.rb_modeAutomatic.AutoSize = true;
            this.rb_modeAutomatic.Location = new System.Drawing.Point(162, 73);
            this.rb_modeAutomatic.Name = "rb_modeAutomatic";
            this.rb_modeAutomatic.Size = new System.Drawing.Size(91, 17);
            this.rb_modeAutomatic.TabIndex = 13;
            this.rb_modeAutomatic.TabStop = true;
            this.rb_modeAutomatic.Text = "Automatyczny";
            this.rb_modeAutomatic.UseVisualStyleBackColor = true;
            this.rb_modeAutomatic.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 118);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(152, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Aktualnie przetwarzana tabela:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 139);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(117, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Liczba wierszy w tabeli:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 160);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(151, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Aktualnie przetwarzany wiersz:";
            // 
            // lb_actualTable
            // 
            this.lb_actualTable.AutoSize = true;
            this.lb_actualTable.Location = new System.Drawing.Point(170, 118);
            this.lb_actualTable.Name = "lb_actualTable";
            this.lb_actualTable.Size = new System.Drawing.Size(22, 13);
            this.lb_actualTable.TabIndex = 18;
            this.lb_actualTable.Text = "     ";
            // 
            // lb_rowAmount
            // 
            this.lb_rowAmount.AutoSize = true;
            this.lb_rowAmount.Location = new System.Drawing.Point(126, 139);
            this.lb_rowAmount.Name = "lb_rowAmount";
            this.lb_rowAmount.Size = new System.Drawing.Size(31, 13);
            this.lb_rowAmount.TabIndex = 19;
            this.lb_rowAmount.Text = "        ";
            // 
            // lb_actualRow
            // 
            this.lb_actualRow.AutoSize = true;
            this.lb_actualRow.Location = new System.Drawing.Point(169, 160);
            this.lb_actualRow.Name = "lb_actualRow";
            this.lb_actualRow.Size = new System.Drawing.Size(22, 13);
            this.lb_actualRow.TabIndex = 20;
            this.lb_actualRow.Text = "     ";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rb_sqlToMongoDB);
            this.panel1.Controls.Add(this.rb_sqlToBasex);
            this.panel1.Location = new System.Drawing.Point(111, 39);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(232, 22);
            this.panel1.TabIndex = 21;
            // 
            // progress
            // 
            this.progress.Location = new System.Drawing.Point(15, 195);
            this.progress.Name = "progress";
            this.progress.Size = new System.Drawing.Size(435, 23);
            this.progress.TabIndex = 23;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(466, 262);
            this.Controls.Add(this.progress);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lb_actualRow);
            this.Controls.Add(this.lb_rowAmount);
            this.Controls.Add(this.lb_actualTable);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.rb_modeAutomatic);
            this.Controls.Add(this.rb_modeSemiAutomatic);
            this.Controls.Add(this.lb_converterMode);
            this.Controls.Add(this.bt_Convert);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lb_quantityOfTables);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.bt_loadDatabase);
            this.Controls.Add(this.tx_databaseName);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Konwerter";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tx_databaseName;
        private System.Windows.Forms.Button bt_loadDatabase;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lb_quantityOfTables;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton rb_sqlToBasex;
        private System.Windows.Forms.RadioButton rb_sqlToMongoDB;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Button bt_Convert;
        private System.Windows.Forms.Label lb_converterMode;
        private System.Windows.Forms.RadioButton rb_modeSemiAutomatic;
        private System.Windows.Forms.RadioButton rb_modeAutomatic;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lb_actualTable;
        private System.Windows.Forms.Label lb_rowAmount;
        private System.Windows.Forms.Label lb_actualRow;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ProgressBar progress;
    }
}

