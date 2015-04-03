namespace LaptopsSystem.Data.Migrations
{
    
    
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Collections.Generic;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    using Faker;
    using Faker.Extensions;

    using LaptopsSystem.Common;
    using LaptopsSystem.Models;
    using System.Text;
    public sealed class Configuration : DbMigrationsConfiguration<LaptopsSystemDbContext>
    {
        private DateTime _randomDateTimeForSeed;
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            _randomDateTimeForSeed = DateTime.UtcNow.AddDays(-7);
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

            var users = context.Users.ToList();
            var laptops = context.Laptops.ToList();

            for (int i = 0; i < users.Count; i++)
            {
                var currentUserId = users[i].Id;
                HashSet<int> laptopIds = new HashSet<int>();
                int votesCount = RandomGenerator.GetRandomInteger(20, 40);
                while (laptopIds.Count < votesCount)
                {
                    laptopIds.Add(RandomGenerator.GetRandomInteger(0, laptops.Count - 1));
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
                "http://thewirecutter.com/wp-content/uploads/mba1.jpeg",
                "http://bestlaptop4us.com/wp-content/uploads/2014/04/gallery-shot_laptops_14_05.jpg",
                "http://pcdoctor-bg.com/wp-content/uploads/2011/10/qosmio-x505-q850-laptop.png",
                "http://laptop1.eu/product_images/r/322/packard-bell-easynote-laptop1eu__25611_zoom.jpg",
                "http://blog.ardes.bg/wp-content/uploads/2011/08/Dell-XPS-15-L502X-1.jpg",
                "http://ecx.images-amazon.com/images/I/61MW8QNvLOL._SL1462_.jpg",
                "http://www.urbansplatter.com/wp-content/uploads/2014/08/laptops-1.jpg",
                "http://www.rapidpcs.co.uk/media/raw/aspire_5336.jpg",
                "http://cdni.wired.co.uk/1240x826/s_v/Samsung-laptop2.jpg",
                "http://windowsinstalirane.com/wp-content/uploads/2013/06/Install-Windows-on-Laptop.jpg",
                "http://www.windstream.com/uploadedImages/Content/Product/Electronics/Tablets_Laptops_and_Desktops/HP255Laptop.jpg",
                "http://elechub.com/wp-content/uploads/2012/12/hp-laptop-computers-repairs.jpg",
                "https://cdn4.pcadvisor.co.uk/cmsdata/reviews/3465138/Photoshoot_220-Sony.jpg",
                "http://www.domstechblog.com/wp-content/uploads/2014/11/budget-laptop.jpg"
            };
            var users = context.Users.ToList();

            for (int i = 0; i < names.Length; i++)
            {
                Manufacturer manufacturer = new Manufacturer
                {
                    Name = names[i]
                };
                context.Manufacturers.Add(manufacturer);
                context.SaveChanges();

                int laptopsCount = RandomGenerator.GetRandomInteger(15, 25);
                for (int j = 0; j < laptopsCount; j++)
                {
                    var paragraphCount = RandomGenerator.GetRandomInteger(2, 3);
                    string description = String.Empty;
                    for (int p = 0; p < paragraphCount; p++)
                    {
                        string paragraph = String.Join(" ", Lorem.Paragraphs(RandomGenerator.GetRandomInteger(2, 4)));
                        description += paragraph + Environment.NewLine;
                    }
                    description += String.Join(" ", Lorem.Paragraphs(RandomGenerator.GetRandomInteger(1, 3)));

                    Laptop laptop = new Laptop
                    {
                        Model = RandomGenerator.GetRandomString(3, 6).ToUpper(),
                        MonitorId = RandomGenerator.GetRandomInteger(1, 8),
                        ManufacturerId = manufacturer.Id,
                        HardDisk = hardDiskSizes[RandomGenerator.GetRandomInteger(0, hardDiskSizes.Length - 1)],
                        Ram = ramSizes[RandomGenerator.GetRandomInteger(0, ramSizes.Length - 1)],
                        Price = (decimal)RandomGenerator.GetRandomInteger(800, 6000) + 0.01m * (decimal)RandomGenerator.GetRandomInteger(0,99),
                        ImageUrl = imgUrls[RandomGenerator.GetRandomInteger(0, imgUrls.Length - 1)],
                        Weight = RandomGenerator.GetRandomInteger() % 2 == 0 ? (double)RandomGenerator.GetRandomInteger(2, 4) + 0.1 * (double)RandomGenerator.GetRandomInteger(0, 9) : default(double?),
                        AdditionalParts = RandomGenerator.GetRandomInteger() % 2 == 0 ? Lorem.Sentence(3) : null,
                        Description = RandomGenerator.GetRandomInteger() % 2 == 0 ? description : null,
                    };
                    context.Laptops.Add(laptop);
                    context.SaveChanges();

                    int commentsCount = RandomGenerator.GetRandomInteger(4, 15);
                    for (int k = 0; k < commentsCount; k++)
                    {
                        DateTime dateTime = RandomGenerator.GetRandomDateTime(_randomDateTimeForSeed, 8);
                        _randomDateTimeForSeed = dateTime;
                        Comment comment = new Comment
                        {
                            //Content = RandomGenerator.GetRandomText(20,200),
                            Content = Lorem.Paragraph(2),
                            CreatedOn = dateTime,
                            Author = users[RandomGenerator.GetRandomInteger(0,users.Count - 1)],
                            LaptopId = laptop.Id
                        };
                        context.Comments.Add(comment);
                        context.SaveChanges();
                    }
                    _randomDateTimeForSeed = DateTime.UtcNow.AddDays(-7);
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

            User testAdmin = new User
            {
                UserName = "testadmin",
                Email = "admin@admin.bg"
            };
            userManager.Create(testAdmin, GlobalConstants.TestPassword);
            userManager.AddToRole(testAdmin.Id, GlobalConstants.AdminRole);

            User testUser = new User
            {
                UserName = "testuser",
                Email = "user@user.bg"
            };
            userManager.Create(testUser, GlobalConstants.TestPassword);
            userManager.AddToRole(testUser.Id, GlobalConstants.UserRole);

            for (int i = 0; i < 30; i++)
            {
                User user = new User
                {
                    //UserName = RandomGenerator.GetRandomString(5, 10),
                    //Email = String.Format("{0}@{1}.com", RandomGenerator.GetRandomString(4, 8), RandomGenerator.GetRandomString(4, 8)).Replace(' ', 'x').ToLower()
                    UserName = Faker.Internet.UserName(),
                    Email = Faker.Internet.Email()
                };
                userManager.Create(user, GlobalConstants.TestPassword);
                userManager.AddToRole(user.Id, RandomGenerator.GetRandomInteger() > 66 ? GlobalConstants.AdminRole : GlobalConstants.UserRole);
            }
            context.SaveChanges();
        }
    }
}
