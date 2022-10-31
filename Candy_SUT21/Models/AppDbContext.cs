using Candy_SUT21.Models.Statistics;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Candy_SUT21.Models
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Candy> Candies { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        public DbSet<ShoppingCartCoupon> ShoppingCartCoupons { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Discount> Discounts { get; set; }

        public DbSet<OrderWeather> OrderWeathers { get; set; }

        public DbSet<CouponCode> CouponCodes { get; set; }
        public DbSet<Customer> Customers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(new Category { CategoryId = 1, CategoryName = "Chocolate Candy" });
            modelBuilder.Entity<Category>().HasData(new Category { CategoryId = 2, CategoryName = "Fruit Candy" });
            modelBuilder.Entity<Category>().HasData(new Category { CategoryId = 3, CategoryName = "Gummy Candy" });
            modelBuilder.Entity<Category>().HasData(new Category { CategoryId = 4, CategoryName = "Halloween Candy" });
            modelBuilder.Entity<Category>().HasData(new Category { CategoryId = 5, CategoryName = "Hard Candy" });

            SeedUsers(modelBuilder);
            SeedRoles(modelBuilder);
            SeedUserRoles(modelBuilder);
            SeedDiscounts(modelBuilder);
            
            modelBuilder.Entity<Candy>().HasData(new Candy
            {
                CandyId = 1,
                Name = "Mixed Chocolate Candy",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Cursus risus at ultrices mi tempus imperdiet nulla malesuada pellentesque. Tortor posuere ac ut consequat. Sagittis nisl rhoncus mattis rhoncus urna neque viverra justo. Lacus sed turpis tincidunt id aliquet risus feugiat in. Viverra aliquet eget sit amet tellus cras adipiscing enim eu.",
                ImageUrl = "chocolateCandy.jpg",
                ImageThumbnailUrl = "chocolateCandy-small.jpg",
                StockAmount = 100,
                   Price = 4.95M,  
                   CategoryId=1,
                   DiscountId = 1
                
            }) ;

            modelBuilder.Entity<Candy>().HasData(new Candy
            {
                CandyId = 2,
                Name = "M&M's",
                Price = 3.95M,
                Description = "Venenatis tellus in metus vulputate eu scelerisque felis imperdiet proin. Quisque egestas diam in arcu cursus. Sed viverra tellus in hac. Quis commodo odio aenean sed adipiscing diam donec adipiscing.",
                CategoryId = 1,
                ImageUrl = "chocolateCandy2.jpg",
                ImageThumbnailUrl = "chocolateCandy2-small.jpg",
                StockAmount = 100,
                DiscountId = 2
            });
            modelBuilder.Entity<Candy>().HasData(new Candy
            {
                CandyId = 3,
                Name = "Another Mixed Chocolate Candy",
                Price = 5.75M,
                Description = "Turpis egestas pretium aenean pharetra magna ac placerat vestibulum. Sed faucibus turpis in eu mi bibendum neque egestas. At in tellus integer feugiat scelerisque. Elementum integer enim neque volutpat ac tincidunt.",
                CategoryId = 1,
                ImageUrl = "chocolateCandy3.jpg",
                ImageThumbnailUrl = "chocolateCandy3-small.jpg",
                StockAmount = 100,
                DiscountId = 3
            });
            modelBuilder.Entity<Candy>().HasData(new Candy
            {
                CandyId = 4,
                Name = "Mixed Candy",
                Price = 3.95M,
                Description = "Vitae congue eu consequat ac felis donec et. Praesent semper feugiat nibh sed pulvinar proin gravida hendrerit. Vel eros donec ac odio. A lacus vestibulum sed arcu non odio euismod lacinia at. Nisl suscipit adipiscing bibendum est ultricies integer. Nec tincidunt praesent semper feugiat nibh.",
                CategoryId = 2,
                ImageUrl = "fruitCandy.jpg",
                ImageThumbnailUrl = "fruitCandy-small.jpg",
                StockAmount = 100,
                DiscountId = 4
            });
            modelBuilder.Entity<Candy>().HasData(new Candy
            {
                CandyId = 5,
                Name = "Mixed Hard Candy",
                Price = 7.00M,
                Description = "Purus sit amet luctus venenatis lectus magna fringilla. Consectetur lorem donec massa sapien faucibus et molestie ac. Sagittis nisl rhoncus mattis rhoncus urna neque viverra.",
                CategoryId = 2,
                ImageUrl = "fruitCandy2.jpg",
                ImageThumbnailUrl = "fruitCandy2-small.jpg",
                StockAmount = 100,
            });
            modelBuilder.Entity<Candy>().HasData(new Candy
            {
                CandyId = 6,
                Name = "Sour Fruit Candy",
                Price = 11.25M,
                Description = "Ultrices vitae auctor eu augue ut. Leo vel fringilla est ullamcorper eget. A diam maecenas sed enim ut. Massa tincidunt dui ut ornare lectus. Nullam non nisi est sit amet facilisis magna. ",
                CategoryId = 2,
                ImageUrl = "fruitCandy3.jpg",
                ImageThumbnailUrl = "fruitCandy3-small.jpg",
                StockAmount = 100,
            });
            modelBuilder.Entity<Candy>().HasData(new Candy
            {
                CandyId = 7,
                Name = "Gummy Bears",
                Price = 3.95M,
                Description = "Diam sit amet nisl suscipit adipiscing bibendum est ultricies integer. Molestie at elementum eu facilisis sed odio morbi quis commodo. Odio facilisis mauris sit amet massa vitae tortor condimentum lacinia. Urna porttitor rhoncus dolor purus non enim praesent elementum facilisis.",
                CategoryId = 3,
                ImageUrl = "gummyCandy.jpg",
                ImageThumbnailUrl = "gummyCandy-small.jpg",
                StockAmount = 100,
            });
            modelBuilder.Entity<Candy>().HasData(new Candy
            {
                CandyId = 8,
                Name = "Another Gummy Bears",
                Price = 1.95M,
                Description = "Posuere ac ut consequat semper viverra nam libero justo laoreet. Ultrices dui sapien eget mi proin sed libero enim. Etiam non quam lacus suspendisse faucibus interdum. Amet nisl suscipit adipiscing bibendum est ultricies integer quis.",
                CategoryId = 3,
                ImageUrl = "gummyCandy2.jpg",
                ImageThumbnailUrl = "gummyCandy2-small.jpg",
                StockAmount = 100,
            });
            modelBuilder.Entity<Candy>().HasData(new Candy
            {
                CandyId = 9,
                Name = "Sour Gummy Bears",
                Price = 13.95M,
                Description = "Ut ornare lectus sit amet est placerat in egestas. Iaculis nunc sed augue lacus viverra vitae. Bibendum ut tristique et egestas quis ipsum suspendisse ultrices gravida. Accumsan tortor posuere ac ut consequat semper viverra.",
                CategoryId = 3,
                ImageUrl = "gummyCandy3.jpg",
                ImageThumbnailUrl = "gummyCandy3-small.jpg",
                StockAmount = 100,
            });
            modelBuilder.Entity<Candy>().HasData(new Candy
            {
                CandyId = 10,
                Name = "Halloween Candy",
                Price = 1.95M,
                Description = "Vitae congue eu consequat ac felis donec et odio. Tellus orci ac auctor augue mauris augue. Feugiat sed lectus vestibulum mattis ullamcorper velit sed. Sit amet consectetur adipiscing elit pellentesque habitant morbi tristique senectus. Sed pulvinar proin gravida hendrerit lectus a.",
                CategoryId = 4,
                ImageUrl = "halloweenCandy.jpg",
                ImageThumbnailUrl = "halloweenCandy-small.jpg",
                StockAmount = 100,
            });
            modelBuilder.Entity<Candy>().HasData(new Candy
            {
                CandyId = 11,
                Name = "Another Halloween Candy",
                Price = 12.95M,
                Description = "Hac habitasse platea dictumst quisque sagittis purus sit. Dui nunc mattis enim ut. Mauris commodo quis imperdiet massa tincidunt nunc pulvinar sapien et.",
                CategoryId = 4,
                ImageUrl = "halloweenCandy2.jpg",
                ImageThumbnailUrl = "halloweenCandy2-small.jpg",
                StockAmount = 100,
            });
            modelBuilder.Entity<Candy>().HasData(new Candy
            {
                CandyId = 12,
                Name = "Mixed Halloween Candy",
                Price = 21.95M,
                Description = "Pulvinar neque laoreet suspendisse interdum consectetur libero id faucibus. Ultrices vitae auctor eu augue ut lectus arcu bibendum at. Vulputate eu scelerisque felis imperdiet proin fermentum.",
                CategoryId = 4,
                ImageUrl = "halloweenCandy3.jpg",
                ImageThumbnailUrl = "halloweenCandy3-small.jpg",
                StockAmount = 100,
            });
            modelBuilder.Entity<Candy>().HasData(new Candy
            {
                CandyId = 13,
                Name = "Hard Candy",
                Price = 6.95M,
                Description = "Vestibulum mattis ullamcorper velit sed ullamcorper morbi tincidunt ornare massa. Arcu cursus euismod quis viverra.",
                CategoryId = 5,
                ImageUrl = "hardCandy.jpg",
                ImageThumbnailUrl = "hardCandy-small.jpg",
                StockAmount = 100,
            });
            modelBuilder.Entity<Candy>().HasData(new Candy
            {
                CandyId = 14,
                Name = "Mixed Sweet/Sour & Hard Candy",
                Price = 2.95M,
                Description = "Blandit massa enim nec dui nunc mattis enim ut tellus. Duis at consectetur lorem donec massa sapien faucibus et. At auctor urna nunc id cursus metus. Ut enim blandit volutpat maecenas volutpat blandit.",
                CategoryId = 5,
                ImageUrl = "hardCandy2.jpg",
                ImageThumbnailUrl = "hardCandy2-small.jpg",
                StockAmount = 100,

            });
            modelBuilder.Entity<Candy>().HasData(new Candy
            {
                CandyId = 15,
                Name = "Another Hard Candy",
                Price = 16.95M,
                Description = "Nisi lacus sed viverra tellus in. Morbi non arcu risus quis varius quam quisque id. Cras adipiscing enim eu turpis egestas. Tristique nulla aliquet enim tortor. Quisque id diam vel quam. Id faucibus nisl tincidunt eget nullam.",
                CategoryId = 5,
                ImageUrl = "hardCandy3.jpg",
                ImageThumbnailUrl = "hardCandy3-small.jpg",
                StockAmount = 100,
            });
        }
        private void SeedUsers(ModelBuilder builder)
        {
            ApplicationUser user = new ApplicationUser
            {
                Id = "b74ddd14-6340-4840-95c2-db12554843e5",
                UserName = "admin@djinn.com",
                NormalizedUserName = "ADMIN@DJINN.COM",
                Email = "admin@djinn.com",
                NormalizedEmail = "ADMIN@DJINN.COM",
                LockoutEnabled = false,
                PhoneNumber = "123456789",
                SecurityStamp = Guid.NewGuid().ToString(),
                EmailConfirmed = true               
            };

            PasswordHasher<ApplicationUser> passwordHasher = new PasswordHasher<ApplicationUser>();
            user.PasswordHash = passwordHasher.HashPassword(user, "Admin123!");

            builder.Entity<ApplicationUser>().HasData(user);
        }

        private void SeedDiscounts(ModelBuilder builder)
        {
            builder.Entity<Discount>().HasData(
                new Discount { Id = 1, Name = "NoDiscount", Percentage = 0},
                new Discount { Id = 2, Name = "MyDiscount", Percentage = 5, StartDate = DateTime.Parse("2022-10-10"), EndDate = DateTime.Parse("2022-12-31") },
                new Discount { Id = 3, Name = "YourDiscount", Percentage = 15, StartDate = DateTime.Parse("2022-01-01"), EndDate = DateTime.Parse("2022-12-31") },
                new Discount { Id = 4, Name = "AnotherDiscount", Percentage = 50, StartDate = DateTime.Parse("2022-01-01"), EndDate = DateTime.Parse("2022-10-01") },
                new Discount { Id = 5, Name = "HellooDiscoconut", Percentage = 25, StartDate = DateTime.Parse("2022-11-10"), EndDate = DateTime.Parse("2023-02-02") }
                );
        }

        private void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole() { Id = "fab4fac1-c546-41de-aebc-a14da6895711", Name = "Admin", ConcurrencyStamp = "1", NormalizedName = "Admin" },
                new IdentityRole() { Id = "c7b013f0-5201-4317-abd8-c211f91b7330", Name = "Customer", ConcurrencyStamp = "2", NormalizedName = "Customer" });
        }

        private void SeedUserRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>() { RoleId = "fab4fac1-c546-41de-aebc-a14da6895711", UserId = "b74ddd14-6340-4840-95c2-db12554843e5" });
        }
    }
}
