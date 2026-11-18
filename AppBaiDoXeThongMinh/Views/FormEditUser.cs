using System.Security.Cryptography;
using System.Text;
using AppBaiDoXeThongMinh.database;
using AppBaiDoXeThongMinh.Models;
using Microsoft.EntityFrameworkCore;

namespace AppBaiDoXeThongMinh.Views;
/*24130255 Trần Anh Quốc
Quản lý người dùng: xem danh sách, thêm mới, xóa*/
public partial class FormEditUser : Form
{
    private readonly User? _currentUser;

    public FormEditUser()
    {
        InitializeComponent();
        SetupUi();
        Load += (_, _) => LoadUsers();
    }

    // Mở từ FormMain: truyền người dùng đang đăng nhập (để không cho tự xóa mình)
    public FormEditUser(User user) : this()
    {
        _currentUser = user;
    }

    // ------------------------------------------------------------
    //  Thiết lập ban đầu
    // ------------------------------------------------------------
    private void SetupUi()
    {
        AcceptButton = btAdd;

        chkShowPassword.CheckedChanged += (_, _) =>
        {
            txtPassword.UseSystemPasswordChar = !chkShowPassword.Checked;
            txtConfirm.UseSystemPasswordChar = !chkShowPassword.Checked;
        };

        btAdd.Click += BtAdd_Click;
        btClear.Click += (_, _) => ClearForm();
        btDelete.Click += BtDelete_Click;
        btLock.Click += BtLock_Click;
        btRefresh.Click += (_, _) => LoadUsers();
    }

    // ------------------------------------------------------------
    //  Danh sách người dùng
    // ------------------------------------------------------------
    private void LoadUsers(int? selectUserId = null)
    {
        try
        {
            using var db = new AppDbContext();
            var users = db.Users.AsNoTracking().OrderBy(u => u.UserId).ToList();

            dgvUsers.Rows.Clear();
            foreach (var u in users)
            {
                int index = dgvUsers.Rows.Add(
                    u.UserId,
                    u.UserName,
                    u.FullName,
                    RoleName(u.Role),
                    u.IsActive ? "Hoạt động" : "Đã khóa");

                var row = dgvUsers.Rows[index];
                row.Tag = u.UserId;
                if (!u.IsActive) row.DefaultCellStyle.ForeColor = Color.Gray;

                if (selectUserId == u.UserId)
                {
                    dgvUsers.ClearSelection();
                    row.Selected = true;
                    dgvUsers.CurrentCell = row.Cells[0];
                }
            }
        }
        catch (Exception ex)
        {
            ShowError("Không thể tải danh sách người dùng", ex);
        }
    }

    // ------------------------------------------------------------
    //  Thêm người dùng
    // ------------------------------------------------------------
    private void BtAdd_Click(object? sender, EventArgs e)
    {
        string userName = txtUserName.Text.Trim();
        string fullName = txtFullName.Text.Trim();
        string password = txtPassword.Text;
        string confirm = txtConfirm.Text;

        // --- Kiểm tra dữ liệu nhập ---
        if (userName.Length < 3 || userName.Any(char.IsWhiteSpace))
        {
            Warn("Tên đăng nhập phải từ 3 ký tự và không chứa khoảng trắng.", txtUserName);
            return;
        }
        if (fullName.Length == 0)
        {
            Warn("Vui lòng nhập họ và tên.", txtFullName);
            return;
        }
        if (password.Length < 6)
        {
            Warn("Mật khẩu phải có ít nhất 6 ký tự.", txtPassword);
            return;
        }
        if (password != confirm)
        {
            Warn("Mật khẩu nhập lại không khớp.", txtConfirm);
            return;
        }

        try
        {
            using var db = new AppDbContext();

            // Không phân biệt hoa/thường để tránh tạo 2 tài khoản dễ nhầm (vd: "an" và "An")
            string lowered = userName.ToLower();
            if (db.Users.Any(u => u.UserName.ToLower() == lowered))
            {
                Warn("Tên đăng nhập đã tồn tại. Vui lòng chọn tên khác.", txtUserName);
                return;
            }

            var user = new User
            {
                UserName = userName,
                FullName = fullName,
                // Cùng cách băm với FormLogin: SHA-256 dạng chuỗi hex
                PasswordHash = Convert.ToHexString(SHA256.HashData(Encoding.UTF8.GetBytes(password))),
                Role = cbRole.SelectedIndex == 0 ? Role.Admin : Role.Guard,
                IsActive = chkActive.Checked
            };

            db.Users.Add(user);
            db.SaveChanges();

            ClearForm();
            LoadUsers(user.UserId);
            MessageBox.Show($"Đã thêm người dùng \"{userName}\".", "Thành công",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            ShowError("Không thể thêm người dùng", ex);
        }
    }

    // ------------------------------------------------------------
    //  Xóa người dùng
    // ------------------------------------------------------------
    private void BtDelete_Click(object? sender, EventArgs e)
    {
        if (dgvUsers.CurrentRow?.Tag is not int id)
        {
            MessageBox.Show("Vui lòng chọn một người dùng trong danh sách.", "Chưa chọn người dùng",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        if (_currentUser != null && id == _currentUser.UserId)
        {
            MessageBox.Show("Bạn không thể xóa chính tài khoản đang đăng nhập.", "Không thể xóa",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        try
        {
            using var db = new AppDbContext();
            var user = db.Users.FirstOrDefault(u => u.UserId == id);
            if (user == null)
            {
                LoadUsers();
                return;
            }

            // Luôn phải còn ít nhất một Admin đang hoạt động
            if (user.Role == Role.Admin && user.IsActive &&
                !db.Users.Any(u => u.UserId != id && u.Role == Role.Admin && u.IsActive))
            {
                MessageBox.Show("Đây là quản trị viên hoạt động cuối cùng nên không thể xóa.",
                    "Không thể xóa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Người dùng đã có ca trực / hóa đơn thì không xóa hẳn (để giữ lịch sử, tránh lỗi khóa ngoại)
            bool hasHistory = db.Shifts.Any(s => s.UserId == id) || db.Invoices.Any(i => i.CreatedBy == id);
            if (hasHistory)
            {
                if (!user.IsActive)
                {
                    MessageBox.Show("Người dùng này đã có ca trực/hóa đơn nên không thể xóa, và tài khoản đã bị khóa sẵn.",
                        "Không thể xóa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var lockAnswer = MessageBox.Show(
                    $"\"{user.UserName}\" đã có ca trực hoặc hóa đơn nên không thể xóa hẳn (để giữ lịch sử).\n\n" +
                    "Bạn có muốn KHÓA tài khoản này thay thế không?",
                    "Không thể xóa hẳn", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (lockAnswer != DialogResult.Yes) return;

                user.IsActive = false;
                db.SaveChanges();
                LoadUsers(id);
                return;
            }

            var answer = MessageBox.Show(
                $"Xóa người dùng \"{user.UserName}\" ({user.FullName})?\nThao tác này không thể hoàn tác.",
                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (answer != DialogResult.Yes) return;

            db.Users.Remove(user);
            db.SaveChanges();
            LoadUsers();
        }
        catch (DbUpdateException ex)
        {
            ShowError("Không thể xóa người dùng (dữ liệu đang được tham chiếu ở nơi khác)", ex);
        }
        catch (Exception ex)
        {
            ShowError("Không thể xóa người dùng", ex);
        }
    }

    // ------------------------------------------------------------
    //  Khóa người dùng
    // ------------------------------------------------------------
    private void BtLock_Click(object? sender, EventArgs e)
    {
        if (dgvUsers.CurrentRow?.Tag is not int id)
        {
            MessageBox.Show("Vui lòng chọn một người dùng trong danh sách.", "Chưa chọn người dùng",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        if (_currentUser != null && id == _currentUser.UserId)
        {
            MessageBox.Show("Bạn không thể khóa chính tài khoản đang đăng nhập.", "Không thể thao tác",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        try
        {
            using var db = new AppDbContext();
            var user = db.Users.FirstOrDefault(u => u.UserId == id);
            if (user == null)
            {
                LoadUsers();
                return;
            }

            // Nếu đang hoạt động -> sắp khóa: kiểm tra không được khóa Admin cuối cùng
            if (user.IsActive && user.Role == Role.Admin &&
                !db.Users.Any(u => u.UserId != id && u.Role == Role.Admin && u.IsActive))
            {
                MessageBox.Show("Đây là quản trị viên hoạt động cuối cùng nên không thể khóa.",
                    "Không thể khóa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string action = user.IsActive ? "KHÓA" : "MỞ KHÓA";
            var answer = MessageBox.Show(
                $"Bạn có chắc chắn muốn {action} tài khoản \"{user.UserName}\" ({user.FullName}) không?",
                $"Xác nhận {action.ToLower()}", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (answer != DialogResult.Yes) return;

            user.IsActive = !user.IsActive;
            db.SaveChanges();

            LoadUsers(id);
            MessageBox.Show($"Đã {action.ToLower()} tài khoản \"{user.UserName}\".", "Thành công",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            ShowError("Không thể cập nhật trạng thái tài khoản", ex);
        }
    }
    
    // ------------------------------------------------------------
    //  Hàm hỗ trợ
    // ------------------------------------------------------------
    private void ClearForm()
    {
        txtUserName.Clear();
        txtFullName.Clear();
        txtPassword.Clear();
        txtConfirm.Clear();
        chkShowPassword.Checked = false;
        chkActive.Checked = true;
        cbRole.SelectedIndex = 1;
        txtUserName.Focus();
    }

    private static string RoleName(Role role) =>
        role == Role.Admin ? "Quản trị viên" : "Nhân viên bảo vệ";

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