using CinemaApplication.DataAccess;
using CinemaApplication.Enums;
using CinemaApplication.Forms.Admin;
using CinemaApplication.Forms.Common;
using CinemaApplication.Utils;

namespace CinemaApplication
{
    public partial class AdminMainForm : Form
    {
        public DataAccessLayer dataAccessLayer;
        public DataAccessLayerVersionEnum currentVersionDataAccess;
        // Enum để theo dõi form con nào đang được hiển thị 
        private AdminChildFormEnum activeChildFormType;
        // Giữ tham chiếu đến form con đang hoạt động
        private Form currentChildForm = null;
        public AdminMainForm()
        {
            InitializeComponent();
            InitializeInstaceForm();
            dataAccessComboBox.Text = DataAccessLayerVersionEnum.ADO_NET.ToString();
        }

        public void InitializeInstaceForm()
        {
            currentVersionDataAccess = DataAccessLayerVersionEnum.ADO_NET;
            dataAccessLayer = new DataAccessLayer(currentVersionDataAccess);
        }

        public void SetDataAccessMethod(DataAccessLayerVersionEnum newVersion)
        {
            DataAccessLayerVersionEnum previousVersion = currentVersionDataAccess;
            this.currentVersionDataAccess = newVersion;
            if (previousVersion != newVersion)
            {
                dataAccessLayer = new DataAccessLayer(newVersion);
            }
        }

        private void dataAccessComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dataAccessComboBox.SelectedItem != null)
            {
                string selectedVersion = dataAccessComboBox.SelectedItem.ToString();
                if (selectedVersion == DataAccessLayerVersionEnum.ADO_NET.ToString())
                {
                    dataAccessLayer.SetDataAccessLayerVersion(DataAccessLayerVersionEnum.ADO_NET);
                }
                else if (selectedVersion == DataAccessLayerVersionEnum.ENTITY_FRAMEWORK.ToString())
                {
                    dataAccessLayer.SetDataAccessLayerVersion(DataAccessLayerVersionEnum.ENTITY_FRAMEWORK);
                }
                else
                {
                    AppUtils.WriteLine("Unsupported data access layer version selected: " + selectedVersion);
                    return;
                }
            }
        }

        public void OpenChildForm(AdminChildFormEnum formType)
        {
            if (currentChildForm != null)
            {
                currentChildForm.Close();
                currentChildForm = null;
            }

            Form childForm = null;
            switch (formType)
            {
                case AdminChildFormEnum.MovieShowingForm:
                    AppUtils.WriteLine("Opening MovieShowingForm...");
                    childForm = new MovieShowingForm(dataAccessLayer);
                    break;
                case AdminChildFormEnum.MovieUpcomingForm:
                    childForm = new MovieUpcomingForm(dataAccessLayer);
                    break;
                case AdminChildFormEnum.AddCinemaRoomForm:
                    childForm = new AddMovieRoomForm(dataAccessLayer);
                    break;
                case AdminChildFormEnum.ListCinemaRoomForm:
                    childForm = new ListCinemaRoomForm(dataAccessLayer);
                    break;
                case AdminChildFormEnum.ManageMovieForm:
                    childForm = new ManageMovieForm(dataAccessLayer);
                    break;
                case AdminChildFormEnum.ManageFoodForm:
                    childForm = new ManageFoodForm(dataAccessLayer);
                    break;
                case AdminChildFormEnum.AddMovieShowtimeForm:
                    childForm = new AddMovieShowtime(dataAccessLayer);
                    break;
                case AdminChildFormEnum.ShowtimesMovieForm:
                    childForm = new ShowtimesMovieForm(dataAccessLayer);
                    break;
                case AdminChildFormEnum.StatisticalForm:
                    childForm = new StatisticalForm(dataAccessLayer);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(formType), "Loại form con không được hỗ trợ.");
            }

            if (childForm != null)
            {

                activeChildFormType = formType;
                currentChildForm = childForm;

                childForm.TopLevel = false;
                childForm.FormBorderStyle = FormBorderStyle.None;
                childForm.Dock = DockStyle.Fill;
                childForm.Size = adminPanel.Size;

                adminPanel.Controls.Add(childForm);
                childForm.BringToFront();
                childForm.Show();

                AppUtils.WriteLine($"Opened child form: {formType}");
            }
        }

        private void addMovieRoomMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(AdminChildFormEnum.AddCinemaRoomForm);
        }

        private void movieShowingMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(AdminChildFormEnum.MovieShowingForm);
        }

        private void movieUpcomingMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(AdminChildFormEnum.MovieUpcomingForm);
        }

        private void listRoomMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(AdminChildFormEnum.ListCinemaRoomForm);
        }

        private void listMovieMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(AdminChildFormEnum.ManageMovieForm);
        }

        private void manageFoodMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(AdminChildFormEnum.ManageFoodForm);
        }

        private void addMovieShowtimeMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(AdminChildFormEnum.AddMovieShowtimeForm);
        }

        private void showtimesMovieMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(AdminChildFormEnum.ShowtimesMovieForm);
        }

        private void scheduleMovieMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(AdminChildFormEnum.ShowtimesMovieForm);
        }

        private void exitMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult confirmExit = MessageBox.Show(
                "Bạn có chắc chắn muốn thoát khỏi ứng dụng?",
                "Xác nhận thoát",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmExit == DialogResult.Yes)
            {
                AppUtils.WriteLine("[AdminMainForm] Application exit requested by user.");
                Application.Exit();
            }
        }

        private void logoutMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult confirmLogout = MessageBox.Show(
                "Bạn có chắc chắn muốn đăng xuất?",
                "Xác nhận đăng xuất",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmLogout == DialogResult.Yes)
            {
                AppUtils.WriteLine("[AdminMainForm] User logging out.");
                AppUtils.SetCurrentUser(null);
                LoginForm loginForm = new LoginForm();
                loginForm.Show();
                this.Close();
            }
        }

        private void statisticalMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(AdminChildFormEnum.StatisticalForm);
        }
    }
}
