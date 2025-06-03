namespace CinemaApplication.UserControls
{
    partial class AddRowInfoControl
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
        private System.Windows.Forms.Label lblRowIdentifierText;
        private System.Windows.Forms.Label lblRowIdentifierValue;
        private System.Windows.Forms.Label lblNumberOfSeatsText;
        private System.Windows.Forms.NumericUpDown numSeatsPerRow;
        private System.Windows.Forms.Label lblSeatTypeText;
        private System.Windows.Forms.ComboBox cmbSeatType;
        private void InitializeComponent()
        {
            lblRowIdentifierText = new Label();
            lblRowIdentifierValue = new Label();
            lblNumberOfSeatsText = new Label();
            numSeatsPerRow = new NumericUpDown();
            lblSeatTypeText = new Label();
            cmbSeatType = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)numSeatsPerRow).BeginInit();
            SuspendLayout();
            // 
            // lblRowIdentifierText
            // 
            lblRowIdentifierText.AutoSize = true;
            lblRowIdentifierText.Location = new Point(4, 9);
            lblRowIdentifierText.Margin = new Padding(4, 0, 4, 0);
            lblRowIdentifierText.Name = "lblRowIdentifierText";
            lblRowIdentifierText.Size = new Size(48, 20);
            lblRowIdentifierText.TabIndex = 0;
            lblRowIdentifierText.Text = "Hàng:";
            // 
            // lblRowIdentifierValue
            // 
            lblRowIdentifierValue.AutoSize = true;
            lblRowIdentifierValue.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblRowIdentifierValue.Location = new Point(51, 11);
            lblRowIdentifierValue.Margin = new Padding(4, 0, 4, 0);
            lblRowIdentifierValue.Name = "lblRowIdentifierValue";
            lblRowIdentifierValue.Size = new Size(18, 17);
            lblRowIdentifierValue.TabIndex = 1;
            lblRowIdentifierValue.Text = "A";
            // 
            // lblNumberOfSeatsText
            // 
            lblNumberOfSeatsText.AutoSize = true;
            lblNumberOfSeatsText.Location = new Point(93, 9);
            lblNumberOfSeatsText.Margin = new Padding(4, 0, 4, 0);
            lblNumberOfSeatsText.Name = "lblNumberOfSeatsText";
            lblNumberOfSeatsText.Size = new Size(102, 20);
            lblNumberOfSeatsText.TabIndex = 2;
            lblNumberOfSeatsText.Text = "Số ghế (1-10):";
            // 
            // numSeatsPerRow
            // 
            numSeatsPerRow.Location = new Point(207, 6);
            numSeatsPerRow.Margin = new Padding(4, 5, 4, 5);
            numSeatsPerRow.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            numSeatsPerRow.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numSeatsPerRow.Name = "numSeatsPerRow";
            numSeatsPerRow.Size = new Size(60, 27);
            numSeatsPerRow.TabIndex = 3;
            numSeatsPerRow.TextAlign = HorizontalAlignment.Center;
            numSeatsPerRow.Value = new decimal(new int[] { 8, 0, 0, 0 });
            // 
            // lblSeatTypeText
            // 
            lblSeatTypeText.AutoSize = true;
            lblSeatTypeText.Location = new Point(280, 9);
            lblSeatTypeText.Margin = new Padding(4, 0, 4, 0);
            lblSeatTypeText.Name = "lblSeatTypeText";
            lblSeatTypeText.Size = new Size(69, 20);
            lblSeatTypeText.TabIndex = 4;
            lblSeatTypeText.Text = "Loại ghế:";
            // 
            // cmbSeatType
            // 
            cmbSeatType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSeatType.FormattingEnabled = true;
            cmbSeatType.Location = new Point(353, 5);
            cmbSeatType.Margin = new Padding(4, 5, 4, 5);
            cmbSeatType.Name = "cmbSeatType";
            cmbSeatType.Size = new Size(159, 28);
            cmbSeatType.TabIndex = 5;
            // 
            // AddRowInfoControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(cmbSeatType);
            Controls.Add(lblSeatTypeText);
            Controls.Add(numSeatsPerRow);
            Controls.Add(lblNumberOfSeatsText);
            Controls.Add(lblRowIdentifierValue);
            Controls.Add(lblRowIdentifierText);
            Margin = new Padding(4, 5, 4, 5);
            Name = "AddRowInfoControl";
            Size = new Size(533, 43);
            Load += AddRowInfoControl_Load;
            ((System.ComponentModel.ISupportInitialize)numSeatsPerRow).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}
