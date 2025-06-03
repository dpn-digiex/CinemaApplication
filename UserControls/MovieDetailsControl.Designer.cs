using System.ComponentModel.Design;
using System.Windows.Forms;

namespace CinemaApplication.UserControls
{
    partial class MovieDetailsControl
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
        private System.Windows.Forms.Panel panelMainContent;
        private System.Windows.Forms.PictureBox picPoster;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblGenre;
        private System.Windows.Forms.Label lblDuration;
        private System.Windows.Forms.Label lblRating;
        private System.Windows.Forms.Label lblReleaseDate;
        private System.Windows.Forms.RichTextBox txtDescription;
        private System.Windows.Forms.Label lblDirector;
        private System.Windows.Forms.Label lblActors;
        private System.Windows.Forms.LinkLabel linkTrailer;
        private System.Windows.Forms.Button btnBuyTicket;
        private void InitializeComponent()
        {
            panelMainContent = new Panel();
            btnBuyTicket = new Button();
            linkTrailer = new LinkLabel();
            lblActors = new Label();
            lblDirector = new Label();
            txtDescription = new RichTextBox();
            lblReleaseDate = new Label();
            lblRating = new Label();
            lblDuration = new Label();
            lblGenre = new Label();
            lblTitle = new Label();
            picPoster = new PictureBox();
            panelMainContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picPoster).BeginInit();
            SuspendLayout();
            // 
            // panelMainContent
            // 
            panelMainContent.AutoScroll = true;
            panelMainContent.Controls.Add(btnBuyTicket);
            panelMainContent.Controls.Add(linkTrailer);
            panelMainContent.Controls.Add(lblActors);
            panelMainContent.Controls.Add(lblDirector);
            panelMainContent.Controls.Add(txtDescription);
            panelMainContent.Controls.Add(lblReleaseDate);
            panelMainContent.Controls.Add(lblRating);
            panelMainContent.Controls.Add(lblDuration);
            panelMainContent.Controls.Add(lblGenre);
            panelMainContent.Controls.Add(lblTitle);
            panelMainContent.Controls.Add(picPoster);
            panelMainContent.Dock = DockStyle.Fill;
            panelMainContent.Location = new Point(0, 0);
            panelMainContent.Margin = new Padding(4, 5, 4, 5);
            panelMainContent.Name = "panelMainContent";
            panelMainContent.Padding = new Padding(20, 23, 20, 23);
            panelMainContent.Size = new Size(850, 600);
            panelMainContent.TabIndex = 0;
            // 
            // btnBuyTicket
            // 
            btnBuyTicket.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnBuyTicket.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnBuyTicket.Location = new Point(24, 481);
            btnBuyTicket.Margin = new Padding(4, 5, 4, 5);
            btnBuyTicket.Name = "btnBuyTicket";
            btnBuyTicket.Size = new Size(160, 46);
            btnBuyTicket.TabIndex = 11;
            btnBuyTicket.Text = "Mua Vé";
            btnBuyTicket.UseVisualStyleBackColor = true;
            // 
            // linkTrailer
            // 
            linkTrailer.AutoSize = true;
            linkTrailer.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            linkTrailer.Location = new Point(24, 440);
            linkTrailer.Margin = new Padding(4, 0, 4, 0);
            linkTrailer.Name = "linkTrailer";
            linkTrailer.Size = new Size(102, 23);
            linkTrailer.TabIndex = 9;
            linkTrailer.TabStop = true;
            linkTrailer.Text = "Xem Trailer";
            linkTrailer.Visible = false;
            // 
            // lblActors
            // 
            lblActors.AutoSize = true;
            lblActors.Font = new Font("Segoe UI", 9F);
            lblActors.Location = new Point(307, 415);
            lblActors.Margin = new Padding(4, 0, 4, 0);
            lblActors.MaximumSize = new Size(667, 0);
            lblActors.Name = "lblActors";
            lblActors.Size = new Size(74, 20);
            lblActors.TabIndex = 8;
            lblActors.Text = "Diễn viên:";
            // 
            // lblDirector
            // 
            lblDirector.AutoSize = true;
            lblDirector.Font = new Font("Segoe UI", 9F);
            lblDirector.Location = new Point(307, 385);
            lblDirector.Margin = new Padding(4, 0, 4, 0);
            lblDirector.Name = "lblDirector";
            lblDirector.Size = new Size(73, 20);
            lblDirector.TabIndex = 7;
            lblDirector.Text = "Đạo diễn:";
            // 
            // txtDescription
            // 
            txtDescription.BorderStyle = BorderStyle.FixedSingle;
            txtDescription.Font = new Font("Segoe UI", 9F);
            txtDescription.Location = new Point(307, 215);
            txtDescription.Margin = new Padding(4, 5, 4, 5);
            txtDescription.Name = "txtDescription";
            txtDescription.ReadOnly = true;
            txtDescription.ScrollBars = RichTextBoxScrollBars.Vertical;
            txtDescription.Size = new Size(500, 152);
            txtDescription.TabIndex = 6;
            txtDescription.Text = "Mô tả phim đang tải...";
            // 
            // lblReleaseDate
            // 
            lblReleaseDate.AutoSize = true;
            lblReleaseDate.Font = new Font("Segoe UI", 9F);
            lblReleaseDate.Location = new Point(307, 177);
            lblReleaseDate.Margin = new Padding(4, 0, 4, 0);
            lblReleaseDate.Name = "lblReleaseDate";
            lblReleaseDate.Size = new Size(81, 20);
            lblReleaseDate.TabIndex = 5;
            lblReleaseDate.Text = "Khởi chiếu:";
            // 
            // lblRating
            // 
            lblRating.AutoSize = true;
            lblRating.Font = new Font("Segoe UI", 9F);
            lblRating.Location = new Point(307, 146);
            lblRating.Margin = new Padding(4, 0, 4, 0);
            lblRating.Name = "lblRating";
            lblRating.Size = new Size(73, 20);
            lblRating.TabIndex = 4;
            lblRating.Text = "Phân loại:";
            // 
            // lblDuration
            // 
            lblDuration.AutoSize = true;
            lblDuration.Font = new Font("Segoe UI", 9F);
            lblDuration.Location = new Point(307, 115);
            lblDuration.Margin = new Padding(4, 0, 4, 0);
            lblDuration.Name = "lblDuration";
            lblDuration.Size = new Size(84, 20);
            lblDuration.TabIndex = 3;
            lblDuration.Text = "Thời lượng:";
            // 
            // lblGenre
            // 
            lblGenre.AutoSize = true;
            lblGenre.Font = new Font("Segoe UI", 9F);
            lblGenre.Location = new Point(307, 85);
            lblGenre.Margin = new Padding(4, 0, 4, 0);
            lblGenre.Name = "lblGenre";
            lblGenre.Size = new Size(65, 20);
            lblGenre.TabIndex = 2;
            lblGenre.Text = "Thể loại:";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.Location = new Point(307, 28);
            lblTitle.Margin = new Padding(4, 0, 4, 0);
            lblTitle.MaximumSize = new Size(667, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(277, 37);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "Tên Phim Đang Tải...";
            // 
            // picPoster
            // 
            picPoster.BorderStyle = BorderStyle.FixedSingle;
            picPoster.Location = new Point(24, 28);
            picPoster.Margin = new Padding(4, 5, 4, 5);
            picPoster.Name = "picPoster";
            picPoster.Size = new Size(266, 407);
            picPoster.SizeMode = PictureBoxSizeMode.Zoom;
            picPoster.TabIndex = 0;
            picPoster.TabStop = false;
            // 
            // MovieDetailsControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panelMainContent);
            Margin = new Padding(4, 5, 4, 5);
            Name = "MovieDetailsControl";
            Size = new Size(850, 600);
            panelMainContent.ResumeLayout(false);
            panelMainContent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picPoster).EndInit();
            ResumeLayout(false);
        }

        #endregion
    }
}
