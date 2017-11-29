using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace ProjectViper.Models.Domain.Entities
{
    /// <summary>
    /// EntityFramework context
    /// </summary>
    public class EFDBContext : DbContext
    {
        public EFDBContext() : base("EFDBConnection")
        {

        }

        public DbSet<Tag> Tags { get; set; }
        public DbSet<FileMeta> Files { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            InitFileTagCrossTable(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        private void InitFileTagCrossTable(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FileMeta>()
                .HasMany(f => f.Tags)
                .WithMany(t => t.Files)
                .Map(m => 
                {
                    m.ToTable("FileTagCrossing");
                    m.MapLeftKey("FileId");
                    m.MapRightKey("TagId");
                });
        }
    }
}
