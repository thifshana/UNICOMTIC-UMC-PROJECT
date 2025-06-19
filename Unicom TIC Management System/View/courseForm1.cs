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
    public partial class courseForm1 : Form
    {
        private CourseController courseController = new CourseController();
        public courseForm1()
        {
            InitializeComponent();
            LoadCourses();
        }



        private void LoadCourses()
        {
            try
            {
                var courses = courseController.GetAll();
                view_all_course.DataSource = courses;

                // Optional: Customize columns if needed, e.g. hide CourseID or rename headers
                view_all_course.Columns["CourseID"].HeaderText = "ID";
                view_all_course.Columns["CourseName"].HeaderText = "Course Name";
                view_all_course.AutoResizeColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load courses: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void add_Click(object sender, EventArgs e)
        {
            Course course = new Course
            {
                CourseName = txtCourseName.Text,
            };

            CourseController courseController = new CourseController();
            courseController.Create(course);

            txtCourseName.Text = "";
            MessageBox.Show("Succefully Added!");

            LoadCourses();

        }

        private void view_all_course_SelectionChanged(object sender, EventArgs e)
        {
            if (view_all_course.CurrentRow != null)
            {
                // Get the CourseName value from the selected row
                var courseName = view_all_course.CurrentRow.Cells["CourseName"].Value?.ToString();

                if (!string.IsNullOrEmpty(courseName))
                {
                    txtCourseName.Text = courseName;
                }
                else
                {
                    txtCourseName.Clear();
                }
            }
        }

        private void update_Click(object sender, EventArgs e)
        {
            if (view_all_course.CurrentRow == null)
            {
                MessageBox.Show("Please select a course to update.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string newCourseName = txtCourseName.Text.Trim();
            if (string.IsNullOrEmpty(newCourseName))
            {
                MessageBox.Show("Please enter a valid course name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int courseId = Convert.ToInt32(view_all_course.CurrentRow.Cells["CourseID"].Value);

            var course = new Course
            {
                CourseID = courseId,
                CourseName = newCourseName
            };

            try
            {
                bool updated = courseController.Update(course);
                if (updated)
                {
                    MessageBox.Show("Course updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadCourses(); // Refresh DataGridView
                    txtCourseName.Clear();
                }
                else
                {
                    MessageBox.Show("Update failed. Course not found.", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating course: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void delete_Click(object sender, EventArgs e)
        {
            if (view_all_course.CurrentRow == null)
            {
                MessageBox.Show("Please select a course to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int courseId = Convert.ToInt32(view_all_course.CurrentRow.Cells["CourseID"].Value);

            var confirmResult = MessageBox.Show("Are you sure you want to delete this course?",
                                                "Confirm Delete",
                                                MessageBoxButtons.YesNo,
                                                MessageBoxIcon.Question);

            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    bool deleted = courseController.Delete(courseId);
                    if (deleted)
                    {
                        MessageBox.Show("Course deleted successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadCourses();
                        txtCourseName.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Delete failed. Course not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting course: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtCourseName_TextChanged(object sender, EventArgs e)
        {

        }

        private void view_all_course_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void courseForm1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }

}
