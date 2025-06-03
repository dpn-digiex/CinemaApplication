using CinemaApplication.DataAccess;
using CinemaApplication.Models;
using CinemaApplication.UserControls;
using CinemaApplication.Utils;

namespace CinemaApplication.Forms.Customer
{
    public partial class MovieDetailsBookingForm : Form
    {
        private readonly DataAccessLayer _dataAccessLayer;
        private UserControl _currentStepControl = null;

        public readonly int _initialMovieId;
        public ShowtimeBookingInfoModel SelectedShowtime { get; set; }
        public List<SeatModel> SelectedSeats { get; set; } = new List<SeatModel>();
        public List<OrderFoodItemData> SelectedFoodItems { get; set; } = new List<OrderFoodItemData>();
        public MovieDetailsBookingForm(int currentMovieId, DataAccessLayer dataAccessLayerRef)
        {
            InitializeComponent();
            _dataAccessLayer= dataAccessLayerRef;
            _initialMovieId = currentMovieId;
            AppUtils.WriteLine($"[MovieDetailsBookingForm] Initializing with MovieID: {_initialMovieId}");
            LoadStep(new MovieDetailsControl(_initialMovieId, _dataAccessLayer, this));
        }
        public void LoadStep(UserControl stepControl)
        {
            if (stepControl == null)
            {
                AppUtils.WriteLine("ERROR: [MovieDetailsBookingForm] Attempted to load a null stepControl.");
                return;
            }

            AppUtils.WriteLine($"[MovieDetailsBookingForm] Loading step: {stepControl.GetType().Name}");

            panelBooking.SuspendLayout(); // Tạm dừng layout để tránh nhấp nháy

            // Dọn dẹp control cũ một cách an toàn
            if (_currentStepControl != null)
            {
                if (panelBooking.Controls.Contains(_currentStepControl))
                {
                    panelBooking.Controls.Remove(_currentStepControl);
                }
                _currentStepControl.Dispose(); // Quan trọng: giải phóng tài nguyên của UserControl cũ
                _currentStepControl = null;
            }

            _currentStepControl = stepControl;
            stepControl.Dock = DockStyle.Fill; // Control con sẽ chiếm toàn bộ panel
            panelBooking.Controls.Add(stepControl);
            stepControl.BringToFront(); // Đảm bảo nó ở trên cùng
            // stepControl.Show(); // Không cần thiết, UserControl tự hiển thị

            panelBooking.ResumeLayout(true); // Tiếp tục layout
            AppUtils.WriteLine($"[MovieDetailsBookingForm] Step {stepControl.GetType().Name} loaded and displayed.");
        }
        public void NavigateToMovieShowtimeSelection(int movieId)
        {
            AppUtils.WriteLine($"[MovieDetailsBookingForm] Navigating to ShowtimeSelection for MovieID: {movieId}");
            LoadStep(new MovieShowtimeSelectionControl(movieId, _dataAccessLayer, this));
        }
        public void NavigateToRoomLayout(ShowtimeBookingInfoModel selectedShowtime) 
        {
            if (selectedShowtime == null)
            {
                AppUtils.WriteLine("ERROR: [MovieDetailsBookingForm] NavigateToRoomLayout called with null selectedShowtime.");
                return;
            }
            this.SelectedShowtime = selectedShowtime;
            this.SelectedSeats.Clear(); 

            AppUtils.WriteLine($"[MovieDetailsBookingForm] Navigating to RoomLayout for ShowtimeID: {selectedShowtime.ShowtimeId}, RoomID: {selectedShowtime.RoomId}, MovieID: {_initialMovieId}");
            LoadStep(new MovieRoomLayoutBookingControl(selectedShowtime, _initialMovieId, _dataAccessLayer, this));
        }
        public void NavigateToFoodOrder()
        {
            AppUtils.WriteLine($"[MovieDetailsBookingForm] Navigating to Food Order. Seats selected: {SelectedSeats.Count}");
            LoadStep(new FoodOrderControl(_dataAccessLayer, this));
        }
        public void NavigateToOrderSummary()
        {
            AppUtils.WriteLine($"[MovieDetailsBookingForm] Navigating to Order Summary. Seats: {SelectedSeats.Count}, Food Items: {SelectedFoodItems.Count}");
            LoadStep(new OrderSummaryControl(_dataAccessLayer, this));
        }

        public void NavigateToOrderedTicketInfo(OrderConfirmationModel confirmationData)
        {
            AppUtils.WriteLine($"[MovieDetailsBookingForm] Navigating to Order Summary. Seats: {SelectedSeats.Count}, Food Items: {SelectedFoodItems.Count}");
            LoadStep(new OrderedTicketInfoControl(confirmationData, _dataAccessLayer, this));
        }
        public void NavigateBackToRoomLayout()
        {
            if (this.SelectedShowtime == null)
            {
                AppUtils.WriteLine("ERROR: [MovieDetailsBookingForm] Cannot navigate back to room layout, SelectedShowtime is null.");
                NavigateBackToMovieDetails();
                return;
            }
            AppUtils.WriteLine($"[MovieDetailsBookingForm] Navigating back to RoomLayout. ShowtimeID: {SelectedShowtime.ShowtimeId}");
            LoadStep(new MovieRoomLayoutBookingControl(this.SelectedShowtime, this._initialMovieId, _dataAccessLayer, this));
        }
        public void NavigateBackToMovieDetails()
        {
            AppUtils.WriteLine($"[MovieDetailsBookingForm] Navigating back to MovieDetails for MovieID: {_initialMovieId}");
            this.SelectedShowtime = null;
            this.SelectedSeats.Clear();
            LoadStep(new MovieDetailsControl(_initialMovieId, _dataAccessLayer, this));
        }
        public void NavigateBackToShowtimeSelection(int movieId)
        {
            AppUtils.WriteLine($"[MovieDetailsBookingForm] Navigating back to ShowtimeSelection for MovieID: {movieId}");
            this.SelectedSeats.Clear();
            LoadStep(new MovieShowtimeSelectionControl(movieId, _dataAccessLayer, this));
        }
        public void CompleteBookingProcess(bool success)
        {
            AppUtils.WriteLine($"[MovieDetailsBookingForm] CompleteBookingProcess called. Success: {success}");
            this.DialogResult = success ? DialogResult.OK : DialogResult.Cancel;
            this.Close();
        }
        private void ShowPlaceholderInPanel(string message)
        {
            if (_currentStepControl != null)
            {
                panelBooking.Controls.Remove(_currentStepControl);
                _currentStepControl.Dispose();
                _currentStepControl = null;
            }
            Label lblPlaceholder = new Label
            {
                Text = message,
                Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill
            };
            panelBooking.Controls.Add(lblPlaceholder);
            lblPlaceholder.BringToFront();
        }
    }
}
