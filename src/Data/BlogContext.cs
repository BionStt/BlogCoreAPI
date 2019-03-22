using BlogCoreAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogCoreAPI.Data
{
    public class BlogContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public BlogContext(DbContextOptions<BlogContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Post>().HasMany(c => c.Comments).WithOne(p => p.Post);

            modelBuilder.Entity<Post>().Property(p => p.Archived).HasDefaultValue(false);
            modelBuilder.Entity<Post>().Property(p => p.Pinned).HasDefaultValue(false);
            modelBuilder.Entity<Post>().Property(p => p.Upload).HasDefaultValue(DateTime.Now);
            modelBuilder.Entity<Post>().Property(p => p.Cover).HasDefaultValue(System.IO.File.ReadAllBytes(".\\Images\\Default.jpg"));
            modelBuilder.Entity<Post>().Property(p => p.Views).HasDefaultValue(0);
            modelBuilder.Entity<Post>().Property(p => p.LastChange).HasDefaultValue(DateTime.Now);
            modelBuilder.Entity<Post>().Property(p => p.Link).HasDefaultValue("");
            modelBuilder.Entity<Post>().Property(p => p.Title).HasDefaultValue("");
            modelBuilder.Entity<Post>().Property(p => p.Preview).HasDefaultValue("");
            modelBuilder.Entity<Post>().Property(p => p.Content).HasDefaultValue("");

            modelBuilder.Entity<Comment>().Property(p => p.Content).HasDefaultValue("");
            modelBuilder.Entity<Comment>().Property(p => p.Upload).HasDefaultValue(DateTime.Now);
            modelBuilder.Entity<Comment>().Property(p => p.LastChange).HasDefaultValue(DateTime.Now);
        }
    }
}
