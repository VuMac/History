using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HistoryQuest.ViewModels.MainViewModels
{
    public class ExamViewModel : BaseViewModel
    {
        private int _currentQuestionIndex;
        private double _progress;
        private bool _isFinishButtonVisible;

        public ObservableCollection<Question> Questions { get; }
        public ICommand NextQuestionCommand { get; }
        public ICommand PreviousQuestionCommand { get; }
        public ICommand FinishExamCommand { get; }

        public ExamViewModel()
        {
            Questions = new ObservableCollection<Question>
            {
                new Question { Text = "Câu hỏi 1: Ai là người khai quốc của triều đại Lý?", Options = new[] { "Lý Công Uẩn", "Lê Lợi", "Ngô Quyền", "Trần Hưng Đạo" } },
                new Question { Text = "Câu hỏi 2: Chiến thắng Điện Biên Phủ diễn ra vào năm nào?", Options = new[] { "1945", "1954", "1968", "1975" } },
                // Add more questions as needed
            };

            _currentQuestionIndex = 0;
            _progress = 0;
            UpdateCurrentQuestion();

            NextQuestionCommand = new Command(NextQuestion);
            PreviousQuestionCommand = new Command(PreviousQuestion);
            FinishExamCommand = new Command(FinishExam);
        }

        public string CurrentQuestionNumber => $"Câu {_currentQuestionIndex + 1} / {Questions.Count}";
        public string CurrentQuestionText => Questions[_currentQuestionIndex].Text;
        public ObservableCollection<string> CurrentOptions => new ObservableCollection<string>(Questions[_currentQuestionIndex].Options);

        public double Progress => _progress;
        public bool IsPreviousButtonEnabled => _currentQuestionIndex > 0;
        public bool IsNextButtonEnabled => _currentQuestionIndex < Questions.Count - 1;
        public bool IsFinishButtonVisible => _currentQuestionIndex == Questions.Count - 1;

        private void NextQuestion()
        {
            if (_currentQuestionIndex < Questions.Count - 1)
            {
                _currentQuestionIndex++;
                UpdateCurrentQuestion();
            }
        }

        private void PreviousQuestion()
        {
            if (_currentQuestionIndex > 0)
            {
                _currentQuestionIndex--;
                UpdateCurrentQuestion();
            }
        }

        private void UpdateCurrentQuestion()
        {
            OnPropertyChanged(nameof(CurrentQuestionNumber));
            OnPropertyChanged(nameof(CurrentQuestionText));
            OnPropertyChanged(nameof(CurrentOptions));
            OnPropertyChanged(nameof(IsPreviousButtonEnabled));
            OnPropertyChanged(nameof(IsNextButtonEnabled));
            OnPropertyChanged(nameof(IsFinishButtonVisible));

            _progress = (double)(_currentQuestionIndex + 1) / Questions.Count;
            OnPropertyChanged(nameof(Progress));
        }

        private void FinishExam()
        {
            // Logic for finishing the exam
            // e.g., calculate the score, show results, etc.
            Application.Current.MainPage.DisplayAlert("Kết thúc bài thi", "Bạn đã hoàn thành bài thi!", "OK");
            Application.Current.MainPage = new NavigationPage(new Views.ResultPage());
            
        }
    }

    public class Question
    {
        public string Text { get; set; }
        public string[] Options { get; set; }
        public int? SelectedOption { get; set; }
    }

}
