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
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configure relationships
        modelBuilder.Entity<Lesson>()
           .HasOne(l => l.ClassHistory)
           .WithMany(c => c.Lessons)
           .HasForeignKey(l => l.ClassHistoryId);

        modelBuilder.Entity<Lesson>()
            .HasOne(l => l.Exam)
            .WithOne(e => e.Lesson)
            .HasForeignKey<Exam>(e => e.LessonId);
    }

}