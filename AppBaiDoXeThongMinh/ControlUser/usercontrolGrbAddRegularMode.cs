namespace AppBaiDoXeThongMinh.ControlUser;

public partial class usercontrolGrbAddRegularMode : UserControl
{
    public event EventHandler? LockClicked;
    public event EventHandler? Deletelicked;
    public event EventHandler? RefreshClicked;
    
    public usercontrolGrbAddRegularMode()
    {
        InitializeComponent();
        btLock.Click += (s, e) => LockClicked?.Invoke(this, e);
        btDelete.Click += (s,e) => Deletelicked?.Invoke(this, e);
        btRefresh.Click += (s, e) => RefreshClicked?.Invoke(this, e); 
    }
}