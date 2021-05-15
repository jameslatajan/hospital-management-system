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
    public partial class loginForm : Form
    {
        private OleDbConnection connection = new OleDbConnection();
        

        public loginForm()
        {
            //edited relative path
            InitializeComponent();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=.\databases\PISdb.accdb; Persist Security Info=False;";
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Exit?", "Exit Application", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dashBoard dash = new dashBoard();

            connection.Open();


            OleDbCommand command = new OleDbCommand();
            command.Connection = connection;
            command.CommandText = "select * from account_tb where USERNAME='"+txtUser.Text+"' and PASS='"+txtPass.Text+"'" ;
            
            
            OleDbDataReader reader =  command.ExecuteReader();

            if (string.IsNullOrEmpty(txtUser.Text))
            {
                MessageBox.Show("Please enter your username and password");

            }
            else {
                int count = 0;
                while (reader.Read())
                {
                    count++;
                }

                if (count == 1)
                {
                    this.Hide();
                    dash.Show();
                }
                else
                {
                    MessageBox.Show("username or password is incorrect try again");
                }
            
            }

           
            connection.Close();
           
        }

        private void txtPass_TextChanged(object sender, EventArgs e)
        {
            txtPass.PasswordChar = '*';
        }



    }
}
