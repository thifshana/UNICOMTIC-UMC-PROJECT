namespace Unicom_TIC_Management_System.View
{
    partial class courseForm1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(courseForm1));
            this.txtCourseName = new System.Windows.Forms.TextBox();
            this.view_all_course = new System.Windows.Forms.DataGridView();
            this.add = new System.Windows.Forms.Button();
            this.update = new System.Windows.Forms.Button();
            this.delete = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.view_all_course)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtCourseName
            // 
            this.txtCourseName.BackColor = System.Drawing.Color.White;
            this.txtCourseName.Font = new System.Drawing.Font("Forte", 9.75F);
            this.txtCourseName.Location = new System.Drawing.Point(153, 57);
            this.txtCourseName.Name = "txtCourseName";
            this.txtCourseName.Size = new System.Drawing.Size(301, 25);
            this.txtCourseName.TabIndex = 0;
            this.txtCourseName.TextChanged += new System.EventHandler(this.txtCourseName_TextChanged);
            // 
            // view_all_course
            // 
            this.view_all_course.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.view_all_course.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.view_all_course.Location = new System.Drawing.Point(30, 118);
            this.view_all_course.Name = "view_all_course";
            this.view_all_course.RowHeadersWidth = 62;
            this.view_all_course.Size = new System.Drawing.Size(442, 191);
            this.view_all_course.TabIndex = 1;
            this.view_all_course.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.view_all_course_CellContentClick);
            this.view_all_course.SelectionChanged += new System.EventHandler(this.view_all_course_SelectionChanged);
            // 
            // add
            // 
            this.add.BackColor = System.Drawing.Color.Black;
            this.add.Font = new System.Drawing.Font("Forte", 9.75F);
            this.add.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.add.Location = new System.Drawing.Point(506, 118);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(75, 33);
            this.add.TabIndex = 2;
            this.add.Text = "ADD";
            this.add.UseVisualStyleBackColor = false;
            this.add.Click += new System.EventHandler(this.add_Click);
            // 
            // update
            // 
            this.update.BackColor = System.Drawing.Color.Black;
            this.update.Font = new System.Drawing.Font("Forte", 9.75F);
            this.update.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.update.Location = new System.Drawing.Point(506, 194);
            this.update.Name = "update";
            this.update.Size = new System.Drawing.Size(75, 34);
            this.update.TabIndex = 3;
            this.update.Text = "UPDATE";
            this.update.UseVisualStyleBackColor = false;
            this.update.Click += new System.EventHandler(this.update_Click);
            // 
            // delete
            // 
            this.delete.BackColor = System.Drawing.Color.Black;
            this.delete.Font = new System.Drawing.Font("Forte", 9.75F);
            this.delete.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.delete.Location = new System.Drawing.Point(506, 272);
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(75, 37);
            this.delete.TabIndex = 4;
            this.delete.Text = "DELETE";
            this.delete.UseVisualStyleBackColor = false;
            this.delete.Click += new System.EventHandler(this.delete_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.LightPink;
            this.label1.Font = new System.Drawing.Font("Forte", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(27, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 14);
            this.label1.TabIndex = 5;
            this.label1.Text = "Course Name : ";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(532, 16);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(44, 42);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Forte", 9.75F);
            this.label2.Location = new System.Drawing.Point(514, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 14);
            this.label2.TabIndex = 7;
            this.label2.Text = "Course Menu";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // courseForm1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightPink;
            this.ClientSize = new System.Drawing.Size(605, 367);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.delete);
            this.Controls.Add(this.update);
            this.Controls.Add(this.add);
            this.Controls.Add(this.view_all_course);
            this.Controls.Add(this.txtCourseName);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "courseForm1";
            this.Text = "courseForm1";
            ((System.ComponentModel.ISupportInitialize)(this.view_all_course)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtCourseName;
        private System.Windows.Forms.DataGridView view_all_course;
        private System.Windows.Forms.Button add;
        private System.Windows.Forms.Button update;
        private System.Windows.Forms.Button delete;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
    }
}