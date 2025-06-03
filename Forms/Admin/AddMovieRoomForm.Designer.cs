namespace CinemaApplication.Forms.Admin
{
    partial class AddMovieRoomForm
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
        private void InitializeComponent()
        {
            addRowLayoutPanel = new FlowLayoutPanel();
            label1 = new Label();
            panel1 = new Panel();
            btnSave = new Button();
            btnRemoveRow = new Button();
            btnAddRow = new Button();
            lbLayout = new Label();
            txtRoomName = new TextBox();
            label2 = new Label();
            previewRoomLayoutPanel = new FlowLayoutPanel();
            addRowLayoutPanel.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // addRowLayoutPanel
            // 
            addRowLayoutPanel.Controls.Add(label1);
            addRowLayoutPanel.Controls.Add(panel1);
            addRowLayoutPanel.Dock = DockStyle.Left;
            addRowLayoutPanel.FlowDirection = FlowDirection.TopDown;
            addRowLayoutPanel.Location = new Point(0, 0);
            addRowLayoutPanel.Name = "addRowLayoutPanel";
            addRowLayoutPanel.Size = new Size(540, 634);
            addRowLayoutPanel.TabIndex = 0;
            addRowLayoutPanel.WrapContents = false;
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(537, 38);
            label1.TabIndex = 0;
            label1.Text = "Phòng chiếu mới";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnSave);
            panel1.Controls.Add(btnRemoveRow);
            panel1.Controls.Add(btnAddRow);
            panel1.Controls.Add(lbLayout);
            panel1.Controls.Add(txtRoomName);
            panel1.Controls.Add(label2);
            panel1.Location = new Point(3, 41);
            panel1.Name = "panel1";
            panel1.Size = new Size(537, 123);
            panel1.TabIndex = 1;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.LightGreen;
            btnSave.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSave.Location = new Point(386, 76);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(114, 29);
            btnSave.TabIndex = 5;
            btnSave.Text = "Lưu";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSaveRoom_Click;
            // 
            // btnRemoveRow
            // 
            btnRemoveRow.Location = new Point(272, 76);
            btnRemoveRow.Name = "btnRemoveRow";
            btnRemoveRow.Size = new Size(108, 29);
            btnRemoveRow.TabIndex = 4;
            btnRemoveRow.Text = "Xóa hàng (-)";
            btnRemoveRow.UseVisualStyleBackColor = true;
            btnRemoveRow.Click += btnRemoveRow_Click;
            // 
            // btnAddRow
            // 
            btnAddRow.Location = new Point(148, 76);
            btnAddRow.Name = "btnAddRow";
            btnAddRow.Size = new Size(118, 29);
            btnAddRow.TabIndex = 3;
            btnAddRow.Text = "Thêm hàng (+)";
            btnAddRow.UseVisualStyleBackColor = true;
            btnAddRow.Click += btnAddRow_Click;
            // 
            // lbLayout
            // 
            lbLayout.AutoSize = true;
            lbLayout.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbLayout.Location = new Point(18, 80);
            lbLayout.Name = "lbLayout";
            lbLayout.Size = new Size(124, 20);
            lbLayout.TabIndex = 2;
            lbLayout.Text = "Bố cục rạp phim:";
            // 
            // txtRoomName
            // 
            txtRoomName.Location = new Point(106, 14);
            txtRoomName.Name = "txtRoomName";
            txtRoomName.Size = new Size(394, 27);
            txtRoomName.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(18, 17);
            label2.Name = "label2";
            label2.Size = new Size(82, 20);
            label2.TabIndex = 0;
            label2.Text = "Tên phòng:";
            // 
            // previewRoomLayoutPanel
            // 
            previewRoomLayoutPanel.BackColor = SystemColors.InactiveCaption;
            previewRoomLayoutPanel.Dock = DockStyle.Fill;
            previewRoomLayoutPanel.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            previewRoomLayoutPanel.ForeColor = SystemColors.ActiveCaptionText;
            previewRoomLayoutPanel.Location = new Point(540, 0);
            previewRoomLayoutPanel.Name = "previewRoomLayoutPanel";
            previewRoomLayoutPanel.Size = new Size(468, 634);
            previewRoomLayoutPanel.TabIndex = 1;
            previewRoomLayoutPanel.WrapContents = false;
            // 
            // AddMovieRoomForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1008, 634);
            Controls.Add(previewRoomLayoutPanel);
            Controls.Add(addRowLayoutPanel);
            Name = "AddMovieRoomForm";
            Text = "Thêm phòng chiếu";
            Load += AddMovieRoomForm_Load;
            addRowLayoutPanel.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel addRowLayoutPanel;
        private FlowLayoutPanel previewRoomLayoutPanel;
        private Label label1;
        private Panel panel1;
        private Label label2;
        private TextBox txtRoomName;
        private Label lbLayout;
        private Button btnAddRow;
        private Button btnRemoveRow;
        private Button btnSave;
    }
}