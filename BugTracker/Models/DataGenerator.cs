using BugTracker.Core.Entities;
using BugTracker.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace BugTracker.Api.Models
{
    public class DataGenerator
    {

        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BugTrackerDbContext(
              serviceProvider.GetRequiredService<DbContextOptions<BugTrackerDbContext>>()))
            {
                // Look for any bugs.
                if (context.Bugs.Any())
                {
                    return;   // Data was already seeded
                }

                context.Categories.AddRange(

                new Category { Id = 1, Name = "Category 1", Description = "Desc Category 1" },
                new Category { Id = 2, Name = "Category 2", Description = "Desc Category 2" },
                new Category { Id = 3, Name = "Category 3", Description = "Desc Category 3" }

                  );

                context.Users.AddRange(
                     new User { Id = 1, Email = "user1@test.com", Name = "test1", Password = "12345678", Role = (User.RoleType)1, UserName = "user1", isActive = true },
                    new User { Id = 2, Email = "user2@test.com", Name = "test2", Password = "12345678", Role = (User.RoleType)1, UserName = "user2", isActive = true },
                    new User { Id = 3, Email = "user3@test.com", Name = "test3", Password = "12345678", Role = (User.RoleType)0, UserName = "Admin", isActive = true }

                    );

                context.Bugs.AddRange(
                      new Bug { Id = 1, Title = "BUG 1", Description = "bug 1 phase dev test", Criticality = (Bug.CriticalityType)1, CreatedAt = DateTime.Now, CategoryID = 1, UserID = 1 },
                    new Bug { Id = 2, Title = "BUG 2", Description = "bug 3 phase dev test", Criticality = (Bug.CriticalityType)1, CreatedAt = DateTime.Now, CategoryID = 2, UserID = 2 },
                    new Bug { Id = 3, Title = "BUG 3", Description = "bug 4 phase dev test", Criticality = (Bug.CriticalityType)1, CreatedAt = DateTime.Now, CategoryID = 3, UserID = 3 }
               );

                context.SaveChanges();
            }
        }
    }

}
