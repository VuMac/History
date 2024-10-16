namespace HistoryQuest;

public partial class MainPage : ContentPage
{
	

	public MainPage()
	{
		InitializeComponent();
        LoginButton.Clicked += OnLoginButtonClicked;
        RegisterButton.Clicked += OnRegisterButtonClicked;
    }


    private void OnLoginButtonClicked(object sender, EventArgs e)
    {
        // Lấy thông tin người dùng
        string username = UsernameEntry.Text;
        string password = PasswordEntry.Text;

        // Kiểm tra tính hợp lệ của thông tin nhập vào
        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
        {
            DisplayAlert("Lỗi", "Tên đăng nhập và Mật khẩu không được để trống", "OK");
            return;
        }

        // Logic xác thực
        if (username == "admin" && password == "admin") // Thay thế bằng logic thực tế
        {
            DisplayAlert("Thành công", "Đăng nhập thành cônggggggggggg!", "OK");
            // Thực hiện điều hướng hoặc xử lý tiếp theo
            // await Navigation.PushAsync(new MainAppPage());
        }
        else
        {
            DisplayAlert("Lỗi", "Tên đăng nhập hoặc Mật khẩu không hợp lệ", "OK");
        }
    }


    private void OnRegisterButtonClicked(object sender, EventArgs e)
    {
        // Điều hướng đến trang đăng ký hoặc xử lý logic đăng ký
        DisplayAlert("Thông báo", "Đang điều hướng đến trang đăng ký...", "OK");
        // Ví dụ: await Navigation.PushAsync(new RegisterPage());
    }

}


