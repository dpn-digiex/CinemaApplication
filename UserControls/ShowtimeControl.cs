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

namespace CinemaApplication.UserControls
{
    public partial class ShowtimeControl : UserControl
    {
        private FullShowtimeInfoModel _currentShowtimeInfo;
        public ShowtimeControl()
        {
            InitializeComponent();
        }
        public void SetShowtimeData(FullShowtimeInfoModel showtimeInfo)
        {
            _currentShowtimeInfo = showtimeInfo;
            if (_currentShowtimeInfo == null)
            {
                lblMovieTitle.Text = "N/A";
                picPoster.Image = null;
                return;
            }

            lblMovieTitle.Text = _currentShowtimeInfo.MovieTitle;
            lblRoomName.Text = $"Phòng: {_currentShowtimeInfo.RoomName}";
            lblTimeSlot.Text = $"Suất: {_currentShowtimeInfo.StartTime:HH:mm} - {_currentShowtimeInfo.EndTime:HH:mm}";
            lblDuration.Text = $"Thời lượng: {_currentShowtimeInfo.MovieDurationMinutes} phút";
            lblGenre.Text = $"Thể loại: {_currentShowtimeInfo.MovieGenre ?? "N/A"}";
            lblRating.Text = $"Phân loại: {_currentShowtimeInfo.MovieRatingDetails ?? "N/A"}";

            if (!string.IsNullOrWhiteSpace(_currentShowtimeInfo.MoviePosterImageUrl))
            {
                try
                {
                    picPoster.LoadAsync(_currentShowtimeInfo.MoviePosterImageUrl);
                }
                catch (Exception ex)
                {
                    AppUtils.WriteLine($"ERROR loading poster in ShowtimeControl for {_currentShowtimeInfo.MovieTitle}: {ex.Message}");
                    picPoster.Image = picPoster.ErrorImage;
                }
            }
            else
            {
                picPoster.Image = picPoster.InitialImage;
            }
        }
    }
}
