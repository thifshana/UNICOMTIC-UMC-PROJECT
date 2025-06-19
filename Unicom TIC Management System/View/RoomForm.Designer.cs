namespace Unicom_TIC_Management_System.View
{
    partial class RoomForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RoomForm));
            this.Roomname = new System.Windows.Forms.Label();
            this.RoomType = new System.Windows.Forms.Label();
            this.txtRoomName = new System.Windows.Forms.TextBox();
            this.cmbRoomType = new System.Windows.Forms.ComboBox();
            this.btnDeleteRoom = new System.Windows.Forms.Button();
            this.btnUpdateRoom = new System.Windows.Forms.Button();
            this.btnAddRoom = new System.Windows.Forms.Button();
            this.dgvRooms = new System.Windows.Forms.DataGridView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRooms)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Roomname
            // 
            this.Roomname.AutoSize = true;
            this.Roomname.BackColor = System.Drawing.Color.LightPink;
            this.Roomname.Font = new System.Drawing.Font("Forte", 9.75F);
            this.Roomname.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Roomname.Location = new System.Drawing.Point(29, 39);
            this.Roomname.Name = "Roomname";
            this.Roomname.Size = new System.Drawing.Size(82, 14);
            this.Roomname.TabIndex = 0;
            this.Roomname.Text = "Room Name :";
            // 
            // RoomType
            // 
            this.RoomType.AutoSize = true;
            this.RoomType.BackColor = System.Drawing.Color.LightPink;
            this.RoomType.Font = new System.Drawing.Font("Forte", 9.75F);
            this.RoomType.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.RoomType.Location = new System.Drawing.Point(29, 97);
            this.RoomType.Name = "RoomType";
            this.RoomType.Size = new System.Drawing.Size(75, 14);
            this.RoomType.TabIndex = 2;
            this.RoomType.Text = "Room Type :";
            // 
            // txtRoomName
            // 
            this.txtRoomName.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtRoomName.Font = new System.Drawing.Font("Forte", 9.75F);
            this.txtRoomName.Location = new System.Drawing.Point(144, 39);
            this.txtRoomName.Name = "txtRoomName";
            this.txtRoomName.Size = new System.Drawing.Size(308, 25);
            this.txtRoomName.TabIndex = 3;
            this.txtRoomName.TextChanged += new System.EventHandler(this.txtRoomName_TextChanged);
            // 
            // cmbRoomType
            // 
            this.cmbRoomType.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.cmbRoomType.Font = new System.Drawing.Font("Forte", 9.75F);
            this.cmbRoomType.FormattingEnabled = true;
            this.cmbRoomType.Location = new System.Drawing.Point(144, 97);
            this.cmbRoomType.Name = "cmbRoomType";
            this.cmbRoomType.Size = new System.Drawing.Size(308, 22);
            this.cmbRoomType.TabIndex = 4;
            this.cmbRoomType.Text = "Values: Room  ,   Hall";
            this.cmbRoomType.SelectedIndexChanged += new System.EventHandler(this.cmbRoomType_SelectedIndexChanged);
            // 
            // btnDeleteRoom
            // 
            this.btnDeleteRoom.BackColor = System.Drawing.Color.Black;
            this.btnDeleteRoom.Font = new System.Drawing.Font("Forte", 9.75F);
            this.btnDeleteRoom.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnDeleteRoom.Location = new System.Drawing.Point(492, 308);
            this.btnDeleteRoom.Name = "btnDeleteRoom";
            this.btnDeleteRoom.Size = new System.Drawing.Size(69, 42);
            this.btnDeleteRoom.TabIndex = 5;
            this.btnDeleteRoom.Text = "DELETE";
            this.btnDeleteRoom.UseVisualStyleBackColor = false;
            this.btnDeleteRoom.Click += new System.EventHandler(this.btnDeleteRoom_Click);
            // 
            // btnUpdateRoom
            // 
            this.btnUpdateRoom.BackColor = System.Drawing.Color.Black;
            this.btnUpdateRoom.Font = new System.Drawing.Font("Forte", 9.75F);
            this.btnUpdateRoom.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnUpdateRoom.Location = new System.Drawing.Point(492, 231);
            this.btnUpdateRoom.Name = "btnUpdateRoom";
            this.btnUpdateRoom.Size = new System.Drawing.Size(69, 38);
            this.btnUpdateRoom.TabIndex = 6;
            this.btnUpdateRoom.Text = "UPDATE ";
            this.btnUpdateRoom.UseVisualStyleBackColor = false;
            this.btnUpdateRoom.Click += new System.EventHandler(this.btnUpdateRoom_Click);
            // 
            // btnAddRoom
            // 
            this.btnAddRoom.BackColor = System.Drawing.Color.Black;
            this.btnAddRoom.Font = new System.Drawing.Font("Forte", 9.75F);
            this.btnAddRoom.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnAddRoom.Location = new System.Drawing.Point(492, 157);
            this.btnAddRoom.Name = "btnAddRoom";
            this.btnAddRoom.Size = new System.Drawing.Size(69, 35);
            this.btnAddRoom.TabIndex = 7;
            this.btnAddRoom.Text = "ADD ";
            this.btnAddRoom.UseVisualStyleBackColor = false;
            this.btnAddRoom.Click += new System.EventHandler(this.btnAddRoom_Click);
            // 
            // dgvRooms
            // 
            this.dgvRooms.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvRooms.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRooms.Location = new System.Drawing.Point(32, 157);
            this.dgvRooms.Name = "dgvRooms";
            this.dgvRooms.RowHeadersWidth = 62;
            this.dgvRooms.Size = new System.Drawing.Size(420, 193);
            this.dgvRooms.TabIndex = 8;
            this.dgvRooms.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRooms_CellContentClick);
            this.dgvRooms.SelectionChanged += new System.EventHandler(this.ShowsRoomList);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(520, 31);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(53, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Forte", 9.75F);
            this.label1.Location = new System.Drawing.Point(504, 88);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 14);
            this.label1.TabIndex = 10;
            this.label1.Text = "Room Details";
            // 
            // RoomForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightPink;
            this.ClientSize = new System.Drawing.Size(606, 371);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.dgvRooms);
            this.Controls.Add(this.btnAddRoom);
            this.Controls.Add(this.btnUpdateRoom);
            this.Controls.Add(this.btnDeleteRoom);
            this.Controls.Add(this.cmbRoomType);
            this.Controls.Add(this.txtRoomName);
            this.Controls.Add(this.RoomType);
            this.Controls.Add(this.Roomname);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RoomForm";
            this.Text = "RoomForm";
            this.Load += new System.EventHandler(this.RoomForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRooms)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Roomname;
        private System.Windows.Forms.Label RoomType;
        private System.Windows.Forms.TextBox txtRoomName;
        private System.Windows.Forms.ComboBox cmbRoomType;
        private System.Windows.Forms.Button btnDeleteRoom;
        private System.Windows.Forms.Button btnUpdateRoom;
        private System.Windows.Forms.Button btnAddRoom;
        private System.Windows.Forms.DataGridView dgvRooms;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
    }

}