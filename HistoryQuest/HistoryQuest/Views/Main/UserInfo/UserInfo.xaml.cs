namespace HistoryQuest.Views.Main;

using System.Windows.Input;

public partial class UserInfo : ContentPage
{
    // Thuộc tính mô phỏng thông tin người dùng (có thể thay bằng Binding nếu dùng MVVM)
    private string _userName = "John Doe";
    private string _email = "johndoe@example.com";
    private int _age = 25;
    private string _address = "123 Đường ABC, TP.HCM";

    public UserInfo()
    {
        InitializeComponent();
        LoadUserInfo(); // Gọi hàm để tải thông tin người dùng
    }

    private void LoadUserInfo()
    {
        // Mô phỏng việc tải dữ liệu từ cơ sở dữ liệu hoặc dịch vụ API
        // Bạn có thể thay bằng BindingContext để sử dụng MVVM nếu cần
        var userData = new
        {
            UserName = _userName,
            Email = _email,
            Age = _age,
            Address = _address
        };

        // Hiển thị thông tin trong các Label (tương ứng với các phần tử XAML của bạn)
        // Bạn có thể sử dụng Data Binding nếu thích
    }

    private async void OnEditButtonClicked(object sender, EventArgs e)
    {
        // Điều hướng đến trang chỉnh sửa thông tin cá nhân
        await Navigation.PushAsync(new Views.Main.EditUserInfo.EditUserInfo());
    }
}
