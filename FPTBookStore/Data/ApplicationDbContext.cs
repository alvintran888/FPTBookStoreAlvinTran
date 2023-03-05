using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using FPTBookStore.Models;
using Microsoft.AspNetCore.Identity;
using System.Reflection.Emit;

namespace FPTBookStore.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Product> Product { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<WaitCategory> WaitCategory { get; set; }
        public DbSet<Order> Order { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);

            SeedUser(builder);

            SeedRole(builder);

            SeedUserRole(builder);

            Seed(builder);


        }

        private void Seed(ModelBuilder builder)
        {
            builder.Entity<Category>().HasData(
                new Category
                {
                    Id = 1,
                    Name = "Book",
                    Description = "ok",
                    Status = "Active"
                },
                new Category
                {
                    Id = 2,
                    Name = "Learning tool",
                    Description = "good",
                    Status = "Active"
                },
                new Category
                {
                    Id = 3,
                    Name = "Manga",
                    Description = "Fantasy",
                    Status = "Active"
                },
                new Category
                {
                    Id = 4,
                    Name = "Comic",
                    Description = "good",
                    Status = "Active"
                },
                new Category
                {
                    Id = 5,
                    Name = "Magic",
                    Description = "Magic",
                    Status = "Active"
                },
                new Category
                {
                    Id = 6,
                    Name = "Drama",
                    Description = "Drama",
                    Status = "Active"
                }
                );
            builder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "Conan Chapter 100",
                    Price = 100,
                    Quantity = 10,
                    Description = "Very funny for children.",
                    CategoryId = 3,
                    Image = "conan100.png"
                },
                new Product
                {
                    Id = 2,
                    Name = "Shin chapter 7",
                    Price = 99,
                    Quantity = 20,
                    Description = "Good",
                    CategoryId = 4,
                    Image = "shin7.png"
                },

                new Product
                {
                    Id = 3,
                    Name = "Tiếng Việt lớp 2",
                    Price = 20,
                    Quantity = 70,
                    Description = "Greate for children study VietNamese.",
                    CategoryId = 1,
                    Image = "tiengviet2.png"
                });
        }

        private void SeedUser(ModelBuilder builder)
        {
            //1. tạo tài khoản ban đầu để add vào DB
            var admin = new ApplicationUser
            {
                Id = "1",
                UserName = "quanghuy01@gmail.com",
                Email = "quanghuy01@gmail.com",
                NormalizedUserName = "quanghuy01@gmail.com",
                Image = "https://file.hstatic.net/200000122283/article/shin-cau-be-but-chi_4017a723e5df4b7d91524dc0bf656c27_1024x1024.jpg",
                DoB = "2000/02/22",
                Address = "Vĩnh Phúc",
                FullName = "Nguyễn Quang Huy"
            };
            var admin2 = new ApplicationUser
            {
                Id = "2",
                UserName = "admin@gmail.com",
                Email = "admin@gmail.com",
                NormalizedUserName = "admin@gmail.com",
                Image = "https://file.hstatic.net/200000122283/article/shin-cau-be-but-chi_4017a723e5df4b7d91524dc0bf656c27_1024x1024.jpg",
                DoB = "2002/08/10",
                Address = "Hà Nội",
                FullName = "Văn Minh"
            };
            var admin3 = new ApplicationUser
            {
                Id = "4",
                UserName = "quanghuy67@gmail.com",
                Email = "quanghuy67@gmail.com",
                NormalizedUserName = "quanghuy67@gmail.com",
                Image = "https://www.alotintuc.com/wp-content/uploads/2021/07/Untitled-Capture2244-scaled-e1626766063525.jpg",
                DoB = "2002/02/18",
                Address = "Hà Nội",
                FullName = "Quang Huy Nguyễn"
            };
            var owner1 = new ApplicationUser
            {
                Id = "5",
                UserName = "owner1@gmail.com",
                Email = "owner1@gmail.com",
                NormalizedUserName = "owner1@gmail.com",
                Image = "https://gamek.mediacdn.vn/133514250583805952/2020/7/11/narutossagemode-15944657133061535033027.png",
                DoB = "2002/08/10",
                Address = "New York",
                FullName = "Tom Holand"
            };
            var owner2 = new ApplicationUser
            {
                Id = "6",
                UserName = "owner2@gmail.com",
                Email = "owner2@gmail.com",
                NormalizedUserName = "owner2@gmail.com",
                Image = "https://gamek.mediacdn.vn/133514250583805952/2020/7/11/narutossagemode-15944657133061535033027.png",
                DoB = "2002/08/10",
                Address = "London",
                FullName = "Harry Kane"
            };
            var customer = new ApplicationUser
            {
                Id = "3",
                UserName = "customer@gmail.com",
                Email = "customer@gmail.com",
                NormalizedUserName = "customer@gmail.com",
                Image = "https://file.hstatic.net/200000122283/article/shin-cau-be-but-chi_4017a723e5df4b7d91524dc0bf656c27_1024x1024.jpg",
                DoB = "2002/08/10",
                Address = "Hà Nội",
                FullName = "Trần Minh Nghĩa"
            };

            //2. khai báo thư viện để mã hóa mật khẩu
            var hasher = new PasswordHasher<ApplicationUser>();

            //3. thiết lập và mã hóa mật khẩu   từng tài khoản
            admin.PasswordHash = hasher.HashPassword(admin, "P@ssw0rd");
            admin2.PasswordHash = hasher.HashPassword(admin2, "P@ssw0rd");
            customer.PasswordHash = hasher.HashPassword(customer, "P@ssw0rd");
            admin3.PasswordHash = hasher.HashPassword(admin3, "P@ssw0rd");
            owner1.PasswordHash = hasher.HashPassword(owner1, "P@ssw0rd");
            owner2.PasswordHash = hasher.HashPassword(owner2, "P@ssw0rd");


            builder.Entity<ApplicationUser>().HasData(admin, customer, admin2, admin3, owner1, owner2);
        }

        private void SeedUserRole(ModelBuilder builder)
        {
            builder.Entity<IdentityUserRole<string>>().HasData(
                 new IdentityUserRole<string>
                 {
                     UserId = "1",
                     RoleId = "A"
                 },
                 new IdentityUserRole<string>
                 {
                     UserId = "2",
                     RoleId = "A"
                 },
                 new IdentityUserRole<string>
                 {
                     UserId = "3",
                     RoleId = "B"
                 },
                 new IdentityUserRole<string>
                 {
                     UserId = "5",
                     RoleId = "O"
                 },
                 new IdentityUserRole<string>
                 {
                     UserId = "6",
                     RoleId = "O"
                 },
                 new IdentityUserRole<string>
                 {
                     UserId = "4",
                     RoleId = "A"
                 }
              );

        }

        private void SeedRole(ModelBuilder builder)
        {
            //1. tạo các role cho hệ thống
            var admin = new IdentityRole
            {
                Id = "A",
                Name = "Administrator",
                NormalizedName = "Administrator"
            };
            var customer = new IdentityRole
            {
                Id = "B",
                Name = "Customer",
                NormalizedName = "Customer"
            };
            var Owner = new IdentityRole
            {
                Id = "O",
                Name = "Owner",
                NormalizedName = "Owner"
            };

            //2. add role vào trong DB
            builder.Entity<IdentityRole>().HasData(admin, customer, Owner);
        }

    }

}