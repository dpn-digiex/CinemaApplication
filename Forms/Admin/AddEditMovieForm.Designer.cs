namespace CinemaApplication.Forms.Admin
{
    partial class AddEditMovieForm
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

        private TextBox txtTitle;
        private RichTextBox txtDescription;
        private TextBox txtDirector;
        private NumericUpDown numDuration;
        private DateTimePicker dtpReleaseDate;
        private TextBox txtPosterUrl;
        private TextBox txtTrailerUrl;
        private TextBox txtGenre;
        private TextBox txtLanguage;
        private ComboBox cmbRatingDetails;
        private ComboBox cmbStatus;
        private Button btnSave;
        private Button btnCancel;
        // Thêm các Labels tương ứng
        private void InitializeComponent()
        {
            txtTitle = new TextBox();
            txtDescription = new RichTextBox();
            txtDirector = new TextBox();
            numDuration = new NumericUpDown();
            dtpReleaseDate = new DateTimePicker();
            txtPosterUrl = new TextBox();
            txtTrailerUrl = new TextBox();
            txtGenre = new TextBox();
            txtLanguage = new TextBox();
            cmbRatingDetails = new ComboBox();
            cmbStatus = new ComboBox();
            btnSave = new Button();
            btnCancel = new Button();
            lblTitleText = new Label();
            lblDescriptionText = new Label();
            lblDirectorText = new Label();
            lblActorsText = new Label();
            lblDurationText = new Label();
            lblReleaseDateText = new Label();
            lblPosterUrlText = new Label();
            lblTrailerUrlText = new Label();
            lblGenreText = new Label();
            lblLanguageText = new Label();
            lblRatingDetailsText = new Label();
            lblStatusText = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            label12 = new Label();
            txtActors = new TextBox();
            posterPictureBox = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)numDuration).BeginInit();
            ((System.ComponentModel.ISupportInitialize)posterPictureBox).BeginInit();
            SuspendLayout();
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(191, 32);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(350, 27);
            txtTitle.TabIndex = 1;
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(191, 62);
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(350, 100);
            txtDescription.TabIndex = 3;
            txtDescription.Text = "";
            // 
            // txtDirector
            // 
            txtDirector.Location = new Point(191, 167);
            txtDirector.Name = "txtDirector";
            txtDirector.Size = new Size(350, 27);
            txtDirector.TabIndex = 5;
            // 
            // numDuration
            // 
            numDuration.Location = new Point(191, 260);
            numDuration.Maximum = new decimal(new int[] { 300, 0, 0, 0 });
            numDuration.Minimum = new decimal(new int[] { 30, 0, 0, 0 });
            numDuration.Name = "numDuration";
            numDuration.Size = new Size(100, 27);
            numDuration.TabIndex = 9;
            numDuration.Value = new decimal(new int[] { 30, 0, 0, 0 });
            // 
            // dtpReleaseDate
            // 
            dtpReleaseDate.Checked = false;
            dtpReleaseDate.Format = DateTimePickerFormat.Short;
            dtpReleaseDate.Location = new Point(191, 290);
            dtpReleaseDate.Name = "dtpReleaseDate";
            dtpReleaseDate.ShowCheckBox = true;
            dtpReleaseDate.Size = new Size(200, 27);
            dtpReleaseDate.TabIndex = 11;
            // 
            // txtPosterUrl
            // 
            txtPosterUrl.Location = new Point(191, 320);
            txtPosterUrl.Name = "txtPosterUrl";
            txtPosterUrl.Size = new Size(350, 27);
            txtPosterUrl.TabIndex = 13;
            // 
            // txtTrailerUrl
            // 
            txtTrailerUrl.Location = new Point(191, 350);
            txtTrailerUrl.Name = "txtTrailerUrl";
            txtTrailerUrl.Size = new Size(350, 27);
            txtTrailerUrl.TabIndex = 15;
            // 
            // txtGenre
            // 
            txtGenre.Location = new Point(191, 380);
            txtGenre.Name = "txtGenre";
            txtGenre.Size = new Size(350, 27);
            txtGenre.TabIndex = 17;
            // 
            // txtLanguage
            // 
            txtLanguage.Location = new Point(191, 410);
            txtLanguage.Name = "txtLanguage";
            txtLanguage.Size = new Size(350, 27);
            txtLanguage.TabIndex = 19;
            // 
            // cmbRatingDetails
            // 
            cmbRatingDetails.Location = new Point(191, 440);
            cmbRatingDetails.Name = "cmbRatingDetails";
            cmbRatingDetails.Size = new Size(150, 28);
            cmbRatingDetails.TabIndex = 21;
            // 
            // cmbStatus
            // 
            cmbStatus.Location = new Point(191, 470);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(150, 28);
            cmbStatus.TabIndex = 23;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(191, 503);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(80, 25);
            btnSave.TabIndex = 24;
            btnSave.Text = "Lưu";
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(191, 503);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(80, 25);
            btnCancel.TabIndex = 25;
            btnCancel.Text = "Hủy";
            btnCancel.Click += btnCancel_Click;
            // 
            // lblTitleText
            // 
            lblTitleText.Location = new Point(0, 0);
            lblTitleText.Name = "lblTitleText";
            lblTitleText.Size = new Size(100, 23);
            lblTitleText.TabIndex = 0;
            // 
            // lblDescriptionText
            // 
            lblDescriptionText.Location = new Point(0, 0);
            lblDescriptionText.Name = "lblDescriptionText";
            lblDescriptionText.Size = new Size(100, 23);
            lblDescriptionText.TabIndex = 2;
            // 
            // lblDirectorText
            // 
            lblDirectorText.Location = new Point(0, 0);
            lblDirectorText.Name = "lblDirectorText";
            lblDirectorText.Size = new Size(100, 23);
            lblDirectorText.TabIndex = 4;
            // 
            // lblActorsText
            // 
            lblActorsText.Location = new Point(0, 0);
            lblActorsText.Name = "lblActorsText";
            lblActorsText.Size = new Size(100, 23);
            lblActorsText.TabIndex = 6;
            // 
            // lblDurationText
            // 
            lblDurationText.Location = new Point(0, 0);
            lblDurationText.Name = "lblDurationText";
            lblDurationText.Size = new Size(100, 23);
            lblDurationText.TabIndex = 8;
            // 
            // lblReleaseDateText
            // 
            lblReleaseDateText.Location = new Point(0, 0);
            lblReleaseDateText.Name = "lblReleaseDateText";
            lblReleaseDateText.Size = new Size(100, 23);
            lblReleaseDateText.TabIndex = 10;
            // 
            // lblPosterUrlText
            // 
            lblPosterUrlText.Location = new Point(0, 0);
            lblPosterUrlText.Name = "lblPosterUrlText";
            lblPosterUrlText.Size = new Size(100, 23);
            lblPosterUrlText.TabIndex = 12;
            // 
            // lblTrailerUrlText
            // 
            lblTrailerUrlText.Location = new Point(0, 0);
            lblTrailerUrlText.Name = "lblTrailerUrlText";
            lblTrailerUrlText.Size = new Size(100, 23);
            lblTrailerUrlText.TabIndex = 14;
            // 
            // lblGenreText
            // 
            lblGenreText.Location = new Point(0, 0);
            lblGenreText.Name = "lblGenreText";
            lblGenreText.Size = new Size(100, 23);
            lblGenreText.TabIndex = 16;
            // 
            // lblLanguageText
            // 
            lblLanguageText.Location = new Point(0, 0);
            lblLanguageText.Name = "lblLanguageText";
            lblLanguageText.Size = new Size(100, 23);
            lblLanguageText.TabIndex = 18;
            // 
            // lblRatingDetailsText
            // 
            lblRatingDetailsText.Location = new Point(0, 0);
            lblRatingDetailsText.Name = "lblRatingDetailsText";
            lblRatingDetailsText.Size = new Size(100, 23);
            lblRatingDetailsText.TabIndex = 20;
            // 
            // lblStatusText
            // 
            lblStatusText.Location = new Point(0, 0);
            lblStatusText.Name = "lblStatusText";
            lblStatusText.Size = new Size(100, 23);
            lblStatusText.TabIndex = 22;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(95, 35);
            label1.Name = "label1";
            label1.Size = new Size(73, 20);
            label1.TabIndex = 26;
            label1.Text = "Tên phim:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(56, 62);
            label2.Name = "label2";
            label2.Size = new Size(112, 20);
            label2.TabIndex = 27;
            label2.Text = "Nội dung phim:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(75, 167);
            label3.Name = "label3";
            label3.Size = new Size(93, 20);
            label3.TabIndex = 28;
            label3.Text = "Giám đốc sx:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(94, 203);
            label4.Name = "label4";
            label4.Size = new Size(74, 20);
            label4.TabIndex = 29;
            label4.Text = "Diễn viên:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(41, 262);
            label5.Name = "label5";
            label5.Size = new Size(128, 20);
            label5.TabIndex = 30;
            label5.Text = "Thời lượng (phút):";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(103, 383);
            label6.Name = "label6";
            label6.Size = new Size(65, 20);
            label6.TabIndex = 30;
            label6.Text = "Thể loại:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(52, 295);
            label7.Name = "label7";
            label7.Size = new Size(117, 20);
            label7.TabIndex = 31;
            label7.Text = "Ngày phát hành:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(86, 323);
            label8.Name = "label8";
            label8.Size = new Size(82, 20);
            label8.TabIndex = 32;
            label8.Text = "Poster URL:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(85, 353);
            label9.Name = "label9";
            label9.Size = new Size(83, 20);
            label9.TabIndex = 33;
            label9.Text = "Trailer URL:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(89, 413);
            label10.Name = "label10";
            label10.Size = new Size(79, 20);
            label10.TabIndex = 34;
            label10.Text = "Ngôn ngữ:";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(90, 473);
            label11.Name = "label11";
            label11.Size = new Size(78, 20);
            label11.TabIndex = 35;
            label11.Text = "Trạng thái:";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(95, 443);
            label12.Name = "label12";
            label12.Size = new Size(73, 20);
            label12.TabIndex = 36;
            label12.Text = "Phân loại:";
            // 
            // txtActors
            // 
            txtActors.Location = new Point(191, 200);
            txtActors.Name = "txtActors";
            txtActors.Size = new Size(350, 27);
            txtActors.TabIndex = 37;
            // 
            // posterPictureBox
            // 
            posterPictureBox.Location = new Point(580, 32);
            posterPictureBox.Name = "posterPictureBox";
            posterPictureBox.Size = new Size(232, 283);
            posterPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            posterPictureBox.TabIndex = 38;
            posterPictureBox.TabStop = false;
            // 
            // AddEditMovieForm
            // 
            ClientSize = new Size(859, 547);
            Controls.Add(posterPictureBox);
            Controls.Add(txtActors);
            Controls.Add(label12);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(lblTitleText);
            Controls.Add(txtTitle);
            Controls.Add(lblDescriptionText);
            Controls.Add(txtDescription);
            Controls.Add(lblDirectorText);
            Controls.Add(txtDirector);
            Controls.Add(lblActorsText);
            Controls.Add(lblDurationText);
            Controls.Add(numDuration);
            Controls.Add(lblReleaseDateText);
            Controls.Add(dtpReleaseDate);
            Controls.Add(lblPosterUrlText);
            Controls.Add(txtPosterUrl);
            Controls.Add(lblTrailerUrlText);
            Controls.Add(txtTrailerUrl);
            Controls.Add(lblGenreText);
            Controls.Add(txtGenre);
            Controls.Add(lblLanguageText);
            Controls.Add(txtLanguage);
            Controls.Add(lblRatingDetailsText);
            Controls.Add(cmbRatingDetails);
            Controls.Add(lblStatusText);
            Controls.Add(cmbStatus);
            Controls.Add(btnSave);
            Controls.Add(btnCancel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "AddEditMovieForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Quản lý Phim";
            ((System.ComponentModel.ISupportInitialize)numDuration).EndInit();
            ((System.ComponentModel.ISupportInitialize)posterPictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitleText;
        private Label lblDescriptionText;
        private Label lblDirectorText;
        private Label lblActorsText;
        private Label lblDurationText;
        private Label lblReleaseDateText;
        private Label lblPosterUrlText;
        private Label lblTrailerUrlText;
        private Label lblGenreText;
        private Label lblLanguageText;
        private Label lblRatingDetailsText;
        private Label lblStatusText;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
        private Label label12;
        private TextBox txtActors;
        private PictureBox posterPictureBox;
    }
}