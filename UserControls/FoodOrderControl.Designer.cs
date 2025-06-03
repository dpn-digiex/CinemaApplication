namespace CinemaApplication.UserControls
{
    partial class FoodOrderControl
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
        private Label lblTitle;
        private FlowLayoutPanel flowLayoutPanelFoodItems;
        private Panel panelSummary;
        private Label lblSummaryTitle;
        private Label lblSubtotalFoodText;
        private Label lblSubtotalFoodValue;
        private Button btnProceedToPayment;
        private Button btnSkipFoodOrder;
        private Button btnBackToSeatSelection;
        private RichTextBox richTextBoxFoodSummaryDisplay;
        private void InitializeComponent()
        {
            lblTitle = new Label();
            flowLayoutPanelFoodItems = new FlowLayoutPanel();
            panelSummary = new Panel();
            lblSummaryTitle = new Label();
            lblSubtotalFoodText = new Label();
            lblSubtotalFoodValue = new Label();
            btnProceedToPayment = new Button();
            btnSkipFoodOrder = new Button();
            btnBackToSeatSelection = new Button();
            richTextBoxFoodSummaryDisplay = new RichTextBox();
            panelSummary.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.Dock = DockStyle.Top;
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.Location = new Point(0, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Padding = new Padding(10);
            lblTitle.Size = new Size(880, 50);
            lblTitle.TabIndex = 2;
            lblTitle.Text = "Chọn Đồ Ăn và Thức Uống";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // flowLayoutPanelFoodItems
            // 
            flowLayoutPanelFoodItems.AutoScroll = true;
            flowLayoutPanelFoodItems.BackColor = SystemColors.Control;
            flowLayoutPanelFoodItems.Dock = DockStyle.Fill;
            flowLayoutPanelFoodItems.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanelFoodItems.Location = new Point(0, 50);
            flowLayoutPanelFoodItems.Name = "flowLayoutPanelFoodItems";
            flowLayoutPanelFoodItems.Padding = new Padding(10);
            flowLayoutPanelFoodItems.Size = new Size(564, 550);
            flowLayoutPanelFoodItems.TabIndex = 0;
            flowLayoutPanelFoodItems.WrapContents = false;
            // 
            // panelSummary
            // 
            panelSummary.BorderStyle = BorderStyle.FixedSingle;
            panelSummary.Controls.Add(lblSummaryTitle);
            panelSummary.Controls.Add(lblSubtotalFoodText);
            panelSummary.Controls.Add(lblSubtotalFoodValue);
            panelSummary.Controls.Add(btnProceedToPayment);
            panelSummary.Controls.Add(btnSkipFoodOrder);
            panelSummary.Controls.Add(btnBackToSeatSelection);
            panelSummary.Controls.Add(richTextBoxFoodSummaryDisplay);
            panelSummary.Dock = DockStyle.Right;
            panelSummary.Location = new Point(564, 50);
            panelSummary.Name = "panelSummary";
            panelSummary.Padding = new Padding(10);
            panelSummary.Size = new Size(316, 550);
            panelSummary.TabIndex = 1;
            // 
            // lblSummaryTitle
            // 
            lblSummaryTitle.AutoSize = true;
            lblSummaryTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblSummaryTitle.Location = new Point(10, 10);
            lblSummaryTitle.Name = "lblSummaryTitle";
            lblSummaryTitle.Size = new Size(144, 25);
            lblSummaryTitle.TabIndex = 0;
            lblSummaryTitle.Text = "Tóm Tắt Đồ Ăn";
            // 
            // lblSubtotalFoodText
            // 
            lblSubtotalFoodText.AutoSize = true;
            lblSubtotalFoodText.Font = new Font("Segoe UI", 9F);
            lblSubtotalFoodText.Location = new Point(13, 235);
            lblSubtotalFoodText.Name = "lblSubtotalFoodText";
            lblSubtotalFoodText.Size = new Size(117, 20);
            lblSubtotalFoodText.TabIndex = 1;
            lblSubtotalFoodText.Text = "Tổng tiền đồ ăn:";
            // 
            // lblSubtotalFoodValue
            // 
            lblSubtotalFoodValue.AutoSize = true;
            lblSubtotalFoodValue.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblSubtotalFoodValue.ForeColor = Color.DarkRed;
            lblSubtotalFoodValue.Location = new Point(13, 255);
            lblSubtotalFoodValue.Name = "lblSubtotalFoodValue";
            lblSubtotalFoodValue.Size = new Size(74, 28);
            lblSubtotalFoodValue.TabIndex = 2;
            lblSubtotalFoodValue.Text = "0 VNĐ";
            lblSubtotalFoodValue.Click += lblSubtotalFoodValue_Click;
            // 
            // btnProceedToPayment
            // 
            btnProceedToPayment.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnProceedToPayment.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnProceedToPayment.Location = new Point(166, 505);
            btnProceedToPayment.Name = "btnProceedToPayment";
            btnProceedToPayment.Size = new Size(117, 30);
            btnProceedToPayment.TabIndex = 3;
            btnProceedToPayment.Text = "Tiếp Tục >>";
            btnProceedToPayment.Click += btnProceedToPayment_Click;
            // 
            // btnSkipFoodOrder
            // 
            btnSkipFoodOrder.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnSkipFoodOrder.Font = new Font("Segoe UI", 9F);
            btnSkipFoodOrder.Location = new Point(13, 471);
            btnSkipFoodOrder.Name = "btnSkipFoodOrder";
            btnSkipFoodOrder.Size = new Size(270, 28);
            btnSkipFoodOrder.TabIndex = 4;
            btnSkipFoodOrder.Text = "Bỏ qua chọn đồ ăn";
            btnSkipFoodOrder.Click += btnSkipFoodOrder_Click;
            // 
            // btnBackToSeatSelection
            // 
            btnBackToSeatSelection.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnBackToSeatSelection.Font = new Font("Segoe UI", 9F);
            btnBackToSeatSelection.Location = new Point(13, 505);
            btnBackToSeatSelection.Name = "btnBackToSeatSelection";
            btnBackToSeatSelection.Size = new Size(147, 30);
            btnBackToSeatSelection.TabIndex = 5;
            btnBackToSeatSelection.Text = "<< Chọn Lại Ghế";
            btnBackToSeatSelection.Click += btnBackToSeatSelection_Click;
            // 
            // richTextBoxFoodSummaryDisplay
            // 
            richTextBoxFoodSummaryDisplay.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            richTextBoxFoodSummaryDisplay.BorderStyle = BorderStyle.FixedSingle;
            richTextBoxFoodSummaryDisplay.Font = new Font("Segoe UI", 9F);
            richTextBoxFoodSummaryDisplay.Location = new Point(13, 38);
            richTextBoxFoodSummaryDisplay.Name = "richTextBoxFoodSummaryDisplay";
            richTextBoxFoodSummaryDisplay.ReadOnly = true;
            richTextBoxFoodSummaryDisplay.ScrollBars = RichTextBoxScrollBars.Vertical;
            richTextBoxFoodSummaryDisplay.Size = new Size(288, 185);
            richTextBoxFoodSummaryDisplay.TabIndex = 6;
            richTextBoxFoodSummaryDisplay.Text = "";
            // 
            // FoodOrderControl
            // 
            Controls.Add(flowLayoutPanelFoodItems);
            Controls.Add(panelSummary);
            Controls.Add(lblTitle);
            Name = "FoodOrderControl";
            Size = new Size(880, 600);
            panelSummary.ResumeLayout(false);
            panelSummary.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
    }
}
