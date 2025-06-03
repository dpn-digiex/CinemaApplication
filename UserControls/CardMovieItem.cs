using CinemaApplication.DataAccess;
using CinemaApplication.Forms.Common;
using CinemaApplication.Forms.Customer;
using CinemaApplication.Models;
using System.ComponentModel;
namespace CinemaApplication.UserControls
{
    public partial class CardMovieItem : UserControl
    {
        public DataAccessLayer dataAccessLayer;
        private MovieModel _currentMovie;
        private string _title = "Tên phim";

        [Category("Movie Data")]
        public string MovieTitle
        {
            get { return _title; }
            set { _title = value; lblTitle.Text = value; }
        }

        private string _genre = "Thể loại";
        [Category("Movie Data")]
        public string Genre
        {
            get { return _genre; }
            set { _genre = value; lblGenre.Text = $"Thể loại: {value}"; }
        }

        private int _duration = 0;
        [Category("Movie Data")]
        public int DurationMinutes
        {
            get { return _duration; }
            set { _duration = value; lblDuration.Text = $"Thời lượng: {value} phút"; }
        }

        private string _release_date = "Thể loại";
        [Category("Movie Data")]
        public string ReleaseDate
        {
            get { return _release_date; }
            set { _release_date = value; lblReleaseDate.Text = $"Khởi chiếu: {value}"; }
        }

        private string _posterUrl;
        [Category("Movie Data")]
        public string PosterUrl
        {
            get { return _posterUrl; }
            set
            {
                _posterUrl = value;
                LoadPosterImage();
            }
        }
        public CardMovieItem(DataAccessLayer dataAccessLayerRef)
        {
            InitializeComponent();
            dataAccessLayer = dataAccessLayerRef;
            foreach (Control ctl in this.Controls)
            {
                ctl.Click += CardMovieItem_Click;
            }
        }

        private void CardMovieItem_Load(object sender, EventArgs e)
        {

        }

        private void LoadPosterImage()
        {
            if (!string.IsNullOrWhiteSpace(_posterUrl))
            {
                try
                {
                    pictureBoxPoster.LoadAsync(_posterUrl);
                }
                catch (Exception ex)
                {
                    pictureBoxPoster.Image = pictureBoxPoster.ErrorImage;
                    Console.WriteLine($"Lỗi tải ảnh poster: {ex.Message}");
                }
            }
            else
            {
                pictureBoxPoster.Image = pictureBoxPoster.InitialImage;
            }
        }

        public void SetMovieData(MovieModel movie)
        {
            if (movie == null) return;

            _currentMovie = movie;
            this.MovieTitle = movie.Title;
            this.Genre = movie.Genre;
            this.DurationMinutes = movie.DurationMinutes;
            this.PosterUrl = movie.PosterImageUrl;
            this.ReleaseDate = movie.ReleaseDate.ToString();
        }

        private void CardMovieItem_Click(object sender, EventArgs e)
        {
            if (_currentMovie != null)
            {
                Console.WriteLine($"CardMovieItem clicked for movie: {_currentMovie.Title} (ID: {_currentMovie.MovieId})");

                // Mở form đặt vé
                MovieDetailsBookingForm bookingForm = new MovieDetailsBookingForm(_currentMovie.MovieId, dataAccessLayer);
                bookingForm.ShowDialog();
            }
            else
            {
                Console.WriteLine("CardMovieItem clicked, but no movie data is set.");
            }
        }
    }
}