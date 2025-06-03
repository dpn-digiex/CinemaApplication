using CinemaApplication.DataAccess;
using CinemaApplication.Enums;
using CinemaApplication.Models;
using CinemaApplication.UserControls;
using CinemaApplication.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CinemaApplication.Forms.Common
{
    public partial class MovieUpcomingForm : Form
    {
        public DataAccessLayer dataAccessLayer;

        public MovieUpcomingForm(DataAccessLayer dataAccessLayerRef)
        {
            InitializeComponent();
            this.dataAccessLayer = dataAccessLayerRef;
        }

        private void MovieUpcomingForm_Load(object sender, EventArgs e)
        {
            LoadShowingMovies();
        }
        private void LoadShowingMovies()
        {
            if (dataAccessLayer == null)
            {
                MessageBox.Show("Không thể tải danh sách phim do lỗi kết nối dữ liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            flowLayoutPanelMovies.Controls.Clear();

            List<MovieModel> activeMovies = dataAccessLayer.GetMoviesByStatus(MovieStatusEnum.upcoming.ToString());

            if (activeMovies.Count == 0)
            {
                Label lblNoMovies = new Label();
                lblNoMovies.Text = "Hiện không có phim nào sắp chiếu.";
                lblNoMovies.AutoSize = true;
                lblNoMovies.Padding = new Padding(10);
                flowLayoutPanelMovies.Controls.Add(lblNoMovies);
                return;
            }

            foreach (MovieModel movie in activeMovies)
            {
                CardMovieItem movieCard = new CardMovieItem(dataAccessLayer);
                movieCard.SetMovieData(movie);
                AppUtils.WriteLine($"SetMovieData movie card for: {movie}");
                movieCard.Margin = new Padding(10); // Thêm khoảng cách giữa các card
                flowLayoutPanelMovies.Controls.Add(movieCard);
            }
        }
    }
}
