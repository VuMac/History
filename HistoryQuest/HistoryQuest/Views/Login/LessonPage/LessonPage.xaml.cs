namespace HistoryQuest.Views;
using System.Windows.Input;
public partial class LessonPage : ContentPage
{
    public LessonPage()
    {
        InitializeComponent();
        //BindingContext = this;
    }
    private void OnBackButtonClicked(object sender, EventArgs e)
    {
        // Điều hướng đến trang chỉnh sửa thông tin cá nhân bằng Application.Current.MainPage
        Application.Current.MainPage = new Views.Main.HomePage();
    }


}
