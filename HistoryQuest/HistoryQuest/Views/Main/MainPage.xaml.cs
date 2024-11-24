using System.Collections.ObjectModel;

namespace HistoryQuest.Views;

public partial class MainPage : ContentPage
{
    public ObservableCollection<string> Classes { get; set; }
    public MainPage()
    {
        InitializeComponent();
        BindingContext = new ViewModels.MainViewModels.MainViewModel();
        // Danh sách lớp học giả lập
        Classes = new ObservableCollection<string>
            {
                "Toán 101",
                "Văn học 202",
                "Lịch sử 303",
                "Địa lý 404"
            };

        BindingContext = this;
    }

    private async void OnLogoutButtonClicked(object sender, EventArgs e)
    {
        // Điều hướng về trang Login khi nhấn "Đăng xuất"s
        await Navigation.PushAsync(new LoginPage());
    }
    private async void OnAddClassClicked(object sender, EventArgs e)
    {
        // Xử lý sự kiện khi nhấn nút "+"
        Navigation.PushAsync(new Views.ClassList.ClassList());
    }
}
