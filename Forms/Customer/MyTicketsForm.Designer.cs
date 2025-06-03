namespace CinemaApplication.Forms.Customer
{
    partial class MyTicketsForm
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
        private Label lblTitle;
        private DataGridView dataGridViewMyTickets;
        private Button btnRefresh;
        private Label lblNoTicketsMessage;
        private Panel panelTop;
        private void InitializeComponent()
        {
            lblTitle = new Label();
            dataGridViewMyTickets = new DataGridView();
            btnRefresh = new Button();
            panelTop = new Panel();
            lblNoTicketsMessage = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridViewMyTickets).BeginInit();
            panelTop.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(16, 18);
            lblTitle.Margin = new Padding(4, 0, 4, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(217, 32);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Vé Đã Đặt Của Tôi";
            // 
            // dataGridViewMyTickets
            // 
            dataGridViewMyTickets.AllowUserToAddRows = false;
            dataGridViewMyTickets.AllowUserToDeleteRows = false;
            dataGridViewMyTickets.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewMyTickets.Dock = DockStyle.Fill;
            dataGridViewMyTickets.Location = new Point(0, 77);
            dataGridViewMyTickets.Margin = new Padding(4, 5, 4, 5);
            dataGridViewMyTickets.Name = "dataGridViewMyTickets";
            dataGridViewMyTickets.ReadOnly = true;
            dataGridViewMyTickets.RowHeadersVisible = false;
            dataGridViewMyTickets.RowHeadersWidth = 51;
            dataGridViewMyTickets.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewMyTickets.Size = new Size(800, 423);
            dataGridViewMyTickets.TabIndex = 1;
            dataGridViewMyTickets.Visible = false;
            // 
            // btnRefresh
            // 
            btnRefresh.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRefresh.Font = new Font("Segoe UI", 9F);
            btnRefresh.Location = new Point(269, 20);
            btnRefresh.Margin = new Padding(4, 5, 4, 5);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(90, 36);
            btnRefresh.TabIndex = 1;
            btnRefresh.Text = "Làm Mới";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // panelTop
            // 
            panelTop.Controls.Add(lblTitle);
            panelTop.Controls.Add(btnRefresh);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Margin = new Padding(4, 5, 4, 5);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(800, 77);
            panelTop.TabIndex = 0;
            // 
            // lblNoTicketsMessage
            // 
            lblNoTicketsMessage.Dock = DockStyle.Fill;
            lblNoTicketsMessage.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblNoTicketsMessage.ForeColor = SystemColors.ControlDarkDark;
            lblNoTicketsMessage.Location = new Point(0, 77);
            lblNoTicketsMessage.Margin = new Padding(4, 0, 4, 0);
            lblNoTicketsMessage.Name = "lblNoTicketsMessage";
            lblNoTicketsMessage.Padding = new Padding(27, 31, 27, 31);
            lblNoTicketsMessage.Size = new Size(800, 423);
            lblNoTicketsMessage.TabIndex = 2;
            lblNoTicketsMessage.Text = "Đang tải danh sách vé...";
            lblNoTicketsMessage.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // MyTicketsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 500);
            Controls.Add(lblNoTicketsMessage);
            Controls.Add(dataGridViewMyTickets);
            Controls.Add(panelTop);
            Margin = new Padding(4, 5, 4, 5);
            Name = "MyTicketsForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Vé Đã Đặt Của Tôi";
            Load += MyTicketsForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewMyTickets).EndInit();
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
    }
}