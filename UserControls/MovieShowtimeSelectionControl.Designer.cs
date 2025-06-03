namespace CinemaApplication.UserControls
{
    partial class MovieShowtimeSelectionControl
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
        private Label lblTitlePrompt;
        private Label lblSelectedMovieTitle;
        private Label lblSelectDatePrompt;
        private DateTimePicker dtpSelectDateShowtime;
        private FlowLayoutPanel flowLayoutPanelShowtimes;
        private Button btnBackToDetails;
        private Panel panelTop;
        private void InitializeComponent()
        {
            this.lblTitlePrompt = new System.Windows.Forms.Label();
            this.lblSelectedMovieTitle = new System.Windows.Forms.Label();
            this.lblSelectDatePrompt = new System.Windows.Forms.Label();
            this.dtpSelectDateShowtime = new System.Windows.Forms.DateTimePicker();
            this.flowLayoutPanelShowtimes = new System.Windows.Forms.FlowLayoutPanel();
            this.btnBackToDetails = new System.Windows.Forms.Button();
            this.panelTop = new System.Windows.Forms.Panel();

            this.panelTop.SuspendLayout();
            this.SuspendLayout();

            // panelTop (chứa các control chọn ngày và tên phim)
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Height = 110; // Chiều cao ví dụ
            this.panelTop.Padding = new System.Windows.Forms.Padding(10);
            this.panelTop.Controls.Add(this.lblTitlePrompt);
            this.panelTop.Controls.Add(this.lblSelectedMovieTitle);
            this.panelTop.Controls.Add(this.lblSelectDatePrompt);
            this.panelTop.Controls.Add(this.dtpSelectDateShowtime);
            this.panelTop.Controls.Add(this.btnBackToDetails);


            // lblTitlePrompt
            this.lblTitlePrompt.AutoSize = true;
            this.lblTitlePrompt.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitlePrompt.Location = new System.Drawing.Point(10, 10);
            this.lblTitlePrompt.Name = "lblTitlePrompt";
            this.lblTitlePrompt.Text = "Bạn đang chọn suất chiếu cho phim:";

            // lblSelectedMovieTitle
            this.lblSelectedMovieTitle.AutoSize = true;
            this.lblSelectedMovieTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblSelectedMovieTitle.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblSelectedMovieTitle.Location = new System.Drawing.Point(10, 30);
            this.lblSelectedMovieTitle.Name = "lblSelectedMovieTitle";
            this.lblSelectedMovieTitle.Text = "Tên Phim...";

            // lblSelectDatePrompt
            this.lblSelectDatePrompt.AutoSize = true;
            this.lblSelectDatePrompt.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblSelectDatePrompt.Location = new System.Drawing.Point(10, 70);
            this.lblSelectDatePrompt.Name = "lblSelectDatePrompt";
            this.lblSelectDatePrompt.Text = "Chọn ngày xem:";

            // dtpSelectDateShowtime
            this.dtpSelectDateShowtime.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.dtpSelectDateShowtime.Location = new System.Drawing.Point(120, 67);
            this.dtpSelectDateShowtime.Name = "dtpSelectDateShowtime";
            this.dtpSelectDateShowtime.Size = new System.Drawing.Size(230, 25);
            this.dtpSelectDateShowtime.TabIndex = 1;

            // btnBackToDetails
            this.btnBackToDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBackToDetails.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnBackToDetails.Location = new System.Drawing.Point(this.panelTop.Width - 110, 10); // Căn phải trên panelTop
            this.btnBackToDetails.Name = "btnBackToDetails";
            this.btnBackToDetails.Size = new System.Drawing.Size(100, 28);
            this.btnBackToDetails.TabIndex = 0;
            this.btnBackToDetails.Text = "<< Chi Tiết Phim";
            this.btnBackToDetails.UseVisualStyleBackColor = true;

            // flowLayoutPanelShowtimes
            this.flowLayoutPanelShowtimes.BackColor = System.Drawing.SystemColors.Control;
            this.flowLayoutPanelShowtimes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelShowtimes.Location = new System.Drawing.Point(0, panelTop.Height); // Nằm dưới panelTop
            this.flowLayoutPanelShowtimes.Name = "flowLayoutPanelShowtimes";
            this.flowLayoutPanelShowtimes.Padding = new System.Windows.Forms.Padding(10);
            this.flowLayoutPanelShowtimes.AutoScroll = true;
            this.flowLayoutPanelShowtimes.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanelShowtimes.WrapContents = false;
            this.flowLayoutPanelShowtimes.TabIndex = 1;


            // MovieShowtimeSelectionControl
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanelShowtimes); // Thêm FlowLayoutPanel trước
            this.Controls.Add(this.panelTop);                // Rồi mới đến panel control ở trên
            this.Name = "MovieShowtimeSelectionControl";
            this.Size = new System.Drawing.Size(700, 500); // Kích thước UserControl ví dụ

            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion
    }
}
