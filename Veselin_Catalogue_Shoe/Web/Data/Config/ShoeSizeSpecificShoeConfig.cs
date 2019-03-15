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
    public class ShoeSizeSpecificShoeConfig : IEntityTypeConfiguration<ShoeSizeSpecificShoe>
    {
        public void Configure(EntityTypeBuilder<ShoeSizeSpecificShoe> builder)
        {
            builder.ToTable(nameof(ShoeSizeSpecificShoe));

            builder
               .HasKey(ss => new { ss.ShoeSizeId, ss.SpecificShoeId });

            builder
                .HasOne(ss => ss.ShoeSize)
                .WithMany(shoesize => shoesize.ShoeSizeSpecificShoes)
                .HasForeignKey(ss => ss.ShoeSizeId);

            builder
                .HasOne(ss => ss.SpecificShoe)
                .WithMany(e => e.ShoeSizeSpecificShoes)
                .HasForeignKey(ss => ss.SpecificShoeId);
        }
    }
}
