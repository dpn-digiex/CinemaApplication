using CinemaApplication.DataAccess;
using CinemaApplication.Forms.Customer;
using CinemaApplication.Models;
using CinemaApplication.Utils;
using System.Data;

namespace CinemaApplication.UserControls
{
    public partial class OrderedTicketInfoControl : UserControl
    {
        private DataAccessLayer _dataAccessLayer;
        private readonly MovieDetailsBookingForm _parentBookingForm;
        private readonly OrderConfirmationModel _confirmationData;
        public OrderedTicketInfoControl(OrderConfirmationModel confirmationData, DataAccessLayer _dataAccessLayerRef, MovieDetailsBookingForm parentForm)
        {
            InitializeComponent();
            _confirmationData = confirmationData ?? throw new ArgumentNullException(nameof(confirmationData));
            _parentBookingForm = parentForm ?? throw new ArgumentNullException(nameof(parentForm));
            _dataAccessLayer = _dataAccessLayerRef;
            DisplayOrderedTicketInfo();
        }

        private void DisplayOrderedTicketInfo()
        {
            AppUtils.WriteLine($"[OrderedTicketInfoControl] Displaying confirmation for OrderID: {_confirmationData.OrderId}");
            MovieModel _movie = _dataAccessLayer.GetMovieById(_parentBookingForm._initialMovieId);
            lblOrderId_Value.Text = $"#{_confirmationData.OrderId}";
            lblMovieTitle_Value.Text = $"{_movie.Title}";
            lblShowtime_Value.Text = $"{_confirmationData.ShowtimeStartTime:dd/MM/yyyy HH:mm}";
            lblRoom_Value.Text = $"{_confirmationData.RoomName}";

            if (_confirmationData.SeatCodes != null && _confirmationData.SeatCodes.Any())
            {
                rtbSeatCodes.Text = string.Join(", ", _confirmationData.SeatCodes);
            }
            else { rtbSeatCodes.Text = "Không có thông tin ghế."; }


            if (_confirmationData.TicketCodes != null && _confirmationData.TicketCodes.Any())
            {
                rtbTicketCodes.Text = string.Join("\n", _confirmationData.TicketCodes.Select(tc => $"- {tc}"));
            }
            else { rtbTicketCodes.Text = "Không có mã vé."; }


            if (_confirmationData.FoodItemsSummary != null && _confirmationData.FoodItemsSummary.Any())
            {
                rtbFoodSummary.Text = string.Join("\n", _confirmationData.FoodItemsSummary);
                lblFoodHeader.Visible = true;
                rtbFoodSummary.Visible = true;
            }
            else
            {
                rtbFoodSummary.Text = "Không đặt đồ ăn/thức uống.";
            }

            lblTotalPaid_Value.Text = $"Tổng Thanh Toán: {_confirmationData.TotalAmountPaid:N0} VNĐ";
            lblOrderTime_Value.Text = $"Thời Gian Đặt: {_confirmationData.OrderDateTime:dd/MM/yyyy HH:mm:ss}";
        }

        private void btnReturnToSystem_Click(object sender, EventArgs e)
        {
            AppUtils.WriteLine("[OrderedTicketInfoControl] Return to system clicked.");
            _parentBookingForm.CompleteBookingProcess(true);
        }
    }
}
