namespace HistoryQuest.Views;
using System.Windows.Input;
public partial class ExamPage : ContentPage
{
    public ExamPage()
    {
        InitializeComponent();
        //BindingContext = this;
        BindingContext = new ViewModels.MainViewModels.ExamViewModel();
    }

   

}
