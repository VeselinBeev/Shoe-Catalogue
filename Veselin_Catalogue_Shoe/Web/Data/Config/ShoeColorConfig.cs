using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Models;
using Web.Models.Shoe;

namespace Web.Data.Config
{
    public class ShoeColorConfig : IEntityTypeConfiguration<ShoeColor>
    {
        public void Configure(EntityTypeBuilder<ShoeColor> builder)
        {
            builder.ToTable(nameof(ShoeColor));

            builder
                .HasMany(e => e.SpecificShoes)
                .WithOne(p => p.Color)
                .OnDelete(DeleteBehavior.SetNull);

        }
    }
}
