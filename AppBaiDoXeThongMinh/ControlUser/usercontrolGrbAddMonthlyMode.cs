using System.Text.RegularExpressions;
using AppBaiDoXeThongMinh.database;
using AppBaiDoXeThongMinh.Models;

namespace AppBaiDoXeThongMinh.Control;

public partial class usercontrolGrbAddMonthlyMode : UserControl
{
    public event EventHandler? TicketAdded;
    public event EventHandler? RefreshClicked;
    
    public usercontrolGrbAddMonthlyMode()
    {
        InitializeComponent();
        cbVehicleType.SelectedIndex = 0;

        btAdd.Click += BtAdd_Click;
        btClear.Click += (_, _) => ClearForm();
        btRefresh.Click += (s, e) => RefreshClicked?.Invoke(this, e);
    }
    public void ClearForm()
    {
        txtPlate.Clear();
        cbVehicleType.SelectedIndex = 0;
        txtOwnerName.Clear();
        txtPhone.Clear();
        nudMonths.Value = 1;
        nudFee.Value = 0;
        txtPlate.Focus();
    }

    private void BtAdd_Click(object? sender, EventArgs e)
    {
        string plate = txtPlate.Text.Trim().ToUpperInvariant();
        string plateKey = NormalizePlate(plate);
        var type = cbVehicleType.SelectedIndex == 1 ? VehicleType.Car : VehicleType.Motorbike;

        string ownerName = txtOwnerName.Text.Trim();
        string phone = Regex.Replace(txtPhone.Text, @"[\s.\-]", "");

        if (plateKey.Length < 4)
        {
            Warn("Vui lòng nhập biển số xe hợp lệ.", txtPlate);
            return;
        }
        if (ownerName.Length == 0)
        {
            Warn("Vé tháng bắt buộc phải có họ tên chủ xe.", txtOwnerName);
            return;
        }
        if (!Regex.IsMatch(phone, @"^\+?\d{9,12}$"))
        {
            Warn("Vé tháng bắt buộc phải có số điện thoại chủ xe hợp lệ (9–12 chữ số).", txtPhone);
            return;
        }

        try
        {
            using var db = new AppDbContext();

            // 1) Kiểm tra xe đã đăng ký khác loại xe chưa
            var vehicle = db.Vehicles.ToList().FirstOrDefault(v => NormalizePlate(v.LicensePlate) == plateKey);
            if (vehicle != null && vehicle.VehicleType != type)
            {
                Warn($"Biển số này đã đăng ký là {VehicleName(vehicle.VehicleType)}. Vui lòng chọn lại loại xe.",
                    cbVehicleType);
                return;
            }

            // 2) Không trùng với vé tháng còn hiệu lực
            DateTime today = DateTime.Today;
            bool hasActiveSub = db.MonthlySubscribers
                .Where(s => s.IsActive && s.EndDate >= today)
                .ToList()
                .Any(s => NormalizePlate(s.LicensePlate) == plateKey);
            if (hasActiveSub)
            {
                Warn("Biển số này đã có vé tháng còn hiệu lực.", txtPlate);
                return;
            }

            // 3) Lưu thông tin xe và đăng ký vé tháng
            using var tx = db.Database.BeginTransaction();

            if (vehicle == null)
            {
                vehicle = new Vehicle { LicensePlate = plate, VehicleType = type };
                db.Vehicles.Add(vehicle);
            }
            vehicle.OwerName = ownerName;
            vehicle.PhoneNumber = phone;

            db.MonthlySubscribers.Add(new MonthlySubscriber
            {
                FullName = ownerName,
                PhoneNumber = phone,
                LicensePlate = plate,
                VehicleType = type.ToString(),
                StartDate = DateTime.Today,
                EndDate = DateTime.Today.AddMonths((int)nudMonths.Value),
                IsActive = true,
                MonthlyFee = nudFee.Value
            });

            db.SaveChanges();
            tx.Commit();

            ClearForm();
            TicketAdded?.Invoke(this, EventArgs.Empty);

            MessageBox.Show(
                $"Đã đăng ký vé tháng cho xe {plate} (Chủ xe: {ownerName}).",
                "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Không thể đăng ký vé tháng.\n\nChi tiết: {ex.Message}",
                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private static string NormalizePlate(string? plate) =>
        new string((plate ?? "").Where(char.IsLetterOrDigit).ToArray()).ToUpperInvariant();

    private static string VehicleName(VehicleType? type) =>
        type == VehicleType.Car ? "Ô tô" : type == VehicleType.Motorbike ? "Xe máy" : "";

    private static void Warn(string message, System.Windows.Forms.Control focus)
    {
        MessageBox.Show(message, "Dữ liệu chưa hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        focus.Focus();
    }
}