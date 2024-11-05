using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HistoryQuest.ViewModels.MainViewModels
{
    public class MainViewModel
    {
        public ICommand OpenLessonCommand { get; }
        public ICommand OpenExamCommand { get; }
        public ICommand OpenReviewCommand { get; }

        public MainViewModel()
        {
            OpenLessonCommand = new Command(async () => await GoToLessonPage());
            OpenExamCommand = new Command(async () => await GoToExamPage());
            //OpenReviewCommand = new Command(async () => await GoToReviewPage());
        }

        private async Task GoToLessonPage()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new Views.LessonPage());
        }

        private async Task GoToExamPage()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new Views.ExamPage());
        }

        //private async Task GoToReviewPage()
        //{
        //    await Application.Current.MainPage.Navigation.PushAsync(new Views.ReviewPage());
        //}
    }
}
