namespace CinemaApplication.UserControls
{
    partial class CardMovieItem
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
        private void InitializeComponent()
        {
            pictureBoxPoster = new PictureBox();
            lblTitle = new Label();
            lblDuration = new Label();
            label2 = new Label();
            lblGenre = new Label();
            lblReleaseDate = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBoxPoster).BeginInit();
            SuspendLayout();
            // 
            // pictureBoxPoster
            // 
            pictureBoxPoster.Location = new Point(14, 17);
            pictureBoxPoster.Name = "pictureBoxPoster";
            pictureBoxPoster.Size = new Size(245, 284);
            pictureBoxPoster.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxPoster.TabIndex = 0;
            pictureBoxPoster.TabStop = false;
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(14, 304);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(220, 56);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "Tên phim";
            // 
            // lblDuration
            // 
            lblDuration.AutoSize = true;
            lblDuration.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDuration.Location = new Point(14, 393);
            lblDuration.Name = "lblDuration";
            lblDuration.Size = new Size(87, 20);
            lblDuration.TabIndex = 2;
            lblDuration.Text = "Thời lượng:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(14, 360);
            label2.Name = "label2";
            label2.Size = new Size(63, 20);
            label2.TabIndex = 3;
            label2.Text = "Thể loại";
            // 
            // lblGenre
            // 
            lblGenre.AutoSize = true;
            lblGenre.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblGenre.Location = new Point(14, 360);
            lblGenre.Name = "lblGenre";
            lblGenre.Size = new Size(63, 20);
            lblGenre.TabIndex = 3;
            lblGenre.Text = "Thể loại";
            // 
            // lblReleaseDate
            // 
            lblReleaseDate.AutoSize = true;
            lblReleaseDate.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblReleaseDate.Location = new Point(14, 425);
            lblReleaseDate.Name = "lblReleaseDate";
            lblReleaseDate.Size = new Size(85, 20);
            lblReleaseDate.TabIndex = 4;
            lblReleaseDate.Text = "Khởi chiếu:";
            // 
            // CardMovieItem
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.HighlightText;
            Controls.Add(lblReleaseDate);
            Controls.Add(lblGenre);
            Controls.Add(label2);
            Controls.Add(lblDuration);
            Controls.Add(lblTitle);
            Controls.Add(pictureBoxPoster);
            Cursor = Cursors.Hand;
            Name = "CardMovieItem";
            Size = new Size(275, 459);
            Click += CardMovieItem_Click;
            ((System.ComponentModel.ISupportInitialize)pictureBoxPoster).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBoxPoster;
        private Label lblTitle;
        private Label lblDuration;
        private Label label2;
        private Label lblGenre;
        private Label lblReleaseDate;
    }
}
