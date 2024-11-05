namespace HistoryQuest.Views;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
        BindingContext = new ViewModels.MainViewModels.MainViewModel();
    }

    private async void OnLogoutButtonClicked(object sender, EventArgs e)
    {
        // Điều hướng về trang Login khi nhấn "Đăng xuất"s
        await Navigation.PushAsync(new LoginPage());
    }
}
