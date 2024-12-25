namespace HistoryQuest.Views.ClassPage;

public partial class ClassPage : ContentPage
{
    public ClassPage()
    {
        InitializeComponent();
    }
    private void OnLessonButtonClicked(object sender, EventArgs e)
    {
        Application.Current.MainPage = new NavigationPage(new Views.LessonPage());
    }

    private void OnExamButtonClicked(object sender, EventArgs e)
    {
        // Điều hướng đến trang chỉnh sửa thông tin cá nhân bằng Application.Current.MainPage
        Application.Current.MainPage = new Views.ExamPage();
    }
}
