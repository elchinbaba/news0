using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using News0.Domain.Entities;

namespace News0.Application
{
    public class NewsContextApplication : DbContext
    {
        public NewsContextApplication() : base() { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryTranslation> CategoryTranslations { get; set; }
        public DbSet<Hashtag> Hashtags { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostTranslation> PostTranslations { get; set; }
        public DbSet<PostTranslationHashtag> PostTranslationHashtags { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
