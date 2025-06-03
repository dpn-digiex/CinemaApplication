namespace CinemaApplication.Forms.Admin
{
    partial class AddMovieShowtime
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
        /// 
        private System.Windows.Forms.Label lblSelectMovie;
        private System.Windows.Forms.ComboBox cmbMovie;
        private System.Windows.Forms.Label lblSelectRoom;
        private System.Windows.Forms.ComboBox cmbRoom;
        private System.Windows.Forms.Label lblSelectDate;
        private System.Windows.Forms.DateTimePicker dtpShowDate;
        private System.Windows.Forms.Label lblSelectTime;
        private System.Windows.Forms.DateTimePicker dtpShowTime;
        private System.Windows.Forms.Label lblMovieDurationText;
        private System.Windows.Forms.Label lblMovieDurationValue;
        private System.Windows.Forms.Label lblEndTimeText;
        private System.Windows.Forms.Label lblEndTimeValue;
        private System.Windows.Forms.Button btnSaveShowtime;
        private void InitializeComponent()
        {
            lblSelectMovie = new Label();
            cmbMovie = new ComboBox();
            lblSelectRoom = new Label();
            cmbRoom = new ComboBox();
            lblSelectDate = new Label();
            dtpShowDate = new DateTimePicker();
            lblSelectTime = new Label();
            dtpShowTime = new DateTimePicker();
            lblMovieDurationText = new Label();
            lblMovieDurationValue = new Label();
            lblEndTimeText = new Label();
            lblEndTimeValue = new Label();
            btnSaveShowtime = new Button();
            SuspendLayout();
            // 
            // lblSelectMovie
            // 
            lblSelectMovie.AutoSize = true;
            lblSelectMovie.Location = new Point(16, 23);
            lblSelectMovie.Margin = new Padding(4, 0, 4, 0);
            lblSelectMovie.Name = "lblSelectMovie";
            lblSelectMovie.Size = new Size(83, 20);
            lblSelectMovie.TabIndex = 0;
            lblSelectMovie.Text = "Chọn Phim:";
            // 
            // cmbMovie
            // 
            cmbMovie.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMovie.FormattingEnabled = true;
            cmbMovie.Location = new Point(219, 17);
            cmbMovie.Margin = new Padding(4, 5, 4, 5);
            cmbMovie.Name = "cmbMovie";
            cmbMovie.Size = new Size(332, 28);
            cmbMovie.TabIndex = 1;
            // 
            // lblSelectRoom
            // 
            lblSelectRoom.AutoSize = true;
            lblSelectRoom.Location = new Point(16, 69);
            lblSelectRoom.Margin = new Padding(4, 0, 4, 0);
            lblSelectRoom.Name = "lblSelectRoom";
            lblSelectRoom.Size = new Size(92, 20);
            lblSelectRoom.TabIndex = 2;
            lblSelectRoom.Text = "Chọn Phòng:";
            // 
            // cmbRoom
            // 
            cmbRoom.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRoom.FormattingEnabled = true;
            cmbRoom.Location = new Point(219, 64);
            cmbRoom.Margin = new Padding(4, 5, 4, 5);
            cmbRoom.Name = "cmbRoom";
            cmbRoom.Size = new Size(332, 28);
            cmbRoom.TabIndex = 3;
            // 
            // lblSelectDate
            // 
            lblSelectDate.AutoSize = true;
            lblSelectDate.Location = new Point(16, 115);
            lblSelectDate.Margin = new Padding(4, 0, 4, 0);
            lblSelectDate.Name = "lblSelectDate";
            lblSelectDate.Size = new Size(126, 20);
            lblSelectDate.TabIndex = 4;
            lblSelectDate.Text = "Chọn Ngày Chiếu:";
            // 
            // dtpShowDate
            // 
            dtpShowDate.Format = DateTimePickerFormat.Short;
            dtpShowDate.Location = new Point(219, 110);
            dtpShowDate.Margin = new Padding(4, 5, 4, 5);
            dtpShowDate.Name = "dtpShowDate";
            dtpShowDate.Size = new Size(159, 27);
            dtpShowDate.TabIndex = 5;
            // 
            // lblSelectTime
            // 
            lblSelectTime.AutoSize = true;
            lblSelectTime.Location = new Point(16, 162);
            lblSelectTime.Margin = new Padding(4, 0, 4, 0);
            lblSelectTime.Name = "lblSelectTime";
            lblSelectTime.Size = new Size(114, 20);
            lblSelectTime.TabIndex = 6;
            lblSelectTime.Text = "Chọn Giờ Chiếu:";
            // 
            // dtpShowTime
            // 
            dtpShowTime.CustomFormat = "HH:mm";
            dtpShowTime.Format = DateTimePickerFormat.Custom;
            dtpShowTime.Location = new Point(219, 156);
            dtpShowTime.Margin = new Padding(4, 5, 4, 5);
            dtpShowTime.Name = "dtpShowTime";
            dtpShowTime.ShowUpDown = true;
            dtpShowTime.Size = new Size(132, 27);
            dtpShowTime.TabIndex = 7;
            // 
            // lblMovieDurationText
            // 
            lblMovieDurationText.AutoSize = true;
            lblMovieDurationText.Location = new Point(16, 208);
            lblMovieDurationText.Margin = new Padding(4, 0, 4, 0);
            lblMovieDurationText.Name = "lblMovieDurationText";
            lblMovieDurationText.Size = new Size(122, 20);
            lblMovieDurationText.TabIndex = 8;
            lblMovieDurationText.Text = "Thời lượng phim:";
            // 
            // lblMovieDurationValue
            // 
            lblMovieDurationValue.BorderStyle = BorderStyle.Fixed3D;
            lblMovieDurationValue.Location = new Point(219, 207);
            lblMovieDurationValue.Margin = new Padding(4, 0, 4, 0);
            lblMovieDurationValue.Name = "lblMovieDurationValue";
            lblMovieDurationValue.Size = new Size(333, 23);
            lblMovieDurationValue.TabIndex = 9;
            lblMovieDurationValue.Text = "N/A";
            // 
            // lblEndTimeText
            // 
            lblEndTimeText.AutoSize = true;
            lblEndTimeText.Location = new Point(16, 254);
            lblEndTimeText.Margin = new Padding(4, 0, 4, 0);
            lblEndTimeText.Name = "lblEndTimeText";
            lblEndTimeText.Size = new Size(193, 20);
            lblEndTimeText.TabIndex = 10;
            lblEndTimeText.Text = "Thời gian kết thúc (dự kiến):";
            // 
            // lblEndTimeValue
            // 
            lblEndTimeValue.BorderStyle = BorderStyle.Fixed3D;
            lblEndTimeValue.Location = new Point(219, 254);
            lblEndTimeValue.Margin = new Padding(4, 0, 4, 0);
            lblEndTimeValue.Name = "lblEndTimeValue";
            lblEndTimeValue.Size = new Size(333, 23);
            lblEndTimeValue.TabIndex = 11;
            lblEndTimeValue.Text = "N/A";
            // 
            // btnSaveShowtime
            // 
            btnSaveShowtime.BackColor = SystemColors.ActiveCaption;
            btnSaveShowtime.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSaveShowtime.Location = new Point(391, 301);
            btnSaveShowtime.Margin = new Padding(4, 5, 4, 5);
            btnSaveShowtime.Name = "btnSaveShowtime";
            btnSaveShowtime.Size = new Size(160, 43);
            btnSaveShowtime.TabIndex = 12;
            btnSaveShowtime.Text = "Lưu Lịch Chiếu";
            btnSaveShowtime.UseVisualStyleBackColor = false;
            btnSaveShowtime.Click += btnSaveShowtime_Click;
            // 
            // AddMovieShowtime
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(576, 386);
            Controls.Add(btnSaveShowtime);
            Controls.Add(lblEndTimeValue);
            Controls.Add(lblEndTimeText);
            Controls.Add(lblMovieDurationValue);
            Controls.Add(lblMovieDurationText);
            Controls.Add(dtpShowTime);
            Controls.Add(lblSelectTime);
            Controls.Add(dtpShowDate);
            Controls.Add(lblSelectDate);
            Controls.Add(cmbRoom);
            Controls.Add(lblSelectRoom);
            Controls.Add(cmbMovie);
            Controls.Add(lblSelectMovie);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(4, 5, 4, 5);
            Name = "AddMovieShowtime";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Thêm Lịch Chiếu Phim";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}