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
    public partial class ExamForm : Form
    {
        public ExamForm()
        {
            InitializeComponent();
            DisplayExams();
            LoadSubjects();


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvExams_SelectionChanged(object sender, EventArgs e)
        {

            cmbSubjects.SelectedIndexChanged -= cmbSubjects_SelectedIndexChanged;

            if (dgvExams.CurrentRow != null)
            {
                txtExamName.Text = dgvExams.CurrentRow.Cells["ExamName"].Value.ToString();
                int selectedSubjectId = Convert.ToInt32(dgvExams.CurrentRow.Cells["SubjectID"].Value);
                cmbSubjects.SelectedValue = selectedSubjectId;
            }

            cmbSubjects.SelectedIndexChanged += cmbSubjects_SelectedIndexChanged;
        }

        private void btnAddExam_Click(object sender, EventArgs e)
        {
            string examName = txtExamName.Text.Trim();

            if (string.IsNullOrEmpty(examName) || cmbSubjects.SelectedItem == null)
            {
                MessageBox.Show("You should enter valid exam name and select a subject.");
                return;
            }

            int subjectId = Convert.ToInt32(cmbSubjects.SelectedValue);

            var exam = new Exam
            {
                ExamName = examName,
                SubjectID = subjectId
            };

            examController.Create(exam);
            MessageBox.Show("Exam added Successfully!");
            DisplayExams();
            Cleardetails();
        }
        private void Cleardetails()
        {
            txtExamName.Clear();
            cmbSubjects.SelectedIndex = -1;
        }
        private ExamController examController = new ExamController();
        private void btnUpdateExam_Click(object sender, EventArgs e)
        {
            if (dgvExams.CurrentRow == null || cmbSubjects.SelectedItem == null)
                return;

            int examId = Convert.ToInt32(dgvExams.CurrentRow.Cells["ExamID"].Value);
            string examName = txtExamName.Text.Trim();
            int subjectId = Convert.ToInt32(cmbSubjects.SelectedValue);

            if (string.IsNullOrEmpty(examName))
            {
                MessageBox.Show("Please, Enter exam name.");
                return;
            }

            var exam = new Exam
            {
                ExamID = examId,
                ExamName = examName,
                SubjectID = subjectId
            };

            ExamController ExamController = new ExamController();
            bool updated = examController.Update(exam);
            MessageBox.Show(updated ? "Exam updated successfully!" : "Update failed.!");
            DisplayExams();
            Cleardetails();
        }
        private void ExamForm_Load(object sender, EventArgs e)
        {
            LoadSubjects();
            DisplayExams();
        }

        private void LoadSubjects()
        {
            SubjectController subjectController = new SubjectController();
            List<Subject> subjects = subjectController.GetAllSubjects();
            cmbSubjects.DataSource = subjects;
            cmbSubjects.DisplayMember = "SubjectName";
            cmbSubjects.ValueMember = "SubjectID";
        }
        private void DisplayExams()
        {
            ExamController ExamController = new ExamController();
            var exams = examController.GetAll();
            dgvExams.DataSource = exams;
        }

        private void cmbSubjects_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void btnDeleteExam_Click(object sender, EventArgs e)
        {
            if (dgvExams.CurrentRow == null)
            {
                MessageBox.Show("Please you should select an exam to delete!.", "Deleted Exam", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show("Do you want to delete this exam?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                int examId = Convert.ToInt32(dgvExams.CurrentRow.Cells["ExamID"].Value);

                try
                {
                    examController.Delete(examId);
                    MessageBox.Show("Exam deleted successfully.");
                    DisplayExams();
                    Cleardetails();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Exam deleting faild!: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void lblSubjectID_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
