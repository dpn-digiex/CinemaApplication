namespace CinemaApplication.Forms.Admin
{
    partial class ManageMovieForm
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
        private DataGridView dataGridViewMovies;
        private Button btnAddNewMovie;
        private Button btnEditMovie;
        private Button btnDeleteMovie;
        private Button btnRefreshList;
        private Panel panelButtons;
        private void InitializeComponent()
        {
            dataGridViewMovies = new DataGridView();
            panelButtons = new Panel();
            btnRefreshList = new Button();
            btnDeleteMovie = new Button();
            btnEditMovie = new Button();
            btnAddNewMovie = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewMovies).BeginInit();
            panelButtons.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridViewMovies
            // 
            dataGridViewMovies.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewMovies.Dock = DockStyle.Fill;
            dataGridViewMovies.Location = new Point(0, 62);
            dataGridViewMovies.Margin = new Padding(4, 5, 4, 5);
            dataGridViewMovies.Name = "dataGridViewMovies";
            dataGridViewMovies.RowHeadersWidth = 51;
            dataGridViewMovies.Size = new Size(1067, 861);
            dataGridViewMovies.TabIndex = 1;
            // 
            // panelButtons
            // 
            panelButtons.Controls.Add(btnRefreshList);
            panelButtons.Controls.Add(btnDeleteMovie);
            panelButtons.Controls.Add(btnEditMovie);
            panelButtons.Controls.Add(btnAddNewMovie);
            panelButtons.Dock = DockStyle.Top;
            panelButtons.Location = new Point(0, 0);
            panelButtons.Margin = new Padding(4, 5, 4, 5);
            panelButtons.Name = "panelButtons";
            panelButtons.Padding = new Padding(7, 8, 7, 8);
            panelButtons.Size = new Size(1067, 62);
            panelButtons.TabIndex = 0;
            // 
            // btnRefreshList
            // 
            btnRefreshList.Location = new Point(355, 12);
            btnRefreshList.Margin = new Padding(4, 5, 4, 5);
            btnRefreshList.Name = "btnRefreshList";
            btnRefreshList.Size = new Size(120, 35);
            btnRefreshList.TabIndex = 0;
            btnRefreshList.Text = "Làm Mới";
            btnRefreshList.UseVisualStyleBackColor = true;
            btnRefreshList.Click += btnRefreshList_Click;
            // 
            // btnDeleteMovie
            // 
            btnDeleteMovie.Location = new Point(247, 12);
            btnDeleteMovie.Margin = new Padding(4, 5, 4, 5);
            btnDeleteMovie.Name = "btnDeleteMovie";
            btnDeleteMovie.Size = new Size(100, 35);
            btnDeleteMovie.TabIndex = 1;
            btnDeleteMovie.Text = "Xóa";
            btnDeleteMovie.UseVisualStyleBackColor = true;
            btnDeleteMovie.Click += btnDeleteMovie_Click;
            // 
            // btnEditMovie
            // 
            btnEditMovie.Location = new Point(139, 12);
            btnEditMovie.Margin = new Padding(4, 5, 4, 5);
            btnEditMovie.Name = "btnEditMovie";
            btnEditMovie.Size = new Size(100, 35);
            btnEditMovie.TabIndex = 2;
            btnEditMovie.Text = "Sửa";
            btnEditMovie.UseVisualStyleBackColor = true;
            btnEditMovie.Click += btnEditMovie_Click;
            // 
            // btnAddNewMovie
            // 
            btnAddNewMovie.Location = new Point(11, 12);
            btnAddNewMovie.Margin = new Padding(4, 5, 4, 5);
            btnAddNewMovie.Name = "btnAddNewMovie";
            btnAddNewMovie.Size = new Size(120, 35);
            btnAddNewMovie.TabIndex = 3;
            btnAddNewMovie.Text = "Thêm Mới";
            btnAddNewMovie.UseVisualStyleBackColor = true;
            btnAddNewMovie.Click += btnAddNewMovie_Click;
            // 
            // ManageMovieForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1067, 923);
            Controls.Add(dataGridViewMovies);
            Controls.Add(panelButtons);
            Margin = new Padding(4, 5, 4, 5);
            Name = "ManageMovieForm";
            Text = "Quản Lý Danh Sách Phim";
            Load += ManageMovieForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewMovies).EndInit();
            panelButtons.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
    }
}