using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace HistoryQuest
{
    public class QuizService
    {
        private readonly HttpClient _httpClient;

        public QuizService()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(" ") // Đặt URL của API bạn đã xây dựng
            };
        }

        public async Task<List<Quiz>> GetQuizzesAsync()
        {
            var response = await _httpClient.GetAsync("quizzes");
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<Quiz>>(json);
        }
    }
}
