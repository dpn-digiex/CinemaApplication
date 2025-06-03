namespace CinemaApplication.Forms.Admin
{
    partial class AddEditFoodItemForm
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
        ///  private System.Windows.Forms.Label lblNameText;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblDescriptionText;
        private System.Windows.Forms.RichTextBox txtDescription;
        private System.Windows.Forms.Label lblPriceText;
        private System.Windows.Forms.NumericUpDown numPrice;
        private System.Windows.Forms.Label lblCategoryText;
        private System.Windows.Forms.TextBox txtCategory;
        private System.Windows.Forms.Label lblImageUrlText;
        private System.Windows.Forms.TextBox txtImageUrl;
        private System.Windows.Forms.Button btnPreviewImage;
        private System.Windows.Forms.CheckBox chkIsAvailable;
        private System.Windows.Forms.PictureBox pictureBoxFoodImage;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ToolTip toolTipHelper;
        private System.Windows.Forms.Label lblNameText;
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            lblNameText = new Label();
            txtName = new TextBox();
            lblDescriptionText = new Label();
            txtDescription = new RichTextBox();
            lblPriceText = new Label();
            numPrice = new NumericUpDown();
            lblCategoryText = new Label();
            txtCategory = new TextBox();
            lblImageUrlText = new Label();
            txtImageUrl = new TextBox();
            btnPreviewImage = new Button();
            chkIsAvailable = new CheckBox();
            pictureBoxFoodImage = new PictureBox();
            btnSave = new Button();
            btnCancel = new Button();
            toolTipHelper = new ToolTip(components);
            ((System.ComponentModel.ISupportInitialize)numPrice).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxFoodImage).BeginInit();
            SuspendLayout();
            // 
            // lblNameText
            // 
            lblNameText.AutoSize = true;
            lblNameText.Location = new Point(20, 28);
            lblNameText.Margin = new Padding(4, 0, 4, 0);
            lblNameText.Name = "lblNameText";
            lblNameText.Size = new Size(75, 20);
            lblNameText.TabIndex = 0;
            lblNameText.Text = "Tên SP (*):";
            // 
            // txtName
            // 
            txtName.Location = new Point(152, 28);
            txtName.Margin = new Padding(4, 5, 4, 5);
            txtName.Name = "txtName";
            txtName.Size = new Size(405, 27);
            txtName.TabIndex = 1;
            toolTipHelper.SetToolTip(txtName, "Tên đầy đủ của sản phẩm.");
            // 
            // lblDescriptionText
            // 
            lblDescriptionText.AutoSize = true;
            lblDescriptionText.Location = new Point(20, 65);
            lblDescriptionText.Margin = new Padding(4, 0, 4, 0);
            lblDescriptionText.Name = "lblDescriptionText";
            lblDescriptionText.Size = new Size(54, 20);
            lblDescriptionText.TabIndex = 2;
            lblDescriptionText.Text = "Mô Tả:";
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(152, 65);
            txtDescription.Margin = new Padding(4, 5, 4, 5);
            txtDescription.Name = "txtDescription";
            txtDescription.ScrollBars = RichTextBoxScrollBars.Vertical;
            txtDescription.Size = new Size(405, 90);
            txtDescription.TabIndex = 3;
            txtDescription.Text = "";
            // 
            // lblPriceText
            // 
            lblPriceText.AutoSize = true;
            lblPriceText.Location = new Point(20, 210);
            lblPriceText.Margin = new Padding(4, 0, 4, 0);
            lblPriceText.Name = "lblPriceText";
            lblPriceText.Size = new Size(54, 20);
            lblPriceText.TabIndex = 4;
            lblPriceText.Text = "Giá (*):";
            // 
            // numPrice
            // 
            numPrice.Location = new Point(152, 208);
            numPrice.Margin = new Padding(4, 5, 4, 5);
            numPrice.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
            numPrice.Name = "numPrice";
            numPrice.Size = new Size(160, 27);
            numPrice.TabIndex = 5;
            numPrice.ThousandsSeparator = true;
            numPrice.Value = new decimal(new int[] { 10000, 0, 0, 0 });
            // 
            // lblCategoryText
            // 
            lblCategoryText.AutoSize = true;
            lblCategoryText.Location = new Point(20, 171);
            lblCategoryText.Margin = new Padding(4, 0, 4, 0);
            lblCategoryText.Name = "lblCategoryText";
            lblCategoryText.Size = new Size(79, 20);
            lblCategoryText.TabIndex = 6;
            lblCategoryText.Text = "Danh Mục:";
            // 
            // txtCategory
            // 
            txtCategory.Location = new Point(152, 171);
            txtCategory.Margin = new Padding(4, 5, 4, 5);
            txtCategory.Name = "txtCategory";
            txtCategory.Size = new Size(405, 27);
            txtCategory.TabIndex = 7;
            // 
            // lblImageUrlText
            // 
            lblImageUrlText.AutoSize = true;
            lblImageUrlText.Location = new Point(20, 248);
            lblImageUrlText.Margin = new Padding(4, 0, 4, 0);
            lblImageUrlText.Name = "lblImageUrlText";
            lblImageUrlText.Size = new Size(102, 20);
            lblImageUrlText.TabIndex = 8;
            lblImageUrlText.Text = "Link/Path Ảnh:";
            // 
            // txtImageUrl
            // 
            txtImageUrl.Location = new Point(152, 245);
            txtImageUrl.Margin = new Padding(4, 5, 4, 5);
            txtImageUrl.Name = "txtImageUrl";
            txtImageUrl.Size = new Size(305, 27);
            txtImageUrl.TabIndex = 9;
            // 
            // btnPreviewImage
            // 
            btnPreviewImage.Location = new Point(465, 245);
            btnPreviewImage.Margin = new Padding(4, 5, 4, 5);
            btnPreviewImage.Name = "btnPreviewImage";
            btnPreviewImage.Size = new Size(92, 29);
            btnPreviewImage.TabIndex = 11;
            btnPreviewImage.Text = "Xem Ảnh";
            btnPreviewImage.UseVisualStyleBackColor = true;
            btnPreviewImage.Click += btnPreviewImage_Click;
            // 
            // chkIsAvailable
            // 
            chkIsAvailable.AutoSize = true;
            chkIsAvailable.Checked = true;
            chkIsAvailable.CheckState = CheckState.Checked;
            chkIsAvailable.Location = new Point(20, 289);
            chkIsAvailable.Margin = new Padding(4, 5, 4, 5);
            chkIsAvailable.Name = "chkIsAvailable";
            chkIsAvailable.Size = new Size(125, 24);
            chkIsAvailable.TabIndex = 12;
            chkIsAvailable.Text = "Có sẵn để bán";
            chkIsAvailable.UseVisualStyleBackColor = true;
            // 
            // pictureBoxFoodImage
            // 
            pictureBoxFoodImage.BorderStyle = BorderStyle.FixedSingle;
            pictureBoxFoodImage.Location = new Point(596, 28);
            pictureBoxFoodImage.Margin = new Padding(4, 5, 4, 5);
            pictureBoxFoodImage.Name = "pictureBoxFoodImage";
            pictureBoxFoodImage.Size = new Size(199, 230);
            pictureBoxFoodImage.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxFoodImage.TabIndex = 13;
            pictureBoxFoodImage.TabStop = false;
            // 
            // btnSave
            // 
            btnSave.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSave.Location = new Point(20, 344);
            btnSave.Margin = new Padding(4, 5, 4, 5);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(107, 43);
            btnSave.TabIndex = 14;
            btnSave.Text = "Lưu";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(152, 344);
            btnCancel.Margin = new Padding(4, 5, 4, 5);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(107, 43);
            btnCancel.TabIndex = 15;
            btnCancel.Text = "Hủy";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // AddEditFoodItemForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(820, 417);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(pictureBoxFoodImage);
            Controls.Add(chkIsAvailable);
            Controls.Add(btnPreviewImage);
            Controls.Add(txtImageUrl);
            Controls.Add(lblImageUrlText);
            Controls.Add(txtCategory);
            Controls.Add(lblCategoryText);
            Controls.Add(numPrice);
            Controls.Add(lblPriceText);
            Controls.Add(txtDescription);
            Controls.Add(lblDescriptionText);
            Controls.Add(txtName);
            Controls.Add(lblNameText);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(4, 5, 4, 5);
            Name = "AddEditFoodItemForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Quản lý Sản phẩm";
            ((System.ComponentModel.ISupportInitialize)numPrice).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxFoodImage).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}