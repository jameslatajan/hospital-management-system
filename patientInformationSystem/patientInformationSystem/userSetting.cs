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
    public partial class userSetting : Form
    {
        private OleDbConnection con = new OleDbConnection();

        public userSetting()
        {
            InitializeComponent();
            //edited relative path
            con.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=.\databases\PISdb.accdb; Persist Security Info=False;";
            
        }

        private void userSetting_Load(object sender, EventArgs e)
        {
            refresh();
            count();
        }

        private void refresh(){
            //data view
            string query = "SELECT * From account_tb";
            con.Open();
            OleDbCommand command = new OleDbCommand();
            command.Connection = con;
            command.CommandText = query;

            OleDbDataAdapter adapter = new OleDbDataAdapter(command);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            
            dataGridView1.DataSource = dt;
            con.Close();
        }
        private void count() {
            //Record count
            con.Open();
            OleDbCommand command = new OleDbCommand();
            command.Connection = con;
            command.CommandText = "select count(ID) from account_tb";
    
            Int32 id = Convert.ToInt32(command.ExecuteScalar());
            command.Dispose();
            con.Close();

            lblCount.Text = "Record Count: " + id.ToString();
        }
        private void clear() {
            txtID.Clear();
            txtUser.Clear();
            txtFname.Clear();
            txtLname.Clear();
            txtPass.Clear();
            txtRpass.Clear();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //insert code
            try
            {
                con.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = con;
                command.CommandText = "insert into account_tb(FIRSTNAME, LASTNAME, USERNAME, PASS) values ('" + txtFname.Text + "', '" + txtLname.Text + "', '" + txtUser.Text + "', '" + txtPass.Text + "')";
                command.ExecuteNonQuery();
                con.Close();
                refresh();
                count();
                clear();
                MessageBox.Show("Data added ");

            }
            catch (Exception ex) {
                MessageBox.Show("Error: " + ex);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {  
                con.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = con;
                command.CommandText = "update account_tb set FIRSTNAME = '" + txtFname.Text + "', LASTNAME = '" + txtLname.Text + "',USERNAME = '" + txtUser.Text + "', PASS = '" + txtPass.Text + "' where ID = " + txtID.Text + " ";
                command.ExecuteNonQuery();
                con.Close();
                refresh();
                count();
                clear();
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
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
                con.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = con;
                command.CommandText = "delete from account_tb where ID = " + txtID.Text + " ";
                command.ExecuteNonQuery();
                con.Close();
                refresh();
                count();
                clear();
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
                MessageBox.Show("Delete Success");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
            }
        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    txtID.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                    txtFname.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                    txtLname.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                    txtUser.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                    txtPass.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                    btnSave.Enabled = false;
                    btnDelete.Enabled = true;
                    btnUpdate.Enabled = true;
                }
            }
            catch (Exception) {
                MessageBox.Show("Invalid selection");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void txtRpass_Leave(object sender, EventArgs e)
        {
            if (txtPass.Text == txtRpass.Text)
            {
                btnSave.Enabled = true;
            }
            else
            {
                btnSave.Enabled = false;
                MessageBox.Show("Password mismatch");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtPass.PasswordChar == '*' && txtRpass.PasswordChar == '*')
            {
                txtPass.PasswordChar = '\0';
                txtRpass.PasswordChar = '\0';
            }
            else if (txtPass.PasswordChar == '\0' && txtRpass.PasswordChar == '\0')
            {
                txtPass.PasswordChar = '*';
                txtRpass.PasswordChar = '*';
            }
        }



    }
}
