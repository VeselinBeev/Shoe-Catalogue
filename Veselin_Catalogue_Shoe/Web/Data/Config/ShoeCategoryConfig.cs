using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Models;

namespace Web.Data.Config
{
    public class ShoeCategoryConfig : IEntityTypeConfiguration<ShoeCategory>
    {
        public void Configure(EntityTypeBuilder<ShoeCategory> builder)
        {
            builder.ToTable(nameof(ShoeCategory));

            builder
                .HasMany(e => e.Shoes)
                .WithOne(p => p.Category)
                .OnDelete(DeleteBehavior.SetNull);

        }
    }
}
