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
 

            cmbRole.Items.AddRange(new string[] { "Admin", "Staff" ,"Student" ,"Lecture" });
            LoadUsers();
        }
        private void LoadUsers()
        {
            try
            {
                var courses = UserController.GetAllUsers();
                dgvUsers.DataSource = courses;

                // Optional: Customize columns if needed, e.g. hide CourseID or rename headers
                dgvUsers.Columns["UserID"].HeaderText = "UserID";
                dgvUsers.Columns["Username"].HeaderText = "Username ";
                dgvUsers.Columns["Password"].HeaderText = "Password ";
                dgvUsers.Columns["Role"].HeaderText = "Role ";
                dgvUsers.AutoResizeColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load courses: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearForm()
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
            LoadUsers();
            ClearForm();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedUserId == -1)
            {
                MessageBox.Show("Please select a user to update.");
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
            LoadUsers();
            ClearForm();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedUserId == -1)
            {
                MessageBox.Show("Please select a user to delete.");
                return;
            }

            var confirm = MessageBox.Show("Are you sure to delete this user?", "Confirm", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                UserController.DeleteUser(selectedUserId);
                LoadUsers();
                ClearForm();
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
