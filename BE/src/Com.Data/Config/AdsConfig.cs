
using Com.Common;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Com.Repo")]
namespace Com.Data
{
    internal class AdsConfig
    {
        public AdsConfig(EntityTypeBuilder<Ad> builder)
        {
            builder.HasIndex(t => t.Code).IsUnique();

            builder.HasData(
                   new Ad
                   {
                       Id = Constants.AdClassic,
                       Code = "classic",
                       Name = "Classic Ad",
                       Description = "Offers the most basic level of advertisement",
                       Price = 269.99,
                       AddedDate = Constants.AddedDate,
                       ModifiedDate = Constants.ModifiedDate,
                       Creator = Constants.AdminId,
                       Modifier = Constants.AdminId
                   },

                   new Ad
                   {
                       Id = Constants.AdStandout,
                       Code = "standout",
                       Name = "Standout Ad",
                       Description = "Allows advertisers to use a company logo and use a longer presentation text",
                       Price = 322.99,
                       AddedDate = Constants.AddedDate,
                       ModifiedDate = Constants.ModifiedDate,
                       Creator = Constants.AdminId,
                       Modifier = Constants.AdminId
                   },

                   new Ad
                   {
                       Id = Constants.AdPremium,
                       Code = "premium",
                       Name = "Premium Ad",
                       Description = "Same benefits as Standout Ad, but also puts the advertisement at the top of the results, allowing higher visibility",
                       Price = 394.99,
                       AddedDate = Constants.AddedDate,
                       ModifiedDate = Constants.ModifiedDate,
                       Creator = Constants.AdminId,
                       Modifier = Constants.AdminId
                   }

               );
        }
    }
}
