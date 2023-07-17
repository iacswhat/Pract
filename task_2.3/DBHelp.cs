using Microsoft.EntityFrameworkCore;

namespace task_2._1._1
{
    public class DBHelp : DbContext
    {

        public DBHelp(DbContextOptions<DBHelp> options) : base(options)
        {
        }

        public DbSet<Patient> patients { get; set; }
        public DbSet<StatisticsResult> BMIStatisticsByAge { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>()
                .HasKey(p => p.id);

            modelBuilder.Entity<Patient>()
                .Property(p => p.fullname)
                .IsRequired()
                .HasMaxLength(255);

            modelBuilder.Entity<Patient>()
                .Property(p => p.height)
                .IsRequired();

            modelBuilder.Entity<Patient>()
                .Property(p => p.weight)
                .IsRequired();

            modelBuilder.Entity<Patient>()
                .Property(p => p.age)
                .IsRequired();

            modelBuilder.Entity<Patient>()
                .Property(p => p.bmi)
                .IsRequired();

            modelBuilder.Entity<StatisticsResult>()
                .HasNoKey();
        }

    }
}
