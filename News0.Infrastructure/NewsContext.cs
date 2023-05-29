using System;
using System.Collections.Generic;
using System.Text;
using News0.Application;
using News0.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace News0.Infrastructure
{
    public class NewsContext : NewsContextApplication
    {
        public NewsContext() : base() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=WIN-D6GRQOTSRKP\SQLEXPRESS;Database=News0;Trusted_Connection=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasKey(c => c.Id);
            modelBuilder.Entity<CategoryTranslation>().HasKey(ct => ct.Id);
            modelBuilder.Entity<Hashtag>().HasKey(h => h.Id);
            modelBuilder.Entity<Language>().HasKey(l => l.Id);
            modelBuilder.Entity<Post>().HasKey(p => p.Id);
            modelBuilder.Entity<PostTranslation>().HasKey(pt => pt.Id);
            modelBuilder.Entity<PostTranslationHashtag>().HasKey(pth => pth.Id);
            modelBuilder.Entity<Role>().HasKey(r => r.Id);
            modelBuilder.Entity<User>().HasKey(u => u.Id);

            modelBuilder.Entity<Post>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Posts)
                .HasForeignKey(p => p.CategoryId);
            modelBuilder.Entity<CategoryTranslation>()
                .HasOne(ct => ct.Category)
                .WithMany(c => c.CategoryTranslations)
                .HasForeignKey(ct => ct.CategoryId);
            modelBuilder.Entity<CategoryTranslation>()
                .HasOne(ct => ct.Language)
                .WithMany(l => l.CategoryTranslations)
                .HasForeignKey(ct => ct.LanguageId);
            modelBuilder.Entity<PostTranslation>()
                .HasOne(pt => pt.Post)
                .WithMany(p => p.PostTranslations)
                .HasForeignKey(pt => pt.PostId);
            modelBuilder.Entity<PostTranslation>()
                .HasOne(pt => pt.Publisher)
                .WithMany(u => u.PostTranslations)
                .HasForeignKey(pt => pt.PublisherId);
            modelBuilder.Entity<PostTranslation>()
                .HasOne(pt => pt.Language)
                .WithMany(l => l.PostTranslations)
                .HasForeignKey(pt => pt.LanguageId);
            modelBuilder.Entity<PostTranslationHashtag>()
                .HasOne(pth => pth.Hashtag)
                .WithMany(h => h.PostTranslationHashtags)
                .HasForeignKey(pth => pth.HashtagId);
            modelBuilder.Entity<PostTranslationHashtag>()
                .HasOne(pth => pth.PostTranslation)
                .WithMany(pt => pt.PostTranslationHashtags)
                .HasForeignKey(pth => pth.PostTranslationId);
            modelBuilder.Entity<User>()
                .HasOne(u => u.Role)
                .WithMany(r => r.Users)
                .HasForeignKey(u => u.RoleId);
        }
    }
}
