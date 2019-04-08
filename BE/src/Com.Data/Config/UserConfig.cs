using Com.Common;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Com.Repo")]
namespace Com.Data
{
    internal class UserConfig
    {
        public UserConfig(EntityTypeBuilder<User> builder)
        {
            builder.HasIndex(t => t.UserName).IsUnique();

            builder.HasData(
                new User
                {
                    Id = Constants.UserId,
                    UserName = "unilever",
                    Password = "$MYHASH$V1$10000$xcFsnGmPpBute45y3p6bGanZvI3JLuPRJGUZopaGHu1mMrPQ",
                    Email = "unilever@yahoo.com",
                    FirstName = "Unilever",
                    LastName = "",
                    AddedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    Creator = Constants.AdminId,
                    Modifier = Constants.AdminId
                },
                new User
                {
                    Id = Constants.UserApple,
                    UserName = "apple",
                    Password = "$MYHASH$V1$10000$xcFsnGmPpBute45y3p6bGanZvI3JLuPRJGUZopaGHu1mMrPQ",
                    Email = "apple@yahoo.com",
                    FirstName = "Apple",
                    LastName = "",
                    AddedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    Creator = Constants.AdminId,
                    Modifier = Constants.AdminId
                },
                new User
                {
                    Id = Constants.UserFord,
                    UserName = "ford",
                    Password = "$MYHASH$V1$10000$xcFsnGmPpBute45y3p6bGanZvI3JLuPRJGUZopaGHu1mMrPQ",
                    Email = "ford@yahoo.com",
                    FirstName = "Ford",
                    LastName = "",
                    AddedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    Creator = Constants.AdminId,
                    Modifier = Constants.AdminId
                },
                new User
                 {
                     Id = Constants.AdminId,
                     UserName = "admin",
                     Password = "$MYHASH$V1$10000$xcFsnGmPpBute45y3p6bGanZvI3JLuPRJGUZopaGHu1mMrPQ",
                     Email = "admin@yahoo.com",
                     FirstName = "Super",
                     LastName = "Admin",
                     Type = UserTypes.Admin,
                     AddedDate = DateTime.Now,
                     ModifiedDate = DateTime.Now
                 }
            );
        }
    }
}
