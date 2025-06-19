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

            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            string selectedRole = comboBox1.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(selectedRole))
            {
                MessageBox.Show("Please fill in all fields.");
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
                MessageBox.Show("Invalid credentials or role. Please try again.");
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(new string[] { "select your role","Admin", "Staff", "Lecture", "Student" });
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
                MessageBox.Show("Please fill in all fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var user = UserController.AuthenticateUser(username, password, role);

            if (user != null)
            {
                MessageBox.Show($"Login successful as {user.Role}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // TODO: Redirect based on role
                // Example:
                // if (user.Role == "Admin") { new AdminForm().Show(); }
                MainForm mainForm = new MainForm(user.Role); // pass user if needed
                mainForm.Show();
                this.Hide();
                //Application.Run(new MainForm());

            }
            else
            {
                MessageBox.Show("Invalid username, password, or role.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
