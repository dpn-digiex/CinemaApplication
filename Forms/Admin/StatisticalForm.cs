using CinemaApplication.DataAccess;
using CinemaApplication.Enums;
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
using static CinemaApplication.Models.OrderConfirmationModel;

namespace CinemaApplication.Forms.Admin
{
    public partial class StatisticalForm : Form
    {
        private DataAccessLayer _dataAccessLayer;
        public StatisticalForm(DataAccessLayer _dataAccessLayerRef)
        {
            InitializeComponent();
            _dataAccessLayer = _dataAccessLayerRef;
        }

        private void StatisticalForm_Load(object sender, EventArgs e)
        {
            if (_dataAccessLayer == null)
            {
                MessageBox.Show("Lớp truy cập dữ liệu không khả dụng. Không thể tải thống kê.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            AppUtils.WriteLine("[StatisticalForm] Form Load started.");
            SetupAllDataGridViews();
            LoadStaticStats();
            InitializeDateFilters();
            //LoadRevenueAndPopularityStats();
            AppUtils.WriteLine("[StatisticalForm] Form Load completed.");
        }

        private void InitializeDateFilters()
        {
            dtpEndDate.Value = DateTime.Today; // Ngày kết thúc là hôm nay
            dtpStartDate.Value = DateTime.Today.AddMonths(-1).Date; // Ngày bắt đầu là 1 tháng trước
            dtpEndDate.MinDate = dtpStartDate.Value; // Đảm bảo ngày kết thúc không trước ngày bắt đầu

            // Cập nhật MinDate của dtpEndDate khi dtpStartDate thay đổi
            dtpStartDate.ValueChanged += (s, e) => {
                if (dtpStartDate.Value > dtpEndDate.Value)
                {
                    dtpEndDate.Value = dtpStartDate.Value; // Nếu start > end, gán end = start
                }
                dtpEndDate.MinDate = dtpStartDate.Value;
            };
            AppUtils.WriteLine("[StatisticalForm] Date filters initialized.");
        }

        private void SetupAllDataGridViews()
        {
            // Cấu hình dgvSeatTypePhysicalStats (Số lượng ghế vật lý theo loại)
            if (dgvSeatTypePhysicalStats != null)
            {
                dgvSeatTypePhysicalStats.AutoGenerateColumns = false;
                dgvSeatTypePhysicalStats.Columns.Clear();
                dgvSeatTypePhysicalStats.Columns.Add(new DataGridViewTextBoxColumn { Name = "colPhysSeatTypeName", HeaderText = "Loại Ghế", DataPropertyName = "SeatTypeName", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill, FillWeight = 60 });
                dgvSeatTypePhysicalStats.Columns.Add(new DataGridViewTextBoxColumn { Name = "colPhysSeatCount", HeaderText = "Số Lượng (Active)", DataPropertyName = "Count", Width = 150, DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleRight, Format = "N0" }, FillWeight = 40 });
                dgvSeatTypePhysicalStats.AllowUserToAddRows = false; dgvSeatTypePhysicalStats.ReadOnly = true; dgvSeatTypePhysicalStats.RowHeadersVisible = false;
                dgvSeatTypePhysicalStats.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue;
            }

            // Cấu hình dgvMovieStatusStats
            if (dgvMovieStatusStats != null)
            {
                dgvMovieStatusStats.AutoGenerateColumns = false;
                dgvMovieStatusStats.Columns.Clear();
                dgvMovieStatusStats.Columns.Add(new DataGridViewTextBoxColumn { Name = "colMovieStatusName", HeaderText = "Trạng Thái Phim", DataPropertyName = "Status", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill, FillWeight = 70 });
                dgvMovieStatusStats.Columns.Add(new DataGridViewTextBoxColumn { Name = "colMovieStatusCount", HeaderText = "Số Lượng Phim", DataPropertyName = "Count", Width = 150, DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleRight, Format = "N0" }, FillWeight = 30 });
                dgvMovieStatusStats.AllowUserToAddRows = false; dgvMovieStatusStats.ReadOnly = true; dgvMovieStatusStats.RowHeadersVisible = false;
                dgvMovieStatusStats.AlternatingRowsDefaultCellStyle.BackColor = Color.Honeydew;
            }

            // Cấu hình dgvTicketSalesBySeatTypePeriod
            if (dgvTicketSalesBySeatTypePeriod != null)
            {
                dgvTicketSalesBySeatTypePeriod.AutoGenerateColumns = false;
                dgvTicketSalesBySeatTypePeriod.Columns.Clear();
                dgvTicketSalesBySeatTypePeriod.Columns.Add(new DataGridViewTextBoxColumn { Name = "colSaleSeatTypeName", HeaderText = "Loại Ghế", DataPropertyName = "SeatTypeName", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill, FillWeight = 60 });
                dgvTicketSalesBySeatTypePeriod.Columns.Add(new DataGridViewTextBoxColumn { Name = "colSaleSeatTicketsSold", HeaderText = "Số Vé Bán", DataPropertyName = "TicketsSold", Width = 150, DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleRight, Format = "N0" }, FillWeight = 40 });
                dgvTicketSalesBySeatTypePeriod.AllowUserToAddRows = false; dgvTicketSalesBySeatTypePeriod.ReadOnly = true; dgvTicketSalesBySeatTypePeriod.RowHeadersVisible = false;
                dgvTicketSalesBySeatTypePeriod.AlternatingRowsDefaultCellStyle.BackColor = Color.LavenderBlush;
            }


            // Cấu hình dgvTicketSalesByMoviePeriod
            if (dgvTicketSalesByMoviePeriod != null)
            {
                dgvTicketSalesByMoviePeriod.AutoGenerateColumns = false;
                dgvTicketSalesByMoviePeriod.Columns.Clear();
                dgvTicketSalesByMoviePeriod.Columns.Add(new DataGridViewTextBoxColumn { Name = "colSaleMovieTitle", HeaderText = "Tên Phim", DataPropertyName = "MovieTitle", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill, FillWeight = 70 });
                dgvTicketSalesByMoviePeriod.Columns.Add(new DataGridViewTextBoxColumn { Name = "colSaleMovieTicketsSold", HeaderText = "Số Vé Bán", DataPropertyName = "TicketsSold", Width = 150, DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleRight, Format = "N0" }, FillWeight = 30 });
                dgvTicketSalesByMoviePeriod.AllowUserToAddRows = false; dgvTicketSalesByMoviePeriod.ReadOnly = true; dgvTicketSalesByMoviePeriod.RowHeadersVisible = false;
                dgvTicketSalesByMoviePeriod.AlternatingRowsDefaultCellStyle.BackColor = Color.LightCyan;
            }
            AppUtils.WriteLine("[StatisticalForm] DataGridViews configured.");
        }

        private void LoadStaticStats()
        {
            // Load thống kê cơ sở vật chất
            AppUtils.WriteLine("[StatisticalForm] Loading infrastructure stats...");
            lblTotalActiveRoomsValue.Text = _dataAccessLayer.GetTotalRoomCount().ToString("N0");
            lblTotalActiveSeatsValue.Text = _dataAccessLayer.GetTotalActiveSeatCount().ToString("N0");
            dgvSeatTypePhysicalStats.DataSource = _dataAccessLayer.GetSeatCountByType();
            AppUtils.WriteLine("[StatisticalForm] Infrastructure stats loaded.");

            // Load thống kê phim
            AppUtils.WriteLine("[StatisticalForm] Loading movie stats...");
            dgvMovieStatusStats.DataSource = _dataAccessLayer.GetMovieCountByStatus();
            AppUtils.WriteLine("[StatisticalForm] Movie stats loaded.");
        }

        private void btnLoadPeriodStats_Click(object sender, EventArgs e)
        {
            LoadRevenueAndPopularityStats();
        }

        private void LoadRevenueAndPopularityStats()
        {
            if (_dataAccessLayer == null)
            {
                MessageBox.Show("Lỗi truy cập dữ liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DateTime startDate = dtpStartDate.Value.Date;
            DateTime endDate = dtpEndDate.Value.Date;

            if (startDate > endDate)
            {
                MessageBox.Show("Ngày bắt đầu không thể lớn hơn ngày kết thúc.", "Lỗi Khoảng Ngày", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            AppUtils.WriteLine($"[StatisticalForm] Loading Revenue & Popularity stats for period: {startDate:dd/MM/yyyy} - {endDate:dd/MM/yyyy}");
            this.Cursor = Cursors.WaitCursor;

            // --- Load Revenue Details ---
            RevenueDetailsStat revenueDetails = _dataAccessLayer.GetRevenueDetailsForPeriod(startDate, endDate);
            if (revenueDetails != null)
            {
                lblTotalTicketRevenueValue.Text = $"{revenueDetails.TicketRevenue:N0} VNĐ";
                lblFoodRevenueValue.Text = $"{revenueDetails.FoodAndBeverageRevenue:N0} VNĐ";
                lblTotalOrdersRevenueValue.Text = $"{revenueDetails.TotalOrderSumRevenue:N0} VNĐ";
            }
            else
            {
                lblTotalTicketRevenueValue.Text = "N/A";
                lblFoodRevenueValue.Text = "N/A";
                lblTotalOrdersRevenueValue.Text = "N/A";
            }

            // --- Load Popularity Stats ---
            int topNPopular = 5; // Lấy top N
            List<PopularFoodItemStat> popularFoods = _dataAccessLayer.GetMostPopularFoodItems(startDate, endDate, topNPopular);
            if (popularFoods.Any())
            {
                // Hiển thị top 1, bạn có thể dùng RichTextBox hoặc ListView để hiển thị top N
                lblMostPopularFoodValue.Text = $"{popularFoods[0].FoodItemName} ({popularFoods[0].TotalQuantitySold:N0} lượt)";
            }
            else { lblMostPopularFoodValue.Text = "N/A"; }

            List<SeatTypeSalesStat> seatSales = _dataAccessLayer.GetTicketSalesBySeatType(startDate, endDate);
            dgvTicketSalesBySeatTypePeriod.DataSource = seatSales;
            if (seatSales.Any()) // Sắp xếp theo TicketsSold giảm dần trong DAL
            {
                lblMostPopularSeatTypeValue.Text = $"{seatSales[0].SeatTypeName} ({seatSales[0].TicketsSold:N0} vé)";
            }
            else { lblMostPopularSeatTypeValue.Text = "N/A"; }

            int totalTickets = _dataAccessLayer.GetTotalTicketsSoldForPeriod(startDate, endDate);
            lblTotalTicketsSoldPeriodValue.Text = $"{totalTickets:N0} vé";

            List<MovieSalesStat> movieSales = _dataAccessLayer.GetTicketSalesByMovie(startDate, endDate);
            dgvTicketSalesByMoviePeriod.DataSource = movieSales;
            if (movieSales.Any()) // Sắp xếp theo TicketsSold giảm dần trong DAL
            {
                lblMostPopularMovieValue.Text = $"{movieSales[0].MovieTitle} ({movieSales[0].TicketsSold:N0} vé)";
            }
            else { lblMostPopularMovieValue.Text = "N/A"; }

            AppUtils.WriteLine("[StatisticalForm] Period-dependent stats loaded.");
            this.Cursor = Cursors.Default; // Trả lại con trỏ mặc định
        }
    }
}
