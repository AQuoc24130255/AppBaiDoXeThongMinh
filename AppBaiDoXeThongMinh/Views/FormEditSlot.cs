using AppBaiDoXeThongMinh.database;
using AppBaiDoXeThongMinh.Models;
using Microsoft.EntityFrameworkCore;

namespace AppBaiDoXeThongMinh.Views;
/*24130255 Trần Anh Quốc
Quản lý chỗ đỗ xe: xem danh sách, thêm mới, xóa*/

public partial class FormEditSlot : Form
{
    public FormEditSlot()
    {
        InitializeComponent();
        SetupUi();
        Load += (_, _) => LoadSlots();
    }

    // ------------------------------------------------------------
    //  Thiết lập ban đầu
    // ------------------------------------------------------------
    private void SetupUi()
    {
        AcceptButton = btAdd;

        btAdd.Click += BtAdd_Click;
        btClear.Click += (_, _) => ClearForm();
        btDelete.Click += BtDelete_Click;
        btRefresh.Click += (_, _) => LoadSlots();
    }

    // ------------------------------------------------------------
    //  Danh sách chỗ đỗ
    // ------------------------------------------------------------
    private void LoadSlots(int? selectSlotId = null)
    {
        try
        {
            using var db = new AppDbContext();

            // Kết hợp bảng ParkingSlots với Vehicles để lấy biển số xe đang đỗ (nếu có)
            var slots = (from s in db.ParkingSlots.AsNoTracking()
                         join v in db.Vehicles.AsNoTracking() on s.CurrentVehicleID equals v.VehicleId into vGroup
                         from vehicle in vGroup.DefaultIfEmpty()
                         orderby s.Zone, s.SlotName
                         select new
                         {
                             s.SlotId,
                             s.SlotName,
                             s.Zone,
                             s.AllowedVehicleType,
                             s.IsOccupied,
                             LicensePlate = vehicle != null ? vehicle.LicensePlate : string.Empty
                         }).ToList();

            dgvSlots.Rows.Clear();
            foreach (var s in slots)
            {
                int index = dgvSlots.Rows.Add(
                    s.SlotId,
                    s.SlotName,
                    s.Zone,
                    VehicleTypeName(s.AllowedVehicleType),
                    s.IsOccupied,
                    s.LicensePlate);

                var row = dgvSlots.Rows[index];
                row.Tag = s.SlotId;

                // Tô màu nhẹ các ô đã có xe đỗ để dễ quan sát
                if (s.IsOccupied)
                {
                    row.DefaultCellStyle.BackColor = Color.FromArgb(255, 245, 245);
                }

                if (selectSlotId == s.SlotId)
                {
                    dgvSlots.ClearSelection();
                    row.Selected = true;
                    dgvSlots.CurrentCell = row.Cells[0];
                }
            }
        }
        catch (Exception ex)
        {
            ShowError("Không thể tải danh sách chỗ đỗ", ex);
        }
    }

    // ------------------------------------------------------------
    //  Thêm chỗ đỗ mới
    // ------------------------------------------------------------
    private void BtAdd_Click(object? sender, EventArgs e)
    {
        string slotName = txtSlotName.Text.Trim();
        string zone = txtZone.Text.Trim();

        // --- Kiểm tra dữ liệu nhập ---
        if (slotName.Length == 0)
        {
            Warn("Vui lòng nhập tên chỗ đỗ.", txtSlotName);
            return;
        }
        if (slotName.Length > 20)
        {
            Warn("Tên chỗ đỗ tối đa 20 ký tự.", txtSlotName);
            return;
        }
        if (zone.Length == 0)
        {
            Warn("Vui lòng nhập khu vực.", txtZone);
            return;
        }
        if (zone.Length > 20)
        {
            Warn("Tên khu vực tối đa 20 ký tự.", txtZone);
            return;
        }

        try
        {
            using var db = new AppDbContext();

            // Kiểm tra trùng tên chỗ đỗ trong cùng một khu vực (không phân biệt hoa/thường)
            string loweredSlot = slotName.ToLower();
            string loweredZone = zone.ToLower();

            bool isDuplicate = db.ParkingSlots.Any(s =>
                s.SlotName.ToLower() == loweredSlot &&
                s.Zone.ToLower() == loweredZone);

            if (isDuplicate)
            {
                Warn($"Chỗ đỗ \"{slotName}\" đã tồn tại trong khu vực \"{zone}\".", txtSlotName);
                return;
            }

            var slot = new ParkingSlot
            {
                SlotName = slotName,
                Zone = zone,
                AllowedVehicleType = cbAllowedVehicleType.SelectedIndex == 0
                    ? VehicleType.Motorbike
                    : VehicleType.Car,
                IsOccupied = false,
                CurrentVehicleID = null
            };

            db.ParkingSlots.Add(slot);
            db.SaveChanges();

            ClearForm();
            LoadSlots(slot.SlotId);
            MessageBox.Show($"Đã thêm chỗ đỗ \"{slotName}\" tại khu vực \"{zone}\".", "Thành công",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            ShowError("Không thể thêm chỗ đỗ", ex);
        }
    }

    // ------------------------------------------------------------
    //  Xóa chỗ đỗ
    // ------------------------------------------------------------
    private void BtDelete_Click(object? sender, EventArgs e)
    {
        if (dgvSlots.CurrentRow?.Tag is not int id)
        {
            MessageBox.Show("Vui lòng chọn một chỗ đỗ trong danh sách.", "Chưa chọn chỗ đỗ",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        try
        {
            using var db = new AppDbContext();
            var slot = db.ParkingSlots.FirstOrDefault(s => s.SlotId == id);
            if (slot == null)
            {
                LoadSlots();
                return;
            }

            // Không cho xóa nếu đang có xe đỗ tại vị trí này
            if (slot.IsOccupied || slot.CurrentVehicleID != null)
            {
                MessageBox.Show(
                    $"Chỗ đỗ \"{slot.SlotName}\" (Khu vực {slot.Zone}) hiện đang có xe đỗ nên không thể xóa.",
                    "Không thể xóa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var answer = MessageBox.Show(
                $"Xóa chỗ đỗ \"{slot.SlotName}\" thuộc khu vực \"{slot.Zone}\"?\nThao tác này không thể hoàn tác.",
                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (answer != DialogResult.Yes) return;

            db.ParkingSlots.Remove(slot);
            db.SaveChanges();
            LoadSlots();
        }
        catch (DbUpdateException ex)
        {
            ShowError("Không thể xóa chỗ đỗ (dữ liệu đang được tham chiếu ở nơi khác)", ex);
        }
        catch (Exception ex)
        {
            ShowError("Không thể xóa chỗ đỗ", ex);
        }
    }

    // ------------------------------------------------------------
    //  Hàm hỗ trợ
    // ------------------------------------------------------------
    private void ClearForm()
    {
        txtSlotName.Clear();
        txtZone.Clear();
        cbAllowedVehicleType.SelectedIndex = 0;
        txtSlotName.Focus();
    }

    private static string VehicleTypeName(VehicleType type) =>
        type == VehicleType.Motorbike ? "Xe Máy" : "Xe Ô Tô";

    private static void Warn(string message, System.Windows.Forms.Control focus)
    {
        MessageBox.Show(message, "Dữ liệu chưa hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        focus.Focus();
    }

    private static void ShowError(string message, Exception ex)
    {
        MessageBox.Show($"{message}.\n\nChi tiết: {ex.Message}",
            "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}
