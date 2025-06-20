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
    public partial class MarkForm : Form
    {
        public MarkForm()
        {
            InitializeComponent();
            DisplayMarks();
        }
        MarkController controller = new MarkController();
        private  void DisplayMarks()
        {
            MarkController markController = new MarkController();
            var marks = markController.GetAllMarks(); // ✅

            gridMark.DataSource = null;
            gridMark.DataSource = marks;
        }   

        private void btnAdd_Click(object sender, EventArgs e)
        {

            try
            {
                Mark newmark = new Mark
                {
                    StudentID = int.Parse(txtStudent.Text),
                    ExamID = int.Parse(txtExamID.Text),
                    Score = int.Parse(txtScore.Text)
                };

                MarkController controller = new MarkController();
                controller.AddMark(newmark); // ✅ ADD instead of DELETE

                DisplayMarks();
                ClearDetails();
                MessageBox.Show("Mark added successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to add mark: " + ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (gridMark.CurrentRow != null)
            {
                try
                {
                    int selectedId = Convert.ToInt32(gridMark.CurrentRow.Cells["MarkID"].Value);

                    Mark updatedMark = new Mark
                    {
                        MarkID = selectedId,
                        StudentID = int.Parse(txtStudent.Text),
                        ExamID = int.Parse(txtExamID.Text),
                        Score = int.Parse(txtScore.Text)
                    };

                    MarkController markController = new MarkController();
                    markController.UpdateMark(updatedMark); // ✅ Pass the mark object

                    DisplayMarks();
                    ClearDetails();
                    MessageBox.Show("Mark updated success-fully!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to update the mark: " + ex.Message);
                }
            }
        }

        private void gridMark_SelectionChanged(object sender, EventArgs e)
        {
            if (gridMark.CurrentRow != null)
            {
                txtStudent.Text = gridMark.CurrentRow.Cells["StudentID"].Value.ToString();
                txtExamID.Text = gridMark.CurrentRow.Cells["ExamID"].Value.ToString();
                txtScore.Text = gridMark.CurrentRow.Cells["Score"].Value.ToString();
            }
        }
        private void ClearDetails()
        {
            txtStudent.Clear();
            txtScore.Clear();
            txtExamID.Clear();
            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (gridMark.CurrentRow != null)
            {
                try
                {
                    int markId = Convert.ToInt32(gridMark.CurrentRow.Cells["MarkID"].Value);

                    MarkController markController = new MarkController();
                    markController.DeleteMark(markId); // ✅ delete selected mark

                    DisplayMarks();
                    ClearDetails();
                    MessageBox.Show("Mark deleted success-fully!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Could not delete the selected mark: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Please, you should select a mark to delete.");
            }
        }

        private void MarkForm_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtScore_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
