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

    private async void OnExamButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ExamPage()); // Điều hướng đến trang Bài thi
    }
}
