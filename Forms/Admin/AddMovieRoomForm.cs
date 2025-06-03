using CinemaApplication.DataAccess;
using CinemaApplication.Enums;
using CinemaApplication.Models;
using CinemaApplication.UserControls;
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
    public partial class AddMovieRoomForm : Form
    {
        private DataAccessLayer _dataAccessLayer;
        private List<SeatTypeModel> _availableSeatTypes;
        private List<AddRowInfoControl> _rowControls = new List<AddRowInfoControl>();

        // Constants for drawing preview
        private const int SEAT_SIZE = 20; // Kích thước ghế
        private const int SEAT_MARGIN = 5;  // Khoảng cách giữa các ghế
        private const int ROW_MARGIN = 10;  // Khoảng cách giữa các hàng
        private const int PREVIEW_PADDING = 20; // Padding cho panel preview
        public AddMovieRoomForm(DataAccessLayer dataAccessLayerRef)
        {
            InitializeComponent();
            _dataAccessLayer = dataAccessLayerRef;
            LoadSeatTypes();
            InitializeDefaultRows();
            previewRoomLayoutPanel.Paint += PreviewRoomLayoutPanel_Paint;
        }

        private void LoadSeatTypes()
        {
            if (_dataAccessLayer == null) return;
            _availableSeatTypes = _dataAccessLayer.GetAllSeatTypes();
            if (_availableSeatTypes == null || !_availableSeatTypes.Any())
            {
                MessageBox.Show("Không thể tải danh sách loại ghế. Vui lòng cấu hình loại ghế trước.", "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btnSave.Enabled = false;
                btnAddRow.Enabled = false;
            }
        }

        private void InitializeDefaultRows(int numberOfRows = 1) // Bắt đầu với 1 hàng
        {
            for (int i = 0; i < numberOfRows; i++)
            {
                AddNewRowControl();
            }
            UpdateRowIdentifiers();
            previewRoomLayoutPanel.Invalidate();
        }

        private char GetNextRowIdentifier()
        {
            if (!_rowControls.Any()) return 'A';
            // Lấy ký tự cuối cùng và tăng lên 1
            char lastIdentifier = _rowControls.Last().RowIdentifier.FirstOrDefault();
            if (char.IsLetter(lastIdentifier))
            {
                return (char)(lastIdentifier + 1);
            }
            return (char)('A' + _rowControls.Count);
        }

        private void AddNewRowControl()
        {
            if (_availableSeatTypes == null || !_availableSeatTypes.Any())
            {
                MessageBox.Show("Chưa có loại ghế nào được định nghĩa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            AddRowInfoControl newRowCtrl = new AddRowInfoControl
            {
                Width = addRowLayoutPanel.ClientSize.Width - 10 // Trừ padding/scroll bar
            };
            newRowCtrl.PopulateSeatTypes(_availableSeatTypes, _availableSeatTypes.FirstOrDefault()); // Default loại ghế đầu tiên
            newRowCtrl.ConfigurationChanged += RowControl_ConfigurationChanged;

            _rowControls.Add(newRowCtrl);
            addRowLayoutPanel.Controls.Add(newRowCtrl); // Thêm vào FlowLayoutPanel
            UpdateRowIdentifiers();
            previewRoomLayoutPanel.Invalidate(); // Yêu cầu vẽ lại preview
        }

        private void RemoveLastRowControl()
        {
            if (_rowControls.Any())
            {
                AddRowInfoControl lastRow = _rowControls.Last();
                lastRow.ConfigurationChanged -= RowControl_ConfigurationChanged;
                addRowLayoutPanel.Controls.Remove(lastRow);
                _rowControls.Remove(lastRow);
                lastRow.Dispose();
                UpdateRowIdentifiers();
                previewRoomLayoutPanel.Invalidate();
            }
        }

        private void UpdateRowIdentifiers()
        {
            char currentIdChar = 'A';
            foreach (var rowCtrl in _rowControls)
            {
                rowCtrl.RowIdentifier = currentIdChar.ToString();
                currentIdChar++;
            }
        }


        private void RowControl_ConfigurationChanged(object sender, EventArgs e)
        {
            previewRoomLayoutPanel.Invalidate(); // Yêu cầu vẽ lại preview khi có thay đổi
        }

        private void PreviewRoomLayoutPanel_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(previewRoomLayoutPanel.BackColor); // Xóa bản vẽ cũ

            if (!_rowControls.Any()) return;

            int currentY = PREVIEW_PADDING; // Vị trí Y bắt đầu vẽ hàng đầu tiên

            foreach (AddRowInfoControl rowCtrl in _rowControls)
            {
                if (rowCtrl.SelectedSeatType == null) continue; // Bỏ qua nếu chưa chọn loại ghế

                int numberOfSeats = rowCtrl.NumberOfSeats;
                Color seatColor = AppUtils.GetColorForSeatType(rowCtrl.SelectedSeatType.TypeName);
                Brush seatBrush = new SolidBrush(seatColor);

                int currentX = PREVIEW_PADDING; // Vị trí X bắt đầu vẽ ghế đầu tiên của hàng

                // Vẽ nhãn hàng (ví dụ: "Hàng A:")
                TextRenderer.DrawText(g, $"Hàng {rowCtrl.RowIdentifier}:", this.Font,
                                      new Point(PREVIEW_PADDING / 2, currentY + (SEAT_SIZE / 2) - (this.Font.Height / 2)),
                                      Color.White);
                currentX += TextRenderer.MeasureText($"Hàng {rowCtrl.RowIdentifier}: ", this.Font).Width;


                for (int i = 0; i < numberOfSeats; i++)
                {
                    Rectangle seatRect = new Rectangle(currentX, currentY, SEAT_SIZE, SEAT_SIZE);
                    g.FillRectangle(seatBrush, seatRect);
                    g.DrawRectangle(Pens.Black, seatRect);

                    // TextRenderer.DrawText(g, (i + 1).ToString(), this.Font, seatRect, Color.Black, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
                    currentX += SEAT_SIZE + SEAT_MARGIN;
                }
                seatBrush.Dispose();
                currentY += SEAT_SIZE + ROW_MARGIN; // Chuyển sang hàng tiếp theo
            }
        }


        private void btnAddRow_Click(object sender, EventArgs e)
        {
            AddNewRowControl();
        }

        private void btnRemoveRow_Click(object sender, EventArgs e)
        {
            RemoveLastRowControl();
        }

        private void btnSaveRoom_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtRoomName.Text))
            {
                MessageBox.Show("Vui lòng nhập tên phòng.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtRoomName.Focus();
                return;
            }

            if (!_rowControls.Any())
            {
                MessageBox.Show("Vui lòng thêm ít nhất một hàng ghế.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            CinemaRoomModel newRoom = new CinemaRoomModel
            {
                RoomName = txtRoomName.Text.Trim(),
                Status = StatusGeneralEnum.active.ToString(),
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            int newRoomId = _dataAccessLayer.AddCinemaRoom(newRoom);

            if (newRoomId <= 0)
            {
                MessageBox.Show("Không thể lưu thông tin phòng. Vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            AppUtils.WriteLine($"Phòng mới được tạo với ID: {newRoomId}");

            // 2. Tạo và lưu danh sách SeatModel
            List<SeatModel> seatsToSave = new List<SeatModel>();
            foreach (AddRowInfoControl rowCtrl in _rowControls)
            {
                if (rowCtrl.SelectedSeatType == null) continue;

                for (int i = 0; i < rowCtrl.NumberOfSeats; i++)
                {
                    SeatModel seat = new SeatModel
                    {
                        RoomId = newRoomId,
                        SeatTypeId = rowCtrl.SelectedSeatTypeId,
                        RowIdentifier = rowCtrl.RowIdentifier, // Ví dụ: "A", "B"
                        SeatNumberInRow = (i + 1).ToString(), // Ví dụ: "1", "2", ...
                        IsActive = true
                    };
                    seatsToSave.Add(seat);
                }
            }

            if (seatsToSave.Any())
            {
                bool seatsSaved = _dataAccessLayer.AddSeats(seatsToSave);
                if (seatsSaved)
                {
                    MessageBox.Show($"Phòng '{newRoom.RoomName}' và sơ đồ ghế đã được lưu thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Lưu thông tin phòng thành công, nhưng đã có lỗi khi lưu sơ đồ ghế.", "Lỗi một phần", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show($"Phòng '{newRoom.RoomName}' đã được lưu. Không có ghế nào được cấu hình để lưu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void AddMovieRoomForm_Load(object sender, EventArgs e)
        {

        }
    }
}
