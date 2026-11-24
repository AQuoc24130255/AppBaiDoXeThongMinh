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
        /*ApplicationConfiguration.Initialize();

        User u;
        
        using (var db = new AppDbContext())
        {
            db.Database.EnsureCreated();
            u = db.Users.FirstOrDefault();
        }
        
        Application.Run(new FormLogin());
    
        Application.Run(new FormProfile());
        //Application.Run(new FormSearch());*/
        ApplicationConfiguration.Initialize();

        using var db = new AppDbContext();
        var guardUser = db.Users.First(u => u.UserName == "guard1");

        Application.Run(new FormProfile(guardUser));
        Application.Run(new FormCheckIn());
        Application.Run(new FormCheckOut());


    }
}