using AppBaiDoXeThongMinh.database;
using AppBaiDoXeThongMinh.Models;
using AppBaiDoXeThongMinh.Views;

namespace AppBaiDoXeThongMinh;

static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();

        //using var db = new AppDbContext();
        //var guardUser = db.Users.First(u => u.UserName == "guard1");
        //Application.Run(new FormCheckOut(guardUser.UserId));
        Application.Run(new FormLogin());

    }
}