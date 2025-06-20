using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unicom_TIC_Management_System.Controller;
using Unicom_TIC_Management_System.Controllers;
using Unicom_TIC_Management_System.Models;

namespace Unicom_TIC_Management_System.View
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }


        private void btnLogin_Click(object sender, EventArgs e)
        {

            var username = txtUsername.Text.Trim();
            var password = txtPassword.Text.Trim();
            var selectedRole = comboBox1.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(selectedRole))
            {
                MessageBox.Show("All fields are required.");
                return;
            }

            User user = LoginController.AuthenticateUser(username, password, selectedRole);

            if (user != null)
            {
                MessageBox.Show($"Login successful! Welcome, {user.Role}.");
                MainForm mainForm = new MainForm(user.Role);
                this.Hide();
                mainForm.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Login failed. Check your credentials and role.\", \"Access Denied\"");
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            string[] roles = { "select your role", "Admin", "Staff", "Lecture", "Student" };
            comboBox1.Items.AddRange(roles);
            comboBox1.SelectedIndex = 0; // default to Admin
        }

        private void lblPassword_Click(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click_1(object sender, EventArgs e)
        {

            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            string role = comboBox1.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(role))
            {
                MessageBox.Show("Please, Enter all login details..", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var loggedUser = UserController.AuthenticateUser(username, password, role);

            if (loggedUser != null)
            {
                MessageBox.Show($"Login successful as {loggedUser.Role}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

              
                MainForm mainForm = new MainForm(loggedUser.Role); // pass user if needed
                mainForm.Show();
                this.Hide();
                

            }
            else
            {
                MessageBox.Show("Incorrect credentials. Try again.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
