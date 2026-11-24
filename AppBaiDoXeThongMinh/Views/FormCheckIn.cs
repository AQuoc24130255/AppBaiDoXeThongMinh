using System;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using AppBaiDoXeThongMinh.database;
using AppBaiDoXeThongMinh.Models;

namespace AppBaiDoXeThongMinh.Views
{
    public partial class FormCheckIn : Form
    {
        private readonly AppDbContext _db;
        private readonly CultureInfo _viCulture = new CultureInfo("vi-VN");
        private readonly int _currentShiftId;

        public FormCheckIn(int shiftId = 1)
        {
            InitializeComponent();
            _db = new AppDbContext();
            _currentShiftId = shiftId;
            InitializeData();
            RegisterEvents();
        }
        

        private void InitializeData()
        {
            cboVehicleType.DataSource = _db.PriceConfigs.ToList();
            cboVehicleType.DisplayMember = "VehicleType";
            cboVehicleType.ValueMember = "ConfigId";

            dgvParkedVehicles.AutoGenerateColumns = false;
            LoadParkedVehicles();
            UpdateStatistics();

            tmrClock.Interval = 1000;
            tmrClock.Start();
            lblClock.Text = DateTime.Now.ToString("HH:mm:ss - dd/MM/yyyy");
            txtCardCodeIn.Focus();
        }

        private void RegisterEvents()
        {
            tmrClock.Tick += (s, e) => lblClock.Text = DateTime.Now.ToString("HH:mm:ss - dd/MM/yyyy");

            txtCardCodeIn.TextChanged += (s, e) => UpdateInputStatus();
            txtLicensePlateIn.TextChanged += (s, e) => UpdateInputStatus();

            txtCardCodeIn.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtLicensePlateIn.Focus();
                    e.SuppressKeyPress = true;
                }
            };

            txtLicensePlateIn.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    ExecuteCheckIn();
                    e.SuppressKeyPress = true;
                }
            };

            btnCheckIn.Click += (s, e) => ExecuteCheckIn();
            txtSearch.TextChanged += (s, e) => LoadParkedVehicles(txtSearch.Text);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F1)
            {
                ExecuteCheckIn();
                return true;
            }
            if (keyData == Keys.F3 && cboVehicleType.Items.Count > 0)
            {
                cboVehicleType.SelectedIndex = (cboVehicleType.SelectedIndex + 1) % cboVehicleType.Items.Count;
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void UpdateInputStatus()
        {
            bool isReady = !string.IsNullOrWhiteSpace(txtCardCodeIn.Text) &&
                           !string.IsNullOrWhiteSpace(txtLicensePlateIn.Text);
            pnlInputStatus.BackColor = isReady ? Color.FromArgb(40, 167, 69) : Color.LightGray;
        }

        private string NormalizePlate(string? plate)
        {
            if (string.IsNullOrWhiteSpace(plate)) return string.Empty;
            return Regex.Replace(plate, @"[^a-zA-Z0-9]", "").ToUpper();
        }

        private void ExecuteCheckIn()
        {
            string cardCode = txtCardCodeIn.Text.Trim().ToUpper();
            string licensePlate = txtLicensePlateIn.Text.Trim().ToUpper();

            if (string.IsNullOrEmpty(cardCode) || string.IsNullOrEmpty(NormalizePlate(licensePlate)))
            {
                MessageBox.Show("Vui lòng nhập đủ Mã thẻ và Biển số xe!", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            var vehicle = _db.Vehicles.FirstOrDefault(v => v.LicensePlate == licensePlate);
            int vehicleId = vehicle?.VehicleId??-1;
            
            bool isAlreadyParked = _db.Tickets.Any(t =>
                t.Status == TicketStatus.Inparking &&
                (t.TicketCode == cardCode || t.VehicleId == vehicleId));

            if (isAlreadyParked)
            {
                MessageBox.Show($"Thẻ [{cardCode}] hoặc biển số [{licensePlate}] đang gửi trong bãi!", "Cảnh báo trùng lặp", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCardCodeIn.SelectAll();
                txtCardCodeIn.Focus();
                return;
            }

            var selectedPrice = cboVehicleType.SelectedItem as PriceConfig;
            if (selectedPrice == null) return;

            
            if (vehicle == null)
            {
                vehicle = new Vehicle
                {
                    LicensePlate = licensePlate,
                    VehicleType = selectedPrice.VehicleType
                };
                _db.Vehicles.Add(vehicle);
                _db.SaveChanges();
            }

            bool hasMonthlyPass = _db.MonthlySubscribers.Any(m =>
                m.LicensePlate == licensePlate && m.EndDate >= DateTime.Now && m.IsActive);

            var freeSlot = _db.ParkingSlots.FirstOrDefault(s =>
                !s.IsOccupied && s.AllowedVehicleType == selectedPrice.VehicleType);

            if (freeSlot != null)
            {
                freeSlot.IsOccupied = true;
                freeSlot.CurrentVehicleID = vehicle.VehicleId;
            }

            var newTicket = new Ticket
            {   TicketCode = cardCode,
                VehicleId = vehicle.VehicleId,
                PriceConfigId = selectedPrice.ConfigId,
                ParkingSlotId = freeSlot?.SlotId,
                EntryTime = DateTime.Now,
                Status = TicketStatus.Inparking,
                IsMonthly = hasMonthlyPass
            };

            _db.Tickets.Add(newTicket);
            _db.SaveChanges();

            LoadParkedVehicles(txtSearch.Text);
            UpdateStatistics();

            txtCardCodeIn.Clear();
            txtLicensePlateIn.Clear();
            txtCardCodeIn.Focus();
        }

        private void LoadParkedVehicles(string keyword = "")
        {
            var query = _db.Tickets
                .Where(t => t.Status == TicketStatus.Inparking)
                .OrderByDescending(t => t.EntryTime)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                string key = keyword.Trim().ToUpper();
                query = query.Where(t => t.TicketCode.Contains(key) || t.Vehicle.LicensePlate.Contains(key));
            }

            dgvParkedVehicles.DataSource = query.Select(t => new
            {
                t.TicketId,
                t.TicketCode,
                t.Vehicle.LicensePlate,
                VehicleType = t.Vehicle != null ? (VehicleType?)t.Vehicle.VehicleType : null,
                t.EntryTime
            })
            .AsEnumerable()
            .Select(t => new
            {
                Id = t.TicketId,
                CardCode = t.TicketCode,
                t.LicensePlate,
                VehicleType = VehicleName(t.VehicleType),
                CheckInTime = t.EntryTime.ToString("dd/MM/yyyy HH:mm")
            })
            .ToList();
        }

        private void UpdateStatistics()
        {
            int parkedCount = _db.Tickets.Count(t => t.Status == TicketStatus.Inparking);
            decimal todayRevenue = _db.Invoices
                .Where(i => i.PaymentDate.Date == DateTime.Today)
                .Sum(i => (decimal?)i.TotalAmount) ?? 0m;

            lblStats.Text = string.Format(_viCulture, "Đang gửi: {0} xe | Doanh thu: {1:N0} đ", parkedCount, todayRevenue);
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            _db.Dispose();
            base.OnFormClosed(e);
        }

        private static string VehicleName(VehicleType? type) =>
            type == VehicleType.Car ? "Ô tô" : type == VehicleType.Motorbike ? "Xe máy" : "";
    }
}