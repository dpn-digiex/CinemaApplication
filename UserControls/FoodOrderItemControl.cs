using CinemaApplication.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CinemaApplication.UserControls
{
    public partial class FoodOrderItemControl : UserControl
    {
        public event EventHandler<QuantityChangedEventArgs> QuantityChanged;
        public FoodItemModel CurrentFoodItem { get; private set; }
        public int SelectedQuantity => (int)numQuantity.Value;

        public class QuantityChangedEventArgs : EventArgs
        {
            public int FoodItemId { get; }
            public int NewQuantity { get; }
            public QuantityChangedEventArgs(int foodItemId, int newQuantity)
            {
                FoodItemId = foodItemId;
                NewQuantity = newQuantity;
            }
        }
        public FoodOrderItemControl(FoodItemModel foodItem)
        {
            InitializeComponent();
            CurrentFoodItem = foodItem ?? throw new ArgumentNullException(nameof(foodItem));
            PopulateData();
            numQuantity.ValueChanged += NumQuantity_ValueChanged;
        }
        private void PopulateData()
        {
            lblFoodName.Text = CurrentFoodItem.Name;
            lblFoodPrice.Text = $"{CurrentFoodItem.Price:N0} VNĐ";
            if (lblFoodDescription != null && !string.IsNullOrWhiteSpace(CurrentFoodItem.Description))
            {
                lblFoodDescription.Text = CurrentFoodItem.Description;
            }
            else if (lblFoodDescription != null)
            {
                lblFoodDescription.Visible = false;
            }


            if (!string.IsNullOrWhiteSpace(CurrentFoodItem.ImageUrl) && picFoodImage != null)
            {
                try { picFoodImage.LoadAsync(CurrentFoodItem.ImageUrl); }
                catch { picFoodImage.Image = picFoodImage.ErrorImage; }
            }
            else if (picFoodImage != null)
            {
                picFoodImage.Image = picFoodImage.InitialImage;
            }
        }
        private void NumQuantity_ValueChanged(object sender, EventArgs e)
        {
            QuantityChanged?.Invoke(this, new QuantityChangedEventArgs(CurrentFoodItem.FoodItemId, (int)numQuantity.Value));
        }

        public void ResetQuantity()
        {
            numQuantity.Value = numQuantity.Minimum;
        }
    }
}
