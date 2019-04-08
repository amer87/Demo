using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Com.Repo")]

namespace Com.Data
{
    internal class CartsConfig
    {
        public CartsConfig(EntityTypeBuilder<Cart> builder)
        {
        }
    }
}
