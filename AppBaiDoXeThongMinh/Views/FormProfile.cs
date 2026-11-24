using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using AppBaiDoXeThongMinh.database;
using AppBaiDoXeThongMinh.Models;

namespace AppBaiDoXeThongMinh.Views
{
    public partial class FormProfile : Form
    {
        private readonly AppDbContext _db;
        private readonly int _currentUserId;
        private User _currentUser;
        private Shift _activeShift;

        public FormProfile(User currentUser)
        {
            InitializeComponent();
            _db = new AppDbContext();
            _currentUserId = currentUser.UserId;

            LoadUserProfile();
            RegisterEvents();

            tmrClock.Interval = 1000;
            tmrClock.Start();
            lblClock.Text = DateTime.Now.ToString("HH:mm:ss - dd/MM/yyyy");
        }

        private void RegisterEvents()
        {
            tmrClock.Tick += (s, e) => lblClock.Text = DateTime.Now.ToString("HH:mm:ss - dd/MM/yyyy");
            btnAttendance.Click += (s, e) => HandleAttendanceToggle();
            btnChangePassword.Click += (s, e) => HandleChangePassword();
        }

        private void LoadUserProfile()
        {
            // Tìm user đang đăng nhập (nếu khóa chính của bạn là Id thay vì UserId thì đổi u.UserId thành u.Id)
            _currentUser = _db.Users.FirstOrDefault(u => u.UserId == _currentUserId);

            if (_currentUser == null)
            {
                MessageBox.Show("Không tìm thấy thông tin tài khoản!", "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lblFullName.Text = _currentUser.FullName;
            lblUsername.Text = _currentUser.UserName;

            // Chuyển Role sang chuỗi để tương thích cả kiểu string lẫn enum (Admin / Guard / Staff / BaoVe)
            string roleStr = _currentUser.Role.ToString();
            bool isGuard = roleStr.Equals("Guard", StringComparison.OrdinalIgnoreCase) ||
                           roleStr.Equals("Staff", StringComparison.OrdinalIgnoreCase) ||
                           roleStr.Equals("BaoVe", StringComparison.OrdinalIgnoreCase);

            if (isGuard)
            {
                lblRole.Text = "Nhân viên Bảo vệ";
                lblRoleBadge.Text = "BẢO VỆ";
                lblRoleBadge.BackColor = Color.FromArgb(40, 167, 69);

                // Hiển thị khu vực chấm công
                pnlAttendance.Visible = true;
                this.ClientSize = new Size(820, 600);

                RefreshShiftState();
                LoadShiftHistory();
            }
            else
            {
                lblRole.Text = "Quản trị viên (Admin)";
                lblRoleBadge.Text = "ADMIN";
                lblRoleBadge.BackColor = Color.FromArgb(0, 102, 204);

                // Ẩn khu vực chấm công và thu gọn form cho Admin
                pnlAttendance.Visible = false;
                this.ClientSize = new Size(820, 275);
            }
        }

        private void RefreshShiftState()
        {
            // Kiểm tra ca trực chưa kết thúc (EndTime == null) của bảo vệ này
            _activeShift = _db.Shifts
                .Where(s => s.UserId == _currentUserId && s.EndDate == null)
                .OrderByDescending(s => s.StartDate)
                .FirstOrDefault();

            if (_activeShift == null)
            {
                lblShiftStatus.Text = "Trạng thái: Chưa vào ca trực hôm nay";
                lblShiftStatus.ForeColor = Color.FromArgb(52, 58, 64);

                btnAttendance.Text = "CHẤM CÔNG VÀO CA";
                btnAttendance.BackColor = Color.FromArgb(40, 167, 69);
            }
            else
            {
                lblShiftStatus.Text = $"Đang trong ca trực (Bắt đầu lúc: {_activeShift.StartDate:HH:mm - dd/MM/yyyy})";
                lblShiftStatus.ForeColor = Color.FromArgb(204, 41, 54);

                btnAttendance.Text = "CHẤM CÔNG TAN CA";
                btnAttendance.BackColor = Color.FromArgb(230, 126, 34);
            }
        }

        private void HandleAttendanceToggle()
        {
            if (_activeShift == null)
            {
                // Bắt đầu ca trực mới
                var newShift = new Shift
                {
                    UserId = _currentUserId,
                    StartDate = DateTime.Now,
                    EndDate = null
                };

                _db.Shifts.Add(newShift);
                _db.SaveChanges();

                MessageBox.Show($"Đã chấm công VÀO CA lúc {newShift.StartDate:HH:mm:ss}!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Kết thúc ca trực hiện tại
                var confirm = MessageBox.Show(
                    "Xác nhận kết thúc ca trực và chấm công tan ca?",
                    "Xác nhận tan ca",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirm != DialogResult.Yes) return;

                _activeShift.EndDate = DateTime.Now;
                _db.SaveChanges();

                TimeSpan worked = _activeShift.EndDate.Value - _activeShift.StartDate;
                MessageBox.Show(
                    $"Đã chấm công TAN CA lúc {_activeShift.EndDate:HH:mm:ss}!\nTổng thời gian trực: {(int)worked.TotalHours} giờ {worked.Minutes} phút.",
                    "Hoàn tất ca trực",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }

            RefreshShiftState();
            LoadShiftHistory();
        }

        private void LoadShiftHistory()
        {
            var shifts = _db.Shifts
                .Where(s => s.UserId == _currentUserId)
                .OrderByDescending(s => s.StartDate)
                .Take(20)
                .ToList();

            dgvShiftHistory.DataSource = shifts.Select(s =>
            {
                string durationText = "Đang trực...";
                if (s.EndDate.HasValue)
                {
                    TimeSpan span = s.EndDate.Value - s.StartDate;
                    durationText = $"{(int)span.TotalHours} giờ {span.Minutes} phút";
                }

                return new
                {
                    WorkDate = s.StartDate.ToString("dd/MM/yyyy"),
                    StartTime = s.StartDate.ToString("HH:mm:ss"),
                    EndTime = s.EndDate.HasValue ? s.EndDate.Value.ToString("HH:mm:ss") : "--:--:--",
                    Duration = durationText
                };
            }).ToList();
        }

        private void HandleChangePassword()
        {
            if (_currentUser == null) return;

            string oldPass = txtOldPassword.Text.Trim();
            string newPass = txtNewPassword.Text.Trim();

            if (string.IsNullOrEmpty(oldPass) || string.IsNullOrEmpty(newPass))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ mật khẩu cũ và mật khẩu mới!", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_currentUser.PasswordHash != oldPass)
            {
                MessageBox.Show("Mật khẩu cũ không chính xác!", "Lỗi xác thực", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtOldPassword.Focus();
                return;
            }

            _currentUser.PasswordHash = newPass;
            _db.SaveChanges();

            txtOldPassword.Clear();
            txtNewPassword.Clear();
            MessageBox.Show("Đổi mật khẩu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            _db.Dispose();
            base.OnFormClosed(e);
        }
    }
}