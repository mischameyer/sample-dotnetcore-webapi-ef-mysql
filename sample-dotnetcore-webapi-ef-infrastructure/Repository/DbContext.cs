using Microsoft.EntityFrameworkCore;
using sample_dotnetcore_webapi_ef_infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace sample_dotnetcore_webapi_ef_infrastructure.Repository
{
    public class DbContext : Microsoft.EntityFrameworkCore.DbContext
    {

        public DbSet<Book> Books { get; set; }

        public DbContext(DbContextOptions<DbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuider)
        {

            modelBuider.Entity<Book>(e =>
            {
                e
                .ToTable("books")
                .HasKey(k => k.Id);

                e
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();
            });

            base.OnModelCreating(modelBuider);
        }

    }
}
