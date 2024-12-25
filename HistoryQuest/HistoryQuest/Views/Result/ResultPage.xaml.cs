namespace HistoryQuest.Views;

public partial class ResultPage : ContentPage
{
    public ResultPage()
    {
        InitializeComponent();
    }
     private void OnBackToHomeClicked(object sender, EventArgs e)
    {
        // Điều hướng đến trang chỉnh sửa thông tin cá nhân bằng Application.Current.MainPage
        Application.Current.MainPage = new Views.Main.HomePage();
    }

}
