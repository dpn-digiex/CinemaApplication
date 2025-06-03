using CinemaApplication.DataAccess;
using CinemaApplication.Models;
using CinemaApplication.UserControls;
using CinemaApplication.Utils;

namespace CinemaApplication.Forms.Admin
{
    public partial class ShowtimesMovieForm : Form
    {
        private DataAccessLayer _dataAccessLayer;
        public ShowtimesMovieForm(DataAccessLayer dataAccessLayerRef)
        {
            InitializeComponent();
            _dataAccessLayer = dataAccessLayerRef;
        }
        private void ShowtimesMovieForm_Load(object sender, EventArgs e)
        {
            if (_dataAccessLayer != null)
            {
                LoadShowtimesForDate(dtpSelectDate.Value);
            }
        }

        private void DtpSelectDate_ValueChanged(object sender, EventArgs e)
        {
            LoadShowtimesForDate(dtpSelectDate.Value);
        }

        private void BtnRefreshShowtimes_Click(object sender, EventArgs e)
        {
            LoadShowtimesForDate(dtpSelectDate.Value);
        }

        private void LoadShowtimesForDate(DateTime selectedDate)
        {
            if (_dataAccessLayer == null) return;

            AppUtils.WriteLine($"[ShowtimesMovieForm] Loading showtimes for date: {selectedDate:dd/MM/yyyy}");
            flowLayoutPanelShowtimes.Controls.Clear();

            List<FullShowtimeInfoModel> showtimes = _dataAccessLayer.GetFullShowtimesByDate(selectedDate);

            if (showtimes != null && showtimes.Any())
            {
                foreach (var showtimeInfo in showtimes)
                {
                    ShowtimeControl sc = new ShowtimeControl();
                    sc.SetShowtimeData(showtimeInfo);
                    flowLayoutPanelShowtimes.Controls.Add(sc);
                }
                AppUtils.WriteLine($"[ShowtimesMovieForm] Displayed {showtimes.Count} showtimes.");
            }
            else
            {
                Label lblNoShowtimes = new Label
                {
                    Text = $"Không có lịch chiếu nào cho ngày {selectedDate:dd/MM/yyyy}.",
                    AutoSize = true,
                    Font = new Font("Segoe UI", 12F),
                    Padding = new Padding(10)
                };
                flowLayoutPanelShowtimes.Controls.Add(lblNoShowtimes);
                AppUtils.WriteLine($"[ShowtimesMovieForm] No showtimes found for {selectedDate:dd/MM/yyyy}.");
            }
        }
    }
}
