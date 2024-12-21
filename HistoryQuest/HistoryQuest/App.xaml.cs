using HistoryQuest.Views;
using HistoryQuest.Views.Main;

namespace HistoryQuest;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
        MainPage = new NavigationPage(new Views.LoginPage());
    }
}
