using CinemaApplication.DataAccess;
using CinemaApplication.Forms.Customer;
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
    public partial class MovieShowtimeSelectionControl : UserControl
    {
        private readonly int _movieId;
        private readonly DataAccessLayer _dataAccessLayer;
        private readonly MovieDetailsBookingForm _parentBookingForm;
        private MovieModel _currentMovie;
        public MovieShowtimeSelectionControl(int movieId, DataAccessLayer dataAccessLayer, MovieDetailsBookingForm parentForm)
        {
            InitializeComponent();
            _movieId = movieId;
            _dataAccessLayer = dataAccessLayer ?? throw new ArgumentNullException(nameof(dataAccessLayer));
            _parentBookingForm = parentForm ?? throw new ArgumentNullException(nameof(parentForm));

            InitializeControls();
            LoadMovieInfo();
            LoadShowtimesForSelectedDate();
        }
        private void InitializeControls()
        {
            dtpSelectDateShowtime.MinDate = DateTime.Today;
            dtpSelectDateShowtime.Value = DateTime.Today;
            dtpSelectDateShowtime.Format = DateTimePickerFormat.Long;
            dtpSelectDateShowtime.ValueChanged += DtpSelectDateShowtime_ValueChanged;

            btnBackToDetails.Click += BtnBackToDetails_Click;

            // Thiết lập cho FlowLayoutPanel
            flowLayoutPanelShowtimes.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanelShowtimes.WrapContents = false; // Quan trọng cho list dọc
            flowLayoutPanelShowtimes.AutoScroll = true;
        }

        private void LoadMovieInfo()
        {
            _currentMovie = _dataAccessLayer.GetMovieById(_movieId);
            if (_currentMovie != null)
            {
                lblSelectedMovieTitle.Text = _currentMovie.Title;
            }
            else
            {
                lblSelectedMovieTitle.Text = "Không tìm thấy phim!";
                AppUtils.WriteLine($"ERROR: [MovieShowtimeSelectionControl] Movie with ID {_movieId} not found.");
            }
        }

        private void DtpSelectDateShowtime_ValueChanged(object sender, EventArgs e)
        {
            LoadShowtimesForSelectedDate();
        }

        private void LoadShowtimesForSelectedDate()
        {
            DateTime selectedDate = dtpSelectDateShowtime.Value;
            AppUtils.WriteLine($"[MovieShowtimeSelectionControl] Loading showtimes for MovieID: {_movieId}, Date: {selectedDate:dd/MM/yyyy}");

            flowLayoutPanelShowtimes.SuspendLayout();
            flowLayoutPanelShowtimes.Controls.Clear();

            if (_dataAccessLayer == null)
            {
                AppUtils.WriteLine("ERROR: [MovieShowtimeSelectionControl] DataAccessLayer is null.");
                Label lblError = new Label { Text = "Lỗi tải dữ liệu suất chiếu.", AutoSize = true, ForeColor = Color.Red };
                flowLayoutPanelShowtimes.Controls.Add(lblError);
                flowLayoutPanelShowtimes.ResumeLayout(true);
                return;
            }


            List<ShowtimeBookingInfoModel> showtimes = _dataAccessLayer.GetShowtimesForBooking(_movieId, selectedDate);

            if (showtimes != null && showtimes.Any())
            {
                foreach (var showtimeInfo in showtimes)
                {
                    MovieShowtimeBookingControl sc = new MovieShowtimeBookingControl(showtimeInfo, _parentBookingForm);
                    flowLayoutPanelShowtimes.Controls.Add(sc);
                }
                AppUtils.WriteLine($"[MovieShowtimeSelectionControl] Displayed {showtimes.Count} showtimes.");
            }
            else
            {
                Label lblNoShowtimes = new Label
                {
                    Text = $"Hiện không có suất chiếu nào cho phim này vào ngày {selectedDate:dd/MM/yyyy}.",
                    Font = new Font("Segoe UI", 10F),
                    AutoSize = true,
                    Padding = new Padding(0, 10, 0, 0)
                };
                flowLayoutPanelShowtimes.Controls.Add(lblNoShowtimes);
                AppUtils.WriteLine($"[MovieShowtimeSelectionControl] No showtimes found for MovieID: {_movieId} on {selectedDate:dd/MM/yyyy}.");
            }
            flowLayoutPanelShowtimes.ResumeLayout(true); // Tiếp tục layout
        }

        private void BtnBackToDetails_Click(object sender, EventArgs e)
        {
            AppUtils.WriteLine("[MovieShowtimeSelectionControl] Back to Movie Details clicked.");
            _parentBookingForm.NavigateBackToMovieDetails();
        }

    }
}
