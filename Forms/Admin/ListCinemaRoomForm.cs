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
    public partial class ListCinemaRoomForm : Form
    {
        private DataAccessLayer _dataAccessLayer;
        public ListCinemaRoomForm(DataAccessLayer dataAccessLayerRef)
        {
            InitializeComponent();
            _dataAccessLayer = dataAccessLayerRef;
        }

        private void ListCinemaRoomForm_Load(object sender, EventArgs e)
        {
            SetupDataGridView();
            LoadCinemaRoomsData();
        }
        private void SetupDataGridView()
        {
            dataGridViewRooms.AutoGenerateColumns = false;
            dataGridViewRooms.Columns.Clear();

            dataGridViewRooms.Columns.Add(new DataGridViewTextBoxColumn { Name = "colSTT", HeaderText = "STT", DataPropertyName = "STT", Width = 50 });
            dataGridViewRooms.Columns.Add(new DataGridViewTextBoxColumn { Name = "colRoomId", HeaderText = "ID Phòng", DataPropertyName = "RoomId", Visible = false }); // Có thể ẩn ID nếu STT đủ
            dataGridViewRooms.Columns.Add(new DataGridViewTextBoxColumn { Name = "colRoomName", HeaderText = "Tên Phòng", DataPropertyName = "RoomName", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dataGridViewRooms.Columns.Add(new DataGridViewTextBoxColumn { Name = "colStatus", HeaderText = "Trạng Thái", DataPropertyName = "Status", Width = 100 });
            dataGridViewRooms.Columns.Add(new DataGridViewTextBoxColumn { Name = "colCreatedAt", HeaderText = "Ngày Tạo", DataPropertyName = "CreatedAt", Width = 120, DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy HH:mm" } });
            dataGridViewRooms.Columns.Add(new DataGridViewTextBoxColumn { Name = "colTotalSeats", HeaderText = "Tổng Ghế", DataPropertyName = "TotalSeats", Width = 80 });
            dataGridViewRooms.Columns.Add(new DataGridViewTextBoxColumn { Name = "colStandardSeats", HeaderText = "Ghế Standard", DataPropertyName = "StandardSeats", Width = 100 });
            dataGridViewRooms.Columns.Add(new DataGridViewTextBoxColumn { Name = "colVipSeats", HeaderText = "Ghế VIP", DataPropertyName = "VipSeats", Width = 80 });
            dataGridViewRooms.Columns.Add(new DataGridViewTextBoxColumn { Name = "colCoupleSeats", HeaderText = "Ghế Couple", DataPropertyName = "CoupleSeats", Width = 90 });

            dataGridViewRooms.AllowUserToAddRows = false;
            dataGridViewRooms.ReadOnly = true;
            dataGridViewRooms.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewRooms.MultiSelect = false;
        }

        private void LoadCinemaRoomsData()
        {
            AppUtils.WriteLine("[ListCinemaRoomForm] Loading cinema rooms data...");
            List<CinemaRoomStatsModel> roomsData = _dataAccessLayer.GetAllCinemaRoomsWithStats();

            if (roomsData != null)
            {
                dataGridViewRooms.DataSource = roomsData;
                AppUtils.WriteLine($"[ListCinemaRoomForm] Loaded {roomsData.Count} rooms.");
            }
            else
            {
                dataGridViewRooms.DataSource = null;
                MessageBox.Show("Không thể tải danh sách phòng chiếu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadCinemaRoomsData();
        }
    }
}
