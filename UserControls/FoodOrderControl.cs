using CinemaApplication.DataAccess;
using CinemaApplication.Forms.Customer;
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
using static CinemaApplication.UserControls.FoodOrderItemControl;

namespace CinemaApplication.UserControls
{
    public partial class FoodOrderControl : UserControl
    {
        private readonly DataAccessLayer _dataAccessLayer;
        private readonly MovieDetailsBookingForm _parentBookingForm;
        private List<FoodItemModel> _availableFoodItems;
        private Dictionary<int, OrderFoodItemData> _currentOrderItems = new Dictionary<int, OrderFoodItemData>();
        public FoodOrderControl(DataAccessLayer dataAccessLayer, MovieDetailsBookingForm parentForm)
        {
            InitializeComponent();
            _dataAccessLayer = dataAccessLayer ?? throw new ArgumentNullException(nameof(dataAccessLayer));
            _parentBookingForm = parentForm ?? throw new ArgumentNullException(nameof(parentForm));

            RestorePreviousFoodSelection();
            LoadAvailableFoodItems();
            UpdateSummary();
        }

        private void RestorePreviousFoodSelection()
        {
            _currentOrderItems.Clear();
            if (_parentBookingForm.SelectedFoodItems != null)
            {
                foreach (var itemData in _parentBookingForm.SelectedFoodItems)
                {
                    _currentOrderItems[itemData.FoodItemId] = itemData;
                }
            }
        }
        private void LoadAvailableFoodItems()
        {
            AppUtils.WriteLine("[FoodOrderControl] Loading available food items.");
            flowLayoutPanelFoodItems.SuspendLayout();
            flowLayoutPanelFoodItems.Controls.Clear();

            _availableFoodItems = _dataAccessLayer.GetAvailableFoodItems();

            if (_availableFoodItems != null && _availableFoodItems.Any())
            {
                foreach (var foodItem in _availableFoodItems)
                {
                    FoodOrderItemControl itemControl = new FoodOrderItemControl(foodItem);
                    itemControl.QuantityChanged += FoodItem_QuantityChanged;
                    itemControl.Width = flowLayoutPanelFoodItems.ClientSize.Width - SystemInformation.VerticalScrollBarWidth - itemControl.Margin.Horizontal;
                    flowLayoutPanelFoodItems.Controls.Add(itemControl);
                }
            }
            else
            {
                Label lblNoFood = new Label { Text = "Xin lỗi, hiện không có đồ ăn/thức uống nào.", AutoSize = true, Font = new Font("Segoe UI", 10F), Padding = new Padding(10) };
                flowLayoutPanelFoodItems.Controls.Add(lblNoFood);
            }
            flowLayoutPanelFoodItems.ResumeLayout(true);
        }
        private void FoodItem_QuantityChanged(object sender, QuantityChangedEventArgs e)
        {
            FoodOrderItemControl itemControl = sender as FoodOrderItemControl;
            if (itemControl == null) return;

            FoodItemModel foodItem = itemControl.CurrentFoodItem;

            if (e.NewQuantity > 0)
            {
                if (_currentOrderItems.ContainsKey(e.FoodItemId))
                {
                    _currentOrderItems[e.FoodItemId].Quantity = e.NewQuantity;
                }
                else
                {
                    _currentOrderItems.Add(e.FoodItemId, new OrderFoodItemData
                    {
                        FoodItemId = foodItem.FoodItemId,
                        FoodItemName = foodItem.Name,
                        Quantity = e.NewQuantity,
                        PricePerItem = foodItem.Price
                    });
                }
                AppUtils.WriteLine($"[FoodOrderControl] Item '{foodItem.Name}' quantity changed to {e.NewQuantity}.");
            }
            else
            {
                if (_currentOrderItems.ContainsKey(e.FoodItemId))
                {
                    _currentOrderItems.Remove(e.FoodItemId);
                    AppUtils.WriteLine($"[FoodOrderControl] Item '{foodItem.Name}' removed from order.");
                }
            }
            UpdateSummary();
        }
        private void UpdateSummary()
        {
            decimal subtotal = 0;
            StringBuilder summaryBuilder = new StringBuilder();

            if (_currentOrderItems != null && _currentOrderItems.Any())
            {
                foreach (var itemData in _currentOrderItems.Values.OrderBy(item => item.FoodItemName))
                {
                    subtotal += itemData.Subtotal;
                    summaryBuilder.AppendLine($"{itemData.FoodItemName} - SL: x{itemData.Quantity} - {itemData.Subtotal:N0}đ");
                }
            }

            if (this.richTextBoxFoodSummaryDisplay != null) 
            {
                if (summaryBuilder.Length > 0)
                {
                    richTextBoxFoodSummaryDisplay.Text = summaryBuilder.ToString();
                }
                else
                {
                    richTextBoxFoodSummaryDisplay.Text = "Chưa chọn món nào.";
                }
            }
            else
            {
                AppUtils.WriteLine("ERROR: [FoodOrderControl] richTextBoxFoodSummaryDisplay is null.");
            }

            if (this.lblSubtotalFoodValue != null)
            {
                lblSubtotalFoodValue.Text = $"{subtotal:N0} VNĐ";
            }
            AppUtils.WriteLine($"[FoodOrderControl] Food subtotal updated: {subtotal:N0} VNĐ. Number of distinct items: {_currentOrderItems.Count}");

            _parentBookingForm.SelectedFoodItems.Clear();
            if (_currentOrderItems.Any())
            {
                _parentBookingForm.SelectedFoodItems.AddRange(_currentOrderItems.Values.Select(data => new OrderFoodItemData
                {
                    FoodItemId = data.FoodItemId,
                    FoodItemName = data.FoodItemName,
                    Quantity = data.Quantity,
                    PricePerItem = data.PricePerItem
                }));
            }
            AppUtils.WriteLine($"[FoodOrderControl] Parent form SelectedFoodItems count: {_parentBookingForm.SelectedFoodItems.Count}");
        }
        private void btnProceedToPayment_Click(object sender, EventArgs e)
        {
            AppUtils.WriteLine("[FoodOrderControl] Proceed to Payment clicked.");
            _parentBookingForm.NavigateToOrderSummary();
        }
        private void btnSkipFoodOrder_Click(object sender, EventArgs e)
        {
            AppUtils.WriteLine("[FoodOrderControl] Skip Food Order clicked.");
            _parentBookingForm.SelectedFoodItems.Clear();
            _currentOrderItems.Clear();
            UpdateSummary();
            _parentBookingForm.NavigateToOrderSummary();
        }
        private void btnBackToSeatSelection_Click(object sender, EventArgs e)
        {
            AppUtils.WriteLine("[FoodOrderControl] Back to Seat Selection clicked.");
            _parentBookingForm.NavigateBackToRoomLayout();
        }
        private void lblSubtotalFoodValue_Click(object sender, EventArgs e)
        {

        }
    }
}
