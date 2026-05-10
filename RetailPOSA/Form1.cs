using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using RetailPOSA.Forms;
using RetailPOSA.Services;

namespace RetailPOSA
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //remove this after test is done
            txtUsername.Text = "Chinthana";
            txtPassword.Text = "bluecat4";
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            AuthService authService = new AuthService();

            int result = authService.Login(txtUsername.Text, txtPassword.Text);

            if (result == 1)
            {
                this.Hide();

                Main main = new Main();

                main.Show();

                //MessageBox.Show("Login successful!");
            }
            else 
            { 
                MessageBox.Show("Login failed. Please check your username and password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }//login
    }
}
