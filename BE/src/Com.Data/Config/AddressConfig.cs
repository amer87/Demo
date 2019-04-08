using Com.Common;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Com.Repo")]
namespace Com.Data
{
    internal class AddressConfig
    {
        public AddressConfig(EntityTypeBuilder<Address> builder)
        {
            builder.HasIndex(x => new { x.BelongsTo, x.Type }).IsUnique();

            builder.HasData(
                   new Address
                   {
                       Id = Constants.UserAddress,
                       AddressLine1 = "Something here",
                       AddressLine2 = "Something there",
                       City = "Putra Jaya",
                       State = "Selangor",
                       Country = "Malaysia",
                       BelongsTo = Constants.UserId,
                       AddedDate = Constants.AddedDate,
                       ModifiedDate = Constants.ModifiedDate,
                       Creator = Constants.AdminId,
                       Modifier = Constants.AdminId
                   },
                    new Address
                    {
                        Id = Guid.NewGuid(),
                        AddressLine1 = "Something here",
                        AddressLine2 = "Something there",
                        City = "Putra Jaya",
                        State = "Selangor",
                        Country = "Malaysia",
                        BelongsTo = Constants.UserApple,
                        AddedDate = Constants.AddedDate,
                        ModifiedDate = Constants.ModifiedDate,
                        Creator = Constants.AdminId,
                        Modifier = Constants.AdminId
                    },
                     new Address
                     {
                         Id = Guid.NewGuid(),
                         AddressLine1 = "Something here",
                         AddressLine2 = "Something there",
                         City = "Putra Jaya",
                         State = "Selangor",
                         Country = "Malaysia",
                         BelongsTo = Constants.UserFord,
                         AddedDate = Constants.AddedDate,
                         ModifiedDate = Constants.ModifiedDate,
                         Creator = Constants.AdminId,
                         Modifier = Constants.AdminId
                     }

               );
        }
    }
}
