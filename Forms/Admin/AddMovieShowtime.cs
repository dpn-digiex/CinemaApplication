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
    public partial class AddMovieShowtime : Form
    {
        private DataAccessLayer _dataAccessLayer;
        private List<MovieModel> _availableMovies;
        private List<CinemaRoomModel> _availableRooms;
        private MovieModel _selectedMovie;
        public AddMovieShowtime(DataAccessLayer dataAccessLayerRef)
        {
            InitializeComponent();
            _dataAccessLayer = dataAccessLayerRef;
            InitializeDateTimePickers();
            LoadMoviesAndRooms();
            AttachEventHandlers();
        }

        private void InitializeDateTimePickers()
        {
            dtpShowDate.MinDate = DateTime.Today.AddDays(1);
            dtpShowDate.Value = DateTime.Today.AddDays(1); // Mặc định là ngày mai
            dtpShowDate.Format = DateTimePickerFormat.Short;

            dtpShowTime.Format = DateTimePickerFormat.Custom;
            dtpShowTime.CustomFormat = "HH:mm"; // Chỉ hiển thị giờ và phút
            dtpShowTime.ShowUpDown = true;
            dtpShowTime.Value = DateTime.Today.Date.AddHours(9); // Mặc định 9:00 AM
        }

        private void LoadMoviesAndRooms()
        {
            if (_dataAccessLayer == null) return;

            _availableMovies = _dataAccessLayer.GetAllMoviesForScheduling();
            cmbMovie.DataSource = null;
            cmbMovie.DataSource = _availableMovies;
            cmbMovie.DisplayMember = "Title"; // Hiển thị tên phim
            cmbMovie.ValueMember = "MovieId";  // Giá trị là ID phim
            cmbMovie.SelectedIndex = -1;

            _availableRooms = _dataAccessLayer.GetAllActiveCinemaRooms();
            cmbRoom.DataSource = null;
            cmbRoom.DataSource = _availableRooms;
            cmbRoom.DisplayMember = "RoomName"; // Hiển thị tên phòng
            cmbRoom.ValueMember = "RoomId";   // Giá trị là ID phòng
            cmbRoom.SelectedIndex = -1;
        }

        private void AttachEventHandlers()
        {
            cmbMovie.SelectedIndexChanged += CmbMovie_SelectedIndexChanged;
            dtpShowDate.ValueChanged += DateTime_ValueChanged;
            dtpShowTime.ValueChanged += DateTime_ValueChanged;
            cmbRoom.SelectedIndexChanged += DateTime_ValueChanged; 
        }

        private void CmbMovie_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMovie.SelectedItem is MovieModel selectedMovie)
            {
                _selectedMovie = selectedMovie;
                lblMovieDurationValue.Text = $"{_selectedMovie.DurationMinutes} phút";
                CalculateAndDisplayEndTime();
            }
            else
            {
                _selectedMovie = null;
                lblMovieDurationValue.Text = "N/A";
                lblEndTimeValue.Text = "N/A";
            }
        }

        private void DateTime_ValueChanged(object sender, EventArgs e)
        {
            CalculateAndDisplayEndTime();
        }

        private void CalculateAndDisplayEndTime()
        {
            if (_selectedMovie == null || _selectedMovie.DurationMinutes <= 0)
            {
                lblEndTimeValue.Text = "N/A";
                return;
            }

            DateTime selectedDate = dtpShowDate.Value.Date;
            TimeSpan selectedTime = dtpShowTime.Value.TimeOfDay;
            DateTime startTime = selectedDate + selectedTime;

            DateTime endTime = startTime.AddMinutes(_selectedMovie.DurationMinutes);
            lblEndTimeValue.Text = endTime.ToString("dd/MM/yyyy HH:mm");
        }

        private bool IsRoomOverlapping(int roomId, DateTime newStartTime, DateTime newEndTime)
        {
            List<ShowtimeModel> existingShowtimes = _dataAccessLayer.GetShowtimesForRoomOnDate(roomId, newStartTime.Date);
            foreach (var existingShowtime in existingShowtimes)
            {
                // Kiểm tra trùng lặp: (StartA < EndB) and (EndA > StartB)
                if (newStartTime < existingShowtime.EndTime && newEndTime > existingShowtime.StartTime)
                {
                    AppUtils.WriteLine($"OVERLAP DETECTED: New [{newStartTime} - {newEndTime}] overlaps with existing [{existingShowtime.StartTime} - {existingShowtime.EndTime}] for room {roomId}");
                    return true;
                }
            }
            return false;
        }

        private void btnSaveShowtime_Click(object sender, EventArgs e)
        {
            if (_dataAccessLayer == null)
            {
                MessageBox.Show("Lỗi hệ thống truy cập dữ liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validate inputs
            if (cmbMovie.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn một bộ phim.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbMovie.Focus();
                return;
            }
            if (cmbRoom.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn một phòng chiếu.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbRoom.Focus();
                return;
            }

            MovieModel selectedMovie = cmbMovie.SelectedItem as MovieModel;
            CinemaRoomModel selectedRoom = cmbRoom.SelectedItem as CinemaRoomModel;

            DateTime showDate = dtpShowDate.Value.Date;
            TimeSpan showTimeOfDay = dtpShowTime.Value.TimeOfDay;
            DateTime proposedStartTime = showDate + showTimeOfDay;

            if (proposedStartTime < DateTime.Now.Date.AddDays(1)) // Kiểm tra lại lần nữa, MinDate của DTP đã xử lý nhưng chắc chắn hơn
            {
                MessageBox.Show("Ngày chiếu phải là từ ngày mai trở đi.", "Ngày không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpShowDate.Focus();
                return;
            }

            DateTime proposedEndTime = proposedStartTime.AddMinutes(selectedMovie.DurationMinutes);

            // Check for overlaps
            if (IsRoomOverlapping(selectedRoom.RoomId, proposedStartTime, proposedEndTime))
            {
                MessageBox.Show($"Phòng '{selectedRoom.RoomName}' đã có lịch chiếu khác trong khoảng thời gian từ {proposedStartTime:HH:mm} đến {proposedEndTime:HH:mm} ngày {proposedStartTime:dd/MM/yyyy}.\nVui lòng chọn thời gian hoặc phòng khác.", "Lịch chiếu bị trùng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Create and save showtime
            ShowtimeModel newShowtime = new ShowtimeModel
            {
                MovieId = selectedMovie.MovieId,
                RoomId = selectedRoom.RoomId,
                StartTime = proposedStartTime,
                EndTime = proposedEndTime,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            bool success = _dataAccessLayer.AddShowtime(newShowtime);
            if (success)
            {
                AppUtils.WriteLine($"[AddMovieShowtimeForm] Showtime added successfully for {selectedMovie.Title} at {newShowtime.StartTime}");
                MessageBox.Show("Thêm lịch chiếu thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Tùy chọn: Xóa các lựa chọn để thêm suất chiếu mới hoặc đóng form
                cmbMovie.SelectedIndex = -1;
                cmbRoom.SelectedIndex = -1;
                lblMovieDurationValue.Text = "N/A";
                lblEndTimeValue.Text = "N/A";
            }
            else
            {
                AppUtils.WriteLine($"ERROR: [AddMovieShowtimeForm] Failed to add showtime for {selectedMovie.Title}");
                MessageBox.Show("Không thể thêm lịch chiếu. Vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
