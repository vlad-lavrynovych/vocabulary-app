using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using vocabulary_app.Models;

namespace vocabulary_app.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Word> words { get; set; }
        public DbSet<Vocabulary> vocabularies { get; set; }
        public DbSet<Topic> topics { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<WordTopic>()
                        .HasOne<Topic>(s => s.Topic)
                        .WithMany(c => c.WordTopics)
                        .HasForeignKey(sc => sc.TopicId);

            modelBuilder.Entity<WordTopic>()
                        .HasOne<Word>(sc => sc.Word)
                        .WithMany(s => s.WordTopics)
                        .HasForeignKey(sc => sc.WordId);

            modelBuilder.Entity<TopicVocabulary>()
              .HasOne<Topic>(s => s.Topic)
              .WithMany(c => c.TopicVocabularies)
              .HasForeignKey(sc => sc.TopicId);

            modelBuilder.Entity<TopicVocabulary>()
                        .HasOne<Vocabulary>(sc => sc.Vocabulary)
                        .WithMany(s => s.TopicVocabularies)
                        .HasForeignKey(sc => sc.VocabularyId);
        }
    }
}
