using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using GameStore.Core.Domain.Entities;
using GameStore.Core.Domain.IdentityEntities;

namespace GameStore.Infrastructure.DbContext
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // DbSets
        public DbSet<Game> Games { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Platform> Platforms { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);



            // ========== SEED DATA ==========
            SeedRoles(modelBuilder);
            SeedUsers(modelBuilder);
            SeedUserRoles(modelBuilder);
            SeedGenres(modelBuilder);
            SeedPlatforms(modelBuilder);
            SeedGames(modelBuilder);
        }

        private void SeedRoles(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = "1",
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole
                {
                    Id = "2",
                    Name = "Customer",
                    NormalizedName = "CUSTOMER"
                }
            );
        }

        private void SeedUsers(ModelBuilder modelBuilder)
        {
            // Admin User - Password: Admin@123
            var adminUser = new ApplicationUser
            {
                Id = "admin-001",
                UserName = "admin@gamestore.com",
                NormalizedUserName = "ADMIN@GAMESTORE.COM",
                Email = "admin@gamestore.com",
                NormalizedEmail = "ADMIN@GAMESTORE.COM",
                EmailConfirmed = true,
                FirstName = "Admin",
                LastName = "User",
                RegistrationDate = new DateTime(2024, 1, 1),
                SecurityStamp = "ADMIN-SECURITY-STAMP-12345",
                PasswordHash = "AQAAAAIAAYagAAAAECONiP1tay3gDjMSMFGckOldUWYAQi+ViNCoZTZrCDrLz1ZtYjzJgrgeDC8uwHt17w==",

                ConcurrencyStamp = "c8554266-b401-4519-9aeb-a9283053fc58"
            };

            // Sample Customer User - Password: Customer@123
            var customerUser = new ApplicationUser
            {
                Id = "customer-001",
                UserName = "customer@example.com",
                NormalizedUserName = "CUSTOMER@EXAMPLE.COM",
                Email = "customer@example.com",
                NormalizedEmail = "CUSTOMER@EXAMPLE.COM",
                EmailConfirmed = true,
                FirstName = "John",
                LastName = "Doe",
                RegistrationDate = new DateTime(2024, 1, 15),
                SecurityStamp = "CUSTOMER-SECURITY-STAMP-67890",
                PasswordHash = "AQAAAAIAAYagAAAAEKp0HJ6Vt2YK5xMz8Wq9Lr3Nf4Gh5Jm7Dp1Xs6Ct9En2Br8Yp0Fk3Hn4Qv5Rs1Tw==",
                ConcurrencyStamp = "d9665377-c512-5620-0bfc-b0394164gd69"
            };

            modelBuilder.Entity<ApplicationUser>().HasData(adminUser, customerUser);
        }

        private void SeedUserRoles(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                // Admin Role Assignment
                new IdentityUserRole<string>
                {
                    RoleId = "1",
                    UserId = "admin-001"
                },
                // Customer Role Assignment
                new IdentityUserRole<string>
                {
                    RoleId = "2",
                    UserId = "customer-001"
                }
            );
        }

        private void SeedGenres(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Genre>().HasData(
                new Genre { Id = 1, Name = "Action" },
                new Genre { Id = 2, Name = "Adventure" },
                new Genre { Id = 3, Name = "RPG" },
                new Genre { Id = 4, Name = "Sports" },
                new Genre { Id = 5, Name = "Strategy" },
                new Genre { Id = 6, Name = "Simulation" },
                new Genre { Id = 7, Name = "Racing" },
                new Genre { Id = 8, Name = "Fighting" },
                new Genre { Id = 9, Name = "Horror" },
                new Genre { Id = 10, Name = "Puzzle" }
            );
        }

        private void SeedPlatforms(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Platform>().HasData(
                new Platform { Id = 1, Name = "PC" },
                new Platform { Id = 2, Name = "PlayStation 5" },
                new Platform { Id = 3, Name = "PlayStation 4" },
                new Platform { Id = 4, Name = "Xbox Series X/S" },
                new Platform { Id = 5, Name = "Xbox One" },
                new Platform { Id = 6, Name = "Nintendo Switch" }
            );
        }

        private void SeedGames(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>().HasData(
                new Game
                {
                    GameId = 1,
                    Title = "The Witcher 3: Wild Hunt",
                    Description = "An epic open-world RPG adventure with rich storytelling and immersive gameplay.",
                    Price = 19.99m,
                    OldPrice = 39.99m,
                    GenreId = 3, // RPG
                    PlatformId = 1, // PC
                    ReleaseDate = new DateTime(2015, 5, 19),
                    StockQuantity = 100,
                    ImageUrl = "/images/games/witcher3.jpg"
                },
                new Game
                {
                    GameId = 2,
                    Title = "Grand Theft Auto V",
                    Description = "An action-adventure game set in the fictional state of San Andreas.",
                    Price = 29.99m,
                    OldPrice = null,
                    GenreId = 1, // Action
                    PlatformId = 1, // PC
                    ReleaseDate = new DateTime(2013, 9, 17),
                    StockQuantity = 150,
                    ImageUrl = "/images/games/gtav.jpg"
                },
                new Game
                {
                    GameId = 3,
                    Title = "Red Dead Redemption 2",
                    Description = "An epic tale of life in America's unforgiving heartland in 1899.",
                    Price = 39.99m,
                    OldPrice = 59.99m,
                    GenreId = 2, // Adventure
                    PlatformId = 2, // PlayStation 5
                    ReleaseDate = new DateTime(2018, 10, 26),
                    StockQuantity = 80,
                    ImageUrl = "/images/games/rdr2.jpg"
                },
                new Game
                {
                    GameId = 4,
                    Title = "FIFA 24",
                    Description = "The latest installment in the legendary football game series.",
                    Price = 69.99m,
                    OldPrice = null,
                    GenreId = 4, // Sports
                    PlatformId = 3, // PlayStation 4
                    ReleaseDate = new DateTime(2023, 9, 29),
                    StockQuantity = 120,
                    ImageUrl = "/images/games/fifa24.jpg"
                },
                new Game
                {
                    GameId = 5,
                    Title = "Elden Ring",
                    Description = "A dark fantasy action RPG developed by FromSoftware.",
                    Price = 44.99m,
                    OldPrice = 59.99m,
                    GenreId = 3, // RPG
                    PlatformId = 1, // PC
                    ReleaseDate = new DateTime(2022, 2, 25),
                    StockQuantity = 90,
                    ImageUrl = "/images/games/eldenring.jpg"
                },
                new Game
                {
                    GameId = 6,
                    Title = "The Legend of Zelda: Breath of the Wild",
                    Description = "An open-world adventure game for Nintendo Switch.",
                    Price = 59.99m,
                    OldPrice = null,
                    GenreId = 2, // Adventure
                    PlatformId = 6, // Nintendo Switch
                    ReleaseDate = new DateTime(2017, 3, 3),
                    StockQuantity = 75,
                    ImageUrl = "/images/games/zelda.jpg"
                },
                new Game
                {
                    GameId = 7,
                    Title = "Resident Evil 4 Remake",
                    Description = "Survival horror game with intense action and terrifying enemies.",
                    Price = 59.99m,
                    OldPrice = null,
                    GenreId = 9, // Horror
                    PlatformId = 2, // PlayStation 5
                    ReleaseDate = new DateTime(2023, 3, 24),
                    StockQuantity = 65,
                    ImageUrl = "/images/games/re4.jpg"
                },
                new Game
                {
                    GameId = 8,
                    Title = "Forza Horizon 5",
                    Description = "Open-world racing game set in a beautiful Mexican landscape.",
                    Price = 39.99m,
                    OldPrice = 59.99m,
                    GenreId = 7, // Racing
                    PlatformId = 4, // Xbox Series X/S
                    ReleaseDate = new DateTime  (2021, 11, 9),
                    StockQuantity = 95,
                    ImageUrl = "/images/games/forza5.jpg"
                }
            );
        }
    }
}