using System.Collections.ObjectModel;

namespace HistoryQuest.Views.ClassList;

public partial class ClassList : ContentPage
{
    public ObservableCollection<string> Classes { get; set; }
    public ClassList()
	{
        InitializeComponent();
        BindingContext = new ViewModels.MainViewModels.MainViewModel();
        // Danh sách lớp học giả lập
        Classes = new ObservableCollection<string>
            {
                "Lịch sử 1",
                "Lịch sử 2",
                "Lịch sử 3",
            };

        BindingContext = this;
    }
}