using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseInsensitiveGraphQL.Db
{
    public class DemoContext:  DbContext
    {

        public DbSet<User> Users { get; set; }
        public DbSet<Address> Addresses { get; set; }

        public DemoContext(DbContextOptions options): base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {

        }

        protected override void  OnModelCreating(ModelBuilder  builder)
        {
            builder.Entity<User>(e => {
                
                e.HasKey(p => p.Id);

                e.Property(p => p.Id);

                e.Property(p => p.Name).
                IsRequired()
                .HasMaxLength(100);

                e.HasMany(p => p.Addresses)
                .WithOne(p => p.User)
                .HasForeignKey(p => p.UserId);

            });

            builder.Entity<Address>(e => {

                e.HasKey(p => p.Id);

                e.Property(p => p.Id)
                .ValueGeneratedOnAdd();

                e.Property(e => e.Street)
                .IsRequired()
                .HasMaxLength(100);

                e.Property(p => p.IsPrimary)
                .IsRequired()
                .HasDefaultValue("false");

                e.Property(p => p.UserId)
                .IsRequired();

                e.HasOne(p => p.User)
                .WithMany(p => p.Addresses);

            });
        }
    }
}
