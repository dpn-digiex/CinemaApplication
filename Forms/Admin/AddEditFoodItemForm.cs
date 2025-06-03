using CinemaApplication.DataAccess;
using CinemaApplication.Models;
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
using System.Xml.Linq;

namespace CinemaApplication.Forms.Admin
{
    public partial class AddEditFoodItemForm : Form
    {
        private readonly DataAccessLayer _dataAccessLayer;
        private readonly FoodItemModel _foodItemToEdit;
        private readonly bool _isEditMode;

        public AddEditFoodItemForm(DataAccessLayer dataAccessLayerRef, FoodItemModel foodItemToEdit = null)
        {
            InitializeComponent();
            _dataAccessLayer = dataAccessLayerRef;
            _foodItemToEdit = foodItemToEdit;
            _isEditMode = (_foodItemToEdit != null);

            LoadFoodItemDetails();
        }


        private void LoadFoodItemDetails()
        {
            if (_isEditMode && _foodItemToEdit != null)
            {
                this.Text = $"Chỉnh Sửa Sản Phẩm: {_foodItemToEdit.Name}";
                txtName.Text = _foodItemToEdit.Name;
                txtDescription.Text = _foodItemToEdit.Description;
                numPrice.Value = Math.Max(numPrice.Minimum, Math.Min(numPrice.Maximum, _foodItemToEdit.Price));
                txtImageUrl.Text = _foodItemToEdit.ImageUrl;
                txtCategory.Text = _foodItemToEdit.Category;
                chkIsAvailable.Checked = _foodItemToEdit.IsAvailable;
                LoadImageToPictureBox(txtImageUrl.Text);
            }
            else
            {
                this.Text = "Thêm Sản Phẩm Mới";
                chkIsAvailable.Checked = true; // Mặc định là có sẵn
                numPrice.Value = 10000; // Giá mặc định
                pictureBoxFoodImage.Image = null;
            }
        }

        private void LoadImageToPictureBox(string imageUrlOrPath)
        {
            if (string.IsNullOrWhiteSpace(imageUrlOrPath))
            {
                pictureBoxFoodImage.Image = pictureBoxFoodImage.InitialImage;
                return;
            }
            try
            {
                pictureBoxFoodImage.LoadAsync(imageUrlOrPath);
            }
            catch (Exception ex)
            {
                AppUtils.WriteLine($"EXCEPTION in LoadImageToPictureBox for '{imageUrlOrPath}': {ex.Message}");
                pictureBoxFoodImage.Image = pictureBoxFoodImage.ErrorImage;
            }
        }

        private void PictureBoxFoodImage_LoadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Cancelled) { AppUtils.WriteLine("[AddEditFoodItemForm] Image loading cancelled."); }
            else if (e.Error != null)
            {
                AppUtils.WriteLine($"ERROR during async image loading: {e.Error.Message}");
                pictureBoxFoodImage.Image = pictureBoxFoodImage.ErrorImage;
            }
            else { AppUtils.WriteLine("[AddEditFoodItemForm] Image loaded successfully."); }
        }

        private void btnBrowseImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files(*.BMP;*.JPG;*.JPEG;*.GIF;*.PNG)|*.BMP;*.JPG;*.JPEG;*.GIF;*.PNG|All files (*.*)|*.*";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    txtImageUrl.Text = openFileDialog.FileName;
                    LoadImageToPictureBox(openFileDialog.FileName);
                }
            }
        }

        private void btnPreviewImage_Click(object sender, EventArgs e)
        {
            LoadImageToPictureBox(txtImageUrl.Text);
        }


        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Vui lòng nhập tên sản phẩm.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return false;
            }
            if (numPrice.Value < 0)
            {
                MessageBox.Show("Giá sản phẩm không thể âm.", "Thông tin không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numPrice.Focus();
                return false;
            }
            if (!string.IsNullOrWhiteSpace(txtImageUrl.Text) && !Uri.IsWellFormedUriString(txtImageUrl.Text, UriKind.Absolute) && !File.Exists(txtImageUrl.Text))
            {
                MessageBox.Show("URL/Đường dẫn ảnh không hợp lệ.", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtImageUrl.Focus();
                return false;
            }
            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return;

            FoodItemModel foodData = _isEditMode ? _foodItemToEdit : new FoodItemModel();
            foodData.Name = txtName.Text.Trim();
            foodData.Description = string.IsNullOrWhiteSpace(txtDescription.Text) ? null : txtDescription.Text.Trim();
            foodData.Price = numPrice.Value;
            foodData.ImageUrl = string.IsNullOrWhiteSpace(txtImageUrl.Text) ? null : txtImageUrl.Text.Trim();
            foodData.Category = string.IsNullOrWhiteSpace(txtCategory.Text) ? null : txtCategory.Text.Trim();
            foodData.IsAvailable = chkIsAvailable.Checked;

            bool success = false;
            try
            {
                if (_isEditMode)
                {
                    foodData.UpdatedAt = DateTime.UtcNow;
                    success = _dataAccessLayer.UpdateFoodItem(foodData);
                }
                else
                {
                    foodData.CreatedAt = DateTime.UtcNow;
                    foodData.UpdatedAt = DateTime.UtcNow;
                    int newItemId = _dataAccessLayer.AddFoodItem(foodData);
                    success = newItemId > 0;
                }

                if (success)
                {
                    MessageBox.Show(_isEditMode ? "Cập nhật sản phẩm thành công!" : "Thêm sản phẩm mới thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show(_isEditMode ? "Không thể cập nhật sản phẩm." : "Không thể thêm sản phẩm mới.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                AppUtils.WriteLine($"EXCEPTION in btnSave_Click (FoodItem): {ex.GetType().FullName} - {ex.Message}\nStackTrace: {ex.StackTrace}");
                MessageBox.Show("Đã xảy ra lỗi khi lưu dữ liệu.", "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
