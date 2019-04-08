using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Com.Repo")]
namespace Com.Data
{
    internal class TypeConfig<T, K> where T : struct, IConvertible where K:BaseType, new()
    {
        public TypeConfig(EntityTypeBuilder<K> builder)
        {
            List<K> data = new List<K>();

            foreach (var area in Enum.GetNames(typeof(T)))
            {
                data.Add(new K { Id = (short)Enum.Parse(typeof(T), area), Name = area });
            }

            builder.HasData(data);
        }
    }
}
