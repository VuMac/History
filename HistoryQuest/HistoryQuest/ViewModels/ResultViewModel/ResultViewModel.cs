using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HistoryQuest.ViewModels.ResultViewModel
{
    public class ResultViewModel : BaseViewModel
    {
        private readonly int _correctAnswers;
        private readonly int _totalQuestions;

        public ResultViewModel(int correctAnswers, int totalQuestions)
        {
            _correctAnswers = correctAnswers;
            _totalQuestions = totalQuestions;
            ScoreText = $"Bạn đã trả lời đúng {_correctAnswers}/{_totalQuestions} câu.";

            // Provide feedback based on the score
            if ((double)_correctAnswers / _totalQuestions >= 0.8)
                FeedbackMessage = "Xuất sắc! Bạn rất giỏi về lịch sử!";
            else if ((double)_correctAnswers / _totalQuestions >= 0.5)
                FeedbackMessage = "Tốt! Bạn có kiến thức khá vững.";
            else
                FeedbackMessage = "Cần cố gắng thêm! Hãy thử lại nhé.";

            ReturnToMainCommand = new Command(async () =>
            {
                await Application.Current.MainPage.Navigation.PopToRootAsync();
            });
        }

        public string ScoreText { get; }
        public string FeedbackMessage { get; }
        public ICommand ReturnToMainCommand { get; }
    }
}
