namespace CinemaApplication.UserControls
{
    partial class OrderedTicketInfoControl
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
        private System.Windows.Forms.Label lblConfirmationTitle;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.Label lblOrderId_Text;
        private System.Windows.Forms.Label lblOrderId_Value;
        private System.Windows.Forms.Label lblMovieTitle_Text;
        private System.Windows.Forms.Label lblMovieTitle_Value;
        private System.Windows.Forms.Label lblShowtime_Text;
        private System.Windows.Forms.Label lblShowtime_Value;
        private System.Windows.Forms.Label lblRoom_Text;
        private System.Windows.Forms.Label lblRoom_Value;
        private System.Windows.Forms.Label lblSeatsHeader;
        private System.Windows.Forms.RichTextBox rtbSeatCodes;
        private System.Windows.Forms.Label lblTicketsHeader;
        private System.Windows.Forms.RichTextBox rtbTicketCodes;
        private System.Windows.Forms.Label lblFoodHeader;
        private System.Windows.Forms.RichTextBox rtbFoodSummary;
        private System.Windows.Forms.Label lblTotalPaid_Text;
        private System.Windows.Forms.Label lblTotalPaid_Value;
        private System.Windows.Forms.Label lblOrderTime_Text;
        private System.Windows.Forms.Label lblOrderTime_Value;
        private System.Windows.Forms.Button btnReturnToSystem;
        private void InitializeComponent()
        {
            lblConfirmationTitle = new Label();
            panelContent = new Panel();
            btnReturnToSystem = new Button();
            lblOrderTime_Value = new Label();
            lblOrderTime_Text = new Label();
            lblTotalPaid_Value = new Label();
            lblTotalPaid_Text = new Label();
            rtbFoodSummary = new RichTextBox();
            lblFoodHeader = new Label();
            rtbTicketCodes = new RichTextBox();
            lblTicketsHeader = new Label();
            rtbSeatCodes = new RichTextBox();
            lblSeatsHeader = new Label();
            lblRoom_Value = new Label();
            lblRoom_Text = new Label();
            lblShowtime_Value = new Label();
            lblShowtime_Text = new Label();
            lblMovieTitle_Value = new Label();
            lblMovieTitle_Text = new Label();
            lblOrderId_Value = new Label();
            lblOrderId_Text = new Label();
            panelContent.SuspendLayout();
            SuspendLayout();
            // 
            // lblConfirmationTitle
            // 
            lblConfirmationTitle.Dock = DockStyle.Top;
            lblConfirmationTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblConfirmationTitle.ForeColor = Color.Green;
            lblConfirmationTitle.Location = new Point(0, 0);
            lblConfirmationTitle.Margin = new Padding(4, 0, 4, 0);
            lblConfirmationTitle.Name = "lblConfirmationTitle";
            lblConfirmationTitle.Padding = new Padding(0, 15, 0, 23);
            lblConfirmationTitle.Size = new Size(800, 80);
            lblConfirmationTitle.TabIndex = 0;
            lblConfirmationTitle.Text = "ĐẶT VÉ THÀNH CÔNG!";
            lblConfirmationTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelContent
            // 
            panelContent.AutoScroll = true;
            panelContent.Controls.Add(btnReturnToSystem);
            panelContent.Controls.Add(lblOrderTime_Value);
            panelContent.Controls.Add(lblOrderTime_Text);
            panelContent.Controls.Add(lblTotalPaid_Value);
            panelContent.Controls.Add(lblTotalPaid_Text);
            panelContent.Controls.Add(rtbFoodSummary);
            panelContent.Controls.Add(lblFoodHeader);
            panelContent.Controls.Add(rtbTicketCodes);
            panelContent.Controls.Add(lblTicketsHeader);
            panelContent.Controls.Add(rtbSeatCodes);
            panelContent.Controls.Add(lblSeatsHeader);
            panelContent.Controls.Add(lblRoom_Value);
            panelContent.Controls.Add(lblRoom_Text);
            panelContent.Controls.Add(lblShowtime_Value);
            panelContent.Controls.Add(lblShowtime_Text);
            panelContent.Controls.Add(lblMovieTitle_Value);
            panelContent.Controls.Add(lblMovieTitle_Text);
            panelContent.Controls.Add(lblOrderId_Value);
            panelContent.Controls.Add(lblOrderId_Text);
            panelContent.Dock = DockStyle.Fill;
            panelContent.Location = new Point(0, 80);
            panelContent.Margin = new Padding(4, 5, 4, 5);
            panelContent.Name = "panelContent";
            panelContent.Padding = new Padding(27, 31, 27, 31);
            panelContent.Size = new Size(800, 870);
            panelContent.TabIndex = 1;
            // 
            // btnReturnToSystem
            // 
            btnReturnToSystem.Anchor = AnchorStyles.Top;
            btnReturnToSystem.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnReturnToSystem.Location = new Point(269, 800);
            btnReturnToSystem.Margin = new Padding(4, 5, 4, 5);
            btnReturnToSystem.Name = "btnReturnToSystem";
            btnReturnToSystem.Size = new Size(240, 54);
            btnReturnToSystem.TabIndex = 20;
            btnReturnToSystem.Text = "Quay Về Trang Chủ";
            btnReturnToSystem.UseVisualStyleBackColor = true;
            btnReturnToSystem.Click += btnReturnToSystem_Click;
            // 
            // lblOrderTime_Value
            // 
            lblOrderTime_Value.AutoSize = true;
            lblOrderTime_Value.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            lblOrderTime_Value.Location = new Point(233, 748);
            lblOrderTime_Value.Margin = new Padding(4, 0, 4, 0);
            lblOrderTime_Value.Name = "lblOrderTime_Value";
            lblOrderTime_Value.Size = new Size(25, 23);
            lblOrderTime_Value.TabIndex = 21;
            lblOrderTime_Value.Text = "...";
            // 
            // lblOrderTime_Text
            // 
            lblOrderTime_Text.AutoSize = true;
            lblOrderTime_Text.Font = new Font("Segoe UI", 9.75F);
            lblOrderTime_Text.Location = new Point(33, 748);
            lblOrderTime_Text.Margin = new Padding(4, 0, 4, 0);
            lblOrderTime_Text.Name = "lblOrderTime_Text";
            lblOrderTime_Text.Size = new Size(119, 23);
            lblOrderTime_Text.TabIndex = 22;
            lblOrderTime_Text.Text = "Thời Gian Đặt:";
            // 
            // lblTotalPaid_Value
            // 
            lblTotalPaid_Value.AutoSize = true;
            lblTotalPaid_Value.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblTotalPaid_Value.ForeColor = Color.DarkRed;
            lblTotalPaid_Value.Location = new Point(231, 712);
            lblTotalPaid_Value.Margin = new Padding(4, 0, 4, 0);
            lblTotalPaid_Value.Name = "lblTotalPaid_Value";
            lblTotalPaid_Value.Size = new Size(27, 25);
            lblTotalPaid_Value.TabIndex = 23;
            lblTotalPaid_Value.Text = "...";
            // 
            // lblTotalPaid_Text
            // 
            lblTotalPaid_Text.AutoSize = true;
            lblTotalPaid_Text.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblTotalPaid_Text.Location = new Point(31, 712);
            lblTotalPaid_Text.Margin = new Padding(4, 0, 4, 0);
            lblTotalPaid_Text.Name = "lblTotalPaid_Text";
            lblTotalPaid_Text.Size = new Size(172, 25);
            lblTotalPaid_Text.TabIndex = 24;
            lblTotalPaid_Text.Text = "Tổng Thanh Toán:";
            // 
            // rtbFoodSummary
            // 
            rtbFoodSummary.BorderStyle = BorderStyle.FixedSingle;
            rtbFoodSummary.Font = new Font("Segoe UI", 9F);
            rtbFoodSummary.Location = new Point(31, 566);
            rtbFoodSummary.Margin = new Padding(4, 5, 4, 5);
            rtbFoodSummary.Name = "rtbFoodSummary";
            rtbFoodSummary.ReadOnly = true;
            rtbFoodSummary.ScrollBars = RichTextBoxScrollBars.Vertical;
            rtbFoodSummary.Size = new Size(692, 121);
            rtbFoodSummary.TabIndex = 12;
            rtbFoodSummary.Text = "";
            // 
            // lblFoodHeader
            // 
            lblFoodHeader.AutoSize = true;
            lblFoodHeader.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblFoodHeader.Location = new Point(31, 528);
            lblFoodHeader.Margin = new Padding(4, 0, 4, 0);
            lblFoodHeader.Name = "lblFoodHeader";
            lblFoodHeader.Size = new Size(221, 23);
            lblFoodHeader.TabIndex = 25;
            lblFoodHeader.Text = "Đồ Ăn/Thức Uống Đã Đặt:";
            // 
            // rtbTicketCodes
            // 
            rtbTicketCodes.BorderStyle = BorderStyle.FixedSingle;
            rtbTicketCodes.Font = new Font("Segoe UI", 9F);
            rtbTicketCodes.Location = new Point(31, 420);
            rtbTicketCodes.Margin = new Padding(4, 5, 4, 5);
            rtbTicketCodes.Name = "rtbTicketCodes";
            rtbTicketCodes.ReadOnly = true;
            rtbTicketCodes.ScrollBars = RichTextBoxScrollBars.Vertical;
            rtbTicketCodes.Size = new Size(692, 90);
            rtbTicketCodes.TabIndex = 11;
            rtbTicketCodes.Text = "";
            // 
            // lblTicketsHeader
            // 
            lblTicketsHeader.AutoSize = true;
            lblTicketsHeader.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTicketsHeader.Location = new Point(31, 382);
            lblTicketsHeader.Margin = new Padding(4, 0, 4, 0);
            lblTicketsHeader.Name = "lblTicketsHeader";
            lblTicketsHeader.Size = new Size(132, 23);
            lblTicketsHeader.TabIndex = 26;
            lblTicketsHeader.Text = "Mã Vé Điện Tử:";
            // 
            // rtbSeatCodes
            // 
            rtbSeatCodes.BorderStyle = BorderStyle.FixedSingle;
            rtbSeatCodes.Font = new Font("Segoe UI", 9F);
            rtbSeatCodes.Location = new Point(31, 274);
            rtbSeatCodes.Margin = new Padding(4, 5, 4, 5);
            rtbSeatCodes.Name = "rtbSeatCodes";
            rtbSeatCodes.ReadOnly = true;
            rtbSeatCodes.ScrollBars = RichTextBoxScrollBars.Vertical;
            rtbSeatCodes.Size = new Size(692, 90);
            rtbSeatCodes.TabIndex = 10;
            rtbSeatCodes.Text = "";
            // 
            // lblSeatsHeader
            // 
            lblSeatsHeader.AutoSize = true;
            lblSeatsHeader.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblSeatsHeader.Location = new Point(31, 235);
            lblSeatsHeader.Margin = new Padding(4, 0, 4, 0);
            lblSeatsHeader.Name = "lblSeatsHeader";
            lblSeatsHeader.Size = new Size(119, 23);
            lblSeatsHeader.TabIndex = 27;
            lblSeatsHeader.Text = "Ghế Đã Chọn:";
            // 
            // lblRoom_Value
            // 
            lblRoom_Value.AutoSize = true;
            lblRoom_Value.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            lblRoom_Value.Location = new Point(204, 174);
            lblRoom_Value.Margin = new Padding(4, 0, 4, 0);
            lblRoom_Value.Name = "lblRoom_Value";
            lblRoom_Value.Size = new Size(25, 23);
            lblRoom_Value.TabIndex = 28;
            lblRoom_Value.Text = "...";
            // 
            // lblRoom_Text
            // 
            lblRoom_Text.AutoSize = true;
            lblRoom_Text.Font = new Font("Segoe UI", 9.75F);
            lblRoom_Text.Location = new Point(31, 174);
            lblRoom_Text.Margin = new Padding(4, 0, 4, 0);
            lblRoom_Text.Name = "lblRoom_Text";
            lblRoom_Text.Size = new Size(113, 23);
            lblRoom_Text.TabIndex = 29;
            lblRoom_Text.Text = "Phòng Chiếu:";
            // 
            // lblShowtime_Value
            // 
            lblShowtime_Value.AutoSize = true;
            lblShowtime_Value.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            lblShowtime_Value.Location = new Point(204, 128);
            lblShowtime_Value.Margin = new Padding(4, 0, 4, 0);
            lblShowtime_Value.Name = "lblShowtime_Value";
            lblShowtime_Value.Size = new Size(25, 23);
            lblShowtime_Value.TabIndex = 30;
            lblShowtime_Value.Text = "...";
            // 
            // lblShowtime_Text
            // 
            lblShowtime_Text.AutoSize = true;
            lblShowtime_Text.Font = new Font("Segoe UI", 9.75F);
            lblShowtime_Text.Location = new Point(31, 128);
            lblShowtime_Text.Margin = new Padding(4, 0, 4, 0);
            lblShowtime_Text.Name = "lblShowtime_Text";
            lblShowtime_Text.Size = new Size(97, 23);
            lblShowtime_Text.TabIndex = 31;
            lblShowtime_Text.Text = "Suất Chiếu:";
            // 
            // lblMovieTitle_Value
            // 
            lblMovieTitle_Value.AutoSize = true;
            lblMovieTitle_Value.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            lblMovieTitle_Value.Location = new Point(204, 82);
            lblMovieTitle_Value.Margin = new Padding(4, 0, 4, 0);
            lblMovieTitle_Value.MaximumSize = new Size(533, 0);
            lblMovieTitle_Value.Name = "lblMovieTitle_Value";
            lblMovieTitle_Value.Size = new Size(25, 23);
            lblMovieTitle_Value.TabIndex = 32;
            lblMovieTitle_Value.Text = "...";
            // 
            // lblMovieTitle_Text
            // 
            lblMovieTitle_Text.AutoSize = true;
            lblMovieTitle_Text.Font = new Font("Segoe UI", 9.75F);
            lblMovieTitle_Text.Location = new Point(31, 82);
            lblMovieTitle_Text.Margin = new Padding(4, 0, 4, 0);
            lblMovieTitle_Text.Name = "lblMovieTitle_Text";
            lblMovieTitle_Text.Size = new Size(53, 23);
            lblMovieTitle_Text.TabIndex = 33;
            lblMovieTitle_Text.Text = "Phim:";
            // 
            // lblOrderId_Value
            // 
            lblOrderId_Value.AutoSize = true;
            lblOrderId_Value.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            lblOrderId_Value.Location = new Point(204, 35);
            lblOrderId_Value.Margin = new Padding(4, 0, 4, 0);
            lblOrderId_Value.Name = "lblOrderId_Value";
            lblOrderId_Value.Size = new Size(25, 23);
            lblOrderId_Value.TabIndex = 34;
            lblOrderId_Value.Text = "...";
            // 
            // lblOrderId_Text
            // 
            lblOrderId_Text.AutoSize = true;
            lblOrderId_Text.Font = new Font("Segoe UI", 9.75F);
            lblOrderId_Text.Location = new Point(31, 35);
            lblOrderId_Text.Margin = new Padding(4, 0, 4, 0);
            lblOrderId_Text.Name = "lblOrderId_Text";
            lblOrderId_Text.Size = new Size(121, 23);
            lblOrderId_Text.TabIndex = 35;
            lblOrderId_Text.Text = "Mã Đơn Hàng:";
            // 
            // OrderedTicketInfoControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panelContent);
            Controls.Add(lblConfirmationTitle);
            Margin = new Padding(4, 5, 4, 5);
            Name = "OrderedTicketInfoControl";
            Size = new Size(800, 950);
            panelContent.ResumeLayout(false);
            panelContent.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
    }
}
