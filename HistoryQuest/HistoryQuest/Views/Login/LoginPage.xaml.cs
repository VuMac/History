namespace HistoryQuest.Views;
using System.Windows.Input;
public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();
        BindingContext = this;
    }

    public Command RegisterCommand => new Command(async () =>
    {
        await Navigation.PushAsync(new Views.RegisterPage());
    });

    private async void OnLoginButtonClicked(object sender, EventArgs e)
    {
        string username = usernameEntry.Text;
        string password = passwordEntry.Text;

        if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
        {
            await DisplayAlert("Lỗi", "Vui lòng nhập đầy đủ tên đăng nhập và mật khẩu.", "OK");
            return;
        }

        if (username == "admin" && password == "admin")  // Kiểm tra tài khoản mẫu
        {
            await DisplayAlert("Thành công", "Đăng nhập thành công!", "OK");
            await Navigation.PushAsync(new Views.MainPage());  // Điều hướng sang trang chính
        }
        else
        {
            await DisplayAlert("Lỗi", "Tên đăng nhập hoặc mật khẩu không đúng.", "OK");
        }
    }

}
