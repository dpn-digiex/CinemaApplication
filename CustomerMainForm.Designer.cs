namespace CinemaApplication
{
    partial class CustomerMainForm
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
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            systemMenuItem = new ToolStripMenuItem();
            accountMenuItem = new ToolStripMenuItem();
            logoutMenuItem = new ToolStripMenuItem();
            exitMenuItem = new ToolStripMenuItem();
            movieShowingMenuItem = new ToolStripMenuItem();
            movieUpcomingMenuItem = new ToolStripMenuItem();
            myTicketMenuItem = new ToolStripMenuItem();
            lớpTruyCậpDữLiệuToolStripMenuItem = new ToolStripMenuItem();
            dataAccessComboBox = new ToolStripComboBox();
            customerPanel = new Panel();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { systemMenuItem, movieShowingMenuItem, movieUpcomingMenuItem, myTicketMenuItem, lớpTruyCậpDữLiệuToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(920, 28);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // systemMenuItem
            // 
            systemMenuItem.DropDownItems.AddRange(new ToolStripItem[] { accountMenuItem, logoutMenuItem, exitMenuItem });
            systemMenuItem.Name = "systemMenuItem";
            systemMenuItem.Size = new Size(85, 24);
            systemMenuItem.Text = "Hệ thống";
            // 
            // accountMenuItem
            // 
            accountMenuItem.Name = "accountMenuItem";
            accountMenuItem.Size = new Size(160, 26);
            accountMenuItem.Text = "Tài khoản";
            // 
            // logoutMenuItem
            // 
            logoutMenuItem.Name = "logoutMenuItem";
            logoutMenuItem.Size = new Size(160, 26);
            logoutMenuItem.Text = "Đăng xuất";
            logoutMenuItem.Click += logoutMenuItem_Click;
            // 
            // exitMenuItem
            // 
            exitMenuItem.Name = "exitMenuItem";
            exitMenuItem.Size = new Size(160, 26);
            exitMenuItem.Text = "Thoát";
            exitMenuItem.Click += exitMenuItem_Click;
            // 
            // movieShowingMenuItem
            // 
            movieShowingMenuItem.Name = "movieShowingMenuItem";
            movieShowingMenuItem.Size = new Size(133, 24);
            movieShowingMenuItem.Text = "Phim đang chiếu";
            movieShowingMenuItem.Click += movieShowingMenuItem_Click;
            // 
            // movieUpcomingMenuItem
            // 
            movieUpcomingMenuItem.Name = "movieUpcomingMenuItem";
            movieUpcomingMenuItem.Size = new Size(122, 24);
            movieUpcomingMenuItem.Text = "Phim sắp chiếu";
            movieUpcomingMenuItem.Click += movieUpcomingMenuItem_Click;
            // 
            // myTicketMenuItem
            // 
            myTicketMenuItem.Name = "myTicketMenuItem";
            myTicketMenuItem.Size = new Size(114, 24);
            myTicketMenuItem.Text = "Vé đặt của tôi";
            myTicketMenuItem.Click += myTicketMenuItem_Click;
            // 
            // lớpTruyCậpDữLiệuToolStripMenuItem
            // 
            lớpTruyCậpDữLiệuToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { dataAccessComboBox });
            lớpTruyCậpDữLiệuToolStripMenuItem.Name = "lớpTruyCậpDữLiệuToolStripMenuItem";
            lớpTruyCậpDữLiệuToolStripMenuItem.Size = new Size(155, 24);
            lớpTruyCậpDữLiệuToolStripMenuItem.Text = "Lớp truy cập dữ liệu";
            // 
            // dataAccessComboBox
            // 
            dataAccessComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            dataAccessComboBox.Items.AddRange(new object[] { "ADO_NET", "ENTITY_FRAMEWORK" });
            dataAccessComboBox.Name = "dataAccessComboBox";
            dataAccessComboBox.Size = new Size(121, 28);
            dataAccessComboBox.SelectedIndexChanged += dataAccessComboBox_SelectedIndexChanged;
            // 
            // customerPanel
            // 
            customerPanel.Dock = DockStyle.Fill;
            customerPanel.Location = new Point(0, 28);
            customerPanel.Name = "customerPanel";
            customerPanel.Size = new Size(920, 525);
            customerPanel.TabIndex = 1;
            // 
            // CustomerMainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(920, 553);
            Controls.Add(customerPanel);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "CustomerMainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Ứng dụng đặt vé xem phim";
            Load += CustomerMainForm_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem systemMenuItem;
        private ToolStripMenuItem accountMenuItem;
        private ToolStripMenuItem logoutMenuItem;
        private ToolStripMenuItem exitMenuItem;
        private ToolStripMenuItem movieShowingMenuItem;
        private ToolStripMenuItem movieUpcomingMenuItem;
        private ToolStripMenuItem lớpTruyCậpDữLiệuToolStripMenuItem;
        private ToolStripComboBox dataAccessComboBox;
        private Panel customerPanel;
        private ToolStripMenuItem myTicketMenuItem;
    }
}