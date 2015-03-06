namespace LaptopsSystem.Data.Migrations
{
    using LaptopsSystem.Common;
    using LaptopsSystem.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Collections.Generic;

    public sealed class Configuration : DbMigrationsConfiguration<LaptopsSystemDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(LaptopsSystemDbContext context)
        {
            SeedMonitorSizes(context);
            SeedRolesAndUsers(context);
            SeedManufacturersLaptopsComments(context);
            SeedVotes(context);
        }

        private void SeedVotes(LaptopsSystemDbContext context)
        {
            if (context.Votes.Any())
            {
                return;
            }

            var users = context.Users.Take(20).ToList();
            var laptops = context.Laptops.Take(60).ToList();

            for (int i = 0; i < users.Count; i++)
            {
                var currentUserId = users[i].Id;
                HashSet<int> laptopIds = new HashSet<int>();
                int votesCount = RandomGenerator.GetRandomNumber(8, 16);
                while (laptopIds.Count < votesCount)
                {
                    laptopIds.Add(RandomGenerator.GetRandomNumber(0, laptops.Count - 1));
                }
                foreach (var laptopId in laptopIds)
                {
                    Vote vote = new Vote
                    {
                        UserId = currentUserId,
                        LaptopId = laptops[laptopId].Id
                    };
                    context.Votes.Add(vote);
                }
            }
            context.SaveChanges();
        }

        private void SeedMonitorSizes(LaptopsSystemDbContext context)
        {
            if (context.MonitorSizes.Any())
            {
                return;
            }

            context.MonitorSizes.Add(new MonitorSize { Size = 10.0 });
            context.MonitorSizes.Add(new MonitorSize { Size = 11.6 });
            context.MonitorSizes.Add(new MonitorSize { Size = 13.3 });
            context.MonitorSizes.Add(new MonitorSize { Size = 14.0 });
            context.MonitorSizes.Add(new MonitorSize { Size = 15.4 });
            context.MonitorSizes.Add(new MonitorSize { Size = 15.6 });
            context.MonitorSizes.Add(new MonitorSize { Size = 17.0 });
            context.MonitorSizes.Add(new MonitorSize { Size = 18.5 });
            context.MonitorSizes.Add(new MonitorSize { Size = 19.0 });
            context.MonitorSizes.Add(new MonitorSize { Size = 20.0 });
            context.MonitorSizes.Add(new MonitorSize { Size = 21.0 });
            context.MonitorSizes.Add(new MonitorSize { Size = 22.0 });
            context.MonitorSizes.Add(new MonitorSize { Size = 23.0 });
            context.SaveChanges();
        }

        private void SeedManufacturersLaptopsComments(LaptopsSystemDbContext context)
        {
            if (context.Manufacturers.Any())
            {
                return;
            }

            string[] names = new string[] { "DELL", "LENOVO", "HP", "ACER", "TOSHIBA" };
            int[] hardDiskSizes = new int[] { 250, 320, 500, 750, 1000, 2000, 5000 };
            int[] ramSizes = new int[] { 2, 4, 6, 8, 12, 16 };
            string[] imgUrls = new string[] 
            {
                "https://encrypted-tbn3.gstatic.com/images?q=tbn:ANd9GcSZNvVQyOyJhkHXVnxV44Lmarv_WcgNG68c1hF4P1ZgNnZs7tqD",
                "https://encrypted-tbn3.gstatic.com/images?q=tbn:ANd9GcR7FbDHAzeEGCgDVZgHt9rhiYVmb7A6nmQ8vWUR07rTSKTf-jz9",
                "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQh8OnxVyggvIAoEGYOJY9SuSNxLflTjgnsnYfZ1LVQ6AOBZOMjlw",
                "https://encrypted-tbn1.gstatic.com/images?q=tbn:ANd9GcQO4SSYXVX5gEqubUkBCmuNh47F5OCoDWlgtrAtkfyzeTjPubbL",
                "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSZ6s-5XNAooG3XwJVNTufJXzV_Fx7SEs-4HB9M3PHu06rDqGmc8Q"
            };
            var users = context.Users.Take(20).ToList();

            for (int i = 0; i < names.Length; i++)
            {
                Manufacturer manufacturer = new Manufacturer
                {
                    Name = names[i]
                };
                context.Manufacturers.Add(manufacturer);
                context.SaveChanges();

                int laptopsCount = RandomGenerator.GetRandomNumber(3, 7);
                for (int j = 0; j < laptopsCount; j++)
                {
                    Laptop laptop = new Laptop
                    {
                        Model = RandomGenerator.GetRandomString(4, 8).ToUpper(),
                        MonitorId = RandomGenerator.GetRandomNumber(3, 8),
                        ManufacturerId = manufacturer.Id,
                        HardDisk = hardDiskSizes[RandomGenerator.GetRandomNumber(0, hardDiskSizes.Length - 1)],
                        Ram = ramSizes[RandomGenerator.GetRandomNumber(0, ramSizes.Length - 1)],
                        Price = RandomGenerator.GetRandomNumber(800, 2400),
                        ImageUrl = imgUrls[RandomGenerator.GetRandomNumber(0, imgUrls.Length - 1)],
                        Weight = RandomGenerator.GetRandomNumber() % 2 == 0 ? (double)RandomGenerator.GetRandomNumber(2, 4) + 0.1 * (double)RandomGenerator.GetRandomNumber(0, 9) : default(double?),
                        AdditionalParts = RandomGenerator.GetRandomNumber() % 2 == 0 ? RandomGenerator.GetRandomText(10, 30) : null,
                        Description = RandomGenerator.GetRandomNumber() % 2 == 0 ? RandomGenerator.GetRandomText(100, 300) : null,
                    };
                    context.Laptops.Add(laptop);
                    context.SaveChanges();

                    int commentsCount = RandomGenerator.GetRandomNumber(4, 14);
                    for (int k = 0; k < commentsCount; k++)
                    {
                        Comment comment = new Comment
                        {
                            Content = RandomGenerator.GetRandomText(20,200),
                            Author = users[RandomGenerator.GetRandomNumber(0,users.Count - 1)],
                            LaptopId = laptop.Id
                        };
                        context.Comments.Add(comment);
                        context.SaveChanges();
                    }

                }
                context.SaveChanges();
            }

        }

        private void SeedRolesAndUsers(LaptopsSystemDbContext context)
        {
            if (context.Roles.Any())
            {
                return;
            }

            context.Roles.Add(new IdentityRole(GlobalConstants.AdminRole));
            context.Roles.Add(new IdentityRole(GlobalConstants.UserRole));
            context.SaveChanges();

            UserManager<User> userManager = new UserManager<User>(new UserStore<User>(context));
            for (int i = 0; i < 10; i++)
            {
                User user = new User
                {
                    UserName = RandomGenerator.GetRandomString(5, 10),
                    Email = String.Format("{0}@{1}.com", RandomGenerator.GetRandomString(4, 8), RandomGenerator.GetRandomString(4, 8)).Replace(' ', 'x').ToLower()
                };
                userManager.Create(user, GlobalConstants.TestPassword);
                userManager.AddToRole(user.Id, RandomGenerator.GetRandomNumber() > 66 ? GlobalConstants.AdminRole : GlobalConstants.UserRole);
            }
            context.SaveChanges();
        }
    }
}
