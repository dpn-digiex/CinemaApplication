using CinemaApplication.DataAccess;
using CinemaApplication.Enums;
using CinemaApplication.Models;
using System.Text.RegularExpressions;

namespace CinemaApplication
{
    public partial class RegisterForm : Form
    {
        public DataAccessLayer dataAccessLayer;
        public DataAccessLayerVersionEnum currentVersionDataAccess;
        public RegisterForm()
        {
            InitializeComponent();
            InitializeInstaceForm();
        }

        public void InitializeInstaceForm()
        {
            currentVersionDataAccess = DataAccessLayerVersionEnum.ADO_NET;
            dataAccessLayer = new DataAccessLayer(currentVersionDataAccess);
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string username = textBoxUsername.Text.Trim();
            string password = textBoxPassword.Text;
            string confirmPassword = textBoxConfirmPassword.Text;
            string email = textBoxEmail.Text.Trim();
            string fullName = textBoxFullname.Text.Trim();
            string phoneNumber = textBoxSdt.Text.Trim();

            if (string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrWhiteSpace(password) ||
                string.IsNullOrWhiteSpace(confirmPassword) ||
                string.IsNullOrWhiteSpace(email) || 
                string.IsNullOrWhiteSpace(fullName) ||
                string.IsNullOrWhiteSpace(phoneNumber))
            {
                MessageBox.Show("Vui lòng điền đầy đủ các trường bắt buộc (*).", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("Mật khẩu và xác nhận mật khẩu không khớp.", "Lỗi mật khẩu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxPassword.Focus();
                return;
            }

            // email validation
            if (!IsValidEmail(email))
            {
                MessageBox.Show("Định dạng email không hợp lệ.", "Lỗi Email", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxEmail.Focus();
                return;
            }

            try
            {
                UserModel newUser = new UserModel
                {
                    Username = username,
                    Password = password, 
                    Email = email,
                    FullName = string.IsNullOrWhiteSpace(fullName) ? null : fullName,
                    PhoneNumber = string.IsNullOrWhiteSpace(phoneNumber) ? null : phoneNumber,
                    Role = UserRoleEnum.user.ToString(), 
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                };
                dataAccessLayer.RegisterUser(newUser);

                MessageBox.Show("Đăng ký tài khoản thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi trong quá trình đăng ký: {ex.Message}", "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnComeback_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;
            try
            {
                // regrex email
                return Regex.IsMatch(email,
                    @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }
    }
}
