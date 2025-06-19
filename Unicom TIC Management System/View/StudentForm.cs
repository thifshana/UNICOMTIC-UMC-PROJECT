using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Unicom_TIC_Management_System.Controller;
using Unicom_TIC_Management_System.Controllers;
using Unicom_TIC_Management_System.Models;

namespace Unicom_TIC_Management_System.View
{
    public partial class StudentForm : Form

    {
        private Label label1;
        private TextBox txtStudentName;
        private ComboBox cmbCourse;
        private Button deletestudent;
        private Button Updatestudent;
        private Button addstudent;
        private DataGridView dgvstudents;
        private Label Course;
        private PictureBox pictureBox1;
        private Label label2;
        private Label studentname;

        public StudentForm()
        {
            InitializeComponent();
            LoadCourses();
        }



        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StudentForm));
            this.label1 = new System.Windows.Forms.Label();
            this.studentname = new System.Windows.Forms.Label();
            this.txtStudentName = new System.Windows.Forms.TextBox();
            this.cmbCourse = new System.Windows.Forms.ComboBox();
            this.deletestudent = new System.Windows.Forms.Button();
            this.Updatestudent = new System.Windows.Forms.Button();
            this.addstudent = new System.Windows.Forms.Button();
            this.dgvstudents = new System.Windows.Forms.DataGridView();
            this.Course = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvstudents)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(34, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(10, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = " ";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // studentname
            // 
            this.studentname.AutoSize = true;
            this.studentname.BackColor = System.Drawing.Color.LightPink;
            this.studentname.Font = new System.Drawing.Font("Forte", 9.75F);
            this.studentname.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.studentname.Location = new System.Drawing.Point(34, 24);
            this.studentname.Name = "studentname";
            this.studentname.Size = new System.Drawing.Size(92, 14);
            this.studentname.TabIndex = 1;
            this.studentname.Text = "Student Name :";
            this.studentname.Click += new System.EventHandler(this.studentname_Click);
            // 
            // txtStudentName
            // 
            this.txtStudentName.BackColor = System.Drawing.Color.White;
            this.txtStudentName.Font = new System.Drawing.Font("Forte", 9.75F);
            this.txtStudentName.Location = new System.Drawing.Point(150, 22);
            this.txtStudentName.Name = "txtStudentName";
            this.txtStudentName.Size = new System.Drawing.Size(342, 25);
            this.txtStudentName.TabIndex = 2;
            // 
            // cmbCourse
            // 
            this.cmbCourse.BackColor = System.Drawing.Color.White;
            this.cmbCourse.Font = new System.Drawing.Font("Forte", 9.75F);
            this.cmbCourse.FormattingEnabled = true;
            this.cmbCourse.Location = new System.Drawing.Point(150, 61);
            this.cmbCourse.Name = "cmbCourse";
            this.cmbCourse.Size = new System.Drawing.Size(342, 22);
            this.cmbCourse.TabIndex = 3;
            // 
            // deletestudent
            // 
            this.deletestudent.BackColor = System.Drawing.Color.Black;
            this.deletestudent.Font = new System.Drawing.Font("Forte", 9.75F);
            this.deletestudent.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.deletestudent.Location = new System.Drawing.Point(509, 284);
            this.deletestudent.Name = "deletestudent";
            this.deletestudent.Size = new System.Drawing.Size(74, 40);
            this.deletestudent.TabIndex = 4;
            this.deletestudent.Text = "DELETE ";
            this.deletestudent.UseVisualStyleBackColor = false;
            this.deletestudent.Click += new System.EventHandler(this.button1_Click);
            // 
            // Updatestudent
            // 
            this.Updatestudent.BackColor = System.Drawing.Color.Black;
            this.Updatestudent.Font = new System.Drawing.Font("Forte", 9.75F);
            this.Updatestudent.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Updatestudent.Location = new System.Drawing.Point(509, 200);
            this.Updatestudent.Name = "Updatestudent";
            this.Updatestudent.Size = new System.Drawing.Size(74, 43);
            this.Updatestudent.TabIndex = 5;
            this.Updatestudent.Text = "UPDATE";
            this.Updatestudent.UseVisualStyleBackColor = false;
            this.Updatestudent.Click += new System.EventHandler(this.Updatestudent_Click);
            // 
            // addstudent
            // 
            this.addstudent.BackColor = System.Drawing.Color.Black;
            this.addstudent.Font = new System.Drawing.Font("Forte", 9.75F);
            this.addstudent.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.addstudent.Location = new System.Drawing.Point(509, 126);
            this.addstudent.Name = "addstudent";
            this.addstudent.Size = new System.Drawing.Size(74, 40);
            this.addstudent.TabIndex = 6;
            this.addstudent.Text = "ADD";
            this.addstudent.UseVisualStyleBackColor = false;
            this.addstudent.Click += new System.EventHandler(this.addstudent_Click);
            // 
            // dgvstudents
            // 
            this.dgvstudents.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvstudents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvstudents.GridColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvstudents.Location = new System.Drawing.Point(37, 126);
            this.dgvstudents.Name = "dgvstudents";
            this.dgvstudents.RowHeadersWidth = 62;
            this.dgvstudents.Size = new System.Drawing.Size(455, 198);
            this.dgvstudents.TabIndex = 7;
            this.dgvstudents.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvstudents_CellContentClick);
            this.dgvstudents.SelectionChanged += new System.EventHandler(this.dgvstudents_SelectionChanged);
            // 
            // Course
            // 
            this.Course.AutoSize = true;
            this.Course.BackColor = System.Drawing.Color.LightPink;
            this.Course.Font = new System.Drawing.Font("Forte", 9.75F);
            this.Course.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Course.Location = new System.Drawing.Point(34, 68);
            this.Course.Name = "Course";
            this.Course.Size = new System.Drawing.Size(52, 14);
            this.Course.TabIndex = 8;
            this.Course.Text = "Course :";
            this.Course.Click += new System.EventHandler(this.Course_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(533, 15);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(60, 64);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Font = new System.Drawing.Font("Forte", 9.75F);
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(515, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 14);
            this.label2.TabIndex = 10;
            this.label2.Text = "Student Detials";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // StudentForm
            // 
            this.BackColor = System.Drawing.Color.LightPink;
            this.ClientSize = new System.Drawing.Size(611, 367);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Course);
            this.Controls.Add(this.dgvstudents);
            this.Controls.Add(this.addstudent);
            this.Controls.Add(this.Updatestudent);
            this.Controls.Add(this.deletestudent);
            this.Controls.Add(this.cmbCourse);
            this.Controls.Add(this.txtStudentName);
            this.Controls.Add(this.studentname);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "StudentForm";
            this.Text = "StudentForm";
            this.Load += new System.EventHandler(this.StudentForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvstudents)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void name_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void StudentForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (selectedStudentID == -1)
            {
                MessageBox.Show("Please select a user to delete.");
                return;
            }

            var confirm = MessageBox.Show("Are you sure to delete this user?", "Confirm", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                StudentController.DeleteStudent(selectedStudentID);
                LoadStudents();
                ClearInputs();
            }
        }

        private void addstudent_Click(object sender, EventArgs e)
        {
            var student = new Student
            {
                StudentID = selectedStudentID,
                Name = txtStudentName.Text,
                CourseID = (int)cmbCourse.SelectedValue
            };

            StudentController.AddStudent(student);
            LoadStudents();
            ClearInputs();

        }


        private void studentname_Click(object sender, EventArgs e)
        {

        }

        private void dgvstudents_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvstudents.Rows[e.RowIndex];
                txtStudentName.Text = row.Cells["Name"].Value.ToString();
                cmbCourse.SelectedValue = Convert.ToInt32(row.Cells["CourseID"].Value);
            }
        }
        private void LoadStudents()
        {
            dgvstudents.DataSource = null;
            dgvstudents.DataSource = StudentController.GetAllStudents();
        }
        private CourseController courseController = new CourseController();
        private void LoadCourses()
        {
            var courses = courseController.GetAllCourses();
            cmbCourse.DataSource = courses;
            cmbCourse.DisplayMember = "CourseName";
            cmbCourse.ValueMember = "CourseID";
        }
        private void ClearInputs()
        {
            txtStudentName.Text = "";

        }
        private int selectedStudentID = -1;

        private void dgvstudents_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvstudents.CurrentRow != null && dgvstudents.CurrentRow.Index >= 0)
            {
                selectedStudentID = Convert.ToInt32(dgvstudents.CurrentRow.Cells["StudentID"].Value);
                txtStudentName.Text = dgvstudents.CurrentRow.Cells["Name"].Value?.ToString();
                cmbCourse.Text = dgvstudents.CurrentRow.Cells["courseId"].Value?.ToString();
            }
            else
            {

                selectedStudentID = -1;

                txtStudentName.Clear();

                cmbCourse.SelectedIndex = -1;
            }
        }

        private void Updatestudent_Click(object sender, EventArgs e)
        {
            if (selectedStudentID == -1)
            {
                MessageBox.Show("Please select a user to update.");
                return;
            }

            var student = new Student
            {
                StudentID = selectedStudentID,
                Name = txtStudentName.Text,
                CourseID = (int)cmbCourse.SelectedValue


            };

            StudentController.UpdateStudent(student);
            LoadStudents();
            ClearInputs();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Course_Click(object sender, EventArgs e)
        {

        }
    }
}
