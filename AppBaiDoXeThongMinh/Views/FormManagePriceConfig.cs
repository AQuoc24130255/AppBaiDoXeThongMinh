using AppBaiDoXeThongMinh.database;
using AppBaiDoXeThongMinh.Models;
using Microsoft.EntityFrameworkCore;

namespace AppBaiDoXeThongMinh.Views;

public partial class FormManagePriceConfig : Form
{
    private List<PriceConfig> _configs = new();
    private bool _loading;

    public FormManagePriceConfig()
    {
        InitializeComponent();
        SetupUi();
        Load += (_, _) => LoadConfigs();
    }

    private void SetupUi()
    {
        cbVehicleType.SelectedIndex = 0;

        nudConfigId.ValueChanged += (_, _) => UpdateModeLabel();
        dgvPrices.SelectionChanged += (_, _) =>
        {
            if (_loading) return;
            if (dgvPrices.CurrentRow?.Tag is int id) FillForm(id);
        };

        btSave.Click += BtSave_Click;
        btRefresh.Click += (_, _) => LoadConfigs((int)nudConfigId.Value);
    }

    private void LoadConfigs(int? selectId = null)
    {
        try
        {
            using var db = new AppDbContext();
            _configs = db.PriceConfigs.AsNoTracking().OrderBy(p => p.ConfigId).ToList();
        }
        catch (Exception ex)
        {
            ShowError("Không thể tải danh sách cấu hình giá", ex);
            return;
        }

        _loading = true;
        dgvPrices.Rows.Clear();
        foreach (var p in _configs)
        {
            int index = dgvPrices.Rows.Add(
                p.ConfigId,
                VehicleName(p.VehicleType),
                $"{p.DayPrice:N0}",
                $"{p.NightPrice:N0}",
                p.TimeUnit,
                p.NightStart.ToString(@"hh\:mm"),
                p.NightEnd.ToString(@"hh\:mm"),
                $"{p.LostTicketFee:N0}");
            dgvPrices.Rows[index].Tag = p.ConfigId;
        }
        _loading = false;

        if (_configs.Count == 0)
        {
            return;
        }

        // Chọn lại cấu hình đang xem, nếu không có thì chọn dòng đầu
        int targetId = selectId.HasValue && _configs.Any(c => c.ConfigId == selectId.Value)
            ? selectId.Value
            : _configs[0].ConfigId;

        foreach (DataGridViewRow row in dgvPrices.Rows)
        {
            if (row.Tag is int id && id == targetId)
            {
                dgvPrices.ClearSelection();
                row.Selected = true;
                dgvPrices.CurrentCell = row.Cells[0];
                break;
            }
        }
        FillForm(targetId);
    }

    private void FillForm(int configId)
    {
        var c = _configs.FirstOrDefault(x => x.ConfigId == configId);
        if (c == null) return;

        SetNud(nudConfigId, c.ConfigId);
        cbVehicleType.SelectedIndex = c.VehicleType == VehicleType.Car ? 1 : 0;
        SetNud(nudDayPrice, c.DayPrice);
        SetNud(nudNightPrice, c.NightPrice);
        SetNud(nudTimeUnit, c.TimeUnit);
        SetNud(nudLostFee, c.LostTicketFee);
        dtpNightStart.Value = ToDateTime(c.NightStart);
        dtpNightEnd.Value = ToDateTime(c.NightEnd);
        UpdateModeLabel();
    }

    private void UpdateModeLabel()
    {
        int id = (int)nudConfigId.Value;
        bool exists = _configs.Any(c => c.ConfigId == id);

        lbMode.Text = exists
            ? $"Đang chỉnh sửa cấu hình #{id}"
            : $"Sẽ TẠO MỚI cấu hình #{id}";
        lbMode.ForeColor = exists ? Color.FromArgb(25, 105, 170) : Color.FromArgb(40, 120, 60);
        btSave.Text = exists ? "Lưu thay đổi" : "Tạo cấu hình";
    }

    private void BtSave_Click(object? sender, EventArgs e)
    {
        int id = (int)nudConfigId.Value;
        bool exists = _configs.Any(c => c.ConfigId == id);
        var type = cbVehicleType.SelectedIndex == 1 ? VehicleType.Car : VehicleType.Motorbike;

        if (exists)
        {
            var answer = MessageBox.Show(
                $"Cập nhật cấu hình giá #{id}?\n" +
                "Phí của các xe đang gửi sẽ được tính theo biểu phí mới khi xe ra.",
                "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (answer != DialogResult.Yes) return;
        }

        try
        {
            var config = PriceConfig.SetPrice(
                id,
                type,
                nudDayPrice.Value,
                nudNightPrice.Value,
                (int)nudTimeUnit.Value,
                ToTimeSpan(dtpNightStart.Value),
                ToTimeSpan(dtpNightEnd.Value),
                nudLostFee.Value);

            LoadConfigs(config.ConfigId);
            MessageBox.Show(
                $"Đã cập nhật cấu hình giá #{config.ConfigId}.",
                "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex) when (ex is ArgumentException or InvalidOperationException)
        {
            MessageBox.Show(ex.Message, "Dữ liệu chưa hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        catch (Exception ex)
        {
            ShowError("Không thể lưu cấu hình giá", ex);
        }
    }

    private static void SetNud(NumericUpDown nud, decimal value) =>
        nud.Value = Math.Max(nud.Minimum, Math.Min(nud.Maximum, value));

    private static DateTime ToDateTime(TimeSpan time)
    {
        int minutes = ((int)time.TotalMinutes % 1440 + 1440) % 1440;
        return new DateTime(2000, 1, 1).AddMinutes(minutes);
    }

    private static TimeSpan ToTimeSpan(DateTime value) =>
        new TimeSpan(value.Hour, value.Minute, 0);

    private static string VehicleName(VehicleType type) =>
        type == VehicleType.Car ? "Ô tô" : "Xe máy";

    private static void ShowError(string message, Exception ex)
    {
        MessageBox.Show($"{message}.\n\nChi tiết: {ex.Message}",
            "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}