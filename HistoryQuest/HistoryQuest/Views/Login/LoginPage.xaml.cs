namespace HistoryQuest.Views;
using System.Text.Json;

using System.Text;
using System.Windows.Input;
using HistoryQuest.Models;
using HistoryQuest.HTTP;

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();
        BindingContext = this;
    }

    //public Command RegisterCommand => new Command(async () =>
    //{
    //    await Navigation.PushAsync(new Views.RegisterPage());
    //});
    public void OnRegisterButtonClicked(object sender, EventArgs e)
    {
        Application.Current.MainPage = new NavigationPage(new Views.RegisterPage());
    }
    private async void OnLoginButtonClicked(object sender, EventArgs e)
    {
        string username = usernameEntry.Text;
        string password = passwordEntry.Text;

        if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
        {
            await DisplayAlert("Lỗi", "Vui lòng nhập đầy đủ tên đăng nhập và mật khẩu.", "OK");
            return;
        }

        // Tạo đối tượng chứa dữ liệu đăng nhập
        var loginData = new
        {
            Username = username,
            Password = password
        };
        var httpClient = new HttpClient(new CustomHttpClientHandler());
        // Gửi yêu cầu đến API

        try
        {
            string apiUrl = "https://192.168.1.3:5000/api/User/login";

            string json = JsonSerializer.Serialize(loginData);

            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await httpClient.PostAsync(apiUrl, content);

            if (response.IsSuccessStatusCode)
            {
                // Đăng nhập thành công
                string responseBody = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<LoginResponse>(responseBody);
                var data = JsonSerializer.Deserialize<UserResponse>(result.data.ToString());
                //lưu token và id va cach lay

                Preferences.Set("tokenJWT", result.token);
                Preferences.Set("userID", data.id.ToString());

                /*var token = Preferences.Get("auth_token", string.Empty);
                var userId = Preferences.Get("user_id", string.Empty);*/

                await DisplayAlert("Thành công", "Đăng nhập thành công!", "OK");

                // Chuyển sang trang chính
                // Thiết lập MainPage làm root page

                Application.Current.MainPage = new NavigationPage(new Views.MainPage());
            }
            else
            {
                // Thông báo lỗi nếu đăng nhập thất bại
                string errorMessage = await response.Content.ReadAsStringAsync();
                await DisplayAlert("Lỗi", "Tên đăng nhập hoặc mật khẩu không đúng.", "OK");
            }
        }
        catch (Exception ex)
        {
            // Xử lý lỗi kết nối hoặc lỗi hệ thống
            await DisplayAlert("Lỗi", $"Đã xảy ra lỗi: {ex.Message}", "OK");
        }


    }

}
