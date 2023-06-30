using BookLibrary.Models;
using BookLibrary.Models.PageModels;
using Duende.IdentityServer.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace BookLibrary.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions options, IOptions<OperationalStoreOptions> operationalStoreOptions)
            : base(options, operationalStoreOptions)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            SeedRoles(builder);
            BaseConfig(builder);

        }

        public void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole { Id = "1", Name = "Admin", NormalizedName = "ADMIN", ConcurrencyStamp = "1" },
                new IdentityRole { Id = "2", Name = "User", NormalizedName = "USER", ConcurrencyStamp = "2" }
            );
        }

        public void BaseConfig(ModelBuilder modelBuilder)
        {



            modelBuilder.Entity<BookShelfs>()
                .HasKey(e => new { e.BookId, e.ShelfId });

            modelBuilder.Entity<BookShelfs>()
                .HasOne(e => e.Book)
                .WithMany(e => e.BookShelves)
                .HasForeignKey(e => e.BookId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BookShelfs_Books");

            modelBuilder.Entity<BookShelfs>()
                .HasOne(e => e.Shelf)
                .WithMany(e => e.BookShelves)
                .HasForeignKey(e => e.ShelfId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BookShelfs_Shelfs");



            modelBuilder.Entity<Shelfs>()
                .HasKey(e => e.ShelfId);

            modelBuilder.Entity<BookShelfs>()
                .HasKey(e => new { e.BookId, e.ShelfId });

            modelBuilder.Entity<BookShelfs>()
                .HasOne(e => e.Book)
                .WithMany(e => e.BookShelves)
                .HasForeignKey(e => e.BookId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BookShelfs_Books");

            modelBuilder.Entity<BookShelfs>()
                .HasOne(e => e.Shelf)
                .WithMany(e => e.BookShelves)
                .HasForeignKey(e => e.ShelfId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BookShelfs_Shelfs");


            modelBuilder.Entity<UserShelfs>()
                .HasKey(e => new { e.ProfileUn, e.ShelfId });

            modelBuilder.Entity<UserShelfs>()
                .HasOne(e => e.Profile)
                .WithMany(e => e.UserShelfs)
                .HasForeignKey(e => e.ProfileUn)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserShelfs_Profile");
            modelBuilder.Entity<UserShelfs>()
                .HasOne(e => e.Shelf)
                .WithMany(e => e.UserShelfs)
                .HasForeignKey(e => e.ShelfId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserShelfs_Shelfs");

            base.OnModelCreating(modelBuilder);
        }


        public virtual DbSet<Authors> Authors { get; set; }


        public virtual DbSet<BookShelfs> BookShelfs { get; set; }

        public virtual DbSet<Books> Books { get; set; }




        public virtual DbSet<UserShelfs> UserShelfs { get; set; }

        public virtual DbSet<Shelfs> Shelfs { get; set; }

    }
}