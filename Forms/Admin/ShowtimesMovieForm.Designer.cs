namespace CinemaApplication.Forms.Admin
{
    partial class ShowtimesMovieForm
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
        private Label lblSelectDateText;
        private DateTimePicker dtpSelectDate;
        private FlowLayoutPanel flowLayoutPanelShowtimes;
        private Panel panelTopControls;
        private Button btnRefreshShowtimes;
        private void InitializeComponent()
        {
            lblSelectDateText = new Label();
            dtpSelectDate = new DateTimePicker();
            flowLayoutPanelShowtimes = new FlowLayoutPanel();
            btnRefreshShowtimes = new Button();
            panelTopControls = new Panel();
            panelTopControls.SuspendLayout();
            SuspendLayout();
            // 
            // lblSelectDateText
            // 
            lblSelectDateText.AutoSize = true;
            lblSelectDateText.Location = new Point(16, 18);
            lblSelectDateText.Margin = new Padding(4, 0, 4, 0);
            lblSelectDateText.Name = "lblSelectDateText";
            lblSelectDateText.Size = new Size(114, 20);
            lblSelectDateText.TabIndex = 0;
            lblSelectDateText.Text = "Chọn ngày xem:";
            // 
            // dtpSelectDate
            // 
            dtpSelectDate.Format = DateTimePickerFormat.Short;
            dtpSelectDate.Location = new Point(133, 14);
            dtpSelectDate.Margin = new Padding(4, 5, 4, 5);
            dtpSelectDate.Name = "dtpSelectDate";
            dtpSelectDate.Size = new Size(159, 27);
            dtpSelectDate.TabIndex = 1;
            dtpSelectDate.ValueChanged += DtpSelectDate_ValueChanged;
            // 
            // flowLayoutPanelShowtimes
            // 
            flowLayoutPanelShowtimes.AutoScroll = true;
            flowLayoutPanelShowtimes.BackColor = SystemColors.ControlLight;
            flowLayoutPanelShowtimes.Dock = DockStyle.Fill;
            flowLayoutPanelShowtimes.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanelShowtimes.Location = new Point(0, 62);
            flowLayoutPanelShowtimes.Margin = new Padding(4, 5, 4, 5);
            flowLayoutPanelShowtimes.Name = "flowLayoutPanelShowtimes";
            flowLayoutPanelShowtimes.Padding = new Padding(13, 15, 13, 15);
            flowLayoutPanelShowtimes.Size = new Size(1067, 861);
            flowLayoutPanelShowtimes.TabIndex = 1;
            flowLayoutPanelShowtimes.WrapContents = false;
            // 
            // btnRefreshShowtimes
            // 
            btnRefreshShowtimes.Location = new Point(307, 12);
            btnRefreshShowtimes.Margin = new Padding(4, 5, 4, 5);
            btnRefreshShowtimes.Name = "btnRefreshShowtimes";
            btnRefreshShowtimes.Size = new Size(120, 35);
            btnRefreshShowtimes.TabIndex = 2;
            btnRefreshShowtimes.Text = "Xem Lịch";
            btnRefreshShowtimes.UseVisualStyleBackColor = true;
            btnRefreshShowtimes.Click += BtnRefreshShowtimes_Click;
            // 
            // panelTopControls
            // 
            panelTopControls.Controls.Add(lblSelectDateText);
            panelTopControls.Controls.Add(dtpSelectDate);
            panelTopControls.Controls.Add(btnRefreshShowtimes);
            panelTopControls.Dock = DockStyle.Top;
            panelTopControls.Location = new Point(0, 0);
            panelTopControls.Margin = new Padding(4, 5, 4, 5);
            panelTopControls.Name = "panelTopControls";
            panelTopControls.Size = new Size(1067, 62);
            panelTopControls.TabIndex = 0;
            // 
            // ShowtimesMovieForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1067, 923);
            Controls.Add(flowLayoutPanelShowtimes);
            Controls.Add(panelTopControls);
            Margin = new Padding(4, 5, 4, 5);
            Name = "ShowtimesMovieForm";
            Text = "Lịch Chiếu Phim";
            Load += ShowtimesMovieForm_Load;
            panelTopControls.ResumeLayout(false);
            panelTopControls.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
    }
}