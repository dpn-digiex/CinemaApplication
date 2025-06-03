using CinemaApplication.DataAccess;
using CinemaApplication.Forms.Customer;
using CinemaApplication.Models;
using CinemaApplication.Utils;
using System.ComponentModel;
using System.Diagnostics;

namespace CinemaApplication.UserControls
{
    public partial class MovieDetailsControl : UserControl
    {
        private readonly int _movieId;
        private readonly DataAccessLayer _dataAccessLayer;
        private readonly MovieDetailsBookingForm _parentBookingForm;
        private MovieModel _currentMovie;
        public MovieDetailsControl(int movieId, DataAccessLayer dataAccessLayerRef, MovieDetailsBookingForm parentForm)
        {
            InitializeComponent();
            _movieId = movieId;
            _dataAccessLayer = dataAccessLayerRef ?? throw new ArgumentNullException(nameof(dataAccessLayerRef));
            _parentBookingForm = parentForm ?? throw new ArgumentNullException(nameof(parentForm));

            LoadMovieDetails();

            if (this.btnBuyTicket != null)
            {
                this.btnBuyTicket.Click += new System.EventHandler(this.btnBuyTicket_Click);
            }
        }
        private void LoadMovieDetails()
        {
            AppUtils.WriteLine($"[MovieDetailsControl] Loading details for MovieID: {_movieId}");
            _currentMovie = _dataAccessLayer.GetMovieById(_movieId);

            if (_currentMovie != null)
            {
                lblTitle.Text = _currentMovie.Title;
                lblGenre.Text = $"Thể loại: {_currentMovie.Genre ?? "N/A"}";
                lblDuration.Text = $"Thời lượng: {_currentMovie.DurationMinutes} phút";
                lblRating.Text = $"Phân loại: {_currentMovie.RatingDetails ?? "N/A"}";
                lblReleaseDate.Text = $"Khởi chiếu: {_currentMovie.ReleaseDate?.ToString("dd/MM/yyyy") ?? "N/A"}";
                lblDirector.Text = $"Đạo diễn: {_currentMovie.Director ?? "N/A"}";
                lblActors.Text = $"Diễn viên: {_currentMovie.Actors ?? "N/A"}";
                txtDescription.Text = _currentMovie.Description ?? "Chưa có mô tả.";

                if (!string.IsNullOrWhiteSpace(_currentMovie.PosterImageUrl))
                {
                    try { picPoster.LoadAsync(_currentMovie.PosterImageUrl); }
                    catch (Exception ex)
                    {
                        AppUtils.WriteLine($"EXCEPTION loading poster in MovieDetailsControl: {ex.Message}");
                        picPoster.Image = picPoster.ErrorImage;
                    }
                }
                else { picPoster.Image = picPoster.InitialImage; }


                if (!string.IsNullOrWhiteSpace(_currentMovie.TrailerUrl))
                {
                    linkTrailer.Text = "Xem Trailer";
                    linkTrailer.Tag = _currentMovie.TrailerUrl;
                    linkTrailer.Visible = true;
                }
                else
                {
                    linkTrailer.Visible = false;
                }
                AppUtils.WriteLine($"[MovieDetailsControl] Details loaded for: {_currentMovie.Title}");
            }
            else
            {
                AppUtils.WriteLine($"ERROR: [MovieDetailsControl] Movie with ID {_movieId} not found.");
                MessageBox.Show("Không tìm thấy thông tin phim.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //_parentBookingForm.CloseBookingProcess();
            }
        }

        private void picPoster_LoadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                AppUtils.WriteLine($"ERROR: [MovieDetailsControl] Async poster load failed: {e.Error.Message}");
                picPoster.Image = picPoster.ErrorImage;
            }
        }

        private void linkTrailer_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string url = linkTrailer.Tag?.ToString();
            if (!string.IsNullOrWhiteSpace(url))
            {
                try
                {
                    Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
                }
                catch (Exception ex)
                {
                    AppUtils.WriteLine($"EXCEPTION opening trailer link '{url}': {ex.Message}");
                    MessageBox.Show("Không thể mở link trailer.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnBuyTicket_Click(object sender, EventArgs e)
        {
            if (_currentMovie != null)
            {
                AppUtils.WriteLine($"[MovieDetailsControl] Buy Ticket button clicked for MovieID: {_currentMovie.MovieId}");
                _parentBookingForm.NavigateToMovieShowtimeSelection(_currentMovie.MovieId);
            }
        }
    }
}
