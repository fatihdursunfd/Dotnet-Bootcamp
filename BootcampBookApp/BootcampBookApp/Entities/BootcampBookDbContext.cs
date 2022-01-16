using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace BootcampBookApp.Entities
{
    public partial class BootcampBookDbContext : DbContext
    {
        public BootcampBookDbContext()
        {
        }

        public BootcampBookDbContext(DbContextOptions<BootcampBookDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<AuthorBook> AuthorBooks { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<BookGenre> BookGenres { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>(entity =>
            {
                entity.ToTable("Author");

                entity.Property(e => e.AuthorId).HasColumnName("AuthorID");
            });

            modelBuilder.Entity<AuthorBook>(entity =>
            {
                entity.ToTable("AuthorBook");

                entity.HasIndex(e => e.AuthorId, "IX_AuthorBook_AuthorId");

                entity.HasIndex(e => e.BookId, "IX_AuthorBook_BookId");

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.AuthorBooks)
                    .HasForeignKey(d => d.AuthorId);

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.AuthorBooks)
                    .HasForeignKey(d => d.BookId);
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.ToTable("Book");

                entity.HasIndex(e => e.AuthorId, "IX_Book_AuthorID");

                entity.Property(e => e.AuthorId).HasColumnName("AuthorID");

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.AuthorId);
            });

            modelBuilder.Entity<BookGenre>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("BookGenre");

                entity.HasIndex(e => e.GenresGenreId, "IX_BookGenre_GenresGenreId");

                entity.HasOne(d => d.BooksBook)
                    .WithMany()
                    .HasForeignKey(d => d.BooksBookId);

                entity.HasOne(d => d.GenresGenre)
                    .WithMany()
                    .HasForeignKey(d => d.GenresGenreId);
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.ToTable("Genre");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
