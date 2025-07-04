﻿namespace Unicom_TIC_Management_System.View
{
    partial class TimetableForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TimetableForm));
            this.Lb = new System.Windows.Forms.Label();
            this.Lbl = new System.Windows.Forms.Label();
            this.lb3 = new System.Windows.Forms.Label();
            this.cmbSubject = new System.Windows.Forms.ComboBox();
            this.txtTimeSlot = new System.Windows.Forms.TextBox();
            this.cmbRoom = new System.Windows.Forms.ComboBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.Bt = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.dgvTimetable = new System.Windows.Forms.DataGridView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTimetable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Lb
            // 
            this.Lb.AutoSize = true;
            this.Lb.BackColor = System.Drawing.Color.LightPink;
            this.Lb.Font = new System.Drawing.Font("Forte", 9.75F);
            this.Lb.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Lb.Location = new System.Drawing.Point(33, 37);
            this.Lb.Name = "Lb";
            this.Lb.Size = new System.Drawing.Size(81, 22);
            this.Lb.TabIndex = 0;
            this.Lb.Text = "Subject :";
            // 
            // Lbl
            // 
            this.Lbl.AutoSize = true;
            this.Lbl.BackColor = System.Drawing.Color.LightPink;
            this.Lbl.Font = new System.Drawing.Font("Forte", 9.75F);
            this.Lbl.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Lbl.Location = new System.Drawing.Point(33, 97);
            this.Lbl.Name = "Lbl";
            this.Lbl.Size = new System.Drawing.Size(101, 22);
            this.Lbl.TabIndex = 1;
            this.Lbl.Text = "Time Slot :";
            // 
            // lb3
            // 
            this.lb3.AutoSize = true;
            this.lb3.BackColor = System.Drawing.Color.LightPink;
            this.lb3.Font = new System.Drawing.Font("Forte", 9.75F);
            this.lb3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lb3.Location = new System.Drawing.Point(33, 163);
            this.lb3.Name = "lb3";
            this.lb3.Size = new System.Drawing.Size(71, 22);
            this.lb3.TabIndex = 2;
            this.lb3.Text = "Room :";
            // 
            // cmbSubject
            // 
            this.cmbSubject.Font = new System.Drawing.Font("Forte", 9.75F);
            this.cmbSubject.FormattingEnabled = true;
            this.cmbSubject.Location = new System.Drawing.Point(177, 34);
            this.cmbSubject.Name = "cmbSubject";
            this.cmbSubject.Size = new System.Drawing.Size(523, 30);
            this.cmbSubject.TabIndex = 3;
            this.cmbSubject.Text = "Select ur Subject ";
            // 
            // txtTimeSlot
            // 
            this.txtTimeSlot.Font = new System.Drawing.Font("Forte", 9.75F);
            this.txtTimeSlot.Location = new System.Drawing.Point(177, 94);
            this.txtTimeSlot.Name = "txtTimeSlot";
            this.txtTimeSlot.Size = new System.Drawing.Size(523, 34);
            this.txtTimeSlot.TabIndex = 4;
            // 
            // cmbRoom
            // 
            this.cmbRoom.Font = new System.Drawing.Font("Forte", 9.75F);
            this.cmbRoom.FormattingEnabled = true;
            this.cmbRoom.Location = new System.Drawing.Point(177, 152);
            this.cmbRoom.Name = "cmbRoom";
            this.cmbRoom.Size = new System.Drawing.Size(523, 30);
            this.cmbRoom.TabIndex = 5;
            this.cmbRoom.Text = "Select ur room ";
            this.cmbRoom.SelectedIndexChanged += new System.EventHandler(this.cmbRoom_SelectedIndexChanged);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.Black;
            this.btnAdd.Font = new System.Drawing.Font("Forte", 9.75F);
            this.btnAdd.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnAdd.Location = new System.Drawing.Point(760, 238);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(104, 57);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // Bt
            // 
            this.Bt.BackColor = System.Drawing.Color.Black;
            this.Bt.Font = new System.Drawing.Font("Forte", 9.75F);
            this.Bt.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Bt.Location = new System.Drawing.Point(760, 338);
            this.Bt.Name = "Bt";
            this.Bt.Size = new System.Drawing.Size(100, 62);
            this.Bt.TabIndex = 7;
            this.Bt.Text = "Update";
            this.Bt.UseVisualStyleBackColor = false;
            this.Bt.Click += new System.EventHandler(this.Bt_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Black;
            this.btnDelete.Font = new System.Drawing.Font("Forte", 9.75F);
            this.btnDelete.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnDelete.Location = new System.Drawing.Point(760, 460);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 69);
            this.btnDelete.TabIndex = 8;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // dgvTimetable
            // 
            this.dgvTimetable.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvTimetable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTimetable.GridColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvTimetable.Location = new System.Drawing.Point(24, 238);
            this.dgvTimetable.Name = "dgvTimetable";
            this.dgvTimetable.RowHeadersWidth = 62;
            this.dgvTimetable.RowTemplate.Height = 28;
            this.dgvTimetable.Size = new System.Drawing.Size(678, 291);
            this.dgvTimetable.TabIndex = 9;
            this.dgvTimetable.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTimetable_CellContentClick);
            this.dgvTimetable.SelectionChanged += new System.EventHandler(this.dgvTimetable_systemchanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(788, 34);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(76, 75);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Forte", 9.75F);
            this.label1.Location = new System.Drawing.Point(746, 125);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 22);
            this.label1.TabIndex = 11;
            this.label1.Text = "Timetable Detials";
            // 
            // TimetableForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightPink;
            this.ClientSize = new System.Drawing.Size(909, 568);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.dgvTimetable);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.Bt);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.cmbRoom);
            this.Controls.Add(this.txtTimeSlot);
            this.Controls.Add(this.cmbSubject);
            this.Controls.Add(this.lb3);
            this.Controls.Add(this.Lbl);
            this.Controls.Add(this.Lb);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "TimetableForm";
            this.Text = "TimetableForm";
            this.Load += new System.EventHandler(this.TimetableForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTimetable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Lb;
        private System.Windows.Forms.Label Lbl;
        private System.Windows.Forms.Label lb3;
        private System.Windows.Forms.ComboBox cmbSubject;
        private System.Windows.Forms.TextBox txtTimeSlot;
        private System.Windows.Forms.ComboBox cmbRoom;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button Bt;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGridView dgvTimetable;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
    }
}