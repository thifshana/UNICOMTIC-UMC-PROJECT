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
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private TextBox NICtxt;
        private TextBox teletxt;
        private TextBox guardiantxt;
        private TextBox SOEdu;
        private DateTimePicker Picker;
        private Label studentname;

        public StudentForm()
        {
            InitializeComponent();
            DisplayCourses();
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
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.NICtxt = new System.Windows.Forms.TextBox();
            this.teletxt = new System.Windows.Forms.TextBox();
            this.guardiantxt = new System.Windows.Forms.TextBox();
            this.SOEdu = new System.Windows.Forms.TextBox();
            this.Picker = new System.Windows.Forms.DateTimePicker();
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
            this.txtStudentName.Location = new System.Drawing.Point(150, 12);
            this.txtStudentName.Name = "txtStudentName";
            this.txtStudentName.Size = new System.Drawing.Size(342, 25);
            this.txtStudentName.TabIndex = 2;
            // 
            // cmbCourse
            // 
            this.cmbCourse.BackColor = System.Drawing.Color.White;
            this.cmbCourse.Font = new System.Drawing.Font("Forte", 9.75F);
            this.cmbCourse.FormattingEnabled = true;
            this.cmbCourse.Location = new System.Drawing.Point(150, 43);
            this.cmbCourse.Name = "cmbCourse";
            this.cmbCourse.Size = new System.Drawing.Size(342, 22);
            this.cmbCourse.TabIndex = 3;
            // 
            // deletestudent
            // 
            this.deletestudent.BackColor = System.Drawing.Color.Black;
            this.deletestudent.Font = new System.Drawing.Font("Forte", 9.75F);
            this.deletestudent.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.deletestudent.Location = new System.Drawing.Point(509, 315);
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
            this.Updatestudent.Location = new System.Drawing.Point(509, 254);
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
            this.addstudent.Location = new System.Drawing.Point(509, 198);
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
            this.dgvstudents.Location = new System.Drawing.Point(37, 198);
            this.dgvstudents.Name = "dgvstudents";
            this.dgvstudents.RowHeadersWidth = 62;
            this.dgvstudents.Size = new System.Drawing.Size(455, 157);
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
            this.Course.Location = new System.Drawing.Point(37, 47);
            this.Course.Name = "Course";
            this.Course.Size = new System.Drawing.Size(52, 14);
            this.Course.TabIndex = 8;
            this.Course.Text = "Course :";
            this.Course.Click += new System.EventHandler(this.Course_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(539, 100);
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
            this.label2.Location = new System.Drawing.Point(506, 167);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 14);
            this.label2.TabIndex = 10;
            this.label2.Text = "Student Detials";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(37, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "NIC";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(37, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Phone num";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(37, 124);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Date of birth";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(37, 141);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "guardian";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(37, 172);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(111, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Specific of  Education";
            // 
            // NICtxt
            // 
            this.NICtxt.Location = new System.Drawing.Point(150, 66);
            this.NICtxt.Name = "NICtxt";
            this.NICtxt.Size = new System.Drawing.Size(342, 20);
            this.NICtxt.TabIndex = 16;
            // 
            // teletxt
            // 
            this.teletxt.Location = new System.Drawing.Point(150, 92);
            this.teletxt.Name = "teletxt";
            this.teletxt.Size = new System.Drawing.Size(342, 20);
            this.teletxt.TabIndex = 17;
            // 
            // guardiantxt
            // 
            this.guardiantxt.Location = new System.Drawing.Point(150, 141);
            this.guardiantxt.Name = "guardiantxt";
            this.guardiantxt.Size = new System.Drawing.Size(342, 20);
            this.guardiantxt.TabIndex = 18;
            // 
            // SOEdu
            // 
            this.SOEdu.Location = new System.Drawing.Point(150, 172);
            this.SOEdu.Name = "SOEdu";
            this.SOEdu.Size = new System.Drawing.Size(342, 20);
            this.SOEdu.TabIndex = 19;
            // 
            // Picker
            // 
            this.Picker.Location = new System.Drawing.Point(150, 117);
            this.Picker.Name = "Picker";
            this.Picker.Size = new System.Drawing.Size(200, 20);
            this.Picker.TabIndex = 20;
            // 
            // StudentForm
            // 
            this.BackColor = System.Drawing.Color.LightPink;
            this.ClientSize = new System.Drawing.Size(611, 367);
            this.Controls.Add(this.Picker);
            this.Controls.Add(this.SOEdu);
            this.Controls.Add(this.guardiantxt);
            this.Controls.Add(this.teletxt);
            this.Controls.Add(this.NICtxt);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
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
            DisplayCourses(); // 🔄 Make sure it's called here too, just in case
            DisplayStudents(); // load all student data
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (selectedStudentID == -1)
            {
                MessageBox.Show("Please, you should select a user to delete.");
                return;
            }

            var confirm = MessageBox.Show("Do you want to delete this user?", "Confirm", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                StudentController.DeleteStudent(selectedStudentID);
                DisplayStudents();
                ClearInputs();
            }
        }

        private void addstudent_Click(object sender, EventArgs e)
        {
            var student = new Student
            {
                StudentID = selectedStudentID,
                Name = txtStudentName.Text,
                CourseID = (int)cmbCourse.SelectedValue,
                Dateofbirth = Picker.Value,
                NIC = int.Parse(NICtxt.Text),
                PhoneNB = int.Parse(teletxt.Text),
                SpecificEDU = SOEdu.Text,
                Guardian = guardiantxt.Text.Trim()
            };

            StudentController.AddStudent(student);
            DisplayStudents();
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
        private void DisplayStudents()
        {
            dgvstudents.DataSource = null;
            dgvstudents.DataSource = StudentController.GetAllStudents();
        }
        private CourseController courseController = new CourseController();
        private void DisplayCourses()
        {
            var courses = courseController.GetAllCourses();
            cmbCourse.DataSource = courses;
            cmbCourse.DisplayMember = "CourseName";
            cmbCourse.ValueMember = "CourseID";
        }
        private void ClearInputs()
        {
            txtStudentName.Text = "";
            txtStudentName.Clear();
            NICtxt.Clear();
            teletxt.Clear();
            guardiantxt.Clear();
            SOEdu.Clear();
            Picker.Value = DateTime.Today;
            cmbCourse.SelectedIndex = -1;

        }
        private int selectedStudentID = -1;

        private void dgvstudents_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvstudents.CurrentRow != null && dgvstudents.CurrentRow.Index >= 0)
            {
                selectedStudentID = Convert.ToInt32(dgvstudents.CurrentRow.Cells["StudentID"].Value);
                txtStudentName.Text = dgvstudents.CurrentRow.Cells["Name"].Value?.ToString();
                cmbCourse.Text = dgvstudents.CurrentRow.Cells["courseId"].Value?.ToString();
                NICtxt.Text = dgvstudents.CurrentRow.Cells["NIC"].Value?.ToString();
                teletxt.Text = dgvstudents.CurrentRow.Cells["PhoneNB"].Value?.ToString();
                guardiantxt.Text = dgvstudents.CurrentRow.Cells["Guardian"].Value?.ToString();
                SOEdu.Text = dgvstudents.CurrentRow.Cells["SpecificEDU"].Value?.ToString();
                Picker.Value = Convert.ToDateTime(dgvstudents.CurrentRow.Cells["Dateofbirth"].Value);

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
                MessageBox.Show("Select a student record to update.");
                return;
            }

            var student = new Student
            {
                StudentID = selectedStudentID,
                Name = txtStudentName.Text,
                CourseID = (int)cmbCourse.SelectedValue,
                Dateofbirth = Picker.Value,
                NIC = int.Parse(NICtxt.Text),
                PhoneNB = int.Parse(teletxt.Text),
                SpecificEDU = SOEdu.Text,
                Guardian = guardiantxt.Text.Trim()


            };

            StudentController.UpdateStudent(student);
            DisplayStudents();
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
