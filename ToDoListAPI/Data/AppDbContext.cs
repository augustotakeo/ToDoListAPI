using Microsoft.EntityFrameworkCore;
using ToDoListAPI.Model;

namespace ToDoListAPI.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Annotation> Annotations { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("DataSource=app.db;Cache=Shared");
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>(entity =>
            {
                entity.HasKey(user => user.Id);
            });

            builder.Entity<Annotation>(entity =>
            {
                entity.HasKey(annotation => annotation.Id);
                entity.HasOne(annotation => annotation.User)
                      .WithMany(user => user.Annotations)
                      .HasForeignKey(annotation => annotation.UserId);
            });
        }
    }
}
