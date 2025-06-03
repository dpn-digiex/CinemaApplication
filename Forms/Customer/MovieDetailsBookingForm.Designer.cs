namespace CinemaApplication.Forms.Customer
{
    partial class MovieDetailsBookingForm
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
            panelBooking = new Panel();
            SuspendLayout();
            // 
            // panelBooking
            // 
            panelBooking.Dock = DockStyle.Fill;
            panelBooking.Location = new Point(0, 0);
            panelBooking.Name = "panelBooking";
            panelBooking.Size = new Size(982, 953);
            panelBooking.TabIndex = 0;
            // 
            // MovieDetailsBookingForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(982, 953);
            Controls.Add(panelBooking);
            Name = "MovieDetailsBookingForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Nội dung phim";
            ResumeLayout(false);
        }

        #endregion

        private Panel panelBooking;
    }
}