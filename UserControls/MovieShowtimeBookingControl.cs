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
    public partial class MovieShowtimeBookingControl : UserControl
    {
        private ShowtimeBookingInfoModel _showtimeInfo;
        private readonly MovieDetailsBookingForm _parentBookingForm;
        public MovieShowtimeBookingControl(ShowtimeBookingInfoModel showtimeInfo, MovieDetailsBookingForm parentForm)
        {
            InitializeComponent();
            _showtimeInfo = showtimeInfo ?? throw new ArgumentNullException(nameof(showtimeInfo));
            _parentBookingForm = parentForm ?? throw new ArgumentNullException(nameof(parentForm));

            PopulateData();

            this.Click += OnShowtimeControlClick;
            panelContainer.Click += OnShowtimeControlClick;
            foreach (Control ctl in panelContainer.Controls)
            {
                ctl.Click += OnShowtimeControlClick;
            }
        }
        private void PopulateData()
        {
            lblTimeSlot.Text = _showtimeInfo.TimeSlotDisplay;
            lblRoomName.Text = $"Phòng: {_showtimeInfo.RoomName}";
            lblSeatsAvailable.Text = _showtimeInfo.AvailabilityDisplay;

            // Ví dụ: thay đổi màu sắc dựa trên số ghế còn lại
            if (_showtimeInfo.AvailableSeats <= 0)
            {
                lblSeatsAvailable.ForeColor = Color.Red;
                lblSeatsAvailable.Text = "Hết ghế";
                this.Enabled = false;
                this.Cursor = Cursors.Default;
            }
            else if (_showtimeInfo.AvailableSeats < 10)
            {
                lblSeatsAvailable.ForeColor = Color.DarkOrange;
            }
            else
            {
                lblSeatsAvailable.ForeColor = Color.Green;
            }
        }

        private void OnShowtimeControlClick(object sender, EventArgs e)
        {
            if (this.Enabled)
            {
                AppUtils.WriteLine($"[MovieShowtimeBookingControl] Clicked. ShowtimeID: {_showtimeInfo.ShowtimeId}, MovieID: {_showtimeInfo.MovieId}, RoomID: {_showtimeInfo.RoomId}");
                _parentBookingForm.NavigateToRoomLayout(_showtimeInfo);
            }
        }
    }
}
