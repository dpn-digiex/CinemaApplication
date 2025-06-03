using CinemaApplication.DataAccess;
using CinemaApplication.Enums;
using CinemaApplication.Forms.Common;
using CinemaApplication.Forms.Customer;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CinemaApplication
{
    public partial class CustomerMainForm : Form
    {
        public DataAccessLayer dataAccessLayer;
        public DataAccessLayerVersionEnum currentVersionDataAccess;

        // Enum để theo dõi form con nào đang được hiển thị 
        private CustomerChildFormEnum activeChildFormType;

        // Giữ tham chiếu đến form con đang hoạt động
        private Form currentChildForm = null;
        public CustomerMainForm()
        {
            InitializeComponent();
            InitializeInstaceForm();
            dataAccessComboBox.Text = DataAccessLayerVersionEnum.ADO_NET.ToString();
            customerPanel.Dock = DockStyle.Fill;
            activeChildFormType = CustomerChildFormEnum.MovieShowingForm;
        }

        public void InitializeInstaceForm()
        {
            currentVersionDataAccess = DataAccessLayerVersionEnum.ADO_NET;
            dataAccessLayer = new DataAccessLayer(currentVersionDataAccess);
        }

        public void OpenChildForm(CustomerChildFormEnum formType)
        {
            if (currentChildForm != null)
            {
                currentChildForm.Close();
                currentChildForm = null;
            }

            Form childForm = null;
            switch (formType)
            {
                case CustomerChildFormEnum.MovieShowingForm:
                    AppUtils.WriteLine("Opening MovieShowingForm...");
                    childForm = new MovieShowingForm(dataAccessLayer);
                    break;
                case CustomerChildFormEnum.MovieUpcomingForm:
                    childForm = new MovieUpcomingForm(dataAccessLayer);
                    break;
                case CustomerChildFormEnum.MyTicketForm:
                     childForm = new MyTicketsForm(dataAccessLayer);
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
                childForm.Size = customerPanel.Size;

                customerPanel.Controls.Add(childForm);
                childForm.BringToFront();
                childForm.Show();

                AppUtils.WriteLine($"Opened child form: {formType}");
            }
        }

        private void movieShowingMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(CustomerChildFormEnum.MovieShowingForm);
        }
        private void movieUpcomingMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(CustomerChildFormEnum.MovieUpcomingForm);
        }

        private void CustomerMainForm_Load(object sender, EventArgs e)
        {
            activeChildFormType = CustomerChildFormEnum.MovieShowingForm;
            OpenChildForm(activeChildFormType);
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

        private void customerPanel_Click(object sender, EventArgs e)
        {
            AppUtils.WriteLine("customerPanel_Click");
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

        private void myTicketMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(CustomerChildFormEnum.MyTicketForm);
        }
    }
}
