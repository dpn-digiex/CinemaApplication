namespace CinemaApplication.UserControls
{
    partial class ShowtimeControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        /// 
        private PictureBox picPoster;
        private Label lblMovieTitle;
        private Label lblRoomName;
        private Label lblTimeSlot;
        private Label lblDuration;
        private Label lblGenre;
        private Label lblRating;
        // private Button btnBookTicket;
        private void InitializeComponent()
        {
            picPoster = new PictureBox();
            lblMovieTitle = new Label();
            lblRoomName = new Label();
            lblTimeSlot = new Label();
            lblDuration = new Label();
            lblGenre = new Label();
            lblRating = new Label();
            ((System.ComponentModel.ISupportInitialize)picPoster).BeginInit();
            SuspendLayout();
            // 
            // picPoster
            // 
            picPoster.BorderStyle = BorderStyle.FixedSingle;
            picPoster.Location = new Point(13, 15);
            picPoster.Margin = new Padding(4, 5, 4, 5);
            picPoster.Name = "picPoster";
            picPoster.Size = new Size(121, 137);
            picPoster.SizeMode = PictureBoxSizeMode.Zoom;
            picPoster.TabIndex = 0;
            picPoster.TabStop = false;
            // 
            // lblMovieTitle
            // 
            lblMovieTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblMovieTitle.AutoEllipsis = true;
            lblMovieTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblMovieTitle.Location = new Point(137, 15);
            lblMovieTitle.Margin = new Padding(4, 0, 4, 0);
            lblMovieTitle.Name = "lblMovieTitle";
            lblMovieTitle.Size = new Size(476, 31);
            lblMovieTitle.TabIndex = 1;
            lblMovieTitle.Text = "Tên Phim";
            // 
            // lblRoomName
            // 
            lblRoomName.AutoSize = true;
            lblRoomName.Font = new Font("Segoe UI", 9F);
            lblRoomName.Location = new Point(142, 46);
            lblRoomName.Margin = new Padding(4, 0, 4, 0);
            lblRoomName.Name = "lblRoomName";
            lblRoomName.Size = new Size(86, 20);
            lblRoomName.TabIndex = 2;
            lblRoomName.Text = "Phòng: ABC";
            // 
            // lblTimeSlot
            // 
            lblTimeSlot.AutoSize = true;
            lblTimeSlot.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTimeSlot.ForeColor = Color.DarkBlue;
            lblTimeSlot.Location = new Point(302, 46);
            lblTimeSlot.Margin = new Padding(4, 0, 4, 0);
            lblTimeSlot.Name = "lblTimeSlot";
            lblTimeSlot.Size = new Size(142, 20);
            lblTimeSlot.TabIndex = 3;
            lblTimeSlot.Text = "Suất: 00:00 - 00:00";
            // 
            // lblDuration
            // 
            lblDuration.AutoSize = true;
            lblDuration.Font = new Font("Segoe UI", 8F);
            lblDuration.Location = new Point(142, 77);
            lblDuration.Margin = new Padding(4, 0, 4, 0);
            lblDuration.Name = "lblDuration";
            lblDuration.Size = new Size(138, 19);
            lblDuration.TabIndex = 4;
            lblDuration.Text = "Thời lượng: 120 phút";
            // 
            // lblGenre
            // 
            lblGenre.AutoSize = true;
            lblGenre.Font = new Font("Segoe UI", 8F);
            lblGenre.Location = new Point(142, 100);
            lblGenre.Margin = new Padding(4, 0, 4, 0);
            lblGenre.Name = "lblGenre";
            lblGenre.Size = new Size(132, 19);
            lblGenre.TabIndex = 5;
            lblGenre.Text = "Thể loại: Hành động";
            // 
            // lblRating
            // 
            lblRating.AutoSize = true;
            lblRating.Font = new Font("Segoe UI", 8F);
            lblRating.Location = new Point(142, 123);
            lblRating.Margin = new Padding(4, 0, 4, 0);
            lblRating.Name = "lblRating";
            lblRating.Size = new Size(97, 19);
            lblRating.TabIndex = 6;
            lblRating.Text = "Phân loại: C16";
            // 
            // ShowtimeControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(lblRating);
            Controls.Add(lblGenre);
            Controls.Add(lblDuration);
            Controls.Add(lblTimeSlot);
            Controls.Add(lblRoomName);
            Controls.Add(lblMovieTitle);
            Controls.Add(picPoster);
            Cursor = Cursors.Hand;
            Margin = new Padding(7, 8, 7, 8);
            Name = "ShowtimeControl";
            Size = new Size(626, 169);
            ((System.ComponentModel.ISupportInitialize)picPoster).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}
