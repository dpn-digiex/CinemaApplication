using CinemaApplication.DataAccess;
using CinemaApplication.Models;
using CinemaApplication.Utils;
using static CinemaApplication.Models.OrderConfirmationModel;

namespace CinemaApplication.Forms.Customer
{
    public partial class MyTicketsForm : Form
    {
        private DataAccessLayer _dataAccessLayer;
        private UserModel _currentUser;
        public MyTicketsForm(DataAccessLayer dataAccessLayerRef)
        {
            InitializeComponent();
            _dataAccessLayer = dataAccessLayerRef;
        }
        private void MyTicketsForm_Load(object sender, EventArgs e)
        {
            _currentUser = AppUtils.GetLoggedInUserInfo();
            if (_currentUser == null)
            {
                AppUtils.WriteLine("[MyTicketsForm] Current user is null. Cannot load tickets.");
                lblNoTicketsMessage.Text = "Vui lòng đăng nhập để xem vé đã đặt của bạn.";
                lblNoTicketsMessage.Visible = true;
                dataGridViewMyTickets.Visible = false;
                if (btnRefresh != null) btnRefresh.Enabled = false;
                return;
            }

            if (_dataAccessLayer != null)
            {
                SetupDataGridView();
                LoadUserTickets();
            }
            else
            {
                lblNoTicketsMessage.Text = "Lỗi hệ thống dữ liệu. Không thể tải vé.";
                lblNoTicketsMessage.Visible = true;
                dataGridViewMyTickets.Visible = false;
                if (btnRefresh != null) btnRefresh.Enabled = false;
            }
        }

        private void SetupDataGridView()
        {
            dataGridViewMyTickets.AutoGenerateColumns = false;
            dataGridViewMyTickets.Columns.Clear();

            dataGridViewMyTickets.Columns.Add(new DataGridViewTextBoxColumn { Name = "colSTT", HeaderText = "STT", DataPropertyName = "STT", Width = 40, SortMode = DataGridViewColumnSortMode.NotSortable });
            dataGridViewMyTickets.Columns.Add(new DataGridViewTextBoxColumn { Name = "colMovieTitle", HeaderText = "Tên Phim", DataPropertyName = "MovieTitle", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dataGridViewMyTickets.Columns.Add(new DataGridViewTextBoxColumn { Name = "colShowtime", HeaderText = "Suất Chiếu", DataPropertyName = "ShowtimeStartTime", Width = 130, DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yy HH:mm" } });
            dataGridViewMyTickets.Columns.Add(new DataGridViewTextBoxColumn { Name = "colRoom", HeaderText = "Phòng", DataPropertyName = "RoomName", Width = 80 });
            dataGridViewMyTickets.Columns.Add(new DataGridViewTextBoxColumn { Name = "colSeat", HeaderText = "Ghế", DataPropertyName = "SeatLocation", Width = 60 });
            dataGridViewMyTickets.Columns.Add(new DataGridViewTextBoxColumn { Name = "colTicketCode", HeaderText = "Mã Vé", DataPropertyName = "TicketCode", Width = 100 });
            dataGridViewMyTickets.Columns.Add(new DataGridViewTextBoxColumn { Name = "colPrice", HeaderText = "Giá Vé (VNĐ)", DataPropertyName = "PricePaid", Width = 100, DefaultCellStyle = new DataGridViewCellStyle { Format = "N0", Alignment = DataGridViewContentAlignment.MiddleRight } });
            dataGridViewMyTickets.Columns.Add(new DataGridViewTextBoxColumn { Name = "colOrderDate", HeaderText = "Ngày Đặt", DataPropertyName = "OrderDate", Width = 130, DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yy HH:mm" } });
            dataGridViewMyTickets.Columns.Add(new DataGridViewTextBoxColumn { Name = "colStatus", HeaderText = "Trạng Thái Vé", DataPropertyName = "TicketStatus", Width = 100 });
            // dataGridViewMyTickets.Columns.Add(new DataGridViewTextBoxColumn { Name = "colTicketId", HeaderText = "TicketID", DataPropertyName = "TicketId", Visible = false });

            dataGridViewMyTickets.AllowUserToAddRows = false;
            dataGridViewMyTickets.ReadOnly = true;
            dataGridViewMyTickets.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewMyTickets.MultiSelect = false;
            dataGridViewMyTickets.RowHeadersVisible = false;
            dataGridViewMyTickets.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridViewMyTickets.BackgroundColor = SystemColors.ControlDark; // Để dễ phân biệt với form
        }

        private void LoadUserTickets()
        {
            if (_currentUser == null || _dataAccessLayer == null) return;

            AppUtils.WriteLine($"[MyTicketsForm] Loading tickets for UserID: {_currentUser.UserId}");
            List<BookedTicketInfoModel> userTickets = _dataAccessLayer.GetTicketsByUserId(_currentUser.UserId);

            if (userTickets != null && userTickets.Any())
            {
                dataGridViewMyTickets.DataSource = userTickets;
                dataGridViewMyTickets.Visible = true;
                lblNoTicketsMessage.Visible = false;
                AppUtils.WriteLine($"[MyTicketsForm] Loaded {userTickets.Count} tickets.");
            }
            else
            {
                dataGridViewMyTickets.DataSource = null;
                dataGridViewMyTickets.Visible = false;
                lblNoTicketsMessage.Text = "Bạn chưa có vé nào được đặt.";
                lblNoTicketsMessage.Visible = true;
                AppUtils.WriteLine("[MyTicketsForm] No tickets found for the current user.");
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (_currentUser != null && _dataAccessLayer != null)
            {
                LoadUserTickets();
            }
            else if (_currentUser == null)
            {
                lblNoTicketsMessage.Text = "Vui lòng đăng nhập để xem vé đã đặt.";
                lblNoTicketsMessage.Visible = true;
                dataGridViewMyTickets.Visible = false;
            }
        }
    }
}
