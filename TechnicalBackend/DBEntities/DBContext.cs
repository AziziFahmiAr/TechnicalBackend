using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using TechnicalBackend.Entity;

namespace TechnicalBackend.DBEntities
{
    public class DBContext : DbContext
    {
        public DBContext()
        {
        }

        public DBContext(DbContextOptions<DBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TTDeveloper>? TTDeveloper { get; set; }
        public virtual DbSet<TTDeveloperHobbies>? TTDeveloperHobbies { get; set; }
        public virtual DbSet<TTDeveloperSkills>? TTDeveloperSkills { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TTDeveloper>(entity =>
            {
                entity.HasKey(r => r.Id);
            });

            modelBuilder.Entity<TTDeveloperHobbies>(entity =>
            {
                entity.HasKey(r => r.Id);
                entity.Property<int>("TTDeveloper_Id");
                entity.HasOne(f => f.TTDeveloperr)
                .WithMany(f => f.TTDeveloperHobbies)
                .HasForeignKey("TTDeveloper_Id")
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<TTDeveloperSkills>(entity =>
            {
                entity.HasKey(r => r.Id);
                entity.Property<int>("TTDeveloper_Id");
                entity.HasOne(f => f.TTDeveloperr)
                .WithMany(f => f.TTDeveloperSkills)
                .HasForeignKey("TTDeveloper_Id")
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
