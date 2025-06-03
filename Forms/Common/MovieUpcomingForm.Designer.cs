namespace CinemaApplication.Forms.Common
{
    partial class MovieUpcomingForm
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
            flowLayoutPanelMovies = new FlowLayoutPanel();
            SuspendLayout();
            // 
            // flowLayoutPanelMovies
            // 
            flowLayoutPanelMovies.AutoScroll = true;
            flowLayoutPanelMovies.BackColor = SystemColors.InactiveCaption;
            flowLayoutPanelMovies.Dock = DockStyle.Fill;
            flowLayoutPanelMovies.Location = new Point(0, 0);
            flowLayoutPanelMovies.Name = "flowLayoutPanelMovies";
            flowLayoutPanelMovies.Size = new Size(825, 502);
            flowLayoutPanelMovies.TabIndex = 0;
            flowLayoutPanelMovies.WrapContents = false;
            // 
            // MovieUpcomingForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(825, 502);
            Controls.Add(flowLayoutPanelMovies);
            Name = "MovieUpcomingForm";
            Text = "Phim sắp chiếu";
            Load += MovieUpcomingForm_Load;
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel flowLayoutPanelMovies;
    }
}