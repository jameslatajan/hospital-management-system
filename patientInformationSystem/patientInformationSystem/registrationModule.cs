using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace patientInformationSystem
{
    public partial class registrationModule : Form
    {
        private OleDbConnection connection = new OleDbConnection();
        public registrationModule()
        {
            InitializeComponent();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Admin\Documents\Visual Studio 2010\Projects\patientInformationSystem\databases\PISdb.accdb; Persist Security Info=False;";
        }

        private void registrationModule_Load(object sender, EventArgs e)
        {
            string query = "SELECT * From patient_tb";
            connection.Open();
            OleDbCommand command = new OleDbCommand();
            command.Connection = connection;
            command.CommandText = query;

            OleDbDataAdapter adapter = new OleDbDataAdapter(command);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            
            dataGridView1.DataSource = dt;
            connection.Close();
            

        }
    }
}
