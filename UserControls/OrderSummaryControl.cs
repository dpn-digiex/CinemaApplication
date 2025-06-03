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
    public partial class OrderSummaryControl : UserControl
    {
        private readonly MovieDetailsBookingForm _parentBookingForm;
        private readonly DataAccessLayer _dataAccessLayer;
        private MovieModel _movieDetails;
        private List<SeatTypeModel> _seatTypes;
        public OrderSummaryControl(DataAccessLayer dataAccessLayer, MovieDetailsBookingForm parentForm)
        {
            InitializeComponent();
            _dataAccessLayer = dataAccessLayer ?? throw new ArgumentNullException(nameof(dataAccessLayer));
            _parentBookingForm = parentForm ?? throw new ArgumentNullException(nameof(parentForm));
        }

        private void OrderSummaryControl_Load(object sender, EventArgs e)
        {
            AppUtils.WriteLine("[OrderSummaryControl] Loading order summary...");
            LoadDataAndDisplaySummary();
        }

        private void LoadDataAndDisplaySummary()
        {
            if (_parentBookingForm.SelectedShowtime == null || !_parentBookingForm.SelectedSeats.Any())
            {
                MessageBox.Show("Thông tin suất chiếu hoặc ghế đã chọn không hợp lệ. Vui lòng thử lại.", "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _parentBookingForm.NavigateBackToRoomLayout();
                return;
            }

            // Lấy thông tin chi tiết phim (nếu cần nhiều hơn những gì có trong SelectedShowtime)
            _movieDetails = _dataAccessLayer.GetMovieById(_parentBookingForm._initialMovieId);
            _seatTypes = _dataAccessLayer.GetAllSeatTypes();

            AppUtils.WriteLine($"_movieDetails: {_movieDetails}");
            AppUtils.WriteLine($"_seatTypes: {_seatTypes}");
            AppUtils.WriteLine($"_parentBookingForm.SelectedShowtime.MovieId: {_parentBookingForm.SelectedShowtime.MovieId}");


            if (_movieDetails == null || _seatTypes == null)
            {
                MessageBox.Show("Không thể tải đầy đủ thông tin đặt vé.", "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Hiển thị thông tin phim và suất chiếu
            lblMovieInfo.Text = $"Phim: {_movieDetails.Title} ({_movieDetails.RatingDetails})";
            lblShowtimeInfoSummary.Text = $"Suất chiếu: {_parentBookingForm.SelectedShowtime.StartTime:dd/MM/yyyy HH:mm} - Phòng: {_parentBookingForm.SelectedShowtime.RoomName}";

            decimal seatSubtotal = 0;
            StringBuilder seatDetailsBuilder = new StringBuilder();
            if (_parentBookingForm.SelectedSeats.Any())
            {
                seatDetailsBuilder.AppendLine("Ghế đã chọn:");
                foreach (var seat in _parentBookingForm.SelectedSeats.OrderBy(s => s.RowIdentifier).ThenBy(s => int.TryParse(s.SeatNumberInRow, out int num) ? num : 0))
                {
                    SeatTypeModel seatType = _seatTypes.FirstOrDefault(st => st.SeatTypeId == seat.SeatTypeId);
                    decimal price = seatType?.DefaultPrice ?? 0;
                    seatSubtotal += price;
                    seatDetailsBuilder.AppendLine($"  - {seat.RowIdentifier}{seat.SeatNumberInRow} ({seatType?.TypeName ?? "N/A"}): {price:N0}đ");
                }
            }
            else
            {
                seatDetailsBuilder.AppendLine("Chưa chọn ghế nào.");
            }
            rtbSeatDetails.Text = seatDetailsBuilder.ToString();
            lblSeatSubtotal.Text = $"Tổng tiền ghế: {seatSubtotal:N0} VNĐ";

            // Hiển thị thông tin đồ ăn
            decimal foodSubtotal = 0;
            StringBuilder foodDetailsBuilder = new StringBuilder();
            if (_parentBookingForm.SelectedFoodItems.Any())
            {
                foodDetailsBuilder.AppendLine("Đồ ăn/Thức uống đã chọn:");
                foreach (var foodItemData in _parentBookingForm.SelectedFoodItems.OrderBy(f => f.FoodItemName))
                {
                    foodSubtotal += foodItemData.Subtotal;
                    foodDetailsBuilder.AppendLine($"  - {foodItemData.FoodItemName} (x{foodItemData.Quantity}): {foodItemData.Subtotal:N0}đ");
                }
            }
            else
            {
                foodDetailsBuilder.AppendLine("Không chọn đồ ăn/thức uống.");
            }
            rtbFoodDetails.Text = foodDetailsBuilder.ToString();
            lblFoodSubtotal.Text = $"Tổng tiền đồ ăn: {foodSubtotal:N0} VNĐ";

            decimal overallTotal = seatSubtotal + foodSubtotal;
            lblOverallTotalValue.Text = $"{overallTotal:N0} VNĐ";

            AppUtils.WriteLine($"[OrderSummaryControl] Summary loaded. Seat Subtotal: {seatSubtotal}, Food Subtotal: {foodSubtotal}, Overall Total: {overallTotal}");
        }


        private void btnConfirmAndPay_Click(object sender, EventArgs e)
        {
            AppUtils.WriteLine("[OrderSummaryControl] Confirm and Pay button clicked.");

            UserModel currentUser = AppUtils.GetLoggedInUserInfo();

            if (_parentBookingForm.SelectedShowtime == null ||
                _parentBookingForm.SelectedSeats == null || !_parentBookingForm.SelectedSeats.Any())
            {
                MessageBox.Show("Thông tin đặt vé chưa đầy đủ (thiếu suất chiếu hoặc ghế). Vui lòng kiểm tra lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Gọi phương thức DAL để tạo đơn hàng
            OrderConfirmationModel confirmation = _dataAccessLayer.CreateFullOrder(
                currentUser,
                _parentBookingForm.SelectedShowtime,
                _parentBookingForm.SelectedSeats,
                _parentBookingForm.SelectedFoodItems,
                _seatTypes
            );

            if (confirmation != null)
            {
                AppUtils.WriteLine($"[OrderSummaryControl] Order created successfully. OrderID: {confirmation.OrderId}");
                _parentBookingForm.NavigateToOrderedTicketInfo(confirmation);
            }
            else
            {
                AppUtils.WriteLine("ERROR: [OrderSummaryControl] Failed to create full order.");
                MessageBox.Show("Đã có lỗi xảy ra trong quá trình tạo đơn hàng. Vui lòng thử lại.", "Lỗi Đặt Vé", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBackToFood_Click(object sender, EventArgs e)
        {
            AppUtils.WriteLine("[OrderSummaryControl] Back to Food Selection clicked.");
            _parentBookingForm.NavigateToFoodOrder();
        }

        private void btnCancelOrder_Click(object sender, EventArgs e)
        {
            AppUtils.WriteLine("[OrderSummaryControl] Cancel Order clicked.");
            var confirmResult = MessageBox.Show("Bạn có chắc chắn muốn hủy toàn bộ đơn đặt vé này không?",
                                                 "Xác nhận hủy",
                                                 MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmResult == DialogResult.Yes)
            {
                _parentBookingForm.CompleteBookingProcess(false);
            }
        }
    }
}
