namespace CinemaApplication.UserControls
{
    partial class FoodOrderItemControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        /// 
        private PictureBox picFoodImage;
        private Label lblFoodName;
        private Label lblFoodPrice;
        private Label lblFoodDescription;
        private NumericUpDown numQuantity;
        private Panel panelContent;
        private void InitializeComponent()
        {
            picFoodImage = new PictureBox();
            lblFoodName = new Label();
            lblFoodPrice = new Label();
            lblFoodDescription = new Label();
            numQuantity = new NumericUpDown();
            panelContent = new Panel();
            ((System.ComponentModel.ISupportInitialize)picFoodImage).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numQuantity).BeginInit();
            panelContent.SuspendLayout();
            SuspendLayout();
            // 
            // picFoodImage
            // 
            picFoodImage.Location = new Point(11, 12);
            picFoodImage.Margin = new Padding(4, 5, 4, 5);
            picFoodImage.Name = "picFoodImage";
            picFoodImage.Size = new Size(107, 123);
            picFoodImage.SizeMode = PictureBoxSizeMode.Zoom;
            picFoodImage.TabIndex = 0;
            picFoodImage.TabStop = false;
            // 
            // lblFoodName
            // 
            lblFoodName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblFoodName.AutoEllipsis = true;
            lblFoodName.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblFoodName.Location = new Point(127, 12);
            lblFoodName.Margin = new Padding(4, 0, 4, 0);
            lblFoodName.Name = "lblFoodName";
            lblFoodName.Size = new Size(467, 31);
            lblFoodName.TabIndex = 1;
            lblFoodName.Text = "Tên Món Ăn";
            // 
            // lblFoodPrice
            // 
            lblFoodPrice.AutoSize = true;
            lblFoodPrice.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblFoodPrice.ForeColor = Color.Firebrick;
            lblFoodPrice.Location = new Point(127, 46);
            lblFoodPrice.Margin = new Padding(4, 0, 4, 0);
            lblFoodPrice.Name = "lblFoodPrice";
            lblFoodPrice.Size = new Size(54, 20);
            lblFoodPrice.TabIndex = 2;
            lblFoodPrice.Text = "0 VNĐ";
            // 
            // lblFoodDescription
            // 
            lblFoodDescription.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblFoodDescription.Font = new Font("Segoe UI", 8F);
            lblFoodDescription.ForeColor = Color.Gray;
            lblFoodDescription.Location = new Point(127, 77);
            lblFoodDescription.Margin = new Padding(4, 0, 4, 0);
            lblFoodDescription.Name = "lblFoodDescription";
            lblFoodDescription.Size = new Size(401, 54);
            lblFoodDescription.TabIndex = 3;
            lblFoodDescription.Text = "Mô tả ngắn cho sản phẩm này...";
            // 
            // numQuantity
            // 
            numQuantity.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            numQuantity.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            numQuantity.Location = new Point(447, 14);
            numQuantity.Margin = new Padding(4, 5, 4, 5);
            numQuantity.Maximum = new decimal(new int[] { 20, 0, 0, 0 });
            numQuantity.Name = "numQuantity";
            numQuantity.Size = new Size(73, 29);
            numQuantity.TabIndex = 4;
            numQuantity.TextAlign = HorizontalAlignment.Center;
            // 
            // panelContent
            // 
            panelContent.BackColor = Color.White;
            panelContent.BorderStyle = BorderStyle.FixedSingle;
            panelContent.Controls.Add(numQuantity);
            panelContent.Controls.Add(lblFoodDescription);
            panelContent.Controls.Add(lblFoodPrice);
            panelContent.Controls.Add(lblFoodName);
            panelContent.Controls.Add(picFoodImage);
            panelContent.Dock = DockStyle.Fill;
            panelContent.Location = new Point(0, 0);
            panelContent.Margin = new Padding(4, 5, 4, 5);
            panelContent.Name = "panelContent";
            panelContent.Padding = new Padding(7, 8, 7, 8);
            panelContent.Size = new Size(533, 154);
            panelContent.TabIndex = 0;
            // 
            // FoodOrderItemControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panelContent);
            Margin = new Padding(4, 5, 4, 9);
            Name = "FoodOrderItemControl";
            Size = new Size(533, 154);
            ((System.ComponentModel.ISupportInitialize)picFoodImage).EndInit();
            ((System.ComponentModel.ISupportInitialize)numQuantity).EndInit();
            panelContent.ResumeLayout(false);
            panelContent.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
    }
}
