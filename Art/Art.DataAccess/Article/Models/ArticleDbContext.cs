using System;
using Art.DataAccess.User.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Art.DataAccess.Article.Models
{
    public partial class ArticleDbContext : IdentityDbContext<Users>
    {
        public ArticleDbContext()
        {
        }

        public ArticleDbContext(DbContextOptions<ArticleDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=ArticleArt;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

        public virtual DbSet<Articles> Articles { get; set; }
       // public virtual DbSet<AuthorArticle> AuthorArticle { get; set; }
        public virtual DbSet<UserArticle> UserArticles { get; set; }
        public virtual DbSet<Authors> Authors { get; set; }
        public virtual DbSet<TopicArticle> TopicArticle { get; set; }
        public virtual DbSet<Topics> Topics { get; set; }
        public new virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Pictures> Pictures { get; set; }
        //public new virtual DbSet<AspNetRoleClaims> RoleClaims { get; set; }
        //public new virtual DbSet<AspNetRoles> Roles { get; set; }
        //public new virtual DbSet<AspNetUserClaims> UserClaims { get; set; }
        //public new virtual DbSet<AspNetUserLogins> UserLogins { get; set; }
        //public new virtual DbSet<AspNetUserRoles> UserRoles { get; set; }
        //public new virtual DbSet<AspNetUserTokens> UserTokens { get; set; }

        //        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //        {
        //            if (!optionsBuilder.IsConfigured)
        //            {
        //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
        //                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=ArticleArt;Trusted_Connection=True;");
        //            }
        //        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<Articles>(entity =>
            {
                entity.HasKey(e => e.ArticleId);
            });

            //modelBuilder.Entity<AspNetRoleClaims>(entity =>
            //{
            //    entity.Property(e => e.RoleId)
            //        .IsRequired()
            //        .HasMaxLength(450);

            //    entity.HasOne(d => d.Role)
            //        .WithMany(p => p.AspNetRoleClaims)
            //        .HasForeignKey(d => d.RoleId);
            //});

            //modelBuilder.Entity<AspNetRoles>(entity =>
            //{
            //    entity.Property(e => e.UserId).ValueGeneratedNever();

            //    entity.Property(e => e.Name).HasMaxLength(256);

            //    entity.Property(e => e.NormalizedName).HasMaxLength(256);
            //});

            //modelBuilder.Entity<AspNetUserClaims>(entity =>
            //{
            //    entity.Property(e => e.UserId)
            //        .IsRequired()
            //        .HasMaxLength(450);

            //    entity.HasOne(d => d.User)
            //        .WithMany(p => p.AspNetUserClaims)
            //        .HasForeignKey(d => d.UserId);
            //});

            //modelBuilder.Entity<AspNetUserLogins>(entity =>
            //{
            //    entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

            //    entity.Property(e => e.LoginProvider).HasMaxLength(128);

            //    entity.Property(e => e.ProviderKey).HasMaxLength(128);

            //    entity.Property(e => e.UserId)
            //        .IsRequired()
            //        .HasMaxLength(450);

            //    entity.HasOne(d => d.User)
            //        .WithMany(p => p.AspNetUserLogins)
            //        .HasForeignKey(d => d.UserId);
            //});

            //modelBuilder.Entity<AspNetUserRoles>(entity =>
            //{
            //    entity.HasKey(e => new { e.UserId, e.RoleId });

            //    entity.HasOne(d => d.Role)
            //        .WithMany(p => p.AspNetUserRoles)
            //        .HasForeignKey(d => d.RoleId);

            //    entity.HasOne(d => d.User)
            //        .WithMany(p => p.AspNetUserRoles)
            //        .HasForeignKey(d => d.UserId);
            //});

            //modelBuilder.Entity<AspNetUserTokens>(entity =>
            //{
            //    entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

            //    entity.Property(e => e.LoginProvider).HasMaxLength(128);

            //    entity.Property(e => e.Name).HasMaxLength(128);

            //    entity.HasOne(d => d.User)
            //        .WithMany(p => p.AspNetUserTokens)
            //        .HasForeignKey(d => d.UserId);
            //});

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<UserArticle>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.ArticleId });

                entity.HasOne(d => d.Article)
                    .WithMany(p => p.UserArticle)
                    .HasForeignKey(d => d.ArticleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserArticle)
                    .HasForeignKey(d => d.UserId);
            });
            // многие ко многим 
            //modelBuilder.Entity<AuthorArticle>(entity =>
            //{
            //    entity.HasKey(e => new { e.AuthorId, e.ArticleId });

            //    entity.HasOne(d => d.Article)
            //        .WithMany(p => p.AuthorArticle)
            //        .HasForeignKey(d => d.ArticleId);

            //    entity.HasOne(d => d.Author)
            //        .WithMany(p => p.AuthorArticle)
            //        .HasForeignKey(d => d.AuthorId);
            //});

            modelBuilder.Entity<Authors>(entity =>
            {
                entity.HasKey(e => e.AuthorId);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Authors)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Authors__UserId__5F141958");
            });
           

            modelBuilder.Entity<TopicArticle>(entity =>
            {
                entity.HasKey(e => new { e.TopicId, e.ArticleId });

                entity.HasOne(d => d.Article)
                    .WithMany(p => p.TopicArticle)
                    .HasForeignKey(d => d.ArticleId);

                entity.HasOne(d => d.Topic)
                    .WithMany(p => p.TopicArticle)
                    .HasForeignKey(d => d.TopicId);
            });

            modelBuilder.Entity<Topics>(entity =>
            {
                entity.HasKey(e => e.TopicId);
            });
        }
    }
}
