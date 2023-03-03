using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Kursovaya_VPKS
{
    public partial class myDocxAppContext : DbContext
    {
        public myDocxAppContext()
        {
        }

        public myDocxAppContext(DbContextOptions<myDocxAppContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CreditCard> CreditCard { get; set; }
        public virtual DbSet<Inn> Inn { get; set; }
        public virtual DbSet<Items> Items { get; set; }
        public virtual DbSet<Passport> Passport { get; set; }
        public virtual DbSet<Photo> Photo { get; set; }
        public virtual DbSet<Polis> Polis { get; set; }
        public virtual DbSet<Snils> Snils { get; set; }
        public virtual DbSet<Template> Template { get; set; }
        public virtual DbSet<TemplateDocument> TemplateDocument { get; set; }
        public virtual DbSet<TemplateDocumentData> TemplateDocumentData { get; set; }
        public virtual DbSet<TemplateObject> TemplateObject { get; set; }
        public virtual DbSet<UserTemplate> UserTemplate { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlite("Data Source=D:\\\\\\\\Program Files\\\\\\\\myDocxApp.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CreditCard>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Cvv).HasColumnName("CVV");

                entity.Property(e => e.Fio).HasColumnName("FIO");

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.CreditCard)
                    .HasForeignKey<CreditCard>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Inn>(entity =>
            {
                entity.ToTable("INN");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Fio).HasColumnName("FIO");

                entity.Property(e => e.Gender).HasColumnType("char");

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.Inn)
                    .HasForeignKey<Inn>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Items>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.DateCreation).IsRequired();

                entity.Property(e => e.Title).IsRequired();

                entity.Property(e => e.Type).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<Passport>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Fio).HasColumnName("FIO");

                entity.Property(e => e.Gender).HasColumnType("char");

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.Passport)
                    .HasForeignKey<Passport>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Photo>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Path).IsRequired();

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.Photo)
                    .HasForeignKey<Photo>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Polis>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Fio).HasColumnName("FIO");

                entity.Property(e => e.Gender).HasColumnType("char");

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.Polis)
                    .HasForeignKey<Polis>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Snils>(entity =>
            {
                entity.ToTable("SNILS");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Fio).HasColumnName("FIO");

                entity.Property(e => e.Gender).HasColumnType("char");

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.Snils)
                    .HasForeignKey<Snils>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Template>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Date).IsRequired();

                entity.Property(e => e.Name).IsRequired();

                entity.Property(e => e.Status).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Template)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<TemplateDocument>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne(d => d.Template)
                    .WithMany(p => p.TemplateDocument)
                    .HasForeignKey(d => d.TemplateId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<TemplateDocumentData>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne(d => d.TemplateDocument)
                    .WithMany(p => p.TemplateDocumentData)
                    .HasForeignKey(d => d.TemplateDocumentId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.TemplateObject)
                    .WithMany(p => p.TemplateDocumentData)
                    .HasForeignKey(d => d.TemplateObjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<TemplateObject>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Type).IsRequired();

                entity.HasOne(d => d.Template)
                    .WithMany(p => p.TemplateObject)
                    .HasForeignKey(d => d.TemplateId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<UserTemplate>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedOnAdd();

                entity.HasOne(d => d.Template)
                    .WithMany(p => p.UserTemplate)
                    .HasForeignKey(d => d.TemplateId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserTemplate)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasIndex(e => e.Login)
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Login).IsRequired();

                entity.Property(e => e.Password).IsRequired();

                entity.Property(e => e.PremiumStatus).IsRequired();

                entity.Property(e => e.Syncing).IsRequired();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
