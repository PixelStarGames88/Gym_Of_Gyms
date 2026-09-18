using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Gym_Of_Gyms.Models;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public DbSet<ApplicationUser> ApplicationUsers { get; set; } = null!;
    public DbSet<Food> UserFood { get; set; } = null!;
    public DbSet<Exercise> Exercises { get; set; } = null!;
    public DbSet<Record_Food> Records_Food { get; set; } = null!;
    public DbSet<Set_Record> Set_Records { get; set; } = null!;
    public DbSet<Eating> Eatings { get; set; } = null!;
    public DbSet<Exercise_Record> Exercise_Records { get; set; } = null!;
    public DbSet<Eating_Day> Eating_Days { get; set; } = null!;
    public DbSet<Workout> Workouts { get; set; } = null!;

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Workout>().HasKey(w => w.Workout_Id);
        modelBuilder.Entity<Food>().HasKey(f => f.Food_Id);
        modelBuilder.Entity<Exercise>().HasKey(e => e.Exercise_Id);
        modelBuilder.Entity<Record_Food>().HasKey(rf => rf.Record_Food_Id);
        modelBuilder.Entity<Set_Record>().HasKey(sr => sr.Set_Record_Id);
        modelBuilder.Entity<Eating>().HasKey(e => e.Eating_Id);
        modelBuilder.Entity<Exercise_Record>().HasKey(er => er.Exercise_Record_Id);
        modelBuilder.Entity<Eating_Day>().HasKey(ed => ed.Day_Id);

        modelBuilder.Entity<Workout>().HasOne(o => o.ApplicationUser).WithMany()
            .HasForeignKey(o => o.User_Id).OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Exercise_Record>().HasOne(o => o.Workout).WithMany()
            .HasForeignKey(o => o.Workout_Id).OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Set_Record>().HasOne(o => o.Exercise_Record).WithMany()
            .HasForeignKey(o => o.Exercise_Record_Id).OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Set_Record>().HasOne(o => o.Exercise).WithMany()
            .HasForeignKey(o => o.Exercise_Id).OnDelete(DeleteBehavior.Cascade);


        modelBuilder.Entity<Eating_Day>().HasOne(o => o.ApplicationUser).WithMany()
            .HasForeignKey(o => o.User_Id).OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Eating>().HasOne(o => o.Eating_Day).WithMany()
            .HasForeignKey(o => o.Day_Id).OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Record_Food>().HasOne(o => o.Food).WithMany()
            .HasForeignKey(o => o.Food_Id).OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Record_Food>().HasOne(o => o.Eating).WithMany()
            .HasForeignKey(o => o.Eating_Id).OnDelete(DeleteBehavior.Cascade);

    }
}