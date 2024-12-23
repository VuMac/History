namespace HistoryQuest.Views;
using System.Windows.Input;
public partial class LessonPage : ContentPage
{
    public LessonPage()
    {
        InitializeComponent();
        //BindingContext = this;
    }
    private async void OnBackButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync(); // Quay lại trang trước đó
    }


}
