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
    public partial class UserForm : Form
    {
        private int selectedUserId = -1;
        
        public UserForm()
        {
            InitializeComponent();
 

            cmbRole.Items.AddRange(new string[] { "Admin", "Staff" , "Lecture" , "Student"  });
            DisplayUsers();
        }
        private void DisplayUsers()
        {
            try
            {
                var allcourses = UserController.GetAllUsers();
                dgvUsers.DataSource = allcourses;

                
                dgvUsers.Columns["UserID"].HeaderText = "UserID";
                dgvUsers.Columns["Username"].HeaderText = "Username ";
                dgvUsers.Columns["Password"].HeaderText = "Password ";
                dgvUsers.Columns["Role"].HeaderText = "Role ";
                dgvUsers.AutoResizeColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading users: {ex.Message}", "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearInput()
        {
            txtusername.Clear();
            txtPassword.Clear();
            cmbRole.SelectedIndex = -1;
            selectedUserId = -1;
        }


        private void dgvUsers_SelectionChanged(object sender, EventArgs e)
        {

            if (dgvUsers.CurrentRow != null && dgvUsers.CurrentRow.Index >= 0)
            {
                selectedUserId = Convert.ToInt32(dgvUsers.CurrentRow.Cells["UserID"].Value);
                txtusername.Text = dgvUsers.CurrentRow.Cells["Username"].Value?.ToString();
                txtPassword.Text = dgvUsers.CurrentRow.Cells["Password"].Value?.ToString();
                cmbRole.Text = dgvUsers.CurrentRow.Cells["Role"].Value?.ToString();
            }
            else
            {
                selectedUserId = -1;
                txtusername.Clear();
                txtPassword.Clear();
                cmbRole.SelectedIndex = -1;
            }
        }

            private void btnAdd_Click(object sender, EventArgs e)
        {
            var user = new User
            {
                Username = txtusername.Text,
                Password = txtPassword.Text,
                Role = cmbRole.Text
            };

            UserController.AddUser(user);
            DisplayUsers();
            ClearInput();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedUserId == -1)
            {
                MessageBox.Show("No user selected for update.");
                return;
            }

            var user = new User
            {
                UserID = selectedUserId,
                Username = txtusername.Text,
                Password = txtPassword.Text,
                Role = cmbRole.Text
            };

            UserController.UpdateUser(user);
            DisplayUsers();
            ClearInput();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedUserId == -1)
            {
                MessageBox.Show("No user selected for deletion.");
                return;
            }

            var confirm = MessageBox.Show("Do you want to delete this user?", "Confirm", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                UserController.DeleteUser(selectedUserId);
                DisplayUsers();
                ClearInput();
            }
        }

        private void dgvUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvUsers.Rows[e.RowIndex].Cells[0].Value != null)
            {
                selectedUserId = Convert.ToInt32(dgvUsers.Rows[e.RowIndex].Cells[0].Value);
                txtusername.Text = dgvUsers.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtPassword.Text = dgvUsers.Rows[e.RowIndex].Cells[2].Value.ToString();
                cmbRole.Text = dgvUsers.Rows[e.RowIndex].Cells[3].Value.ToString();
            }
        }

        private void UserForm_Load(object sender, EventArgs e)
        {

        }

        private void cmbRole_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
