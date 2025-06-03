namespace CinemaApplication.Forms.Admin
{
    partial class ManageFoodForm
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
        /// 
        private DataGridView dataGridViewFoodItems;
        private Button btnAddNewFoodItem;
        private Button btnEditFoodItem;
        private Button btnDeleteFoodItem;
        private Button btnRefreshList;
        private Panel panelButtons;
        private void InitializeComponent()
        {
            dataGridViewFoodItems = new DataGridView();
            panelButtons = new Panel();
            btnRefreshList = new Button();
            btnDeleteFoodItem = new Button();
            btnEditFoodItem = new Button();
            btnAddNewFoodItem = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewFoodItems).BeginInit();
            panelButtons.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridViewFoodItems
            // 
            dataGridViewFoodItems.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewFoodItems.Dock = DockStyle.Fill;
            dataGridViewFoodItems.Location = new Point(0, 45);
            dataGridViewFoodItems.Name = "dataGridViewFoodItems";
            dataGridViewFoodItems.RowHeadersWidth = 51;
            dataGridViewFoodItems.Size = new Size(1063, 608);
            dataGridViewFoodItems.TabIndex = 1;
            // 
            // panelButtons
            // 
            panelButtons.Controls.Add(btnRefreshList);
            panelButtons.Controls.Add(btnDeleteFoodItem);
            panelButtons.Controls.Add(btnEditFoodItem);
            panelButtons.Controls.Add(btnAddNewFoodItem);
            panelButtons.Dock = DockStyle.Top;
            panelButtons.Location = new Point(0, 0);
            panelButtons.Name = "panelButtons";
            panelButtons.Padding = new Padding(5);
            panelButtons.Size = new Size(1063, 45);
            panelButtons.TabIndex = 0;
            // 
            // btnRefreshList
            // 
            btnRefreshList.Location = new Point(266, 8);
            btnRefreshList.Name = "btnRefreshList";
            btnRefreshList.Size = new Size(90, 25);
            btnRefreshList.TabIndex = 0;
            btnRefreshList.Text = "Làm Mới";
            btnRefreshList.Click += btnRefreshList_Click;
            // 
            // btnDeleteFoodItem
            // 
            btnDeleteFoodItem.Location = new Point(185, 8);
            btnDeleteFoodItem.Name = "btnDeleteFoodItem";
            btnDeleteFoodItem.Size = new Size(75, 25);
            btnDeleteFoodItem.TabIndex = 1;
            btnDeleteFoodItem.Text = "Xóa";
            btnDeleteFoodItem.Click += btnDeleteFoodItem_Click;
            // 
            // btnEditFoodItem
            // 
            btnEditFoodItem.Location = new Point(104, 8);
            btnEditFoodItem.Name = "btnEditFoodItem";
            btnEditFoodItem.Size = new Size(75, 25);
            btnEditFoodItem.TabIndex = 2;
            btnEditFoodItem.Text = "Sửa";
            btnEditFoodItem.Click += btnEditFoodItem_Click;
            // 
            // btnAddNewFoodItem
            // 
            btnAddNewFoodItem.Location = new Point(8, 8);
            btnAddNewFoodItem.Name = "btnAddNewFoodItem";
            btnAddNewFoodItem.Size = new Size(90, 25);
            btnAddNewFoodItem.TabIndex = 3;
            btnAddNewFoodItem.Text = "Thêm Mới";
            btnAddNewFoodItem.Click += btnAddNewFoodItem_Click;
            // 
            // ManageFoodForm
            // 
            ClientSize = new Size(1063, 653);
            Controls.Add(dataGridViewFoodItems);
            Controls.Add(panelButtons);
            Name = "ManageFoodForm";
            Text = "Quản Lý Sản Phẩm Ăn Uống";
            Load += ManageFoodForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewFoodItems).EndInit();
            panelButtons.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
    }
}