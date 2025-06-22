using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Unicom_TIC_Management_System.Controller;
using Unicom_TIC_Management_System.Models;

namespace Unicom_TIC_Management_System.View
{
    public partial class RoomForm : Form
    {
        public RoomForm()
        {
            InitializeComponent();
            cmbRoomType.Items.AddRange(new string[] { "Lecture Hall" , "Main Lab" ,"Mini Lab-01" ,  "Mini lab-02" , "StaffRoom" , "OfficeRoom"});
            DisplayRooms();
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            Room r = new Room();
            r.RoomName = txtRoomName.Text;

            //RoomController.AddRoom(r);
            MessageBox.Show("Room added.");
        }
        private int selectedRoomId = -1;
        private void ShowsRoomList(object sender, EventArgs e)
        {
            

            if (dgvRooms.CurrentRow != null && dgvRooms.CurrentRow.Index >= 0)
            {
                selectedRoomId = Convert.ToInt32(dgvRooms.CurrentRow.Cells["RoomID"].Value);
                txtRoomName.Text = dgvRooms.CurrentRow.Cells["RoomName"].Value?.ToString();
               // txtPassword.Text = dgvRooms.CurrentRow.Cells["Password"].Value?.ToString();
                cmbRoomType.Text = dgvRooms.CurrentRow.Cells["RoomType"].Value?.ToString();
            }
            else
            {
                selectedRoomId = -1;
                txtRoomName.Clear();
                
                cmbRoomType.SelectedIndex = 0; // Optional default

            }
        }

        private void txtRoomName_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void btnAddRoom_Click(object sender, EventArgs e)
        {

            {

                if (string.IsNullOrWhiteSpace(txtRoomName.Text))
                {
                    MessageBox.Show("Room Name is required..", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (cmbRoomType.SelectedItem == null)
                {
                    MessageBox.Show("Please  choose a Room Type.", "Input  Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string roomType = cmbRoomType.SelectedItem.ToString();

                Room room = new Room
                {
                    RoomName = txtRoomName.Text.Trim(),
                    RoomType = roomType
                };

                try
                {
                    RoomController roomController = new RoomController();
                    roomController.Create(room);
                    MessageBox.Show("Room successfully added!", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    txtRoomName.Clear();
                    cmbRoomType.SelectedIndex = 0; // Reset selection
                    DisplayRooms();
                    ClearFields();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error occurred while adding room: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

        }
        private void DisplayRooms()
        {
            RoomController roomController = new RoomController();
            var roomList = roomController.GetAll(); // Get all rooms from DB

            dgvRooms.DataSource = null;
            dgvRooms.DataSource = roomList;

            // Optional: auto-size columns for better appearance
            dgvRooms.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }

        private void ClearFields()
        {
            txtRoomName.Clear();
            cmbRoomType.SelectedIndex = -1;
            selectedRoomId = -1;
        }

        private void dgvRooms_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvRooms.Rows[e.RowIndex];
                selectedRoomId = Convert.ToInt32(row.Cells["RoomID"].Value);
                txtRoomName.Text = row.Cells["RoomName"].Value?.ToString();
                cmbRoomType.SelectedItem = row.Cells["RoomType"].Value?.ToString();
            }
        }

        private void btnUpdateRoom_Click(object sender, EventArgs e)
        {

            if (selectedRoomId == -1)
            {
                MessageBox.Show("Select a room before updating.", " Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtRoomName.Text) || cmbRoomType.SelectedItem == null)
            {
                MessageBox.Show("All fields are mandatory.", "Input Incomplete", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show("Do you want to update this room?", "Confirm Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No) return;
            var updatedRoom = new Room
            {
                RoomID = selectedRoomId,
                RoomName = txtRoomName.Text.Trim(),
                RoomType = cmbRoomType.SelectedItem.ToString()
            };

            try
            {
                roomController.Update(updatedRoom);
                MessageBox.Show("Room updated.", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFields();
                DisplayRooms();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Update failed:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private RoomController roomController = new RoomController();
        private void btnDeleteRoom_Click(object sender, EventArgs e)
        {
            {
            if (dgvRooms.CurrentRow == null)
            {
                MessageBox.Show("No room selected.", " Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int roomId = Convert.ToInt32(dgvRooms.CurrentRow.Cells["RoomID"].Value);

            var result = MessageBox.Show("Do you want to delete this room?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                try
                {
                    roomController.Delete(roomId);
                    MessageBox.Show("Room deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DisplayRooms(); // refresh the DataGridView
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Couldn't delete room: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

        }

        private void cmbRoomType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void RoomForm_Load(object sender, EventArgs e)
        {
            dgvRooms.SelectionChanged += ShowsRoomList;
            this.txtRoomName.TextChanged += new System.EventHandler(this.txtRoomName_TextChanged);

        }
    }
}
