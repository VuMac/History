using HistoryQuizApi.Models;
using Microsoft.EntityFrameworkCore;


namespace HistoryQuizApi.Data
{
    public class QuizContext : DbContext
    {

        public QuizContext(DbContextOptions<QuizContext> options) : base(options)
        {

        }


        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; } // Thêm DbSet cho Answer
    }
}
