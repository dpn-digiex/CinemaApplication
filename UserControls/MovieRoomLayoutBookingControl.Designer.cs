namespace CinemaApplication.UserControls
{
    partial class MovieRoomLayoutBookingControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        /// 
        private Label lblScreen;
        private Panel panelSeatLayout;
        private FlowLayoutPanel flowLegend;
        private Label lblShowtimeInfo;
        private Label lblSelectedSeatsSummary;
        private Label lblTotalPriceSummary;
        private Button btnNext;
        private Button btnBack;
        private Panel panelTopInfo;
        private Panel panelBottomActions;
        private void InitializeComponent()
        {
            lblScreen = new Label();
            panelTopInfo = new Panel();
            btnBack = new Button();
            lblShowtimeInfo = new Label();
            flowLegend = new FlowLayoutPanel();
            panelSeatLayout = new Panel();
            panelBottomActions = new Panel();
            lblSelectedSeatTypesInfo = new Label();
            btnNext = new Button();
            lblTotalPriceSummary = new Label();
            lblSelectedSeatsSummary = new Label();
            panelTopInfo.SuspendLayout();
            panelBottomActions.SuspendLayout();
            SuspendLayout();
            // 
            // lblScreen
            // 
            lblScreen.BackColor = Color.LightGray;
            lblScreen.Dock = DockStyle.Top;
            lblScreen.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblScreen.ForeColor = Color.DarkSlateGray;
            lblScreen.Location = new Point(0, 154);
            lblScreen.Margin = new Padding(4, 0, 4, 0);
            lblScreen.Name = "lblScreen";
            lblScreen.Size = new Size(800, 46);
            lblScreen.TabIndex = 1;
            lblScreen.Text = "M À N   H Ì N H";
            lblScreen.TextAlign = ContentAlignment.MiddleCenter;
            lblScreen.Click += lblScreen_Click;
            // 
            // panelTopInfo
            // 
            panelTopInfo.Controls.Add(btnBack);
            panelTopInfo.Controls.Add(lblShowtimeInfo);
            panelTopInfo.Controls.Add(flowLegend);
            panelTopInfo.Dock = DockStyle.Top;
            panelTopInfo.Location = new Point(0, 0);
            panelTopInfo.Margin = new Padding(4, 5, 4, 5);
            panelTopInfo.Name = "panelTopInfo";
            panelTopInfo.Padding = new Padding(13, 15, 13, 15);
            panelTopInfo.Size = new Size(800, 154);
            panelTopInfo.TabIndex = 4;
            // 
            // btnBack
            // 
            btnBack.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnBack.Font = new Font("Segoe UI", 9F);
            btnBack.Location = new Point(581, 5);
            btnBack.Margin = new Padding(4, 5, 4, 5);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(133, 46);
            btnBack.TabIndex = 2;
            btnBack.Text = "<< Quay Lại";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // lblShowtimeInfo
            // 
            lblShowtimeInfo.AutoSize = true;
            lblShowtimeInfo.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblShowtimeInfo.Location = new Point(13, 8);
            lblShowtimeInfo.Margin = new Padding(4, 0, 4, 0);
            lblShowtimeInfo.Name = "lblShowtimeInfo";
            lblShowtimeInfo.Size = new Size(270, 23);
            lblShowtimeInfo.TabIndex = 0;
            lblShowtimeInfo.Text = "Phim: ... Suất chiếu: ... Phòng: ...";
            // 
            // flowLegend
            // 
            flowLegend.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            flowLegend.Location = new Point(0, 54);
            flowLegend.Margin = new Padding(4, 5, 4, 5);
            flowLegend.Name = "flowLegend";
            flowLegend.Size = new Size(800, 85);
            flowLegend.TabIndex = 1;
            // 
            // panelSeatLayout
            // 
            panelSeatLayout.AutoScroll = true;
            panelSeatLayout.BackColor = Color.FromArgb(240, 240, 240);
            panelSeatLayout.BorderStyle = BorderStyle.Fixed3D;
            panelSeatLayout.Dock = DockStyle.Fill;
            panelSeatLayout.Location = new Point(0, 200);
            panelSeatLayout.Margin = new Padding(4, 5, 4, 5);
            panelSeatLayout.Name = "panelSeatLayout";
            panelSeatLayout.Size = new Size(800, 377);
            panelSeatLayout.TabIndex = 2;
            // 
            // panelBottomActions
            // 
            panelBottomActions.Controls.Add(lblSelectedSeatTypesInfo);
            panelBottomActions.Controls.Add(btnNext);
            panelBottomActions.Controls.Add(lblTotalPriceSummary);
            panelBottomActions.Controls.Add(lblSelectedSeatsSummary);
            panelBottomActions.Dock = DockStyle.Bottom;
            panelBottomActions.Location = new Point(0, 577);
            panelBottomActions.Margin = new Padding(4, 5, 4, 5);
            panelBottomActions.Name = "panelBottomActions";
            panelBottomActions.Padding = new Padding(13, 15, 13, 15);
            panelBottomActions.Size = new Size(800, 123);
            panelBottomActions.TabIndex = 3;
            // 
            // lblSelectedSeatTypesInfo
            // 
            lblSelectedSeatTypesInfo.AutoSize = true;
            lblSelectedSeatTypesInfo.Font = new Font("Segoe UI", 9F);
            lblSelectedSeatTypesInfo.Location = new Point(13, 44);
            lblSelectedSeatTypesInfo.Margin = new Padding(4, 0, 4, 0);
            lblSelectedSeatTypesInfo.Name = "lblSelectedSeatTypesInfo";
            lblSelectedSeatTypesInfo.Size = new Size(69, 20);
            lblSelectedSeatTypesInfo.TabIndex = 6;
            lblSelectedSeatTypesInfo.Text = "Loại ghế:";
            // 
            // btnNext
            // 
            btnNext.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnNext.Enabled = false;
            btnNext.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnNext.Location = new Point(581, 51);
            btnNext.Margin = new Padding(4, 5, 4, 5);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(133, 46);
            btnNext.TabIndex = 3;
            btnNext.Text = "Tiếp Tục >>";
            btnNext.UseVisualStyleBackColor = true;
            btnNext.Click += btnNext_Click;
            // 
            // lblTotalPriceSummary
            // 
            lblTotalPriceSummary.AutoSize = true;
            lblTotalPriceSummary.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTotalPriceSummary.Location = new Point(13, 74);
            lblTotalPriceSummary.Margin = new Padding(4, 0, 4, 0);
            lblTotalPriceSummary.Name = "lblTotalPriceSummary";
            lblTotalPriceSummary.Size = new Size(149, 23);
            lblTotalPriceSummary.TabIndex = 4;
            lblTotalPriceSummary.Text = "Tổng tiền: 0 VNĐ";
            // 
            // lblSelectedSeatsSummary
            // 
            lblSelectedSeatsSummary.AutoSize = true;
            lblSelectedSeatsSummary.Font = new Font("Segoe UI", 9F);
            lblSelectedSeatsSummary.Location = new Point(13, 15);
            lblSelectedSeatsSummary.Margin = new Padding(4, 0, 4, 0);
            lblSelectedSeatsSummary.Name = "lblSelectedSeatsSummary";
            lblSelectedSeatsSummary.Size = new Size(95, 20);
            lblSelectedSeatsSummary.TabIndex = 5;
            lblSelectedSeatsSummary.Text = "Ghế đã chọn:";
            // 
            // MovieRoomLayoutBookingControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panelSeatLayout);
            Controls.Add(lblScreen);
            Controls.Add(panelBottomActions);
            Controls.Add(panelTopInfo);
            Margin = new Padding(4, 5, 4, 5);
            Name = "MovieRoomLayoutBookingControl";
            Size = new Size(800, 700);
            panelTopInfo.ResumeLayout(false);
            panelTopInfo.PerformLayout();
            panelBottomActions.ResumeLayout(false);
            panelBottomActions.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label lblSelectedSeatTypesInfo;
    }
}
