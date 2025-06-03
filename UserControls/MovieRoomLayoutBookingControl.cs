using CinemaApplication.DataAccess;
using CinemaApplication.Forms.Customer;
using CinemaApplication.Models;
using CinemaApplication.Utils;

namespace CinemaApplication.UserControls
{
    public partial class MovieRoomLayoutBookingControl : UserControl
    {
        private readonly ShowtimeBookingInfoModel _selectedShowtime;
        private readonly int _movieId;
        private readonly DataAccessLayer _dataAccessLayer;
        private readonly MovieDetailsBookingForm _parentBookingForm;

        private List<SeatTypeModel> _seatTypes;
        private List<SeatModel> _roomSeats;
        private List<int> _bookedSeatIds;
        // Constants for drawing
        private const int SEAT_LABEL_WIDTH = 30;
        private const int SEAT_LABEL_HEIGHT = 30;
        private const int SEAT_MARGIN = 6;
        private const int ROW_LABEL_WIDTH = 30;
        private const int LAYOUT_PADDING = 10;

        // Màu sắc 
        private readonly Color COLOR_AVAILABLE_DEFAULT = Color.LightGray;
        private readonly Color COLOR_BOOKED = Color.DimGray;
        private readonly Color COLOR_SELECTED = Color.SkyBlue;
        private readonly Color COLOR_TEXT_BOOKED = Color.WhiteSmoke;
        private readonly Color COLOR_TEXT_AVAILABLE = Color.Black;
        private readonly Color COLOR_TEXT_SELECTED = Color.Black;
        public MovieRoomLayoutBookingControl(ShowtimeBookingInfoModel selectedShowtime, int movieId, DataAccessLayer dataAccessLayer, MovieDetailsBookingForm parentForm)
        {
            InitializeComponent();
            _selectedShowtime = selectedShowtime ?? throw new ArgumentNullException(nameof(selectedShowtime));
            _movieId = movieId;
            _dataAccessLayer = dataAccessLayer ?? throw new ArgumentNullException(nameof(dataAccessLayer));
            _parentBookingForm = parentForm ?? throw new ArgumentNullException(nameof(parentForm));

            _parentBookingForm.SelectedSeats.Clear();
            this.Load += MovieRoomLayoutBookingControl_Load;
        }
        private void MovieRoomLayoutBookingControl_Load(object sender, EventArgs e)
        {
            LoadInitialData();
        }

        private void LoadInitialData()
        {
            AppUtils.WriteLine($"[MovieRoomLayout] Loading data for ShowtimeID: {_selectedShowtime.ShowtimeId}, RoomID: {_selectedShowtime.RoomId}");
            if (_dataAccessLayer == null)
            {
                MessageBox.Show("Lỗi hệ thống truy cập dữ liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _seatTypes = _dataAccessLayer.GetAllSeatTypes();
            _roomSeats = _dataAccessLayer.GetSeatsByRoomId(_selectedShowtime.RoomId);
            _bookedSeatIds = _dataAccessLayer.GetBookedSeatIdsForShowtime(_selectedShowtime.ShowtimeId);

            if (_seatTypes == null || !_seatTypes.Any() || _roomSeats == null || !_roomSeats.Any())
            {
                MessageBox.Show("Không thể tải thông tin loại ghế hoặc sơ đồ phòng.", "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnNext.Enabled = false;
                return;
            }

            DisplayShowtimeInfo();
            DisplaySeatTypeLegend();
            DrawSeatLayout();
            UpdateSelectionSummary(); // Cập nhật summary ban đầu (thường là rỗng)
        }

        private void DisplayShowtimeInfo()
        {
            MovieModel movie = _dataAccessLayer.GetMovieById(_movieId);
            string movieTitle = movie?.Title ?? "Phim không xác định";
            lblShowtimeInfo.Text = $"Phim: {movieTitle}\nSuất chiếu: {_selectedShowtime.StartTime:dd/MM/yyyy HH:mm} - Phòng: {_selectedShowtime.RoomName}";
        }

        private void DisplaySeatTypeLegend()
        {
            flowLegend.Controls.Clear();
            flowLegend.SuspendLayout();

            int legendItemWidth = 200;
            int legendItemHeight = 25;
            int colorBoxSize = 20;
            int textStartX = colorBoxSize + 5; 
            int textLabelMaxWidth = legendItemWidth - textStartX - 5; 

            foreach (var seatType in _seatTypes.OrderBy(st => st.SeatTypeId))
            {
                Panel legendItemPanel = new Panel
                {
                    Size = new Size(legendItemWidth, legendItemHeight),
                    Margin = new Padding(5, 2, 5, 2)
                };
                Panel colorBox = new Panel
                {
                    Size = new Size(colorBoxSize, colorBoxSize),
                    Location = new Point(3, (legendItemHeight - colorBoxSize) / 2),
                    BackColor = GetColorForSeatType(seatType.TypeName, seatType.DisplayColorHex),
                    BorderStyle = BorderStyle.FixedSingle
                };

                Label typeLabel = new Label
                {
                    Text = $"{seatType.TypeName}: {seatType.DefaultPrice:N0} VNĐ",
                    Location = new Point(textStartX, (legendItemHeight - Font.Height) / 2 - 1),
                    MaximumSize = new Size(textLabelMaxWidth, legendItemHeight),
                    AutoSize = true,
                    AutoEllipsis = true,
                    Font = new Font("Segoe UI", 8f),
                    TextAlign = ContentAlignment.MiddleLeft
                };

                legendItemPanel.Controls.Add(colorBox);
                legendItemPanel.Controls.Add(typeLabel);
                flowLegend.Controls.Add(legendItemPanel);
            }
            flowLegend.ResumeLayout(true);
            flowLegend.PerformLayout();
        }
        private Color GetColorForSeatType(string typeName, string hexColor)
        {
            if (!string.IsNullOrWhiteSpace(hexColor))
            {
                try { return ColorTranslator.FromHtml(hexColor); }
                catch { /* fallback to name-based or default */ }
            }
            return AppUtils.GetColorForSeatType(typeName);
        }
        private void DrawSeatLayout()
        {
            panelSeatLayout.Controls.Clear();
            panelSeatLayout.SuspendLayout();

            if (!_roomSeats.Any())
            {
                Label noSeatsLabel = new Label { Text = "Sơ đồ ghế không có sẵn cho phòng này.", AutoSize = true };
                panelSeatLayout.Controls.Add(noSeatsLabel);
                panelSeatLayout.ResumeLayout(true);
                return;
            }

            // Nhóm ghế theo hàng
            var rows = _roomSeats
                .GroupBy(s => s.RowIdentifier)
                .OrderBy(g => g.Key); // Sắp xếp hàng (A, B, C...)

            int currentY = LAYOUT_PADDING;

            foreach (var rowGroup in rows)
            {
                string rowId = rowGroup.Key;

                // Vẽ nhãn hàng (ví dụ: "A")
                Label rowLabel = new Label
                {
                    Text = rowId,
                    AutoSize = false,
                    Size = new Size(ROW_LABEL_WIDTH, SEAT_LABEL_HEIGHT),
                    Location = new Point(LAYOUT_PADDING, currentY),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Font = new Font("Segoe UI", 9F, FontStyle.Bold)
                };
                panelSeatLayout.Controls.Add(rowLabel);

                int currentX = LAYOUT_PADDING + ROW_LABEL_WIDTH + SEAT_MARGIN;

                foreach (var seat in rowGroup.OrderBy(s => { int.TryParse(s.SeatNumberInRow, out int num); return num; }))
                {
                    Label lbSeat = new Label
                    {
                        Name = $"seat_{seat.SeatId}",
                        Text = $"{seat.RowIdentifier}{seat.SeatNumberInRow}",
                        Size = new Size(SEAT_LABEL_WIDTH, SEAT_LABEL_HEIGHT),
                        Location = new Point(currentX, currentY),
                        BorderStyle = BorderStyle.FixedSingle,
                        TextAlign = ContentAlignment.MiddleCenter,
                        Cursor = Cursors.Hand,
                        Tag = seat
                    };

                    SeatTypeModel seatType = _seatTypes.FirstOrDefault(st => st.SeatTypeId == seat.SeatTypeId);
                    Color seatColor = COLOR_AVAILABLE_DEFAULT;
                    if (seatType != null)
                    {
                        seatColor = GetColorForSeatType(seatType.TypeName, seatType.DisplayColorHex);
                    }

                    bool isBooked = _bookedSeatIds.Contains(seat.SeatId);
                    bool isSelected = _parentBookingForm.SelectedSeats.Any(s => s.SeatId == seat.SeatId);

                    if (!seat.IsActive) // Ghế không hoạt động
                    {
                        lbSeat.BackColor = Color.LightSlateGray; // Màu khác cho ghế hỏng/không dùng
                        lbSeat.Text = "X";
                        lbSeat.ForeColor = Color.DarkGray;
                        lbSeat.Enabled = false;
                        lbSeat.Cursor = Cursors.Default;
                    }
                    else if (isBooked)
                    {
                        lbSeat.BackColor = COLOR_BOOKED;
                        lbSeat.Text = "X"; // Hoặc để trống
                        lbSeat.ForeColor = COLOR_TEXT_BOOKED;
                        lbSeat.Enabled = false; // Không cho chọn ghế đã đặt
                        lbSeat.Cursor = Cursors.Default;
                    }
                    else if (isSelected)
                    {
                        lbSeat.BackColor = COLOR_SELECTED;
                        lbSeat.Text = "✓";
                        lbSeat.ForeColor = COLOR_TEXT_SELECTED;
                        lbSeat.Click += SeatLabel_Click;
                    }
                    else // Ghế còn trống
                    {
                        lbSeat.BackColor = seatColor;
                        lbSeat.ForeColor = COLOR_TEXT_AVAILABLE;
                        lbSeat.Click += SeatLabel_Click;
                    }

                    // Gợi ý ToolTip
                    ToolTip seatToolTip = new ToolTip();
                    seatToolTip.SetToolTip(lbSeat, $"Ghế: {seat.RowIdentifier}{seat.SeatNumberInRow}\nLoại: {seatType?.TypeName ?? "N/A"}\nGiá: {seatType?.DefaultPrice:N0} VNĐ" + (isBooked ? "\n(Đã đặt)" : (seat.IsActive ? "" : "\n(Không khả dụng)")));


                    panelSeatLayout.Controls.Add(lbSeat);
                    currentX += SEAT_LABEL_WIDTH + SEAT_MARGIN;
                }
                currentY += SEAT_LABEL_HEIGHT + SEAT_MARGIN; // Khoảng cách giữa các hàng (điều chỉnh nếu cần)
            }
            panelSeatLayout.ResumeLayout(true);
        }
        private void SeatLabel_Click(object sender, EventArgs e)
        {
            Label clickedLabel = sender as Label;
            if (clickedLabel == null || !(clickedLabel.Tag is SeatModel seatModel) || !seatModel.IsActive || _bookedSeatIds.Contains(seatModel.SeatId))
            {
                return;
            }

            SeatTypeModel seatType = _seatTypes.FirstOrDefault(st => st.SeatTypeId == seatModel.SeatTypeId);
            Color originalColor = (seatType != null) ? GetColorForSeatType(seatType.TypeName, seatType.DisplayColorHex) : COLOR_AVAILABLE_DEFAULT;

            // Kiểm tra xem ghế đã được chọn trước đó chưa
            SeatModel existingSelectedSeat = _parentBookingForm.SelectedSeats.FirstOrDefault(s => s.SeatId == seatModel.SeatId);

            if (existingSelectedSeat != null) // Ghế đã được chọn -> Bỏ chọn
            {
                _parentBookingForm.SelectedSeats.Remove(existingSelectedSeat);
                clickedLabel.Text = $"{seatModel.RowIdentifier}{seatModel.SeatNumberInRow}";
                clickedLabel.BackColor = originalColor;
                clickedLabel.ForeColor = COLOR_TEXT_AVAILABLE;
                AppUtils.WriteLine($"[MovieRoomLayout] Seat UNSELECTED: {seatModel.RowIdentifier}{seatModel.SeatNumberInRow}");
            }
            else // Ghế chưa được chọn -> Chọn
            {
                _parentBookingForm.SelectedSeats.Add(seatModel);
                clickedLabel.Text = "✓"; // Ký hiệu đã chọn
                clickedLabel.BackColor = COLOR_SELECTED; // Màu khi được chọn
                clickedLabel.ForeColor = COLOR_TEXT_SELECTED;
                AppUtils.WriteLine($"[MovieRoomLayout] Seat SELECTED: {seatModel.RowIdentifier}{seatModel.SeatNumberInRow}");
            }

            UpdateSelectionSummary();
        }
        private void UpdateSelectionSummary()
        {
            if (_parentBookingForm.SelectedSeats.Any())
            {
                string selectedSeatsText = string.Join(", ", _parentBookingForm.SelectedSeats.Select(s => $"{s.RowIdentifier}{s.SeatNumberInRow}"));
                lblSelectedSeatsSummary.Text = $"Ghế đã chọn: {selectedSeatsText}";

                decimal totalPrice = 0;
                Dictionary<string, int> seatTypeCounts = new Dictionary<string, int>();

                foreach (var seat in _parentBookingForm.SelectedSeats)
                {
                    SeatTypeModel st = _seatTypes.FirstOrDefault(type => type.SeatTypeId == seat.SeatTypeId);
                    if (st != null)
                    {
                        totalPrice += st.DefaultPrice;
                        if (seatTypeCounts.ContainsKey(st.TypeName))
                            seatTypeCounts[st.TypeName]++;
                        else
                            seatTypeCounts[st.TypeName] = 1;
                    }
                }
                lblTotalPriceSummary.Text = $"Tổng tiền: {totalPrice:N0} VNĐ";

                string typesSummary = string.Join(", ", seatTypeCounts.Select(kvp => $"{kvp.Value} ghế {kvp.Key}"));
                 lblSelectedSeatTypesInfo.Text = $"Loại ghế: {typesSummary}";
                btnNext.Enabled = true;
            }
            else
            {
                lblSelectedSeatsSummary.Text = "Ghế đã chọn: (Chưa chọn ghế nào)";
                lblTotalPriceSummary.Text = "Tổng tiền: 0 VNĐ";
                lblSelectedSeatTypesInfo.Text = "Loại ghế:";
                btnNext.Enabled = false;
            }
        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            if (!_parentBookingForm.SelectedSeats.Any())
            {
                MessageBox.Show("Vui lòng chọn ít nhất một ghế.", "Chưa chọn ghế", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            AppUtils.WriteLine($"[MovieRoomLayout] Next button clicked. Selected seats: {_parentBookingForm.SelectedSeats.Count}");
            _parentBookingForm.NavigateToFoodOrder();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            AppUtils.WriteLine("[MovieRoomLayout] Back button clicked.");
            _parentBookingForm.NavigateBackToShowtimeSelection(_movieId);
        }

        private void lblScreen_Click(object sender, EventArgs e)
        {

        }
    }
}
