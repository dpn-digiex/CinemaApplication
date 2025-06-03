using CinemaApplication.DataAccess;
using CinemaApplication.Enums;
using CinemaApplication.Models;
using CinemaApplication.Utils;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CinemaApplication
{
    public partial class LoginForm : Form
    {
        public DataAccessLayer dataAccessLayer;
        public DataAccessLayerVersionEnum currentVersionDataAccess;
        public LoginForm()
        {
            InitializeComponent();
            InitializeInstaceForm();
        }

        public void InitializeInstaceForm()
        {
            currentVersionDataAccess = DataAccessLayerVersionEnum.ADO_NET;
            dataAccessLayer = new DataAccessLayer(currentVersionDataAccess);
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            // for testing
            textBoxUsername.Text = "hellovn";
            textBoxPassword.Text = "123456";
            //btnLogin.PerformClick();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            // hiển thị RegisterForm
            RegisterForm registerForm = new RegisterForm();
            registerForm.Show();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            string username = textBoxUsername.Text;
            string password = textBoxPassword.Text;

            UserModel loggedInUser = dataAccessLayer.AuthenticateUser(username, password);

            if (loggedInUser != null) 
            {
                // save user info as global
                AppUtils.SetCurrentUser(loggedInUser);
                MessageBox.Show($"Đăng nhập thành công! Xin chào {loggedInUser.FullName ?? loggedInUser.Username}.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // check role
                if (loggedInUser.Role != null && loggedInUser.Role.Equals("admin", StringComparison.OrdinalIgnoreCase))
                {
                    AdminMainForm adminForm = new AdminMainForm();
                    adminForm.Show();
                }
                else if (loggedInUser.Role != null && loggedInUser.Role.Equals("user", StringComparison.OrdinalIgnoreCase))
                {
                    CustomerMainForm customerForm = new CustomerMainForm();
                    customerForm.Show();
                }
                this.Hide(); 
            }
            else 
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng.", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
