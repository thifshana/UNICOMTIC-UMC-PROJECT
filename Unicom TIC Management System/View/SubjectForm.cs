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
using Unicom_TIC_Management_System.Models;

namespace Unicom_TIC_Management_System.View
{
    public partial class SubjectForm : Form
    {

        private SubjectController subjectController = new SubjectController();
        private CourseController courseController = new CourseController(); // optional if using dropdown

        public SubjectForm()
        {
            InitializeComponent();
            LoadCourses();
            LoadSubjects();
        }
        private void LoadCourses()
        {
            var courses = courseController.GetAllCourses();
            cmbCourseID.DataSource = courses;
            cmbCourseID.DisplayMember = "CourseName";
            cmbCourseID.ValueMember = "CourseID";
        }

        private void LoadSubjects()
        {
            dgvSubjects.DataSource = null;
            dgvSubjects.DataSource = subjectController.GetAllSubjects();
        }
        private void ClearFields()
        {
            txtSubjectName.Clear();
            cmbCourseID.SelectedIndex = 0;
        }

        private void dgvSubjects_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvSubjects.CurrentRow != null)
            {
                // Get the CourseName value from the selected row
                var courseName = dgvSubjects.CurrentRow.Cells["SubjectName"].Value?.ToString();

                if (!string.IsNullOrEmpty(courseName))
                {
                    txtSubjectName.Text = courseName;
                }
                else
                {
                    txtSubjectName.Clear();
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSubjectName.Text))
            {
                MessageBox.Show("Please enter a subject name.");
                return;
            }

            Subject subject = new Subject
            {
                SubjectName = txtSubjectName.Text.Trim(),
                CourseID = (int)cmbCourseID.SelectedValue
            };

            subjectController.AddSubject(subject);
            MessageBox.Show("Subject added successfully!");
            LoadSubjects();
            ClearFields();
        }

        private void dgvSubjects_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvSubjects.Rows[e.RowIndex];
                txtSubjectName.Text = row.Cells["SubjectName"].Value.ToString();
                cmbCourseID.SelectedValue = Convert.ToInt32(row.Cells["CourseID"].Value);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvSubjects.CurrentRow == null)
            {
                MessageBox.Show("Please select a subject to update.");
                return;
            }

            int subjectId = Convert.ToInt32(dgvSubjects.CurrentRow.Cells["SubjectID"].Value);

            Subject subject = new Subject
            {
                SubjectID = subjectId,
                SubjectName = txtSubjectName.Text.Trim(),
                CourseID = (int)cmbCourseID.SelectedValue
            };

            subjectController.UpdateSubject(subject);
            MessageBox.Show("Subject updated successfully!");
            LoadSubjects();
            ClearFields();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvSubjects.CurrentRow == null)
            {
                MessageBox.Show("Please select a subject to delete.");
                return;
            }

            int subjectId = Convert.ToInt32(dgvSubjects.CurrentRow.Cells["SubjectID"].Value);
            subjectController.DeleteSubject(subjectId);
            MessageBox.Show("Subject deleted successfully!");
            LoadSubjects();
            ClearFields();
        }

        private void lblSubjectName_Click(object sender, EventArgs e)
        {

        }

        private void SubjectForm_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lblCourseID_Click(object sender, EventArgs e)
        {

        }

        private void cmbCourseID_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }


}
