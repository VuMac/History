using HistoryQuizApi.Models;
using HistoryQuizApi.Models.Data;
using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public DbSet<User> User { get; set; }
    public DbSet<ClassHistory> classHistory { get; set; }
    
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}
    

}