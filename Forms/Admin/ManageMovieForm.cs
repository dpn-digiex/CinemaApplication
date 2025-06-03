using CinemaApplication.DataAccess;
using CinemaApplication.Models;
using CinemaApplication.Utils;

namespace CinemaApplication.Forms.Admin
{
    public partial class ManageMovieForm : Form
    {
        private DataAccessLayer _dataAccessLayer;
        public ManageMovieForm(DataAccessLayer dataAccessLayerRef)
        {
            InitializeComponent();
            _dataAccessLayer = dataAccessLayerRef;
        }

        private void ManageMovieForm_Load(object sender, EventArgs e)
        {
            if (_dataAccessLayer == null) return;
            SetupDataGridView();
            LoadMovies();
            UpdateButtonStates();
        }

        private void SetupDataGridView()
        {
            dataGridViewMovies.AutoGenerateColumns = false;
            dataGridViewMovies.Columns.Clear();

            dataGridViewMovies.Columns.Add(new DataGridViewTextBoxColumn { Name = "colMovieId", HeaderText = "ID", DataPropertyName = "MovieId", Width = 50 });
            dataGridViewMovies.Columns.Add(new DataGridViewTextBoxColumn { Name = "colTitle", HeaderText = "Tên Phim", DataPropertyName = "Title", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dataGridViewMovies.Columns.Add(new DataGridViewTextBoxColumn { Name = "colDirector", HeaderText = "Đạo Diễn", DataPropertyName = "Director", Width = 150 });
            dataGridViewMovies.Columns.Add(new DataGridViewTextBoxColumn { Name = "colDuration", HeaderText = "Thời Lượng (phút)", DataPropertyName = "DurationMinutes", Width = 80 });
            dataGridViewMovies.Columns.Add(new DataGridViewTextBoxColumn { Name = "colReleaseDate", HeaderText = "Ngày Khởi Chiếu", DataPropertyName = "ReleaseDate", Width = 100, DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" } });
            dataGridViewMovies.Columns.Add(new DataGridViewTextBoxColumn { Name = "colGenre", HeaderText = "Thể Loại", DataPropertyName = "Genre", Width = 120 });
            dataGridViewMovies.Columns.Add(new DataGridViewTextBoxColumn { Name = "colStatus", HeaderText = "Trạng Thái", DataPropertyName = "Status", Width = 80 });
            dataGridViewMovies.Columns.Add(new DataGridViewTextBoxColumn { Name = "colRating", HeaderText = "Phân Loại", DataPropertyName = "RatingDetails", Width = 70 });


            dataGridViewMovies.AllowUserToAddRows = false;
            dataGridViewMovies.ReadOnly = true;
            dataGridViewMovies.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewMovies.MultiSelect = false;
            dataGridViewMovies.RowHeadersVisible = false;
            dataGridViewMovies.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            dataGridViewMovies.SelectionChanged += DataGridViewMovies_SelectionChanged;
            dataGridViewMovies.CellDoubleClick += DataGridViewMovies_CellDoubleClick;
        }

        private void LoadMovies()
        {
            if (_dataAccessLayer == null) return;
            AppUtils.WriteLine("[ManageMovieForm] Loading movies...");
            List<MovieModel> movies = _dataAccessLayer.GetAllMovies();
            if (movies != null)
            {
                dataGridViewMovies.DataSource = movies;
                AppUtils.WriteLine($"[ManageMovieForm] Loaded {movies.Count} movies.");
            }
            else
            {
                dataGridViewMovies.DataSource = null;
                MessageBox.Show("Không thể tải danh sách phim.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            UpdateButtonStates();
        }

        private void UpdateButtonStates()
        {
            bool rowSelected = dataGridViewMovies.SelectedRows.Count > 0;
            btnEditMovie.Enabled = rowSelected;
            btnDeleteMovie.Enabled = rowSelected;
        }

        private void DataGridViewMovies_SelectionChanged(object sender, EventArgs e)
        {
            UpdateButtonStates();
        }

        private void btnRefreshList_Click(object sender, EventArgs e)
        {
            LoadMovies();
        }

        private void btnAddNewMovie_Click(object sender, EventArgs e)
        {
            if (_dataAccessLayer == null) return;
            AddEditMovieForm addForm = new AddEditMovieForm(_dataAccessLayer);
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                LoadMovies();
            }
        }

        private void EditSelectedMovie()
        {
            if (_dataAccessLayer == null) return;
            if (dataGridViewMovies.SelectedRows.Count > 0)
            {
                MovieModel selectedMovie = dataGridViewMovies.SelectedRows[0].DataBoundItem as MovieModel;
                MovieModel dataSelectedMovie = _dataAccessLayer.GetMovieById(selectedMovie.MovieId);
                if (dataSelectedMovie != null)
                {
                    AddEditMovieForm editForm = new AddEditMovieForm(_dataAccessLayer, dataSelectedMovie);
                    if (editForm.ShowDialog() == DialogResult.OK)
                    {
                        LoadMovies(); // Tự động làm mới
                    }
                }
            }
        }
        private void btnEditMovie_Click(object sender, EventArgs e)
        {
            EditSelectedMovie();
        }
        private void DataGridViewMovies_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                EditSelectedMovie();
            }
        }
        private void btnDeleteMovie_Click(object sender, EventArgs e)
        {
            if (_dataAccessLayer == null) return;
            if (dataGridViewMovies.SelectedRows.Count > 0)
            {
                MovieModel selectedMovie = dataGridViewMovies.SelectedRows[0].DataBoundItem as MovieModel;
                if (selectedMovie != null)
                {
                    var confirmResult = MessageBox.Show($"Bạn có chắc chắn muốn xóa phim '{selectedMovie.Title}' không?",
                                                 "Xác nhận xóa",
                                                 MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (confirmResult == DialogResult.Yes)
                    {
                        bool success = _dataAccessLayer.DeleteMovie(selectedMovie.MovieId);
                        if (success)
                        {
                            MessageBox.Show("Xóa phim thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadMovies(); // Tự động làm mới
                        }
                        else
                        {
                            MessageBox.Show("Không thể xóa phim. Có thể phim đang được tham chiếu ở nơi khác.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }
    }
}
