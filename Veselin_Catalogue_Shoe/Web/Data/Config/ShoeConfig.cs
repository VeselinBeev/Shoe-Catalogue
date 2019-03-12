using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Models;

namespace Web.Data.Config
{
    public class ShoeConfig : IEntityTypeConfiguration<Shoe>
    {
        public void Configure(EntityTypeBuilder<Shoe> builder)
        {
            builder.ToTable(nameof(Shoe));

            builder
                .HasOne(e => e.Category)
                .WithMany(p => p.Shoes);
        }
    }
}
