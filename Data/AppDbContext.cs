using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<TypeEntity> Types { get; set; }
        public DbSet<ComputerEntity> Computers { get; set; }
        public DbSet<ProducerEntity> Producers { get; set; }


        private string Path { get; set; }
        public AppDbContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            Path = System.IO.Path.Join(path, "comps.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data source={Path}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //// ADMIN ////
            string ADMIN_ID = Guid.NewGuid().ToString();
            string ADMIN_ROLE_ID = Guid.NewGuid().ToString();


            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Name = "admin",
                NormalizedName = "ADMIN",
                Id = ADMIN_ROLE_ID,
                ConcurrencyStamp = ADMIN_ROLE_ID
            });

            var admin = new IdentityUser
            {
                Id = ADMIN_ID,
                UserName = "Adam",
                NormalizedUserName = "ADAM",
                Email = "adam123@wsei.edu.pl",
                NormalizedEmail = "ADAM123@WSEI.EDU.PL",
                EmailConfirmed = true,
            };

            PasswordHasher<IdentityUser> adminPasswordHasher = new PasswordHasher<IdentityUser>();
            admin.PasswordHash = adminPasswordHasher.HashPassword(admin, "AhE5tgGvy99GN8G");

            modelBuilder.Entity<IdentityUser>().HasData(admin);

            modelBuilder.Entity<IdentityUserRole<string>>()
            .HasData(new IdentityUserRole<string>
            {
                RoleId = ADMIN_ROLE_ID,
                UserId = ADMIN_ID
            });


            //// USER ////
            string USER_ID = Guid.NewGuid().ToString();
            string USER_ROLE_ID = Guid.NewGuid().ToString();

            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Name = "user",
                NormalizedName = "USER",
                Id = USER_ROLE_ID,
                ConcurrencyStamp = USER_ROLE_ID
            });

            var user = new IdentityUser
            {
                Id = USER_ID,
                UserName = "Jan",
                NormalizedUserName = "JAN",
                Email = "jan@microsoft.wsei.edu.pl",
                NormalizedEmail = "JAN@MICROSOFT.WSEI.EDU.PL",
                EmailConfirmed = true,
            };

            PasswordHasher<IdentityUser> userPasswordHasher = new PasswordHasher<IdentityUser>();
            user.PasswordHash = userPasswordHasher.HashPassword(user, "UV1I0N4LP9ZpKOs");

            modelBuilder.Entity<IdentityUser>().HasData(user);

            modelBuilder.Entity<IdentityUserRole<string>>()
                .HasData(new IdentityUserRole<string>
                {
                    RoleId = USER_ROLE_ID,
                    UserId = USER_ID
                });


            //// MOD ////
            string MOD_ID = Guid.NewGuid().ToString();
            string MOD_ROLE_ID = Guid.NewGuid().ToString();

            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Name = "mod",
                NormalizedName = "MOD",
                Id = MOD_ROLE_ID,
                ConcurrencyStamp = MOD_ROLE_ID
            });

            var mod = new IdentityUser
            {
                Id = MOD_ID,
                UserName = "Tomasz",
                NormalizedUserName = "TOMASZ",
                Email = "tomasz@wsei.edu.pl",
                NormalizedEmail = "TOMASZ@WSEI.EDU.PL",
                EmailConfirmed = true,
            };

            PasswordHasher<IdentityUser> modPasswordHasher = new PasswordHasher<IdentityUser>();
            mod.PasswordHash = modPasswordHasher.HashPassword(mod, "SejFBV76TumonDv");

            modelBuilder.Entity<IdentityUser>().HasData(mod);

            modelBuilder.Entity<IdentityUserRole<string>>()
                .HasData(new IdentityUserRole<string>
                {
                    RoleId = MOD_ROLE_ID,
                    UserId = MOD_ID
                });


            
            //// DATA ////
            modelBuilder.Entity<ComputerEntity>().HasOne(c => c.Type).WithMany(o => o.Computers).HasForeignKey(c => c.TypeId);
            modelBuilder.Entity<ProducerEntity>().HasOne(c => c.Computer).WithMany(o => o.Producers).HasForeignKey(c => c.ComputerId);

            modelBuilder.Entity<TypeEntity>().HasData(
                new
                {
                    TypeId = 1,
                    TypeName = "Laptop",
                },
                new
                {
                    TypeId = 2,
                    TypeName = "Desktop",
                },
                new
                {
                    TypeId = 3,
                    TypeName = "Chromebook",
                },
                new
                {
                    TypeId = 4,
                    TypeName = "All-in-One PC",
                },
                new
                {
                    TypeId = 5,
                    TypeName = "Ultrabook",
                },
                new
                {
                    TypeId = 6,
                    TypeName = "Netbook",
                }
                );


            modelBuilder.Entity<ProducerEntity>().HasData(
                new
                {
                    ProducerId = 1,
                    ComputerId = 1,
                    ProducerName = "Dell",
                    OriginCountry = "USA",
                    Description = "Dell Inc. to amerykańskie przedsiębiorstwo informatyczne założone w 1984 roku przez Michaela Della.",
                    FoundationYear = new DateTime(1984, 2, 1)
                },
                new 
                {
                    ProducerId = 2,
                    ComputerId = 2, 
                    ProducerName = "HP",
                    OriginCountry = "USA",
                    Description = "HP Inc. to amerykańskie przedsiębiorstwo technologiczne z siedzibą w Palo Alto w Kalifornii.",
                    FoundationYear = new DateTime(1939, 1, 1)
                },
                new 
                {
                    ProducerId = 3,
                    ComputerId = 3, 
                    ProducerName = "Apple",
                    OriginCountry = "USA",
                    Description = "Apple Inc. to amerykańskie przedsiębiorstwo technologiczne z siedzibą w Cupertino w Kalifornii.",
                    FoundationYear = new DateTime(1976, 4, 1)
                },
                new 
                {
                    ProducerId = 4,
                    ComputerId = 4, 
                    ProducerName = "Lenovo",
                    OriginCountry = "Chiny",
                    Description = "Lenovo Group Ltd. to chińskie przedsiębiorstwo technologiczne z siedzibą w Pekinie.",
                    FoundationYear = new DateTime(1984, 11, 1)
                },
                new 
                {
                    ProducerId = 5,
                    ComputerId = 5, 
                    ProducerName = "Asus",
                    OriginCountry = "Tajwan",
                    Description = "ASUSTeK Computer Inc. to tajwańskie przedsiębiorstwo komputerowe.",
                    FoundationYear = new DateTime(1989, 4, 2)
                },
                new 
                {
                    ProducerId = 6,
                    ComputerId = 6, 
                    ProducerName = "Acer",
                    OriginCountry = "Tajwan",
                    Description = "Acer Inc. to tajwańskie przedsiębiorstwo informatyczne.",
                    FoundationYear = new DateTime(1976, 8, 1)
                }
                );


            modelBuilder.Entity<ComputerEntity>().HasData(
                new
                {
                    ComputerId = 1,
                    ComputerName = "Dell XPS 13",
                    Processor = "Intel Core i7-1165G7",
                    Memory = "16GB DDR4",
                    GraphicsCard = "Intel Iris Xe Graphics",
                    ProductionDate = new DateTime(2021, 5, 1),
                    TypeId = 1 
                },
                new
                {
                    ComputerId = 2,
                    ComputerName = "HP Pavilion Gaming Desktop",
                    Processor = "AMD Ryzen 5 5600G",
                    Memory = "8GB DDR4",
                    GraphicsCard = "NVIDIA GeForce GTX 1650",
                    ProductionDate = new DateTime(2021, 8, 15),
                    TypeId = 2 
                },
                new
                {
                    ComputerId = 3,
                    ComputerName = "MacBook Air",
                    Processor = "Apple M1",
                    Memory = "8GB Unified Memory",
                    GraphicsCard = "Apple M1 GPU",
                    ProductionDate = new DateTime(2020, 11, 17),
                    TypeId = 1 
                },
                new
                {
                    ComputerId = 4,
                    ComputerName = "Lenovo ThinkPad X1 Carbon",
                    Processor = "Intel Core i7-1165G7",
                    Memory = "16GB LPDDR4X",
                    GraphicsCard = "Intel Iris Xe Graphics",
                    ProductionDate = new DateTime(2021, 3, 1),
                    TypeId = 1 
                },
                new
                {
                    ComputerId = 5,
                    ComputerName = "ASUS ROG Zephyrus G14",
                    Processor = "AMD Ryzen 9 5900HS",
                    Memory = "16GB DDR4",
                    GraphicsCard = "NVIDIA GeForce RTX 3060",
                    ProductionDate = new DateTime(2021, 7, 1),
                    TypeId = 1 
                },
                new
                {
                    ComputerId = 6,
                    ComputerName = "Acer Predator Helios 300",
                    Processor = "Intel Core i7-10750H",
                    Memory = "16GB DDR4",
                    GraphicsCard = "NVIDIA GeForce RTX 3060",
                    ProductionDate = new DateTime(2021, 9, 1),
                    TypeId = 1 
                }
            );

        }
    }
}
