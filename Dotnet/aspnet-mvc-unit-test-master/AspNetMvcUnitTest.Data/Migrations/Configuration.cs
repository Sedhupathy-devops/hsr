using AspNetMvcUnitTest.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace AspNetMvcUnitTest.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<AspNetMvcUnitTest.Data.Models.WeTubeContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AspNetMvcUnitTest.Data.Models.WeTubeContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            if (!context.Videos.Any())
            {
                context.Videos.AddRange(
                    new List<Video>
                    {
                        new Video
                        {
                            Title = "Learn React - React Crash Course 2018 - React Tutorial with Examples | Mosh",
                            Url = "https://www.youtube.com/watch?v=Ke90Tje7VS0",
                            Duration = 8726,
                            UploadTime = new DateTime(2018, 7, 16),
                            ViewCount = 471732
                        },
                        new Video
                        {
                            Title = "Blazor, a New NET Single Page Application Framework",
                            Url = "https://www.youtube.com/watch?v=GI_9g9lZpik",
                            Duration = 2947,
                            UploadTime = new DateTime(2018, 12, 18),
                            ViewCount = 5276
                        },
                        new Video
                        {
                            Title = "4 Programming Paradigms in 40 Minutes",
                            Url = "https://www.youtube.com/watch?v=cgVVZMfLjEI",
                            Duration = 2487,
                            UploadTime = new DateTime(2018, 3, 18),
                            ViewCount = 110715
                        }
                    });
            }
        }
    }
}
