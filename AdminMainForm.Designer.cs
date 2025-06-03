namespace CinemaApplication
{
    partial class AdminMainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            adminPanel = new Panel();
            label1 = new Label();
            menuStrip1 = new MenuStrip();
            systemMenuItem = new ToolStripMenuItem();
            accountMenuItem = new ToolStripMenuItem();
            logoutMenuItem = new ToolStripMenuItem();
            exitMenuItem = new ToolStripMenuItem();
            managementMenuItem = new ToolStripMenuItem();
            manageRoomMenuItem = new ToolStripMenuItem();
            listRoomMenuItem = new ToolStripMenuItem();
            seatTypeMenuItem = new ToolStripMenuItem();
            addMovieRoomMenuItem = new ToolStripMenuItem();
            manageMovieMenuItem = new ToolStripMenuItem();
            listMovieMenuItem = new ToolStripMenuItem();
            mangeScheduleMenuItem = new ToolStripMenuItem();
            showtimesMovieMenuItem = new ToolStripMenuItem();
            addMovieShowtimeMenuItem = new ToolStripMenuItem();
            manageFoodMenuItem = new ToolStripMenuItem();
            manageOrderMenuItem = new ToolStripMenuItem();
            manageUserMenuItem = new ToolStripMenuItem();
            statisticalMenuItem = new ToolStripMenuItem();
            viewMenuItem = new ToolStripMenuItem();
            scheduleMovieMenuItem = new ToolStripMenuItem();
            movieShowingMenuItem = new ToolStripMenuItem();
            movieUpcomingMenuItem = new ToolStripMenuItem();
            dataAccessMenuItem = new ToolStripMenuItem();
            dataAccessComboBox = new ToolStripComboBox();
            adminPanel.SuspendLayout();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // adminPanel
            // 
            adminPanel.Controls.Add(label1);
            adminPanel.Dock = DockStyle.Fill;
            adminPanel.Location = new Point(0, 28);
            adminPanel.Name = "adminPanel";
            adminPanel.Size = new Size(1052, 589);
            adminPanel.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(328, 254);
            label1.Name = "label1";
            label1.Size = new Size(372, 38);
            label1.TabIndex = 1;
            label1.Text = "Hệ thống quản lý rạp phim";
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { systemMenuItem, managementMenuItem, statisticalMenuItem, viewMenuItem, dataAccessMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1052, 28);
            menuStrip1.TabIndex = 2;
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
            // managementMenuItem
            // 
            managementMenuItem.DropDownItems.AddRange(new ToolStripItem[] { manageRoomMenuItem, manageMovieMenuItem, mangeScheduleMenuItem, manageFoodMenuItem, manageOrderMenuItem, manageUserMenuItem });
            managementMenuItem.Name = "managementMenuItem";
            managementMenuItem.Size = new Size(73, 24);
            managementMenuItem.Text = "Quản lý";
            // 
            // manageRoomMenuItem
            // 
            manageRoomMenuItem.DropDownItems.AddRange(new ToolStripItem[] { listRoomMenuItem, seatTypeMenuItem, addMovieRoomMenuItem });
            manageRoomMenuItem.Name = "manageRoomMenuItem";
            manageRoomMenuItem.Size = new Size(224, 26);
            manageRoomMenuItem.Text = "Rạp và phòng chiếu";
            // 
            // listRoomMenuItem
            // 
            listRoomMenuItem.Name = "listRoomMenuItem";
            listRoomMenuItem.Size = new Size(246, 26);
            listRoomMenuItem.Text = "Danh sách phòng chiếu";
            listRoomMenuItem.Click += listRoomMenuItem_Click;
            // 
            // seatTypeMenuItem
            // 
            seatTypeMenuItem.Name = "seatTypeMenuItem";
            seatTypeMenuItem.Size = new Size(246, 26);
            seatTypeMenuItem.Text = "Loại ghế ngồi";
            // 
            // addMovieRoomMenuItem
            // 
            addMovieRoomMenuItem.Name = "addMovieRoomMenuItem";
            addMovieRoomMenuItem.Size = new Size(246, 26);
            addMovieRoomMenuItem.Text = "Thêm phòng chiếu mới";
            addMovieRoomMenuItem.Click += addMovieRoomMenuItem_Click;
            // 
            // manageMovieMenuItem
            // 
            manageMovieMenuItem.DropDownItems.AddRange(new ToolStripItem[] { listMovieMenuItem });
            manageMovieMenuItem.Name = "manageMovieMenuItem";
            manageMovieMenuItem.Size = new Size(224, 26);
            manageMovieMenuItem.Text = "Phim ảnh";
            // 
            // listMovieMenuItem
            // 
            listMovieMenuItem.Name = "listMovieMenuItem";
            listMovieMenuItem.Size = new Size(198, 26);
            listMovieMenuItem.Text = "Danh sách phim";
            listMovieMenuItem.Click += listMovieMenuItem_Click;
            // 
            // mangeScheduleMenuItem
            // 
            mangeScheduleMenuItem.DropDownItems.AddRange(new ToolStripItem[] { showtimesMovieMenuItem, addMovieShowtimeMenuItem });
            mangeScheduleMenuItem.Name = "mangeScheduleMenuItem";
            mangeScheduleMenuItem.Size = new Size(224, 26);
            mangeScheduleMenuItem.Text = "Lịch chiếu";
            // 
            // showtimesMovieMenuItem
            // 
            showtimesMovieMenuItem.Name = "showtimesMovieMenuItem";
            showtimesMovieMenuItem.Size = new Size(217, 26);
            showtimesMovieMenuItem.Text = "Lịch chiếu phim ";
            showtimesMovieMenuItem.Click += showtimesMovieMenuItem_Click;
            // 
            // addMovieShowtimeMenuItem
            // 
            addMovieShowtimeMenuItem.Name = "addMovieShowtimeMenuItem";
            addMovieShowtimeMenuItem.Size = new Size(217, 26);
            addMovieShowtimeMenuItem.Text = "Tạo lịch chiếu mới ";
            addMovieShowtimeMenuItem.Click += addMovieShowtimeMenuItem_Click;
            // 
            // manageFoodMenuItem
            // 
            manageFoodMenuItem.Name = "manageFoodMenuItem";
            manageFoodMenuItem.Size = new Size(224, 26);
            manageFoodMenuItem.Text = "Thức ăn, đồ uống";
            manageFoodMenuItem.Click += manageFoodMenuItem_Click;
            // 
            // manageOrderMenuItem
            // 
            manageOrderMenuItem.Name = "manageOrderMenuItem";
            manageOrderMenuItem.Size = new Size(224, 26);
            manageOrderMenuItem.Text = "Đơn hàng, đặt vé";
            // 
            // manageUserMenuItem
            // 
            manageUserMenuItem.Name = "manageUserMenuItem";
            manageUserMenuItem.Size = new Size(224, 26);
            manageUserMenuItem.Text = "Người dùng";
            // 
            // statisticalMenuItem
            // 
            statisticalMenuItem.Name = "statisticalMenuItem";
            statisticalMenuItem.Size = new Size(139, 24);
            statisticalMenuItem.Text = "Báo cáo thống kê";
            statisticalMenuItem.Click += statisticalMenuItem_Click;
            // 
            // viewMenuItem
            // 
            viewMenuItem.DropDownItems.AddRange(new ToolStripItem[] { scheduleMovieMenuItem, movieShowingMenuItem, movieUpcomingMenuItem });
            viewMenuItem.Name = "viewMenuItem";
            viewMenuItem.Size = new Size(55, 24);
            viewMenuItem.Text = "View";
            // 
            // scheduleMovieMenuItem
            // 
            scheduleMovieMenuItem.Name = "scheduleMovieMenuItem";
            scheduleMovieMenuItem.Size = new Size(202, 26);
            scheduleMovieMenuItem.Text = "Lịch chiếu phim";
            scheduleMovieMenuItem.Click += scheduleMovieMenuItem_Click;
            // 
            // movieShowingMenuItem
            // 
            movieShowingMenuItem.Name = "movieShowingMenuItem";
            movieShowingMenuItem.Size = new Size(202, 26);
            movieShowingMenuItem.Text = "Phim đang chiếu";
            movieShowingMenuItem.Click += movieShowingMenuItem_Click;
            // 
            // movieUpcomingMenuItem
            // 
            movieUpcomingMenuItem.Name = "movieUpcomingMenuItem";
            movieUpcomingMenuItem.Size = new Size(202, 26);
            movieUpcomingMenuItem.Text = "Phim sắp chiếu";
            movieUpcomingMenuItem.Click += movieUpcomingMenuItem_Click;
            // 
            // dataAccessMenuItem
            // 
            dataAccessMenuItem.DropDownItems.AddRange(new ToolStripItem[] { dataAccessComboBox });
            dataAccessMenuItem.Name = "dataAccessMenuItem";
            dataAccessMenuItem.Size = new Size(155, 24);
            dataAccessMenuItem.Text = "Lớp truy cập dữ liệu";
            // 
            // dataAccessComboBox
            // 
            dataAccessComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            dataAccessComboBox.Items.AddRange(new object[] { "ADO_NET", "ENTITY_FRAMEWORK" });
            dataAccessComboBox.Name = "dataAccessComboBox";
            dataAccessComboBox.Size = new Size(121, 28);
            dataAccessComboBox.SelectedIndexChanged += dataAccessComboBox_SelectedIndexChanged;
            // 
            // AdminMainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1052, 617);
            Controls.Add(adminPanel);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "AdminMainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Ứng dụng quản lý rạp phim";
            adminPanel.ResumeLayout(false);
            adminPanel.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Panel adminPanel;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem systemMenuItem;
        private ToolStripMenuItem accountMenuItem;
        private ToolStripMenuItem logoutMenuItem;
        private ToolStripMenuItem exitMenuItem;
        private ToolStripMenuItem managementMenuItem;
        private ToolStripMenuItem manageMovieMenuItem;
        private ToolStripMenuItem listMovieMenuItem;
        private ToolStripMenuItem manageRoomMenuItem;
        private ToolStripMenuItem listRoomMenuItem;
        private ToolStripMenuItem seatTypeMenuItem;
        private ToolStripMenuItem addMovieRoomMenuItem;
        private ToolStripMenuItem mangeScheduleMenuItem;
        private ToolStripMenuItem showtimesMovieMenuItem;
        private ToolStripMenuItem addMovieShowtimeMenuItem;
        private ToolStripMenuItem manageFoodMenuItem;
        private ToolStripMenuItem manageOrderMenuItem;
        private ToolStripMenuItem manageUserMenuItem;
        private ToolStripMenuItem statisticalMenuItem;
        private ToolStripMenuItem viewMenuItem;
        private ToolStripMenuItem scheduleMovieMenuItem;
        private ToolStripMenuItem movieShowingMenuItem;
        private ToolStripMenuItem movieUpcomingMenuItem;
        private ToolStripMenuItem dataAccessMenuItem;
        private ToolStripComboBox dataAccessComboBox;
        private Label label1;
    }
}
