using AppBaiDoXeThongMinh.database;
using AppBaiDoXeThongMinh.Models;
using Microsoft.EntityFrameworkCore;

namespace AppBaiDoXeThongMinh.Views;

public partial class TestDatabase : Form
{
    public TestDatabase()
    {
        InitializeComponent();
        var db = new AppDbContext();
        //dataGridView1.DataSource = db.Tickets.Include(t => t.Vehicle).ToList();
        loadData();

    }

    private void loadData()
    {
        using (var db = new AppDbContext())
        {
            // Lấy danh sách vé (kèm thông tin xe liên kết qua Include)
            // Giả sử DbSet trong AppDbContext của bạn tên là Tickets
            var list = db.Tickets
                .Include(t => t.Vehicle) 
                .ToList();

            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Add("colStt", "stt");
            dataGridView1.Columns.Add("colLicensePlate", "LicensePlate");
            dataGridView1.Columns.Add("colTicketCode", "TicketCode");
            dataGridView1.Columns.Add("colEntryTime", "EntryTime");
            dataGridView1.Columns.Add("colDuration", "Duration");
            dataGridView1.Columns.Add("colVehicleType", "VehicleType");
            
            int stt = 1;
            foreach (var t in list)
            {
                var duration = (t.ExitTime ?? DateTime.Now) - t.EntryTime;
                
                dataGridView1.Rows.Add(
                    stt++,
                    t.Vehicle?.LicensePlate ?? "Không rõ", // Dùng dấu ? để an toàn nếu xe bị null
                    t.TicketCode,
                    t.EntryTime.ToString("dd/MM/yyyy HH:mm"),
                    $"{(int)duration.TotalHours}h {duration.Minutes}m",
                    t.Vehicle?.VehicleType.ToString() ?? ""
                );
            }
        }
    }
}