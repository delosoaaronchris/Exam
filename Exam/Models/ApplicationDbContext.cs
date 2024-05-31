using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Annotations;

namespace RecyclingApp.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("DefaultConnection")
        {
        }

        public DbSet<RecyclableType> RecyclableTypes { get; set; }
        public DbSet<RecyclableItem> RecyclableItems { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RecyclableType>()
        .Property(rt => rt.Type)
        .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("IX_Type") { IsUnique = true }));


            base.OnModelCreating(modelBuilder);
        }
    }
}
