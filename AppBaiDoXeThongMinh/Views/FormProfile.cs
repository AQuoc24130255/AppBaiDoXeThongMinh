using System;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using AppBaiDoXeThongMinh.database;
using AppBaiDoXeThongMinh.Models;

namespace AppBaiDoXeThongMinh.Views
{
    public partial class FormProfile : Form
    {
        private readonly AppDbContext _db;
        private readonly int _currentUserId;
        private User? _currentUser;
        private Shift? _activeShift;
        private readonly CheckBox _chkShowPassword = new();

        public FormProfile(User loggedInUser) : this(loggedInUser.UserId)
        {
        }

        public FormProfile(int currentUserId = 1)
        {
            InitializeComponent();
            SetupShowPasswordControl();

            _db = new AppDbContext();
            _currentUserId = currentUserId;

            LoadUserProfile();
            RegisterEvents();

            tmrClock.Interval = 1000;
            tmrClock.Start();
            lblClock.Text = DateTime.Now.ToString("HH:mm:ss - dd/MM/yyyy");
        }

        private void SetupShowPasswordControl()
        {
            txtOldPassword.UseSystemPasswordChar = true;
            txtNewPassword.UseSystemPasswordChar = true;

            _chkShowPassword.Text = "Hiển thị mật khẩu";
            _chkShowPassword.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            _chkShowPassword.ForeColor = Color.FromArgb(55, 65, 81);
            _chkShowPassword.AutoSize = true;
            _chkShowPassword.Location = new Point(575, 99);

            // Dịch nút Cập nhật mật khẩu xuống dưới ô tích để không bị đè
            btnChangePassword.Location = new Point(575, 127);

            grpUserInfo.Controls.Add(_chkShowPassword);

            _chkShowPassword.CheckedChanged += (s, e) =>
            {
                bool isHidden = !_chkShowPassword.Checked;
                txtOldPassword.UseSystemPasswordChar = isHidden;
                txtNewPassword.UseSystemPasswordChar = isHidden;
            };
        }

        private void RegisterEvents()
        {
            tmrClock.Tick += (s, e) => lblClock.Text = DateTime.Now.ToString("HH:mm:ss - dd/MM/yyyy");
            btnAttendance.Click += (s, e) => HandleAttendanceToggle();
            btnChangePassword.Click += (s, e) => HandleChangePassword();
        }

        private static string HashPassword(string rawPassword)
        {
            return Convert.ToHexString(
                SHA256.HashData(Encoding.UTF8.GetBytes(rawPassword)));
        }

        private void LoadUserProfile()
        {
            _currentUser = _db.Users.FirstOrDefault(u => u.UserId == _currentUserId);

            if (_currentUser == null)
            {
                MessageBox.Show("Không tìm thấy thông tin tài khoản!", "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lblFullName.Text = _currentUser.FullName;
            lblUsername.Text = _currentUser.UserName;

            string roleStr = _currentUser.Role.ToString();
            bool isGuard = roleStr.Equals("Guard", StringComparison.OrdinalIgnoreCase) ||
                           roleStr.Equals("Staff", StringComparison.OrdinalIgnoreCase) ||
                           roleStr.Equals("BaoVe", StringComparison.OrdinalIgnoreCase);

            if (isGuard)
            {
                lblRole.Text = "Nhân viên Bảo vệ";
                lblRoleBadge.Text = "BẢO VỆ";
                lblRoleBadge.BackColor = Color.FromArgb(40, 167, 69);

                pnlAttendance.Visible = true;
                this.AutoScroll = true;
                this.AutoScrollMinSize = new Size(800, 610);

                RefreshShiftState();
                LoadShiftHistory();
            }
            else
            {
                lblRole.Text = "Quản trị viên (Admin)";
                lblRoleBadge.Text = "ADMIN";
                lblRoleBadge.BackColor = Color.FromArgb(0, 102, 204);

                pnlAttendance.Visible = false;
                this.AutoScroll = false;
                this.ClientSize = new Size(820, 275);
            }
        }

        private void HandleChangePassword()
        {
            if (_currentUser == null)
            {
                MessageBox.Show("Không xác định được tài khoản đang đăng nhập!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string oldPass = txtOldPassword.Text;
            string newPass = txtNewPassword.Text;

            if (string.IsNullOrWhiteSpace(oldPass) || string.IsNullOrWhiteSpace(newPass))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ mật khẩu cũ và mật khẩu mới!", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (newPass.Length < 4)
            {
                MessageBox.Show("Mật khẩu mới phải có ít nhất 4 ký tự!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNewPassword.Focus();
                return;
            }

            string oldPassHash = HashPassword(oldPass);
            if (!string.Equals(_currentUser.PasswordHash, oldPassHash, StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Mật khẩu cũ không chính xác!", "Lỗi xác thực", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtOldPassword.SelectAll();
                txtOldPassword.Focus();
                return;
            }

            if (oldPass == newPass)
            {
                MessageBox.Show("Mật khẩu mới phải khác mật khẩu cũ!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNewPassword.SelectAll();
                txtNewPassword.Focus();
                return;
            }

            try
            {
                _currentUser.PasswordHash = HashPassword(newPass);
                _db.SaveChanges();

                txtOldPassword.Clear();
                txtNewPassword.Clear();
                _chkShowPassword.Checked = false;

                MessageBox.Show("Cập nhật mật khẩu thành công! Vui lòng dùng mật khẩu mới cho lần đăng nhập sau.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể lưu mật khẩu mới.\nChi tiết: " + ex.Message, "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RefreshShiftState()
        {
            _activeShift = _db.Shifts
                .Where(s => s.UserId == _currentUserId && s.EndDate == DateTime.MinValue)
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
                lblShiftStatus.Text = $"Đang trong ca trực (Bắt đầu: {_activeShift.StartDate:HH:mm - dd/MM/yyyy})";
                lblShiftStatus.ForeColor = Color.FromArgb(204, 41, 54);

                btnAttendance.Text = "CHẤM CÔNG TAN CA";
                btnAttendance.BackColor = Color.FromArgb(230, 126, 34);
            }
        }

        private void HandleAttendanceToggle()
        {
            if (_activeShift == null)
            {
                var newShift = new Shift
                {
                    UserId = _currentUserId,
                    StartDate = DateTime.Now,
                    EndDate = DateTime.MinValue
                };

                _db.Shifts.Add(newShift);
                _db.SaveChanges();

                MessageBox.Show($"Đã chấm công VÀO CA lúc {newShift.StartDate:HH:mm:ss}!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
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
        

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            _db.Dispose();
            base.OnFormClosed(e);
        }
        
    }
}