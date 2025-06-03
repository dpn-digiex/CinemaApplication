namespace CinemaApplication.Forms.Admin
{
    partial class StatisticalForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        /// 
        private System.Windows.Forms.TabControl tabControlMainStats;
        private System.Windows.Forms.TabPage tabPageInfrastructure;
        private System.Windows.Forms.Panel panelInfraTop;
        private System.Windows.Forms.FlowLayoutPanel flowPanelInfraSummary;
        private System.Windows.Forms.Label lblTotalActiveRoomsText;
        private System.Windows.Forms.Label lblTotalActiveRoomsValue;
        private System.Windows.Forms.Label lblTotalActiveSeatsText;
        private System.Windows.Forms.Label lblTotalActiveSeatsValue;
        private System.Windows.Forms.DataGridView dgvSeatTypePhysicalStats;
        private System.Windows.Forms.TabPage tabPageMovieStats;
        private System.Windows.Forms.DataGridView dgvMovieStatusStats;
        private System.Windows.Forms.TabPage tabPageSalesAndRevenue;
        private System.Windows.Forms.Panel panelDateFilterControls;
        private System.Windows.Forms.Label lblDateRangePrompt;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.Label lblDateRangeSeparator;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.Button btnLoadPeriodStats;
        private System.Windows.Forms.GroupBox grpRevenueDetails;
        private System.Windows.Forms.Label lblTicketRevenueText;
        private System.Windows.Forms.Label lblTicketRevenueValue;
        private System.Windows.Forms.Label lblFoodRevenueText;
        private System.Windows.Forms.Label lblFoodRevenueValue;
        private System.Windows.Forms.Label lblTotalOrdersRevenueText;
        private System.Windows.Forms.Label lblTotalOrdersRevenueValue;
        private System.Windows.Forms.GroupBox grpPopularityStats;
        private System.Windows.Forms.Label lblTotalTicketsSoldPeriodText;
        private System.Windows.Forms.Label lblTotalTicketsSoldPeriodValue;
        private System.Windows.Forms.Label lblMostPopularFoodPeriodText;
        private System.Windows.Forms.Label lblMostPopularFoodPeriodValue;
        private System.Windows.Forms.Label lblMostPopularSeatTypePeriodText;
        private System.Windows.Forms.Label lblMostPopularSeatTypePeriodValue;
        private System.Windows.Forms.DataGridView dgvTicketSalesBySeatTypePeriod;
        private System.Windows.Forms.Label lblMostPopularMoviePeriodText;
        private System.Windows.Forms.Label lblMostPopularMoviePeriodValue;
        private System.Windows.Forms.Label lblTotalTicketRevenueText;
        private System.Windows.Forms.Label lblTotalTicketRevenueValue;
        private System.Windows.Forms.Label lblMostPopularMovieValue;
        private System.Windows.Forms.Label lblMostPopularMovieText;
        private System.Windows.Forms.Label lblMostPopularSeatTypeValue;
        private System.Windows.Forms.DataGridView dgvTicketSalesByMoviePeriod;

        private void InitializeComponent()
        {
            tabControlMainStats = new TabControl();
            tabPageInfrastructure = new TabPage();
            dgvSeatTypePhysicalStats = new DataGridView();
            panelInfraTop = new Panel();
            flowPanelInfraSummary = new FlowLayoutPanel();
            lblTotalActiveRoomsText = new Label();
            lblTotalActiveRoomsValue = new Label();
            lblTotalActiveSeatsText = new Label();
            lblTotalActiveSeatsValue = new Label();
            tabPageMovieStats = new TabPage();
            dgvMovieStatusStats = new DataGridView();
            tabPageSalesAndRevenue = new TabPage();
            grpPopularityStats = new GroupBox();
            lblMostPopularFoodValue = new Label();
            dgvTicketSalesByMoviePeriod = new DataGridView();
            dgvTicketSalesBySeatTypePeriod = new DataGridView();
            lblMostPopularSeatTypePeriodText = new Label();
            lblTotalTicketsSoldPeriodValue = new Label();
            lblTotalTicketsSoldPeriodText = new Label();
            lblMostPopularFoodPeriodValue = new Label();
            lblMostPopularFoodPeriodText = new Label();
            grpRevenueDetails = new GroupBox();
            lblTotalOrdersRevenueValue = new Label();
            lblTotalOrdersRevenueText = new Label();
            lblFoodRevenueValue = new Label();
            lblFoodRevenueText = new Label();
            lblTicketRevenueValue = new Label();
            lblTotalTicketRevenueText = new Label();
            panelDateFilterControls = new Panel();
            lblDateRangePrompt = new Label();
            dtpStartDate = new DateTimePicker();
            lblDateRangeSeparator = new Label();
            dtpEndDate = new DateTimePicker();
            btnLoadPeriodStats = new Button();
            lblTicketRevenueText = new Label();
            lblMostPopularSeatTypePeriodValue = new Label();
            lblMostPopularMoviePeriodText = new Label();
            lblMostPopularMoviePeriodValue = new Label();
            lblTotalTicketRevenueValue = new System.Windows.Forms.Label();
            lblFoodRevenueValue = new System.Windows.Forms.Label();
            lblTotalOrdersRevenueValue = new System.Windows.Forms.Label();
            lblMostPopularSeatTypeValue = new System.Windows.Forms.Label();
            lblMostPopularMovieValue = new System.Windows.Forms.Label();
            tabControlMainStats.SuspendLayout();
            tabPageInfrastructure.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSeatTypePhysicalStats).BeginInit();
            panelInfraTop.SuspendLayout();
            flowPanelInfraSummary.SuspendLayout();
            tabPageMovieStats.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMovieStatusStats).BeginInit();
            tabPageSalesAndRevenue.SuspendLayout();
            grpPopularityStats.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTicketSalesByMoviePeriod).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvTicketSalesBySeatTypePeriod).BeginInit();
            grpRevenueDetails.SuspendLayout();
            panelDateFilterControls.SuspendLayout();
            SuspendLayout();
            // 
            // tabControlMainStats
            // 
            tabControlMainStats.Controls.Add(tabPageInfrastructure);
            tabControlMainStats.Controls.Add(tabPageMovieStats);
            tabControlMainStats.Controls.Add(tabPageSalesAndRevenue);
            tabControlMainStats.Dock = DockStyle.Fill;
            tabControlMainStats.Location = new Point(0, 0);
            tabControlMainStats.Margin = new Padding(4, 5, 4, 5);
            tabControlMainStats.Name = "tabControlMainStats";
            tabControlMainStats.Padding = new Point(10, 5);
            tabControlMainStats.SelectedIndex = 0;
            tabControlMainStats.Size = new Size(1045, 1048);
            tabControlMainStats.TabIndex = 0;
            // 
            // tabPageInfrastructure
            // 
            tabPageInfrastructure.Controls.Add(dgvSeatTypePhysicalStats);
            tabPageInfrastructure.Controls.Add(panelInfraTop);
            tabPageInfrastructure.Location = new Point(4, 33);
            tabPageInfrastructure.Margin = new Padding(4, 5, 4, 5);
            tabPageInfrastructure.Name = "tabPageInfrastructure";
            tabPageInfrastructure.Padding = new Padding(13, 15, 13, 15);
            tabPageInfrastructure.Size = new Size(1037, 1011);
            tabPageInfrastructure.TabIndex = 0;
            tabPageInfrastructure.Text = "Tổng Quan CSVC";
            tabPageInfrastructure.UseVisualStyleBackColor = true;
            // 
            // dgvSeatTypePhysicalStats
            // 
            dgvSeatTypePhysicalStats.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSeatTypePhysicalStats.Dock = DockStyle.Fill;
            dgvSeatTypePhysicalStats.Location = new Point(13, 63);
            dgvSeatTypePhysicalStats.Margin = new Padding(4, 5, 4, 5);
            dgvSeatTypePhysicalStats.Name = "dgvSeatTypePhysicalStats";
            dgvSeatTypePhysicalStats.RowHeadersWidth = 51;
            dgvSeatTypePhysicalStats.Size = new Size(1011, 933);
            dgvSeatTypePhysicalStats.TabIndex = 1;
            // 
            // panelInfraTop
            // 
            panelInfraTop.AutoSize = true;
            panelInfraTop.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panelInfraTop.Controls.Add(flowPanelInfraSummary);
            panelInfraTop.Dock = DockStyle.Top;
            panelInfraTop.Location = new Point(13, 15);
            panelInfraTop.Margin = new Padding(4, 5, 4, 5);
            panelInfraTop.Name = "panelInfraTop";
            panelInfraTop.Size = new Size(1011, 48);
            panelInfraTop.TabIndex = 0;
            // 
            // flowPanelInfraSummary
            // 
            flowPanelInfraSummary.AutoSize = true;
            flowPanelInfraSummary.Controls.Add(lblTotalActiveRoomsText);
            flowPanelInfraSummary.Controls.Add(lblTotalActiveRoomsValue);
            flowPanelInfraSummary.Controls.Add(lblTotalActiveSeatsText);
            flowPanelInfraSummary.Controls.Add(lblTotalActiveSeatsValue);
            flowPanelInfraSummary.Dock = DockStyle.Fill;
            flowPanelInfraSummary.Location = new Point(0, 0);
            flowPanelInfraSummary.Margin = new Padding(4, 5, 4, 5);
            flowPanelInfraSummary.Name = "flowPanelInfraSummary";
            flowPanelInfraSummary.Padding = new Padding(0, 0, 0, 15);
            flowPanelInfraSummary.Size = new Size(1011, 48);
            flowPanelInfraSummary.TabIndex = 0;
            // 
            // lblTotalActiveRoomsText
            // 
            lblTotalActiveRoomsText.AutoSize = true;
            lblTotalActiveRoomsText.Font = new Font("Segoe UI", 9.75F);
            lblTotalActiveRoomsText.Location = new Point(0, 5);
            lblTotalActiveRoomsText.Margin = new Padding(0, 5, 4, 5);
            lblTotalActiveRoomsText.Name = "lblTotalActiveRoomsText";
            lblTotalActiveRoomsText.Size = new Size(149, 23);
            lblTotalActiveRoomsText.TabIndex = 0;
            lblTotalActiveRoomsText.Text = "Phòng hoạt động:";
            // 
            // lblTotalActiveRoomsValue
            // 
            lblTotalActiveRoomsValue.AutoSize = true;
            lblTotalActiveRoomsValue.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            lblTotalActiveRoomsValue.Location = new Point(153, 5);
            lblTotalActiveRoomsValue.Margin = new Padding(0, 5, 20, 5);
            lblTotalActiveRoomsValue.Name = "lblTotalActiveRoomsValue";
            lblTotalActiveRoomsValue.Size = new Size(20, 23);
            lblTotalActiveRoomsValue.TabIndex = 1;
            lblTotalActiveRoomsValue.Text = "0";
            // 
            // lblTotalActiveSeatsText
            // 
            lblTotalActiveSeatsText.AutoSize = true;
            lblTotalActiveSeatsText.Font = new Font("Segoe UI", 9.75F);
            lblTotalActiveSeatsText.Location = new Point(193, 5);
            lblTotalActiveSeatsText.Margin = new Padding(0, 5, 4, 5);
            lblTotalActiveSeatsText.Name = "lblTotalActiveSeatsText";
            lblTotalActiveSeatsText.Size = new Size(130, 23);
            lblTotalActiveSeatsText.TabIndex = 2;
            lblTotalActiveSeatsText.Text = "Ghế hoạt động:";
            // 
            // lblTotalActiveSeatsValue
            // 
            lblTotalActiveSeatsValue.AutoSize = true;
            lblTotalActiveSeatsValue.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            lblTotalActiveSeatsValue.Location = new Point(327, 5);
            lblTotalActiveSeatsValue.Margin = new Padding(0, 5, 0, 5);
            lblTotalActiveSeatsValue.Name = "lblTotalActiveSeatsValue";
            lblTotalActiveSeatsValue.Size = new Size(20, 23);
            lblTotalActiveSeatsValue.TabIndex = 3;
            lblTotalActiveSeatsValue.Text = "0";
            // 
            // tabPageMovieStats
            // 
            tabPageMovieStats.Controls.Add(dgvMovieStatusStats);
            tabPageMovieStats.Location = new Point(4, 33);
            tabPageMovieStats.Margin = new Padding(4, 5, 4, 5);
            tabPageMovieStats.Name = "tabPageMovieStats";
            tabPageMovieStats.Padding = new Padding(13, 15, 13, 15);
            tabPageMovieStats.Size = new Size(1037, 1011);
            tabPageMovieStats.TabIndex = 1;
            tabPageMovieStats.Text = "Thống Kê Phim";
            tabPageMovieStats.UseVisualStyleBackColor = true;
            // 
            // dgvMovieStatusStats
            // 
            dgvMovieStatusStats.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMovieStatusStats.Dock = DockStyle.Fill;
            dgvMovieStatusStats.Location = new Point(13, 15);
            dgvMovieStatusStats.Margin = new Padding(4, 5, 4, 5);
            dgvMovieStatusStats.Name = "dgvMovieStatusStats";
            dgvMovieStatusStats.RowHeadersWidth = 51;
            dgvMovieStatusStats.Size = new Size(1011, 981);
            dgvMovieStatusStats.TabIndex = 0;
            // 
            // tabPageSalesAndRevenue
            // 
            tabPageSalesAndRevenue.AutoScroll = true;
            tabPageSalesAndRevenue.Controls.Add(grpPopularityStats);
            tabPageSalesAndRevenue.Controls.Add(grpRevenueDetails);
            tabPageSalesAndRevenue.Controls.Add(panelDateFilterControls);
            tabPageSalesAndRevenue.Location = new Point(4, 33);
            tabPageSalesAndRevenue.Margin = new Padding(4, 5, 4, 5);
            tabPageSalesAndRevenue.Name = "tabPageSalesAndRevenue";
            tabPageSalesAndRevenue.Padding = new Padding(13, 15, 13, 15);
            tabPageSalesAndRevenue.Size = new Size(1037, 1011);
            tabPageSalesAndRevenue.TabIndex = 2;
            tabPageSalesAndRevenue.Text = "Doanh Thu & Bán Chạy";
            tabPageSalesAndRevenue.UseVisualStyleBackColor = true;
            // 
            // grpPopularityStats
            // 
            grpPopularityStats.Controls.Add(lblMostPopularFoodValue);
            grpPopularityStats.Controls.Add(dgvTicketSalesByMoviePeriod);
            grpPopularityStats.Controls.Add(dgvTicketSalesBySeatTypePeriod);
            grpPopularityStats.Controls.Add(lblMostPopularSeatTypePeriodText);
            grpPopularityStats.Controls.Add(lblTotalTicketsSoldPeriodValue);
            grpPopularityStats.Controls.Add(lblTotalTicketsSoldPeriodText);
            grpPopularityStats.Controls.Add(lblMostPopularFoodPeriodValue);
            grpPopularityStats.Controls.Add(lblMostPopularFoodPeriodText);
            grpPopularityStats.Dock = DockStyle.Top;
            grpPopularityStats.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            grpPopularityStats.Location = new Point(13, 253);
            grpPopularityStats.Margin = new Padding(4, 5, 4, 5);
            grpPopularityStats.Name = "grpPopularityStats";
            grpPopularityStats.Padding = new Padding(13, 15, 13, 15);
            grpPopularityStats.Size = new Size(1011, 692);
            grpPopularityStats.TabIndex = 2;
            grpPopularityStats.TabStop = false;
            grpPopularityStats.Text = "Thống Kê Bán Chạy & Phổ Biến";
            // 
            // lblMostPopularFoodValue
            // 
            lblMostPopularFoodValue.AutoSize = true;
            lblMostPopularFoodValue.Location = new Point(16, 37);
            lblMostPopularFoodValue.Name = "lblMostPopularFoodValue";
            lblMostPopularFoodValue.Size = new Size(215, 23);
            lblMostPopularFoodValue.TabIndex = 7;
            lblMostPopularFoodValue.Text = "lblMostPopularFoodValue";
            // 
            // dgvTicketSalesByMoviePeriod
            // 
            dgvTicketSalesByMoviePeriod.ColumnHeadersHeight = 29;
            dgvTicketSalesByMoviePeriod.Location = new Point(521, 116);
            dgvTicketSalesByMoviePeriod.Margin = new Padding(4, 5, 4, 5);
            dgvTicketSalesByMoviePeriod.Name = "dgvTicketSalesByMoviePeriod";
            dgvTicketSalesByMoviePeriod.RowHeadersWidth = 51;
            dgvTicketSalesByMoviePeriod.Size = new Size(490, 326);
            dgvTicketSalesByMoviePeriod.TabIndex = 0;
            // 
            // dgvTicketSalesBySeatTypePeriod
            // 
            dgvTicketSalesBySeatTypePeriod.ColumnHeadersHeight = 29;
            dgvTicketSalesBySeatTypePeriod.Location = new Point(13, 116);
            dgvTicketSalesBySeatTypePeriod.Margin = new Padding(4, 5, 4, 5);
            dgvTicketSalesBySeatTypePeriod.Name = "dgvTicketSalesBySeatTypePeriod";
            dgvTicketSalesBySeatTypePeriod.RowHeadersWidth = 51;
            dgvTicketSalesBySeatTypePeriod.Size = new Size(483, 326);
            dgvTicketSalesBySeatTypePeriod.TabIndex = 1;
            // 
            // lblMostPopularSeatTypePeriodText
            // 
            lblMostPopularSeatTypePeriodText.Location = new Point(0, 0);
            lblMostPopularSeatTypePeriodText.Margin = new Padding(4, 0, 4, 0);
            lblMostPopularSeatTypePeriodText.Name = "lblMostPopularSeatTypePeriodText";
            lblMostPopularSeatTypePeriodText.Size = new Size(133, 35);
            lblMostPopularSeatTypePeriodText.TabIndex = 2;
            // 
            // lblTotalTicketsSoldPeriodValue
            // 
            lblTotalTicketsSoldPeriodValue.Location = new Point(0, 0);
            lblTotalTicketsSoldPeriodValue.Margin = new Padding(4, 0, 4, 0);
            lblTotalTicketsSoldPeriodValue.Name = "lblTotalTicketsSoldPeriodValue";
            lblTotalTicketsSoldPeriodValue.Size = new Size(133, 35);
            lblTotalTicketsSoldPeriodValue.TabIndex = 3;
            // 
            // lblTotalTicketsSoldPeriodText
            // 
            lblTotalTicketsSoldPeriodText.Location = new Point(0, 0);
            lblTotalTicketsSoldPeriodText.Margin = new Padding(4, 0, 4, 0);
            lblTotalTicketsSoldPeriodText.Name = "lblTotalTicketsSoldPeriodText";
            lblTotalTicketsSoldPeriodText.Size = new Size(133, 35);
            lblTotalTicketsSoldPeriodText.TabIndex = 4;
            // 
            // lblMostPopularFoodPeriodValue
            // 
            lblMostPopularFoodPeriodValue.Location = new Point(0, 0);
            lblMostPopularFoodPeriodValue.Margin = new Padding(4, 0, 4, 0);
            lblMostPopularFoodPeriodValue.Name = "lblMostPopularFoodPeriodValue";
            lblMostPopularFoodPeriodValue.Size = new Size(133, 35);
            lblMostPopularFoodPeriodValue.TabIndex = 5;
            // 
            // lblMostPopularFoodPeriodText
            // 
            lblMostPopularFoodPeriodText.Location = new Point(0, 0);
            lblMostPopularFoodPeriodText.Margin = new Padding(4, 0, 4, 0);
            lblMostPopularFoodPeriodText.Name = "lblMostPopularFoodPeriodText";
            lblMostPopularFoodPeriodText.Size = new Size(133, 35);
            lblMostPopularFoodPeriodText.TabIndex = 6;
            // 
            // grpRevenueDetails
            // 
            grpRevenueDetails.Controls.Add(lblTotalOrdersRevenueValue);
            grpRevenueDetails.Controls.Add(lblTotalOrdersRevenueText);
            grpRevenueDetails.Controls.Add(lblFoodRevenueValue);
            grpRevenueDetails.Controls.Add(lblFoodRevenueText);
            grpRevenueDetails.Controls.Add(lblTicketRevenueValue);
            grpRevenueDetails.Controls.Add(lblTotalTicketRevenueText);
            grpRevenueDetails.Dock = DockStyle.Top;
            grpRevenueDetails.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            grpRevenueDetails.Location = new Point(13, 84);
            grpRevenueDetails.Margin = new Padding(4, 5, 4, 5);
            grpRevenueDetails.Name = "grpRevenueDetails";
            grpRevenueDetails.Padding = new Padding(13, 15, 13, 15);
            grpRevenueDetails.Size = new Size(1011, 169);
            grpRevenueDetails.TabIndex = 1;
            grpRevenueDetails.TabStop = false;
            grpRevenueDetails.Text = "Chi Tiết Doanh Thu";
            // 
            // lblTotalOrdersRevenueValue
            // 
            lblTotalOrdersRevenueValue.AutoSize = true;
            lblTotalOrdersRevenueValue.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTotalOrdersRevenueValue.Location = new Point(240, 115);
            lblTotalOrdersRevenueValue.Margin = new Padding(4, 0, 4, 0);
            lblTotalOrdersRevenueValue.Name = "lblTotalOrdersRevenueValue";
            lblTotalOrdersRevenueValue.Size = new Size(55, 20);
            lblTotalOrdersRevenueValue.TabIndex = 0;
            lblTotalOrdersRevenueValue.Text = "0 VNĐ";
            // 
            // lblTotalOrdersRevenueText
            // 
            lblTotalOrdersRevenueText.AutoSize = true;
            lblTotalOrdersRevenueText.Font = new Font("Segoe UI", 9F);
            lblTotalOrdersRevenueText.Location = new Point(13, 115);
            lblTotalOrdersRevenueText.Margin = new Padding(4, 0, 4, 0);
            lblTotalOrdersRevenueText.Name = "lblTotalOrdersRevenueText";
            lblTotalOrdersRevenueText.Size = new Size(170, 20);
            lblTotalOrdersRevenueText.TabIndex = 1;
            lblTotalOrdersRevenueText.Text = "Tổng giá trị đơn (đã TT):";
            // 
            // lblFoodRevenueValue
            // 
            lblFoodRevenueValue.AutoSize = true;
            lblFoodRevenueValue.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblFoodRevenueValue.Location = new Point(240, 77);
            lblFoodRevenueValue.Margin = new Padding(4, 0, 4, 0);
            lblFoodRevenueValue.Name = "lblFoodRevenueValue";
            lblFoodRevenueValue.Size = new Size(55, 20);
            lblFoodRevenueValue.TabIndex = 2;
            lblFoodRevenueValue.Text = "0 VNĐ";
            // 
            // lblFoodRevenueText
            // 
            lblFoodRevenueText.AutoSize = true;
            lblFoodRevenueText.Font = new Font("Segoe UI", 9F);
            lblFoodRevenueText.Location = new Point(13, 77);
            lblFoodRevenueText.Margin = new Padding(4, 0, 4, 0);
            lblFoodRevenueText.Name = "lblFoodRevenueText";
            lblFoodRevenueText.Size = new Size(162, 20);
            lblFoodRevenueText.TabIndex = 3;
            lblFoodRevenueText.Text = "Doanh thu đồ ăn/nước:";
            // 
            // lblTicketRevenueValue
            // 
            lblTicketRevenueValue.Location = new Point(0, 0);
            lblTicketRevenueValue.Margin = new Padding(4, 0, 4, 0);
            lblTicketRevenueValue.Name = "lblTicketRevenueValue";
            lblTicketRevenueValue.Size = new Size(133, 35);
            lblTicketRevenueValue.TabIndex = 4;
            // 
            // lblTotalTicketRevenueText
            // 
            lblTotalTicketRevenueText.AutoSize = true;
            lblTotalTicketRevenueText.Font = new Font("Segoe UI", 9F);
            lblTotalTicketRevenueText.Location = new Point(13, 38);
            lblTotalTicketRevenueText.Margin = new Padding(4, 0, 4, 0);
            lblTotalTicketRevenueText.Name = "lblTotalTicketRevenueText";
            lblTotalTicketRevenueText.Size = new Size(100, 20);
            lblTotalTicketRevenueText.TabIndex = 5;
            lblTotalTicketRevenueText.Text = "Doanh thu vé:";
            // 
            // panelDateFilterControls
            // 
            panelDateFilterControls.Controls.Add(lblDateRangePrompt);
            panelDateFilterControls.Controls.Add(dtpStartDate);
            panelDateFilterControls.Controls.Add(lblDateRangeSeparator);
            panelDateFilterControls.Controls.Add(dtpEndDate);
            panelDateFilterControls.Controls.Add(btnLoadPeriodStats);
            panelDateFilterControls.Dock = DockStyle.Top;
            panelDateFilterControls.Location = new Point(13, 15);
            panelDateFilterControls.Margin = new Padding(4, 5, 4, 5);
            panelDateFilterControls.Name = "panelDateFilterControls";
            panelDateFilterControls.Size = new Size(1011, 69);
            panelDateFilterControls.TabIndex = 0;
            // 
            // lblDateRangePrompt
            // 
            lblDateRangePrompt.AutoSize = true;
            lblDateRangePrompt.Font = new Font("Segoe UI", 9F);
            lblDateRangePrompt.Location = new Point(4, 18);
            lblDateRangePrompt.Margin = new Padding(4, 0, 4, 0);
            lblDateRangePrompt.Name = "lblDateRangePrompt";
            lblDateRangePrompt.Size = new Size(96, 20);
            lblDateRangePrompt.TabIndex = 0;
            lblDateRangePrompt.Text = "Xem từ ngày:";
            // 
            // dtpStartDate
            // 
            dtpStartDate.Format = DateTimePickerFormat.Short;
            dtpStartDate.Location = new Point(123, 15);
            dtpStartDate.Margin = new Padding(4, 5, 4, 5);
            dtpStartDate.Name = "dtpStartDate";
            dtpStartDate.Size = new Size(132, 27);
            dtpStartDate.TabIndex = 1;
            // 
            // lblDateRangeSeparator
            // 
            lblDateRangeSeparator.AutoSize = true;
            lblDateRangeSeparator.Font = new Font("Segoe UI", 9F);
            lblDateRangeSeparator.Location = new Point(280, 20);
            lblDateRangeSeparator.Margin = new Padding(4, 0, 4, 0);
            lblDateRangeSeparator.Name = "lblDateRangeSeparator";
            lblDateRangeSeparator.Size = new Size(34, 20);
            lblDateRangeSeparator.TabIndex = 2;
            lblDateRangeSeparator.Text = "đến";
            // 
            // dtpEndDate
            // 
            dtpEndDate.Format = DateTimePickerFormat.Short;
            dtpEndDate.Location = new Point(333, 15);
            dtpEndDate.Margin = new Padding(4, 5, 4, 5);
            dtpEndDate.Name = "dtpEndDate";
            dtpEndDate.Size = new Size(132, 27);
            dtpEndDate.TabIndex = 2;
            // 
            // btnLoadPeriodStats
            // 
            btnLoadPeriodStats.Location = new Point(512, 11);
            btnLoadPeriodStats.Margin = new Padding(4, 5, 4, 5);
            btnLoadPeriodStats.Name = "btnLoadPeriodStats";
            btnLoadPeriodStats.Size = new Size(160, 38);
            btnLoadPeriodStats.TabIndex = 3;
            btnLoadPeriodStats.Text = "Tải Dữ Liệu";
            btnLoadPeriodStats.Click += btnLoadPeriodStats_Click;
            // 
            // lblTicketRevenueText
            // 
            lblTicketRevenueText.Location = new Point(0, 0);
            lblTicketRevenueText.Name = "lblTicketRevenueText";
            lblTicketRevenueText.Size = new Size(100, 23);
            lblTicketRevenueText.TabIndex = 0;
            // 
            // lblMostPopularSeatTypePeriodValue
            // 
            lblMostPopularSeatTypePeriodValue.Location = new Point(0, 0);
            lblMostPopularSeatTypePeriodValue.Name = "lblMostPopularSeatTypePeriodValue";
            lblMostPopularSeatTypePeriodValue.Size = new Size(100, 23);
            lblMostPopularSeatTypePeriodValue.TabIndex = 0;
            // 
            // lblMostPopularMoviePeriodText
            // 
            lblMostPopularMoviePeriodText.Location = new Point(0, 0);
            lblMostPopularMoviePeriodText.Name = "lblMostPopularMoviePeriodText";
            lblMostPopularMoviePeriodText.Size = new Size(100, 23);
            lblMostPopularMoviePeriodText.TabIndex = 0;
            // 
            // lblMostPopularMoviePeriodValue
            // 
            lblMostPopularMoviePeriodValue.Location = new Point(0, 0);
            lblMostPopularMoviePeriodValue.Name = "lblMostPopularMoviePeriodValue";
            lblMostPopularMoviePeriodValue.Size = new Size(100, 23);
            lblMostPopularMoviePeriodValue.TabIndex = 0;
            // 
            // StatisticalForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1045, 1048);
            Controls.Add(tabControlMainStats);
            Margin = new Padding(4, 5, 4, 5);
            Name = "StatisticalForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Báo Cáo và Thống Kê";
            Load += StatisticalForm_Load;
            tabControlMainStats.ResumeLayout(false);
            tabPageInfrastructure.ResumeLayout(false);
            tabPageInfrastructure.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSeatTypePhysicalStats).EndInit();
            panelInfraTop.ResumeLayout(false);
            panelInfraTop.PerformLayout();
            flowPanelInfraSummary.ResumeLayout(false);
            flowPanelInfraSummary.PerformLayout();
            tabPageMovieStats.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvMovieStatusStats).EndInit();
            tabPageSalesAndRevenue.ResumeLayout(false);
            grpPopularityStats.ResumeLayout(false);
            grpPopularityStats.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTicketSalesByMoviePeriod).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvTicketSalesBySeatTypePeriod).EndInit();
            grpRevenueDetails.ResumeLayout(false);
            grpRevenueDetails.PerformLayout();
            panelDateFilterControls.ResumeLayout(false);
            panelDateFilterControls.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label lblMostPopularFoodValue;
    }
}