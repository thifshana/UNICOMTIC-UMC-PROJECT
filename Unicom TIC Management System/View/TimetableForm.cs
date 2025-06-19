using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unicom_TIC_Management_System.Controller;
using Unicom_TIC_Management_System.Database;
using Unicom_TIC_Management_System.Models;

namespace Unicom_TIC_Management_System.View
{
    public partial class TimetableForm : Form
    {

        public TimetableForm()
        {
            InitializeComponent();
            LoadSubjects();
            LoadRooms();
            LoadTimetables();

        }

        private void TimetableForm_Load(object sender, EventArgs e)
        {

        }

        private void dgvTimetable_systemchanged(object sender, EventArgs e)
        {
            if (dgvTimetable.SelectedRows.Count > 0)
            {
                var row = dgvTimetable.SelectedRows[0];
                selectedID = Convert.ToInt32(row.Cells["TimetableID"].Value);
                txtTimeSlot.Text = row.Cells["TimeSlot"].Value.ToString();

                // Select Subject
                foreach (Subject item in cmbSubject.Items)
                {
                    if (item.SubjectID == Convert.ToInt32(row.Cells["SubjectID"].Value))
                    {
                        cmbSubject.SelectedItem = item;
                        break;
                    }
                }

                // Select Room
                foreach (Room item in cmbRoom.Items)
                {
                    if (item.RoomID == Convert.ToInt32(row.Cells["RoomID"].Value))
                    {
                        cmbRoom.SelectedItem = item;
                        break;
                    }
                }
            }
        }
        public class Subject
        {
            public int SubjectID { get; set; }
            public string SubjectName { get; set; }
            public override string ToString() => SubjectName;
        }

        public class Room
        {
            public int RoomID { get; set; }
            public string RoomName { get; set; }
            public override string ToString() => RoomName;
        }
        private TimetableController timetableController = new TimetableController();
        private int selectedID = -1;


        private void LoadSubjects()
        {
            cmbSubject.Items.Clear();
            using (var conn = DbConfig.GetConnection())
            {
                var cmd = new SQLiteCommand("SELECT SubjectID, SubjectName FROM Subject", conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        cmbSubject.Items.Add(new Subject
                        {
                            SubjectID = Convert.ToInt32(reader["SubjectID"]),
                            SubjectName = reader["SubjectName"].ToString()
                        });
                    }
                }
            }
        }

        private void LoadRooms()
        {
            cmbRoom.Items.Clear();
            using (var conn = DbConfig.GetConnection())
            {
                var cmd = new SQLiteCommand("SELECT RoomID, RoomName FROM Room", conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        cmbRoom.Items.Add(new Room
                        {
                            RoomID = Convert.ToInt32(reader["RoomID"]),
                            RoomName = reader["RoomName"].ToString()
                        });
                    }
                }
            }
        }

        private void LoadTimetables()
        {
            dgvTimetable.DataSource = timetableController.GetAll();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cmbSubject.SelectedItem is Subject subject && cmbRoom.SelectedItem is Room room)
            {
                var timetable = new Timetable
                {
                    SubjectID = subject.SubjectID,
                    TimeSlot = txtTimeSlot.Text,
                    RoomID = room.RoomID
                };

                timetableController.Create(timetable);
                LoadTimetables();
                ClearFields();
            }
        }

        private void Bt_Click(object sender, EventArgs e)
        {

            if (selectedID == -1) return;

            if (cmbSubject.SelectedItem is Subject subject && cmbRoom.SelectedItem is Room room)
            {
                var timetable = new Timetable
                {
                    TimetableID = selectedID,
                    SubjectID = subject.SubjectID,
                    TimeSlot = txtTimeSlot.Text,
                    RoomID = room.RoomID
                };

                timetableController.Update(timetable);
                LoadTimetables();
                ClearFields();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            if (selectedID != -1)
            {
                timetableController.Delete(selectedID);
                LoadTimetables();
                ClearFields();
            }
        }

        private void ClearFields()
        {
            cmbSubject.SelectedIndex = -1;
            cmbRoom.SelectedIndex = -1;
            txtTimeSlot.Clear();
            selectedID = -1;
        }

        private void cmbRoom_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void cmbSubject_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dgvTimetable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {







        }
    }

}




