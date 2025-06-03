using CinemaApplication.DataAccess;
using CinemaApplication.Models;
using CinemaApplication.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CinemaApplication.Forms.Admin
{
    public partial class AddEditMovieForm : Form
    {
        private readonly DataAccessLayer _dataAccessLayer;
        private readonly MovieModel _movieToEdit;
        private readonly bool _isEditMode;


        public AddEditMovieForm(DataAccessLayer dataAccessLayer, MovieModel movieToEdit = null)
        {
            InitializeComponent();
            _dataAccessLayer = dataAccessLayer;
            _movieToEdit = movieToEdit;
            _isEditMode = (_movieToEdit != null);

            SetupComboBoxes();
            InitializeFormValues();
        }
        private void SetupComboBoxes()
        {
            cmbStatus.Items.Clear();
            cmbStatus.Items.AddRange(new string[] { "active", "upcoming", "inactive" });
            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;

            cmbRatingDetails.Items.Clear();
            cmbRatingDetails.Items.AddRange(new string[] { "P", "C13", "C16", "C18", "K" });
            cmbRatingDetails.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void InitializeFormValues()
        {
            if (_isEditMode)
            {
                this.Text = "Chỉnh Sửa Thông Tin Phim";
                txtTitle.Text = _movieToEdit.Title;
                txtDescription.Text = _movieToEdit.Description;
                txtDirector.Text = _movieToEdit.Director;
                txtActors.Text = _movieToEdit.Actors;
                numDuration.Value = Math.Max(numDuration.Minimum, Math.Min(numDuration.Maximum, _movieToEdit.DurationMinutes));
                if (_movieToEdit.ReleaseDate.HasValue)
                    dtpReleaseDate.Value = _movieToEdit.ReleaseDate.Value;
                else
                    dtpReleaseDate.Checked = false;

                txtPosterUrl.Text = _movieToEdit.PosterImageUrl;
                txtTrailerUrl.Text = _movieToEdit.TrailerUrl;
                txtGenre.Text = _movieToEdit.Genre;
                txtLanguage.Text = _movieToEdit.Language;
                cmbRatingDetails.SelectedItem = _movieToEdit.RatingDetails;
                cmbStatus.SelectedItem = _movieToEdit.Status;
                LoadImageToPosterPictureBox(_movieToEdit.PosterImageUrl);
            }
            else
            {
                this.Text = "Thêm Phim Mới";
                dtpReleaseDate.Value = DateTime.Today;
                cmbStatus.SelectedItem = "upcoming";
                cmbRatingDetails.SelectedIndex = 0;
            }
        }
        private void LoadImageToPosterPictureBox(string imageUrlOrPath)
        {
            if (string.IsNullOrWhiteSpace(imageUrlOrPath))
            {
                posterPictureBox.Image = posterPictureBox.InitialImage;
                AppUtils.WriteLine("[AddEditMovieForm] Poster URL/Path is empty, clearing PictureBox.");
                return;
            }

            try
            {
                posterPictureBox.LoadAsync(imageUrlOrPath);
                AppUtils.WriteLine($"[AddEditMovieForm] Attempting to load poster from: {imageUrlOrPath}");
            }
            catch (Exception ex)
            {
                AppUtils.WriteLine($"EXCEPTION in LoadImageToPosterPictureBox for '{imageUrlOrPath}': {ex.GetType().FullName} - {ex.Message}");
                posterPictureBox.Image = posterPictureBox.ErrorImage; // Hiển thị ảnh lỗi
                MessageBox.Show($"Không thể tải ảnh poster từ: {imageUrlOrPath}\nLỗi: {ex.Message}", "Lỗi Tải Ảnh", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show("Vui lòng nhập tên phim.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTitle.Focus();
                return;
            }
            if (numDuration.Value <= 0)
            {
                MessageBox.Show("Thời lượng phim phải lớn hơn 0.", "Thông tin không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numDuration.Focus();
                return;
            }
            if (cmbStatus.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn trạng thái phim.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbStatus.Focus();
                return;
            }

            MovieModel movieData = _isEditMode ? _movieToEdit : new MovieModel();

            movieData.Title = txtTitle.Text.Trim();
            movieData.Description = txtDescription.Text.Trim();
            movieData.Director = txtDirector.Text.Trim();
            movieData.Actors = txtActors.Text.Trim();
            movieData.DurationMinutes = (int)numDuration.Value;
            movieData.ReleaseDate = dtpReleaseDate.Checked ? dtpReleaseDate.Value.Date : (DateTime?)null; // Lấy ngày, bỏ qua giờ
            movieData.PosterImageUrl = txtPosterUrl.Text.Trim();
            movieData.TrailerUrl = txtTrailerUrl.Text.Trim();
            movieData.Genre = txtGenre.Text.Trim();
            movieData.Language = txtLanguage.Text.Trim();
            movieData.RatingDetails = cmbRatingDetails.SelectedItem?.ToString();
            movieData.Status = cmbStatus.SelectedItem.ToString();

            bool success = false;
            if (_isEditMode)
            {
                movieData.UpdatedAt = DateTime.UtcNow;
                success = _dataAccessLayer.UpdateMovie(movieData);
            }
            else
            {
                movieData.CreatedAt = DateTime.UtcNow;
                movieData.UpdatedAt = DateTime.UtcNow;
                int newMovieId = _dataAccessLayer.AddMovie(movieData);
                success = newMovieId > 0;
            }

            if (success)
            {
                MessageBox.Show(_isEditMode ? "Cập nhật thông tin phim thành công!" : "Thêm phim mới thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK; 
                this.Close();
            }
            else
            {
                MessageBox.Show(_isEditMode ? "Không thể cập nhật thông tin phim." : "Không thể thêm phim mới.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
