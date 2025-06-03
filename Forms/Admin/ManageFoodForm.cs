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

namespace CinemaApplication.Forms.Admin
{
    public partial class ManageFoodForm : Form
    {
        private DataAccessLayer _dataAccessLayer;
        private readonly FoodItemModel _foodItemToEdit;
        private readonly bool _isEditMode;
        public ManageFoodForm(DataAccessLayer dataAccessLayerRef)
        {
            InitializeComponent();
            _dataAccessLayer = dataAccessLayerRef;
        }

        private void ManageFoodForm_Load(object sender, EventArgs e)
        {
            if (_dataAccessLayer == null) return;
            SetupDataGridView();
            LoadFoodItems();
            UpdateButtonStates();
        }
        private void SetupDataGridView()
        {
            dataGridViewFoodItems.AutoGenerateColumns = false;
            dataGridViewFoodItems.Columns.Clear();

            dataGridViewFoodItems.Columns.Add(new DataGridViewTextBoxColumn { Name = "colFoodItemId", HeaderText = "ID", DataPropertyName = "FoodItemId", Width = 50 });
            dataGridViewFoodItems.Columns.Add(new DataGridViewTextBoxColumn { Name = "colName", HeaderText = "Tên Sản Phẩm", DataPropertyName = "Name", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dataGridViewFoodItems.Columns.Add(new DataGridViewTextBoxColumn { Name = "colCategory", HeaderText = "Danh Mục", DataPropertyName = "Category", Width = 120 });
            dataGridViewFoodItems.Columns.Add(new DataGridViewTextBoxColumn { Name = "colPrice", HeaderText = "Giá (VNĐ)", DataPropertyName = "Price", Width = 100, DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" } });
            dataGridViewFoodItems.Columns.Add(new DataGridViewCheckBoxColumn { Name = "colIsAvailable", HeaderText = "Có Sẵn", DataPropertyName = "IsAvailable", Width = 70 });
            dataGridViewFoodItems.Columns.Add(new DataGridViewTextBoxColumn { Name = "colDescription", HeaderText = "Mô Tả", DataPropertyName = "Description", Width = 200 });


            dataGridViewFoodItems.AllowUserToAddRows = false;
            dataGridViewFoodItems.ReadOnly = true;
            dataGridViewFoodItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewFoodItems.MultiSelect = false;
            dataGridViewFoodItems.RowHeadersVisible = false;
            dataGridViewFoodItems.SelectionChanged += DataGridViewFoodItems_SelectionChanged;
            dataGridViewFoodItems.CellDoubleClick += DataGridViewFoodItems_CellDoubleClick;
        }

        private void LoadFoodItems()
        {
            if (_dataAccessLayer == null) return;
            AppUtils.WriteLine("[ManageFoodForm] Loading food items...");
            List<FoodItemModel> items = _dataAccessLayer.GetAllFoodItems();
            if (items != null)
            {
                dataGridViewFoodItems.DataSource = items;
                AppUtils.WriteLine($"[ManageFoodForm] Loaded {items.Count} food items.");
            }
            else
            {
                dataGridViewFoodItems.DataSource = null;
                MessageBox.Show("Không thể tải danh sách sản phẩm.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            UpdateButtonStates();
        }

        private void UpdateButtonStates()
        {
            bool rowSelected = dataGridViewFoodItems.SelectedRows.Count > 0;
            btnEditFoodItem.Enabled = rowSelected;
            btnDeleteFoodItem.Enabled = rowSelected;
        }

        private void DataGridViewFoodItems_SelectionChanged(object sender, EventArgs e)
        {
            UpdateButtonStates();
        }

        private void EditSelectedFoodItem()
        {
            if (_dataAccessLayer == null || dataGridViewFoodItems.SelectedRows.Count == 0) return;

            FoodItemModel selectedItem = dataGridViewFoodItems.SelectedRows[0].DataBoundItem as FoodItemModel;
            if (selectedItem != null)
            {
                AddEditFoodItemForm editForm = new AddEditFoodItemForm(_dataAccessLayer, selectedItem);
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    LoadFoodItems();
                }
            }
        }

        private void DataGridViewFoodItems_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) EditSelectedFoodItem();
        }

        private void btnRefreshList_Click(object sender, EventArgs e)
        {
            LoadFoodItems();
        }

        private void btnAddNewFoodItem_Click(object sender, EventArgs e)
        {
            if (_dataAccessLayer == null) return;
            AddEditFoodItemForm addForm = new AddEditFoodItemForm(_dataAccessLayer);
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                LoadFoodItems();
            }
        }

        private void btnEditFoodItem_Click(object sender, EventArgs e)
        {
            EditSelectedFoodItem();
        }

        private void btnDeleteFoodItem_Click(object sender, EventArgs e)
        {
            if (_dataAccessLayer == null || dataGridViewFoodItems.SelectedRows.Count == 0) return;

            FoodItemModel selectedItem = dataGridViewFoodItems.SelectedRows[0].DataBoundItem as FoodItemModel;
            if (selectedItem != null)
            {
                var confirmResult = MessageBox.Show($"Bạn có chắc chắn muốn xóa sản phẩm '{selectedItem.Name}' không?",
                                                     "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirmResult == DialogResult.Yes)
                {
                    bool success = _dataAccessLayer.DeleteFoodItem(selectedItem.FoodItemId);
                    if (success)
                    {
                        MessageBox.Show("Xóa sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadFoodItems();
                    }
                    else
                    {
                        MessageBox.Show("Không thể xóa sản phẩm.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
