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
    public partial class AddRowInfoControl : UserControl
    {
        public event EventHandler ConfigurationChanged;

        private string _rowIdentifier = "A";
        public string RowIdentifier
        {
            get => _rowIdentifier;
            set
            {
                _rowIdentifier = value;
                lblRowIdentifierValue.Text = value;
            }
        }

        public int NumberOfSeats
        {
            get => (int)numSeatsPerRow.Value;
            set => numSeatsPerRow.Value = Math.Clamp(value, (int)numSeatsPerRow.Minimum, (int)numSeatsPerRow.Maximum);
        }

        public SeatTypeModel SelectedSeatType => cmbSeatType.SelectedItem as SeatTypeModel;
        public int SelectedSeatTypeId => (cmbSeatType.SelectedItem as SeatTypeModel)?.SeatTypeId ?? -1;


        public AddRowInfoControl()
        {
            InitializeComponent();
            numSeatsPerRow.ValueChanged += OnControlValueChanged;
            cmbSeatType.SelectedIndexChanged += OnControlValueChanged;
        }

        public void PopulateSeatTypes(List<SeatTypeModel> seatTypes, SeatTypeModel defaultType = null)
        {
            cmbSeatType.DataSource = null;
            cmbSeatType.DataSource = seatTypes;
            cmbSeatType.DisplayMember = "TypeName"; 
            cmbSeatType.ValueMember = "SeatTypeId"; 

            if (defaultType != null && seatTypes.Any(st => st.SeatTypeId == defaultType.SeatTypeId))
            {
                cmbSeatType.SelectedValue = defaultType.SeatTypeId;
            }
            else if (seatTypes.Any())
            {
                cmbSeatType.SelectedIndex = 0;
            }
        }

        private void OnControlValueChanged(object sender, EventArgs e)
        {
            ConfigurationChanged?.Invoke(this, EventArgs.Empty);
        }

        private void AddRowInfoControl_Load(object sender, EventArgs e)
        {

        }
    }
}
