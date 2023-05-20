using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Contexts
{
    public class AppDbContext:IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions):base(dbContextOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>()
                 .HasOne(P => P.discount)
                 .WithMany(D => D.products)
                 .HasForeignKey(P => P.discount_id)
                 .HasPrincipalKey(P => P.discount_id);

            modelBuilder.Entity<Product>()
                .HasOne(p => p.category)
                .WithMany(C => C.products)
                .HasForeignKey(P => P.category_id);

            modelBuilder.Entity<Product>()
                .HasOne(p => p.brand)
                .WithMany(B => B.products)
                .HasForeignKey(p=>p.brand_id);


            modelBuilder.Entity<Review>()
                .HasOne(R => R.product)
                .WithMany(P => P.reviews)
                .HasForeignKey(R => R.product_id);

            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<IdentityRole>().ToTable("Roles");
            modelBuilder.Entity<IdentityUserRole<string>>().ToTable("UserRoles");
            modelBuilder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims");
            modelBuilder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins");
            modelBuilder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims");
            modelBuilder.Entity<IdentityUserToken<string>>().ToTable("UserTokens");
            

      

        }


        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Review> reviews { get; set; }  
    }
}
