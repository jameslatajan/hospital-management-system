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
           
            //edited relative path
            InitializeComponent();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=.\databases\PISdb.accdb; Persist Security Info=False;";
        }
        private void refresh() {
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

        private void registrationModule_Load(object sender, EventArgs e)
        {
            refresh();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            panel8.Visible = true;
            btnDelete.Enabled = false;
            btnEdit.Enabled = false;
            btnAdd.Enabled = true;
            
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
            panel8.Visible = false;
        }

        private void label12_Click(object sender, EventArgs e)
        {
            panel11.Visible  = false;
        }

        

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
            
            try
            {
                if (e.RowIndex >= 0)
                {
                    txtPcode.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                    textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                    textBox1.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                    comboBox1.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                    btnAdd.ForeColor = Color.White;
                    btnEdit.Enabled = true;
                    btnDelete.Enabled = true;
                    btnAdd.Enabled = true;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid selection");
            }
             
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            panel11.Visible = true;
            btnAdd.Enabled = false;
            btnDelete.Enabled = false;
   
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (txt_name.Text == "" || txt_desc.Text == "" || combo.Text == "")
            {
                MessageBox.Show("Please fill all the requirements");
            }
            else { 
            //insert code
            try
            {
               
                OleDbCommand command = new OleDbCommand();
                connection.Open();
                command.Connection = connection;
                command.CommandText = "insert into patient_tb(p_name, p_descrip, p_ctgry) values ('" + txt_name.Text + "', '" + txt_desc.Text + "', '" + combo.Text + "')";
                command.ExecuteNonQuery();
                connection.Close();
                refresh();
                //count();
                //clear();
                MessageBox.Show("Data added ");
                panel8.Visible = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
            }
            }
            
        }

        private void label12_Click_1(object sender, EventArgs e)
        {
            panel11.Visible  = false;
            btnAdd.Enabled = true;
            btnDelete.Enabled = true;
           
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            OleDbCommand command = new OleDbCommand();
            command.Connection = connection;
            connection.Open();
            
           try
            {
              
                  
                command.CommandText = "update patient_tb set p_name = '" + textBox2.Text + "', p_descrip = '" + textBox1.Text + "',p_ctgry = '" + comboBox1.Text + "'where p_code = " + txtPcode.Text + " ";
                command.ExecuteNonQuery();
                connection.Close();
                refresh();
                panel11.Visible  = false;
                MessageBox.Show("Update Success");
                
             
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                command.CommandText = "delete from patient_tb where p_code = " + txtPcode.Text + " ";
                command.ExecuteNonQuery();
                connection.Close();
                refresh();
                btnDelete.Enabled = false;
                MessageBox.Show("Delete Success");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
            }
        }
   


    }
    
}
