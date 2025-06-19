using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unicom_TIC_Management_System.Models;
using static System.Collections.Specialized.BitVector32;

namespace Unicom_TIC_Management_System.View
{
    public partial class MainForm : Form
    {
      
        string _role;

 

        public MainForm(string Role)
        {
            _role = Role;
            InitializeComponent();
           
            
            ApplyRolePermissions();
        }
        private void LoadFormInPanel(Form form)
        {
            panel2.Controls.Clear();           // Clear previous controls
            form.TopLevel = false;                     // Make it a child form
            form.FormBorderStyle = FormBorderStyle.None; // Remove borders
            form.Dock = DockStyle.Fill;                // Fill the panel
            panel2.Controls.Add(form);         // Add form to panel
            form.Show();                               // Show the form
        }
        private void ApplyRolePermissions()
        {
            string role = _role;

            if (role == "Admin")
            {
                // Full access
                
            }
            else if (role == "Lecture")
            {
                btnuser.Visible = false;
                button4.Visible = true;
                button1.Visible = false;
                button7.Visible = false;
            }
            else if (role == "Staff")
            {
                btnuser.Visible = false ;
            }
            else if (role == "Student")
            {
                button4.Visible = false;
                button6.Visible = false;
                btnuser.Visible = false;
                button1.Visible = false;

                
            }
        }

        

        private void btnuser_Click(object sender, EventArgs e)
        {
            LoadFormInPanel(new UserForm());
        }

        private void button6_Click(object sender, EventArgs e)
        {
            LoadFormInPanel(new StudentForm());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadFormInPanel(new courseForm1());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LoadFormInPanel(new ExamForm());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            LoadFormInPanel(new MarkForm());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            LoadFormInPanel(new RoomForm());
        }

        private void button7_Click(object sender, EventArgs e)
        {
            LoadFormInPanel(new SubjectForm());
        }

        private void button9_Click(object sender, EventArgs e)
        {
            LoadFormInPanel(new TimetableForm());
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
