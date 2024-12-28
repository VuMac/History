using HistoryQuizApi.Models;
using HistoryQuizApi.Models.Data;
using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public DbSet<User> User { get; set; }
    public DbSet<ClassHistory> classHistory { get; set; }
    public DbSet<Enrollment> enrollments { get; set; }
    public DbSet<Lesson> Lessons { get; set; }
    public DbSet<Exam> Exams { get; set; }
    public DbSet<Submission> Submissions { get; set; }

    public DbSet<LessonCompletion> LessonCompletions { get; set; }
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Lesson>()
           .HasOne(l => l.ClassHistory)
           .WithMany(c => c.Lessons)
           .HasForeignKey(l => l.ClassHistoryId);

        modelBuilder.Entity<Lesson>()
     .HasMany(l => l.Exams)  // Một Lesson có nhiều Exam
     .WithOne(e => e.Lesson) // Mỗi Exam có một Lesson
     .HasForeignKey(e => e.LessonId); // Khóa ngoại trong bảng Exam

        modelBuilder.Entity<Submission>()
            .HasOne(s => s.Exam)
            .WithMany(e => e.Submissions)
            .HasForeignKey(s => s.ExamId);

        modelBuilder.Entity<LessonCompletion>()
        .HasKey(lc => lc.Id);

        modelBuilder.Entity<LessonCompletion>()
            .HasOne<Lesson>()
            .WithMany()
            .HasForeignKey(lc => lc.LessonId);
    }

}