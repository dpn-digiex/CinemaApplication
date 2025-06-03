namespace CinemaApplication.UserControls
{
    partial class MovieShowtimeBookingControl
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
        private Label lblTimeSlot;
        private Label lblRoomName;
        private Label lblSeatsAvailable;
        private Panel panelContainer;

        private void InitializeComponent()
        {
            panelContainer = new Panel();
            lblSeatsAvailable = new Label();
            lblRoomName = new Label();
            lblTimeSlot = new Label();
            panelContainer.SuspendLayout();
            SuspendLayout();
            // 
            // panelContainer
            // 
            panelContainer.AutoSize = true;
            panelContainer.BackColor = Color.IndianRed;
            panelContainer.BorderStyle = BorderStyle.FixedSingle;
            panelContainer.Controls.Add(lblSeatsAvailable);
            panelContainer.Controls.Add(lblRoomName);
            panelContainer.Controls.Add(lblTimeSlot);
            panelContainer.Dock = DockStyle.Fill;
            panelContainer.Location = new Point(0, 0);
            panelContainer.Margin = new Padding(4, 5, 4, 5);
            panelContainer.Name = "panelContainer";
            panelContainer.Padding = new Padding(11, 12, 11, 12);
            panelContainer.Size = new Size(180, 108);
            panelContainer.TabIndex = 0;
            // 
            // lblSeatsAvailable
            // 
            lblSeatsAvailable.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblSeatsAvailable.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblSeatsAvailable.Location = new Point(15, 39);
            lblSeatsAvailable.Margin = new Padding(4, 0, 4, 0);
            lblSeatsAvailable.Name = "lblSeatsAvailable";
            lblSeatsAvailable.Size = new Size(128, 26);
            lblSeatsAvailable.TabIndex = 2;
            lblSeatsAvailable.Text = "Còn 00/00 ghế";
            lblSeatsAvailable.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblRoomName
            // 
            lblRoomName.AutoSize = true;
            lblRoomName.Font = new Font("Segoe UI", 9F);
            lblRoomName.Location = new Point(15, 65);
            lblRoomName.Margin = new Padding(4, 0, 4, 0);
            lblRoomName.Name = "lblRoomName";
            lblRoomName.Size = new Size(67, 20);
            lblRoomName.TabIndex = 1;
            lblRoomName.Text = "Phòng: X";
            // 
            // lblTimeSlot
            // 
            lblTimeSlot.AutoSize = true;
            lblTimeSlot.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblTimeSlot.ForeColor = Color.FromArgb(0, 0, 192);
            lblTimeSlot.Location = new Point(15, 14);
            lblTimeSlot.Margin = new Padding(4, 0, 4, 0);
            lblTimeSlot.Name = "lblTimeSlot";
            lblTimeSlot.Size = new Size(128, 25);
            lblTimeSlot.TabIndex = 0;
            lblTimeSlot.Text = "00:00 - 00:00";
            // 
            // MovieShowtimeBookingControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panelContainer);
            Cursor = Cursors.Hand;
            Margin = new Padding(4, 5, 4, 9);
            Name = "MovieShowtimeBookingControl";
            Size = new Size(180, 108);
            panelContainer.ResumeLayout(false);
            panelContainer.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}
