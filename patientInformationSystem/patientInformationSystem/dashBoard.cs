using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace patientInformationSystem
{
    public partial class dashBoard : Form
    {
        public dashBoard()
        {
            InitializeComponent();
            
       
        }

        private void btnLog_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to logout?", "Exit Application", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                loginForm login = new loginForm();
                this.Hide();
                login.Show();
            }
        }

        private void btnReg_Click(object sender, EventArgs e)
        {
            registrationModule regModule = new registrationModule();
            regModule.TopLevel = false;
            panel5.Controls.Clear();
            panel5.Controls.Add(regModule);
            regModule.BringToFront();
            regModule.Show();

          
        }

        private void btnCon_Click(object sender, EventArgs e)
        {
            docConsDiagModule docModule = new docConsDiagModule();
            panel5.Controls.Clear();
            docModule.TopLevel = false;
            panel5.Controls.Add(docModule);
            docModule.BringToFront();
            docModule.Show();
        }

       
        private void btnRecords_Click(object sender, EventArgs e)
        {
            records rec = new records();
            panel5.Controls.Clear();
            rec.TopLevel = false;
            panel5.Controls.Add(rec);
            rec.BringToFront();
            rec.Show();
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            userSetting user = new userSetting();
            panel5.Controls.Clear();
            user.TopLevel = false;
            panel5.Controls.Add(user);
            user.BringToFront();
            user.Show();
        }



        private void dashBoard_Load_1(object sender, EventArgs e)
        {
            timer1.Start();
            time_1.Text = DateTime.Now.ToLongDateString();
            time_2.Text = DateTime.Now.ToShortTimeString();

            registrationModule regModule = new registrationModule();
            panel5.Controls.Clear();
            regModule.TopLevel = false;
            panel5.Controls.Add(regModule);
            regModule.BringToFront();
            regModule.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            time_2.Text = DateTime.Now.ToShortTimeString();
        }

      
       }
}
