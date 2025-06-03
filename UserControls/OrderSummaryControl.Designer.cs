namespace CinemaApplication.UserControls
{
    partial class OrderSummaryControl
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
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelMainContentArea;
        private System.Windows.Forms.Label lblMovieInfo;
        private System.Windows.Forms.Label lblShowtimeInfoSummary;
        private System.Windows.Forms.GroupBox grpSeatSummary;
        private System.Windows.Forms.RichTextBox rtbSeatDetails;
        private System.Windows.Forms.Label lblSeatSubtotal;
        private System.Windows.Forms.GroupBox grpFoodSummary;
        private System.Windows.Forms.RichTextBox rtbFoodDetails;
        private System.Windows.Forms.Label lblFoodSubtotal;
        private System.Windows.Forms.Label lblOverallTotalText;
        private System.Windows.Forms.Label lblOverallTotalValue;
        private System.Windows.Forms.Panel panelBottomActions;
        private System.Windows.Forms.Button btnConfirmAndPay;
        private System.Windows.Forms.Button btnBackToFood;
        private System.Windows.Forms.Button btnCancelOrder;
        private void InitializeComponent()
        {
            lblTitle = new Label();
            panelMainContentArea = new Panel();
            lblOverallTotalValue = new Label();
            lblOverallTotalText = new Label();
            grpFoodSummary = new GroupBox();
            rtbFoodDetails = new RichTextBox();
            lblFoodSubtotal = new Label();
            grpSeatSummary = new GroupBox();
            rtbSeatDetails = new RichTextBox();
            lblSeatSubtotal = new Label();
            lblShowtimeInfoSummary = new Label();
            lblMovieInfo = new Label();
            panelBottomActions = new Panel();
            btnConfirmAndPay = new Button();
            btnBackToFood = new Button();
            btnCancelOrder = new Button();
            panelMainContentArea.SuspendLayout();
            grpFoodSummary.SuspendLayout();
            grpSeatSummary.SuspendLayout();
            panelBottomActions.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.Dock = DockStyle.Top;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.Location = new Point(0, 0);
            lblTitle.Margin = new Padding(4, 0, 4, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Padding = new Padding(0, 15, 0, 15);
            lblTitle.Size = new Size(900, 72);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "TÓM TẮT ĐƠN HÀNG";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelMainContentArea
            // 
            panelMainContentArea.AutoScroll = true;
            panelMainContentArea.Controls.Add(lblOverallTotalValue);
            panelMainContentArea.Controls.Add(lblOverallTotalText);
            panelMainContentArea.Controls.Add(grpFoodSummary);
            panelMainContentArea.Controls.Add(grpSeatSummary);
            panelMainContentArea.Controls.Add(lblShowtimeInfoSummary);
            panelMainContentArea.Controls.Add(lblMovieInfo);
            panelMainContentArea.Dock = DockStyle.Fill;
            panelMainContentArea.Location = new Point(0, 72);
            panelMainContentArea.Margin = new Padding(4, 5, 4, 5);
            panelMainContentArea.Name = "panelMainContentArea";
            panelMainContentArea.Padding = new Padding(20, 15, 20, 15);
            panelMainContentArea.Size = new Size(900, 686);
            panelMainContentArea.TabIndex = 1;
            // 
            // lblOverallTotalValue
            // 
            lblOverallTotalValue.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblOverallTotalValue.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblOverallTotalValue.ForeColor = Color.FromArgb(192, 0, 0);
            lblOverallTotalValue.Location = new Point(556, 597);
            lblOverallTotalValue.Margin = new Padding(4, 0, 4, 0);
            lblOverallTotalValue.Name = "lblOverallTotalValue";
            lblOverallTotalValue.Size = new Size(267, 38);
            lblOverallTotalValue.TabIndex = 5;
            lblOverallTotalValue.Text = "0 VNĐ";
            lblOverallTotalValue.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblOverallTotalText
            // 
            lblOverallTotalText.AutoSize = true;
            lblOverallTotalText.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblOverallTotalText.Location = new Point(24, 600);
            lblOverallTotalText.Margin = new Padding(4, 0, 4, 0);
            lblOverallTotalText.Name = "lblOverallTotalText";
            lblOverallTotalText.Size = new Size(137, 28);
            lblOverallTotalText.TabIndex = 4;
            lblOverallTotalText.Text = "TỔNG CỘNG:";
            // 
            // grpFoodSummary
            // 
            grpFoodSummary.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpFoodSummary.Controls.Add(rtbFoodDetails);
            grpFoodSummary.Controls.Add(lblFoodSubtotal);
            grpFoodSummary.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            grpFoodSummary.Location = new Point(24, 346);
            grpFoodSummary.Margin = new Padding(4, 5, 4, 5);
            grpFoodSummary.Name = "grpFoodSummary";
            grpFoodSummary.Padding = new Padding(11, 12, 11, 12);
            grpFoodSummary.Size = new Size(825, 231);
            grpFoodSummary.TabIndex = 3;
            grpFoodSummary.TabStop = false;
            grpFoodSummary.Text = "Thông Tin Đồ Ăn/Thức Uống";
            // 
            // rtbFoodDetails
            // 
            rtbFoodDetails.BackColor = SystemColors.Window;
            rtbFoodDetails.BorderStyle = BorderStyle.None;
            rtbFoodDetails.Dock = DockStyle.Fill;
            rtbFoodDetails.Font = new Font("Segoe UI", 9F);
            rtbFoodDetails.Location = new Point(11, 34);
            rtbFoodDetails.Margin = new Padding(4, 5, 4, 5);
            rtbFoodDetails.Name = "rtbFoodDetails";
            rtbFoodDetails.ReadOnly = true;
            rtbFoodDetails.Size = new Size(803, 154);
            rtbFoodDetails.TabIndex = 0;
            rtbFoodDetails.Text = "";
            // 
            // lblFoodSubtotal
            // 
            lblFoodSubtotal.Dock = DockStyle.Bottom;
            lblFoodSubtotal.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            lblFoodSubtotal.ForeColor = Color.Firebrick;
            lblFoodSubtotal.Location = new Point(11, 188);
            lblFoodSubtotal.Margin = new Padding(4, 0, 4, 0);
            lblFoodSubtotal.Name = "lblFoodSubtotal";
            lblFoodSubtotal.Padding = new Padding(0, 8, 0, 0);
            lblFoodSubtotal.Size = new Size(803, 31);
            lblFoodSubtotal.TabIndex = 1;
            lblFoodSubtotal.Text = "Tổng tiền đồ ăn: 0 VNĐ";
            lblFoodSubtotal.TextAlign = ContentAlignment.MiddleRight;
            // 
            // grpSeatSummary
            // 
            grpSeatSummary.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpSeatSummary.Controls.Add(rtbSeatDetails);
            grpSeatSummary.Controls.Add(lblSeatSubtotal);
            grpSeatSummary.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            grpSeatSummary.Location = new Point(24, 100);
            grpSeatSummary.Margin = new Padding(4, 5, 4, 5);
            grpSeatSummary.Name = "grpSeatSummary";
            grpSeatSummary.Padding = new Padding(11, 12, 11, 12);
            grpSeatSummary.Size = new Size(825, 231);
            grpSeatSummary.TabIndex = 2;
            grpSeatSummary.TabStop = false;
            grpSeatSummary.Text = "Thông Tin Vé Đã Chọn";
            // 
            // rtbSeatDetails
            // 
            rtbSeatDetails.BackColor = SystemColors.Window;
            rtbSeatDetails.BorderStyle = BorderStyle.None;
            rtbSeatDetails.Dock = DockStyle.Fill;
            rtbSeatDetails.Font = new Font("Segoe UI", 9F);
            rtbSeatDetails.Location = new Point(11, 34);
            rtbSeatDetails.Margin = new Padding(4, 5, 4, 5);
            rtbSeatDetails.Name = "rtbSeatDetails";
            rtbSeatDetails.ReadOnly = true;
            rtbSeatDetails.Size = new Size(803, 154);
            rtbSeatDetails.TabIndex = 0;
            rtbSeatDetails.Text = "";
            // 
            // lblSeatSubtotal
            // 
            lblSeatSubtotal.Dock = DockStyle.Bottom;
            lblSeatSubtotal.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            lblSeatSubtotal.ForeColor = Color.Firebrick;
            lblSeatSubtotal.Location = new Point(11, 188);
            lblSeatSubtotal.Margin = new Padding(4, 0, 4, 0);
            lblSeatSubtotal.Name = "lblSeatSubtotal";
            lblSeatSubtotal.Padding = new Padding(0, 8, 0, 0);
            lblSeatSubtotal.Size = new Size(803, 31);
            lblSeatSubtotal.TabIndex = 1;
            lblSeatSubtotal.Text = "Tổng tiền ghế: 0 VNĐ";
            lblSeatSubtotal.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblShowtimeInfoSummary
            // 
            lblShowtimeInfoSummary.AutoSize = true;
            lblShowtimeInfoSummary.Font = new Font("Segoe UI", 10F);
            lblShowtimeInfoSummary.Location = new Point(24, 54);
            lblShowtimeInfoSummary.Margin = new Padding(4, 0, 4, 0);
            lblShowtimeInfoSummary.Name = "lblShowtimeInfoSummary";
            lblShowtimeInfoSummary.Size = new Size(111, 23);
            lblShowtimeInfoSummary.TabIndex = 1;
            lblShowtimeInfoSummary.Text = "Suất chiếu: ...";
            // 
            // lblMovieInfo
            // 
            lblMovieInfo.AutoSize = true;
            lblMovieInfo.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblMovieInfo.Location = new Point(24, 15);
            lblMovieInfo.Margin = new Padding(4, 0, 4, 0);
            lblMovieInfo.Name = "lblMovieInfo";
            lblMovieInfo.Size = new Size(82, 25);
            lblMovieInfo.TabIndex = 0;
            lblMovieInfo.Text = "Phim: ...";
            // 
            // panelBottomActions
            // 
            panelBottomActions.Controls.Add(btnConfirmAndPay);
            panelBottomActions.Controls.Add(btnBackToFood);
            panelBottomActions.Controls.Add(btnCancelOrder);
            panelBottomActions.Dock = DockStyle.Bottom;
            panelBottomActions.Location = new Point(0, 758);
            panelBottomActions.Margin = new Padding(4, 5, 4, 5);
            panelBottomActions.Name = "panelBottomActions";
            panelBottomActions.Padding = new Padding(13, 15, 13, 15);
            panelBottomActions.Size = new Size(900, 92);
            panelBottomActions.TabIndex = 2;
            // 
            // btnConfirmAndPay
            // 
            btnConfirmAndPay.Anchor = AnchorStyles.Right;
            btnConfirmAndPay.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnConfirmAndPay.Location = new Point(649, 20);
            btnConfirmAndPay.Margin = new Padding(4, 5, 4, 5);
            btnConfirmAndPay.Name = "btnConfirmAndPay";
            btnConfirmAndPay.Size = new Size(200, 46);
            btnConfirmAndPay.TabIndex = 2;
            btnConfirmAndPay.Text = "Xác Nhận & Thanh Toán";
            btnConfirmAndPay.UseVisualStyleBackColor = true;
            btnConfirmAndPay.Click += btnConfirmAndPay_Click;
            // 
            // btnBackToFood
            // 
            btnBackToFood.Anchor = AnchorStyles.None;
            btnBackToFood.Font = new Font("Segoe UI", 9F);
            btnBackToFood.Location = new Point(24, 20);
            btnBackToFood.Margin = new Padding(4, 5, 4, 5);
            btnBackToFood.Name = "btnBackToFood";
            btnBackToFood.Size = new Size(137, 46);
            btnBackToFood.TabIndex = 1;
            btnBackToFood.Text = "<< Chọn Đồ Ăn";
            btnBackToFood.UseVisualStyleBackColor = true;
            btnBackToFood.Click += btnBackToFood_Click;
            // 
            // btnCancelOrder
            // 
            btnCancelOrder.Anchor = AnchorStyles.Left;
            btnCancelOrder.Font = new Font("Segoe UI", 9F);
            btnCancelOrder.Location = new Point(529, 21);
            btnCancelOrder.Margin = new Padding(4, 5, 4, 5);
            btnCancelOrder.Name = "btnCancelOrder";
            btnCancelOrder.Size = new Size(112, 46);
            btnCancelOrder.TabIndex = 0;
            btnCancelOrder.Text = "Hủy Đơn";
            btnCancelOrder.UseVisualStyleBackColor = true;
            btnCancelOrder.Click += btnCancelOrder_Click;
            // 
            // OrderSummaryControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panelMainContentArea);
            Controls.Add(panelBottomActions);
            Controls.Add(lblTitle);
            Margin = new Padding(4, 5, 4, 5);
            Name = "OrderSummaryControl";
            Size = new Size(900, 850);
            Load += OrderSummaryControl_Load;
            panelMainContentArea.ResumeLayout(false);
            panelMainContentArea.PerformLayout();
            grpFoodSummary.ResumeLayout(false);
            grpSeatSummary.ResumeLayout(false);
            panelBottomActions.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
    }
}
